#pragma checksum "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de778c77c62f67bac0a408581c28ac6b7207751a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Index), @"mvc.1.0.view", @"/Views/Home/Index.cshtml")]
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
#line 1 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\_ViewImports.cshtml"
using dotdis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de778c77c62f67bac0a408581c28ac6b7207751a", @"/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7131d8d06665ee11de7040b7069ac5c5a863a366", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
  
ViewData["Title"] = "Home Page";

#line default
#line hidden
#nullable disable
            DefineSection("head", async() => {
                WriteLiteral("\r\n    <link rel=\"apple-touch-icon\" sizes=\"180x180\"");
                BeginWriteAttribute("href", " href=\'", 107, "\'", 156, 1);
#nullable restore
#line 6 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 114, Url.Content("~/img/apple-touch-icon.png"), 114, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"32x32\"");
                BeginWriteAttribute("href", " href=\'", 211, "\'", 257, 1);
#nullable restore
#line 7 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 218, Url.Content("~/img/favicon-32x32.png"), 218, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"16x16\"");
                BeginWriteAttribute("href", " href=\'", 312, "\'", 358, 1);
#nullable restore
#line 8 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 319, Url.Content("~/img/favicon-16x16.png"), 319, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"manifest\"");
                BeginWriteAttribute("href", " href=\'", 386, "\'", 431, 1);
#nullable restore
#line 9 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 393, Url.Content("~/img/site.webmanifest"), 393, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">    \r\n    <link");
                BeginWriteAttribute("href", " href=\'", 448, "\'", 486, 1);
#nullable restore
#line 10 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 455, Url.Content("~/css/index.css"), 455, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\'", 534, "\'", 575, 1);
#nullable restore
#line 11 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 541, Url.Content("~/css/fontIcon.css"), 541, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            );
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de778c77c62f67bac0a408581c28ac6b7207751a6116", async() => {
                WriteLiteral(@"
    <div class=""navigation"">
        <input type=""checkbox"" class=""navigation__checkbox"" id=""navi-toogle"">
        <label for=""navi-toogle"" class=""navigation__button"">
            <span class=""navigation__icon"">
                &nbsp;
            </span>
        </label>

        <div class=""navigation__background"">&nbsp;</div>

        <nav class=""navigation__nav"">
            <ul class=""navigation__list"">
                <li class=""navigation__item"">
                    <a href=""#"" class=""navigation__link""><span>01</span>Start now</a>
                </li>
                <li class=""navigation__item"">
                    <a href=""#"" class=""navigation__link""><span>02</span>Why Discord?</a>
                </li>
                <li class=""navigation__item"">
                    <a href=""#"" class=""navigation__link""><span>03</span>Safety use</a>
                </li>
                <li class=""navigation__item"">
                    <a href=""#"" class=""navigation__link""><span>04</span>About");
                WriteLiteral(@" us</a>
                </li>
                <li class=""navigation__item"">
                    <a href=""#"" class=""navigation__link""><span>05</span>Contact</a>
                </li>
            </ul>
        </nav>
    </div>
    <header class=""home__header"">
        <div class=""home__header__logo-box"">
            <img");
                BeginWriteAttribute("src", " src=\'", 1978, "\'", 2015, 1);
#nullable restore
#line 46 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 1984, Url.Content("~/img/logo1.png"), 1984, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" alt=""logo"" class=""home__header__logo"">
        </div>
        <div class=""home__header--content"">
            <h1 class=""home__header--content--title"">
                Your place to talk
            </h1>
            <p class=""home__header--content--description"">
                Whether you’re part of a school club, gaming group, worldwide art community, or just a handful of
                friends that want to spend time together, Dodis makes it easy to talk every day and hang out more
                often.
            </p>

            <a href=""chat"" class=""btn btn--white btn-animated u-margin-top-medium"">
                Start Chatting now
            </a>
        </div>
    </header>
    <main style=""height: 100%;"">
        <section class=""home__section home__section--1"">
            <div>
                <img class=""home__section--1--image""");
                BeginWriteAttribute("src", " src=\'", 2895, "\'", 2946, 1);
#nullable restore
#line 66 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 2901, Url.Content("~/img/home__section_image.svg"), 2901, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 2947, "\"", 2953, 0);
                EndWriteAttribute();
                WriteLiteral(@">
            </div>
            <div></div>
            <div class=""home__section--1--content"">
                <div>
                    <h2 class=""home__section--1--title heading-secondary"">An invite-only place with plenty of room to
                        talk</h2>
                    <p class=""home__section--1--description"">
                        Dodis servers are organized into topic-based channels where you can collaborate, share, and just
                        talk about your day without clogging up a group chat.
                    </p>
                </div>
            </div>
            <div></div>
        </section>
        <section class=""home__section home__section--2"">
            <div class=""home__section home__section--2--wrapper"">
                <div class=""feature-box"">
                    <i class=""feature-box__icon icon-basic-world""></i>
                    <h3 class=""heading-tertiary u-margin-bottom-small"">
                        Chat de
                    <");
                WriteLiteral(@"/h3>
                    <p class=""feature-box__text"">
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Eveniet, repellat ea natus
                        reiciendis
                    </p>
                </div>
                <div></div>
                <div class=""feature-box"">
                    <i class=""feature-box__icon icon-basic-compass""></i>
                    <h3 class=""heading-tertiary u-margin-bottom-small"">
                        Chat de
                    </h3>
                    <p class=""feature-box__text"">
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Eveniet, repellat ea natus
                        reiciendis
                    </p>
                </div>
                <div></div>
                <div class=""feature-box"">
                    <i class=""feature-box__icon icon-basic-map""></i>
                    <h3 class=""heading-tertiary u-margin-bottom-small"">
                        Chat de");
                WriteLiteral(@"
                    </h3>
                    <p class=""feature-box__text"">
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Eveniet, repellat ea natus
                        reiciendis
                    </p>
                </div>
                <div></div>
                <div class=""feature-box"">
                    <i class=""feature-box__icon icon-basic-heart""></i>
                    <h3 class=""heading-tertiary u-margin-bottom-small"">
                        Chat de
                    </h3>
                    <p class=""feature-box__text"">
                        Lorem ipsum dolor sit amet consectetur adipisicing elit. Eveniet, repellat ea natus
                        reiciendis
                    </p>
                </div>
            </div>

        </section>
        <section class=""home__section home__section--3"">
            <div></div>
            <div class=""home__section--1--content"">
                <div>
                    <h2 cl");
                WriteLiteral(@"ass=""home__section--1--title heading-secondary"">An invite-only place with plenty of room to
                        talk</h2>
                    <p class=""home__section--1--description"">
                        Dodis servers are organized into topic-based channels where you can collaborate, share, and just
                        talk about your day without clogging up a group chat.
                    </p>
                </div>
            </div>
            <div></div>
            <div>
                <img class=""home__section--1--image""");
                BeginWriteAttribute("src", " src=\'", 6584, "\'", 6635, 1);
#nullable restore
#line 143 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 6590, Url.Content("~/img/home__section_image.svg"), 6590, 45, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                BeginWriteAttribute("alt", " alt=\"", 6636, "\"", 6642, 0);
                EndWriteAttribute();
                WriteLiteral(">\r\n            </div>\r\n        </section>\r\n    </main>\r\n    <footer class=\"footer\">\r\n        <div class=\"footer__logo-box\">\r\n            <img");
                BeginWriteAttribute("src", " src=\'", 6784, "\'", 6821, 1);
#nullable restore
#line 149 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Home\Index.cshtml"
WriteAttributeValue("", 6790, Url.Content("~/img/logo1.png"), 6790, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@">
            <!-- <picture class=""footer__logo"">
                <source srcset="""" media=""(max-width:37.5rem)"">
                <img srcset=""img/logo-green-2x.png 1x, img/logo-green-2x.png 2x"" alt=""Full logo"">
            </picture> -->
        </div>
        <div class=""footer__navigation--wrapper"">
            <div>
                <div class=""footer__navigation"">
                    <ul class=""footer__list"">
                        <li class=""footer__item"">
                            <a href=""#"" class=""footer__link"">Company</a>
                        </li>
                        <li class=""footer__item"">
                            <a href=""#"" class=""footer__link"">Company</a>
                        </li>
                        <li class=""footer__item"">
                            <a href=""#"" class=""footer__link"">Company</a>
                        </li>
                        <li class=""footer__item"">
                            <a href=""#"" class=""footer__link"">Company</a>
     ");
                WriteLiteral(@"                   </li>
                        <li class=""footer__item"">
                            <a href=""#"" class=""footer__link"">Company</a>
                        </li>
                    </ul>
                </div>
            </div>
            <div>
                <p class=""footer__copyright"">
                    Built by <a href=""#"" class=""footer__link"">Dotdis Team</a>
                </p>
            </div>
        </div>


    </footer>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
