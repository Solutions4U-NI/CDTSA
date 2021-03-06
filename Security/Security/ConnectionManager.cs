﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;


namespace Security
{

    public  sealed class ConnectionManager
    {
        public static SqlTransaction Tran;
        private static SqlConnection oConn;

        public static void ResetCon() {
            oConn = null;
        }

        public static  SqlConnection GetConnection()
        {
            if (oConn == null)
            {
                String sNameConexion = (Esquema.Compania == "CEDETSA") ? "StringConCedetsa" : "StringConDasa";
                String ConnectionString =  ConfigurationManager.ConnectionStrings[sNameConexion].ConnectionString;
                oConn = new SqlConnection(ConnectionString);
            }
            //connection.Open();
            return oConn;
        }

        public static void BeginTran()
        {

            if (oConn.State == System.Data.ConnectionState.Closed)
                oConn.Open();
            Tran = oConn.BeginTransaction();
        }

        public static void CommitTran()
        {
            Tran.Commit();
            Tran = null;
        }

        public static void RollBackTran()
        {
            if (Tran != null)
                Tran.Rollback();
            if (oConn.State == System.Data.ConnectionState.Open)
                oConn.Close();
            Tran = null;
        }
    }
}
