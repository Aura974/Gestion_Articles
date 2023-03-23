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

        public void AddArticle(Article article)
        {
            this.Articles.Add(article);
            this.TotalStock += article.NoOfITems;
        }

        public void UpdateArticle()
        {

        }
        public bool IsReferenceInCatalogue(int reference)
        {
            bool foundReference = Articles.Any(x => x.Reference == reference);

            return foundReference;
        }

        public bool IsArticleNameInCatalogue(string articleName)
        {
            bool foundArticleName = Articles.Any(x => x.ArticleName.ToLower() == articleName);

            return foundArticleName;
        }

        public void DeleteArticle()
        {

        }

    }
}
