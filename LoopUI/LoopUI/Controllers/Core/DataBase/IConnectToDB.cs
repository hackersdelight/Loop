using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace Loop.DatabaseConnection
{
	public interface IConnectToDB
	{
		bool OpenConnection();
		bool OpenConnection(String connectionString);
		void CloseConnection();
		void ExecNonQuery(DbCommand args);
		DataSet ExecSelect(DbCommand args);
		void BeginTransaction();
		void CommitTransaction();
		void RollbackTransaction();
		bool ConnectionIsOpen { get; }
	}
}
