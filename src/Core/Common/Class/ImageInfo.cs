namespace Core.Common.Class;
public class ImageInfo
{
    public required string AvatarId { get; set; }
    public required string MediaType { get; set;}
    public byte[]? Data { get; set; }
}
