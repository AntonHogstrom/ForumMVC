using ForumMVC.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace ForumMVC.Controllers
{
    public class ForumController : Controller
    {
        //Skapa lista med ThreadViewModel threads
        static private List<ThreadViewModel> threads = new();

        public IActionResult Index()
        {
            return View(threads.OrderByDescending(thread => thread.Id).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult CreateThread(ThreadViewModel threadViewModel)
        {
            threads.Add(threadViewModel);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult PatchLikesThread(int id, int like, bool fromThread)
        {
            foreach(var thread in threads)
            {
                if (thread.Id == id)
                {
                    if(like == 1)
                    {
                        thread.Likes++;
                    }
                    else
                    {
                        thread.Likes--;
                    }
                }
            }
            if(fromThread) 
            { 
                return RedirectToAction(nameof(Thread), new {Id = id});
            }
            return RedirectToAction(nameof(Index));
        }


        public IActionResult PatchLikesComment(int id, int like, int threadId)
        {
            foreach (var thread in threads)
            {
                if (thread.Id == threadId)
                {
                    foreach(var comment in thread.Comments)
                    {
                        if(comment.Id == id)
                        {
                            if(like == 1)
                            {
                                comment.Likes++;
                            }
                            else
                            {
                                comment.Likes--;
                            }
                        }
                    }
                }
            }
            return RedirectToAction(nameof(Thread), new { Id = threadId });
        }

        public IActionResult Thread(int id)
        {
            foreach(var thread in threads)
            {
                if(thread.Id == id)
                {
                    return View(thread);
                }
            }
            return View();
        }

        public IActionResult CommentThread(int id, CommentViewModel commentViewModel)
        {
            foreach (var thread in threads)
            {
                if (id == thread.Id)
                {
                    thread.Comments.Add(commentViewModel);
                }
            }
            return RedirectToAction(nameof(Thread), new { Id = id });
        }
    }
}