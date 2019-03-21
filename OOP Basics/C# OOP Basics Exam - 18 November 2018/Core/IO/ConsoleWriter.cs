using System;
using DungeonsAndCodeWizards.Core.IO.Contracts;

namespace DungeonsAndCodeWizards.Core.IO
{
	public class ConsoleWriter : IWriter
	{
		public void WriteLine(string message)
		{
		    if (message == null ||
		        message == "")
		    {
		        return;
		    }
			Console.WriteLine(message);
		}
	}
}