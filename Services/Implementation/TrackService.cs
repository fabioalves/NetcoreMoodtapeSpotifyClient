using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentSpotifyApi;
using FluentSpotifyApi.Model;

namespace NetMoodtapeSpotifyClient.Service
{
    public class TrackService : ITrackService
    {
        private readonly IFluentSpotifyClient _spotifyClient;
        public TrackService(IFluentSpotifyClient spotifyClient)
        {
            _spotifyClient = spotifyClient;
        }

        public async Task<List<FullTrack>> GetTopTracks(FullArtist artist, string country)
        {
             return (await _spotifyClient.Artist(artist.Id).TopTracks.GetAsync(country)).Items.ToList();
        }

        public async Task<List<FullTrack>> SelectTracksByMood(List<FullTrack> tracks, float mood)
        {
            try {
            var selectedTracksIds = new List<string>();
            tracks = tracks.OrderBy(item => new Random().Next()).ToList();
            
            while(tracks.Any())
            {
                var splittedList = new List<FullTrack>();    
                splittedList.AddRange(tracks.Take(50).ToList());
                tracks = tracks.Skip(50).ToList();
                var ids = splittedList.Select(t => t.Id).ToArray();
                var audioFeatures = await _spotifyClient.Tracks(ids).AudioFeatures.GetAsync();
                foreach(var feature in audioFeatures.Items)
                {
                    if(mood < 0.10){
                        if( (0 <= feature.Valence && feature.Valence <= mood * 0.15) &&
                            (feature.Danceability <= mood * 8) &&
                            (feature.Energy <= mood * 10))                        
                        {
                            selectedTracksIds.Add(feature.Id);
                        }
                    } 
                    else if(0.10 <= mood && mood <= 0.25){
                        if( (mood - 0.075 <= feature.Valence && feature.Valence <= mood + 0.075) &&
                            (feature.Danceability <= mood * 4) &&
                            (feature.Energy <= mood * 5))                        
                        {
                            selectedTracksIds.Add(feature.Id);
                        }
                    }
                    else if(0.25 <= mood && mood <= 0.50){
                        if( (mood - 0.05 <= feature.Valence && feature.Valence <= mood + 0.05) &&
                            (feature.Danceability <= mood * 1.75) &&
                            (feature.Energy <= mood * 1.75))                        
                        {
                            selectedTracksIds.Add(feature.Id);
                        }
                    }
                    else if(0.50 <= mood && mood < 0.75){
                        if( (mood - 0.075 <= feature.Valence && feature.Valence <= mood + 0.075) &&
                            (feature.Danceability >= mood/2.5) &&
                            (feature.Energy >= mood/2))                        
                        {
                            selectedTracksIds.Add(feature.Id);
                        }
                    }
                    else if(0.75 <= mood && mood < 0.9){
                        if( (mood - 0.075 <= feature.Valence && feature.Valence <= mood + 0.075) &&
                            (feature.Danceability >= mood/2) &&
                            (feature.Energy >= mood/1.75))                        
                        {
                            selectedTracksIds.Add(feature.Id);
                        }
                    }
                    else if(mood >= 0.90){
                        if( (mood - 0.15 <= feature.Valence && feature.Valence <= 1) &&
                            (feature.Danceability <= mood/1.75) &&
                            (feature.Energy >= mood/1.5))                        
                        {
                            selectedTracksIds.Add(feature.Id);
                        }
                    }

                }
            

            }

                return (await _spotifyClient.Tracks(selectedTracksIds.Take(30)).GetAsync()).Items.ToList();
            } catch(Exception ex){
                throw;
            }
        }
    }
}