using AutoMapper;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FilmesApi.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDTO, Endereco>();
            CreateMap<Endereco, ReadEnderecoDTO>();
            CreateMap<UpdateEnderecoDTO, Endereco>();
        }
    }
}
