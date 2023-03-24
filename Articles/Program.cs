namespace Articles
{
    public class Program
    {
        /// <summary>
        /// Articles stock
        /// </summary>
        private static Catalogue Supermarket = new Catalogue();
        /// <summary>
        /// Menu to browse the stock
        /// </summary>
        private static Menu Menu = new Menu();

        public static void Main(string[] args)
        {
            // Encoding so the console shows the currency symbol
            Console.OutputEncoding = System.Text.Encoding.Unicode;

            // Creating new articles and adding them to catalogue
            Supermarket.Articles = new List<Article>();
            Article beer = new Article();
            Article wine = new Article();
            Article rum = new Article();
            Article gin = new Article();

            beer.ArticleName = "Dodo";
            beer.Reference = 1;
            beer.SellingPrice = 1.5m;
            Supermarket.Articles.Add(beer);

            wine.ArticleName = "Mouton Cadet 2019";
            wine.Reference = 2;
            wine.SellingPrice = 16.95m;
            Supermarket.Articles.Add(wine);

            rum.ArticleName = "Charrette";
            rum.Reference = 3;
            rum.SellingPrice = 10.95m;
            Supermarket.Articles.Add(rum);

            gin.ArticleName = "Tanqueray";
            gin.Reference = 4;
            gin.SellingPrice = 26.9m;
            Supermarket.Articles.Add(gin);

            // Starting the catalogue menu
            Menu.Start(Supermarket);

        }
    }
}
