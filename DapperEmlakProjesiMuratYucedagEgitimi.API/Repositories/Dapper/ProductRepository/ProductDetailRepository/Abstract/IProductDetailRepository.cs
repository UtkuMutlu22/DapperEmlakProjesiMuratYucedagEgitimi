using DapperEmlakProjesiMuratYucedagEgitimi.API.Dtos.ProductDtos.ProductDetailDtos;

namespace DapperEmlakProjesiMuratYucedagEgitimi.API.Repositories.Dapper.ProductRepository.ProductDetailRepository.Abstract
{
    public interface IProductDetailRepository
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailAsync();
        Task<List<ResultProductDetailDto>> GetActiveProductDetailAsync();
        Task<List<ResultProductDetailDto>> GetPassiveProductDetailAsync();
        Task<bool> CreateProductDetailAsync(CreateProductDetailDto ProductDetailDto);
        Task<ResultProductDetailDto> GetProductDetailByIDAsync(int id);
        Task<bool> DeleteProductDetailAsync(int ProductDetailId);
        Task<bool> UpdateProductDetailAsync(UpdateProductDetailDto ProductDetailDto);
        Task<bool> SetPassiveProductDetailAsync(SetPassiveProductDetailDto ProductDetailDto);
        Task<bool> SetActiveProductDetailAsync(SetActiveProductDetailDto ProductDetailDto);
    }
}
