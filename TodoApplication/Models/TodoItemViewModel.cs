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

namespace TodoApplication.Models
{
	/// <summary>
	/// Represents a todo item view model.
	/// </summary>
	public class TodoItemViewModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="TodoItemViewModel"/> class.
		/// </summary>
		public TodoItemViewModel()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="TodoItemViewModel"/> class.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="title">The title.</param>
		/// <param name="description">The description.</param>
		/// <param name="createdByUsername">The created by username.</param>
		public TodoItemViewModel(Guid id, DateTime creationTime, string title, string description, string createdByUsername)
		{
			this.Id = id;
			this.CreationTime = creationTime;
			this.Title = title;
			this.Description = description;
			this.CreatedByUsername = createdByUsername;
		}

		/// <summary>
		/// Gets or sets the created by username.
		/// </summary>
		/// <value>The created by username.</value>
		public string CreatedByUsername { get; set; }

		/// <summary>
		/// Gets or sets the creation time.
		/// </summary>
		/// <value>The creation time.</value>
		public DateTime CreationTime { get; set; }

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>The identifier.</value>
		public Guid Id { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		public string Title { get; set; }
	}
}