using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class ProductsController : Controller
    {
        // GET: Products/Index
        public ActionResult Index(string search = "", string SortColumn = "ProductName", string IconClass="fa-sort-asc", int PageNo = 1)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            ViewBag.search = search;
            List<Product2> products = db.Products.Where(temp => temp.ProductName.Contains(search)).ToList();

            /*Sorting*/
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "ProductID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductID).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductID).ToList();
            }
            else if(ViewBag.SortColumn == "ProductName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.ProductName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.ProductName).ToList();
            }
            else if (ViewBag.SortColumn == "Price")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Price).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Price).ToList();
            }
            else if (ViewBag.SortColumn == "DateOfPurchase")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.DateOfPurchase).ToList();
                else
                    products = products.OrderByDescending(temp => temp.DateOfPurchase).ToList();
            }
            else if (ViewBag.SortColumn == "AvailabilityStatus")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.AvailabilityStatus).ToList();
                else
                    products = products.OrderByDescending(temp => temp.AvailabilityStatus).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Category.CategoryName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Category.CategoryName).ToList();
            }
            else if (ViewBag.SortColumn == "BrandID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    products = products.OrderBy(temp => temp.Brand.BrandName).ToList();
                else
                    products = products.OrderByDescending(temp => temp.Brand.BrandName).ToList();
            }

            /* Paging */
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            products = products.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(products);
        }

        public ActionResult Details(long id)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Product2 p = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(p);
        }

        public ActionResult Create()
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(Product2 p)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            if (ModelState.IsValid)
            {
                if (Request.Files.Count >= 1)
                {
                    var file = Request.Files[0];
                    var imgBytes = new Byte[file.ContentLength];
                    file.InputStream.Read(imgBytes, 0, file.ContentLength);
                    var base64String = Convert.ToBase64String(imgBytes, 0, imgBytes.Length);
                    p.Photo = base64String;
                }

                db.Products.Add(p);
                db.SaveChanges();

                return RedirectToAction("Index");

            }
            else
            {
               ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
             //   ViewBag.Message = "Keni gabime ne model";

                return View(p);
            }
        }
        public ActionResult Edit(long id)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Product2 existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            ViewBag.Categories = db.Categories.ToList();
            ViewBag.Brands = db.Brands.ToList();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Edit(Product2 p)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();

            if (ModelState.IsValid)
            {
                Product2 existingProduct = db.Products.Where(temp => temp.ProductID == p.ProductID).FirstOrDefault();
                existingProduct.ProductName = p.ProductName;
                existingProduct.Price = p.Price;
                existingProduct.Category = p.Category;
                existingProduct.DateOfPurchase = p.DateOfPurchase;
                existingProduct.CategoryID = p.CategoryID;
                existingProduct.BrandID = p.BrandID;
                existingProduct.AvailabilityStatus = p.AvailabilityStatus;
                existingProduct.Active = p.Active;
                db.SaveChanges();
                return RedirectToAction("Index", "Products");
            }
            else
            {
                ViewBag.Categories = db.Categories.ToList();
                ViewBag.Brands = db.Brands.ToList();
                return View(p); //duhet ktheyer View(p) dhe jo View bosh
            }


        }

                public ActionResult Delete(long id)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Product2 existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            return View(existingProduct);
        }

        [HttpPost]
        public ActionResult Delete(long id, Product2 p)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Product2 existingProduct = db.Products.Where(temp => temp.ProductID == id).FirstOrDefault();
            db.Products.Remove(existingProduct);
            db.SaveChanges();
            return RedirectToAction("Index", "Products");
        }
    }
}


