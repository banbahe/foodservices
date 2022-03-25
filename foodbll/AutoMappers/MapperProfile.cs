using AutoMapper;
using fooddtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace foodbll.AutoMappers
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<OrderDetailDto, storage.OrderDetails>().
             ForMember(dest => dest.unitPrice, src => src.MapFrom(e => e.UnitPrice)).
             ForMember(dest => dest.amount, src => src.MapFrom(e => e.Amount)).
             ForMember(dest => dest.idproduct, src => src.MapFrom(e => e.IdProduct));

            CreateMap<storage.OrderDetails, OrderDetailDto>().
             ForMember(dest => dest.UnitPrice, src => src.MapFrom(e => e.unitPrice)).
             ForMember(dest => dest.Amount, src => src.MapFrom(e => e.amount)).
             ForMember(dest => dest.IdProduct, src => src.MapFrom(e => e.idproduct));

            CreateMap<OrderDto, storage.Orders>().
             ForMember(dest => dest.currentStatus, src => src.MapFrom(e => e.CurrentStatus)).
             ForMember(dest => dest.dateEntry, src => src.MapFrom(e => e.DateEntry)).
             ForMember(dest => dest.idorder, src => src.MapFrom(e => e.IdOrder)).
             ForMember(dest => dest.total, src => src.MapFrom(e => e.Total)).
             ForMember(dest => dest.folio, src => src.MapFrom(e => e.Folio)).
             ForMember(dest => dest.clientname, src => src.MapFrom(e => e.ClientName)).
             ForMember(dest => dest.details, src => src.MapFrom(e => e.Details));

            CreateMap<storage.Orders, OrderDto>().
             ForMember(dest => dest.CurrentStatus, src => src.MapFrom(e => e.currentStatus)).
             ForMember(dest => dest.DateEntry, src => src.MapFrom(e => e.dateEntry)).
             ForMember(dest => dest.IdOrder, src => src.MapFrom(e => e.idorder)).
             ForMember(dest => dest.Total, src => src.MapFrom(e => e.total)).
             ForMember(dest => dest.Folio, src => src.MapFrom(e => e.folio)).
             ForMember(dest => dest.ClientName, src => src.MapFrom(e => e.clientname)).
             ForMember(dest => dest.Details, src => src.MapFrom(e => e.details));

            CreateMap<ProductDto, storage.Products>().
             ForMember(dest => dest.currentStatus, src => src.MapFrom(e => e.CurrentStatus)).
             ForMember(dest => dest.idproduct, src => src.MapFrom(e => e.IdProduct)).
             ForMember(dest => dest.name, src => src.MapFrom(e => e.Name)).
             ForMember(dest => dest.imgPath, src => src.MapFrom(e => e.ImgPath)).
             ForMember(dest => dest.unitPrice, src => src.MapFrom(e => e.UnitPrice)).
             ForMember(dest => dest.sku, src => src.MapFrom(e => e.SKU)).
             ForMember(dest => dest.existence, src => src.MapFrom(e => e.Existence));

            CreateMap<storage.Products, ProductDto>().
             ForMember(dest => dest.CurrentStatus, src => src.MapFrom(e => e.currentStatus)).
             ForMember(dest => dest.IdProduct, src => src.MapFrom(e => e.idproduct)).
             ForMember(dest => dest.Name, src => src.MapFrom(e => e.name)).
             ForMember(dest => dest.ImgPath, src => src.MapFrom(e => e.imgPath)).
             ForMember(dest => dest.UnitPrice, src => src.MapFrom(e => e.unitPrice)).
             ForMember(dest => dest.SKU, src => src.MapFrom(e => e.sku)).
             ForMember(dest => dest.Existence, src => src.MapFrom(e => e.existence));
        }
    }
}
