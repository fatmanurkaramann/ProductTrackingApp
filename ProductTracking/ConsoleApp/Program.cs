using Business.Abstract;
using Business.Concrete;
using Business.DTOs;
using DataAccess;
using DataAccess.Repositories.Abstraction;
using DataAccess.Repositories;
using Entity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

public class Program
{
    private static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
          .AddScoped<IProductRepository, ProductRepository>()
            .AddScoped<IProductService, ProductService>()
            .AddScoped<IUserService, UserService>()
            .AddScoped<IUserRepository, UserRepository>()
             .AddDbContext<ProductTrackingDbContext>()
          .BuildServiceProvider();


        while (true)
        {
            Console.WriteLine("Enter your choice:");
            Console.WriteLine("1. Kayıt Ol");
            Console.WriteLine("2. Giriş Yap");

            int choice = Convert.ToInt32(Console.ReadLine());

            //döngü her çalıştığında bi daha newlenmeyecek
            Product product = new Product(serviceProvider.GetRequiredService<IProductService>());
            User user = new User(serviceProvider.GetRequiredService<IUserService>());

            switch (choice)
            {
                case 1:
                    user.CreateUser();
                    break;
                case 2:
                    user.Login();
                    bool isExit = false;
                    while (!isExit)
                    {
                        Console.WriteLine("Enter your choice:");
                        Console.WriteLine("1. Ürün listele");
                        Console.WriteLine("2. Ürün Ekle");
                        Console.WriteLine("3. Ürün Güncelle");
                        Console.WriteLine("4. Ürün sil");
                        Console.WriteLine("5. Çıkış"); 

                        int choice2 = Convert.ToInt32(Console.ReadLine());
                        
                        switch (choice2)
                        {
                            case 1:
                                product.ListProduct();
                                break;
                            case 2:
                                product.AddProduct();
                                break;
                            case 3:
                                product.UpdateProduct();
                                break;
                            case 4:
                                product.DeleteProduct();
                                break;
                            case 5:
                                isExit = true; // Çıkış seçeneği seçildiğinde döngüyü sonlandırır
                                break;
                            default:
                                Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                                break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Geçersiz seçim. Lütfen tekrar deneyin.");
                    break;
            }
        }

    }

}
public class User
{
    readonly IUserService _service;

    public User(IUserService service)
    {
        _service = service;
    }

    public void CreateUser()
    {
        Console.WriteLine(" İsim: ");
        string name = Console.ReadLine();
        Console.WriteLine(" Soyisim: ");
        string surname = Console.ReadLine();
        Console.WriteLine(" Email: ");
        string email = Console.ReadLine();
        Console.WriteLine(" Password: ");
        string password = Console.ReadLine();
        UserDto userDto = new UserDto { Name = name, Surname = surname, Email = email, Password = password };
        _service.CreateUser(userDto);
        Console.WriteLine("Kullanıcı kaydı yapıldı!");
    }
    public void ListUser()
    {
        foreach (var item in _service.GetAll())
        {
            Console.WriteLine("İsim : " + item.Name + " " + item.Surname);
        }

    }
    public void Login()
    {
        Console.WriteLine("Email giriniz");
        string email = Console.ReadLine();
        Console.WriteLine("şifre giriniz");
        string password = Console.ReadLine();

        UserDto userDto = new UserDto { Email = email, Password = password };
        _service.Login(userDto);
    }
}
public class Product
{
    private readonly IProductService _productService;
    //Product sınıfının dışından _productService alanına doğrudan erişim engellendiği için,
    //sınıf içindeki diğer yöntemler ve işlemler bu servisi değiştiremez ve güvenli bir şekilde kullanabilir.
    //Bu sınıf içindeki tutarlılığı ve işleyişi sağlamak için önemli bir yapıdır.
    public Product(IProductService productService)
    {
        _productService = productService;
    }

    public void ListProduct()
    {
        foreach (var item in _productService.GetAll())
        {

            Console.WriteLine("Ürün Id : " + item.Id);
            Console.WriteLine("Ürün Adı : " + item.Name);
            Console.WriteLine("Ürün Fiyatı : " + item.Price);
            Console.WriteLine("Ürün Stok Adedi : " + item.Stock);
            Console.WriteLine("----------------------");
        }

    }
    public void AddProduct()
    {

        Console.WriteLine("Ürün ismi: ");
        string name = Console.ReadLine();
        Console.WriteLine("Ürün stoğu: ");
        int stock = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Ürün fiyatı: ");
        float price = Convert.ToSingle(Console.ReadLine());

        ProductDto product = new ProductDto
        {
            Name = name,
            Stock = stock,
            Price = price
        };
        _productService.Add(product);

        Console.WriteLine("Ürün oluşturuldu!");

    }
    public void UpdateProduct()
    {
        Console.WriteLine("Ürün id: ");
        int id = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Ürün ismi: ");
        string name2 = Console.ReadLine();
        Console.WriteLine("Ürün stoğu: ");
        int stock2 = Convert.ToInt16(Console.ReadLine());
        Console.WriteLine("Ürün fiyatı: ");
        float price2 = Convert.ToSingle(Console.ReadLine());

        ProductDto product2 = new ProductDto
        {
            Name = name2,
            Stock = stock2,
            Price = price2
        };

        _productService.Update(product2, id);
        Console.WriteLine("Ürün Güncellendi!");

    }

    public void DeleteProduct()
    {
        Console.WriteLine("Ürün id: ");
        int id = Convert.ToInt16(Console.ReadLine());
        _productService.Delete(id);
        Console.WriteLine("Ürün Silindi!");

    }
}