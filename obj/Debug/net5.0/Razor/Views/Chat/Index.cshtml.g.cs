#pragma checksum "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a36ab1edf4eb686cbcfb32bb017dc58ea8949e12"
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
#line 1 "C:\Users\lamha\Documents\GitHub\dotDis\Views\_ViewImports.cshtml"
using dotdis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\lamha\Documents\GitHub\dotDis\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a36ab1edf4eb686cbcfb32bb017dc58ea8949e12", @"/Views/Chat/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7131d8d06665ee11de7040b7069ac5c5a863a366", @"/Views/_ViewImports.cshtml")]
    public class Views_Chat_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
  
    ViewData["Title"] = "dotDis";

#line default
#line hidden
#nullable disable
            DefineSection("head", async() => {
                WriteLiteral(@"
    <script src=""js/class.js""></script>
    <script src=""js/webSocket.js""></script>
    <link rel=""stylesheet"" href=""css/style.css"" />
    <link rel=""preconnect"" href=""https://fonts.gstatic.com"">
    <script src=""https://kit.fontawesome.com/6e774c561d.js"" crossorigin=""anonymous""></script>
    <link href=""https://fonts.googleapis.com/css2?family=Quicksand:wght@400&display=swap"" rel=""stylesheet"">
");
            }
            );
            WriteLiteral("<script type=\"text/javascript\">window.onload = init(");
#nullable restore
#line 13 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
                                               Write(ViewData["uid"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(")</script>\r\n<nav>\r\n     <div id=\"list-friend\">\r\n");
#nullable restore
#line 16 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
          foreach (User user in (List<User>)ViewData["Friend"])
         {

#line default
#line hidden
#nullable disable
            WriteLiteral("             <div class=\"nav-entry friend-room\"");
            BeginWriteAttribute("id", " id=\"", 707, "\"", 720, 1);
#nullable restore
#line 18 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
WriteAttributeValue("", 712, user.ID, 712, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onclick", " onclick=\"", 721, "\"", 752, 3);
            WriteAttributeValue("", 731, "setChatUser(", 731, 12, true);
#nullable restore
#line 18 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
WriteAttributeValue("", 743, user.ID, 743, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 751, ")", 751, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n                <img class=\"avatar\" src=\"img/avatar.png\"></img>\r\n                <div>");
#nullable restore
#line 20 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
                Write(user.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n                <div");
            BeginWriteAttribute("id", " id=\"", 880, "\"", 905, 2);
            WriteAttributeValue("", 885, "status-user-", 885, 12, true);
#nullable restore
#line 21 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
WriteAttributeValue("", 897, user.ID, 897, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></div>\r\n             </div>\r\n");
#nullable restore
#line 23 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Chat\Index.cshtml"
         }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"     </div>
     <div id=""list-room"">

     </div>
     <button onclick='location.href = ""Chat/Logout""'>Logout</button>
</nav>
<main>
    <div id=""top-bar"">
        <div class=""vertical-center"" id=""chat-name"">CHANNEL_NAME</div>
        <div id=""personal"">
            <div class=""vertical-seperator vertical-center""></div>
            <div id=""personal-noti"" class=""circle-bt""><i class=""fas fa-bell""></i></div>
            <img id=""personal-avatar"" class=""vertical-center"" src=""img/avatar.png""></img>
            <div id=""personal-name"" class=""vertical-center""></div>
            <div id=""personal-setting"" class=""circle-bt""><i class=""fas fa-cog""></i></div>
        </div>
    </div>
    <div id=""chat-window"">
            <div id=""conversation"">
                <div id=""mesg-list"">
                    <div class=""mesg-wrap"">
                        <div class=""mesg-bubble mesg-own"">This is a message</div>
                    </div>
                    <div class=""mesg-wrap"">
                   ");
            WriteLiteral(@"     <div class=""mesg-bubble mesg-other"">This is another message</div>
                    </div>
                    <div class=""mesg-wrap"">
                        <div class=""mesg-bubble mesg-own"">This is just another one</div>
                    </div>
                </div>
                <div id=""mesg-input"">
                    <textarea id=""field-mesg-input""></textarea>
                    <button id=""button-send"" onclick=""sendMesg()"" disabled>Send</button>
                </div>
            </div>
            
            <div id=""member-list"">
                <div class=""vertical-seperator""></div>
                <div class=""friend-room"">
                    <img class=""avatar"" src=""img/avatar.png""></img>
                    <div>USER_NAME</div>
                </div>
                <div class=""friend-room"">
                    <img class=""avatar"" src=""img/avatar.png""></img>
                    <div>USER_NAME</div>
                </div>
            </div>
        </div>
 ");
            WriteLiteral("   <div id=\"mesg-output\">\r\n        <p> Received Messages :</p>\r\n    </div>\r\n</main>");
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
