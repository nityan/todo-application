using System;
using System.Reflection.Emit;
using System.Security.Claims;

namespace TodoApplication.Extensions
{
	/// <summary>
	/// Represents a collection of extension methods for the <see cref="ClaimsPrincipal"/> class.
	/// </summary>
	public static class ClaimsPrincipalExtensions
	{
		/// <summary>
		/// Gets the user identifier.
		/// </summary>
		/// <typeparam name="T">The type of identifier.</typeparam>
		/// <param name="source">The source.</param>
		/// <returns>Returns the id of the user.</returns>
		/// <exception cref="ArgumentNullException">source - Value cannot be null</exception>
		public static Guid GetUserId(this ClaimsPrincipal source)
		{
			if (source == null)
			{
				throw new ArgumentNullException(nameof(source), "Value cannot be null");
			}

			var identifier = source.FindFirst(ClaimTypes.NameIdentifier)?.Value;

			if (identifier == null)
			{
				throw new InvalidOperationException($"Unable to locate claim for user: {source.Identity?.Name}");
			}

			return Guid.Parse(identifier);
		}
	}
}