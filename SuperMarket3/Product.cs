using SuperMarket.BaseModel;

namespace SuperMarket3;

public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public Supermarket Supermarket { get; set; }
    public int SupermarketId { get; set; }
    public bool Nofication { get; set; }

    public Result<string> AddName(string name,int supermarket)
    {
        if (name.Any(p => char.IsDigit(p)) && name == "")
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

    public Result<int> AddPrice(string price)
    {
        int result;
        if (int.TryParse(price, out result))
        {

            Price = result;
            return new Result<int>
            {
                Data = result,
                IsSuccess = true,
                Message = Message.Fail
            };
        }

        return new Result<int>
        {
            IsSuccess = false,
            Message = Message.Fail
        };
    }

    public Result<int> AddCount(string count)
    {
        int result;
        if (int.TryParse(count, out result))
        {

            Count = result;
            if (result < 3)
            {
                Nofication = true;
                return new Result<int>
                {
                    Data = result,
                    IsSuccess = true,
                    Message = Message.CountProduct
                };
            }

            Nofication = false;
            return new Result<int>
            {
                Data = result,
                IsSuccess = true,
                Message = Message.Success
            };
        }

        return new Result<int>
        {
            IsSuccess = false,
            Message = Message.Fail
        };
    }
}