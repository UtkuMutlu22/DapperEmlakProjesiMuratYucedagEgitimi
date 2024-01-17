using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.CategoryDtos;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
        Task<List<ResultCategoryDto>> GetActiveCategoryAsync();
        Task<List<ResultCategoryDto>> GetPassiveCategoryAsync();
        Task<bool> CreateCategoryAsync(CreateCategoryDto categoryDto);
        Task<ResultCategoryDto> GetCategoryByIDAsync(int id);
        Task<bool> DeleteCategoryAsync(int categoryId);
        Task<bool> UpdateCategoryAsync(UpdateCategoryDto categoryDto);
        Task<bool> SetPassiveCategoryAsync(SetPassiveCategoryDto categoryDto);
        Task<bool> SetActiveCategoryAsync(SetActiveCategoryDto categoryDto);
    }
}
