using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using genealogy.business;
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
            List<GENAlbums> lst = AlbumRepository.Current.GetAllAlbum(DataHelper.AlbumDetailTypeImage);
            return View(lst);
        }

        public ActionResult AlbumVideos()
        {
            List<GENAlbums> lst = AlbumRepository.Current.GetAllAlbum(DataHelper.AlbumDetailTypeVideo);
            return View(lst);
        }
        [ChildActionOnly]
        public ActionResult GetListAlbumDetailByAlbumId(int albumId, int intTypeId)
        {
            List<GENAlbumDetails> lst = AlbumDetailRepository.Current.GetListAlbumDetailByAlbumID(albumId, intTypeId);
            ViewBag.TypeId = intTypeId;
            return PartialView(lst);
        }

    }
}
