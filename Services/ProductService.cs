using SimpleAPI.Models;
using SimpleAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace SimpleAPI.Services;
public class ProductService
{
	private readonly ProductContext _context;

	public ProductService(ProductContext productContext)
	{
		_context = productContext;
	}

	public IEnumerable<Product> GetAll()
	{
		return _context.Products
			.AsNoTracking()
			.ToList();
	}

	public Product? GetProductById(int id)
	{
		return _context.Products
			.AsNoTracking()
			.FirstOrDefault(p => p.Id == id);
	} 

	public Product Create(Product newProduct)
	{
		_context.Products.Add(newProduct);
		_context.SaveChanges();

		return newProduct;
	}

	public void DeleteById(int id)
    {
		var productToDelete = _context.Products.Find(id);

		if(productToDelete != null)
		{
			_context.Products.Remove(productToDelete);
			_context.SaveChanges();
		}

		return;
    }

	public void Update(Product product)
    {
		var productToUpdate = _context.Products.Find(product.Id);

        if (productToUpdate != null)
		{
			_context.Products.Remove(productToUpdate);
			_context.Products.Add(product);
			_context.SaveChanges();
		}
        return;
    }

}
