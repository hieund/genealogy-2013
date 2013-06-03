using genealogy.business;
using genealogy.business.Base;
using genealogy.business.Custom;
using genealogy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace genealogy.Controllers
{
    public class CommentController : Controller
    {
        //
        // GET: /Comment/



        [ChildActionOnly]
        public ActionResult GetCommentNews(int id)
        {
            List<GENComments> comments = CommentsRepository.Current.GetCommentByNews(id);
            return PartialView(comments);
        }

        [HttpGet]
        public ActionResult InsertCommentNews(int id)
        {
            CommentsModels comment = new CommentsModels();
            ViewBag.id = id;
            return PartialView(comment);
        }

        [HttpPost]
        public ActionResult InsertCommentNews(CommentsModels comment, int id)
        {
            
                UserModels user = this.getCurrentUser();
                if (user != null)
                {
                    ModelState.Remove("Email");
                    ModelState.Remove("FullName");
                    comment.FullName = user.FullName;
                    comment.Email = user.Email;
                    comment.UserID = user.UserID;
                    comment.Avartar = user.Avatar;
                }
                if (ModelState.IsValid)
                {
                    GENComments genComment = new GENComments()
                    {
                        Content = comment.Content,
                        NewsID = id,
                        CreatedDate = DateTime.Now,
                        Avartar = comment.Avartar,
                        Email = comment.Email,
                        FullName = comment.FullName,
                        UserID = comment.UserID, 
                    };
                    genComment.Insert();
                    
                }
                CommentsRepository.Current.RemoveCommentByNews(id);
                List<GENComments> comments = CommentsRepository.Current.GetCommentByNews(id);
                return PartialView("~/Views/Comment/GetCommentNews.cshtml", comments); 
        }

        private UserModels getCurrentUser()
        {
            GENUsers objUser = new GENUsers();
            UserModels mdUser = new UserModels();
            if (UserRepository.Current.IsLogin())
            {
                objUser = Session[DataHelper.UserLogin] as GENUsers;
                mdUser = ModelHelper.Current.LoadUserModels(objUser);
                return mdUser;
            }
            return null;
        }

    }
}
