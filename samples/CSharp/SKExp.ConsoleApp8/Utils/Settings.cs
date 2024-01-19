using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SKExp.ConsoleApp8.Utils
{
	public static class Settings
	{
		public static OpenAISettings GetOpenAISettings()
		{

			var builder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", optional: false);

			IConfiguration config = builder.Build();

			var myFirstClass = config.GetSection("OpenAI").Get<OpenAISettings>();

			return myFirstClass;
		}
	}

	public class OpenAISettings
	{
		public bool UseAzureOpenAI { get; set; }
		public string Model { get; set; }
		public string Endpoint { get; set; }
		public string Apikey { get; set; }
		public string Org { get; set; }
	}
}
