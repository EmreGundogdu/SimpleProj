using AutoMapper;
using DataModels;
using Models;

namespace API.Extensions
{
    public static class ConfigureMappingProfile
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(x => x.AddProfile(new AutoMapperMappingProfile()));
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
    public class AutoMapperMappingProfile : Profile
    {
        public AutoMapperMappingProfile()
        {
            CreateMap<Contact, ContactDVO>().ForMember(x => x.FullName, y => y.MapFrom(z => z.FirstName + " " + z.LastName)).ReverseMap();
        }
    }
}
