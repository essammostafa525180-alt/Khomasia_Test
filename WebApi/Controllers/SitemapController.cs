//using Domain.Abstractions;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using System.Text;
//using System.Xml;

//namespace WebApi.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class SitemapController : ControllerBase
//    {
//        private readonly IUnitOfWork _hadithService;
//        private const string BaseUrl = "https://api.hadithportal.com";

//        public SitemapController(IUnitOfWork hadithService)
//        {
//            _hadithService = hadithService;
//        }

//        [HttpGet("/sitemap.xml")]
//        public async Task<IActionResult> GetSitemap()
//        {
//            var sb = new StringBuilder();

//            var settings = new XmlWriterSettings
//            {
//                Indent = true,
//                Encoding = Encoding.UTF8,
//                Async = true
//            };

//            using (var writer = XmlWriter.Create(sb, settings))
//            {
//                await writer.WriteStartDocumentAsync();
//                writer.WriteStartElement("urlset", "http://www.sitemaps.org/schemas/sitemap/0.9");

//                // ============================
//                // الصفحات الثابتة
//                // ============================
//                WriteUrl(writer, $"{BaseUrl}/", "weekly", "1.0");
//                WriteUrl(writer, $"{BaseUrl}/library", "monthly", "0.8");
//                WriteUrl(writer, $"{BaseUrl}/aboutUs", "yearly", "0.5");
//                WriteUrl(writer, $"{BaseUrl}/narrators", "monthly", "0.7");

//                // ============================
//                // Classifications
//                // ============================
//                var classifications = await _hadithService.ClassificationRepository.GetQueryable().AsNoTracking()
//.Select(c => c.Id).ToListAsync();
//                foreach (var id in classifications)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/classification/{id}", "monthly", "0.8");
//                }

//                // ============================
//                // Books
//                // ============================
//                var books = await _hadithService.BookRepository.GetQueryable().AsNoTracking()
//.Select(b => b.Id).ToListAsync();
//                foreach (var id in books)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/book/{id}/babs", "monthly", "0.7");
//                }

//                // ============================
//                // Babs / Hadith
//                // ============================
//                var babs = await _hadithService.BabRepository.GetQueryable().AsNoTracking()
//.Select(b => b.Id).ToListAsync();
//                foreach (var id in babs)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/bab/{id}/hadith", "monthly", "0.6");
//                }

//                // ============================
//                // Takhreej
//                // ============================
//                var takhreej = await _hadithService.HadithTakhreejRepository.GetQueryable().AsNoTracking()
//.Select(h => h.HadithIdFrom).Distinct().ToListAsync();
//                foreach (var id in takhreej)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/takhreej/{id}", "monthly", "0.6");
//                }

//                // ============================
//                // Sharh classifications 
//                // ============================
//                var sharhClassifications = await _hadithService.ClassificationRepository.GetQueryable().AsNoTracking()
//.Where(c => c.Type != 0).Select(c => c.Id).ToListAsync();
//                foreach (var id in sharhClassifications)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/sharh/{id}", "monthly", "0.6");
//                }
//                // ============================
//                // Book sharh  
//                // ============================
//                var sharhBooks = await _hadithService.SharhBookRepository.GetQueryable().AsNoTracking()
//.Select(c => c.Id).ToListAsync();
//                foreach (var id in sharhBooks)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/BookSharh/{id}", "monthly", "0.6");
//                }

//                // ============================
//                // Partitions
//                // ============================
//                var partitions = await _hadithService.PartitionRepository.GetQueryable().AsNoTracking()
//.Select(c => c.Id).ToListAsync();
//                foreach (var partitionId in partitions)
//                {
//                    WriteUrl(writer, $"{BaseUrl}/partition/{partitionId}/collections", "monthly", "0.7");

//                    var collections = await _hadithService.HadithCollectionRepository.GetQueryable().AsNoTracking()
//.Where(h => h.PartationId == partitionId).Select(c => c.Id).ToListAsync();
//                    foreach (var collectionId in collections)
//                    {
//                        WriteUrl(writer, $"{BaseUrl}/partition/{partitionId}/collection/{collectionId}", "monthly", "0.6");
//                    }
//                }

//                writer.WriteEndElement(); // urlset
//                await writer.WriteEndDocumentAsync();
//            }

//            return Content(sb.ToString(), "application/xml", Encoding.UTF8);
//        }

//        private void WriteUrl(XmlWriter writer, string loc, string changefreq, string priority)
//        {
//            writer.WriteStartElement("url");
//            writer.WriteElementString("loc", loc);
//            writer.WriteElementString("lastmod", DateTime.UtcNow.ToString("yyyy-MM-dd"));
//            writer.WriteElementString("changefreq", changefreq);
//            writer.WriteElementString("priority", priority);
//            writer.WriteEndElement();
//        }
//    }