using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebServer.Models;

namespace WebServer.Controllers 
{
    [Route("api/[controller]")]
    public class ProductsController : Controller {
        // Actions

        int counter = 20;

        // Get all
        [HttpGet]
        public ActionResult Get()
        {
            if(FakeData.Products.Count>0)
            {
                return Ok(FakeData.Products.ToArray());
            }
            else
            {
                return NotFound();
            }
        }

        // Get by id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if(FakeData.Products.ContainsKey(id))
            {
                return Ok(FakeData.Products[id]);
            }
            else
            {
                return NotFound();
            }
        }

        // Get product in price range
        [HttpGet("price/{low}/{high}")]
        public ActionResult GetInRange(int low, int high)
        {
            var products = FakeData.Products.Values.Where(p => p.Price >= low && p.Price <= high).ToArray();
            if(products.Length>0)
            {
                return Ok(products);
            }
            else
            {
                return NotFound();
            }
        }

        // Delete product
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if(FakeData.Products.ContainsKey(id)){
                FakeData.Products.Remove(id);
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // Add product
        [HttpPost]
        public ActionResult Add([FromBody]Product product)
        {
            product.ID = counter++;
            FakeData.Products.Add(product.ID, product);
            return Ok();
        }

        // Update product
        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody]Product product)
        {
            if (FakeData.Products.ContainsKey(id))
            {
                FakeData.Products[id] = product;
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        // Update prices
        [HttpPut("raise/{value}")]
        public ActionResult Raise(double value)
        {
            var flattenedValues = FakeData.Products.Values.ToArray();
            foreach(var cur in flattenedValues)
            {
                cur.Price += value;
            }

            return Ok();
        }
    }
}