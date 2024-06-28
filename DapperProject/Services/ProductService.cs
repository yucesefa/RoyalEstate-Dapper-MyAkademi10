using Dapper;
using DapperProject.Context;
using DapperProject.Dtos.ProductDtos;

namespace DapperProject.Services
{
    public class ProductService : IProductService
    {
        private readonly DapperContext _dapperContext;

        public ProductService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            string query = "Insert into TblProduct (ProductName,Price,Stock,CategoryId) values (@productName,@price,@stock,@categoryId)";
            var parameters = new DynamicParameters();
            parameters.Add("@productName", createProductDto.ProductName);
            parameters.Add("@price", createProductDto.Price);
            parameters.Add("@stock", createProductDto.Stock);
            parameters.Add("@categoryId", createProductDto.CategoryId);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task DeleteProductAsync(int id)
        {
            string query = "delete from TblProduct where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }

        public async Task<List<ResultProductDto>> GetAllProductAsync()
        {
            string query = "select * from TblProduct";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<ResultProductDto>(query);
            return values.ToList();
        }

        public async Task<List<ResultProductWithCategoryDto>> GetAllProductWithCategoryAsync()
        {
            string query = "select ProductId,ProductName,Price,Stock,CategoryName from TblProduct inner join TblCategory on TblProduct.CategoryId=TblCategory.CategoryId";
            var connections = _dapperContext.CreateConnection();
            var values = await connections.QueryAsync<ResultProductWithCategoryDto>(query);
            return values.ToList();
        }

        public async Task<GetByIdProductDto> GetProductAsync(int id)
        {
            string query = "select * from TblProduct where ProductId=@productId";
            var parameters = new DynamicParameters();
            parameters.Add("@productId", id);
            var connection = _dapperContext.CreateConnection();
            var value = await connection.QueryFirstOrDefaultAsync<GetByIdProductDto>(query,parameters);
            return value;
        }

        public async Task<int> GetProductCount()
        {
            string query = "select Count(*) from TblProduct";
            var connection = _dapperContext.CreateConnection();
            int value = await connection.QueryFirstOrDefaultAsync<int>(query);
            return value;
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            string query = "Update TblProduct Set ProductName=@p1, Price=@p2, Stock=@p3, CategoryId=@p4 where ProductId=@p5";
            var parameters = new DynamicParameters();
            parameters.Add("@p1", updateProductDto.ProductName);
            parameters.Add("@p2", updateProductDto.Price);
            parameters.Add("@p3", updateProductDto.Stock);
            parameters.Add("@p4", updateProductDto.CategoryId);
            parameters.Add("@p5", updateProductDto.ProductId);
            var connection = _dapperContext.CreateConnection();
            await connection.ExecuteAsync(query, parameters);
        }
    }
}
