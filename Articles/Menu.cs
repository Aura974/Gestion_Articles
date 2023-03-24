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
                        RemoveArticle(catalogue);
                        break;
                    case 4:
                        UpdateArticle(catalogue);
                        break;
                    case 5:
                        FindArticleName(catalogue);
                        break;
                    case 6:
                        FindArticlesPriceRange(catalogue);
                        break;
                    case 7:
                        DisplayAllArticles(catalogue);
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
                var requestedArticle = catalogue.Articles.Find(x => x.Reference == reference);
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine(requestedArticle.ToString());
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
                var requestedArticle = catalogue.Articles.Find(x => x.ArticleName.ToLower() == articleName);
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine(requestedArticle.ToString());
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
            decimal sellingPrice = IsSellingPrice("Prix de l'article");

            // Getting number of items (defaults to 1)
            Console.Write("\nNombre d'articles : ");
            string itemsNumber = Console.ReadLine();
            if(IsNumber(itemsNumber))
            {
                int noOfItems = Int32.Parse(itemsNumber);
                newArticle.NoOfItems = noOfItems;
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
        private decimal IsSellingPrice(string field)
        {
            Console.Write($"{field} : ");

            string stringPrice = Console.ReadLine();

            while (!IsDecimal(stringPrice))
            {
                Console.WriteLine("Veuillez entre un nombre !\n");
                Console.Write($"{field} : ");
                stringPrice = Console.ReadLine();
            }
            decimal sellingPrice = Decimal.Parse(stringPrice);

            return sellingPrice;
        }

        /// <summary>
        /// Checks if article exists 
        /// then calls on the delete method 
        /// to remove it from catalogue and stock
        /// </summary>
        /// <param name="catalogue"></param>
        private void RemoveArticle(Catalogue catalogue)
        {
            int reference = IsReference();

            if (catalogue.IsReferenceInCatalogue(reference))
            {
                var requestedArticle = catalogue.Articles.Find(x => x.Reference == reference);

                catalogue.DeleteArticle(requestedArticle);
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Article supprimé avec succès !");
                Console.WriteLine("------------------------------");
                Thread.Sleep(3000);
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
        /// Updates one property of an article found by reference
        /// </summary>
        /// <param name="catalogue"></param>
        private void UpdateArticle(Catalogue catalogue)
        {
            int choice = -1;
            Console.WriteLine("------------------------------");
            int reference = IsReference();
            Article oldArticle = new Article();

            if (catalogue.IsReferenceInCatalogue(reference))
            {
                oldArticle = catalogue.Articles.Find(x => x.Reference == reference);
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("  --- MODIFIER UN ARTICLE --- ");
                Console.WriteLine("------------------------------\n");
                Console.WriteLine(oldArticle.ToString());
                Console.WriteLine("------------------------------");
            }
            else
            {
                Console.Clear();
                Console.WriteLine("------------------------------");
                Console.WriteLine("Article non référencé");
                Console.WriteLine("------------------------------");
                Console.WriteLine("Retour au menu...");
                Thread.Sleep(3000);
            }


            while (choice != 0)
            {
                Console.WriteLine("\n Que souhaitez-vous modifier ?\n");
                Console.WriteLine("(1) Nom de l'article");
                Console.WriteLine("(2) Référence");
                Console.WriteLine("(3) Prix");
                Console.WriteLine("(4) Nombre d'articles");
                Console.WriteLine("(0) Retour au menu principal");
                Console.Write("\nChoix : ");
                try
                {
                    choice = Int32.Parse(Console.ReadLine());
                }
                catch (FormatException)
                {
                    choice = -1;
                }

                switch (choice)
                {
                    case 1:
                        // Getting name
                        Console.Write("\nNom de l'article : ");
                        string newArticleName = Console.ReadLine();
                        while (string.IsNullOrEmpty(newArticleName))
                        {
                            Console.Write("Veuillez entrer un nom d'article : ");
                            newArticleName = Console.ReadLine();
                        }
                        oldArticle.ArticleName = newArticleName;
                        DisplaySuccess(oldArticle, "nom");
                        choice = 0;
                        break;

                    case 2:
                        // Getting unique reference
                        Console.WriteLine();
                        int newReference = IsReference();
                        if (catalogue.IsReferenceInCatalogue(newReference))
                        {
                            Console.WriteLine("\nLa référence existe déjà.");
                            Console.WriteLine("------------------------------\n");
                        }
                        else
                        {
                            oldArticle.Reference = newReference;
                            DisplaySuccess(oldArticle, "référence");
                            choice = 0;
                        }
                        break;

                    case 3:
                        // Getting selling price
                        decimal newSellingPrice = IsSellingPrice("Nouveau prix");
                        oldArticle.SellingPrice = newSellingPrice;
                        DisplaySuccess(oldArticle, "prix");
                        choice = 0;
                        break;

                    case 4:
                        // Getting number of items (defaults to 1)
                        Console.Write("\nNombre d'articles : ");
                        string newItemsNumber = Console.ReadLine();
                        if (IsNumber(newItemsNumber))
                        {
                            int noOfItems = Int32.Parse(newItemsNumber);
                            catalogue.TotalStock -= oldArticle.NoOfItems;
                            oldArticle.NoOfItems = noOfItems;
                            catalogue.TotalStock += oldArticle.NoOfItems;

                            DisplaySuccess(oldArticle, "nombre d'articles");
                            choice = 0;
                        }
                        else
                        {
                            Console.WriteLine("\n------------------------------");
                            Console.WriteLine("Nombre d'articles incorrect.");
                            Console.WriteLine("------------------------------\n");
                            Thread.Sleep(2000);
                            choice = 0;
                        }
                        break;
                    default:
                        break;
                }


            }
        }

        /// <summary>
        /// Displays the successful message of update of an article
        /// </summary>
        /// <param name="article">the object of type Article to display</param>
        /// <param name="field">the string field that was modified</param>
        public void DisplaySuccess(Article article, string field)
        {
            Console.Clear();
            if (field == "référence")
            {
                Console.WriteLine($"\nLa {field} a été modifiée avec succès !");
            }
            else
            {
                Console.WriteLine($"\nLe {field} a été modifié avec succès !");
            }
            Console.WriteLine("Nouvel article : ");
            Console.WriteLine("\n------------------------------");
            Console.WriteLine(article.ToString());
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Retour au menu...");
            Thread.Sleep(3000);
        }

        /// <summary>
        /// Finds and displays all articles within a price range
        /// </summary>
        /// <param name="catalogue"></param>
        public void FindArticlesPriceRange(Catalogue catalogue)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine(" --AFFICHER LISTE D'ARTICLES--");
            Console.WriteLine("------------------------------\n");

            Console.WriteLine("Afficher les articles compris entre...\n");
            decimal priceMin = IsSellingPrice("Prix mini");
            Console.WriteLine("\n... et\n");
            decimal priceMax = IsSellingPrice("Prix maxi");
            Console.WriteLine("------------------------------\n");


            List<Article> articles = catalogue.ListArticlesPriceRange(priceMin, priceMax);

            if (articles.Count > 0)
            {
                foreach (Article article in articles)
                {
                    Console.WriteLine(article.ToString());
                    Console.WriteLine("------------------------------\n");
                }
                Console.Write("Appuyez sur une touche pour revenir au menu");
                Console.ReadLine();
            }

            
        }

        public void DisplayAllArticles(Catalogue catalogue)
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("    ---LISTE D'ARTICLES---    ");
            Console.WriteLine("------------------------------\n");

            foreach (Article article in catalogue.Articles)
            {
                Console.WriteLine(article.ToString());
                Console.WriteLine("------------------------------\n");
            }
            Console.Write("Appuyez sur une touche pour revenir au menu");
            Console.ReadLine();
        }
    }
}
