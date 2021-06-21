using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SmartSchool.api.Data;
using SmartSchool.api.Models;

namespace SmartSchool.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
  
        public readonly IRepository _repository;

        public ProfessorController(IRepository repository)
       {
            _repository = repository;
        } 

        [HttpGet]
       public IActionResult Get()
       {
           var result = _repository.GetAllProfessores(true);
           return Ok(result);
       }


        [HttpGet("{id}")]
        public ActionResult GetId(int id){
            var result = _repository.GetAllProfessoresById(id, false);
            if(result == null) return BadRequest("ID Não encontrado!");
            return Ok(result);
        }


        [HttpPost]
        public ActionResult Post(Professor professor){

            _repository.add(professor);
            if (_repository.SaveChanges()){
                return Ok(professor);
            }

            return BadRequest("Id nâo encontrado!");
        }
        
        [HttpPut("{id}")]
        public ActionResult Put(int id, Professor professor){
            //AsNoTrackin serve para que ele não quebre a aplicação apos a consulta feita
            var result = _repository.GetAllProfessoresById(id, true);
            if(result == null) return BadRequest("ID Não encontrado!");

            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Professor não encontrado!");
        }

        [HttpPatch("{id}")]
        public ActionResult Patch(int id, Professor professor){
            var result = _repository.GetAllProfessoresById(id, false);
            
            _repository.Update(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Não encontrado!");
        }

        [HttpDelete("{id}")]
        public ActionResult delete(int id, Professor professor){
            var result = _repository.GetAllProfessoresById(id, false);
            if (result == null) return BadRequest("ID Não encontrado!");
            _repository.Delete(professor);
            if (_repository.SaveChanges())
            {
                return Ok(professor);
            }
            return BadRequest("Não encontrado");
        }        
    }
}