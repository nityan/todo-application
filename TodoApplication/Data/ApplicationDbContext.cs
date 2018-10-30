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
 * Date: 2018-10-28
 */

using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data.Model;

namespace TodoApplication.Data
{
	/// <summary>
	/// Represents the application database context.
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityDbContext" />
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid, ApplicationUserClaim, ApplicationUserRole, ApplicationUserLogin, ApplicationRoleClaim, ApplicationUserToken>
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="ApplicationDbContext"/> class.
		/// </summary>
		/// <param name="options">The options.</param>
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{
		}

		/// <summary>
		/// Gets or sets the todo item.
		/// </summary>
		/// <value>The todo item.</value>
		public DbSet<TodoItem> TodoItem { get; set; }

		/// <summary>
		/// Configures the schema needed for the identity framework.
		/// </summary>
		/// <param name="builder">The builder being used to construct the model for this context.</param>
		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ApplicationUser>().HasKey(c => c.Id);
			builder.Entity<ApplicationUser>().HasMany(c => c.TodoItems);
			builder.Entity<TodoItem>().HasOne(c => c.CreatedByUser);

			builder.Entity<ApplicationUser>().HasMany(c => c.Claims).WithOne().HasForeignKey(c => c.UserId).IsRequired();
			builder.Entity<ApplicationUser>().HasMany(c => c.Logins).WithOne().HasForeignKey(c => c.UserId).IsRequired();
			builder.Entity<ApplicationUser>().HasMany(c => c.Tokens).WithOne().HasForeignKey(c => c.UserId).IsRequired();
			builder.Entity<ApplicationUser>().HasMany(c => c.UserRoles).WithOne(c =>c.ApplicationUser).HasForeignKey(c => c.UserId).IsRequired();

			builder.Entity<ApplicationRole>().HasMany(c => c.UserRoles).WithOne(c =>c.ApplicationRole).HasForeignKey(c => c.RoleId).IsRequired();
			builder.Entity<ApplicationRole>().HasMany(c => c.RoleClaims).WithOne(c => c.ApplicationRole).HasForeignKey(c => c.RoleId).IsRequired();

			base.OnModelCreating(builder);
		}
	}
}