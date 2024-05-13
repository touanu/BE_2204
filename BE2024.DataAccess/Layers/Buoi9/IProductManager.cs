using CommonLibs;

namespace BE2024.DataAccess.Layers
{
    internal interface IProductManager
    {
        ReturnData BuyProduct(string productID, int buyQuantity);
    }
}
