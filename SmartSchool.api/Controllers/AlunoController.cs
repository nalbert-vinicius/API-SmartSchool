using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.api.Models;
using System.Linq;
using SmartSchool.api.Data;
using Microsoft.EntityFrameworkCore;
using SmartSchool.api.DTOs;
using AutoMapper;

namespace SmartSchool.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {

        public readonly IRepository _repository;
        private readonly IMapper _mapper;

        public AlunoController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        

        [HttpGet]
       public IActionResult Get()
       {
            var alunos = _repository.GetAllAlunos(true);
            return Ok(_mapper.Map<IEnumerable<AlunoDTO>>(alunos));
       }

        [HttpGet("{id}")]
       //actionresult responsavel por retornar um dado
       public IActionResult GetByID(int Id)
       {
            //expressão linq para verificar id na lista
            var alunos = _repository.GetAllAlunosById(Id, false);
           if(alunos == null) return BadRequest("Aluno não encontrado");

           var alunoDto = _mapper.Map<AlunoDTO>(alunos);
           return Ok(alunoDto);
       }
      
        
        [HttpPost]
       public IActionResult Post(AlunoDTO model)
       {
            var aluno = _mapper.Map<Aluno>(model);

            _repository.add(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }
            return BadRequest("Aluno não cadastrado");
       }
        
        [HttpPut("{id}")]
       public IActionResult Put(int id, AlunoDTO model)
       {
            var aluno = _repository.GetAllAlunosById(id, true);

            _mapper.Map(model, aluno);
         
            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }
            return BadRequest("Aluno não atualizado");

        }

        [HttpPatch("{id}")]
       public IActionResult Patch (int id, AlunoDTO model)
       {
            var aluno = _repository.GetAllAlunosById(id, true);

            _mapper.Map(model, aluno);

            _repository.Update(aluno);
            if (_repository.SaveChanges())
            {
                return Created($"/api/aluno{model.Id}", _mapper.Map<AlunoDTO>(aluno));
            }
            return BadRequest("Aluno não cadastrado");
        }

         [HttpDelete("{id}")]
       public IActionResult Delete(int id)
       {
            var aluno = _repository.GetAllAlunosById(id, false);

            _repository.Delete(aluno);
            if (_repository.SaveChanges())
            {
                return Ok("Aluno removido");
            }
            return BadRequest("Aluno não removido");
        }
        
    }
}