using Microsoft.AspNetCore.Mvc;
using Negocio;
using Negocio.Modelo;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductControler : ControllerBase
    {
        ProductApi api = new ProductApi();
        Product product;
        // GET: api/<ValuesController>/products
        [HttpGet("products")]
        public IActionResult Get()
        {
            try
            {
                List<Product> lista = api.GetProductos();
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

        // GET api/<ValuesController>/products/5
        [HttpGet("products/{id}")]
        public IActionResult Get(int id)
        {
            try

            {
                
                product = api.GetProductoById(id);
                if (product == null)
                {
                    return NotFound("Id invalido");
                }
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { msg =  ex.Message });
            }
        }


        // POST api/<ValuesController>/products
        [HttpPost("products")]
        public IActionResult Post([FromBody] Product producto)
        {

            
            try
            {
                 product = api.PostProducto(producto);
                 return StatusCode(201,product);
            }
            catch (Exception ex)
            {
                 return StatusCode(500, ex.Message);
            }

        }
       
        // PUT api/<ValuesController>/5
        [HttpPut]
      
        public IActionResult Put([FromBody] Product producto)
        {   
            try
            {
                product = api.ModificarProducto(producto);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return StatusCode(500,  ex.Message);
            }
        }


        // DELETE api/<ValuesController>/5
        [HttpDelete("products/{id}")]
        public IActionResult Delete(int id)
        {

            try
            {

             var  product = api.EliminarProducto(id);
                return Ok(product);
            }
            catch( Exception ex)
            {
                return StatusCode(500, new { msg = ex.Message } );
            }
         
        }

        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            try
            {
                List<string> lista =  api.GetCategories();
               
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }


        // POST api/<ValuesController>
        [HttpPost("Categories")]
        public IActionResult Post([FromBody] string category)
        {
            try
            {
                api.PostCategorie(category);
                return StatusCode(201, category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred: " + ex.Message);
            }
        }

       


    }
}
