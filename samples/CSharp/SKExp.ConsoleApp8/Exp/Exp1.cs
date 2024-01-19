using Microsoft.SemanticKernel.Connectors.OpenAI;
using Microsoft.SemanticKernel;
using SKExp.ConsoleApp8.Plugins;
using SKExp.ConsoleApp8.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKExp.ConsoleApp8.Exp
{
	internal class Exp1
	{
		new public static async Task RunAsync()
		{
			IKernelBuilder builder = SKHelper.GetBuilder();

			builder.Plugins.AddFromType<LightPlugin>();

			Kernel kernel = builder.Build();

			// Enable auto invocation of kernel functions
			OpenAIPromptExecutionSettings settings2 = new OpenAIPromptExecutionSettings()
			{
				ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions
			};

			try {

				// Start a chat session
				while (true)
				{
					// Get the user's message
					Console.Write("User > ");
					var userMessage = Console.ReadLine()!;

					// Invoke the kernel
					var results = await kernel.InvokePromptAsync(userMessage, new(settings2));

					// Print the results
					Console.WriteLine($"Assistant > {results}");
				}

			}
			catch (Exception e)
			{
				throw e;
			}





		}	
	}
}
