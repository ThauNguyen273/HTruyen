namespace Core.Common.Constants;
public static class FormFileContants
{
    public static IReadOnlyDictionary<string, string> Extension => new Dictionary<string, string>()
    {
       { ".png", "image/png" },
       { ".jpg", "image/jpeg" },
       { ".jpeg", "image/jpeg" },
       { ".jfif", "image/jpeg" },
       { ".pjpeg", "image/jpeg" },
       { ".pjp", "image/jpeg" },
       { ".webp", "image/webp" }
    };
    public static string GetMediaType(string extension)
    {
        if (Extension.TryGetValue(extension, out var mediaType))
        {
            return mediaType;
        }

        throw new ArgumentException($"Invalid extension: {extension}");
    }
}
