using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Linq;

namespace SNobleCSharpProject
{
    public class AppTaskManager
    {
        public void InitPrompt()
        {
            //Greeting message briefly explaining app and origin of data used.
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Welcome to the Intrepid Sojourner Beer Project (ISBP)");
            Console.WriteLine(" Product Mix Report Application!");
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" ISBP is a brewery located in Denver, CO. The product mix report pertains");
            Console.WriteLine(" to their taproom sales. The purpose of the application is to quickly pull");
            Console.WriteLine(" key information from the spreadsheet, such as top-selling, or non-selling");
            Console.WriteLine(" items, to aid decision-making in the business. Cheers!");
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("");
            Console.WriteLine("[--------------------------------------------------------------------------]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" Press <ENTER> to continue to the application.");
            Console.WriteLine("");
            Console.ResetColor();
            Console.ReadLine();
        }

        static public void MainMenu()
        {
            bool isDone = false;

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            string csvFilePath = Path.Combine(directory.FullName, "ProductMixOneWeek.csv");
            string filePath = CsvReader.ReadFile(csvFilePath);

            CsvReader reader = new CsvReader(csvFilePath);

            List<Product> products = reader.ReadProductMix(csvFilePath);

            while (!isDone)
            {
                //Main Menu
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(4, 10);
                Console.WriteLine(" MAIN MENU");
                Console.ResetColor();
                Console.WriteLine();
                Console.SetCursorPosition(15, 11);
                Console.WriteLine("[1] See All Products");
                Console.SetCursorPosition(15, 12);
                Console.WriteLine("[2] Add Product to Mix");
                Console.SetCursorPosition(15, 13);
                Console.WriteLine("[3] Remove Product from Mix");
                Console.SetCursorPosition(15, 14);
                Console.WriteLine("[4] Exit Application");
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Enter your choice from the above menu: ");
                Console.ResetColor();
                var userInput = Console.ReadLine();

                if (Convert.ToInt32(userInput) == 4)
                {
                    Console.WriteLine("Thank you.  Have a nice day!");
                    isDone = true;
                }
                else if ((Convert.ToInt32(userInput) > 4) || (Convert.ToInt32(userInput) < 1))
                {
                    Console.WriteLine("Please enter valid option (1-4).");
                }
                else if (Convert.ToInt32(userInput) == 1)
                {
                    Console.WriteLine("[-----------------------------------------------------------------------------]");
                    // Formatting columns
                    Console.WriteLine("{0,-3} {1,-35} {2,20} {3, 20}\n", "ID#", "Product Name", "Category", "Subcategory");
                    for (int x = 0; x < products.Count; x++)
                    {
                        Console.WriteLine("{0,-3} {1,-35} {2,20} {3, 20}", x, products[x].prodName, products[x].prodCategory, products[x].prodSubcategory);
                    }
                    Console.WriteLine("[-----------------------------------------------------------------------------]");
                    Console.WriteLine("Press any key to go back to the Main Menu.");
                    Console.ReadKey();
                    Console.Clear();
                }
                else if (Convert.ToInt32(userInput) == 2)
                {
                    while (true)
                    {
                        //Create a product and write it to file.
                        Console.Clear();
                        var newProd = new Product();
                        Console.WriteLine("[--------------------------------------------------------------------------]");
                        Console.WriteLine("***  ADDING NEW PRODUCT  ***");

                        //Sets Name of new product
                        Console.WriteLine("What is the name of the product? ");
                        string ProdName = Console.ReadLine();

                        //Sets Category of new product
                        Console.WriteLine("Category - <D>rinks, <M>erchandise, or <S>nacks? ");
                        var prodCatInput = Console.ReadKey();
                        bool prodCatOption = true;
                        string ProdCategory = "";

                        while (prodCatOption)
                        {
                            switch (prodCatInput.Key)
                            {
                                case ConsoleKey.D:
                                    ProdCategory = "Drinks";
                                    prodCatOption = false;
                                    break;
                                case ConsoleKey.M:
                                    ProdCategory = "Merchandise";
                                    prodCatOption = false;
                                    break;
                                case ConsoleKey.S:
                                    ProdCategory = "Snacks";
                                    prodCatOption = false;
                                    break;
                                default:
                                    Console.WriteLine("  -  Category unknown");
                                    prodCatOption = false;
                                    break;
                            };

                        }
                        Console.ReadLine();

                        //Sets subcategory of new product
                        Console.WriteLine("Subcategory (drink oz., type of merch., type of snack)? ");
                        string ProdSubcategory = Console.ReadLine();

                        // Confirming addition of product.
                        Console.WriteLine("Are you sure you want to add this product?\n" + "<Y>es, <B>ack; Any other key restarts this process");
                        var confirmInput = Console.ReadKey();

                        newProd.prodName = ProdName;
                        newProd.prodCategory = ProdCategory;
                        newProd.prodSubcategory = ProdSubcategory;


                        if (confirmInput.Key == ConsoleKey.Y)
                        {
                            Console.Clear();
                            products.Add(newProd);
                            CsvReader.FileWrite(products);
                            break;
                        }
                        Console.Clear();
                        if (confirmInput.Key == ConsoleKey.B)
                        {
                            MainMenu();
                        }
                    }
                }

                else if (Convert.ToInt32(userInput) == 3)
                {

                    Console.WriteLine("{0,-3} {1,-35}\n", "ID#", "Product Name");
                    for (int j = 0; j < products.Count; j++)
                    {
                        Console.WriteLine("{0,-3} {1,-35}", j, products[j].prodName);
                    }
                    Console.WriteLine("[-----------------------------------------------------------------------------]");
                    Console.WriteLine("What is the ID# of the product you wish to remove?");
                    var idxRemove = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine(products[Convert.ToInt32(idxRemove)].prodName);
                    Console.WriteLine("Are you sure? <Y>es, any other key quits the action.");
                    var deleteInput = Console.ReadKey();
                    if (deleteInput.Key == ConsoleKey.Y)
                    {
                        products.RemoveAt(Convert.ToInt32(idxRemove));
                        CsvReader.FileWrite(products);
                        if (Convert.ToInt32(idxRemove) <= products.Count)
                        {
                            idxRemove--;
                        }
                        Console.WriteLine("   Product has been removed!");
                        Console.ReadKey();
                    }
                }
            }
        }
    }
}
