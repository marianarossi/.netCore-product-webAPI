using AutoMapper;
using AutoMapper.Execution;
using Dapper;
using dotnetAPI.models;
using dotnetAPI.Models;
using dotnetAPI.Models.DTOs;
using System.Data.SqlClient;

namespace dotnetAPI.Services.Impl
{

    public class ProductService : IProductService
    {
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProductService(IConfiguration configuration, IMapper mapper) {
            _configuration = configuration;
            _mapper = mapper;
        }
        public async Task<ResponseModel<List<ProductDTO>>> getProducts()
        {
            ResponseModel <List<ProductDTO>> response = new ResponseModel<List<ProductDTO>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var productsDB = await connection.QueryAsync<Product>("select * from Products");
               
                if (productsDB.Count() == 0)
                {
                    response.Message = "No Products Found";
                    response.Status = false;
                    return response; 
                }

                var mappedProduct = _mapper.Map<List<ProductDTO>>(productsDB);
                response.Data = mappedProduct;
                response.Message = "Products found successfully";
                response.Status = true;
            }

            return response;
        }

        public async Task<ResponseModel<ProductDTO>> getProductById(int id)
        {
            ResponseModel<ProductDTO> response = new ResponseModel<ProductDTO>();
            using(var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var productsDb = await connection.QueryFirstOrDefaultAsync<Product> //or default in case of no products - returns null
                    ("Select * from Products where id = @Id", new { Id = id});
                if(productsDb == null)
                {
                    response.Message = "No product found";

                    response.Status = false;
                    return response; 
                }
                var mappedProduct = _mapper.Map<ProductDTO>(productsDb);

                response.Data = mappedProduct;
                response.Status = true;
                response.Message = "Product found";
            }
            return response;
        }

        public async Task<ResponseModel<List<ProductDTO>>> createProduct(CreateProductDTO createProductDTO)
        {
            ResponseModel<List<ProductDTO>> response = new ResponseModel<List<ProductDTO>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var productDb = await connection
                    .ExecuteAsync("insert into Products (Name, Description, Price, DateCreated) " +
                    "values (@Name, @Description, @Price, @DateCreated)", createProductDTO);
                if(productDb == 0)
                {
                    response.Message = "An error ocurred";
                    response.Status = false;
                    return response;
                }
                var products = await ListProducts(connection);
                var mappedproducts = _mapper.Map<List<ProductDTO>>(products);
                response.Data = mappedproducts;
                response.Status = true;
                response.Message = "Products listed";
            }
            return response;
        }

        private static async Task<IEnumerable<Product>> ListProducts(SqlConnection connection)
        {
            return await connection.QueryAsync<Product>("select * from Products");
        }

        public async Task<ResponseModel<List<ProductDTO>>> editProduct(EditProductDTO editProductDTO)
        {
            ResponseModel<List<ProductDTO>> response = new ResponseModel<List<ProductDTO>>();

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var productsDb = await connection.ExecuteAsync("update Products set Name = @Name," +
                "Description = @Description, Price = @Price where Id = @Id", editProductDTO);

                if(productsDb == 0)
                {
                    response.Message = "An error occurred while trying to edit";
                    response.Status = false;
                    return response;
                }
                var products = await ListProducts(connection);
                var mappedProducts = _mapper.Map<List<ProductDTO>>(products);

                response.Data = mappedProducts;
                response.Status = true;
                response.Message = "Edited successfully";
            }
            return response;
            
        }

        public async Task<ResponseModel<List<ProductDTO>>> removeProduct(int id)
        {
            ResponseModel<List<ProductDTO>> response = new ResponseModel<List<ProductDTO>>();
            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var productsDb = await connection.ExecuteAsync("delete from Products where id = @Id", new {Id = id});
                
                if (productsDb == 0)
                {
                    response.Message = "An error occurred while trying to edit";
                    response.Status = false;
                    return response;
                }
                
                var products = await ListProducts(connection);
                var mappedProducts = _mapper.Map<List<ProductDTO>>(products);
                response.Data = mappedProducts;
                response.Status = true;
                response.Message = "Deleted successfully";
            }
            return response;
        }
    }
}
