using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using ProductService.Models;

namespace ProductService.Controllers
{
    /*
    The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using ProductService.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Brand>("Brands");
    builder.EntitySet<Product>("Products"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class BrandsController : ODataController
    {
        private ProductServiceContext db = new ProductServiceContext();

        // GET: odata/Brands
        [Queryable]
        public IQueryable<Brand> GetBrands()
        {
            return db.Brands;
        }

        // GET: odata/Brands(5)
        [Queryable]
        public SingleResult<Brand> GetBrand([FromODataUri] int key)
        {
            return SingleResult.Create(db.Brands.Where(brand => brand.ID == key));
        }

        // PUT: odata/Brands(5)
        public IHttpActionResult Put([FromODataUri] int key, Delta<Brand> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Brand brand = db.Brands.Find(key);
            if (brand == null)
            {
                return NotFound();
            }

            patch.Put(brand);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(brand);
        }

        // POST: odata/Brands
        public IHttpActionResult Post(Brand brand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Brands.Add(brand);
            db.SaveChanges();

            return Created(brand);
        }

        // PATCH: odata/Brands(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Brand> patch)
        {
            Validate(patch.GetEntity());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Brand brand = db.Brands.Find(key);
            if (brand == null)
            {
                return NotFound();
            }

            patch.Patch(brand);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BrandExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(brand);
        }

        // DELETE: odata/Brands(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Brand brand = db.Brands.Find(key);
            if (brand == null)
            {
                return NotFound();
            }

            db.Brands.Remove(brand);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET: odata/Brands(5)/Products
        [Queryable]
        public IQueryable<Product> GetProducts([FromODataUri] int key)
        {
            return db.Brands.Where(m => m.ID == key).SelectMany(m => m.Products);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BrandExists(int key)
        {
            return db.Brands.Count(e => e.ID == key) > 0;
        }
    }
}
