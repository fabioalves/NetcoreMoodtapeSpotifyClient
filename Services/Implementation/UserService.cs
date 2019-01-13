using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentSpotifyApi;
using FluentSpotifyApi.Builder.Me.Personalization.Top;
using FluentSpotifyApi.Model;

namespace NetMoodtapeSpotifyClient.Service
{
    public class UserService : IUserService
    {
        private readonly IFluentSpotifyClient _spotifyClient;
        public UserService(IFluentSpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

        public async Task<List<FullArtist>> GetTopArtistsFromUser()
        {
            var topArtistsFromUser = new List<FullArtist>();
            topArtistsFromUser = await GetTopArtists(topArtistsFromUser);
            topArtistsFromUser = await GetFollowedArtists(topArtistsFromUser);
            return topArtistsFromUser;
        }

        private async Task<List<FullArtist>> GetTopArtists(List<FullArtist> topArtists){
            try 
            {
                var ranges = new TimeRange[]{TimeRange.ShortTerm, TimeRange.MediumTerm, TimeRange.LongTerm};
                foreach(var range in ranges){
                    var topArtistsPerRange = (await _spotifyClient.Me.Personalization.TopArtists.GetAsync(10, 0,range));
                    foreach(var artist in topArtistsPerRange.Items)
                    {
                        if(!topArtists.Any(a => a.Id.Equals(artist)))
                            topArtists.Add(artist);
                    }
                }
                return topArtists;
            } 
            catch(Exception) 
            {
                throw;
            }
        }

        private async Task<List<FullArtist>> GetFollowedArtists(List<FullArtist> topArtists){
            try 
            {
                var followedArtists = (await _spotifyClient.Me.Following.Artists().GetAsync(50)).Page;
                foreach(var artist in followedArtists.Items){
                    if(!topArtists.Any(a => a.Id.Equals(artist)))
                        topArtists.Add(artist);
                }
                return topArtists;
            }
            catch(Exception)
            {
                throw;
            }
        }

    }
}