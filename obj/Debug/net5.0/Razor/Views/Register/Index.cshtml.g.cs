#pragma checksum "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a765a9b9316f9a7c1b21b5fd050c4082fd9ae3f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Register_Index), @"mvc.1.0.view", @"/Views/Register/Index.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7a765a9b9316f9a7c1b21b5fd050c4082fd9ae3f", @"/Views/Register/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7131d8d06665ee11de7040b7069ac5c5a863a366", @"/Views/_ViewImports.cshtml")]
    public class Views_Register_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("login__form login__form--register"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Submit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "POST", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
  
ViewData["Title"] = "Register";

#line default
#line hidden
#nullable disable
            DefineSection("head", async() => {
                WriteLiteral("\r\n    <link rel=\"apple-touch-icon\" sizes=\"180x180\"");
                BeginWriteAttribute("href", " href=\'", 106, "\'", 155, 1);
#nullable restore
#line 6 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 113, Url.Content("~/img/apple-touch-icon.png"), 113, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"32x32\"");
                BeginWriteAttribute("href", " href=\'", 210, "\'", 256, 1);
#nullable restore
#line 7 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 217, Url.Content("~/img/favicon-32x32.png"), 217, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"16x16\"");
                BeginWriteAttribute("href", " href=\'", 311, "\'", 357, 1);
#nullable restore
#line 8 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 318, Url.Content("~/img/favicon-16x16.png"), 318, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"manifest\"");
                BeginWriteAttribute("href", " href=\'", 385, "\'", 430, 1);
#nullable restore
#line 9 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 392, Url.Content("~/img/site.webmanifest"), 392, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">    \r\n    <link");
                BeginWriteAttribute("href", " href=\'", 447, "\'", 485, 1);
#nullable restore
#line 10 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 454, Url.Content("~/css/index.css"), 454, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\'", 533, "\'", 574, 1);
#nullable restore
#line 11 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 540, Url.Content("~/css/fontIcon.css"), 540, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            );
            WriteLiteral(@"<!-- <header>
    Register
</header>
<main>
    <form id=""register-form"" asp-action=""Submit"" method=""POST"">
        <input type=""text"" name=""name"" placeholder=""Fullname""><br />
        <input type=""email"" name=""email"" placeholder=""E-mail""><br />
        <input type=""text"" name=""username"" placeholder=""Username""><br />
        <input type=""password"" name=""passwd"" placeholder=""Password""><br />
        <input type=""submit"" value=""Create"">
    </form>
</main> -->

");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a765a9b9316f9a7c1b21b5fd050c4082fd9ae3f7707", async() => {
                WriteLiteral("\r\n    <main class=\"login\">\r\n    <div class=\"home__header__logo-box\">\r\n            <img");
                BeginWriteAttribute("src", " src=\'", 1185, "\'", 1222, 1);
#nullable restore
#line 29 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 1191, Url.Content("~/img/logo1.png"), 1191, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"logo\" class=\"home__header__logo\">\r\n        </div>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7a765a9b9316f9a7c1b21b5fd050c4082fd9ae3f8509", async() => {
                    WriteLiteral(@"
            <div class=""login__form__content login__form__content--register"">
                <div>
                    <h3 class=""text__header__primary"">
                        Create an account
                    </h3>
                    <div class=""auth__input__wrapper"">
                        <label class=""auth__input--label"" for=""fullname"">Full Name</label>
                        <input class=""auth__input--input"" id=""fullname"" type=""text"" name=""name"">
                    </div>
                    <div class=""auth__input__wrapper"">
                        <label class=""auth__input--label"" for=""email"">Email</label>
                        <input class=""auth__input--input"" id=""email"" type=""email"" name=""email"">
                    </div>
                    <div class=""auth__input__wrapper"">
                        <label class=""auth__input--label"" for=""name"">username</label>
                        <input class=""auth__input--input"" id=""name"" type=""text"" name=""username"">
             ");
                    WriteLiteral(@"       </div>
                    <div class=""auth__input__wrapper"">
                        <label class=""auth__input--label"" for=""passwd"">password</label>
                        <input class=""auth__input--input"" id=""passwd"" type=""password"" name=""passwd"">
                    </div>
                    <div class=""login__form--forgot-password-wrapper"">
                        <label>
                            <input type=""checkbox"">
                            <p style=""display: inline-block;"">
                                I have read and agree to DotDis's
                                <a class=""login__form--register-link"" href=""#"">
                                    Terms of Service
                                </a>
                                and
                                <a class=""login__form--register-link"" href=""#"">
                                    Privacy Policy
                                </a>
                            </p>
                        </labe");
                    WriteLiteral(@"l>
                    </div>
                    <button class=""login__form__submit--btn"">
                        <div id=""auth-loading"" class=""snippet"" data-title="".dot-flashing"">
                            <div class=""stage"">
                                <div class=""dot-flashing""></div>
                            </div>
                        </div>
                        <div onclick=""handlePressAuthBtn()"" id=""auth-text"" class=""login__form__submit--text"">
                            Login
                        </div>
                    </button>
                    <div>
                        <a class=""login__form--register-link"" href=""/Login"">Already have an account?</a>
                    </div>
                </div>
        ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_2.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n    </main>\r\n");
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
            WriteLiteral("\r\n<script");
            BeginWriteAttribute("src", " src=\'", 4228, "\'", 4267, 1);
#nullable restore
#line 85 "C:\Users\lamha\Documents\GitHub\dotDis\Views\Register\Index.cshtml"
WriteAttributeValue("", 4234, Url.Content("~/js/loginPage.js"), 4234, 33, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("></script>");
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
