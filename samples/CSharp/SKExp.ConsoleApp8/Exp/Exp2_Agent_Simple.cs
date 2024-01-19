using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using SKExp.ConsoleApp8.Utils;
using System.ComponentModel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;

namespace SKExp.ConsoleApp8.Exp
{

	public class EmailPlugin
	{
		[KernelFunction]
		[Description("Sends an email to a recipient.")]
		public async Task SendEmailAsync(
			Kernel kernel,
			[Description("Semicolon delimitated list of emails of the recipients")] string recipientEmails,
			string subject,
			string body
		)
		{
			// Add logic to send an email using the recipientEmails, subject, and body
			// For now, we'll just print out a success message to the console
			Console.WriteLine("Email sent!");
		}
	}

	public class AuthorEmailPlanner
	{
		[KernelFunction]
		[Description("Returns back the required steps necessary to author an email.")]
		[return: Description("The list of steps needed to author an email")]
		public async Task<string> GenerateRequiredStepsAsync(
			Kernel kernel,
			[Description("A 2-3 sentence description of what the email should be about")] string topic,
			[Description("A description of the recipients")] string recipients
		)
		{
			// Prompt the LLM to generate a list of steps to complete the task
			var result = await kernel.InvokePromptAsync($"""
        I'm going to write an email to {recipients} about {topic} on behalf of a user.
        Before I do that, can you succinctly recommend the top 3 steps I should take in a numbered list?
        I want to make sure I don't forget anything that would help my user's email sound more professional.
        """, new() {
			{ "topic", topic },
			{ "recipients", recipients }
		});

			// Return the plan back to the agent
			return result.ToString();
		}
	}

	internal class Exp2_Agent_Simple
	{
		new public static async Task RunAsync()
		{
			IKernelBuilder builder = SKHelper.GetBuilder();

			builder.Plugins.AddFromType<AuthorEmailPlanner>();
			builder.Plugins.AddFromType<EmailPlugin>();
			Kernel kernel = builder.Build();

			// Retrieve the chat completion service from the kernel
			IChatCompletionService chatCompletionService = kernel.GetRequiredService<IChatCompletionService>();

			// Create the chat history
			ChatHistory chatMessages = new ChatHistory("""
You are a friendly assistant who likes to follow the rules. You will complete required steps
and request approval before taking any consequential actions. If the user doesn't provide
enough information for you to complete a task, you will keep asking questions until you have
enough information to complete the task.
""");

			// Start the conversation
			while (true)
			{
				// Get user input
				System.Console.Write("User > ");
				chatMessages.AddUserMessage(Console.ReadLine()!);

				// Get the chat completions
				OpenAIPromptExecutionSettings openAIPromptExecutionSettings = new()
				{
					ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
				};
				var result = chatCompletionService.GetStreamingChatMessageContentsAsync(
					chatMessages,
					executionSettings: openAIPromptExecutionSettings,
					kernel: kernel);

				// Stream the results
				string fullMessage = "";
				await foreach (var content in result)
				{
					if (content.Role.HasValue)
					{
						System.Console.Write("Assistant > ");
					}
					System.Console.Write(content.Content);
					fullMessage += content.Content;
				}
				System.Console.WriteLine();

				// Add the message from the agent to the chat history
				chatMessages.AddAssistantMessage(fullMessage);
			}







		}	
	}
}
