using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace Loop.DatabaseConnection
{
		public class DbCommand
		{
				public String CommandText { get; set; }
				public SqlParameter[] Parameters { get; set; }
				public static DbCommand Parse(object ob)
				{
						try
						{
								return (DbCommand)ob;
						}
						catch (Exception ex)
						{
								throw ex;
						}
				}
				public DbCommandType Type;
				public enum DbCommandType
				{
						SELECT,
						INSERT,
						DELETE,
						UPDATE,
				}

				public DbCommand()
				{
				}
				
				public DbCommand(String commandText)
				{
						CommandText = commandText;
				}
		}
}
