using Core.DTOs.Categories;
using Core.Entities;
using Riok.Mapperly.Abstractions;

namespace Core.Mappers;
[Mapper]
public static partial class CategoryMapper
{
    public static partial CategoryShort ToShortForm(Category source);
    public static partial Category ToEntity(CategoryCreateUpdate source);
    public static partial void ToEntity(CategoryCreateUpdate source, Category target);
}

