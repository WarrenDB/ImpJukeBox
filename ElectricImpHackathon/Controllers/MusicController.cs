﻿using System;
using System.Collections.Generic;
using System.EnterpriseServices.Internal;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using ElectricImpHackathon.Models;

namespace ElectricImpHackathon.Controllers
{
    public class MusicController : Controller
    {
        private MusicContext Context = new MusicContext();
        //
        // GET: /Music/

        private void SendSongToImp(string song)
        {
            System.Net.WebRequest.Create("https://agent.electricimp.com/qcd3tqH2yirA?led=" + song).BeginGetResponse(null, null);
        }

        private List<SongTrack> GetRandomSongs(int number)
        {
            var rand = new Random();
            return Context.SongTracks.ToArray().OrderBy(x => rand.NextDouble()).Take(number).ToList();
        }

        private SongTrack GetSongById(int id)
        {
            return Context.SongTracks.FirstOrDefault(x => x.ID == id);
        }

        public ViewResult Go()
        {
            var requestString = Request.Params["body"];
            if (string.IsNullOrEmpty(requestString)) return View();
            var requestTokens = requestString.Split(' ');
            switch (requestTokens[0].ToLower())
            {
                case "play":
                    return PlaySong(requestTokens.Length > 1 ? requestTokens[1] : null);
                case "list":
                    return ListSongs();
                case "random":
                    return PlaySong(null);
                default:
                    return View();

            }
        }

        public ViewResult PlaySong(string songId)
        {
            SongTrack song;
            int ID;
            
            if (string.IsNullOrEmpty(songId) || !int.TryParse(songId, out ID))
            {
                song = GetRandomSongs(1).First();
                SendSongToImp(song.Data);
            }
            else
            {
                song = GetSongById(ID);
                if (song != null)
                {
                    SendSongToImp(song.Data);
                }
                else
                {
                    return View("SongNotFound");
                }
            }
            return View("PlaySong", song);
        }

        public ViewResult ListSongs()
        {
            var randomCollection = GetRandomSongs(5);
            return View("ListSongs", randomCollection);
        }

        public ViewResult SongNotFound()
        {
            return View();
        }
    }
}
