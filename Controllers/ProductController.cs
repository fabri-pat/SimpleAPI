using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
	private ProductService _productService;
	public ProductController(ProductService productService)
	{
		_productService = productService;
	}

	[HttpGet]
	public IEnumerable<Product> GetAll() => _productService.GetAll();

	[HttpGet("{id}")]
	public ActionResult<List<Product>> Get(int id)
	{
		var product = _productService.GetProductById(id);

		if(product == null)
			return NotFound();

		return Ok(product);
	}

	[HttpPost]
	public IActionResult Create(Product newProduct)
    {
		_productService.Create(newProduct);
		
		return CreatedAtAction(nameof(Create), newProduct);
    }

	[HttpPut("{id}")]
	public IActionResult Update(int id, Product product)
    {
		if (id != product.Id)
			return BadRequest();

		var existingProduct = _productService.GetProductById(id);

		if (existingProduct == null)
			return NotFound();

		_productService.Update(product);

		return Ok(product);
    }

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
    {
		var existingProduct = _productService.GetProductById(id);

		if (existingProduct == null)
			return NotFound(id);

		_productService.DeleteById(id);

		return NoContent();
    }
}
