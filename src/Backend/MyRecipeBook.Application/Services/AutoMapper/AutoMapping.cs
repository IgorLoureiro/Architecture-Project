﻿using AutoMapper;
using MyRecipeBook.Communication.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.Services.AutoMapper
{
    internal class AutoMapping : Profile
    {

        public AutoMapping()
        {
            RequestToDomain();
        }

        private void RequestToDomain()
        {
            CreateMap<RequestRegisterUserJson, Domain.Entities.User>().ForMember(dest => dest.Password, opt => opt.Ignore());
        }

    }
}
