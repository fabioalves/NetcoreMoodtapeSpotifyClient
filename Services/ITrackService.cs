using System.Collections.Generic;
using System.Threading.Tasks;
using FluentSpotifyApi.Model;

namespace NetMoodtapeSpotifyClient.Service
{
    public interface ITrackService
    {
        Task<List<FullTrack>> GetTopTracks(FullArtist artist, string country);
        Task<List<FullTrack>> SelectTracksByMood(List<FullTrack> tracks, float mood);
    }
}