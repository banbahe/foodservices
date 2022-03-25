using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace foodbll.AutoMappers
{
    public interface IMainMapper
    {
        IMapper Mapper { get; set; }
    }
}
