using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TodoApplication.Data.Model;

namespace TodoApplication.Services
{
	/// <summary>
	/// Represents an application sign in manager.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.SignInManager{TodoApplication.Data.Model.ApplicationUser}" />
	public class ApplicationSignInManager : SignInManager<ApplicationUser>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationSignInManager"/> class.
		/// </summary>
		/// <param name="userManager">An instance of <see cref="P:Microsoft.AspNetCore.Identity.SignInManager`1.UserManager" /> used to retrieve users from and persist users.</param>
		/// <param name="contextAccessor">The accessor used to access the <see cref="T:Microsoft.AspNetCore.Http.HttpContext" />.</param>
		/// <param name="claimsFactory">The factory to use to create claims principals for a user.</param>
		/// <param name="optionsAccessor">The accessor used to access the <see cref="T:Microsoft.AspNetCore.Identity.IdentityOptions" />.</param>
		/// <param name="logger">The logger used to log messages, warnings and errors.</param>
		/// <param name="schemes">The scheme provider that is used enumerate the authentication schemes.</param>
		public ApplicationSignInManager(ApplicationUserManager userManager, IHttpContextAccessor contextAccessor, IUserClaimsPrincipalFactory<ApplicationUser> claimsFactory, IOptions<IdentityOptions> optionsAccessor, ILogger<ApplicationSignInManager> logger, IAuthenticationSchemeProvider schemes) : base(userManager, contextAccessor, claimsFactory, optionsAccessor, logger, schemes)
		{
		}
	}
}
