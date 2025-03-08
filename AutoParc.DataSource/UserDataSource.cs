using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoParc.Model.Identity;

namespace AutoParc.DataSource;


public class UserDataSource: UserManager<UserModel>
{
    public UserDataSource(IUserStore<UserModel> store, IOptions<IdentityOptions> optionsAccessor, 
        IPasswordHasher<UserModel> passwordHasher, 
        IEnumerable<IUserValidator<UserModel>> userValidators, 
        IEnumerable<IPasswordValidator<UserModel>> passwordValidators, 
        ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, IServiceProvider services, 
        ILogger<UserManager<UserModel>> logger) : base(store, optionsAccessor, passwordHasher, userValidators, passwordValidators, keyNormalizer, errors, services, logger)
    {
         
    }
}