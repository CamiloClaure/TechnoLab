using clsGeneric.Data;
using clsGeneric.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace clsGeneric.Controller
{
    public class ctrlUsuarios : clsResult, IDisposable
    {
        public Usuario GetUsuario(string userName, string password)
        {
            try
            {
                using(dUsuario luResult = new dUsuario())
                {
                    return luResult.GetUsuario(userName, password);
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Materia> GetMaterias()
        {
            try
            {
                using (dUsuario luResult = new dUsuario())
                {
                    return luResult.GetMaterias();
                }
            }
            catch
            {
                return null;
            }
        }

        public Reservas GetReserva(string CodEstudiante, int CodReserva)
        {
            try
            {
                using (dReservas reservas = new dReservas())
                {
                    return reservas.GetReserva(CodEstudiante, CodReserva);
                }
            }
            catch
            {
                return null;
            }
        }

        public Reservas GetReserva(string CodEstudiante)
        {
            try
            {
                using (dReservas reservas = new dReservas())
                {
                    return reservas.GetReserva(CodEstudiante);
                }
            }
            catch
            {
                return null;
            }
        }

        public void AddReserva(Reservas reserva, List<Materiales> materiales)
        {
            using(dReservas luResult = new dReservas())
            {
                luResult.AddReserva(reserva, materiales);
            }
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
