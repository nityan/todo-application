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

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents an application user.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.IdentityUser{System.Guid}" />
	public class ApplicationUser : IdentityUser<Guid>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUser"/> class.
		/// </summary>
		public ApplicationUser()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUser"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		public ApplicationUser(Guid id)
		{
			this.Id = id;
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationUser"/> class.
		/// </summary>
		/// <param name="userName">The user name.</param>
		public ApplicationUser(string userName) : base(userName)
		{
		}

		/// <summary>
		/// Gets or sets the claims.
		/// </summary>
		/// <value>The claims.</value>
		public virtual ICollection<ApplicationUserClaim> Claims { get; set; }

		/// <summary>
		/// Gets or sets the logins.
		/// </summary>
		/// <value>The logins.</value>
		public virtual ICollection<ApplicationUserLogin> Logins { get; set; }

		/// <summary>
		/// Gets or sets the todo items.
		/// </summary>
		/// <value>The todo items.</value>
		public virtual ICollection<TodoItem> TodoItems { get; set; }

		/// <summary>
		/// Gets or sets the tokens.
		/// </summary>
		/// <value>The tokens.</value>
		public virtual ICollection<ApplicationUserToken> Tokens { get; set; }

		/// <summary>
		/// Gets or sets the user roles.
		/// </summary>
		/// <value>The user roles.</value>
		public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
	}
}