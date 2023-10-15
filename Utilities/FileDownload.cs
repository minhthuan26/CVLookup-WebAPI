namespace CVLookup_WebAPI.Utilities
{
	public class FileDownload
	{
		public byte[] Bytes { get; set; }
		public string ContentType { get; set; } = "application/octet-stream";
		public string FilePath { get; set; }
	}
}
