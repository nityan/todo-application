using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TodoApplication.Data.Model;

namespace TodoApplication.Services
{
	/// <summary>
	/// Represents an application role manager.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.RoleManager{TodoApplication.Data.Model.ApplicationRole}" />
	public class ApplicationRoleManager : RoleManager<ApplicationRole>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationRoleManager"/> class.
		/// </summary>
		/// <param name="store">The persistence store the manager will operate over.</param>
		/// <param name="roleValidators">A collection of validators for roles.</param>
		/// <param name="keyNormalizer">The normalizer to use when normalizing role names to keys.</param>
		/// <param name="errors">The <see cref="T:Microsoft.AspNetCore.Identity.IdentityErrorDescriber" /> used to provider error messages.</param>
		/// <param name="logger">The logger used to log messages, warnings and errors.</param>
		public ApplicationRoleManager(IRoleStore<ApplicationRole> store, IEnumerable<IRoleValidator<ApplicationRole>> roleValidators, ILookupNormalizer keyNormalizer, IdentityErrorDescriber errors, ILogger<RoleManager<ApplicationRole>> logger) : base(store, roleValidators, keyNormalizer, errors, logger)
		{
		}
	}
}
