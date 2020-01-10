using AutoMapper;
using Dominio.EntidadesDto;
using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Mapa
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            //ENTIDAD A DTO
            CreateMap<Producto, ProductoDto>().ReverseMap();

            //DTO A ENTIDAD
            CreateMap<ProductoDto, Producto>().ReverseMap();
        }
    }
}