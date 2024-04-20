using BE2024.DataAccess.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE2024.DataAccess.Layers
{
    internal interface IProductManager
    {
        ReturnData BuyProduct(Product product);
    }
}
