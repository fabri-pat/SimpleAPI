using SimpleAPI.Models;

namespace SimpleAPI.Services;
public class ProductService
{
	static List<Product> Products { get; }

	static ProductService()
	{
		Products = new List<Product>();
		Products.Add(new Product
		{
			Name = "Prodottotest",
			Description = "Prodotto di test ottimo da gustare",
			Discount = 0,
			Id = 1,
			IsOnOffering = false,
			MinUnitsToDiscount = 0,
			Price = 12.50
		});
	}

	public static List<Product> GetAll() => Products;

	public static Product? GetProductById(int id) => Products.FirstOrDefault(p => p.Id == id);

	public static void Add(Product product) => Products.Add(product);

	public static void Delete(int id)
    {
		var product = GetProductById(id);

		if(product != null)
			Products.Remove(product);

		return;
    }

	public static void Update(Product product)
    {
		var index = Products.FindIndex(p => p.Id == product.Id);

        if (index != -1)
			Replace(index, product);
        return;
    }

	private static void Replace(int index, Product product)
    {
		Products.RemoveAt(index);
		Products.Insert(index, product);
    }
}
