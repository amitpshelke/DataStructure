using System.Collections.Generic;

namespace Nuance
{
    public interface INews
    {
        NewsCategory NewsCategory { get; set; }
        string Content { get; set; }
        NewsType NewsType { get; set; }
    }



    public class NewsFactory
    {
        public static INews GenerateNews(int News, NewsCategory newsCategory, string Content, NewsType NewsType)
        {
            INews inews = null;

            switch (News)
            {
                case 1: { inews = new InternalNews(newsCategory, Content, NewsType); break; }
                case 2: { inews = new ExternalNews(newsCategory, Content, NewsType); break; }
            }

            return inews;
        }
    }



    public class InternalNews : INews
    {
        private NewsCategory _newsCategory = new NewsCategory();
        private string _content = string.Empty;
        private NewsType _newsType = new NewsType();

        public InternalNews(NewsCategory newsCategory, string Content, NewsType newsType)
        {
            _newsCategory = newsCategory;
            _content = Content;
            _newsType = newsType;
        }

        public NewsCategory NewsCategory
        {
            get { return _newsCategory; }
            set { _newsCategory = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public NewsType NewsType
        {
            get { return _newsType; }
            set { _newsType = value; }
        }
    }

    public class ExternalNews : INews
    {
        private NewsCategory _newsCategory = new NewsCategory();
        private string _content = string.Empty;
        private NewsType _newsType = new NewsType();

        public ExternalNews(NewsCategory newsCategory, string Content, NewsType newsType)
        {
            _newsCategory = newsCategory;
            _content = Content;
            _newsType = newsType;
        }

        public NewsCategory NewsCategory
        {
            get { return _newsCategory; }
            set { _newsCategory = value; }
        }
        public string Content
        {
            get { return _content; }
            set { _content = value; }
        }
        public NewsType NewsType
        {
            get { return _newsType; }
            set { _newsType = value; }
        }
    }
    


    public enum NewsCategory
    {
        NationalPolitics = 0,
        InternationalPolitics = 1,
        Sports = 2,
        Travel = 3,
        Market = 4,
        Art = 5
    }

    public enum NewsType
    {
        Normal = 0,
        Emergency = 1
    }
}
