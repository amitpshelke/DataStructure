using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuance
{
    public class Newspaper
    {
        public string NewPaperTitle { get; set; }
        public List<Page> NewsPaperPages { get; set; }

        public void Execute(Page page)
        {
            NewsPaperPages = new List<Page>();
            NewsPaperPages.Add(page);
            Console.WriteLine(NewPaperTitle);

            foreach (var item in page.News)
                Console.WriteLine(item.NewsType.ToString() + " : " + item.Content);
            foreach(var item in page.Advertisements)
                Console.WriteLine("Advertisement : " + item.Content);
        }
    }
}
