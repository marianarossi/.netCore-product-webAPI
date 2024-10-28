using dotnetAPI.Models;
using dotnetAPI.Models.DTOs;

namespace dotnetAPI.Services
{

    public interface IProductService
    {
        Task<ResponseModel<List<ProductDTO>>> getProducts();
        Task<ResponseModel<ProductDTO>> getProductById(int id);
        Task<ResponseModel<List<ProductDTO>>> createProduct(CreateProductDTO createProductDTO);
        Task<ResponseModel<List<ProductDTO>>> editProduct(EditProductDTO editProductDTO);
        Task<ResponseModel<List<ProductDTO>>> removeProduct(int id);
    }
    
}
