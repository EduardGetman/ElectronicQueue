using AutoMapper;

namespace ElectronicQueue.Core.Application.Interfaces
{
    public interface IMapWith<T> where T : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
