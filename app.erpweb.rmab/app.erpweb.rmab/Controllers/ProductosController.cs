using app.erpweb.rmab.Bussines;
using app.erpweb.rmab.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace app.erpweb.rmab.Controllers
{
    public class ProductosController : Controller
    {
        //instanciar objeto de la clase ProductoBll
        readonly ProductoBll obj = new ProductoBll();

        // GET: Productos
        public ActionResult Index()
        {
            return View(obj.ProductoListar().ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            Producto pro = new Producto
            {
                IdProducto = id
            };
            return View(obj.ProductoConsultar(pro));
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public ActionResult Create(Producto pro)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    obj.ProductoAdicionar(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            Producto pro = new Producto
            {
                IdProducto = id
            };
            return View(obj.ProductoConsultar(pro));
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public ActionResult Edit(Producto pro)
        {
            try
            {
                // TODO: Add update logic here
                if (ModelState.IsValid)
                {
                    obj.ProductoActualizar(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            Producto pro = new Producto
            {
                IdProducto = id
            };
            return View(obj.ProductoConsultar(pro));
        }

        // POST: Productos/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                Producto pro = new Producto
                {
                    IdProducto = id
                };
                if (ModelState.IsValid)
                {
                    obj.ProductoEliminar(pro);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
