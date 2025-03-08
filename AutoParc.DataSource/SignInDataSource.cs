using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AutoParc.Model.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace AutoParc.DataSource
{
    public class SignInDataSource : SignInManager<UserModel>
    {
        public SignInDataSource(UserManager<UserModel> userManager, IHttpContextAccessor contextAccessor, 
            IUserClaimsPrincipalFactory<UserModel> claimsFactory, 
            IOptions<IdentityOptions> optionsAccessor, ILogger<SignInManager<UserModel>> logger, 
            IAuthenticationSchemeProvider schemes, IUserConfirmation<UserModel> confirmation) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes, confirmation)
        {
        }
    }
}