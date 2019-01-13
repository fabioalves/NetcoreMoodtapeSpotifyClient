using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentSpotifyApi;
using FluentSpotifyApi.Builder.Me.Personalization.Top;
using FluentSpotifyApi.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetMoodtapeSpotifyClient.Service;

namespace NetMoodtapeSpotifyClient.Controllers
{
    public class MoodtapeController : Controller
    {
        private readonly IFluentSpotifyClient _spotifyClient;
        private readonly IUserService _userService;
        private readonly IArtistService _artistService;
        private readonly ITrackService _trackService;
        public MoodtapeController(IFluentSpotifyClient spotifyClient, 
                                    IUserService userService, IArtistService artistService,
                                    ITrackService trackService){
            _spotifyClient = spotifyClient;
            _userService = userService;
            _artistService = artistService;
            _trackService = trackService;
        }
        [Authorize]
        public ActionResult Index(){
            return View();
        }
        private float GetMood(int rating){
            float mood = 0;
            if(rating == 1)
                mood = 0.5f;
            if(rating == 2)
                mood = 0.1f;
            if(rating == 3)
                mood = 0.3f;
            if(rating == 4)
                mood = 0.6f;
            if(rating == 5)
                mood = 0.8f;
            if(rating == 6)
                mood = 1;
            return mood;
        }

        [Authorize]
        public async Task<ActionResult> Select(int rating){
            var mood = GetMood(rating);

            var topArtists = await _userService.GetTopArtistsFromUser();
            var topTracks = await GetTopTracks(topArtists);
            var tracksByMood = await _trackService.SelectTracksByMood(topTracks, mood);

            return View(tracksByMood);
        }
        private async Task<List<FullTrack>> GetTopTracks(List<FullArtist> topArtists){
            var topTracks = new List<FullTrack>();
            foreach(var artist in topArtists){
                var topTracksPerArtist = await _trackService.GetTopTracks(artist, "br");
                topTracks.AddRange(topTracksPerArtist);
            }
            return topTracks;
        }


    }
}