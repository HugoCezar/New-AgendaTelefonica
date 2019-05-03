using Microsoft.AspNetCore.Mvc;
using Agenda_Telefonica.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Agenda_Telefonica.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpGet]
        public IActionResult Agenda()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Agenda(Contato contato)
        {
            if (contato.Nome == null || contato.Nome.Trim().Length == 0)
            {
                ModelState.AddModelError("Nome", "O campo Nome é obrigatório.");
            }  
            if (contato.Telefone_Celular == null || contato.Telefone_Celular.Trim().Length == 0)
            {
                ModelState.AddModelError("Celular", "O campo Telefone Celular é obrigatório.");
            }
            if (ModelState.IsValid)
            {
                try
                {
                    ContatoDao.IncluirContato(contato);
                }
                catch
                {
                    return View("Error");
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View("Agenda");
            }
        }

        List<Contato> Contatos = ContatoDao.ListaContatos();
        public IActionResult ListaContatos()
        {
            return View(Contatos);
        }

        [HttpGet]
        public IActionResult Edicao(Contato contato)
        {
            return View("Edicao", contato);
        }

        [HttpPost]
        public IActionResult Atualizar(Contato contato)
        {
            try
            {
                ContatoDao.AtualizarContato(contato);
            }
            catch
            {
                return View("Error");
            }
            return View("Edicao");
        }

        public IActionResult Details(Contato contato)
        {
            return View("Details", contato);
        }
        
        public IActionResult Excluir(Contato contato)
        {
            return View("Excluir", contato);
        }

        [HttpPost]
        public IActionResult ExcluirConfirma(int? id)
        {
            try
            {
                ContatoDao.ExcluirContato(id);                
            }
            catch
            {
                return View("Error");
            }
            return View("Index");
        }
    }
}
