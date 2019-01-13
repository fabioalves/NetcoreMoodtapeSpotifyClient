using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentSpotifyApi;
using FluentSpotifyApi.Model;

namespace NetMoodtapeSpotifyClient.Service {
    public class ArtistService : IArtistService
    {
        private readonly IFluentSpotifyClient _spotifyClient;
        public ArtistService(IFluentSpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

    }
}