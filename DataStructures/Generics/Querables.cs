using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures.Generics
{

    /*
     IEnumerable IEnumerable is best suitable for working with in-memory collection. 
     IEnumerable doesn’t move between items, it is forward only collection.

     IQueryable IQueryable best suits for remote data source, like a database or web service. 
     IQueryable is a very powerful feature that enables a variety of interesting deferred execution scenarios (like paging and composition based queries).

     So when you have to simply iterate through the in-memory collection, use IEnumerable, 
     if you need to do any manipulation with the collection like Dataset and other data sources, use IQueryable

     */
    class Querables
    {
    }
}
