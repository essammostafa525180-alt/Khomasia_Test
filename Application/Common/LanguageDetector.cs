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

        //public static string Normalize(string text)
        //{
        //    if (string.IsNullOrWhiteSpace(text))
        //        return text;

        //    return text
        //        .Replace("أ", "ا")
        //        .Replace("إ", "ا")
        //        .Replace("آ", "ا")
        //        .Replace("ى", "ي")
        //        .Replace("ة", "ه")
        //        .Replace("ؤ", "و")
        //        .Replace("ئ", "ي")
        //        .Replace("ء", "")
        //        .Replace("ـ", "")
        //        .RemoveDiacritics();
        //}


    }
}