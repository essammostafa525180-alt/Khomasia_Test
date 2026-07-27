using Microsoft.Extensions.Localization;

namespace Domain.Shared
{
    public class Result<T>
    {
        public bool IsSuccess { get; private set; }
        public T Data { get; private set; }
        public string ErrorMessage { get; private set; }

        // Private constructor to ensure controlled instantiation.
        private Result(bool success, T data, string errorMessage)
        {
            IsSuccess = success;
            Data = data;
            ErrorMessage = errorMessage;
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>(true, data, null);
        }

        public static Result<T> Failure(string errorMessage)
        {
            return new Result<T>(false, default, errorMessage);
        }
        public static Result<T> FailureLocalized<TLocalizer>(IStringLocalizer<TLocalizer> localizer, string errorKey)
        {
            return new Result<T>(false, default, localizer[errorKey]);
        }
        public static Result<T> SuccessLocalized<TLocalizer>(IStringLocalizer<TLocalizer> localizer, string errorKey)
        {
            return new Result<T>(true, default, localizer[errorKey]);
        }
    }
    public class Result
    {
        public bool IsSuccess { get; private set; }
        public string ErrorMessage { get; private set; }

        private Result(bool isSuccess, string errorMessage)
        {
            IsSuccess = isSuccess;
            ErrorMessage = errorMessage;
        }

        public static Result Success() => new(true, null);

        public static Result Failure(string errorMessage) => new(false, errorMessage);
    }
}
