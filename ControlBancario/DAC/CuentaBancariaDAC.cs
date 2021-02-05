﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Security;

namespace ControlBancario.DAC
{
    public static class CuentaBancariaDAC
    {
        public static SqlDataAdapter oAdaptador = InicializarAdaptador();
        
        private static SqlDataAdapter InicializarAdaptador()
        {
			String getSQL = "[dbo].[cbGetCuentaBancaria]";
            String InsertSQL = "[dbo].[cbUpdateCuentaBancaria]";
            String UpdateSQL = "[dbo].[cbUpdateCuentaBancaria]";
            String DeleteSQL = "[dbo].[cbUpdateCuentaBancaria]";

            try
            {
                SqlDataAdapter oAdaptador = new SqlDataAdapter()
                {
                    SelectCommand = new SqlCommand(getSQL, ConnectionManager.GetConnection()),
                    InsertCommand = new SqlCommand(InsertSQL, ConnectionManager.GetConnection()),
                    UpdateCommand = new SqlCommand(UpdateSQL, ConnectionManager.GetConnection()),
                    DeleteCommand = new SqlCommand(DeleteSQL, ConnectionManager.GetConnection())
                };

                //Paremetros Select 
				oAdaptador.SelectCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.SelectCommand.Parameters.Add("@IDCuenta", SqlDbType.Int).SourceColumn = "IDCuenta";
                oAdaptador.SelectCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                


                //Paremetros Insert
                oAdaptador.InsertCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.InsertCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "I";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.InsertCommand.Parameters.Add("@Codigo", SqlDbType.NChar).SourceColumn = "Codigo";
                oAdaptador.InsertCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.InsertCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                oAdaptador.InsertCommand.Parameters.Add("@IDMoneda", SqlDbType.Int).SourceColumn = "IDMoneda";
                oAdaptador.InsertCommand.Parameters.Add("@SaldoInicial", SqlDbType.Decimal).SourceColumn = "SaldoInicial";
                oAdaptador.InsertCommand.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).SourceColumn = "FechaCreacion";
                oAdaptador.InsertCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
				oAdaptador.InsertCommand.Parameters.Add("@ConsecCheque", SqlDbType.Int).SourceColumn = "ConsecCheque";
                oAdaptador.InsertCommand.Parameters.Add("@Limite", SqlDbType.Decimal).SourceColumn = "Limite";
                oAdaptador.InsertCommand.Parameters.Add("@IDCuenta", SqlDbType.Int ).SourceColumn = "IDCuenta";
                oAdaptador.InsertCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";


                //Paremetros Update 
                oAdaptador.UpdateCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.UpdateCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "U";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.UpdateCommand.Parameters.Add("@Codigo", SqlDbType.NChar).SourceColumn = "Codigo";
                oAdaptador.UpdateCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.UpdateCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                oAdaptador.UpdateCommand.Parameters.Add("@IDMoneda", SqlDbType.Int).SourceColumn = "IDMoneda";
                oAdaptador.UpdateCommand.Parameters.Add("@SaldoInicial", SqlDbType.Decimal).SourceColumn = "SaldoInicial";
                oAdaptador.UpdateCommand.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).SourceColumn = "FechaCreacion";
                oAdaptador.UpdateCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
				oAdaptador.UpdateCommand.Parameters.Add("@ConsecCheque", SqlDbType.Int).SourceColumn = "ConsecCheque";
                oAdaptador.UpdateCommand.Parameters.Add("@Limite", SqlDbType.Decimal).SourceColumn = "Limite";
                oAdaptador.UpdateCommand.Parameters.Add("@IDCuenta", SqlDbType.Int ).SourceColumn = "IDCuenta";
                oAdaptador.UpdateCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";
 


