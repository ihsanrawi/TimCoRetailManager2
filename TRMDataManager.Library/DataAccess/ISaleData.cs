using System.Collections.Generic;
using TRMDataManager.Library.Internal.Models;

namespace TRMDataManager.Library.DataAccess
{
    public interface ISaleData
    {
        List<SaleReportModel> GetSaleReports();
        decimal GetTaxRate();
        void SaveSale(SaleModel saleInfo, string cashierId);
    }
}