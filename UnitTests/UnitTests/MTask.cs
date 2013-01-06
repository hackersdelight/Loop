using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Loop.Models;
using NUnit.Framework;

namespace Loop.Tests
{
	[TestFixture]
	public class MTask
	{
		[Test]
		public void CreateTask()
		{
			List<string> comments = new List<string>();
			comments.Add("comment1");
			comments.Add("comment2");
			Task t = new Task("IR-123456", "testTitle", TaskType.Bug, "my test description", "my test steps", "test background info", comments);
			Assert.AreEqual(t.number + " - " + t.title, t.GetTaskTitle());
			Assert.AreEqual("comment1\ncomment2\n", t.GetTaskComments());
		}
	}
}
