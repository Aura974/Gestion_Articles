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


            int choice = -1;

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
                Console.WriteLine("(0) Quitter\n");
                Console.Write("Choix : ");
                choice = Int32.Parse(Console.ReadLine());
                Console.Clear();

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
                    /*case 4:
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
                        break;*/
                    default:
                        break;
                }
            }
        }

        public static void FindArticle()
        {
            Console.WriteLine("------------------------------"); 
            Console.Write("Entrez une référence : ");
            
            try
            {
                int reference = Int32.Parse(Console.ReadLine());

                Console.WriteLine(Supermarket.IsArticleInCatalogue(reference));
                Console.WriteLine("------------------------------\n");
                Console.Write("Appuyez sur une touche pour revenir au menu");
                Console.ReadLine();

            }
            catch (FormatException)
            {
                Console.Write("Veuillez entrer un nombre !");
                Console.WriteLine("------------------------------\n");
                Console.ReadLine();
            }
        }

    }
}
