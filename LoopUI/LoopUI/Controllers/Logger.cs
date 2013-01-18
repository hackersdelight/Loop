using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace LoopUI.Controllers
{
	public class Logger
	{
		string logPath;

		private Logger()
		{
			logPath = "D:\\Log.txt";
		}

		private static Logger instance;

		internal static Logger Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new Logger();
				}
				return instance;
			}
		}

		internal void WriteToLog(string message)
		{
			using (StreamWriter writer = new StreamWriter(logPath, true))
			{
				writer.WriteLine(DateTime.Now + ": " + message);
				writer.Close();
			}
		}
	}
}