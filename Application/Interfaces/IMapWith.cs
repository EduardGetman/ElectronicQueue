using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicQueue.Core.Application.Interfaces
{
    public interface IMapWith<T> where T : class
    {
        void Mapping(Profile profile) => profile.CreateMap(typeof(T), GetType());
    }
}
