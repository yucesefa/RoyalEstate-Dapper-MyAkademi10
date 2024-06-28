using DapperProject.Dtos.CategoryDtos;
using DapperProject.Dtos.ProductDtos;

namespace DapperProject.Services
{
    public interface IProductService
    {
        Task<List<ResultProductDto>> GetAllProductAsync();
        Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync();
        Task CreateProductAsync(CreateProductDto createProductDto);
        Task DeleteProductAsync(int id);
        Task UpdateProductAsync(UpdateProductDto updateProductDto);
        Task<GetByIdProductDto> GetProductAsync(int id);
        Task<int> GetProductCount();
    }
}
