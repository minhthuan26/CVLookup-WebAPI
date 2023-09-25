using CVLookup_WebAPI.Utilities;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace CVLookup_WebAPI.Services.MailService
{
	public class MailService : IMailService
	{
		private readonly IConfiguration _configuration;

		public MailService(IConfiguration configuration)
		{
			_configuration = configuration;
		}

		public async Task<bool> sendMail(string to, string subject, object message)
		{
			try
			{
				var email = new MimeMessage();
				email.From.Add(
					new MailboxAddress(
						_configuration.GetValue<string>("MailConfig:MAIL_FROM_NAME"),
						_configuration.GetValue<string>("MailConfig:MAIL_FROM_ADDRESS")
					)
				);
				email.To.Add(MailboxAddress.Parse(to));
				email.Subject = subject;
				email.Body = new TextPart(TextFormat.Html)
				{
					Text = message.ToString()
				};

				var smptClient = new SmtpClient();
				await smptClient.ConnectAsync(
					_configuration.GetValue<string>("MailConfig:MAIL_HOST"),
					_configuration.GetValue<int>("MailConfig:MAIL_PORT"),
					SecureSocketOptions.StartTls
				);
				if (!smptClient.IsConnected)
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình kết nối đến smtp");
				}
				await smptClient.AuthenticateAsync(
					_configuration.GetValue<string>("MailConfig:MAIL_USER"),
					_configuration.GetValue<string>("MailConfig:MAIL_PASSWORD")
				);
				if (!smptClient.IsAuthenticated)
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình xác thực");
				}
				var sendResult = await smptClient.SendAsync(email);
				if (!sendResult.Contains("2.0.0 OK"))
				{
					throw new ExceptionReturn(500, "Thất bại. Có lỗi xảy ra trong quá trình gửi mail");
				}
				await smptClient.DisconnectAsync(true);
				return true;
			} catch (ExceptionReturn e)
			{
				throw new ExceptionReturn(e.Code, e.Message);
			}
		}
	}
}