                //Paremetros Delete 
                oAdaptador.DeleteCommand.CommandType = CommandType.StoredProcedure;
                oAdaptador.DeleteCommand.Parameters.Add("@Operacion", SqlDbType.NChar).Value = "D";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).SourceColumn = "IDCuentaBanco";
                oAdaptador.DeleteCommand.Parameters.Add("@Codigo", SqlDbType.NChar).SourceColumn = "Codigo";
                oAdaptador.DeleteCommand.Parameters.Add("@Descr", SqlDbType.NChar).SourceColumn = "Descr";
                oAdaptador.DeleteCommand.Parameters.Add("@IDBanco", SqlDbType.Int).SourceColumn = "IDBanco";
                oAdaptador.DeleteCommand.Parameters.Add("@IDMoneda", SqlDbType.Int).SourceColumn = "IDMoneda";
                oAdaptador.DeleteCommand.Parameters.Add("@SaldoInicial", SqlDbType.Decimal).SourceColumn = "SaldoInicial";
                oAdaptador.DeleteCommand.Parameters.Add("@FechaCreacion", SqlDbType.DateTime).SourceColumn = "FechaCreacion";
                oAdaptador.DeleteCommand.Parameters.Add("@IDTipo", SqlDbType.Int).SourceColumn = "IDTipo";
				oAdaptador.DeleteCommand.Parameters.Add("@ConsecCheque", SqlDbType.Int).SourceColumn = "ConsecCheque";
                oAdaptador.DeleteCommand.Parameters.Add("@Limite", SqlDbType.Decimal).SourceColumn = "Limite";
                oAdaptador.DeleteCommand.Parameters.Add("@IDCuenta", SqlDbType.Int ).SourceColumn = "IDCuenta";
                oAdaptador.DeleteCommand.Parameters.Add("@Activa", SqlDbType.Bit).SourceColumn = "Activa";

