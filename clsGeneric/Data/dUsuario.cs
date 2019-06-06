using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;

namespace clsGeneric.Data
{
    public class dUsuario : clsResult, IDisposable
    {
        public clsConnection guConnection;

        public dUsuario()
        {
            this.guConnection = new clsConnection();
        }

        public Usuario GetUsuario(string name, string password)
        {
            Usuario user = new Usuario();
            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();
                    DynamicParameters luParameters = new DynamicParameters();
                    luParameters.Add("@CodUser", name);
                    luParameters.Add("@pwUser", password);
                    user = guConnection.guDb.Query<Usuario>(@"select * from usuario where codigo = @CodUser and pass = @pwUser", luParameters).FirstOrDefault();

                    guConnection.mtdCerrar();
                }
            }
            catch
            {

            }

            return user;
        }

        public List<Materia> GetMaterias()
        {
            List<Materia> lsMaterias = new List<Materia>();

            try
            {
                using (guConnection)
                {
                    guConnection.mtdAbrir();

                    lsMaterias = guConnection.guDb.Query<Materia>(@"select IdMateria, Docente, Nombre from materia").ToList();

                    guConnection.mtdCerrar();
                }
            }catch(Exception ex)
            {
                ex.ToString();
            }

            return lsMaterias;
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
