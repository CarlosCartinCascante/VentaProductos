using Microsoft.AspNetCore.Mvc;

using VentaProductos.Models;

namespace VentaProductos.Controllers
{
    public class VentaProductosController : Controller
    {

        private readonly FamiliaProductoHandler familiaHandler = new();
        private readonly ProductoHandler productoHandler = new();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CrearFamiliaProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearFamiliaProducto(FamiliaProducto familiaProducto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            familiaHandler.AgregarFamiliaProducto(familiaProducto);

            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditarFamiliaProducto(int idFamiliaProducto)
        {
            FamiliaProducto familiaProducto = familiaHandler.ObtenerFamiliaProducto(idFamiliaProducto);
            TempData["idFamiliaProducto"] = familiaProducto.IDFamilia;
            ViewBag.familiaProductoAntigua = familiaProducto;
            return View();
        }

        [HttpPost]
        public ActionResult EditarFamiliaProducto(FamiliaProducto familiaProducto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (TempData["idFamiliaProducto"] != null)
            {
                familiaProducto.IDFamilia = (int)TempData["idFamiliaProducto"];
            }

            familiaHandler.EditarFamiliaProducto(familiaProducto);
            return RedirectToAction("VerFamiliaProducto");
        }

        [HttpPost]
        public ActionResult BorrarFamiliaProducto(int idFamiliaProducto)
        {
            familiaHandler.BorrarFamiliaProducto(idFamiliaProducto);
            return RedirectToAction("VerFamiliaProducto");
        }

        public ActionResult VerFamiliaProducto()
        {
            return View(familiaHandler.ObtenerFamiliasProductos());
        }

        public ActionResult CrearProducto()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CrearProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            productoHandler.AgregarProducto(producto);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult EditarProducto(int codigoProducto)
        {
            Producto producto = productoHandler.ObtenerProducto(codigoProducto);
            TempData["codigoProducto"] = producto.CodigoProducto;
            TempData["fechaIngreso"] = producto.FechaIngreso;
            ViewBag.productoAntiguo = producto;
            return View();
        }

        [HttpPost]
        public ActionResult EditarProducto(Producto producto)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            if (TempData["codigoProducto"] != null)
            {
                producto.CodigoProducto = (int)TempData["codigoProducto"];
            }
            if (TempData["fechaIngreso"] != null)
            {
                producto.FechaIngreso = (DateTime)TempData["fechaIngreso"];
            }

            productoHandler.EditarProducto(producto);
            return RedirectToAction("VerProductos");
        }

        [HttpPost]
        public ActionResult BorrarProducto(int codigoProducto)
        {
            productoHandler.BorrarProducto(codigoProducto);
            return RedirectToAction("VerProductos");
        }

        public ActionResult VerProductos()
        {
            return View(productoHandler.ObtenerProductos());
        }
    }
}
