using RANKSOnlineWholesale.DBase;
using System;

namespace RANKSOnlineWholesale.Repository
{
    public class BaseUnitOfWork : IDisposable
    {
        private RANKSWHOLESALEEntities DBEntity = new RANKSWHOLESALEEntities();
        public IRepository<Tbl_EntityType> GetRepositoryInstance<Tbl_EntityType>() where Tbl_EntityType : class
        {
            return new BaseRepository<Tbl_EntityType>(DBEntity);
        }

        public void SaveChanges()
        {
            DBEntity.SaveChanges();
        }

      protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposed)
                {
                    DBEntity.Dispose();
                }
            }
            this.disposed = true;

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private bool disposed = false;

    }
}