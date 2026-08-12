using Domain.Enums;
using System.Text.RegularExpressions;

namespace Application.Common
{
    public static class LanguageDetector
    {
        public static DetectedLanguage Detect(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return DetectedLanguage.Unknown;

            if (text.Any(c => c >= 0x0600 && c <= 0x06FF))
                return DetectedLanguage.Arabic;

            if (text.Any(char.IsLetter))
                return DetectedLanguage.Latin;

            return DetectedLanguage.Unknown;
        }

        public static string RemoveDiacritics(this string input)
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string pattern = @"[\u064B-\u0652]";
            return Regex.Replace(input, pattern, "");
        }

        public static string aa = "ss";

    }
}