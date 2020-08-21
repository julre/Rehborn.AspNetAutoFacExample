using AutoMapper;
using Rehborn.AspNetAutoFacExample.Domain;

namespace Rehborn.AspNetAutoFacExample.Application.Values.Mappings
{
    public class ValueProfile : Profile
    {
        public ValueProfile()
        {
            CreateMap<Value, ValueDto>();
        }
    }
}