namespace Domain.Aggregates.HadithAggregate
{
    public class HadithLanguages
    {
        public int Id { get; set; }

        private string _language = string.Empty;
        public string Language
        {
            get => _language;
            set
            {
                _language = value;
                Code = GenerateCode(value);
            }
        }

        public string Code { get; private set; } = string.Empty;

        private static string GenerateCode(string language)
        {
            if (string.IsNullOrWhiteSpace(language))
                return string.Empty;

            var words = language.Trim()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            if (words.Length == 1)
            {
                return words[0].Length >= 2
                    ? words[0][..2].ToUpper()
                    : words[0].ToUpper();
            }

            return string.Concat(words.Select(w => w[0])).ToUpper();
        }
    }
}
