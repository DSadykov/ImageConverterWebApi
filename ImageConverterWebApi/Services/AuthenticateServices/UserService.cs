using ImageConverterWebApi.Extensions;
using ImageConverterWebApi.Models;
using ImageConverterWebApi.Services.DB;

namespace ImageConverterWebApi.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDBContext _userRepository;
        private readonly IConfiguration _configuration;

        public UserService(UsersDBContext userRepository, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _configuration = configuration;
        }

        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            UserModel? user = _userRepository
                .Users
                .FirstOrDefault(x => x.Email == model.Email && x.Password == model.Password);

            if (user == null)
            {
                // todo: need to add logger
                return new()
                {
                    ErrorMessage = "Wrong email or password!"
                };
            }

            var token = _configuration.GenerateJwtToken(user);

            return new() { Token = token };
        }

        public async Task<AuthenticateResponse> Register(AuthenticateRequest userModel)
        {
            if (_userRepository.Users.FirstOrDefault(x => x.Email == userModel.Email) is not null)
            {
                return new()
                {
                    ErrorMessage = "Email is already taken!"
                };
            }
            _userRepository.Users.Add(new()
            {
                Email = userModel.Email,
                Password = userModel.Password,
            });
            _userRepository.SaveChanges();
            AuthenticateResponse? response = Authenticate(new AuthenticateRequest
            {
                Email = userModel.Email,
                Password = userModel.Password
            });

            return response;
        }

        public UserModel? GetById(int id)
        {
            return _userRepository.Users.FirstOrDefault(x => x.Id == id);
        }
    }
}
