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