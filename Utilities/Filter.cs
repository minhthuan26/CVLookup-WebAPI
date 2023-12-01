using Microsoft.VisualBasic;

namespace CVLookup_WebAPI.Utilities
{
	public class Filter
	{
		public static int PageSize { get; } = 10;
		public int Page { get; set; } = 1;
		public string? Keyword { get; set; }
		public string? UserId { get; set; }
		public string? Province { get; set; }
		public string? District { get; set; }
		public string? Career { get; set; }
		public string? JobField { get; set; }
		public string? JobForm { get; set; }
		public string? Experience { get; set; }
		public string? Position { get; set; }
		public string? SortBy { get; set; }
	}
}
