﻿using System;
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
    public class ProductController : ApiController
    {
        // GET: api/Product
        public List<ProductModel> Get()
        {
            ProductData data = new ProductData();
            return data.GetAllProduct();
        }

    }
}
