using Microsoft.SemanticKernel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SKExp.ConsoleApp8.Plugins
{
	public class LightPlugin
	{
		public bool IsOn { get; set; }

		[KernelFunction, Description("Gets the state of the light.")]
		public string GetState() => IsOn ? "on" : "off";

		[KernelFunction, Description("Changes the state of the light.")]
		public string ChangeState(bool newState)
		{
			IsOn = newState;
			var state = GetState();

			// Print the state to the console
			Console.ForegroundColor = ConsoleColor.DarkBlue;
			Console.WriteLine($"[Light is now {state}]");
			Console.ResetColor();

			return state;
		}
	}
}
