using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tic.Nova.Dados.Entidade;
using Tic.Nova.Dados.Repositorio;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Tic.Nova.Controllers
{
    public class ClienteController : Controller
    {
        private readonly ClienteRepositorio _clienteRepositorio;

        public ClienteController()
        {
            _clienteRepositorio = new ClienteRepositorio();
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pesquisa()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Cliente requisicao)
        {
            var cliente = _clienteRepositorio.InserirCliente(requisicao);

            return cliente != null ? View("Cliente", cliente) : View("NotFound");
        }

        [HttpPost]
        public IActionResult ObterClientePorEmail(string email)
        {
            var cliente = _clienteRepositorio.ObterClientePorEmail(email);

            return cliente != null ? View("Cliente", cliente) : View("NotFound");
        }
    }
}
