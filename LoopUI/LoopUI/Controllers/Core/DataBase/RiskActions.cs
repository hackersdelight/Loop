using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Loop.Interfaces;
using Loop.DatabaseConnection;
using LoopUI.Models;
using System.Data;
using System.Data.SqlClient;

namespace LoopUI.Controllers
{
	internal class RiskActions : IRiskActions
	{
		private IConnectToDB connection;

		//work collection of users to prevent frequent usage of db
		private List<IRisk> RiskCollection;
		private List<IRiskType> RiskTypesCollection;

		internal RiskActions(IConnectToDB connection)
		{
			this.connection = connection;
		}

		public void AddRisk(IRisk risk)
		{
			throw new NotImplementedException();
		}

		public List<IRisk> GetAllRisks()
		{
			if (RiskCollection == null)
			{
				try
				{
					connection.OpenConnection();
					DbCommand command = new DbCommand("select * from Risks");
					command.Type = DbCommand.DbCommandType.SELECT;
					DataSet set = connection.ExecSelect(command);
					RiskCollection = new List<IRisk>();
					foreach (DataRow row in set.Tables[0].Rows)
					{
						RiskCollection.Add(CreateRiskModelInstance(row));
					}
				}
				finally
				{
					connection.CloseConnection();
				}
			}
			return RiskCollection;
		}

		public List<IRiskType> GetAllRiskTypes()
		{
			if (RiskTypesCollection == null)
			{
				try
				{
					connection.OpenConnection();
					DbCommand command = new DbCommand("select * from RiskTypes");
					command.Type = DbCommand.DbCommandType.SELECT;
					DataSet set = connection.ExecSelect(command);
					RiskTypesCollection = new List<IRiskType>();
					foreach (DataRow row in set.Tables[0].Rows)
					{
						RiskTypesCollection.Add(CreateRiskTypeInstance(row));
					}
				}
				finally
				{
					connection.CloseConnection();
				}
			}
			return RiskTypesCollection;
		}


		public void DeleteRisk(int id)
		{
			throw new NotImplementedException();
		}

		public void EditRisk(IRisk risk)
		{
			try
			{
				connection.OpenConnection();
				DbCommand command = new DbCommand("UPDATE Risks SET Title = @title, TypeId = @typeid where Id = @id;");
				command.Parameters = new SqlParameter[3];
				command.Parameters[0] = new SqlParameter("id", risk.Id);
				command.Parameters[1] = new SqlParameter("title", risk.Title);
				command.Parameters[2] = new SqlParameter("typeid", risk.Type.Id);
				command.Type = DbCommand.DbCommandType.UPDATE;
				connection.ExecNonQuery(command);
				if (RiskCollection != null)
				{
					//update value in Collection
					RiskCollection.Remove(RiskCollection.Find(x => x.Id == risk.Id));
					RiskCollection.Add(risk);
				}
			}
			finally
			{
				connection.CloseConnection();
			}
		}

		public IRisk GetRiskById(int id)
		{
			if (RiskCollection == null)
				GetAllRisks();
			if (RiskCollection.Exists(x => x.Id == id))
			{
				return RiskCollection.Find(x => x.Id == id);
			}
			else return null;
		}

		private IRiskType GetRiskTypeById(int id)
		{
			if (RiskTypesCollection == null)
				GetAllRiskTypes();
			if (RiskTypesCollection.Exists(x => x.Id == id))
			{
				return RiskTypesCollection.Find(x => x.Id == id);
			}
			else return null;
		}

		private IRiskType CreateRiskTypeInstance(DataRow row)
		{
			RiskType r = new RiskType()
			{
				Id = Convert.ToInt32(row["Id"]),
				Title = row["Title"].ToString()
			};
			return r;
		}

		private IRisk CreateRiskModelInstance(DataRow row)
		{
			Risk r = new Risk()
			{
				Id = Convert.ToInt32(row["Id"]),
				Title = row["Title"].ToString(),
				Type = GetRiskTypeById(Convert.ToInt32(row["TypeId"]))
			};
			return r;
		}
	}
}