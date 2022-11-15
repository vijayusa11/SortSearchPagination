using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace code_2.Controllers
{
    public class HomeController : Controller
    {
        WebAppEntities db = new WebAppEntities();
        // GET: Home

        [AcceptVerbs(HttpVerbs.Get | HttpVerbs.Post)]
        public ActionResult Index(string searchTxt, string SortOrder, string SortBy, int PageNumber = 1)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var user = db.tbl_User.ToList();
            if (searchTxt != null)
            {
                user = db.tbl_User.Where(x => x.UserName.Contains(searchTxt) || x.Email.Contains(searchTxt) || x.Gender.Contains(searchTxt)).ToList();
                ApplySorting(SortOrder, SortBy, user);
                user = ApplyPagination(user, PageNumber);
            }
            else
            {
                ApplySorting(SortOrder, SortBy, user);
                user = ApplyPagination(user, PageNumber);
            }
            return View(user);
        }
        public void ApplySorting(string SortOrder, string SortBy, List<tbl_User> user)
        {

            switch (SortBy)
            {
                case ("UserName"):
                    {
                        switch (SortOrder)
                        {
                            case ("Asc"):
                                {
                                    user = user.OrderBy(x => x.UserName).ToList();
                                    break;
                                }
                            case ("Desc"):
                                {
                                    user = user.OrderByDescending(x => x.UserName).ToList();
                                    break;
                                }
                            default:
                                {
                                    user = user.OrderBy(x => x.UserName).ToList();
                                    break;
                                }

                        }

                        break;
                    }
                case ("Email"):
                    {
                        switch (SortOrder)
                        {
                            case ("Asc"):
                                {
                                    user = user.OrderBy(x => x.Email).ToList();
                                    break;
                                }
                            case ("Desc"):
                                {
                                    user = user.OrderByDescending(x => x.Email).ToList();
                                    break;
                                }
                            default:
                                {
                                    user = user.OrderBy(x => x.Email).ToList();
                                    break;
                                }

                        }
                        break;
                    }
                case ("Password"):
                    {
                        switch (SortOrder)
                        {
                            case ("Asc"):
                                {
                                    user = user.OrderBy(x => x.Password).ToList();
                                    break;
                                }
                            case ("Desc"):
                                {
                                    user = user.OrderByDescending(x => x.Password).ToList();
                                    break;
                                }
                            default:
                                {
                                    user = user.OrderBy(x => x.Password).ToList();
                                    break;
                                }

                        }

                        break;
                    }

                default:
                    {
                        user = user.OrderBy(x => x.UserName).ToList();
                        break;
                    }
            }
        }
        
        public List<tbl_User> ApplyPagination(List<tbl_User> user, int PageNumber)
        {
            ViewBag.TotalPages = Math.Ceiling(user.Count() / 5.0);
            ViewBag.PageNumber = PageNumber;
            user = user.Skip((PageNumber - 1) * 5).Take(5).ToList();
            return user;
        }
        
       
    }
    }



      //switch (SortOrder)
      //{
      //    case ("Asc"):
      //        {
      //            user = user.OrderBy(x => x.UserName).ToList();
      //            break;
      //        }
      //    case ("Desc"):
      //        {
      //            user = user.OrderByDescending(x => x.UserName).ToList();
      //            break;
      //        }
      //    default:
      //        {
      //            user = user.OrderBy(x => x.UserName).ToList();
      //            break;
      //        }

//}