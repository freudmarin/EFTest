using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFDbFirstApproachExample.Models;

namespace EFDbFirstApproachExample.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories/Index
        public ActionResult Index(string search = "", string SortColumn = "CategoryName", string IconClass = "fa-sort-asc", int PageNo = 1)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            ViewBag.search = search;
            List<Category2> categories = db.Categories.Where(c2 => c2.CategoryName.Contains(search)).ToList();

           
            ViewBag.SortColumn = SortColumn;
            ViewBag.IconClass = IconClass;
            if (ViewBag.SortColumn == "CategoryID")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    categories = categories.OrderBy(temp => temp.CategoryID).ToList();
                else
                    categories = categories.OrderByDescending(temp => temp.CategoryID).ToList();
            }
            else if (ViewBag.SortColumn == "CategoryName")
            {
                if (ViewBag.IconClass == "fa-sort-asc")
                    categories = categories.OrderBy(temp => temp.CategoryName).ToList();
                else
                    categories = categories.OrderByDescending(temp => temp.CategoryName).ToList();

            }
            int NoOfRecordsPerPage = 5;
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(categories.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
            int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
            ViewBag.PageNo = PageNo;
            ViewBag.NoOfPages = NoOfPages;
            categories = categories.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

            return View(categories);
        }

        public ActionResult Details(long id)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Category2 c = db.Categories.Where(categ => categ.CategoryID == id).FirstOrDefault();
            return View(c);
        }
        public  ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category2 c)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
       
            db.Categories.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Edit(long id)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Category2 thisCategory = db.Categories.Where(c => c.CategoryID == id).FirstOrDefault();

            return View(thisCategory);
        }
        [HttpPost]
        public ActionResult Edit(Category2 c)
        {
            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Category2 thisCategory = db.Categories.Where(a => a.CategoryID == c.CategoryID).FirstOrDefault();
            thisCategory.CategoryName = c.CategoryName;
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }
        public ActionResult Delete (long id)
        {

            CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Category2 toDeleteCategory= db.Categories.Where(t => t.CategoryID == id).FirstOrDefault();
            return View(toDeleteCategory);
        }
        [HttpPost]
        public ActionResult Delete(long id,Category2 c)
        {
           CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
            Category2 toDeleteCategory2 = db.Categories.Where(t2 => t2.CategoryID == id).FirstOrDefault();
            db.Categories.Remove(toDeleteCategory2);
            db.SaveChanges();
            return RedirectToAction("Index", "Categories");
        }


    }
}


