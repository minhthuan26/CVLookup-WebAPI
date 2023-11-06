namespace CVLookup_WebAPI.Utilities
{
	public static class TimeAgo
	{
		public static string AsTimeAgo(this DateTime dateTime)
		{
			TimeSpan timeSpan = DateTime.Now.Subtract(dateTime);

			return timeSpan.TotalSeconds switch
			{
				<= 60 => $"{timeSpan.Seconds} giây trước",

				_ => timeSpan.TotalMinutes switch
				{
					<= 1 => "Khoảng 1 phút trước",
					< 60 => $"Khoảng {timeSpan.Minutes} phút trước",
					_ => timeSpan.TotalHours switch
					{
						<= 1 => "Khoảng 1 giờ trước",
						< 24 => $"Khoảng {timeSpan.Hours} giờ trước",
						_ => timeSpan.TotalDays switch
						{
							<= 1 => "Hôm qua",
							<= 30 => $"Khoảng {timeSpan.Days} ngày trước",

							<= 60 => "Khoảng 1 tháng trước",
							< 365 => $"Khoảng {timeSpan.Days / 30} tháng trước",

							<= 365 * 2 => "Khoảng 1 năm trước",
							_ => $"Khoảng {timeSpan.Days / 365} năm trước"
						}
					}
				}
			};
		}
	}
}
