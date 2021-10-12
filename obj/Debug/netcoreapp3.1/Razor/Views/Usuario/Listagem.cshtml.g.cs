#pragma checksum "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5dbf344ac41f8cd8f6002afb81af94225dd53380"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Usuario_Listagem), @"mvc.1.0.view", @"/Views/Usuario/Listagem.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\_ViewImports.cshtml"
using Biblioteca;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\_ViewImports.cshtml"
using Biblioteca.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5dbf344ac41f8cd8f6002afb81af94225dd53380", @"/Views/Usuario/Listagem.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8ea07f0214da259abc315dec5bc842518e8ae187", @"/Views/_ViewImports.cshtml")]
    public class Views_Usuario_Listagem : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<Usuario>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
  
    ViewData["Title"] = "Usuários cadastrados no sistema:";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

<div class=""row"">
    <div class=""col-md-12"">
        <table class=""table table-striped"">
            <thead>
                <tr>
                    <th>Nome</th>
                    <th>Login</th>
                    <th>Tipo</th>
                    <th></th>
                </tr>
            </thead>
            <tbody>
");
#nullable restore
#line 20 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                 foreach (Usuario u in Model)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <tr>\r\n                        <td>");
#nullable restore
#line 23 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                       Write(u.Nome);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                        <td>");
#nullable restore
#line 24 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                       Write(u.Login);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 25 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                          string tipo = u.Tipo == Usuario.ADMIN ? "Administrador" : "Padrão";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        <td>");
#nullable restore
#line 27 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                       Write(u.Tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral(" | ");
#nullable restore
#line 27 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                                 Write(tipo);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 792, "\"", 821, 2);
            WriteAttributeValue("", 799, "EditarUsuario?id=", 799, 17, true);
#nullable restore
#line 29 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
WriteAttributeValue("", 816, u.Id, 816, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Editar</a></td>\r\n                        <td><a");
            BeginWriteAttribute("href", " href=\"", 870, "\"", 900, 2);
            WriteAttributeValue("", 877, "ExcluirUsuario?id=", 877, 18, true);
#nullable restore
#line 30 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
WriteAttributeValue("", 895, u.Id, 895, 5, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">Excluir</a></td>\r\n                    </tr>\r\n");
#nullable restore
#line 32 "C:\Users\vitor\Downloads\Biblioteca - netcore3.1\Biblioteca\Views\Usuario\Listagem.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </tbody>\r\n        </table>\r\n    </div>\r\n</div>");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<Usuario>> Html { get; private set; }
    }
}
#pragma warning restore 1591