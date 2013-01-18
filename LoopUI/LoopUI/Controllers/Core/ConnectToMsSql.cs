using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using LoopUI.Controllers;

namespace Loop.DatabaseConnection
{
	public class ConnectToMsSql : IConnectToDB
	{
		protected bool transactionIsActive;
		protected bool connectionIsOpen;
		protected SqlTransaction transaction;
		protected SqlConnection connection;

		public bool ConnectionIsOpen
		{
			get
			{
				return connectionIsOpen;
			}
		}

		public ConnectToMsSql()
		{
			transactionIsActive = false;
			connectionIsOpen = false;
		}

		public bool OpenConnection()
		{
			if (!(connectionIsOpen))
			{
				connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);
				connection.Open();
				connectionIsOpen = true;
			}
			else
			{
				Logger.Instance.WriteToLog("Warning: connection is already opened.");
			}
			return connectionIsOpen;
		}

		public bool OpenConnection(String newConnectionString)
		{
			if (!(connectionIsOpen))
			{
				connection = new SqlConnection(newConnectionString);
				connection.Open();
				connectionIsOpen = true;
			}
			else
			{
				Logger.Instance.WriteToLog("Warning: connection is already opened.");
			}
			return connectionIsOpen;
		}

		public void CloseConnection()
		{
			if (connectionIsOpen)
			{
				if (transactionIsActive)
				{
					RollbackTransaction();
				}
				connection.Close();
				connectionIsOpen = false;
			}
			else
			{
				Logger.Instance.WriteToLog("Error: there is no open connection."); ;
			}
		}

		public void ExecNonQuery(DbCommand args)
		{
			if (connectionIsOpen)
			{
				if ((args != null) && (args.CommandText != String.Empty))
				{
					SqlCommand command = null;
					if (!transactionIsActive)
					{
						command = new SqlCommand(args.CommandText, connection);
					}
					else
					{
						command = new SqlCommand(args.CommandText, connection, transaction);
					}
					if (args.Parameters != null)
					{
						command.Parameters.AddRange(args.Parameters);
					}
					command.ExecuteNonQuery();
				}
				else
				{
					Logger.Instance.WriteToLog("Error in command arguments.");
				}
			}
			else
			{
				Logger.Instance.WriteToLog("Error: connection was not opened.");
			}
		}

		public DataSet ExecSelect(DbCommand args)
		{
			if (connectionIsOpen)
			{
				if ((args != null) && (args.CommandText != String.Empty))
				{
					SqlCommand command = null;
					if (!transactionIsActive)
					{
						command = new SqlCommand(args.CommandText, connection);
					}
					else
					{
						command = new SqlCommand(args.CommandText, connection, transaction);
					}
					if (args.Parameters != null)
					{
						command.Parameters.AddRange(args.Parameters);
					}
					var dataAdapter = new SqlDataAdapter(command);
					var dataSet = new DataSet(connection.Database);
					dataAdapter.Fill(dataSet);
					return dataSet;
				}
				else
				{
					Logger.Instance.WriteToLog("Error in command arguments.");
				}
			}
			else
			{
				Logger.Instance.WriteToLog("Error: connection was not opened.");
			}
			return null;
		}

		public void BeginTransaction()
		{
			if (connectionIsOpen)
			{
				if (!transactionIsActive)
				{
					transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
					transactionIsActive = true;
				}
				else
				{
					Logger.Instance.WriteToLog("Error: transaction is already began.");
				}
			}
			else
			{
				Logger.Instance.WriteToLog("Error: connection was not opened.");
			}
		}

		public void CommitTransaction()
		{
			if (connectionIsOpen)
			{
				if (transactionIsActive)
				{
					transaction.Commit();
					transactionIsActive = false;
				}
				else
				{
					Logger.Instance.WriteToLog("Error: there is no active transaction.");
				}
			}
			else
			{
				Logger.Instance.WriteToLog("Error: connection was not opened.");
			}
		}

		public void RollbackTransaction()
		{
			if (connectionIsOpen)
			{
				if (transactionIsActive)
				{
					transaction.Rollback();
					transactionIsActive = false;
				}
				else
				{
					Logger.Instance.WriteToLog("Error: there is no active transaction.");
				}
			}
			else
			{
				Logger.Instance.WriteToLog("Error: connection was not opened.");
			}
		}
	}
}
