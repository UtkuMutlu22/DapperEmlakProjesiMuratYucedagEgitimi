using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.CategoryDtos;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.CategoryRepository.Abstract
{
    public interface ICategoryRepository
    {
        Task<List<ResultCategoryDto>> GetAllCategoryAsync();
    }
}
