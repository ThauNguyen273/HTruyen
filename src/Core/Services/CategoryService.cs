using Core.DTOs.Categories;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;

namespace Core.Services;
public class CategoryService
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryService(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<IEnumerable<CategoryShort>> SearchAsync(
        string? name = null,
        ushort pageNumber = 1,
        ushort pageSize = 15,
        bool isDescending = false)
    {
        var pagination = new PaginationParameters(pageNumber, pageSize);
        var entities = await _categoryRepository.SearchAsync(name ?? string.Empty, pagination, isDescending);

        return entities.Select(CategoryMapper.ToShortForm);
    }

    public async Task<Category?> GetAsync(string id)
    {
        return await _categoryRepository.GetAsync(id);
    }

    public async Task<string> CreateAsync(CategoryCreateUpdate create)
    {
        var entity = CategoryMapper.ToEntity(create);
        entity.MetalTitle = ConvertNameToMetalTitle(create.Name);
        await _categoryRepository.CreateAsync(entity);

        return entity.Id!;
    }

    public async Task ReplaceAsync(string id, CategoryCreateUpdate update)
    {
        var entity = await _categoryRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        CategoryMapper.ToEntity(update, entity);
        entity.MetalTitle = ConvertNameToMetalTitle(update.Name);
        await _categoryRepository.ReplaceAsync(entity);
    }

    public async Task DeleteAsync(string id)
    {
        try
        {
            await _categoryRepository.DeleteAsync(id);
        }
        catch (KeyNotFoundException ex) 
        {
            throw ex;
        }
    }

    private string ConvertNameToMetalTitle(string name)
    {
        string withoutPunctuation = RemoveDiacritics(name);
        string convert = withoutPunctuation.Replace(" ", "-").ToLower();
        string metalTitle = "truyen-" + convert;

        return metalTitle;
    }

    private string RemoveDiacritics(string text)
    {
        // Dùng bảng mã Unicode để loại bỏ dấu thanh
        string normalizedString = text.Normalize(NormalizationForm.FormD);
        StringBuilder stringBuilder = new StringBuilder();

        foreach (char c in normalizedString)
        {
            // Bỏ qua các ký tự dấu thanh
            if (CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
            {
                stringBuilder.Append(c);
            }
        }

        return stringBuilder.ToString();
    }
}