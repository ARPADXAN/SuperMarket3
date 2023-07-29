using SuperMarket.BaseModel;
using System.Reflection;
using SuperMarket3;

public class Program
{
    static void Main(string[] args)
    {
        ChoiceFunction();

    }
    public static void ChoiceFunction()
    {
        var supermarkets = new List<Supermarket>();
        var supermarket = new Supermarket();
        var products = new List<Product>();
        var product = new Product();
        var resultString = new Result<string>();
        var resultNumber = new Result<int>();

        bool menuList = false;

        do
        {
            Console.WriteLine("1 Add SuperMarket");
            Console.WriteLine("2 Show Product");
            string inputChoice = Console.ReadLine();
            bool isFinish = true;
            bool choiceFunc = true;
            switch (inputChoice)
            {
                case "1":

                    while (choiceFunc)
                    {
                        int id = 1;
                        Console.WriteLine("Please Enter Name of SuperMarket");
                        var resultAddName = supermarket.AddName(Console.ReadLine());
                        supermarket.Id += id;
                        if (!resultAddName.IsSuccess)
                        {
                            Console.WriteLine(resultAddName.Message);
                            Console.ReadLine();
                            break;
                        }
                        supermarket.Name = resultAddName.Data;
                        Console.WriteLine("Please Enter Address of SuperMarket");

                        var resultAddAddress = supermarket.AddAddress(Console.ReadLine());
                        if (!resultAddName.IsSuccess)
                        {
                            Console.WriteLine(resultAddAddress.Message);
                            break;
                        }
                        supermarket.Address = resultAddAddress.Data;
                        supermarkets.Add(supermarket);
                        Console.WriteLine("Please Enter Name Of product for add this SuperMarket");

                        var resultAddProduct = supermarket.AddProduct(Console.ReadLine(), supermarket.Id);
                        if (!resultAddProduct.IsSuccess)
                        {
                            Console.WriteLine(resultAddAddress.Message);
                            break;
                        }
                        Console.WriteLine(resultAddProduct.Data);
                        supermarket.products = resultAddProduct.Data;
                        Console.WriteLine("For Add More SuperMarket Press Y key otherwise Press Any key for next Function");
                        choiceFunc = (Console.ReadKey(true).Key.ToString().ToLower() == "y");
                        //if (choiceFunc is false)
                        //{
                        //    Console.WriteLine("For Add Product Press Y key otherwise Press Any key for List Menu");
                        //    isFinish = (Console.ReadKey(true).Key.ToString().ToLower() == "y");
                        //    menuList = true;
                        //}


                    }


                    break;

                case "2":
                    Console.WriteLine("///////////////////////List All SuperMarket\\\\\\\\\\\\\\\\\\\\\\\\");
                    foreach (var item in supermarkets)
                    {
                        Console.WriteLine(item.Name + "\n" + "Id: " + item.Id + " | Address :" + item.Address);
                        Console.WriteLine(
                            "====================================================================================");
                    }
                    Console.WriteLine("///////////////////////List All Product/////////////////////////////////////");

                    foreach (var item in products)
                    {
                        Console.WriteLine(item.Name + "\n" + "Id: " + item.Id + " | Price :" + item.Price +
                                          " | Count :" + item.Count + (item.Nofication ? " Product is Finishing" : ""));
                        Console.WriteLine(
                            "====================================================================================");
                    }

                    Console.ReadLine();
                    Console.WriteLine("If return to Menu please type Y otherwise type any key ");
                    menuList = (Console.ReadKey(true).Key.ToString().ToLower() == "y");
                    break;
                default:
                    Console.WriteLine("Your Choice not Correct");
                    break;
            }

        } while (menuList != false);
    }
}