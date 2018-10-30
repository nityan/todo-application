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
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TodoApplication.Data;
using TodoApplication.Data.Model;

namespace TodoApplication.Services
{
	/// <summary>
	/// Represents a todo item service.
	/// </summary>
	/// <seealso cref="TodoApplication.Services.ITodoItemService" />
	public class TodoItemService : ITodoItemService, IDisposable
	{
		/// <summary>
		/// The context.
		/// </summary>
		private readonly ApplicationDbContext context;

		/// <summary>
		/// Initializes a new instance of the <see cref="TodoItemService"/> class.
		/// </summary>
		/// <param name="context">The context.</param>
		public TodoItemService(ApplicationDbContext context)
		{
			this.context = context;
		}

		/// <summary>
		/// Creates the todo item.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="description">The description.</param>
		/// <param name="userId">The user identifier.</param>
		/// <returns>Returns the id of the newly created todo item.</returns>
		public async Task<Guid> CreateTodoItemAsync(string title, string description, Guid userId)
		{
			var todoItem = new TodoItem(title, description)
			{
				CreatedByUserId = userId
			};

			this.context.TodoItem.Add(todoItem);
			await this.context.SaveChangesAsync();

			return todoItem.Id;
		}

		/// <summary>
		/// Deletes the todo item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <exception cref="KeyNotFoundException">If the specified key is not found</exception>
		public async Task DeleteTodoItemAsync(Guid id)
		{
			var todoItem = await this.context.TodoItem.FindAsync(id);

			if (todoItem == null)
			{
				throw new KeyNotFoundException($"Unable to locate todo item: {id}");
			}

			this.context.TodoItem.Remove(todoItem);
			await this.context.SaveChangesAsync();
		}

		/// <summary>
		/// Gets the todo item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Returns the todo item, or null if not found.</returns>
		public async Task<TodoItem> GetTodoItemAsync(Guid id)
		{
			return await this.context.TodoItem.FindAsync(id);
		}

		/// <summary>
		/// Queries the specified todo items based on a given expression.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="count">The count.</param>
		/// <param name="offset">The offset.</param>
		/// <returns>Returns a list of todo items that match the specified expression.</returns>
		public async Task<IEnumerable<TodoItem>> QueryAsync(Expression<Func<TodoItem, bool>> expression, int? count, int offset)
		{
			var results = new List<TodoItem>();

			var todoItems = this.context.TodoItem.AsQueryable().Include(c => c.CreatedByUser).Where(expression);

			//totalCount = await todoItems.CountAsync();

			if (offset > 0)
			{
				todoItems = todoItems.Skip(offset);
			}

			todoItems = todoItems.Take(count ?? 25);

			results.AddRange(await todoItems.ToListAsync());

			return results;
		}

		/// <summary>
		/// Updates the todo item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="title">The title.</param>
		/// <param name="description">The description.</param>
		/// <param name="userId">The user identifier.</param>
		/// <returns>Returns the id of the updated todo item.</returns>
		/// <exception cref="KeyNotFoundException">If the specified key is not found</exception>
		public async Task<Guid> UpdateTodoItemAsync(Guid id, string title, string description, Guid userId)
		{
			var todoItem = await this.GetTodoItemAsync(id);

			if (todoItem == null)
			{
				throw new KeyNotFoundException($"Unable to locate todo item: {id}");
			}

			todoItem.CreatedByUserId = userId;
			todoItem.Title = title;
			todoItem.Description = description;
			todoItem.UpdatedTime = DateTime.Now;

			this.context.Entry(todoItem).State = EntityState.Modified;
			await this.context.SaveChangesAsync();

			return todoItem.Id;
		}

		/// <summary>
		/// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
		/// </summary>
		public void Dispose()
		{
			this.context?.Dispose();
		}
	}
}
