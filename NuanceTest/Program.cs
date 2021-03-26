using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuance
{
    class Program
    {
        static void Main(string[] args)
        {
            INews n1 = NewsFactory.GenerateNews(1, NewsCategory.NationalPolitics, "Highest number of COVID cases in Maharastra", NewsType.Normal);
            INews n2 = NewsFactory.GenerateNews(1, NewsCategory.InternationalPolitics, "SAAB ready to export Gripen at higher price", NewsType.Normal);
            INews n3 = NewsFactory.GenerateNews(1, NewsCategory.Market, "Gold price increase by Rs 1000 per gram", NewsType.Normal);
            INews n4 = NewsFactory.GenerateNews(1, NewsCategory.Sports, "New Zealand won against England", NewsType.Normal);
            INews n5 = NewsFactory.GenerateNews(1, NewsCategory.Art, "Filmfare award tonight", NewsType.Normal);
            INews n6 = NewsFactory.GenerateNews(1, NewsCategory.Travel, "Singapore started cheap flights for next two months", NewsType.Normal);

            Advertisement a1 = new Advertisement("Fevicol Ad");
            Advertisement a2 = new Advertisement("Surf Excel Ad");
            Advertisement a3 = new Advertisement("Tata Motors Ad"); //trying to ad extra item

            INews n7 = NewsFactory.GenerateNews(2, NewsCategory.NationalPolitics, "PM is going to address the nation today at 9:30 PM", NewsType.Emergency); //high Priority News Item
            INews n8 = NewsFactory.GenerateNews(2, NewsCategory.InternationalPolitics, "Covid 19 had outbreak, World anncounce lockdown", NewsType.Emergency); //high Priority News Item




            Page p = new Page();
            p.AddNews(n1);
            p.AddNews(n2);
            p.AddNews(n3);
            p.AddNews(n4);
            p.AddNews(n5);
            p.AddNews(n6);

            p.AddAdvertisement(a1);
            p.AddAdvertisement(a2);
            p.AddAdvertisement(a3);  //trying to add one more Ad

            p.AddNews(n7);  //trying to more news on same page
            p.AddNews(n8);  //trying to more news on same page


            Newspaper np = new Newspaper();
            np.NewPaperTitle = "The Times";
            np.Execute(p);

        }
    }
}
