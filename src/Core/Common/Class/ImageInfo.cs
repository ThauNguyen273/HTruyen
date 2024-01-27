namespace Core.Common.Class;

public class ImageInfo
{
    public required string ImageId { get; set; }
    public required string ImageMediaType { get; set; }
    public byte[]? ImageData { get; set; }
}
