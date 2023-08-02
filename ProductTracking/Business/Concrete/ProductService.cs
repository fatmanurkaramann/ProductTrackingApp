using Business.Abstract;
using Business.DTOs;
using DataAccess;
using DataAccess.Repositories;
using DataAccess.Repositories.Abstraction;
using Entity;
using System.Security.Cryptography;

namespace Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }
       
        public int Add(ProductDto productDto)
        {

            Product product = new() 
            { 
                Name = productDto.Name,
                Price=productDto.Price,
                Stock=productDto.Stock 
            };
            if (productDto.Price == 0 && productDto.Stock == 0)
                throw new Exception("Stok ve Fiyat 0 dan büyük olmalıdır");
           return  _repository.Add(product);
        }

        public int Delete(int id)
        {
            Product product = _repository.GetById(id);
            return _repository.Delete(product);
        }

        public List<Product> GetAll()
        {
           return _repository.GetAll();
        }

        public int Update(ProductDto product, int id)
        {
            Product updatedProduct = _repository.GetById(id);
            updatedProduct.Name = product.Name;
            updatedProduct.Price = product.Price;
            updatedProduct.Stock = product.Stock;
            return _repository.Update(updatedProduct);
        }
    }
}
