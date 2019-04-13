using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsultoriaLaSante.DataAccess
{
    public class UnityOfWork: IDisposable
    {
        private Context.Context ctx;
        public UnityOfWork(Context.Context ctx)
        {
            this.ctx = ctx;
        }

        public bool Save()
        {
            return ctx.SaveChanges() > 1;
        }

        private bool disposed = false;

        public  void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                ctx.Dispose();
            }

            disposed = true;
        }
    }
}
