using Domain.Abstractions;
using Infrastructure.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Text;
using System.Xml;

namespace Infrastructure.Services
{
    public class SitemapGeneratorService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _env;
        private const int PageSize = 50000;
        private readonly string BaseUrl;


        public SitemapGeneratorService(IUnitOfWork unitOfWork, IWebHostEnvironment env, IOptions<SitemapSettings> config)
        {
            _unitOfWork = unitOfWork;
            _env = env;
            BaseUrl = config.Value.BaseUrl;

        }

        public async Task GenerateAllAsync()
        {
            var sitemapFiles = new List<string>();

            sitemapFiles.Add(await GenerateStaticSitemapAsync());

            sitemapFiles.Add(await GenerateClassificationsSitemapAsync());

            sitemapFiles.Add(await GenerateBooksSitemapAsync());

            var babFiles = await GeneratePaginatedSitemapAsync(
                "babs",
                () => _unitOfWork.BabRepository.GetQueryable().AsNoTracking().Select(b => b.Id),
                id => $"{BaseUrl}/bab/{id}/hadith"
            );
            sitemapFiles.AddRange(babFiles);

            var takhreejFiles = await GeneratePaginatedSitemapAsync(
                "takhreej",
                () => _unitOfWork.HadithTakhreejRepository.GetQueryable().AsNoTracking().Select(h => h.HadithIdFrom).Distinct(),
                id => $"{BaseUrl}/takhreej/{id}"
            );
            sitemapFiles.AddRange(takhreejFiles);

            sitemapFiles.Add(await GenerateSharhSitemapAsync());

            sitemapFiles.Add(await GenerateOtherSharhSitemapAsync());


            sitemapFiles.Add(await GeneratePartitionsSitemapAsync());

            await GenerateSitemapIndexAsync(sitemapFiles);
        }

        // ============================
        // Static Pages
        // ============================
        private async Task<string> GenerateStaticSitemapAsync()
        {
            var urls = new List<string>
            {
                $"{BaseUrl}/",
                $"{BaseUrl}/library",
                $"{BaseUrl}/aboutUs",
                $"{BaseUrl}/narrators"
            };

            return await WriteFileAsync("sitemap-static.xml", writer =>
            {
                foreach (var url in urls)
                    WriteUrl(writer, url, "weekly", "1.0");
            });
        }

        // ============================
        // Classifications
        // ============================
        private async Task<string> GenerateClassificationsSitemapAsync()
        {
            var ids = await _unitOfWork.ClassificationRepository
                .GetQueryable()
                .AsNoTracking()
                .Select(c => c.Id)
                .ToListAsync();

            return await WriteFileAsync("sitemap-classifications.xml", writer =>
            {
                foreach (var id in ids)
                    WriteUrl(writer, $"{BaseUrl}/classification/{id}", "monthly", "0.8");
            });
        }

        // ============================
        // Books
        // ============================
        private async Task<string> GenerateBooksSitemapAsync()
        {
            var ids = await _unitOfWork.BookRepository
                .GetQueryable()
                .AsNoTracking()
                .Select(b => b.Id)
                .ToListAsync();

            return await WriteFileAsync("sitemap-books.xml", writer =>
            {
                foreach (var id in ids)
                    WriteUrl(writer, $"{BaseUrl}/book/{id}/babs", "monthly", "0.7");
            });
        }

        // ============================
        // Sharh
        // ============================
        private async Task<string> GenerateSharhSitemapAsync()
        {
            var sharhClassifications = await _unitOfWork.ClassificationRepository
                .GetQueryable()
                .AsNoTracking()
                .Where(c => c.Type != 0)
                .Select(c => c.Id)
                .ToListAsync();

            var sharhBooks = await _unitOfWork.SharhBookRepository
                .GetQueryable()
                .AsNoTracking()
                .Select(c => c.Id)
                .ToListAsync();

            return await WriteFileAsync("sitemap-sharh.xml", writer =>
            {
                foreach (var id in sharhClassifications)
                    WriteUrl(writer, $"{BaseUrl}/sharh/{id}", "monthly", "0.6");

                foreach (var id in sharhBooks)
                    WriteUrl(writer, $"{BaseUrl}/BookSharh/{id}", "monthly", "0.6");
            });
        }

