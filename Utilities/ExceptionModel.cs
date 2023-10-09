using System.Transactions;

namespace CVLookup_WebAPI.Utilities
{
	[Serializable]
	public class ExceptionModel : Exception
	{
		public int Code { get; set; }
		public string Message { get; set; }

		public ExceptionModel(int code, string message)
		{
			Code = code;
			Message = message;
		}

	}
}
