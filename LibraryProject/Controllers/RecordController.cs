using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibraryProject.Models;
using LibraryProject.Abstract;
using LibraryProject.Entities;
using System.Web.Mvc;
using System.Net;

namespace LibraryProject.Controllers
{
    public class RecordController : Controller
    {
        static IRecordRepository recordRepo = RecordRepository.GetRecordRepository();

        public RecordController(){}

        public ActionResult Index()
        {
            return View (recordRepo.GetRecordList());
        }
    }
}
