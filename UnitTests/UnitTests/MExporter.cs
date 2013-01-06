using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Loop.Models;
using Loop.Interfaces;
using System.IO;

namespace Loop.Tests
{
	[TestFixture]
	public class MExporter
	{
		List<ITask> tasks;

		[TestFixtureSetUp]
		public void SetupTest()
		{
			List<string> comments = new List<string>();
			comments.Add("comment1");
			comments.Add("comment2");
			this.tasks = new List<ITask>();
			tasks.Add(new Task("IR-123456", "testTitle1", TaskType.Bug, "my test description1", "my test steps1", "test background info1", comments));
			tasks.Add(new Task("IR-654321", "testTitle2", TaskType.Enhancement, "my test description2", "my test steps2", "test background info2", comments));
		}

		[Test]
		public void Export()
		{
			Exporter exp = new Exporter(@"d:\\", "test.txt");
			exp.ExportData(tasks);

			using (StreamReader sr = new StreamReader(@"d:\\test.txt"))
			{
				string line;
				int c = 0;
				// Read and display lines from the file until the end of 
				// the file is reached.
				while ((line = sr.ReadLine()) != null)
				{
					Assert.AreEqual(tasks[c].title, line);
					c++;
				}
			}
		}
	}
}
