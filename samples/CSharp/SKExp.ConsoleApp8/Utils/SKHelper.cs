using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKExp.ConsoleApp8.Utils
{
	public static class SKHelper
	{

		public static IKernelBuilder GetBuilder()
		{
			IKernelBuilder builder = Kernel.CreateBuilder();

			OpenAISettings settings = Settings.GetOpenAISettings();

			if (settings.UseAzureOpenAI)
				builder.AddAzureOpenAIChatCompletion(settings.Model, settings.Endpoint, settings.Apikey);
			else
				builder.AddOpenAIChatCompletion(settings.Model, settings.Apikey, settings.Org);

			if (Program.Args.Length > 1 && Program.Args[1] != null && Program.Args[1] == "logs")
			{
				builder.Services.AddLogging(c => c.SetMinimumLevel(LogLevel.Trace).AddDebug().AddConsole(o =>
				{
					// o.FormatterName = "json";
				}));
			}

			return builder;
		}




		internal static IKernelBuilder WithCompletionService(this IKernelBuilder kernelBuilder)
		{
			switch (Env.Var("Global:LlmService")!)
			{
				case "AzureOpenAI":
					if (Env.Var("AzureOpenAI:DeploymentType") == "text-completion")
					{
						kernelBuilder.Services.AddAzureOpenAITextGeneration(
							deploymentName: Env.Var("AzureOpenAI:TextCompletionDeploymentName")!,
							modelId: Env.Var("AzureOpenAI:TextCompletionModelId")!,
							endpoint: Env.Var("AzureOpenAI:Endpoint")!,
							apiKey: Env.Var("AzureOpenAI:ApiKey")!
						);
					}
					else if (Env.Var("AzureOpenAI:DeploymentType") == "chat-completion")
					{
						kernelBuilder.Services.AddAzureOpenAIChatCompletion(
							deploymentName: Env.Var("AzureOpenAI:ChatCompletionDeploymentName")!,
							modelId: Env.Var("AzureOpenAI:ChatCompletionModelId")!,
							endpoint: Env.Var("AzureOpenAI:Endpoint")!,
							apiKey: Env.Var("AzureOpenAI:ApiKey")!
						);
					}
					break;

				case "OpenAI":
					if (Env.Var("OpenAI:ModelType") == "text-completion")
					{
						kernelBuilder.Services.AddOpenAITextGeneration(
							modelId: Env.Var("OpenAI:TextCompletionModelId")!,
							apiKey: Env.Var("OpenAI:ApiKey")!,
							orgId: Env.Var("OpenAI:OrgId")
						);
					}
					else if (Env.Var("OpenAI:ModelType") == "chat-completion")
					{
						kernelBuilder.Services.AddOpenAIChatCompletion(
							modelId: Env.Var("OpenAI:ChatCompletionModelId")!,
							apiKey: Env.Var("OpenAI:ApiKey")!,
							orgId: Env.Var("OpenAI:OrgId")
						);
					}
					break;

				default:
					throw new ArgumentException($"Invalid service type value: {Env.Var("OpenAI:ModelType")}");
			}

			return kernelBuilder;
		}

	}


#pragma warning disable CA1812 // instantiated by AddUserSecrets
	internal sealed class Env
#pragma warning restore CA1812
	{
		/// <summary>
		/// Simple helper used to load env vars and secrets like credentials,
		/// to avoid hard coding them in the sample code
		/// </summary>
		/// <param name="name">Secret name / Env var name</param>
		/// <returns>Value found in Secret Manager or Environment Variable</returns>
		internal static string? Var(string name)
		{
			var configuration = new ConfigurationBuilder()
				.AddUserSecrets<Env>()
				.Build();

			var value = configuration[name];
			if (!string.IsNullOrEmpty(value))
			{
				return value;
			}

			value = Environment.GetEnvironmentVariable(name);

			return value;
		}
	}
}