        // ============================
        // Partitions & Collections
        // ============================
        private async Task<string> GeneratePartitionsSitemapAsync()
        {
            var partitions = await _unitOfWork.PartitionRepository
                .GetQueryable()
                .AsNoTracking()
                .Select(p => p.Id)
                .ToListAsync();

            var collections = await _unitOfWork.HadithCollectionRepository
                .GetQueryable()
                .AsNoTracking()
                .Select(c => new { c.Id, c.PartationId })
                .ToListAsync();

            return await WriteFileAsync("sitemap-partitions.xml", writer =>
            {
                foreach (var partitionId in partitions)
                {
                    WriteUrl(writer, $"{BaseUrl}/partition/{partitionId}/collections", "monthly", "0.7");

                    var partitionCollections = collections.Where(c => c.PartationId == partitionId);
                    foreach (var collection in partitionCollections)
                    {
                        WriteUrl(writer, $"{BaseUrl}/partition/{partitionId}/collection/{collection.Id}", "monthly", "0.6");
                    }
                }
            });
        }
        // ============================
        // Other Sharh
        // ============================
        private async Task<string> GenerateOtherSharhSitemapAsync()
        {
            var ids = await _unitOfWork.HadithSharhRepository
                .GetQueryable()
                .AsNoTracking()
                .Select(h => h.HadithId)
                .ToListAsync();

            return await WriteFileAsync("sitemap-other-sharh.xml", writer =>
            {
                foreach (var id in ids)
                    WriteUrl(writer, $"{BaseUrl}/other-sharh/{id}", "monthly", "0.6");
            });
        }

        // ============================
        // Paginated (Babs & Takhreej)
        // ============================
        private async Task<List<string>> GeneratePaginatedSitemapAsync(
            string prefix,
            Func<IQueryable<int>> queryFactory,
            Func<int, string> urlBuilder)
        {
            var totalCount = await queryFactory().CountAsync();
            var totalPages = (int)Math.Ceiling((double)totalCount / PageSize);
            var fileNames = new List<string>();

            for (int page = 0; page < totalPages; page++)
            {
                var ids = await queryFactory()
                    .Skip(page * PageSize)
                    .Take(PageSize)

                    .ToListAsync();

                var fileName = $"sitemap-{prefix}-{page + 1}.xml";

                await WriteFileAsync(fileName, writer =>
                {
                    foreach (var id in ids)
                        WriteUrl(writer, urlBuilder(id), "monthly", "0.6");
                });

                fileNames.Add(fileName);
            }

            return fileNames;
        }

        // ============================
        // Sitemap Index
        // ============================
        private async Task GenerateSitemapIndexAsync(List<string> fileNames)
        {
            var path = Path.Combine(_env.WebRootPath, "sitemap.xml");
            var sb = new StringBuilder();

            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8,
                Async = true
            };

            using (var writer = XmlWriter.Create(sb, settings))
            {
                await writer.WriteStartDocumentAsync();
                writer.WriteStartElement("sitemapindex", "http://www.sitemaps.org/schemas/sitemap/0.9");

                foreach (var fileName in fileNames)
                {
                    writer.WriteStartElement("sitemap");
                    writer.WriteElementString("loc", $"{BaseUrl}/{fileName}");
                    writer.WriteElementString("lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"));
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                await writer.WriteEndDocumentAsync();
            }

            await File.WriteAllTextAsync(path, sb.ToString(), Encoding.UTF8);
        }

        // ============================
        // Helpers
        // ============================
        private async Task<string> WriteFileAsync(string fileName, Action<XmlWriter> writeContent)
        {
            var path = Path.Combine(_env.WebRootPath, fileName);
            var sb = new StringBuilder();

            var settings = new XmlWriterSettings
            {
                Indent = true,
                Encoding = Encoding.UTF8,
                Async = true
            };

            using (var writer = XmlWriter.Create(sb, settings))
            {
                await writer.WriteStartDocumentAsync();
                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");
                writeContent(writer);
                writer.WriteEndElement();
                await writer.WriteEndDocumentAsync();
            }

            await File.WriteAllTextAsync(path, sb.ToString(), Encoding.UTF8);
            return fileName;
        }

        private void WriteUrl(XmlWriter writer, string loc, string changefreq, string priority)
        {
            writer.WriteStartElement("url");
            writer.WriteElementString("loc", loc);
            writer.WriteElementString("lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"));
            writer.WriteElementString("changefreq", changefreq);
            writer.WriteElementString("priority", priority);
            writer.WriteEndElement();
        }
    }
}
