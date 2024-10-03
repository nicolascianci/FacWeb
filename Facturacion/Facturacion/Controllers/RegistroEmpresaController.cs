using Business;
using Entity.Parametros;
using Facturacion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Facturacion.Controllers
{
    public class RegistroEmpresaController : Controller
    {
        private modelList model;
        private BUPais bupais;


        public RegistroEmpresaController()
        {
            model = new modelList();
            bupais = new BUPais();
        }

        public ActionResult RegistroEmpresa(ENRegistroEmpresa paramss)
        {
           string token = "";

            model.listPais = bupais.listaPaises(paramss,token);
            return View(model);
        }

        
    }
}
