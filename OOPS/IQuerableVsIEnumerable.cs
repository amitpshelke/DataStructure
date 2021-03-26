using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPS.IQuerableVsIEnumerable
{
    /*
      
        IEnumerable : -
        - IEnumerable exists in System.Collections Namespace.
        - IEnumerable doesn’t support lazy loading
        - Querying data from a database, IEnumerable execute a select query on the server side, load data in-memory on a client-side and then filter data.
        - IEnumerable Extension methods take functional objects.

        IQueryable:-
        - IQueryable exists in System.Linq Namespace.
        - IQueryable support lazy loading
        - Querying data from a database, IQueryable execute the select query on the server side with all filters.
        - IQueryable Extension methods take expression objects means expression tree 
        
        ** Both IEnumerable and IQueryable are forward collection.
        
        ** IEnumerable is great for working with in-memory collections, but IQueryable allows for a remote data source, like a database or web service
    */


    public class QueryData
    { 
        public void Get()
        {
            try
            {
                DBEntities dBEntities1 = new DBEntities();
                IEnumerable<tblCity> ienum = dBEntities1.tblCities.Where(c => c.CityName.StartsWith("M"));
                ienum = ienum.Take(2);
                /*
                 ienum here generates below query 
                 
                 SELECT [Extent1].[ID] AS [ID], 
                        [Extent1].[CityName] AS [CityName], 
                        [Extent1].[StateID] AS [StateID], 
                        [Extent1].[IsActive] AS [IsActive], 
                        [Extent1].[DateAdded] AS [DateAdded], 
                        [Extent1].[DateModified] AS [DateModified]
                        FROM [dbo].[tblCity] AS [Extent1]
                        WHERE [Extent1].[CityName] LIKE 'M%
                 */

                foreach (var item in ienum)
                {
                    Console.WriteLine(item);
                }

                DBEntities dBEntities2 = new DBEntities();
                IQueryable<tblCity> iquery = dBEntities2.tblCities.AsQueryable().Where(c => c.CityName.StartsWith("M"));
                iquery = iquery.Take(2);

                /*
                   iquery here generates below query 
                 
                   SELECT TOP (2) [Extent1].[ID] AS [ID], 
                                  [Extent1].[CityName] AS [CityName], 
                                  [Extent1].[StateID] AS [StateID], 
                                  [Extent1].[IsActive] AS [IsActive], 
                                  [Extent1].[DateAdded] AS [DateAdded], 
                                  [Extent1].[DateModified] AS [DateModified]
                                  FROM [dbo].[tblCity] AS [Extent1]
                                  WHERE [Extent1].[CityName] LIKE 'M%'
                 */

                foreach (var item in iquery.Take(2))
                {
                    Console.WriteLine(item);
                }
            }
            catch (Exception ex)
            {
                string error = ex.Message;
            }
        }
    }


    public class Client
    {
        public static void Execute()
        {
            QueryData qd = new QueryData();
            qd.Get();
        }
    }
}
