﻿using FluentValidation;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserValidator : AbstractValidator<RequestRegisterUserJson>
    {
        public RegisterUserValidator() {
            RuleFor(user => user.Name).NotEmpty().WithMessage(ResourceMessagesException.NAME_EMPTY);
            RuleFor(user => user.Email).NotEmpty().WithMessage("O email não pode ser vazio");
            RuleFor(user => user.Email).EmailAddress();
            RuleFor(user => user.Password.Length).GreaterThanOrEqualTo(6);
        }
    }
}
