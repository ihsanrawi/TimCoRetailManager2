using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Internal.Models;

namespace TRMDataManager.Controllers
{
    [Authorize]
    public class SaleController : ApiController
    {
        // POST: api/Sale
        [Authorize(Roles = "Cashier")]
        public void Post(SaleModel sale)
        {
            SaleData data = new SaleData();
            string userId = RequestContext.Principal.Identity.GetUserId();

            data.SaveSale(sale, userId);
        }

        // api/Sale/GetSalesReport
        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        public List<SaleReportModel> GetSalesReports()
        {
            SaleData data = new SaleData();
            return data.GetSaleReports();
        }
    }
}
