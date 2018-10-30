using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application role claim.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityRoleClaim{System.Guid}" />
	public class ApplicationRoleClaim : IdentityRoleClaim<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationRoleClaim" /> class.
		/// </summary>
		public ApplicationRoleClaim()
		{

		}

		/// <summary>
		/// Gets or sets the application role.
		/// </summary>
		/// <value>The application role.</value>
		public virtual ApplicationRole ApplicationRole { get; set; }
	}
}
