using Biblioteca.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Http;

namespace Biblioteca.Controllers
{
    public class UsuarioController : Controller
    {
        public IActionResult Listagem(){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            return View(new UsuarioService().Listar());
        }

        public IActionResult editarUsuario(int id)
        {
            Usuario u = new UsuarioService().Listar(id);
            return View(u);
        }

        [HttpPost]
        public IActionResult editarUsuario(Usuario userEditado){
            
            userEditado.Senha = Criptografo.TextoCriptografado(userEditado.Senha); //faz a senha alterada do usuário ser criptografada
            
            UsuarioService us = new UsuarioService();
            us.editarUsuario(userEditado);

            return RedirectToAction("Listagem");
        }

        public IActionResult Cadastro()
        {
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            return View();
        }
        
        public IActionResult RegistrarUsuarios(){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            return View();
        }

        [HttpPost]
        public IActionResult RegistrarUsuarios(Usuario novoUser){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);

            novoUser.Senha = Criptografo.TextoCriptografado(novoUser.Senha);

            UsuarioService us = new UsuarioService();
            us.incluirUsuario(novoUser);

            return RedirectToAction("CadastroRealizado");
        }

        public IActionResult ExcluirUsuario(int id)
        {
            return View(new UsuarioService().Listar(id));
        }

        [HttpPost]
        public IActionResult ExcluirUsuario(string decisao, int id){
            if(decisao == "Excluir"){
                ViewData["Mensagem"] = "Exclusão do usuário " +new UsuarioService().Listar(id).Nome+ " realizada com sucesso";
                new UsuarioService().excluirUsuario(id);
                return View("Listagem", new UsuarioService().Listar());
            }
            else{
                return View("Listagem", new UsuarioService().Listar());
            }

        }

        public IActionResult CadastroRealizado(){
            Autenticacao.CheckLogin(this);
            Autenticacao.verificaSeUsuarioEAdmin(this);
            
            return View();
        }

        public IActionResult PrecisaAdmin(){
            Autenticacao.CheckLogin(this);
            return View();
        }

        public IActionResult Sair(){
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}