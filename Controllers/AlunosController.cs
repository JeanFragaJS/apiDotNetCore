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
    public class AlunosController : ControllerBase
    {
      [HttpPost]
      [Route("alunos")]
      public async Task<ActionResult<Alunos>> Post(
        [FromServices] DataContext db,
        [FromBody] Alunos aluno)
      {
        if(ModelState.IsValid)
        {
          db.Alunos.Add(aluno);
          await db.SaveChangesAsync();
          return aluno;
        }
        else
        {
          return BadRequest(ModelState);
        }
      } 

       [HttpGet]
       [Route("alunos")]
       public async Task<ActionResult<List<Alunos>>> Get([FromServices] DataContext db)
       {
         var alunos = await db.Alunos
         .Include(x => x.Turma)
         .AsNoTracking()
         .ToListAsync();
         return alunos;
       }

       [HttpGet]
       [Route("alunos/{id:int}")]
       public async Task<ActionResult <Alunos>> GetById ([FromServices] DataContext db, int id) 
       {
         var aluno = await db.Alunos
         .Include(x => x.Turma)
         .FirstOrDefaultAsync(x => x.Id == id);
         return aluno;
       }

       [HttpPut]
       [Route("alunos/{id:int}")]
       public async Task<ActionResult<Alunos>> Update([FromServices] DataContext db, int id, [FromBody] Alunos aluno) 
       {
         
         var alunoAntigo = await db.Alunos.FirstOrDefaultAsync(x => x.Id == id);
         if( alunoAntigo == null) 
         {
           return NotFound();
         }
        
          alunoAntigo.Name = aluno.Name;
          alunoAntigo.TurmasId = aluno.TurmasId;
          await db.SaveChangesAsync();
          return Ok();
         
 
       }

       [HttpDelete]
       [Route("alunos/{id:int}")]
       public async Task<ActionResult<Alunos>> Delete ([FromServices] DataContext db, int id) 
       {
          var aluno = await db.Alunos
          .AsNoTracking()
          .FirstOrDefaultAsync(x => x.Id == id);
          if( aluno == null) 
          {
           return NotFound();
          }
           db.Alunos.Remove(aluno);
           db.SaveChanges();

          return Ok();
       }
    }
}