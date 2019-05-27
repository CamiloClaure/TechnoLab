using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace clsGeneric.Data
{
    public class clsConnection : IDisposable
    {
        public MySqlConnection guDb;

        private string gsConnectionName = "CnxConnectionString";

        public clsConnection()
        {
            string lsConexion = ConfigurationManager.ConnectionStrings[gsConnectionName].ConnectionString;
            this.guDb = new MySqlConnection(lsConexion);
        }

        public void mtdAbrir()
        {
            if (this.guDb.State.ToString() != "Open")
                this.guDb.Open();
        }

        public void mtdCerrar()
        {
            if (this.guDb.State.ToString() == "Open")
                this.guDb.Close();
        }


        #region IDisposable Support
        // some fields that require cleanup
        private bool disposed = false; // to detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                // Dispose unmanaged managed resources.
                disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
