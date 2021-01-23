using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace ShoppingCart.Application.AutoMapper
{

    //it will configure the AutoMapper instance that is going to be initialized by the Runtime to use these two profiles
    //made up of Mappings
    //Automapper > Configuration > Profiles
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(
                cfg => {
                    cfg.AddProfile(new DomainToViewModelProfile());
                    cfg.AddProfile(new ViewModelToDomainProfile());
                }
                );
        }
    }
}
