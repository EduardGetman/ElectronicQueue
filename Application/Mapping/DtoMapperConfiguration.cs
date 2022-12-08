using AutoMapper;

namespace ElectronicQueue.Core.Application.Mapping
{
    public class DtoMapperConfiguration
    {
        private static readonly MapperConfiguration _configuration = new MapperConfiguration(x =>
        {
            x.AddProfile<DtoModelProfile>();

            x.AllowNullCollections = true;
            x.AllowNullDestinationValues = true;
        });
        public static IMapper CreateMapper() => _configuration.CreateMapper();
    }
}
