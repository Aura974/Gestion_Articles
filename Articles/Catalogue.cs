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

        public string IsArticleInCatalogue(int reference)
        {
            var foundArticle = this.Articles.Find(x => x.Reference == reference);
            
            if (foundArticle == null)
            {
                return "Article non référencé";
            }
            return foundArticle.ToString();
        }

        public void DeleteArticle()
        {

        }
    }
}
