using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAICampo.DAL;
using UAICampo.Services;

namespace UAICampo.BLL
{
    public static class BLL_DVManager
    {
        static List<string> errores = new List<string>();
        static DAL_DV dal = new DAL_DV();

		public static bool verificarDVH(string tabla)
		{
			List<string> rows = dal.verificarDVH(tabla);

			if (rows.Count == 0)
			{
				return true;
			}

			string errorMsg = "DVH error in table:" + tabla;
			errores.Add(errorMsg);

			foreach (string row in rows)
			{
				errorMsg = "Error in row:" + row;
				errores.Add(errorMsg);
				User user = UserInstance.getInstance().user;
				SessionManager sm = new SessionManager();
				BLL_LogManager.addMessage(new Log
				{
					Date = DateTime.Now,
					Code = "DVV_ERROR",
					Description = String.Format(errorMsg),
					Type = LogType.Error,
					User = user.Id
				});
			}

			return false;
		}

		public static bool verificarDV()
		{
			bool ok = true;

			foreach (string tabla in dal.obtenerTablas())
			{
				if (!dal.verificarDVV(tabla))
				{
					ok = false;
					string errorMsg = "Error DVV in table:" + tabla;
					errores.Add(errorMsg);
					User user = UserInstance.getInstance().user;
					BLL_LogManager.addMessage(new Log
					{
						Date = DateTime.Now,
						Code = "DVV_ERROR",
						Description = String.Format(errorMsg),
						Type = LogType.Error,
						User = user.Id
					});
				}
				if (!verificarDVH(tabla))
				{
					ok = false;
				}
			}

			return ok;
		}

		public static string obtenerErrores()
		{
			var result = new System.Text.StringBuilder();
			foreach (string error in errores)
			{
				result.Append(error + "\n");
			}

			return result.ToString();
		}

		public static async void actualizarDV()
		{
			await Task.Run(() =>
			{
				try
				{
					BLL_DVManager.borrarErrores();

					foreach (string tabla in dal.obtenerTablas())
					{
						dal.actualizarDVH(tabla);
						dal.actualizarDVV(tabla);
					}
					BLL_LogManager.addMessage(new Log
					{
						Date = DateTime.Now,
						Code = "DV_REFRESH",
						Description = "Check digits refreshed.",
						Type = LogType.Info,
						User = UserInstance.getInstance().user.Id
					});

				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
			});
		}

		private static void borrarErrores()
		{
			errores.Clear();
		}
	}
}
