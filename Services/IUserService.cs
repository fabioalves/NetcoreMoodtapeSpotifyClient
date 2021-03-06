using System.Collections.Generic;
using System.Threading.Tasks;
using FluentSpotifyApi.Model;

namespace NetMoodtapeSpotifyClient.Service
{
    public interface IUserService
    {
         Task<List<FullArtist>> GetTopArtistsFromUser();
    }
}