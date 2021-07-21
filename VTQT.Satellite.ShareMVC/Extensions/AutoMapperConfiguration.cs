using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace VTQT.Satellite.ShareMVC.Extensions
{
    public static class AutoMapperConfiguration
    {
        public static IMapper Mapper { get; private set; }

        public static MapperConfiguration MapperConfiguration { get; private set; }

        public static void Init(MapperConfiguration config)
        {
            AutoMapperConfiguration.MapperConfiguration = config;
            AutoMapperConfiguration.Mapper = config.CreateMapper();
        }
    }
}
