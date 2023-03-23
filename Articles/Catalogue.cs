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
        public int TotalStock { get; set; }

        /// <summary>
        /// Adds article to list and increments the stock
        /// </summary>
        /// <param name="article"></param>
        public void AddArticle(Article article)
        {
            this.Articles.Add(article);
            this.TotalStock += article.NoOfITems;
        }

        /// <summary>
        /// Updates one article from list
        /// </summary>
        public void UpdateArticle()
        {

        }

        /// <summary>
        /// Searches catalogue for reference
        /// </summary>
        /// <param name="reference">an integer</param>
        /// <returns>a boolean</returns>
        public bool IsReferenceInCatalogue(int reference)
        {
            bool foundReference = Articles.Any(x => x.Reference == reference);

            return foundReference;
        }

        /// <summary>
        /// Searches catalogue for article name
        /// </summary>
        /// <param name="articleName">a string</param>
        /// <returns>a boolean</returns>
        public bool IsArticleNameInCatalogue(string articleName)
        {
            bool foundArticleName = Articles.Any(x => x.ArticleName.ToLower() == articleName);

            return foundArticleName;
        }

        

        public int AssignReference()
        {
            int maxReference = Articles.Max(x => x.Reference);
            int newReference = maxReference + 1;

            return newReference;
        }

        /// <summary>
        /// Deletes article from list
        /// </summary>


    }
}
