using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.ProductDtos;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.ProductRepository.Abstract
{
    public interface IProductDetailRepository
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductDto>> GetActiveProductAsync();
        Task<List<ResultProductDto>> GetPassiveProductAsync();
        Task<bool> CreateProductAsync(CreateProductDto ProductDto);
        Task<ResultProductDto> GetProductByIDAsync(int id);
        Task<bool> DeleteProductAsync(int ProductId);
        Task<bool> UpdateProductAsync(UpdateProductDto ProductDto);
        Task<bool> SetPassiveProductAsync(SetPassiveProductDto ProductDto);
        Task<bool> SetActiveProductAsync(SetActiveProductDto ProductDto);
    }
}
