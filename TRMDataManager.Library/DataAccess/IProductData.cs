using System.Collections.Generic;
using TRMDataManager.Library.Internal.Models;

namespace TRMDataManager.Library.DataAccess
{
    public interface IProductData
    {
        List<ProductModel> GetAllProduct();
        ProductModel GetProductById(int productId);
    }
}