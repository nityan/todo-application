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

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoApplication.Extensions;
using TodoApplication.Models;
using TodoApplication.Services;

namespace TodoApplication.Controllers
{
	/// <summary>
	/// Represents a todo item controller.
	/// </summary>
	[Authorize]
	public class TodoItemController : Controller
	{
		/// <summary>
		/// The todo item service.
		/// </summary>
		private readonly ITodoItemService todoItemService;

		/// <summary>
		/// Initializes a new instance of the <see cref="TodoItemController" /> class.
		/// </summary>
		/// <param name="todoItemService">The todo item service.</param>
		public TodoItemController(ITodoItemService todoItemService)
		{
			this.todoItemService = todoItemService;
		}

		// GET: TodoItems/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: TodoItems/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Description,Title")] CreateTodoItemModel model)
		{
			if (!this.ModelState.IsValid)
			{
				return View();
			}

			await this.todoItemService.CreateTodoItemAsync(model.Title, model.Description, this.User.GetUserId());

			return View(model);
		}

		// GET: TodoItems/Delete/5
		public async Task<IActionResult> Delete(Guid id)
		{
			var todoItem = await this.todoItemService.GetTodoItemAsync(id);

			if (todoItem == null)
			{
				return this.NotFound();
			}

			return View(todoItem);
		}

		// POST: TodoItems/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			await this.todoItemService.DeleteTodoItemAsync(id);

			return RedirectToAction(nameof(Index));
		}

		// GET: TodoItems/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var todoItem = await this.todoItemService.GetTodoItemAsync(id ?? Guid.Empty);

			return View(todoItem);
		}

		// GET: TodoItems/Edit/5
		public async Task<IActionResult> Edit(Guid id)
		{
			var todoItem = await this.todoItemService.GetTodoItemAsync(id);

			if (todoItem == null)
			{
				return NotFound();
			}

			var model = new UpdateTodoItemModel(todoItem.Id, todoItem.Description, todoItem.Title);

			return View(model);
		}

		// POST: TodoItems/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id, Description, Title")] UpdateTodoItemModel model)
		{
			if (id != model.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				await this.todoItemService.UpdateTodoItemAsync(id, model.Title, model.Description, this.User.GetUserId());
			}

			return View(model);
		}

		// GET: TodoItems
		public async Task<IActionResult> Index()
		{
			var todoItems = await this.todoItemService.QueryAsync(c => true, null, 0);

			var results = new List<TodoItemViewModel>();

			results.AddRange(todoItems.Select(c => new TodoItemViewModel(c.Id, c.CreationTime, c.Title, c.Description, c.CreatedByUser.UserName)));

			return View(results);
		}
	}
}