namespace Articles
{
    public class Program
    {
        /// <summary>
        /// Articles stock
        /// </summary>
        private static Catalogue Supermarket = new Catalogue();

        public static void Main(string[] args)
        {
            List<Article> articles = Supermarket.Articles;
            Article beer = new Article();
            Article wine = new Article();
            Article rum = new Article();
            Article gin = new Article();

            beer.ArticleName = "Dodo";
            beer.Reference = 1;
            beer.SellingPrice = 1.5m;
            articles.Add(beer);

            wine.ArticleName = "Mouton Cadet 2019";
            wine.Reference = 2;
            wine.SellingPrice = 16.95m;
            articles.Add(wine);

            rum.ArticleName = "Charrette";
            rum.Reference = 3;
            rum.SellingPrice = 10.95m;
            articles.Add(rum);

            gin.ArticleName = "Tanqueray";
            gin.Reference = 4;
            gin.SellingPrice = 26.9m;
            articles.Add(gin);


            int choice = 0;

            while (choice != 0)
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("      --- BIENVENUE ---       ");
                Console.WriteLine("------------------------------\n");
                Console.WriteLine("(1) Rechercher un article par référence");
                Console.WriteLine("(2) Ajouter un article au stock");
                Console.WriteLine("(3) Supprimer un article par référence");
                Console.WriteLine("(4) Modifier un article par référence");
                Console.WriteLine("(5) Rechercher un article par nom");
                Console.WriteLine("(6) Rechercher un article par prix de vente");
                Console.WriteLine("(7) Afficher tous les articles");
                Console.WriteLine("(8) Quitter\n");
                Console.Write("Choix : ");
                choice = Int32.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        FindArticle();
                        break;
                    case 2:
                        Supermarket.AddArticle();
                        break;
                    case 3:
                        Supermarket.DeleteArticle();
                        break;
                    case 4:
                        Supermarket.UpdateArticle();
                        break;
                    case 5:
                        Supermarket.FindArticle();
                        break;
                    case 6:
                        Supermarket.FindArticle();
                        break;
                    case 7:
                        Supermarket.DisplayArticle();
                        break;
                    case 8:
                        break;
                    default:
                        break;
                }
            }
        }
        public Article FindArticle()
        {
            Console.Write("Entrez une référence : ");
            Console.WriteLine("--------------------")
            try
            {
                int reference = Int32.Parse(Console.ReadLine());
                foreach (var article in Supermarket.Articles)
                {
                    if (Supermarket.IsArticleInCatalogue(reference))
                    {
                        Console.WriteLine($)
                    }
                }
            }
        }

    }
}
