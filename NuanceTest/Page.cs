using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nuance
{
    public class Page
    {
        private List<INews> news = new List<INews>();
        private List<Advertisement> advertisements = new List<Advertisement>();

        public List<INews> News
        {
            get { return news; }
            private set {  }
        }

        public List<Advertisement> Advertisements
        {
            get { return advertisements; }
            private set { }
        }


        public void AddNews(INews n)
        {
            if ((news.Count + advertisements.Count) <= 7)
            {
                news.Add(n);
            }
            else
            {
                if (n.NewsType == NewsType.Emergency && news.Count <= 7)
                {
                    news.Add(n);
                    advertisements.RemoveAt(0);
                }
            }
        }

        public void AddAdvertisement(Advertisement a)
        {
            if (news.Count <= 6 && (news.Count + advertisements.Count) <= 7)
            {
                advertisements.Add(a);
            }
        }

    }
}
