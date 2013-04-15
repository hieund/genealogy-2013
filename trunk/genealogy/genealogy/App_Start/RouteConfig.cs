using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace genealogy
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            #region News
            routes.MapRoute(
             "News-Detail",
             "tin-tuc/{NewsCategoryUrl}/{NewsUrl}-{NewsId}",
             new { controller = "News", action = "NewsDetail" },
             new { NewsCategoryUrl = @"^(\w|-|\d)+$", NewsId = @"^(\d)+$" }
             );

            routes.MapRoute(
              "News-Category",
              "tin-tuc/{NewsCategoryUrl}/{CategoryId}",
              new { controller = "News", action = "NewsCategory" },
              new { NewsCategoryUrl = @"^(\w|-|\d)+$", CategoryId = @"^(\d)+$" }
             );
            routes.MapRoute(
            "News-Post",
            "tin-tuc/dang-bai-viet",
            new { controller = "News", action = "NewsPost" }
            );

            routes.MapRoute(
             "News-Home",
             "tin-tuc",
             new { controller = "News", action = "Home" }
             );
            #endregion

            #region Album
            routes.MapRoute(
            "Album-Detail",
            "tu-lieu/{AlbumCategoryUrl}/{AlbumUrl}-{AlbumId}",
            new { controller = "Album", action = "AlbumDetail" },
            new { AlbumUrl = @"^(\w|-|\d)+$", AlbumId = @"^(\d)+$" }
            );

            routes.MapRoute(
              "Album-Category",
              "tu-lieu/{AlbumCategoryUrl}/{AlbumCategoryId}",
              new { controller = "Album", action = "AlbumCategory" },
              new { AlbumCategoryUrl = @"^(\w|-|\d)+$", AlbumCategoryId = @"^(\d)+$" }
             );
            routes.MapRoute(
            "Album-Images",
            "tu-lieu/hinh-anh",
            new { controller = "Album", action = "AlbumImages" }
            );
            routes.MapRoute(
            "Album-Video",
            "tu-lieu/video",
            new { controller = "Album", action = "AlbumVideos" }
            );
            routes.MapRoute(
             "Album-Home",
             "tu-lieu",
             new { controller = "Album", action = "Index" }
             );
            #endregion

            #region Profile

            #endregion

            #region Events

            #endregion

            #region Ajax

            #endregion

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}