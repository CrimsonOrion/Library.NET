using Microsoft.AspNetCore.StaticFiles;

namespace Library.NET.Helpers;
public static class Extensions
{
    public static DateTime DoubleToDateTime(this double? dateTime)
    {
        if (dateTime == null)
        {
            return new DateTime();
        }

        var year = Convert.ToUInt16(dateTime.ToString()[..4]);
        var month = Convert.ToUInt16(dateTime.ToString().Substring(4, 2));
        var day = Convert.ToInt16(dateTime.ToString().Substring(6, 2));
        var hour = Convert.ToInt16(dateTime.ToString().Substring(8, 2));
        var minute = Convert.ToInt16(dateTime.ToString().Substring(10, 2));

        return new DateTime(year, month, day, hour, minute, 0);
    }

    public static double PixelsToInchesWidth(this int pixels) => (pixels - 7) / 7d + 1;

    public static double PixelsToInchesHeight(this int pixels) => pixels * 0.75;

    public static int InchesToPoints(this float inches) => Convert.ToInt32(inches * 72f);

    public static string WindowsToLinuxPath(this string path)
    {
        if (string.IsNullOrWhiteSpace(path))
        {
            return string.Empty;
        }

        return path.Trim().Replace('\\', '/');
    }

    public static string FormatZip(this string zip)
    {
        if (string.IsNullOrWhiteSpace(zip))
        {
            return string.Empty;
        }

        zip = zip.Trim();
        if (zip.Length > 5 && !zip.Contains("-")) // If the zip is longer than 5 digits, add the '-' between the zip and extension
        {
            zip = string.Concat(zip.AsSpan(0, 5), "-", zip[5..]);
        }

        return zip;
    }

    public static string FormatPhoneNumber(this string phoneNumber)
    {
        if (string.IsNullOrWhiteSpace(phoneNumber))
        {
            return "None provided";
        }
        else
        {
            phoneNumber = phoneNumber.Trim();
        }

        if (phoneNumber == "0")
        {
            phoneNumber = "None provided";
        }
        else if (phoneNumber.Length < 10)
        {
            phoneNumber = string.Concat("(252) ", phoneNumber.AsSpan(0, 3), "-", phoneNumber.AsSpan(3, 4));
        }
        else if (phoneNumber.StartsWith("1", StringComparison.CurrentCulture))
        {
            phoneNumber = $"({phoneNumber.Substring(1, 3)}) {phoneNumber.Substring(4, 3)}-{phoneNumber[7..]}";
        }
        else
        {
            phoneNumber = $"({phoneNumber[..3]}) {phoneNumber.Substring(3, 3)}-{phoneNumber[6..]}";
        }

        return phoneNumber;
    }

    public static string FormatSSN(this string ssn)
    {
        if (string.IsNullOrWhiteSpace(ssn))
        {
            return string.Empty;
        }

        ssn = ssn.Trim().PadLeft(9, '0')[5..];
        ssn = "xxx-xx-" + ssn;
        return ssn;
    }

    public static string FormatLocation(this string location)
    {
        if (string.IsNullOrWhiteSpace(location))
        {
            return string.Empty;
        }

        if (!location.Contains('-'))
        {
            var tempLoc = location.PadLeft(10, '0');
            location = tempLoc[..4] + "-" + tempLoc.Substring(4, 3) + "-" + tempLoc[7..];
        }
        return location;
    }

    public static string GetContentType(this FileInfo fileInfo) => new FileExtensionContentTypeProvider().TryGetContentType(fileInfo.FullName, out var cType) ? cType : "application/octet-stream";

    // Check for Null section
    public static string CheckForNullString(this object value) => value == null ? string.Empty : value.ToString().Trim();

    public static double CheckForNullDouble(this object value) => value == null ? 0 : (double)value;

    public static decimal CheckForNullDecimal(this object value) => value == null ? 0 : (decimal)value;

    public static int CheckForNullInteger(this object value) => value == null ? 0 : (int)value;

    public static bool CheckForNullBoolean(this object value) => value != null && (bool)value;

    public static DateTime CheckForNullDate(this object value) => value == null ? DateTime.MinValue : (DateTime)value;
}