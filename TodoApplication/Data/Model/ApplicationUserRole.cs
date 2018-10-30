using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application user role.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUserRole{System.Guid}" />
	public class ApplicationUserRole : IdentityUserRole<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUserRole"/> class.
		/// </summary>
		public ApplicationUserRole()
		{
			
		}

		/// <summary>
		/// Gets or sets the application user.
		/// </summary>
		/// <value>The application user.</value>
		public virtual ApplicationUser ApplicationUser { get; set; }

		/// <summary>
		/// Gets or sets the application role.
		/// </summary>
		/// <value>The application role.</value>
		public virtual ApplicationRole ApplicationRole { get; set; }
	}
}
