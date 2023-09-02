namespace CVLookup_WebAPI.Utilities
{
	public class ApiResponse
	{
		public bool Success { get; set; }
		public string Code { get; set; }
		public object Data { get; set; }
		public string Message { get; set; }
	}
}
