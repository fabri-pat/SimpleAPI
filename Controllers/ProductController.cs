using Microsoft.AspNetCore.Mvc;
using SimpleAPI.Models;
using SimpleAPI.Services;

namespace SimpleAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
	public ProductController()
	{
	}

	[HttpGet]
	public ActionResult<List<Product>> GetAll() => ProductService.GetAll();

	[HttpGet("{id}")]
	public ActionResult<List<Product>> Get(int id)
	{
		var product = ProductService.GetProductById(id);

		if(product == null)
			return NotFound();

		return Ok(product);
	}

	[HttpPost]
	public IActionResult Create(Product product)
    {
		ProductService.Add(product);
		
		return CreatedAtAction(nameof(Create), product);
    }

	[HttpPut("{id}")]
	public IActionResult Update(int id, Product product)
    {
		if (id != product.Id)
			return BadRequest();

		var existingProduct = ProductService.GetProductById(id);

		if (existingProduct == null)
			return NotFound();

		ProductService.Update(product);

		return Ok(product);
    }

	[HttpDelete("{id}")]
	public IActionResult Delete(int id)
    {
		var existingProduct = ProductService.GetProductById(id);

		if (existingProduct == null)
			return NotFound(id);

		ProductService.Delete(id);

		return NoContent();
    }
}
