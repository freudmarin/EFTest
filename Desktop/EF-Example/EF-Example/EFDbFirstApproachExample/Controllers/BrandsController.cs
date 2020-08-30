
using EFDbFirstApproachExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

public class BrandsController : Controller
{
    // GET: Categories/Index
    public ActionResult Index(string search = "", string SortColumn = "BrandName", string IconClass = "fa-sort-asc", int PageNo = 1)
    {
        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
        ViewBag.search = search;
        List<Brand2> brands = db.Brands.Where(c2 => c2.BrandName.Contains(search)).ToList();


        ViewBag.SortColumn = SortColumn;
        ViewBag.IconClass = IconClass;
        if (ViewBag.SortColumn == "BrandID")
        {
            if (ViewBag.IconClass == "fa-sort-asc")
                brands = brands.OrderBy(temp => temp.BrandID).ToList();
            else
                brands= brands.OrderByDescending(temp => temp.BrandID).ToList();
        }
        else if (ViewBag.SortColumn == "BrandName")
        {
            if (ViewBag.IconClass == "fa-sort-asc")
               brands = brands.OrderBy(temp => temp.BrandName).ToList();
            else
                brands = brands.OrderByDescending(temp => temp.BrandName).ToList();

        }
        int NoOfRecordsPerPage = 5;
        int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(brands.Count) / Convert.ToDouble(NoOfRecordsPerPage)));
        int NoOfRecordsToSkip = (PageNo - 1) * NoOfRecordsPerPage;
        ViewBag.PageNo = PageNo;
        ViewBag.NoOfPages = NoOfPages;
        brands = brands.Skip(NoOfRecordsToSkip).Take(NoOfRecordsPerPage).ToList();

        return View(brands);
    }

    public ActionResult Details(long id)
    {
        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
        Brand2 brand = db.Brands.Where(br => br.BrandID == id).FirstOrDefault();
        return View(brand);
    }
    public ActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Create(Brand2 br)
    {
        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
        if (ModelState.IsValid)
        {
            db.Brands.Add(br);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        else
            return View(br);

    }

    public ActionResult Edit(long id)
    {
        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
       Brand2 thisbrand = db.Brands.Where(br=> br.BrandID == id).FirstOrDefault();

        return View(thisbrand);
    }
    [HttpPost]
    public ActionResult Edit(Brand2 br)
    {
        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
        if (ModelState.IsValid)
        {
            Brand2 thisBrand = db.Brands.Where(a => a.BrandID == br.BrandID).FirstOrDefault();
            thisBrand.BrandName = br.BrandName;
            db.SaveChanges();
            return RedirectToAction("Index", "Brands");
        }
        return View(br);
    }
    public ActionResult Delete(long id)
    {

        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
        Brand2 toDeleteBrand = db.Brands.Where(br => br.BrandID == id).FirstOrDefault();
        return View(toDeleteBrand);
    }
    [HttpPost]
    public ActionResult Delete(long id, Brand2 br)
    {
        CodeFirstDatabaseEntities db = new CodeFirstDatabaseEntities();
       Brand2 toDeleteBrand2 = db.Brands.Where(t2 => t2.BrandID == id).FirstOrDefault();
        db.Brands.Remove(toDeleteBrand2);
        db.SaveChanges();
        return RedirectToAction("Index", "Brands");
    }


}


