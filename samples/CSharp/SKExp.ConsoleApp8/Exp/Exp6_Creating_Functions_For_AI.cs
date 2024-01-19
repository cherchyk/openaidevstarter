using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using SKExp.ConsoleApp8.Utils;
using System.ComponentModel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Plugins.Core;
using Microsoft.SemanticKernel.PromptTemplates.Handlebars;

namespace SKExp.ConsoleApp8.Exp
{
	internal class Exp6_Creating_Functions_For_AI
	{
		new public static async Task RunAsync()
		{
			IKernelBuilder builder = SKHelper.GetBuilder();

			builder.Plugins.AddFromType<Plugins.MathPlugin>();

			Kernel kernel = builder.Build();

			// Create chat history
			ChatHistory history = [];

			// Get chat completion service
			IChatCompletionService chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

			// Test the math plugin
			double answer = await kernel.InvokeAsync<double>("MathPlugin", "Sqrt", new() { { "number1", 12 } });
			Console.WriteLine($"The square root of 12 is {answer}.");

			// Start the conversation
			while (true)
			{
				// Get user input
				Console.Write("User > ");
				history.AddUserMessage(Console.ReadLine()!);

				// Enable auto function calling
				OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
				{
					ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
				};

				// Get the response from the AI
				IAsyncEnumerable<StreamingChatMessageContent> result = chatCompletionService.GetStreamingChatMessageContentsAsync(
					history,
					executionSettings: openAIPromptExecutionSettings,
					kernel: kernel);

				// Stream the results
				string fullMessage = "";
				bool first = true;
				await foreach (StreamingChatMessageContent content in result)
				{
					if (content.Role.HasValue && first)
					{
						Console.Write("Assistant > ");
						first = false;
					}
					Console.Write(content.Content);
					fullMessage += content.Content;
				}
				Console.WriteLine();

				// Add the message from the agent to the chat history
				history.AddAssistantMessage(fullMessage);
			}
		}
	}
}