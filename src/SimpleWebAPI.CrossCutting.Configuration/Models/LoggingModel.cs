using Newtonsoft.Json;

namespace SimpleWebAPI.CrossCutting.Configuration.Models
{
	public class LoggingModel
	{
		[JsonProperty("LogLevel")]
		public LogLevel LogLevel { get; set; }
	}

	public class LogLevel
	{
		[JsonProperty("Default")]
		public string Default { get; set; }

		[JsonProperty("Microsoft")]
		public string Microsoft { get; set; }

		[JsonProperty("Microsoft.Hosting.Lifetime")]
		public string MicrosoftHostingLifetime { get; set; }
	}
}
