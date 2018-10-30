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
