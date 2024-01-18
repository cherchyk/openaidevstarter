using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using SKExp.ConsoleApp8.Exp;
using SKExp.ConsoleApp8.Plugins;
using SKExp.ConsoleApp8.Utils;
using System.Reflection;

namespace SKExp.ConsoleApp8
{
	public static class Program
	{
		public const string DefaultFilter = "";

		public static string[] Args { get; set; }



		public static async Task Main(string[] args)
		{
			Args = args;

			// Execution canceled if the user presses Ctrl+C.
			using CancellationTokenSource cancellationTokenSource = new();
			CancellationToken cancelToken = cancellationTokenSource.ConsoleCancellationToken();

			string newfilter = args.Length > 0 ? args[0] : Console.ReadLine();

			string ? filter = string.IsNullOrEmpty(newfilter) ? DefaultFilter: newfilter;

			// Run examples based on the filter
			await RunExamplesAsync(filter, cancelToken);


			Console.ReadLine();
		}



		public static async Task RunExamplesAsync(string? filter, CancellationToken cancellationToken)
		{
			// fund all types that have RunAsync method
			IEnumerable<Type> examples = Assembly.GetExecutingAssembly().GetTypes()
				.Where(o => o.GetMethod("RunAsync") != null
						&& 
						(o.Name.Contains(filter, StringComparison.OrdinalIgnoreCase) || string.IsNullOrEmpty(filter)
					));

			// Filter and run examples
			foreach (Type example in examples)
			{
				try
				{
					MethodInfo? method = example.GetMethod("RunAsync");

					Console.WriteLine($"Running {example.Name}...");

					bool hasCancellationToken = method.GetParameters().Any(param => param.ParameterType == typeof(CancellationToken));

					var taskParameters = hasCancellationToken ? new object[] { cancellationToken } : null;
					if (method.Invoke(null, taskParameters) is Task t)
					{
						await t.SafeWaitAsync(cancellationToken);
					}
					else
					{
						method.Invoke(null, null);
					}
				}
				catch (Exception ex)
				{
					Console.WriteLine($"{ex.Message}. Skipping example {example}.");
				}

			}
		}

		private static CancellationToken ConsoleCancellationToken(this CancellationTokenSource tokenSource)
		{
			Console.CancelKeyPress += (s, e) =>
			{
				Console.WriteLine("Canceling...");
				tokenSource.Cancel();
				e.Cancel = true;
			};

			return tokenSource.Token;
		}

		private static async Task SafeWaitAsync(this Task task, CancellationToken cancellationToken = default)
		{
			try
			{
				await task.WaitAsync(cancellationToken);
				Console.WriteLine();
				Console.WriteLine("== DONE ==");
			}
			catch (Exception ex)
			{
				Console.WriteLine($"{ex.Message}. Skipping example.");
			}

			cancellationToken.ThrowIfCancellationRequested();
		}

	}
}