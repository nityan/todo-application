﻿/*
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
