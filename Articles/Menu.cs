namespace Articles
{
    public class Menu
    {
        public void Start(Catalogue catalogue)
        {
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
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    choice = -1;
                }
                Console.Clear();

                switch (choice)
                {
                    case 1:

                        FindReference(catalogue);
                        break;
                    case 2:
                        //CreateArticle();
                        break;
                    case 3:
                        break;
                    case 4:
                        //Supermarket.UpdateArticle();
                        break;
                    case 5:
                        FindArticleName(catalogue);
                        break;
                    case 6:
                        //Supermarket.FindArticle();
                        break;
                    case 7:
                        //Supermarket.DisplayArticle();
                        break;
                    case 8:
                        break;
                    default:
                        break;
                }
            }
        }

        private void FindReference(Catalogue catalogue)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("       ---RECHERCHE---        ");
            Console.WriteLine("------------------------------\n");
            Console.Write("Référence de l'article : ");
            string stringReference = Console.ReadLine();


            while (!IsNumber(stringReference))
            {
                Console.WriteLine("Veuillez entre un nombre !\n");
                Console.Write("Référence de l'article : ");
                stringReference = Console.ReadLine();
            }
            int reference = Int32.Parse(stringReference);

            if (catalogue.IsReferenceInCatalogue(reference))
            {
                var requiredArticle = catalogue.Articles.Find(x => x.Reference == reference);
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine(requiredArticle.ToString());
                Console.WriteLine("------------------------------");
                Console.Write("Appuyez sur une touche pour revenir au menu");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Article non référencé");
                Console.WriteLine("------------------------------\n");
                Console.Write("Appuyez sur une touche pour revenir au menu");
                Console.ReadLine();
            }
        }

        private void FindArticleName(Catalogue catalogue)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("       ---RECHERCHE---        ");
            Console.WriteLine("------------------------------");
            Console.Write("Entrez un nom d'article : ");
            string articleName = Console.ReadLine().ToLower();

            if (catalogue.IsArticleNameInCatalogue(articleName))
            {
                var requiredArticle = catalogue.Articles.Find(x => x.ArticleName.ToLower() == articleName);
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine(requiredArticle.ToString());
                Console.WriteLine("------------------------------");
                Console.Write("Appuyez sur une touche pour revenir au menu");
                Console.ReadLine();
            }
            else
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Article non trouvé");
                Console.WriteLine("------------------------------\n");
                Console.Write("Appuyez sur une touche pour revenir au menu");
                Console.ReadLine();
            }
        }

        
    }
}
