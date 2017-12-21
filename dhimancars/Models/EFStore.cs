using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using dhimancars.Models;
using dhimancars.Controllers;

namespace dhimancars.Models
{
    public class EFStore : IIStore
    {
        StoreModel db = new StoreModel();

        public IQueryable<Store> Store { get { return db.Stores; } }

        public IQueryable<Store2> Store2 => throw new NotImplementedException();

        public void Delete(Store store)
        {
            db.Stores.Remove(store);
            db.SaveChanges();
        }

        public Store Save(Store store)
        {
            if (store.CarID == 0 )
            {
                db.Stores.Add(store);
            }
            else
            {
                db.Entry(Store).State = System.Data.Entity.EntityState.Modified;
            }
            db.SaveChanges();
            return store;
        }
    }
}