﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services;

namespace UAICampo.DAL
{
    public class DAL_DV
    {
        private static readonly string CONNECTION_STRING = DataBaseServices.getConnectionString();

        private SqlConnection sqlConnection;
		private SqlConnection sqlConnection1;
		private SqlCommand sqlCommand;
        private SqlDataReader sqlReader;

		public bool verificarDVV(string tabla)
		{
			string dvvCalculado = calcularDVV(tabla).GetHashCode().ToString();
			return dvvCalculado.Equals(obtenerDVV(tabla));
		}
		public string calcularDVV(string tabla)
		{
			using (sqlConnection = new SqlConnection(CONNECTION_STRING))
			{
				string selectDVH = $"SELECT dvh FROM {tabla}";
				SqlCommand query = new SqlCommand(selectDVH, sqlConnection);
				sqlConnection.Open();
				SqlDataReader data = query.ExecuteReader();

				var dvhs = new System.Text.StringBuilder();
				while (data.Read())
				{
					dvhs.Append(data["dvh"]);
				}
				sqlConnection.Close();

				return dvhs.ToString();
			}
		}

		public string obtenerDVV(string tabla)
		{
			using (sqlConnection = new SqlConnection(CONNECTION_STRING))
			{
				string selectDVV = $"SELECT dvv FROM dvv WHERE tableName = '{tabla}'";
				SqlCommand query = new SqlCommand(selectDVV, sqlConnection);
				sqlConnection.Open();
				SqlDataReader data = query.ExecuteReader();

				string dvv = "";
				while (data.Read())
				{
					dvv = data["dvv"].ToString();
				}
				sqlConnection.Close();

				return dvv;
			}
		}

		public List<string> verificarDVH(string tabla)
		{
			using (sqlConnection = new SqlConnection(CONNECTION_STRING))
			{
				List<string> result = new List<string>();

				string selectDVH = $"SELECT * FROM {tabla}";
				SqlCommand query = new SqlCommand(selectDVH, sqlConnection);
				sqlConnection.Open();
				SqlDataReader data = query.ExecuteReader();

				var dvhs = new System.Text.StringBuilder();
				int row = 1;
				while (data.Read())
				{
					for (int i = 0; i < data.FieldCount; i++)
					{
						if (!data.GetName(i).Equals("dvh") && !isForeignKey(data.GetName(i)))
						{
							dvhs.Append(data.GetValue(i).GetHashCode().ToString());
						}
					}

					string dvhsCalculated = dvhs.ToString().GetHashCode().ToString();
					if (dvhsCalculated != data["dvh"].ToString())
					{
						result.Add(row.ToString());
					}
					row++;
					dvhs.Clear();
				}
				sqlConnection.Close();

				return result;
			}
		}
		public void actualizarDVV(string tabla)
		{
			using (sqlConnection1 = new SqlConnection(CONNECTION_STRING))
			{
				try
				{

					string SQL = $"UPDATE dvv SET dvv = '{calcularDVV(tabla).GetHashCode().ToString()}' WHERE tableName = '{tabla}'";
					sqlConnection1.Open();
					SqlCommand mCom = new SqlCommand(SQL, sqlConnection1);

					mCom.ExecuteNonQuery();
					sqlConnection1.Close();
				}
				catch (Exception e)
				{
					User user = UserInstance.getInstance().user;
					SessionManager sm = new SessionManager();
					DAL_Log dal_log = new DAL_Log();
					dal_log.Save(new Log
					{
						Date = DateTime.Now,
						Code = "DVVREFRESH_ERROR",
						Description = String.Format("DVV refresh error"),
						Type = LogType.Error,
						User = user.Id
					});
				}
			}
		}
		public void actualizarDVH(string tabla)
		{
			using (sqlConnection = new SqlConnection(CONNECTION_STRING))
			{
				try
				{

					List<string> result = new List<string>();

					string selectDVH = $"SELECT * FROM {tabla}";
					SqlCommand selectQuery = new SqlCommand(selectDVH, sqlConnection);
					sqlConnection.Open();
					SqlDataReader data = selectQuery.ExecuteReader();

					var finalQuery = new System.Text.StringBuilder();
					var dvhs = new System.Text.StringBuilder();
					int row = 1;
					while (data.Read())
					{
						for (int i = 0; i < data.FieldCount; i++)
						{
							if (!data.GetName(i).Equals("dvh") && !isForeignKey(data.GetName(i)))
							{
								dvhs.Append(data.GetValue(i).GetHashCode().ToString());
							}
						}

						finalQuery.Append($"UPDATE {tabla} SET dvh = '{dvhs.ToString().GetHashCode().ToString()}' WHERE id = {data["id"].ToString()};");
						row++;
						dvhs.Clear();
					}
					sqlConnection.Close();

					sqlConnection.Open();
					SqlCommand updateQuery = new SqlCommand(finalQuery.ToString(), sqlConnection);
					updateQuery.ExecuteNonQuery();
					sqlConnection.Close();
				}
				catch (Exception e)
				{
					User user = UserInstance.getInstance().user;
					SessionManager sm = new SessionManager();
					DAL_Log dal_log = new DAL_Log();
					dal_log.Save(new Log
					{
						Date = DateTime.Now,
						Code = "DVHREFRESH_ERROR",
						Description = String.Format("DVH refresh error"),
						Type = LogType.Error,
						User = user.Id
					});
				}
			}
		}
		public List<string> obtenerTablas()
		{
			using (sqlConnection = new SqlConnection(CONNECTION_STRING))
			{
				string selectDVV = "SELECT tableName FROM dvv";
				SqlCommand query = new SqlCommand(selectDVV, sqlConnection);
				sqlConnection.Open();
				SqlDataReader data = query.ExecuteReader();

				List<string> names = new List<string>();
				while (data.Read())
				{
					names.Add(data["tableName"].ToString());
				}
				sqlConnection.Close();

				return names;
			}
		}
		public bool isForeignKey(string colName)
		{
			if (colName.Length < 4)
			{
				return false;
			}

			if (colName.Substring(1,3).Equals("FK_"))
			{
				return true;
			}

			return false;
		}
	}
}
