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
using Microsoft.AspNetCore.Mvc;
using TodoApplication.Controllers;

namespace TodoApplication.Extensions
{
	public static class UrlHelperExtensions
	{
		public static string EmailConfirmationLink(this IUrlHelper urlHelper, Guid userId, string code, string scheme)
		{
			return urlHelper.Action(
				action: nameof(AccountController.ConfirmEmail),
				controller: "Account",
				values: new { userId, code },
				protocol: scheme);
		}

		public static string ResetPasswordCallbackLink(this IUrlHelper urlHelper, Guid userId, string code, string scheme)
		{
			return urlHelper.Action(
				action: nameof(AccountController.ResetPassword),
				controller: "Account",
				values: new { userId, code },
				protocol: scheme);
		}
	}
}
