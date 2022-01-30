using System.Collections.Generic;
using System.Threading.Tasks;
using jeanFraga.Data;
using Microsoft.AspNetCore.Mvc;
using jeanFraga.Models;
using Microsoft.EntityFrameworkCore;

namespace jeanFraga.Controllers
{
    [Controller]
    [Route("v1/turmas")]  
    public class TurmasController: ControllerBase
    {  


      [HttpPost]
      [Route("")]

      public async Task<ActionResult<Turmas>> Post(
        [FromServices] DataContext db,
        [FromBody] Turmas turma)
      {
        if( ModelState.IsValid)
        {

          db.Turmas.Add(turma);
          await db.SaveChangesAsync();
          return turma;
        }
        else
        {
          return BadRequest(ModelState);
        }
      } 

       [HttpGet]
       [Route("")]
       public async Task<ActionResult<List<Turmas>>> Get([FromServices] DataContext db)
       {
         var turmas = await db.Turmas
         .AsNoTracking()
         .ToListAsync();
         return turmas;
       }

       [HttpGet]
       [Route("{id:int}")]
       public async Task<ActionResult <Turmas>> GetById ([FromServices] DataContext db, int id) 
       {
         var turma = await db.Turmas
         .AsNoTracking()
         .FirstOrDefaultAsync(x => x.Id == id);
         return turma;
       }

       [HttpPut]
       [Route("{id:int}")]
       public async Task<ActionResult<Turmas>> Update([FromServices] DataContext db, int id, [FromBody] Turmas turma) 
       {
         
         var turmaAntiga = await db.Turmas
         .AsNoTracking()
         .FirstOrDefaultAsync(x => x.Id == id);
         if( turmaAntiga == null) 
         {
           return NotFound();
         }
        
          turmaAntiga.Name = turma.Name;
          await db.SaveChangesAsync();
          return Ok();
         
 
       }

       [HttpDelete]
       [Route("{id:int}")]
       public async Task<ActionResult<Turmas>> Delete ([FromServices] DataContext db, int id) 
       {
          var turma = await db.Turmas
          .AsNoTracking()
          .FirstOrDefaultAsync(x => x.Id == id);
          if( turma == null) 
          {
           return NotFound();
          }
           db.Turmas.Remove(turma);
           db.SaveChanges();

          return Ok();
       }
 
    }
}