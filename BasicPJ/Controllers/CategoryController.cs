using BasicPJ.Data;
using BasicPJ.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BasicPJ.Controllers
{
    public class CategoryController : BaseController<Category>
    {
        private readonly IRepository<Product> _productRepository;
        private readonly IRepository<OptionProduct> _optionProductRepository;
        public CategoryController()
        {
            _productRepository = new Repository<Product>(Context);
            _optionProductRepository = new Repository<OptionProduct>(Context);
        }
        public ActionResult Index()
        {
            var listCategory = GetAll().ToList();
            return View(listCategory);
        }
        public ActionResult Details(int Id)
        {
            Category category = GetById(Id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Create(Category category)
        {
            Add(category);
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Edit(int Id)
        {
            Category category = GetById(Id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            Update(category);
            return RedirectToAction("Index", "Category");
        }
        public ActionResult Delete(int Id)
        {
            Category p = GetById(Id);
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(Category category)
        {
            Remove(category);
            return RedirectToAction("Index", "Category");
        }
        [Route("Collections/{Slug}")]
        public ActionResult Collection(string Slug)
        {
            var categories = GetAll();
            ViewBag.ListCate = categories;
            if (Slug == "All" || Slug == "")
            {
                var products = Context.Products.ToList();
                ViewBag.Categories = categories;
                return View(products);
            }
            else
            {
                var products = Context.Products.Where(x => x.Category.Slug == Slug).ToList();
                var categoriesBySlug = Context.Categories.Where(n => n.Slug == Slug).ToList();
                ViewBag.Categories = categoriesBySlug;
                return View(products);
            }
        }
        public ActionResult DetailProduct(int Id)
        {
            var Product = _productRepository.GetById(Id);
            var c = _optionProductRepository.GetAll().ToList();
            c = Context.OptionProducts.Where(p => p.Product.ProductId == Id).ToList();
            ViewBag.optionProducts = c;
            return View(Product);
        }
    }
}