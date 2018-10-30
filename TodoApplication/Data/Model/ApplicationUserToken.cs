using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application user token.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUserToken{System.Guid}" />
	public class ApplicationUserToken : IdentityUserToken<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUserToken"/> class.
		/// </summary>
		public ApplicationUserToken()
		{
			
		}

		/// <summary>
		/// Gets or sets the application user.
		/// </summary>
		/// <value>The application user.</value>
		public virtual ApplicationUser ApplicationUser { get; set; }
	}
}
