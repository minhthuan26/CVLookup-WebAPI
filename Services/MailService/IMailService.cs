namespace CVLookup_WebAPI.Services.MailService
{
	public interface IMailService
	{
		public Task<bool> sendMail(string to, string subject, object message);
	}
}
