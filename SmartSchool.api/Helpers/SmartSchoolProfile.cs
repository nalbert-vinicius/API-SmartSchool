using AutoMapper;
using SmartSchool.api.Models;
using SmartSchool.api.DTOs;

namespace SmartSchool.api.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<Aluno, AlunoDTO>()
                .ForMember(
                dest => dest.Nome,
                opt => opt.MapFrom(src => $"{src.Nome} {src.Sobrenome}")
                )
                .ForMember(
                   dest => dest.Idade,
                   opt => opt.MapFrom(src => src.DataNasc.GetCurrentAge())
                );
        }
    }
}
