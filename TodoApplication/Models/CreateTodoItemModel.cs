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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Migrations.Operations;

namespace TodoApplication.Models
{
	/// <summary>
	/// Represents a create todo item model.
	/// </summary>
	public class CreateTodoItemModel
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="CreateTodoItemModel"/> class.
		/// </summary>
		public CreateTodoItemModel()
		{
			
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="CreateTodoItemModel"/> class.
		/// </summary>
		/// <param name="description">The description.</param>
		/// <param name="title">The title.</param>
		public CreateTodoItemModel(string description, string title)
		{
			this.Description = description;
			this.Title = title;
		}

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		[StringLength(4000)]
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the title.
		/// </summary>
		/// <value>The title.</value>
		[Required]
		[StringLength(255)]
		public string Title { get; set; }
	}
}
