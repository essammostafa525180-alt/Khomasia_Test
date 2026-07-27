using MediatR;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace Domain.Primitives;

public static class Validator
{
    public static string ValidateEmailAddress(string email)
    {
        NotNullOrWhiteSpace(email);

        // Use a regular expression to validate email format
        if (!Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
        {
            throw new ArgumentException("Invalid email address.", nameof(email));
        }
        return email;
    }

    public static string ValidateWebsiteUrl(string url)
    {
        if (!Regex.IsMatch(url, @"^(?:(https?|http):\/\/)?(([\w-]+(\.[\w-]+)*(\.\w{2,})+)|(\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}))(:(\d+))?([\/?].*)?$", RegexOptions.IgnoreCase))
        {
            throw new ArgumentException("Invalid Website URL.", nameof(url));
        }
        return url;
    }

    public static string ValidateAlphanumeric(string value, int minLength = 3, int maxLength = 50)
    {
        NotNullOrWhiteSpace(value);

        if (value.Length < minLength || value.Length > maxLength)
        {
            throw new ArgumentOutOfRangeException(nameof(value), $"Value length must be between {minLength} and {maxLength} characters.");
        }

        // Use a regular expression to check for alphanumeric characters
        if (!Regex.IsMatch(value, "^[a-zA-Z0-9 ]*$") && !Regex.IsMatch(value, "^[\\u0621-\\u064A ]+$"))
        {
            throw new ArgumentException("Value must contain only alphanumeric characters.", nameof(value));
        }
        return value;
    }

    public static string ValidatePassport(string value)
    {
        NotNullOrWhiteSpace(value);

        if (value.Length < 3 || value.Length > 20)
        {
            throw new ArgumentOutOfRangeException(nameof(value), "Passport Number must be between 3 and 20 characters.");
        }

        // Use a regular expression to check for alphanumeric characters
        if (!Regex.IsMatch(value, "^[a-zA-Z0-9]*$"))
        {
            throw new ArgumentException("Value must contain only alphanumeric characters.", nameof(value));
        }

        return value;
    }

    public static T NotNull<T>(T value)
    {
        if (value == null)
        {
            throw new ArgumentNullException();
        }

        return value;
    }

    public static string NotNullOrWhiteSpace(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException("Value cannot be null, empty, or white space.");
        }

        return value;
    }

    public static string ValidateLength(string value, int maxLength, int minLength = 0)
    {
        if (minLength > 0)
        {
            NotNullOrWhiteSpace(value);

            if (value.Length < minLength)
            {
                throw new ArgumentException($"{nameof(value)} length must be equal to or greater than {minLength}!");
            }
        }

        if (value != null && value.Length > maxLength)
        {
            throw new ArgumentException($"{nameof(value)} length must be equal to or less than {maxLength}!");
        }

        return value;
    }

    public static DateTime ValidateBirthDate(DateTime birthDate)
    {
        // Add your specific birth date validation logic here
        if (birthDate > DateTime.Now)
        {
            throw new ArgumentException("Birth date cannot be in the future.");
        }

        return birthDate;
    }
    public static DateTime ValidateFutureDateWithMinDays(DateTime date, int minimumDays)
    {
        DateTime futureDate = DateTime.Now.AddDays(minimumDays);

        if (date.Date < futureDate.Date)
        {
            throw new ArgumentOutOfRangeException(nameof(date), $"Date must be at least {minimumDays} days in the future.");
        }

        return date;
    }

    public static string ValidateAttachment(IFormFile? image)
    {
          var _allowedExtenstions = new List<string> { ".jpg", ".png"};
          long _maxAllowedPosterSize = 1048576;

        if (!_allowedExtenstions.Contains(Path.GetExtension(image.FileName).ToLower()))
            throw new ArgumentException("Only .png and .jpg images are allowed!");

        if (image.Length > _maxAllowedPosterSize)
            throw new ArgumentException("Max allowed size for poster is 1MB!");

        return image.FileName;
    }

    public static string ValidateFiles(IFormFile? file)
    {
        var _allowedExtenstions = new List<string> { ".pdf", ".docx" };
        long _maxAllowedFileSize = 10485760;


        if (file == null || file.Length == 0)
            throw new ArgumentException("No file uploaded!");
        if (!_allowedExtenstions.Contains(Path.GetExtension(file.FileName).ToLower()))
            throw new ArgumentException("Only .pdf and .docx are allowed!");
        if (file.Length > _maxAllowedFileSize)
            throw new ArgumentException("Max allowed size for File is 1MB!");
        return file.FileName;
    }

}

