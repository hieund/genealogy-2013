using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business.Base;
using genealogy.business.Custom;
namespace genealogy.Controllers
{
    public class AlbumController : Controller
    {
        //
        // GET: /Album/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AlbumImages()
        {
            List<GENAlbums> lst = AlbumRepository.Current.GetAllAlbum();
            return View(lst);
        }

        public ActionResult AlbumVideos()
        {
            return View();
        }
        [ChildActionOnly]
        public ActionResult GetListAlbumDetailByAlbumId(int albumId)
        {
            List<GENAlbumDetails> lst = AlbumDetailRepository.Current.GetListAlbumDetailByAlbumID(albumId);
            return PartialView(lst);
        }

    }
}
