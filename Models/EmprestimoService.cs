using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Models
{
    public class EmprestimoService
    {
        public void Inserir(Emprestimo e)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                bc.Emprestimos.Add(e);
                bc.SaveChanges();
            }
        }

        public void Atualizar (Emprestimo e) {
            using (BibliotecaContext bc = new BibliotecaContext ()) {
                Emprestimo emprestimo = bc.Emprestimos.Find (e.Id);
                emprestimo.NomeUsuario = e.NomeUsuario;
                emprestimo.Telefone = e.Telefone;
                emprestimo.LivroId = e.LivroId;
                emprestimo.DataEmprestimo = e.DataEmprestimo;
                emprestimo.DataDevolucao = e.DataDevolucao;

                bc.SaveChanges ();
            }
        }

        public ICollection<Emprestimo> ListarTodos(int pag = 1, int tamanho = 4, FiltrosEmprestimos filtro = null)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                IQueryable<Emprestimo> query;
                int pular = (pag - 1) * tamanho;

                if (filtro != null)
                {
                    //definindo dinamicamente a filtragem
                    switch (filtro.TipoFiltro)
                    {
                        case "Usuario":
                            query = bc.Emprestimos.Include(e => e.Livro).Where(e => e.NomeUsuario.Contains(filtro.Filtro, StringComparison.CurrentCultureIgnoreCase));
                            break;

                        case "Livro":
                            query = bc.Emprestimos.Include(e => e.Livro).Where(e => e.Livro.Titulo.Contains(filtro.Filtro, StringComparison.CurrentCultureIgnoreCase));
                            break;

                        default:
                            query = bc.Emprestimos.Include(e => e.Livro);
                            break;
                    }
                }
                else
                {
                    // caso filtro não tenha sido informado
                    query = bc.Emprestimos.Include(e => e.Livro);
                }
                return query.Skip(pular).Take(tamanho).OrderByDescending(e => e.DataDevolucao).ToList();
                
            }
        }

        public Emprestimo ObterPorId(int id)
        {
            using (BibliotecaContext bc = new BibliotecaContext())
            {
                return bc.Emprestimos.Find(id);
            }
        }
        public int NumeroDeEmprestimos(){
            using(var context = new BibliotecaContext()){
                return context.Emprestimos.Count();
            }
        }
    }
}