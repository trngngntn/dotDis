#pragma checksum "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0d0e681e25aed744cf82378422f34eae851f20a7"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Login), @"mvc.1.0.view", @"/Views/Dashboard/Login.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"0d0e681e25aed744cf82378422f34eae851f20a7", @"/Views/Dashboard/Login.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7131d8d06665ee11de7040b7069ac5c5a863a366", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Login : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Authorize", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("method", "post", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition login-page"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
  
    ViewData["Title"] = "dotDis | Login";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("head", async() => {
                WriteLiteral("\r\n    <link rel=\"apple-touch-icon\" sizes=\"180x180\"");
                BeginWriteAttribute("href", " href=\'", 117, "\'", 166, 1);
#nullable restore
#line 6 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 124, Url.Content("~/img/apple-touch-icon.png"), 124, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"32x32\"");
                BeginWriteAttribute("href", " href=\'", 221, "\'", 267, 1);
#nullable restore
#line 7 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 228, Url.Content("~/img/favicon-32x32.png"), 228, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"icon\" type=\"image/png\" sizes=\"16x16\"");
                BeginWriteAttribute("href", " href=\'", 322, "\'", 368, 1);
#nullable restore
#line 8 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 329, Url.Content("~/img/favicon-16x16.png"), 329, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link rel=\"manifest\"");
                BeginWriteAttribute("href", " href=\'", 396, "\'", 441, 1);
#nullable restore
#line 9 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 403, Url.Content("~/img/site.webmanifest"), 403, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\r\n    <link");
                BeginWriteAttribute("href", " href=\'", 454, "\'", 525, 1);
#nullable restore
#line 10 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 461, Url.Content("~/css/dashboard/fontawesome-free/css/all.min.css"), 461, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"https://code.ionicframework.com/ionicons/2.0.1/css/ionicons.min.css\" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\'", 695, "\'", 775, 1);
#nullable restore
#line 12 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 702, Url.Content("~/css/dashboard/icheck-bootstrap/icheck-bootstrap.min.css"), 702, 73, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link");
                BeginWriteAttribute("href", " href=\'", 823, "\'", 878, 1);
#nullable restore
#line 13 "Z:\FPT Major\Semester 5\PRN292 - .NET and C#\Project\Git\dotDis\Views\Dashboard\Login.cshtml"
WriteAttributeValue("", 830, Url.Content("~/css/dashboard/adminlte.min.css"), 830, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\r\n    <link href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700\" rel=\"stylesheet\" type=\"text/css\" />\r\n");
            }
            );
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0e681e25aed744cf82378422f34eae851f20a78308", async() => {
                WriteLiteral(@"
    <div class=""login-box"">
        <div class=""login-logo"">
            <b>dot</b>Dis
        </div>
        <!-- /.login-logo -->
        <div class=""card"">
            <div class=""card-body login-card-body"">
                <p class=""login-box-msg"">Sign in to start your session</p>

                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "0d0e681e25aed744cf82378422f34eae851f20a78887", async() => {
                    WriteLiteral(@"
                    <div class=""input-group mb-3"">
                        <input type=""text"" class=""form-control"" id=""username"" name=""username"" placeholder=""Username"">
                        <div class=""input-group-append"">
                            <div class=""input-group-text""></div>
                        </div>
                    </div>
                    <div class=""input-group mb-3"">
                        <input type=""password"" class=""form-control"" id=""password"" name=""passwd"" placeholder=""Password"">
                        <div class=""input-group-append"">
                            <div class=""input-group-text""></div>
                        </div>
                    </div>
                    <div class=""row"">
                        <div class=""col-8"">
                            <div class=""icheck-primary"">
                                <input type=""checkbox"" id=""remember"">
                                <label for=""remember"">
                                    Remem");
                    WriteLiteral(@"ber Me
                                </label>
                            </div>
                        </div>
                        <!-- /.col -->
                        <div class=""col-4"">
                            <button type=""submit"" class=""btn btn-primary btn-block"">Sign In</button>
                        </div>
                        <!-- /.col -->
                    </div>
                ");
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_0.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
                __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Method = (string)__tagHelperAttribute_1.Value;
                __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n            </div>\r\n            <!-- /.login-card-body -->\r\n        </div>\r\n    </div>\r\n    <!-- /.login-box -->\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
