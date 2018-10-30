using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Data.Model;

namespace TodoApplication.Services
{
	/// <summary>
	/// Represents an application role store.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.UserStore{TodoApplication.Data.Model.ApplicationUser, TodoApplication.Data.Model.ApplicationRole, TodoApplication.Data.ApplicationDbContext, System.Guid, Microsoft.AspNetCore.Identity.IdentityUserClaim{System.Guid}, Microsoft.AspNetCore.Identity.IdentityUserRole{System.Guid}, Microsoft.AspNetCore.Identity.IdentityUserLogin{System.Guid}, Microsoft.AspNetCore.Identity.IdentityUserToken{System.Guid}, Microsoft.AspNetCore.Identity.IdentityRoleClaim{System.Guid}}" />
	public class ApplicationRoleStore : RoleStore<ApplicationRole, ApplicationDbContext, Guid, ApplicationUserRole, ApplicationRoleClaim>
	{
		/// <summary>
		/// Creates a new instance of the store.
		/// </summary>
		/// <param name="context">The context used to access the store.</param>
		/// <param name="describer">The <see cref="T:Microsoft.AspNetCore.Identity.IdentityErrorDescriber" /> used to describe store errors.</param>
		public ApplicationRoleStore(ApplicationDbContext context, IdentityErrorDescriber describer = null) : base(context, describer)
		{
		}
	}
}
