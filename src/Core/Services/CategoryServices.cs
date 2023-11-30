using Core.DTOs.Categories;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Mappers;
using Core.Repositories.Parameters;

namespace Core.Services;
public class CategoryServices
{
    private readonly ICategoryRepository _categoryRepository;

    public CategoryServices(ICategoryRepository categoryRepository)
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
        await _categoryRepository.CreateAsync(entity);

        return entity.Id!;
    }

    public async Task ReplaceAsync(string id, CategoryCreateUpdate update)
    {
        var entiry = await _categoryRepository.GetAsync(id) ?? throw new KeyNotFoundException();
        CategoryMapper.ToEntity(update, entiry);
        await _categoryRepository.ReplaceAsync(entiry);
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
}