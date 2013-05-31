using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using System.Configuration;
using genealogy.business;
using genealogy.business.Base;
using genealogy.business.Custom;
using WebLibs;
namespace genealogy.Controllers
{
    public class VideoController : Controller
    {
        //
        // GET: /Video/

        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult VideoBox()
        {
            List<GENAlbumDetails> lst = AlbumDetailRepository.Current.GetListVideoBox(Convert.ToInt32(ConfigurationManager.AppSettings["VideoBox"]), DataHelper.AlbumDetailTypeVideo);
            return PartialView(lst);
        }
    }
}
