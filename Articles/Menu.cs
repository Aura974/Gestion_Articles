namespace Articles
{
    public class Menu
    {
        /// <summary>
        /// Method to start the CLI for the desired catalogue
        /// </summary>
        /// <param name="catalogue"></param>
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
                        CreateArticle(catalogue);
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

        /// <summary>
        /// Searches catalogue for reference and displays article if found
        /// </summary>
        /// <param name="catalogue"></param>
        private void FindReference(Catalogue catalogue)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("       ---RECHERCHE---        ");
            Console.WriteLine("------------------------------\n");

            int reference = IsReference();

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

        /// <summary>
        /// Searches catalogue for article name and displays article if found
        /// </summary>
        /// <param name="catalogue"></param>
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

        /// <summary>
        /// Creates a new article and adds it to the stock
        /// </summary>
        /// <param name="catalogue"></param>
        private void CreateArticle(Catalogue catalogue) 
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("   ---AJOUTER UN ARTICLE---   ");
            Console.WriteLine("------------------------------\n");
            // Creating new object Article
            Article newArticle = new Article();

            // Getting name
            Console.Write("Nom de l'article : ");
            string articleName = Console.ReadLine();
            while (string.IsNullOrEmpty(articleName))
            {
                Console.Write("Veuillez entrer un nom d'article : ");
                articleName = Console.ReadLine();
            }

            // Getting unique reference
            Console.WriteLine("");
            int reference = IsReference();

            // Getting selling price
            Console.WriteLine("");
            decimal sellingPrice = IsSellingPrice();

            // Getting number of items (defaults to 1)
            Console.Write("\nNombre d'articles : ");
            string itemsNumber = Console.ReadLine();
            if(IsNumber(itemsNumber))
            {
                int noOfItems = Int32.Parse(itemsNumber);
                newArticle.NoOfITems = noOfItems;
            }
            else
            {
                Console.WriteLine("\n------------------------------"); 
                Console.WriteLine("Nombre d'articles incorrect.");
                Console.WriteLine("Un seul article a été ajouté.\n");
                Thread.Sleep(2000);
            }

            // Assigning values to object properties
            newArticle.ArticleName = articleName;

            if (catalogue.IsReferenceInCatalogue(reference))
            {
                int assignedReference = catalogue.AssignReference();
                newArticle.Reference = assignedReference;
                Console.WriteLine("\n------------------------------");
                Console.WriteLine("La référence existe déjà.");
                Console.WriteLine($"La nouvelle référence de l'article \"{articleName}\" sera : {assignedReference}.");
                Console.WriteLine("------------------------------\n");
                Thread.Sleep(3000);
            }
            else
            {
                newArticle.Reference = reference;
            }
            
            newArticle.SellingPrice = sellingPrice;

            // Adding to catalogue and stock
            catalogue.AddArticle(newArticle);

            Console.WriteLine("Article(s) ajouté(s) avec succès !");
            Console.WriteLine("Retour au menu...");
            Thread.Sleep(3000);

            


        }

        /// <summary>
        /// Checks if input is integer
        /// </summary>
        /// <param name="input">a string</param>
        /// <returns>a boolean</returns>
        private bool IsNumber(string input)
        {
            bool isNumber = int.TryParse(input, out _);

            return isNumber;
        }

        /// <summary>
        /// Checks if input is decimal
        /// </summary>
        /// <param name="input">a string</param>
        /// <returns>a boolean</returns>
        private bool IsDecimal(string input)
        {
            bool isNumber = decimal.TryParse(input, out _);

            return isNumber;
        }

        /// <summary>
        /// Checks if reference is a correct number
        /// </summary>
        /// <returns>an integer</returns>
        private int IsReference()
        {
            Console.Write("Référence de l'article : ");

            string stringReference = Console.ReadLine();

            while (!IsNumber(stringReference))
            {
                Console.WriteLine("Veuillez entre un nombre !\n");
                Console.Write("Référence de l'article : ");
                stringReference = Console.ReadLine();
            }
            int reference = Int32.Parse(stringReference);

            return reference;
        }

        /// <summary>
        /// Checks if selling price is a correct number
        /// </summary>
        /// <returns>a decimal</returns>
        private decimal IsSellingPrice()
        {
            Console.Write("Prix de l'article : ");

            string stringPrice = Console.ReadLine();

            while (!IsDecimal(stringPrice))
            {
                Console.WriteLine("Veuillez entre un nombre !\n");
                Console.Write("Prix de l'article : ");
                stringPrice = Console.ReadLine();
            }
            decimal sellingPrice = Decimal.Parse(stringPrice);

            return sellingPrice;
        }
    }
}
