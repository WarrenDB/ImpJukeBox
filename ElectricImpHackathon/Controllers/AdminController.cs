using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectricImpHackathon.Models;

namespace ElectricImpHackathon.Controllers
{
    public class AdminController : Controller
    {
        private MusicContext Context = new MusicContext();

        //
        // GET: /Admin/

        public ActionResult Index()
        {
            return View(Context.SongTracks.ToList());
        }

        //
        // GET: /Admin/Details/5

        public ActionResult Details(int id)
        {
            return View(Context.SongTracks.FirstOrDefault(track => track.ID == id));
        }

        //
        // GET: /Admin/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Admin/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                var song = new SongTrack()
                {
                    Data = collection.Get("Data"),
                    SongName = collection.Get("SongName")
                };

                Context.SongTracks.Add(song);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Admin/Edit/5

        public ActionResult Edit(int id)
        {
            return View(Context.SongTracks.FirstOrDefault(track => track.ID == id));
        }

        //
        // POST: /Admin/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                var modSong = Context.SongTracks.FirstOrDefault(track => track.ID == id);
                modSong.SongName = collection["SongName"];
                modSong.Data = collection["Data"];
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
        }

        //
        // GET: /Admin/Delete/5

        public ActionResult Delete(int id)
        {
            try
            {
                var doomedSong = Context.SongTracks.FirstOrDefault(track => track.ID == id);
                Context.SongTracks.Remove(doomedSong);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // POST: /Admin/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                var doomedSong = Context.SongTracks.FirstOrDefault(track => track.ID == id);
                Context.SongTracks.Remove(doomedSong);
                Context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
