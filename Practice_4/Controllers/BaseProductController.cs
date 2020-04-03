using Practice_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Practice_4.Controllers
{
    public class BaseProductController : Controller
    {
        [HttpGet]
        public ActionResult Create() {
            return View();
        }

        /// <summary>
        /// Метод добавления в коллекцию продукта
        /// </summary>
        /// <param name="product">Продукт переденный из формы</param>
        /// <returns>Переадресовывает на главную страницу</returns>
        [HttpPost]
        public ActionResult Create(BaseProduct product) {
            if (!ModelState.IsValid)
                return View();

            var products = (List<BaseProduct>)Session["BaseProducts"];

            if (products == null)
                products = new List<BaseProduct>();

            product.Id = products.Count == 0 ? 1 : products.Max(item => item.Id) + 1;

            products.Add(product);
            Session["BaseProducts"] = products;

            TempData["SuccessMessage"] = "Продукт успешно добавлен";

            return RedirectToAction("Index", "Products");
        }

        /// <summary>
        /// Метод получения информации о продукте
        /// </summary>
        /// <param name="id">id продукта</param>
        /// <returns>Страница с информацией о продукте</returns>
        [HttpGet]
        public ActionResult Details(int? id) {
            if (id == null)
                return RedirectToAction("Index", "Products");

            var products = ((List<BaseProduct>)Session["BaseProducts"]);

            if (products == null || products.Count == 0)
            {
                TempData["ErrorMessage"] = $"Невозможно отобразить информацию о продукте,коллекция продуктов отсутствует или пуста";
                return RedirectToAction("Index", "Products");
            }

            var productToDisplay = products.FirstOrDefault(product => product.Id == id);

            if (productToDisplay == null)
            {
                TempData["ErrorMessage"] = $"Продукт с идентификатором [{id}] не найден";
                return RedirectToAction("Index", "Products");
            }

            return View(productToDisplay);
        }

        [HttpGet]
        public ActionResult Edit(int? id) {
            if (id == null)
                return RedirectToAction("Index", "Products");

            var products = ((List<BaseProduct>)Session["BaseProducts"]);

            if (products == null || products.Count == 0)
            {
                TempData["ErrorMessage"] = $"Невозможно редактировать продукт,коллекция продуктов отсутствует или пуста";
                return RedirectToAction("Index", "Products");
            }

            var productToEdit = products.FirstOrDefault(product => product.Id == id);

            if (productToEdit == null)
            {
                TempData["ErrorMessage"] = $"Продукт с идентификатором [{id}] не найден";
                return RedirectToAction("Index", "Products");
            }

            return View(productToEdit);
        }

        /// <summary>
        /// Метод редактирования продукта
        /// </summary>
        /// <param name="product">редактированный продукт</param>
        /// <returns>Переадресация на главную страницу</returns>
        [HttpPost]
        public ActionResult Edit(BaseProduct product) {
            if (!ModelState.IsValid)
                return View(product);

            var products = (List<BaseProduct>)Session["BaseProducts"];

            if (products == null || products.Count == 0)
            {
                TempData["ErrorMessage"] = $"Невозможно редактировать продукт,коллекция продуктов отсутствует или пуста";
                return RedirectToAction("Index", "Products");
            }

            if (products.FirstOrDefault(item => item.Id == product.Id) == null)
            {
                TempData["ErrorMessage"] = $"Продукт с идентификатором [{product.Id}] не найден";
                return RedirectToAction("Index", "Products");
            }

            products[products.FindIndex(item => item.Id == product.Id)] = product;

            Session["BaseProducts"] = products;

            TempData["SuccessMessage"] = $"Продукт [{product.Name}] изменен!";
            return RedirectToAction("Index", "Products");
        }

        /// <summary>
        /// Метод удаления продукта из коллекции
        /// </summary>
        /// <param name="id">id продукта</param>
        /// <returns>Переадресация на главную страницу</returns>
        [HttpGet]
        public ActionResult Delete(int? id) {
            if (id == null)
                return RedirectToAction("Index", "Products");
            var products = (List<BaseProduct>)Session["BaseProducts"];

            if (products == null || products.Count == 0)
            {
                TempData["ErrorMessage"] = $"Невозможно удалить продукт,коллекция продуктов отсутствует или пуста"; return RedirectToAction("Index", "Products");
            }

            var product = products.Find(item => item.Id == id);

            if (product == null)
            {
                TempData["ErrorMessage"] = $"Продукт с идентификатором [{id}] не найден";
                return RedirectToAction("Index", "Products");
            }

            TempData["SuccessMessage"] = $"Продукт [{product.Name}] успешно удалён!";
            products.Remove(product);

            Session["BaseProducts"] = products;

            return RedirectToAction("Index", "Products");
        }
    }
}