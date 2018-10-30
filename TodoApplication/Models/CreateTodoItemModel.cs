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
