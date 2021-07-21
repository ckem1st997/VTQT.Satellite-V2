using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using VTQT.Satellite.Entity.Entity;
using VTQT.Satellite.ShareMVC.Models;

namespace VTQT.Satellite.ShareMVC.Extensions
{
    public static class MappingExtensions
    {
        private static IMapper _mapper;
        public static void Configure(IMapper mapper)
        {
            _mapper = mapper;
        }
        public static SubModel ToModel(this Subscriber entity)
        {
            return _mapper.Map<Subscriber, SubModel>(entity);
        }

        public static Subscriber ToEntity(this SubModel model)
        {
            return _mapper.Map<SubModel, Subscriber>(model);
        }

        public static Subscriber ToEntity(this SubModel model, Subscriber destination)
        {
            return _mapper.Map(model, destination);
        }

    }
}
