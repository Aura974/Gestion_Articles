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
            this.TotalStock += article.NoOfItems;
        }
        
        /// <summary>
        /// Deletes article from list and stock
        /// </summary>
        public void DeleteArticle(Article article)
        {
            this.TotalStock -= article.NoOfItems; 
            this.Articles.Remove(article);
            
        }

        /// <summary>
        /// Searches catalogue for reference
        /// </summary>
        /// <param name="reference">an integer</param>
        /// <returns>a boolean</returns>
        public bool IsReferenceInCatalogue(int reference)
        {
            bool foundReference = this.Articles.Any(x => x.Reference == reference);

            return foundReference;
        }

        /// <summary>
        /// Searches catalogue for article name
        /// </summary>
        /// <param name="articleName">a string</param>
        /// <returns>a boolean</returns>
        public bool IsArticleNameInCatalogue(string articleName)
        {
            bool foundArticleName = this.Articles.Any(x => x.ArticleName.ToLower() == articleName);

            return foundArticleName;
        }

        /// <summary>
        /// Finds all articles within a price range
        /// </summary>
        /// <param name="priceMin">minimum price</param>
        /// <param name="priceMax">maximum price</param>
        /// <returns>a list of articles</returns>
        public List<Article> ListArticlesPriceRange(decimal priceMin, decimal priceMax) 
        {
            List<Article> articles = new List<Article>();

            foreach (Article article in this.Articles)
            {
                if (article.SellingPrice <= priceMax && article.SellingPrice >= priceMin)
                {
                    articles.Add(article);
                }
            }

            return articles;
        }

        /// <summary>
        /// Returns a unique reference to assign to new article
        /// </summary>
        /// <returns>an integer</returns>
        public int AssignReference()
        {
            int maxReference = this.Articles.Max(x => x.Reference);
            int newReference = maxReference + 1;

            return newReference;
        }

    }
}
