namespace Application.Extensions;

internal static class DateTimeExtension
{
    public static DateTime GetLocalTime(this DateTime dateTime)
    {
        return dateTime.Kind == DateTimeKind.Utc
                    ? dateTime.ToLocalTime()
                    : dateTime;
    }
}
