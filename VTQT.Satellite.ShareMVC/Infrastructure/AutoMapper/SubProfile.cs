using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.ShareMVC.Models;

namespace VTQT.Satellite.ShareMVC.Infrastructure.AutoMapper
{
    public class SubProfile : Profile
    {
        public SubProfile()
        {
            CreateMap<Subscriber, SubModel>();
            CreateMap<SubModel, Subscriber>();
        }
    }
}

