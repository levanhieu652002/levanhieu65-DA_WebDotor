#pragma checksum "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "282c5f81ce3f789b9f0ea73abbee727172bf0ed3"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Admin_Views_HoiDaps_Details), @"mvc.1.0.view", @"/Areas/Admin/Views/HoiDaps/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"282c5f81ce3f789b9f0ea73abbee727172bf0ed3", @"/Areas/Admin/Views/HoiDaps/Details.cshtml")]
    public class Areas_Admin_Views_HoiDaps_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebAppYte.Models.HoiDap>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
#nullable restore
#line 3 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
  
    ViewBag.Title = "Details";
    Layout = "~/Areas/Admin/Views/Shared/_LayoutAd.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<h2>Chi tiết</h2>\n\n<div>\n   \n    <hr />\n    <dl class=\"dl-horizontal\">\n        <dt>\n          Tên bệnh nhân\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 19 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
       Write(Html.DisplayFor(model => model.MabnNavigation.Tenbn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n            Tên bác sĩ\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 27 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
       Write(Html.DisplayFor(model => model.MandNavigation.Tendn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n          Câu hỏi\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 35 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
       Write(Html.DisplayFor(model => model.Hoi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n         Trả lời\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 43 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
       Write(Html.DisplayFor(model => model.Dap));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n            Ngày hỏi\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 51 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ngayhoi));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n           Ngày trả lời\n        </dt>\n\n        <dd>\n            ");
#nullable restore
#line 59 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
       Write(Html.DisplayFor(model => model.Ngaytl));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n        </dd>\n\n        <dt>\n          Trạng thái\n        </dt>\n\n        <dd>\n");
#nullable restore
#line 67 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
               if (Model.Trangthai == 0)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5 style=\"color:red\">Chưa trả lời</h5> ");
#nullable restore
#line 69 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
                                                        }
                            if (Model.Trangthai == 1)
                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5 style=\"color:red\">Đã trả lời</h5> ");
#nullable restore
#line 72 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
                                                      } 

#line default
#line hidden
#nullable disable
            WriteLiteral("        </dd>\n\n    </dl>\n</div>\n<p>\n   \n    ");
#nullable restore
#line 79 "D:\DA\WebAppYte\WebAppYte\Areas\Admin\Views\HoiDaps\Details.cshtml"
Write(Html.ActionLink("Quay lại", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n</p>\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebAppYte.Models.HoiDap> Html { get; private set; }
    }
}
#pragma warning restore 1591