                return oAdaptador;
            }
            catch (Exception)
            {
                throw;
            }
        }



        public static void SetTransactionToAdaptador(bool Activo)
        {
            oAdaptador.UpdateCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.DeleteCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
            oAdaptador.InsertCommand.Transaction = (Activo) ? ConnectionManager.Tran : null;
        }

        private static DataSet CreateDataSet()
        {
            DataSet DS = new DataSet();
            DataTable tipoTable = DS.Tables.Add("Data");
            return DS;
        }

        public static DataSet GetData(int IDCuenta, int IDBanco)
        {
            DataSet DS = CreateDataSet();
            oAdaptador.SelectCommand.Parameters["@IDCuenta"].Value = IDCuenta;
            oAdaptador.SelectCommand.Parameters["@IDBanco"].Value = IDBanco;
            
            oAdaptador.Fill(DS.Tables["Data"]);
            return DS;
        }

        public static int NextConsecutivoCheque(int IDCuentaBanco)
        {
            int ID = 0;
            DataSet DS = new DataSet();

            SqlCommand oCmd = new SqlCommand("dbo.cbNextConsecutivoCheque", ConnectionManager.GetConnection());
            SqlConnection oConn = oCmd.Connection;
            try
            {


                oCmd.CommandType = CommandType.StoredProcedure;
                oCmd.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).Value = IDCuentaBanco;
                oCmd.Parameters.Add("@NextConsecutivo", SqlDbType.Int);
                oCmd.Parameters["@NextConsecutivo"].Direction = ParameterDirection.Output;


                if (oConn.State == ConnectionState.Closed)
                    oConn.Open();
                oCmd.ExecuteNonQuery();

                if (oCmd.Parameters["@NextConsecutivo"].Value != DBNull.Value)
                    ID = (int)oCmd.Parameters["@NextConsecutivo"].Value;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (oConn.State == ConnectionState.Open)
                    oConn.Close();

            }
            return ID;

        }


		public static bool ActualizarSaldoLibro(int IDCuentaBanco, DateTime FechaCorte, int IDAccion, int IDMovimiento=-1)
		{
			String strSQL = "dbo.cbActualizaSaldoBancoLibros";
			bool Result = false;
			
			SqlCommand oCmd = new SqlCommand(strSQL, ConnectionManager.GetConnection());
			try
			{

				oCmd.Parameters.Add(new SqlParameter("@IDCuentaBanco", IDCuentaBanco));
				oCmd.Parameters.Add(new SqlParameter("@FechaCorte", FechaCorte));
				oCmd.Parameters.Add(new SqlParameter("@IDMovimiento", IDMovimiento));
				oCmd.Parameters.Add(new SqlParameter("@IDAccion", IDAccion));

				oCmd.CommandType = CommandType.StoredProcedure;

				oCmd.Connection.Open();
				oCmd.ExecuteNonQuery();
				Result = true;

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (oCmd.Connection.State == ConnectionState.Open)
					oCmd.Connection.Close();
			}
			return Result;
		}

		public static Decimal GetSaldoCuentaLibro(int IDCuentaBanco,DateTime FechaCorte,int IDAccion)
		{
			Decimal Saldo = 0;
			
			SqlCommand oCmd = new SqlCommand("dbo.cbGetSaldoCuentaLibros", ConnectionManager.GetConnection());
			SqlConnection oConn = oCmd.Connection;
			try
			{

								 
				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).Value = IDCuentaBanco;
				oCmd.Parameters.Add("@FechaCorte", SqlDbType.DateTime).Value  = FechaCorte;
				oCmd.Parameters.Add("@IDAccion", SqlDbType.Int).Value = IDAccion;


				SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
				DataSet DS = CreateDataSet();

				oAdap.Fill(DS.Tables["Data"]);

				Saldo = Convert.ToDecimal(DS.Tables[0].Rows[0][0].ToString() == "" ? "0": DS.Tables[0].Rows[0][0] );

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (oConn.State == ConnectionState.Open)
					oConn.Close();

			}
			return Saldo;

		}

		public static Decimal GetSaldoCuentaBanco(int IDCuentaBanco, DateTime FechaCorte)
		{
			Decimal Saldo = 0;

			SqlCommand oCmd = new SqlCommand("dbo.cbGetSaldoCuentaBancos", ConnectionManager.GetConnection());
			SqlConnection oConn = oCmd.Connection;
			try
			{


				oCmd.CommandType = CommandType.StoredProcedure;
				oCmd.Parameters.Add("@IDCuentaBanco", SqlDbType.Int).Value = IDCuentaBanco;
				oCmd.Parameters.Add("@FechaCorte", SqlDbType.DateTime).Value = FechaCorte;


				SqlDataAdapter oAdap = new SqlDataAdapter(oCmd);
				DataSet DS = CreateDataSet();

				oAdap.Fill(DS.Tables["Data"]);

				Saldo = Convert.ToDecimal(DS.Tables[0].Rows[0][0].ToString() == "" ? "0" :DS.Tables[0].Rows[0][0]);

			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (oConn.State == ConnectionState.Open)
					oConn.Close();

			}
			return Saldo;

		}


		public static DataSet GetEstadoCuentaBancaria(DateTime FechaInicial, DateTime FechaFinal, int IDCuentaBanco)
		{

			DataSet DS = new DataSet();

			SqlCommand oCmd = new SqlCommand("dbo.cbGetEstadoCuenta", ConnectionManager.GetConnection());
			SqlConnection oConn = oCmd.Connection;
			try
			{


				oCmd.CommandType = CommandType.StoredProcedure;
				SqlDataAdapter oAdapatadorTmp = new SqlDataAdapter(oCmd);
				oCmd.Parameters.Add("@FechaInicial", SqlDbType.DateTime, 50).Value = FechaInicial;
				oCmd.Parameters.Add("@FechaFinal", SqlDbType.DateTime, 50).Value = FechaFinal;
				oCmd.Parameters.Add("@IDCuentaBanco", SqlDbType.Int, 50).Value = IDCuentaBanco;
				
				oAdapatadorTmp.Fill(DS, "Data");


			}
			catch (Exception)
			{
				throw;
			}
			finally
			{
				if (oConn.State == ConnectionState.Open)
					oConn.Close();

			}
			return DS;

		}
       
    }
}
