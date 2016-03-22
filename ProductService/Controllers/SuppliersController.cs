using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ProductService.Models;

namespace ProductService.Controllers
{
    public class SuppliersController : ApiController
    {
        private ProductServiceContext db = new ProductServiceContext();

        // GET odata/Suppliers
        [Queryable]
        public IQueryable<Supplier> GetSuppliers()
        {
            return db.Suppliers;
        }
    }
}
