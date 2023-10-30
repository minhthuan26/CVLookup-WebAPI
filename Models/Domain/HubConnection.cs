namespace CVLookup_WebAPI.Models.Domain
{
	public class HubConnection
	{
		public string Id { get; set; } = Guid.NewGuid().ToString();
		public string ConnectionId { get; set; }
		public string UserId { get; set; }
	}
}
