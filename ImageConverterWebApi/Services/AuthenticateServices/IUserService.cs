using ImageConverterWebApi.Models;

namespace ImageConverterWebApi.Services
{
    public interface IUserService
    {
        AuthenticateResponse Authenticate(AuthenticateRequest model);
        UserModel? GetById(int id);
        Task<AuthenticateResponse> Register(AuthenticateRequest userModel);
    }
}