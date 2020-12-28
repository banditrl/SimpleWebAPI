using Newtonsoft.Json;
using SimpleWebAPI.CrossCutting.Configuration.Models;

namespace SimpleWebAPI.CrossCutting.Configuration
{
	public class AppSettings
	{
		[JsonProperty("Logging")]
		public LoggingModel Logging { get; set; }

		[JsonProperty("Secret")]
		public string Secret { get; set; }
	}
}
