using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace foodbll.AutoMappers
{
    public class MainMapper
    {
        public MainMapper()
        {
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MapperProfile());

            });
            Mapper = mappingConfig.CreateMapper();
        }

        public IMapper Mapper { get; set; }
    }
}
