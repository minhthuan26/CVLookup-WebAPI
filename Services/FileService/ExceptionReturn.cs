using System.Runtime.Serialization;

namespace CVLookup_WebAPI.Services.FileService
{
	[Serializable]
	internal class ExceptionReturn : Exception
	{
		public ExceptionReturn()
		{
		}

		public ExceptionReturn(string? message) : base(message)
		{
		}

		public ExceptionReturn(string? message, Exception? innerException) : base(message, innerException)
		{
		}

		protected ExceptionReturn(SerializationInfo info, StreamingContext context) : base(info, context)
		{
		}
	}
}