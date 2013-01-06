using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Xml;
using Loop.Interfaces;

namespace Loop.Models
{
	public class Importer : IImport
	{
		private string username;
		private string password;
		private string spNumber;

		public Importer(string username, string password, string spNumber)
		{
			this.username = username;
			this.password = password;
			this.spNumber = spNumber;
		}

		public List<ITask> ImportData()
		{
			return GetListOfTasks();
		}

		private XmlDocument SendRequestToBTS()
		{
			XmlDocument resultXML = new XmlDocument();
			HttpWebRequest request = SetUpRequest();
			using (var response = new StreamReader(request.GetResponse().GetResponseStream()))
			{
				resultXML.LoadXml(response.ReadToEnd());
			}
			return resultXML;
		}

		private HttpWebRequest SetUpRequest()
		{
			byte[] data = System.Text.Encoding.UTF8.GetBytes(String.Format("<Item type='Issue' action='get' select='category,issue_number,name,background, description, steps'><state condition='like'>dev%</state><target_version condition='eq'>{0}</target_version></Item>", spNumber));
			string connection = @"http://myinnovator.com/Server/InnovatorServer.aspx";
			HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(connection);
			string dbName = "MyInnovator";
			string dbUser = username;
			string dbPass = password;
			request.Headers.Set("AUTHUSER", dbUser);
			request.Headers.Set("AUTHPASSWORD", dbPass);
			request.Headers.Set("DATABASE", dbName);
			request.Headers.Set("SOAPACTION", "ApplyItem");
			request.Method = "Post";
			request.ContentType = "text/xml; charset=utf-8";
			Stream reqStream = request.GetRequestStream();
			reqStream.Write(data, 0, data.Length);
			reqStream.Close();
			return request;
		}

		private List<ITask> GetListOfTasks()
		{
			List<ITask> result = new List<ITask>();
			XmlNodeList tasks = SendRequestToBTS().SelectNodes("//Result/Item[@type='Issue']");
			foreach (XmlNode node in tasks)
			{
				result.Add(CreateTask(node));
			}
			return result;
		}

		private Task CreateTask(XmlNode node)
		{
			string number = node.SelectSingleNode("/issue_number/text()").Value;
			string title = node.SelectSingleNode("/name/text()").Value;
			TaskType type = (TaskType)Enum.Parse(typeof(TaskType), node.SelectSingleNode("/category/text()").Value);
			string descr = node.SelectSingleNode("/description/text()").Value;
			string steps = node.SelectSingleNode("/steps/text()").Value;
			string bg = node.SelectSingleNode("/background/text()").Value;
			List<string> comments = new List<string>();
			/*XmlNodeList commentNodes = node.SelectNodes("/Relationships/Item[@type='comment'");
			foreach (XmlNode comment in commentNodes)
			{
				comments.Add(comment.SelectSingleNode("/Value/text()").Value);
			}	 */
			return new Task(number, title, type, descr, steps, bg, comments);
		}
	}
}
