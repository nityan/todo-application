/*
 * Copyright 2016-2018 Mohawk College of Applied Arts and Technology
 * 
 * Licensed under the Apache License, Version 2.0 (the "License"); you 
 * may not use this file except in compliance with the License. You may 
 * obtain a copy of the License at 
 * 
 * http://www.apache.org/licenses/LICENSE-2.0 
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS, WITHOUT
 * WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the 
 * License for the specific language governing permissions and limitations under 
 * the License.
 * 
 * User: Nityan
 * Date: 2018-10-29
 */
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
