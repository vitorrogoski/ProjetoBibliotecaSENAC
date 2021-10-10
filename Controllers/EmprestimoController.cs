using System;
using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Biblioteca.Controllers
{
    
    public class EmprestimoController : Controller
    {
        
        public IActionResult Cadastro()
        {

            Autenticacao.CheckLogin(this);
       
            LivroService livroService = new LivroService();
            EmprestimoService emprestimoService = new EmprestimoService();

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = livroService.ListarTodos();
            cadModel.Livros = livroService.ListarDisponiveis();
            return View(cadModel);
        }

        [HttpPost]
        public IActionResult Cadastro(CadEmprestimoViewModel viewModel)
        {
            if(!string.IsNullOrEmpty(viewModel.Emprestimo.NomeUsuario)){

                EmprestimoService emprestimoService = new EmprestimoService();

                if(viewModel.Emprestimo.Id == 0){
                    emprestimoService.Inserir(viewModel.Emprestimo);
                }
                else
                {
                    emprestimoService.Atualizar(viewModel.Emprestimo);
                }
                return RedirectToAction("Listagem");
            }
            else{
                ViewData["mensagem"] = "Por favor, preencha todos os campos";

                LivroService livroService = new LivroService();
                EmprestimoService emprestimoService = new EmprestimoService();

                CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();

                cadModel.Livros = livroService.ListarDisponiveis();

                return View(cadModel);
            }
        }

        public IActionResult Listagem(string tipoFiltro, string filtro, int pag = 1)
        {
            Autenticacao.CheckLogin(this);
            FiltrosEmprestimos objFiltro = null;
            if(!string.IsNullOrEmpty(filtro))
            {
                objFiltro = new FiltrosEmprestimos();
                objFiltro.Filtro = filtro;
                objFiltro.TipoFiltro = tipoFiltro;
            }

            int quantidadePorPagina = 10;
            EmprestimoService emprestimoService = new EmprestimoService();
            int totalDeRegistros = emprestimoService.NumeroDeEmprestimos();
            ICollection<Emprestimo> lista = emprestimoService.ListarTodos (pag, quantidadePorPagina, objFiltro);
            ViewData["NumeroDePaginas"] = (int) Math.Ceiling((double) totalDeRegistros / quantidadePorPagina);
            
            return View(lista);
        }

        public IActionResult Edicao(int id)
        {
            Autenticacao.CheckLogin(this);
            LivroService livroService = new LivroService();
            EmprestimoService em = new EmprestimoService();
            Emprestimo e = em.ObterPorId(id);

            CadEmprestimoViewModel cadModel = new CadEmprestimoViewModel();
            cadModel.Livros = livroService.ListarDisponiveis();
            cadModel.Livros.Add(livroService.ObterPorId(e.LivroId));
            cadModel.Emprestimo = e;
            
            return View(cadModel);
        }
    }
}