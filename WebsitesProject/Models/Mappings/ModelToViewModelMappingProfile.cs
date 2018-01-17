using System;
using AutoMapper;
using WebsitesProject.Models.OrderViewModels;
using WebsitesProject.Models.WebsiteViewModels;

namespace WebsitesProject.Models.Mappings
{
    public class ModelToViewModelMappingProfile : Profile
    {
        public ModelToViewModelMappingProfile()
        {
            CreateMap<Order, OrderViewModel>();
            CreateMap<Order, CreateOrderViewModel>()
                .ForMember(dest => dest.WebsiteId,
                    opts => opts.MapFrom(src => src.Website.WebsiteId));
            CreateMap<Order, DeleteOrderViewModel>();
            CreateMap<Order, DetailsOrderViewModel>();
            CreateMap<Order, EditOrderViewModel>()
                .ForMember(dest => dest.WebsiteId,
                    opts => opts.MapFrom(src => src.Website.WebsiteId));

            CreateMap<Website, WebsiteViewModel>();
            CreateMap<Website, CreateWebsiteViewModel>();
            CreateMap<Website, DeleteWebsiteViewModel>();
            CreateMap<Website, DetailsWebsiteViewModel>();
            CreateMap<Website, EditWebsiteViewModel>();

        }
    }
}
