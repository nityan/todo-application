using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application user login.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUserLogin{System.Guid}" />
	public class ApplicationUserLogin : IdentityUserLogin<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUserLogin" /> class.
		/// </summary>
		public ApplicationUserLogin()
		{

		}

		/// <summary>
		/// Gets or sets the application user.
		/// </summary>
		/// <value>The application user.</value>
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}
