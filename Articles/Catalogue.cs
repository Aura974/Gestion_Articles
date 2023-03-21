namespace Articles
{
    /// <summary>
    /// Class defining the shop inventory
    /// </summary>
    public class Catalogue
    {
        /// <summary>
        /// List of all articles 
        /// </summary>
        public List<Article> Articles { get; set; }

        public void AddArticle()
        {

        }

        public void UpdateArticle() 
        { 

        }

        public bool IsArticleInCatalogue(int reference)
        {
            foreach (var article in Articles)
            {
                if (article.Reference == reference)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteArticle()
        {

        }
    }
}
