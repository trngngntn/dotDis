#pragma checksum "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1f06d71df7d53e17f1d791cedd5b43c7f0fe22fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Login_Index), @"mvc.1.0.view", @"/Views/Login/Index.cshtml")]
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
#line 1 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\_ViewImports.cshtml"
using dotdis;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\_ViewImports.cshtml"
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1f06d71df7d53e17f1d791cedd5b43c7f0fe22fc", @"/Views/Login/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7131d8d06665ee11de7040b7069ac5c5a863a366", @"/Views/_ViewImports.cshtml")]
    public class Views_Login_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("login__form login__form--login"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Authorize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
  
ViewData["Title"] = "Login";

#line default
#line hidden
#nullable disable
            DefineSection("head", async() => {
                WriteLiteral("\r\n    <link rel=\"apple-touch-icon\" sizes=\"180x180\"");
                BeginWriteAttribute("href", " href=\'", 103, "\'", 152, 1);
#nullable restore
#line 6 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 110, Url.Content("~/img/apple-touch-icon.png"), 110, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"32x32\"");
                BeginWriteAttribute("href", " href=\'", 207, "\'", 253, 1);
#nullable restore
#line 7 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 214, Url.Content("~/img/favicon-32x32.png"), 214, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"16x16\"");
                BeginWriteAttribute("href", " href=\'", 308, "\'", 354, 1);
#nullable restore
#line 8 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 315, Url.Content("~/img/favicon-16x16.png"), 315, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"manifest\"");
                BeginWriteAttribute("href", " href=\'", 382, "\'", 427, 1);
#nullable restore
#line 9 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 389, Url.Content("~/img/site.webmanifest"), 389, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">    \r\n    <link");
                BeginWriteAttribute("href", " href=\'", 444, "\'", 482, 1);
#nullable restore
#line 10 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 451, Url.Content("~/css/index.css"), 451, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\'", 530, "\'", 571, 1);
#nullable restore
#line 11 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 537, Url.Content("~/css/fontIcon.css"), 537, 34, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            );
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f06d71df7d53e17f1d791cedd5b43c7f0fe22fc7365", async() => {
                WriteLiteral("\r\n    <main class=\"login\">\r\n    <div class=\"home__header__logo-box\">\r\n            <img");
                BeginWriteAttribute("src", " src=\'", 705, "\'", 742, 1);
#nullable restore
#line 16 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 711, Url.Content("~/img/logo1.png"), 711, 31, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" alt=\"logo\" class=\"home__header__logo\">\r\n        </div>\r\n        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "1f06d71df7d53e17f1d791cedd5b43c7f0fe22fc8184", async() => {
                    WriteLiteral(@"
            <div class=""login__form__content"">
                <div>
                    <h3 class=""text__header__primary"">
                        Welcome back!
                    </h3>
                    <h4 class=""text__header__secondary"">
                        We're so excited to see you again!
                    </h4>
                    <div class=""auth__input__wrapper"">
                        <label class=""auth__input--label"" for=""username"">Email or Phone number</label>
                        <input class=""auth__input--input"" id=""username"" type=""text"" name=""username"">
                    </div>
                    <div class=""auth__input__wrapper"">
                        <label class=""auth__input--label"" for=""password"">password</label>
                        <input class=""auth__input--input"" id=""password"" type=""password"" name=""passwd"">
                    </div>
                    <div class=""login__form--forgot-password-wrapper"">
                        <a class=""login__fo");
                    WriteLiteral(@"rm--forgot-password"" href=""#"">Forgot your password?</a>
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
                        <span class=""login__form--register-label"">Need an account?</span>
                        <a class=""login__form--register-link"" href=""/Register"">Register</a>
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
            BeginWriteAttribute("src", " src=\'", 2855, "\'", 2894, 1);
#nullable restore
#line 56 "D:\FPT Major\Semester 5\PRN292 - .NET and C#\dotDis\Git\dotDis\Views\Login\Index.cshtml"
WriteAttributeValue("", 2861, Url.Content("~/js/loginPage.js"), 2861, 33, false);

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
