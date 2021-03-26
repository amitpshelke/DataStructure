using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace EDF
{
    public class LicenseData
    {
        public DataTable dt = null;

        public LicenseData()
        {
            CreateTable();
            FillTable();
            FilterData();
        }

        private void CreateTable()
        {
            dt = new DataTable();
            dt.Columns.Add(new DataColumn("Token", typeof(String)));
            dt.Columns.Add(new DataColumn("CreatedAt", typeof(String)));
            dt.Columns.Add(new DataColumn("AvailableSeat", typeof(Int32)));
        }

        private void FillTable()
        {
            dt.Rows.Add("jhgadjd", "20-May-2019", 0);
            dt.Rows.Add("regfhetuy", "28-May-2019", 15);
            dt.Rows.Add("rtsvxfg", "27-May-2019", 10);
            dt.Rows.Add("dhdgcv", "15-May-2019", 60);
            dt.Rows.Add("wrweref", "01-Jun-2019", 5);
            dt.Rows.Add("mmhbdfxb", "05-May-2019", 2);
            dt.Rows.Add("idhfk", "11-May-2019", 8);
            dt.Rows.Add("kjhsdkjfh", "03-Jul-2019", 10);
            dt.Rows.Add("msdkh", "19-Jun-2019", 0);
            dt.Rows.Add("jhgdsjf", "13-Apr-2019", 0);
            dt.Rows.Add("kjgsdjf", "12-Apr-2019", 12);
            dt.Rows.Add("jhgadjd", "20-May-2019", 0);
            dt.Rows.Add("regfhetuy", "28-May-2019", 15);
            dt.Rows.Add("rtsvxfg", "27-May-2019", 10);
            dt.Rows.Add("dhdgcv", "15-May-2019", 60);
            dt.Rows.Add("wrweref", "01-Jun-2019", 5);
            dt.Rows.Add("mmhbdfxb", "05-May-2019", 2);
            dt.Rows.Add("idhfk", "11-May-2019", 8);
            dt.Rows.Add("kjhsdkjfh", "03-Jul-2019", 10);
            dt.Rows.Add("msdkh", "19-Jun-2019", 0);
            dt.Rows.Add("jhgdsjf", "13-Apr-2019", 0);
            dt.Rows.Add("kjgsdjf", "12-Apr-2019", 10);

        }

        private void FilterData()
        {
            var first = dt.Select("AvailableSeat>0").AsEnumerable();
            var result = first.Min(r => Convert.ToDateTime(r.Field<string>("CreatedAt")));

            IOrderedEnumerable<DateTime> idr = dt.Rows.OfType<DataRow>().Select(k => Convert.ToDateTime(k["CreatedAt"])).OrderBy(k => k);

            var result1 = dt.AsEnumerable()
               .Select(cols => Convert.ToDateTime(cols.Field<string>("CreatedAt")))
               .OrderBy(p => p.Ticks);


            //var row = dt.AsEnumerable().Where(x => x.Field<int>("AvailableSeat") > 0).Select(x => (x.Field<string>("CreatedAt"), Row:x)).Min().Row;

            // Remove the 0 entries and sort them by date CreatedAt
            DataRow result2 = dt.AsEnumerable()
                            .Where(x => x.Field<int>("AvailableSeat") > 0)
                            .OrderBy(d => Convert.ToDateTime(d.Field<string>("CreatedAt")))
                            .FirstOrDefault();

        }
    }
}
