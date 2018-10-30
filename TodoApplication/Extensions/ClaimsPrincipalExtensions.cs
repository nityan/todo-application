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
using System;
using System.Reflection.Emit;
using System.Security.Claims;

namespace TodoApplication.Extensions
{
	/// <summary>
	/// Represents a collection of extension methods for the <see cref="ClaimsPrincipal"/> class.
	/// </summary>
	public static class ClaimsPrincipalExtensions
	{
		/// <summary>
		/// Gets the user identifier.
		/// </summary>
		/// <typeparam name="T">The type of identifier.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns>Returns the id of the user.</returns>
		/// <exception cref="ArgumentNullException">source - Value cannot be null</exception>
		public static Guid GetUserId(this ClaimsPrincipal source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "Value cannot be null");
			}

			var identifier = source.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (identifier == null)
			{
				throw new InvalidOperationException($"Unable to locate claim for user: {source.Identity?.Name}");
			}

			return Guid.Parse(identifier);
		}
	}
}