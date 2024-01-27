using Core.DTOs.Images;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]

public static partial class ImageMapper
{
    public static partial ImageShort ToShortForm(Image source);
    public static partial Image ToEntity(ImageCreateUpdate source);
    
    public static partial void ToEntity(ImageCreateUpdate source, Image target);

}
