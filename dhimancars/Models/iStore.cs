using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dhimancars.Models
{
    public interface IIStore
    {
       IQueryable<Store> Store { get;  }

       IQueryable<Store2> Store2 { get; }

        Store Save(Store store);

        void Delete(Store store);
    }
}
