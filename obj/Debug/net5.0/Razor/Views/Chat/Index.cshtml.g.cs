#pragma checksum "/home/trngngntn/Git/dotDis/Views/Chat/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0ddccd691a123dc6e58f249e028037ac7115239e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Chat_Index), @"mvc.1.0.view", @"/Views/Chat/Index.cshtml")]
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
#line 1 "/home/trngngntn/Git/dotDis/Views/_ViewImports.cshtml"
using dotdis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "/home/trngngntn/Git/dotDis/Views/_ViewImports.cshtml"
using dotdis.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0ddccd691a123dc6e58f249e028037ac7115239e", @"/Views/Chat/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a98d08d27857268ec6cada6ada4fabd505d4a77d", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "/home/trngngntn/Git/dotDis/Views/Chat/Index.cshtml"
  
    ViewData["Title"] = "dotDis";

#line default
#line hidden
#nullable disable
            DefineSection("head", async() => {
                WriteLiteral("\n    <script src=\"js/class.js\"></script>\n    <script src=\"js/webSocket.js\"></script>\n");
            }
            );
            WriteLiteral("<script type=\"text/javascript\">window.onload = setActiveUser(");
#nullable restore
#line 9 "/home/trngngntn/Git/dotDis/Views/Chat/Index.cshtml"
                                                        Write(ViewData["uid"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(@")</script>
<main>
    <span>TestUser status: <span id=""status-3"">Undefined</span></span>
    <br />
    <textarea id=""field-mesg-input""></textarea>
    <br />
    <button id=""button-send"" onclick=""sendMesg()"">Send</button>
    <br />
    <div id=""mesg-output"">
        <p> Received Messages :</p>
    </div>
</main>
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
