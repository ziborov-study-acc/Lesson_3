using Practice_4.Helpers;
using Practice_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_4.Controllers
{
    public class ProductsController : Controller {
        public ActionResult Index() {
            if (Session["BaseProducts"] == null)
            {
                Session["BaseProducts"] = new List<BaseProduct> {
                    new BaseProduct(1,"Продукт штучный","5 шт."),
                    new BaseProduct(2,"BaseКартошка","5 кг."),
                    new BaseProduct(3,"Вода","7 л."),
                    new BaseProduct(4,"Бутылка воды","500 мл."),
                    new BaseProduct(5,"Продукт","300 г."),
                    new BaseProduct(6,"Что-то","5 шт."),
                };
            }

            if (Session["Products"] == null)
            {
                Session["Products"] = new List<Product> {
                    new Product(1,"Помидор",50,MeasureType.Piece),
                    new Product(2,"Картошка",10,MeasureType.Kilogram),
                    new Product(3,"Вода",7,MeasureType.Liter),
                    new Product(4,"Бутылка колы",500,MeasureType.Mililiter),
                    new Product(5,"Чипсы",300,MeasureType.Gram),
                    new Product(6,"Что-то",5,MeasureType.Piece),
                };
            }
            ViewBag.Products = (List<Product>)Session["Products"];
            ViewBag.BaseProducts = (List<BaseProduct>)Session["BaseProducts"];
            return View();
        }

    }
}