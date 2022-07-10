using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.Services;

namespace UAICampo.DAL
{
   public abstract class DAL_Connection
    {
		protected SqlConnection conn;
		public DAL_Connection()
		{
			try
			{
				this.conn = new SqlConnection(DataBaseServices.getConnectionString());
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}
