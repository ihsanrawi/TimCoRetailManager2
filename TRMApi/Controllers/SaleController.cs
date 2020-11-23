using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TRMDataManager.Library.DataAccess;
using TRMDataManager.Library.Internal.Models;

namespace TRMApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SaleController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ISaleData _saleData;

        public SaleController(IConfiguration config, ISaleData saleData)
        {
            _config = config;
            _saleData = saleData;
        }

        // POST: api/Sale
        [Authorize(Roles = "Cashier")]
        [HttpPost]
        public void Post(SaleModel sale)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier); //RequestContext.Principal.Identity.GetUserId();

            _saleData.SaveSale(sale, userId);
        }

        // api/Sale/GetSalesReport
        [Authorize(Roles = "Admin,Manager")]
        [Route("GetSalesReport")]
        [HttpGet]
        public List<SaleReportModel> GetSalesReports()
        {
            return _saleData.GetSaleReports();
        }

        [AllowAnonymous]
        [Route("GetTaxReport")]
        [HttpGet]
        public decimal GetTaxReports()
        {
            return _saleData.GetTaxRate();
        }
    }
}
