using Application.Abstractions;
using Application.Settings;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace Application.CQRS.Hadiths.Queries
{
    public class GetHadithAudioQuery : IQuery<Result<FileStreamResult>>
    {
        public string FileName { get; set; } = null!;
    }

    public class GetHadithAudioQueryHandler
        : IQueryHandler<GetHadithAudioQuery, Result<FileStreamResult>>
    {
        private readonly HadithAudioSettings _audioSettings;

        public GetHadithAudioQueryHandler(IOptions<HadithAudioSettings> options)
        {
            _audioSettings = options.Value;
        }

        public async Task<Result<FileStreamResult>> Handle(
            GetHadithAudioQuery request,
            CancellationToken cancellationToken)
        {
            // نتحقق من الاسم أولاً
            if (string.IsNullOrWhiteSpace(request.FileName))
                return Result<FileStreamResult>.Failure("FileName is required");

            var fullPath = Path.Combine(_audioSettings.BasePath, request.FileName);

            if (!File.Exists(fullPath))
                return Result<FileStreamResult>.Failure("Audio file not found");
            var stream = new FileStream(
                fullPath,
                FileMode.Open,
                FileAccess.Read,
                FileShare.Read,
                bufferSize: 64 * 1024,
                useAsync: true
            );

            var fileResult = new FileStreamResult(stream, "audio/mpeg")
            {
                EnableRangeProcessing = true
            };

            return Result<FileStreamResult>.Success(fileResult);


        }
    }
}
