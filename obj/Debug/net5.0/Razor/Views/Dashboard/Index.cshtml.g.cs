#pragma checksum "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "9992b48791741cc2eafa588cb9b61d765f14a1d5"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Dashboard_Index), @"mvc.1.0.view", @"/Views/Dashboard/Index.cshtml")]
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
using Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"9992b48791741cc2eafa588cb9b61d765f14a1d5", @"/Views/Dashboard/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7131d8d06665ee11de7040b7069ac5c5a863a366", @"/Views/_ViewImports.cshtml")]
    public class Views_Dashboard_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline ml-3"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("hold-transition sidebar-mini layout-fixed layout-navbar-fixed layout-footer-fixed"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 1 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
  
    ViewData["Title"] = "dotDis | Dashboard";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n");
            DefineSection("head", async() => {
                WriteLiteral("\n    <link rel=\"apple-touch-icon\" sizes=\"180x180\"");
                BeginWriteAttribute("href", " href=\'", 116, "\'", 165, 1);
#nullable restore
#line 6 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 123, Url.Content("~/img/apple-touch-icon.png"), 123, 42, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"icon\" type=\"image/png\" sizes=\"32x32\"");
                BeginWriteAttribute("href", " href=\'", 219, "\'", 265, 1);
#nullable restore
#line 7 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 226, Url.Content("~/img/favicon-32x32.png"), 226, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"icon\" type=\"image/png\" sizes=\"16x16\"");
                BeginWriteAttribute("href", " href=\'", 319, "\'", 365, 1);
#nullable restore
#line 8 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 326, Url.Content("~/img/favicon-16x16.png"), 326, 39, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link rel=\"manifest\"");
                BeginWriteAttribute("href", " href=\'", 392, "\'", 437, 1);
#nullable restore
#line 9 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 399, Url.Content("~/img/site.webmanifest"), 399, 38, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(">\n    <link");
                BeginWriteAttribute("href", " href=\'", 449, "\'", 520, 1);
#nullable restore
#line 10 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 456, Url.Content("~/css/dashboard/fontawesome-free/css/all.min.css"), 456, 64, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\n    <link");
                BeginWriteAttribute("href", " href=\'", 567, "\'", 653, 1);
#nullable restore
#line 11 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 574, Url.Content("~/css/dashboard/overlayScrollbars/css/OverlayScrollbars.min.css"), 574, 79, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\n    <link");
                BeginWriteAttribute("href", " href=\'", 700, "\'", 755, 1);
#nullable restore
#line 12 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 707, Url.Content("~/css/dashboard/adminlte.min.css"), 707, 48, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(" rel=\"stylesheet\" type=\"text/css\" />\n    <link href=\"https://fonts.googleapis.com/css?family=Source+Sans+Pro:300,400,400i,700\" rel=\"stylesheet\" type=\"text/css\" />\n");
            }
            );
            WriteLiteral("\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9992b48791741cc2eafa588cb9b61d765f14a1d57427", async() => {
                WriteLiteral(@"
    <div class=""wrapper"">
        <!-- Navbar -->
        <nav class=""main-header navbar navbar-expand navbar-white navbar-light"">
            <!-- Left navbar links -->
            <ul class=""navbar-nav"">
                <li class=""nav-item"">
                    <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
                </li>
                <li class=""nav-item d-none d-sm-inline-block"">
                    <a href=""dashboard.html"" class=""nav-link"">Home</a>
                </li>
                <li class=""nav-item d-none d-sm-inline-block"">
                    <a href=""#"" class=""nav-link"">Contact</a>
                </li>
            </ul>

            <!-- SEARCH FORM -->
            ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "9992b48791741cc2eafa588cb9b61d765f14a1d58461", async() => {
                    WriteLiteral(@"
                <div class=""input-group input-group-sm"">
                    <input class=""form-control form-control-navbar"" type=""search"" placeholder=""Search""
                        aria-label=""Search"">
                    <div class=""input-group-append"">
                        <button class=""btn btn-navbar"" type=""submit"">
                            <i class=""fas fa-search""></i>
                        </button>
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
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral(@"

            <!-- Right navbar links -->
            <ul class=""navbar-nav ml-auto"">
                <!-- Messages Dropdown Menu -->
                <li class=""nav-item dropdown"">
                    <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
                        <i class=""far fa-comments""></i>
                        <span class=""badge badge-danger navbar-badge"">3</span>
                    </a>
                    <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                        <a href=""#"" class=""dropdown-item"">
                            <!-- Message Start -->
                            <div class=""media"">
                                <img src=""dist/img/user1-128x128.jpg"" alt=""User Avatar""
                                    class=""img-size-50 mr-3 img-circle"">
                                <div class=""media-body"">
                                    <h3 class=""dropdown-item-title"">
                                        Brad Diesel
                            ");
                WriteLiteral(@"            <span class=""float-right text-sm text-danger""><i class=""fas fa-star""></i></span>
                                    </h3>
                                    <p class=""text-sm"">Call me whenever you can...</p>
                                    <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                                </div>
                            </div>
                            <!-- Message End -->
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <!-- Message Start -->
                            <div class=""media"">
                                <img src=""dist/img/user8-128x128.jpg"" alt=""User Avatar""
                                    class=""img-size-50 img-circle mr-3"">
                                <div class=""media-body"">
                                    <h3 class=""dropdown-item-title"">
                            ");
                WriteLiteral(@"            John Pierce
                                        <span class=""float-right text-sm text-muted""><i class=""fas fa-star""></i></span>
                                    </h3>
                                    <p class=""text-sm"">I got your message bro</p>
                                    <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                                </div>
                            </div>
                            <!-- Message End -->
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <!-- Message Start -->
                            <div class=""media"">
                                <img src=""dist/img/user3-128x128.jpg"" alt=""User Avatar""
                                    class=""img-size-50 img-circle mr-3"">
                                <div class=""media-body"">
                                    <h3 class=""drop");
                WriteLiteral(@"down-item-title"">
                                        Nora Silvester
                                        <span class=""float-right text-sm text-warning""><i
                                                class=""fas fa-star""></i></span>
                                    </h3>
                                    <p class=""text-sm"">The subject goes here</p>
                                    <p class=""text-sm text-muted""><i class=""far fa-clock mr-1""></i> 4 Hours Ago</p>
                                </div>
                            </div>
                            <!-- Message End -->
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item dropdown-footer"">See All Messages</a>
                    </div>
                </li>
                <!-- Notifications Dropdown Menu -->
                <li class=""nav-item dropdown"">
                    <a class=""nav-link"" data-toggle=""dropdown"" href=""#"">
            ");
                WriteLiteral(@"            <i class=""far fa-bell""></i>
                        <span class=""badge badge-warning navbar-badge"">15</span>
                    </a>
                    <div class=""dropdown-menu dropdown-menu-lg dropdown-menu-right"">
                        <span class=""dropdown-item dropdown-header"">15 Notifications</span>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-envelope mr-2""></i> 4 new messages
                            <span class=""float-right text-muted text-sm"">3 mins</span>
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-users mr-2""></i> 8 friend requests
                            <span class=""float-right text-muted text-sm"">12 hours</span>
                        </a>
                        <div class=""dropdown-divider""></div>
      ");
                WriteLiteral(@"                  <a href=""#"" class=""dropdown-item"">
                            <i class=""fas fa-file mr-2""></i> 3 new reports
                            <span class=""float-right text-muted text-sm"">2 days</span>
                        </a>
                        <div class=""dropdown-divider""></div>
                        <a href=""#"" class=""dropdown-item dropdown-footer"">See All Notifications</a>
                    </div>
                </li>
                <li class=""nav-item"">
                    <a class=""nav-link"" data-widget=""control-sidebar"" data-slide=""true"" href=""#"" role=""button""><i
                            class=""fas fa-th-large""></i></a>
                </li>
            </ul>
        </nav>
        <!-- /.navbar -->

        <!-- Main Sidebar Container -->
        <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
            <!-- Brand Logo -->
            <a href=""index3.html"" class=""brand-link"">
                <img");
                BeginWriteAttribute("src", " src=\'", 8375, "\'", 8427, 1);
#nullable restore
#line 149 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 8381, Url.Content("~/img/dashboard/dotDisLogo.png"), 8381, 46, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" alt=""dotDis Logo"" class=""brand-image img-circle elevation-3""
                    style=""opacity: .8"">
                <span class=""brand-text font-weight-light"">dotDis</span>
            </a>

            <!-- Sidebar -->
            <div class=""sidebar"">
                <!-- Sidebar user panel (optional) -->
                <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
                    <div class=""image"">
                        <img");
                BeginWriteAttribute("src", " src=\'", 8871, "\'", 8920, 1);
#nullable restore
#line 159 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
WriteAttributeValue("", 8877, Url.Content("~/img/dashboard/profile.jpg"), 8877, 43, false);

#line default
#line hidden
#nullable disable
                EndWriteAttribute();
                WriteLiteral(@" class=""img-circle elevation-2"" alt=""User Image"">
                    </div>
                    <div class=""info"">
                        <a href=""#"" class=""d-block"">Luan Le</a>
                    </div>
                </div>

                <!-- Sidebar Menu -->
                <nav class=""mt-2"">
                    <ul class=""nav nav-pills nav-sidebar flex-column"" data-widget=""treeview"" role=""menu""
                        data-accordion=""false"">
                        <!-- Add icons to the links using the .nav-icon class
                   with font-awesome or any other icon font library -->
                        <li class=""nav-item has-treeview menu-open"">
                            <a href=""#"" class=""nav-link active"">
                                <i class=""nav-icon fas fa-tachometer-alt""></i>
                                <p>
                                    Dashboard
                                </p>
                            </a>
                        </li>

                     ");
                WriteLiteral(@"   <li class=""nav-header"">DATABASE</li>
                        <li class=""nav-item"">
                            <a href=""pages/gallery.html"" class=""nav-link"">
                                <i class=""nav-icon far fa-image""></i>
                                <p>
                                    Gallery
                                </p>
                            </a>
                        </li>
                    </ul>
                </nav>
                <!-- /.sidebar-menu -->
            </div>
            <!-- /.sidebar -->
        </aside>

        <!-- Content Wrapper. Contains page content -->
        <div class=""content-wrapper"">
            <!-- Content Header (Page header) -->
            <div class=""content-header"">
                <div class=""container-fluid"">
                    <div class=""row mb-2"">
                        <div class=""col-sm-6"">
                            <h1 class=""m-0 text-dark"">Dashboard</h1>
                        </div><!-- /.col -->
                     ");
                WriteLiteral(@"   <div class=""col-sm-6"">
                            <ol class=""breadcrumb float-sm-right"">
                                <li class=""breadcrumb-item""><a href=""#"">Home</a></li>
                                <li class=""breadcrumb-item active"">Dashboard</li>
                            </ol>
                        </div><!-- /.col -->
                    </div><!-- /.row -->
                </div><!-- /.container-fluid -->
            </div>
            <!-- /.content-header -->

            <!-- Main content -->
            <section class=""content"">
                <div class=""container-fluid"">
                    <!-- Info boxes -->
                    <div class=""row"">
                        <div class=""col-12 col-sm-6 col-md-4"">
                            <div class=""info-box"">
                                <span class=""info-box-icon bg-info elevation-1""><i class=""fas fa-cog""></i></span>

                                <div class=""info-box-content"">
                                    <span class=");
                WriteLiteral("\"info-box-text\">Users</span>\n                                    <span class=\"info-box-number\">\n                                        ");
#nullable restore
#line 229 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
                                   Write(ViewData["Users"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"
                                    </span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                        <div class=""col-12 col-sm-6 col-md-4"">
                            <div class=""info-box mb-3"">
                                <span class=""info-box-icon bg-danger elevation-1""><i
                                        class=""fas fa-thumbs-up""></i></span>

                                <div class=""info-box-content"">
                                    <span class=""info-box-text"">Rooms</span>
                                    <span class=""info-box-number"">");
#nullable restore
#line 244 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
                                                             Write(ViewData["Rooms"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->

                        <!-- fix for small devices only -->
                        <div class=""clearfix hidden-md-up""></div>

                        <div class=""col-12 col-sm-6 col-md-4"">
                            <div class=""info-box mb-3"">
                                <span class=""info-box-icon bg-success elevation-1""><i
                                        class=""fas fa-shopping-cart""></i></span>

                                <div class=""info-box-content"">
                                    <span class=""info-box-text"">Messages</span>
                                    <span class=""info-box-number"">");
#nullable restore
#line 262 "/home/trngngntn/Git/dotDis/Views/Dashboard/Index.cshtml"
                                                             Write(ViewData["Messages"]);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"</span>
                                </div>
                                <!-- /.info-box-content -->
                            </div>
                            <!-- /.info-box -->
                        </div>
                        <!-- /.col -->
                    </div>
                    <!-- /.row -->
                </div>
                <!--/. container-fluid -->
            </section>
            <!-- /.content -->
        </div>
        <!-- /.content-wrapper -->

        <!-- Control Sidebar -->
        <aside class=""control-sidebar control-sidebar-dark"">
            <!-- Control sidebar content goes here -->
        </aside>
        <!-- /.control-sidebar -->

        <!-- Main Footer -->
        <footer class=""main-footer"">
            <strong>Copyright &copy; 2021-2021 <a href=""http://dotdis.duckdns.org"">dotDis</a>.</strong>
            All rights reserved.
            <div class=""float-right d-none d-sm-inline-block"">
                <b>Version</b> 1.0.0
            </div>
       ");
                WriteLiteral(@" </footer>
    </div>
    <!-- ./wrapper -->

    <!-- REQUIRED SCRIPTS -->
    <!-- jQuery -->
    <script src=""plugins/jquery/jquery.min.js""></script>
    <!-- Bootstrap -->
    <script src=""plugins/bootstrap/js/bootstrap.bundle.min.js""></script>
    <!-- overlayScrollbars -->
    <script src=""plugins/overlayScrollbars/js/jquery.overlayScrollbars.min.js""></script>
    <!-- AdminLTE App -->
    <script src=""dist/js/adminlte.js""></script>

    <!-- OPTIONAL SCRIPTS -->
    <script src=""dist/js/demo.js""></script>

    <!-- PAGE PLUGINS -->
    <!-- jQuery Mapael -->
    <script src=""plugins/jquery-mousewheel/jquery.mousewheel.js""></script>
    <script src=""plugins/raphael/raphael.min.js""></script>
    <script src=""plugins/jquery-mapael/jquery.mapael.min.js""></script>
    <script src=""plugins/jquery-mapael/maps/usa_states.min.js""></script>
    <!-- ChartJS -->
    <script src=""plugins/chart.js/Chart.min.js""></script>

    <!-- PAGE SCRIPTS -->
    <script src=""dist/js/pages/dashboard2.js""></script>
");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
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
