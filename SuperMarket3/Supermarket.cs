using SuperMarket.BaseModel;

namespace SuperMarket3
{
    public class Supermarket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public ICollection<Product> products { get; set; }

        public Supermarket()
        {

        }

        public Result<string> AddName(string name)
        {

            if (name.Any(p => char.IsDigit(p)) || name == "")
            {
                return new Result<string>
                {

                    IsSuccess = false,
                    Message = Message.Fail
                };
            }
            Name = name;
            return new Result<string>
            {
                Data = Name,
                IsSuccess = true,
                Message = Message.Success
            };
        }

        public Result<string> AddAddress(string address)
        {
            if (address.Any(p => char.IsDigit(p)) && address == "")
            {

                return new Result<string>
                {
                    IsSuccess = false,
                    Message = Message.Fail
                };
            }
            Address = address;
            return new Result<string>
            {
                Data = address,
                IsSuccess = true,
                Message = Message.Success
            };
        }

        public Result<ICollection<Product>> AddProduct(string productName ,int supermarketId)
        {
            var resultString = new Result<string>();
            var resultNumber = new Result<int>();
            Product product = new Product();

            var resultAddNameProduct = product.AddName(productName, supermarketId);
            if (!resultAddNameProduct.IsSuccess)
            {
                Console.WriteLine(resultAddNameProduct.Message);
            }
            Console.WriteLine("Please Enter Price of Product");
            resultNumber = product.AddPrice(Console.ReadLine());
            if (!resultNumber.IsSuccess)
            {
                Console.WriteLine(resultNumber.Message);
            }

            product.Price = resultNumber.Data;
            Console.WriteLine("Please Enter Count of Product");
            resultNumber = product.AddCount(Console.ReadLine());
            if (!resultNumber.IsSuccess)
            {
                Console.WriteLine(resultNumber.Message);
            }

            if (resultNumber.Data < 5)
            {
                product.Nofication = true;
            }
            product.Count = resultNumber.Data;
            Console.WriteLine(resultNumber.Message);
            products.Add(product);
            return new Result<ICollection<Product>>
            {
                IsSuccess = true,
                Data = products,
                Message = Message.Success,
            };
        }
    }
}
