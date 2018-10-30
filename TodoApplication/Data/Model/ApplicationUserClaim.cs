using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application user claim.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUserClaim{System.Guid}" />
	public class ApplicationUserClaim : IdentityUserClaim<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUserClaim" /> class.
		/// </summary>
		public ApplicationUserClaim()
		{

		}

		/// <summary>
		/// Gets or sets the application user.
		/// </summary>
		/// <value>The application user.</value>
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}
