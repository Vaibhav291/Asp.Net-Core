using ContosoPizza.Models;
using ContosoPizza.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        public PizzaController() 
        {
        }

        // Get all action
        [HttpGet]
        public ActionResult<List<Pizza_>> GetAll() => PizzaService.GetAll();

        //Get by Id action
        [HttpGet("{id}")]
        public ActionResult<Pizza_> Get(int id)
        {
            var pizza = PizzaService.Get(id);

            if(pizza == null) 
            {
                return NotFound();
            }

            return pizza;
        }

        // Post action
        [HttpPost]
        public IActionResult Create(Pizza_ pizza)
        {
            PizzaService.Add(pizza);
            return CreatedAtAction(nameof(Get), new { id = pizza.Id }, pizza);
        }

        // Put action
        [HttpPut("{id}")]
        public IActionResult Update(int id, Pizza_ pizza)
        {
            if(id != pizza.Id)
                return BadRequest();

            var existingPizza = PizzaService.Get(id);
            if(existingPizza is null)
                return NotFound();

            PizzaService.Update(pizza);

            return NoContent();
        }

        //Delete action
        [HttpDelete("{id}")]
        public IActionResult Delete(int id) 
        {
            var pizza = PizzaService.Get(id);

            if(pizza is null)
                return NotFound();

            PizzaService.Delete(id);

            return NoContent();
        }
    }
}
