using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application role.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityRole{System.Guid}" />
	public class ApplicationRole : IdentityRole<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationRole" /> class.
		/// </summary>
		public ApplicationRole()
		{

		}

		/// <summary>
		/// Gets or sets the user roles.
		/// </summary>
		/// <value>The user roles.</value>
		public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }

		/// <summary>
		/// Gets or sets the role claims.
		/// </summary>
		/// <value>The role claims.</value>
		public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
	}
}
