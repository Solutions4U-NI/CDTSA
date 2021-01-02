﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Util;
using System.Data;
using System.Data.SqlClient;

namespace Security
{
	public static class RoleDAC
	{
		public static DataSet GetArbolAcciones( SqlTransaction tran = null)
		{
			String strSQL = "dbo.secGetArbolAcciones";

			SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

			oCmd.CommandType = CommandType.StoredProcedure;
			if (tran != null)
				oCmd.Transaction = tran;
			
			SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
			DataSet DS = new DataSet();

			oAdap.Fill(DS, "Data");

			return DS;

		}

		public static DataSet GetAccionesByRole(int IDRole, SqlTransaction tran = null)
		{
			String strSQL = "dbo.secGetAccionByRole";

			SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

			oCmd.CommandType = CommandType.StoredProcedure;
			oCmd.Parameters.Add(new SqlParameter("@IDRole", IDRole));
			if (tran != null)
				oCmd.Transaction = tran;

			SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
			DataSet DS = new DataSet();

			oAdap.Fill(DS, "Data");

			return DS;

		}

		public static DataSet GetRole(int IDRole, SqlTransaction tran = null)
		{
			String strSQL = "dbo.secGetRole";

			SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

			oCmd.CommandType = CommandType.StoredProcedure;
			oCmd.Parameters.Add(new SqlParameter("@IDRole", IDRole));
			if (tran != null)
				oCmd.Transaction = tran;

			SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
			DataSet DS = new DataSet();

			oAdap.Fill(DS, "Data");

			return DS;

		}

		
		public static long InsertUpdateRole(string Accion,ref int IDRole, String Descr, String DescrLarga, SqlTransaction tran)
		{
			long result = -1;
			String strSQL = "dbo.secUpdateRole";

			SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

			oCmd.Parameters.Add(new SqlParameter("@Accion", Accion));
			oCmd.Parameters.Add(new SqlParameter("@IDRole", IDRole));
			oCmd.Parameters["@IDRole"].Direction = ParameterDirection.InputOutput;
			oCmd.Parameters.Add(new SqlParameter("@Descr", Descr));
			oCmd.Parameters.Add(new SqlParameter("@DescrLarga", DescrLarga));
			


			oCmd.CommandType = CommandType.StoredProcedure;
			oCmd.Transaction = tran;
			result = oCmd.ExecuteNonQuery();
			if (Accion == "I")
			{
				IDRole = (int)oCmd.Parameters["@IDRole"].Value;
				
			}


			return result;

		}


		public static long InsertUpdateRoleAccion(string Accion, int IDModulo, int IDRole, int IDAccion, SqlTransaction tran)
		{
			long result = -1;
			String strSQL = "dbo.secUpdateRoleAccion";

			SqlCommand oCmd = new SqlCommand(strSQL, Security.ConnectionManager.GetConnection());

			oCmd.Parameters.Add(new SqlParameter("@Accion", Accion));
			oCmd.Parameters.Add(new SqlParameter("@IDModulo", IDModulo));
			oCmd.Parameters.Add(new SqlParameter("@IDRole", IDRole));
			oCmd.Parameters.Add(new SqlParameter("@IDAccion", IDAccion));


			oCmd.CommandType = CommandType.StoredProcedure;
			oCmd.Transaction = tran;
			result = oCmd.ExecuteNonQuery();

			return result;

		}

	}
}
