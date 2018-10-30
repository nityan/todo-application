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
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace TodoApplication.Data.Model
{
	/// <summary>
	/// Represents a Todo item.
	/// </summary>
	public class TodoItem
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TodoItem"/> class.
		/// </summary>
		public TodoItem()
		{
			this.CreationTime = DateTime.Now;
			this.Id = Guid.NewGuid();
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TodoItem" /> class.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="description">The description.</param>
		public TodoItem(string title, string description) : this()
		{
			this.Title = title;
			this.Description = description;
		}

		/// <summary>
		/// Gets or sets the created by user.
		/// </summary>
		/// <value>The created by user.</value>
		[ForeignKey("CreatedByUserId")]
		public ApplicationUser CreatedByUser { get; set; }

		/// <summary>
		/// Gets or sets the created by user identifier.
		/// </summary>
		/// <value>The created by user identifier.</value>
		[Required]
		public Guid CreatedByUserId { get; set; }

		/// <summary>
		/// Gets or sets the creation time.
		/// </summary>
		/// <value>The creation time.</value>
		[Required]
		public DateTime CreationTime { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[StringLength(4000)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the content of the encrypted.
		/// </summary>
		/// <value>The content of the encrypted.</value>
		public string EncryptedContent { get; set; }

		/// <summary>
		/// Gets or sets the content of the hashed.
		/// </summary>
		/// <value>The content of the hashed.</value>
		public string HashedContent { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		[Key]
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[Required]
		[StringLength(255)]
		public string Title { get; set; }

		/// <summary>
		/// Gets or sets the updated time.
		/// </summary>
		/// <value>The updated time.</value>
		public DateTime? UpdatedTime { get; set; }
	}
}