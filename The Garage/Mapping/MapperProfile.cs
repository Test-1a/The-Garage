using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using The_Garage.Models;

namespace The_Garage.Mapping
{
    public class MapperProfile:Profile
    {
        public MapperProfile()
        {
            CreateMap<Vehicles, DetialViewModel>()
                .ForMember(dest=> dest.Type,
                from => from.MapFrom(t => t.Type))
                .ForMember(dest=> dest.Member, from => from.MapFrom(m => m.Member))
                ;
        }

    }
}
