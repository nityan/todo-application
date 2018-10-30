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
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TodoApplication.Data.Model;

namespace TodoApplication.Services
{
	/// <summary>
	/// Represents a Todo service.
	/// </summary>
	public interface ITodoItemService
	{
		/// <summary>
		/// Creates the todo item.
		/// </summary>
		/// <param name="title">The title.</param>
		/// <param name="description">The description.</param>
		/// <param name="userId">The user identifier.</param>
		/// <returns>Returns the id of the newly created todo item.</returns>
		Task<Guid> CreateTodoItemAsync(string title, string description, Guid userId);

		/// <summary>
		/// Deletes the todo item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		Task DeleteTodoItemAsync(Guid id);

		/// <summary>
		/// Gets the todo item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <returns>Returns the todo item, or null if not found.</returns>
		Task<TodoItem> GetTodoItemAsync(Guid id);

		/// <summary>
		/// Queries the specified todo items based on a given expression.
		/// </summary>
		/// <param name="expression">The expression.</param>
		/// <param name="count">The count.</param>
		/// <param name="offset">The offset.</param>
		/// <returns>Returns a list of todo items that match the specified expression.</returns>
		Task<IEnumerable<TodoItem>> QueryAsync(Expression<Func<TodoItem, bool>> expression, int? count, int offset);


		/// <summary>
		/// Updates the todo item.
		/// </summary>
		/// <param name="id">The identifier.</param>
		/// <param name="title">The title.</param>
		/// <param name="description">The description.</param>
		/// <param name="userId">The user identifier.</param>
		/// <returns>Returns the id of the updated todo item.</returns>
		Task<Guid> UpdateTodoItemAsync(Guid id, string title, string description, Guid userId);
	}
}
