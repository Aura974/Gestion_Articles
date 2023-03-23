namespace Articles
{
    /// <summary>
    /// Class defining an article
    /// </summary>
    public class Article
    {
        /// <summary>
        /// Article reference
        /// </summary>
        public int Reference { get; set; }
        /// <summary>
        /// Article name
        /// </summary>
        public string ArticleName { get; set; }
        /// <summary>
        /// Article selling price
        /// </summary>
        public decimal SellingPrice { get; set; }

        /// <summary>
        /// Number of the same articles to create (default to 1)
        /// </summary>
        public int NoOfITems { get; set; }

        // Constructor
        public Article()
        {
            NoOfITems = 1;
        }

        /// <summary>
        /// Overridden ToString() method to display an article
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return "Article : " + ArticleName + "\n" + "Référence : " + Reference + "\n" + "Prix : " + SellingPrice;
        }
    }
}
