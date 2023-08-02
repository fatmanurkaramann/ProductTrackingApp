using Business.DTOs;
using Entity;

namespace Business.Abstract
{
    public interface IProductService
    {
        List<Product> GetAll();
        int Add(ProductDto product);
        int Update(ProductDto product,int id);
        int Delete(int id);
    }
}
