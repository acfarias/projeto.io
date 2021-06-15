using AutoMapper;

namespace projeto.io.api.Mapeamentos
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegistrarMapeamentos()
        {
            return new MapperConfiguration(m =>
            {
                m.AddProfile(new DomainToViewModelMappingProfile());
                m.AddProfile(new ViewModelToDomainMappingProfile());
            });
        }
    }
}
