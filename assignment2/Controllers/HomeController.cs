using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace assignment2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Story()
        {
            return View();
        }

        public ActionResult Characters()
        {
            return View();
        }
        public ActionResult Search(int pageIndex=1)
        {
            using (assignment2.Models.AssignmentDb db=new Models.AssignmentDb())
            {
                var query = db.Stoty.AsQueryable();
                var keyword = Request.QueryString["keyword"];
                var sort = Request.QueryString["sort"];
                if (keyword != null)
                {
                    query=query.Where(x=>x.Title.Contains(keyword));
                }
                if(sort != null)
                {
                    if(sort=="desc")
                    {
                        query=query.OrderByDescending(x=>x.Title);
                    }
                    else if(sort=="asc")
                    {
                        query=query.OrderBy(x=>x.Title);
                    }
                    else
                    {
                        query = query.OrderByDescending(x => x.Id);
                    }
                }
                else
                {
                    query = query.OrderByDescending(x => x.Id);
                }
                Pager pager = new Pager();
                pager.TotalCount = query.Count();
                pager.PageCount =(pager.TotalCount+pager.PageSize-1)/pager.PageSize;
                pager.PageIndex = pageIndex;

                query=query.Skip((pageIndex-1)*pager.PageSize).Take(pager.PageSize);
                ViewBag.pager=pager;
                return View(query.ToList());
            }
           
        }
    }
    public class Pager
    {
        public int PageCount { get; set; }
        public int PageIndex { get; set; }
        public int TotalCount { get; set; }
        public int PageSize { get; set; } = 4;
        public int NextPage
        {
            get
            {
                var n = PageIndex + 1;
                return n<=PageCount ? n : PageCount;
            }
        }
        public int PrePage
        {
            get
            {
                var n = PageIndex - 1;
                return n <= 1 ? 1 : n;
            }
        }
    }
}