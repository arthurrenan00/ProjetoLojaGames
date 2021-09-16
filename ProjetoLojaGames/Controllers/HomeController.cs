using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjetoLojaGames.Models;
using ProjetoLojaGames.Repositorio;

namespace ProjetoLojaGames.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        Acoes ac = new Acoes();
        //PARTE DO JOGO

        public ActionResult Jogo()
        {
            var jogo = new Jogo();
            return View(jogo);
        }
        

        [HttpPost]
        public ActionResult CadJogo(Jogo jog)
        {
            ac.CadastrarJogo(jog);
            return View(jog);
        }

        public ActionResult ListarJogo()
        {
            var ExibeJogo = new Acoes();
            var TodosJogos = ExibeJogo.ListarJogo();
            return View(TodosJogos);
        }

        // PARTE DO CLIENTE
        public ActionResult Cliente()
        {
            var cliente = new Cliente();
            return View(cliente);
        }


        [HttpPost]
        public ActionResult CadCli(Cliente cli)
        {
            ac.CadastrarCliente(cli);
            return View(cli);
        }

        public ActionResult ListarCliente()
        {
            var ExibeCli = new Acoes();
            var TodosCli = ExibeCli.ListarCliente();
            return View(TodosCli);
        }

        // PARTE DO FUNCIONÁRIO
        public ActionResult Funcionario()
        {
            var funcio = new Funcionario();
            return View(funcio);
        }


        [HttpPost]
        public ActionResult CadFunc(Funcionario func)
        {
            ac.CadastrarFunc(func);
            return View(func);
        }

        public ActionResult ListarFuncionario()
        { 
            var ExibeFunc = new Acoes();
            var TodosFunc = ExibeFunc.ListarFuncionario();
            return View(TodosFunc);
        }

    }
}