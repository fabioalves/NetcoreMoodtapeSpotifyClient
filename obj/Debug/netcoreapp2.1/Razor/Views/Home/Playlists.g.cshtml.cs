#pragma checksum "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "726328f0dc9522008731a7c01a32d6dbe76247fc"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Playlists), @"mvc.1.0.view", @"/Views/Home/Playlists.cshtml")]
[assembly:global::Microsoft.AspNetCore.Mvc.Razor.Compilation.RazorViewAttribute(@"/Views/Home/Playlists.cshtml", typeof(AspNetCore.Views_Home_Playlists))]
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
#line 1 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\_ViewImports.cshtml"
using NetMoodtapeSpotifyClient;

#line default
#line hidden
#line 2 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\_ViewImports.cshtml"
using NetMoodtapeSpotifyClient.Models;

#line default
#line hidden
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"726328f0dc9522008731a7c01a32d6dbe76247fc", @"/Views/Home/Playlists.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"cd28f2efe0e22f5266bd6dc862cc0d1f5835a1cd", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Playlists : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<NetMoodtapeSpotifyClient.Models.PlaylistListItemModel>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            BeginContext(75, 75, true);
            WriteLiteral("\r\n<table class=\"table table-striped\">\r\n    <tr>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(151, 40, false);
#line 6 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
       Write(Html.DisplayNameFor(model => model.Name));

#line default
#line hidden
            EndContext();
            BeginContext(191, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(235, 41, false);
#line 9 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
       Write(Html.DisplayNameFor(model => model.Owner));

#line default
#line hidden
            EndContext();
            BeginContext(276, 62, true);
            WriteLiteral("\r\n        </th>\r\n        <th class=\"text-right\">\r\n            ");
            EndContext();
            BeginContext(339, 50, false);
#line 12 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
       Write(Html.DisplayNameFor(model => model.NumberOfTracks));

#line default
#line hidden
            EndContext();
            BeginContext(389, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(433, 44, false);
#line 15 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
       Write(Html.DisplayNameFor(model => model.IsPublic));

#line default
#line hidden
            EndContext();
            BeginContext(477, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(521, 51, false);
#line 18 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
       Write(Html.DisplayNameFor(model => model.IsCollaborative));

#line default
#line hidden
            EndContext();
            BeginContext(572, 43, true);
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
            EndContext();
            BeginContext(616, 43, false);
#line 21 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
       Write(Html.DisplayNameFor(model => model.IsOwned));

#line default
#line hidden
            EndContext();
            BeginContext(659, 30, true);
            WriteLiteral("\r\n        </th>\r\n    </tr>\r\n\r\n");
            EndContext();
#line 25 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
            BeginContext(730, 48, true);
            WriteLiteral("        <tr>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(779, 39, false);
#line 29 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
           Write(Html.DisplayFor(modelItem => item.Name));

#line default
#line hidden
            EndContext();
            BeginContext(818, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(874, 40, false);
#line 32 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
           Write(Html.DisplayFor(modelItem => item.Owner));

#line default
#line hidden
            EndContext();
            BeginContext(914, 74, true);
            WriteLiteral("\r\n            </td>\r\n            <td class=\"text-right\">\r\n                ");
            EndContext();
            BeginContext(989, 49, false);
#line 35 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
           Write(Html.DisplayFor(modelItem => item.NumberOfTracks));

#line default
#line hidden
            EndContext();
            BeginContext(1038, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1094, 43, false);
#line 38 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsPublic));

#line default
#line hidden
            EndContext();
            BeginContext(1137, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1193, 50, false);
#line 41 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsCollaborative));

#line default
#line hidden
            EndContext();
            BeginContext(1243, 55, true);
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
            EndContext();
            BeginContext(1299, 42, false);
#line 44 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsOwned));

#line default
#line hidden
            EndContext();
            BeginContext(1341, 36, true);
            WriteLiteral("\r\n            </td>\r\n        </tr>\r\n");
            EndContext();
#line 47 "C:\Users\Fábio Alves\projetos\NetMoodtapeSpotifyClient\Views\Home\Playlists.cshtml"
    }

#line default
#line hidden
            BeginContext(1384, 10, true);
            WriteLiteral("\r\n</table>");
            EndContext();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<NetMoodtapeSpotifyClient.Models.PlaylistListItemModel>> Html { get; private set; }
    }
}
#pragma warning restore 1591