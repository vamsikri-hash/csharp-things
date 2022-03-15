using ManooruDosa.Models;
using ManooruDosa.Services;
using Microsoft.AspNetCore.Mvc;

namespace ManooruDosa.Controllers;


[ApiController]
[Route("[controller]")]
public class DosaController : ControllerBase
{
    public DosaController()
    {

    }

   [HttpGet]
   public ActionResult<List<Dosa>> GetAll() => DosaService.GetAll();

   [HttpGet("{id}")]
   public ActionResult<Dosa> Get(int id)
   {
       var dosa = DosaService.Get(id);
       if(dosa is null) return NotFound();

       return dosa;
   }

   [HttpPost]
   public IActionResult Create(Dosa dosa)
   {
       DosaService.Add(dosa);
       return CreatedAtAction(nameof(Create),new {id = dosa.Id}, dosa);
   }

   [HttpPut("{id}")]
   public IActionResult Update(int id, Dosa dosa)
   {
       if(id != dosa.Id) return BadRequest();

       var existingDosa = DosaService.Get(id);

       if(existingDosa is null) return NotFound();

       DosaService.Update(dosa);

       return NoContent();
   }

   [HttpDelete("{id}")]
   public IActionResult Delete(int id)
   {
       var dosa = DosaService.Get(id);

       if(dosa is null) return NotFound();

       DosaService.Delete(id);

       return NoContent();
   }


}