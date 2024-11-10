#pragma checksum "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "6fed94930f47945a5aa2165e484563eaf092568c"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Bacsi_Lichdangcho), @"mvc.1.0.view", @"/Views/Bacsi/Lichdangcho.cshtml")]
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
#line 2 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
using Microsoft.AspNetCore.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
using System.Text.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
using WebAppYte.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6fed94930f47945a5aa2165e484563eaf092568c", @"/Views/Bacsi/Lichdangcho.cshtml")]
    public class Views_Bacsi_Lichdangcho : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<WebAppYte.DAO.LichKham>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\n");
            WriteLiteral("\n");
#nullable restore
#line 10 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
  
    ViewBag.Title = "Kiemtralichhen";
    Layout = "~/Views/Shared/_Layout.cshtml";
    var httpContext = HttpContextAccessor.HttpContext;
    var uJson = httpContext.Session.GetString("userBS");
    var userBS = !string.IsNullOrEmpty(uJson) ? JsonSerializer.Deserialize<NguoiDung>(uJson) : null;

#line default
#line hidden
#nullable disable
            WriteLiteral("\n<hr />\n<h2>DANH SÁCH LỊCH HẸN</h2>\n<hr />\n<h4>\n    <a");
            BeginWriteAttribute("href", " href=\"", 584, "\"", 652, 1);
#nullable restore
#line 22 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
WriteAttributeValue("", 591, Url.Action("Lichdangcho", "Bacsi", new { id = userBS.Mand }), 591, 61, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">LỊCH CHƯA XÁC NHẬN</a>&nbsp;||\n    <a");
            BeginWriteAttribute("href", " href=\"", 691, "\"", 761, 1);
#nullable restore
#line 23 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
WriteAttributeValue("", 698, Url.Action("Lichdaxacnhan", "Bacsi", new { id = userBS.Mand }), 698, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">LỊCH ĐÃ XÁC NHẬN</a>&nbsp;||\n    <a");
            BeginWriteAttribute("href", " href=\"", 798, "\"", 868, 1);
#nullable restore
#line 24 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
WriteAttributeValue("", 805, Url.Action("Kiemtralichhen", "Bacsi", new { id = userBS.Mand}), 805, 63, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">TẤT CẢ LỊCH HẸN</a>\n</h4>\n<br />\n<table class=\"table table-bordered\">\n    <tr>\n        <th>\n            Người đặt lịch\n        </th>\n        <th>\n            Ngày sinh\n        </th>\n        <th>\n            Số điện thoại\n        </th>\n");
            WriteLiteral("        <th>\n            Nội dung cần tư vấn\n        </th>\n");
            WriteLiteral("        <th>\n            Ngày khám\n        </th>\n");
            WriteLiteral("        <th>\n            Ca khám\n        </th>\n        <th>\n            Hình thức\n        </th>\n        <th>\n            Trạng thái\n        </th>\n\n\n    </tr>\n\n");
#nullable restore
#line 66 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<tr>\n    <td>\n        ");
#nullable restore
#line 70 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(Html.DisplayFor(modelItem => item.tenbn));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 73 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(item.ngaysinh.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 76 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(Html.DisplayFor(modelItem => item.sdt));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 79 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(Html.DisplayFor(modelItem => item.mota));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n\n    <td>\n        ");
#nullable restore
#line 83 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(item.ngaykham.ToString("dd/MM/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 86 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(Html.DisplayFor(modelItem => item.ca));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n    <td>\n        ");
#nullable restore
#line 89 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
   Write(Html.DisplayFor(modelItem => item.hinhthuc));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n    </td>\n\n    <td>\n");
#nullable restore
#line 93 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
           if (@item.trangthai == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h5 style=\"color:blueviolet\">Đang chờ xác nhận. </h5>\r\n");
#nullable restore
#line 96 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
                    }
                    else if (@item.trangthai == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5 style=\"color:orangered\">Đã xác nhận lịch </h5> ");
#nullable restore
#line 99 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
                                                                   }
            else if (@item.trangthai == 2 || @item.trangthai == 4)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <h5 style=\"color:green\">Đã tư vấn xong. </h5>\r\n");
#nullable restore
#line 103 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
                    }
                    else if (@item.trangthai == 3)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <h5 style=\"color:red\">Đã hủy</h5> ");
#nullable restore
#line 106 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
                                                  } 

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\n    <td>\n");
#nullable restore
#line 109 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
           if (@item.trangthai == 0)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button");
            BeginWriteAttribute("class", " class=\"", 2759, "\"", 2767, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                    ");
#nullable restore
#line 112 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
               Write(Html.ActionLink("Xác nhận", "Xacnhanlichhen", new { id = item.madat }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </button> ");
#nullable restore
#line 113 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
                          }
            else if (@item.trangthai == 1)
            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                <button");
            BeginWriteAttribute("class", " class=\"", 2970, "\"", 2978, 0);
            EndWriteAttribute();
            WriteLiteral(">\n                    ");
#nullable restore
#line 117 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
               Write(Html.ActionLink("Cập nhật trạng thái", "Xacnhanlichhen", new { id = item.madat }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\n                </button>\n");
#nullable restore
#line 119 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
            }
            else if (@item.trangthai == 2 || @item.trangthai == 4)
            {
            }
            else if (@item.trangthai == 3)
            {
            } 

#line default
#line hidden
#nullable disable
            WriteLiteral("    </td>\n</tr>");
#nullable restore
#line 127 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
     }

#line default
#line hidden
#nullable disable
            WriteLiteral("</table>\n    Trang ");
#nullable restore
#line 129 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
      Write(Model.PageCount < Model.PageNumber ? 0 : Model.PageNumber);

#line default
#line hidden
#nullable disable
            WriteLiteral(" / ");
#nullable restore
#line 129 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
                                                                    Write(Model.PageCount);

#line default
#line hidden
#nullable disable
            WriteLiteral("\n\n    ");
#nullable restore
#line 131 "D:\DA\WebAppYte\WebAppYte\Views\Bacsi\Lichdangcho.cshtml"
Write(Html.PagedListPager(Model, page => Url.Action("Kiemtralichhen",
        new { page })));

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public IHttpContextAccessor HttpContextAccessor { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<WebAppYte.DAO.LichKham>> Html { get; private set; }
    }
}
#pragma warning restore 1591
