using AutoMapper;
using MyRecipeBook.Application.Services.AutoMapper;
using MyRecipeBook.Application.Services.Cryptography;
using MyRecipeBook.Communication.Requests;
using MyRecipeBook.Communication.Responses;
using MyRecipeBook.Domain.Repositories.User;
using MyRecipeBook.Exceptions.ExpectionsBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyRecipeBook.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {

        private readonly IUserWriteOnlyRepository _writeOnlyRepository;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IMapper _mapper;
        private readonly PasswordEncripter _passwordEncripter;

        public RegisterUserUseCase(IUserWriteOnlyRepository writeOnlyRepository,
            IUserReadOnlyRepository userReadOnlyRepository,
            PasswordEncripter passwordEncripter,
            IMapper mapper)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _userReadOnlyRepository = userReadOnlyRepository;
            _mapper = mapper;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request)
        {

            Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);

            user.Password = criptografiaDeSenha.Encrypt(request.Password);

            await _writeOnlyRepository.Add(user);

            //Validar a request

            //mapear uma request em uma entidade

            //Salvar no banco de dados

            //Criptografia da senha

            return new ResponseRegisteredUserJson
            {
                Name = request.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            if (result.IsValid == false) { 
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new MyRecipeBookException();
            }
        }
    }
}   
