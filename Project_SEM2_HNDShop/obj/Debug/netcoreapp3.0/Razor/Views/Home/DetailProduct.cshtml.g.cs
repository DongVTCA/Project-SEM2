#pragma checksum "D:\23-11\Project-SEM2\Project_SEM2_HNDShop\Views\Home\DetailProduct.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1fbbfce3fabc10e90eafb6bd64b8be776052c6ae"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_DetailProduct), @"mvc.1.0.view", @"/Views/Home/DetailProduct.cshtml")]
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
#line 1 "D:\23-11\Project-SEM2\Project_SEM2_HNDShop\Views\_ViewImports.cshtml"
using Project_SEM2_HNDShop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\23-11\Project-SEM2\Project_SEM2_HNDShop\Views\_ViewImports.cshtml"
using Project_SEM2_HNDShop.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"1fbbfce3fabc10e90eafb6bd64b8be776052c6ae", @"/Views/Home/DetailProduct.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bde3ebbaa628fe143384f9c49173c67dc0cfe14b", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_DetailProduct : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Project_SEM2_HNDShop.DTO.ProductDto>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\23-11\Project-SEM2\Project_SEM2_HNDShop\Views\Home\DetailProduct.cshtml"
 foreach (var item in Model)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <p>");
#nullable restore
#line 5 "D:\23-11\Project-SEM2\Project_SEM2_HNDShop\Views\Home\DetailProduct.cshtml"
  Write(item.product.ProDesc);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n");
#nullable restore
#line 6 "D:\23-11\Project-SEM2\Project_SEM2_HNDShop\Views\Home\DetailProduct.cshtml"
    
}

#line default
#line hidden
#nullable disable
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Project_SEM2_HNDShop.DTO.ProductDto>> Html { get; private set; }
    }
}
#pragma warning restore 1591
