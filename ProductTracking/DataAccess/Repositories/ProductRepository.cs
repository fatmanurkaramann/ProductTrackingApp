using DataAccess.Repositories.Abstraction;
using Entity;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccess.Repositories
{

    public class ProductRepository : Repository<Product, ProductTrackingDbContext>, IProductRepository
    {

        //base(dbContext) ifadesi türetilen sınıfın(derived) (burada ProductRepository) temel sınıfının
        //(burada Repository<Product, ProductTrackingDbContext>) constructorını çağırmak için kullanılır.
        //Yani ProductRepository, Repository<Product, ProductTrackingDbContext> sınıfından miras aldığı için,
        //Repository sınıfının constructorını çalıştırmak için base anahtar kelimesini kullanır.

        //base anahtar kelimesi, türetilen sınıfın(Productrepo) temel sınıfını ifade eder.
        //base anahtar kelimesiyle birlikte parantez içinde verilen parametreler,
        //temel sınıfın(repository) ilgili Constructorına gönderilir.
        //Böylece temel sınıfın constructorı çalıştırılmış olur
        //ve temel sınıfın içindeki işlemler gerçekleştirilir.

        public ProductRepository(ProductTrackingDbContext dbContext) : base(dbContext)
        {
           
        }

        public void UpdatePrice(int productId, decimal newPrice)
        {
           
            var productToUpdate = GetById(productId);

            if (productToUpdate != null)
            {
                productToUpdate.Price =(float)newPrice;
                Context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Ürün bulunamadı.");
            }
        }
    }
}
