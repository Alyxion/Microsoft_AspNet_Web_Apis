using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers {

    [Route("api/[controller]")]
    public class ProductsController : Controller {
        // Add actions here

    [HttpGet]
    public Product[] GetAllProducts() {
    return FakeData.Products.Values.ToArray();
    }    

    [HttpGet("ByID/{id}")]
    public Product Get(int id) {
    if (FakeData.Products.ContainsKey(id))
        return FakeData.Products[id];
    else
        return null;
    }

    [HttpGet("from/{low}/to/{high}")]
    public Product[] Get(int low, int high) {
        var products = FakeData.Products.Values
        .Where(p => p.Price >= low && p.Price <= high).ToArray();
        return products;
    }    

    [HttpPost]
    public Product Post([FromBody]Product product) {
    product.ID = FakeData.Products.Keys.Max() + 1;
    FakeData.Products.Add(product.ID, product);
    return product; // contains the new ID
    }    

    [HttpDelete("{id}")]
    public void Delete(int id) {
    if (FakeData.Products.ContainsKey(id)) {
        FakeData.Products.Remove(id);
    }
    }
    }
}