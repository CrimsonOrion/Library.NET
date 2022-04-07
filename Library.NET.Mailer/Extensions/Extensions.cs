using Microsoft.AspNetCore.StaticFiles;

namespace Library.NET.Mailer;
public static class Extensions
{
    public static string GetContentType(this FileInfo fileInfo) => new FileExtensionContentTypeProvider().TryGetContentType(fileInfo.FullName, out var cType) ? cType : "application/octet-stream";
}