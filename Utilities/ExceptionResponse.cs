using System.Text.Json;
using System.Text.Json.Serialization;

namespace CVLookup_WebAPI.Utilities
{
	public class ExceptionResponse
	{
		public static async Task Response(HttpContext context, int statusCode, ApiResponse message)
		{
			try
			{
				context.Response.ContentType = "application/json";
				context.Response.StatusCode = statusCode;
				var options = new JsonSerializerOptions { WriteIndented = true };
				var jsonResponse = JsonSerializer.Serialize(message, options);
				await context.Response.WriteAsync(jsonResponse);
				await context.Response.StartAsync();
			}
			catch (Exception e)
			{
				throw new Exception(e.Message);
			}

		}
	}
}
