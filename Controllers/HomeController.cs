using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using FluentSpotifyApi;
using FluentSpotifyApi.AuthorizationFlows.AspNetCore.AuthorizationCode.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetMoodtapeSpotifyClient.Models;

namespace NetMoodtapeSpotifyClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFluentSpotifyClient fluentSpotifyClient;

        public HomeController(IFluentSpotifyClient fluentSpotifyClient)
        {
            this.fluentSpotifyClient = fluentSpotifyClient;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [Route("/signin-spotify/")]
        public ActionResult SigninSpotify(){
            return RedirectToAction("Signin", "Authentication");
        }

        [Authorize]
        public async Task<IActionResult> Playlists()
        {
            var userId = this.User.GetNameIdentifier();

            var model = (await this.fluentSpotifyClient.Me.Playlists.GetAsync(limit: 20, offset: 0))
                .Items
                .Select(item => new PlaylistListItemModel
                {
                    Id = item.Id,
                    Name = item.Name,
                    Owner = item.Owner?.DisplayName ?? item.Owner?.Id,
                    NumberOfTracks = (item.Tracks?.Total).GetValueOrDefault(),
                    IsPublic = item.Public,
                    IsCollaborative = item.Collaborative,
                    IsOwned = item.Owner?.Id == userId
                }).ToList();

            return this.View(model);
        }
    }
}
