using FluentSpotifyApi;
using Microsoft.AspNetCore.Mvc;

namespace NetMoodtapeSpotifyClient.Controllers
{
    public class CallbackController : Controller
    {
        public IFluentSpotifyClient _spotifyClient { get; set; }
        public CallbackController(IFluentSpotifyClient spotifyClient){
            _spotifyClient = spotifyClient;
        }
        public ActionResult Index(){
            return View();
        }

    }
}