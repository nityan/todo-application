using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
		/// Gets or sets the creation time.
		/// </summary>
		/// <value>The creation time.</value>
		public DateTime CreationTime { get; set; }

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

		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>The description.</value>
		public string Description { get; set; }

		/// <summary>
		/// Gets or sets the created by username.
		/// </summary>
		/// <value>The created by username.</value>
		public string CreatedByUsername { get; set; }
	}
}
