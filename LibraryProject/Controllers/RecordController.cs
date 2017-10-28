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

        [HttpGet]
        public ActionResult AddRecord()//Just in case member borrowed when system down, you can add it later
        {
            return View("Add");
        }

        [HttpPost]
        public ActionResult AddRecord(int bookId, string bookName, int memberId, string memberName
                       , DateTime borrowDate, DateTime dueDate, string borrowStatus)
        {
            int recordId = recordRepo.GetCounter();

            Record newRecord = new Record(recordId,bookId,bookName,memberId,memberName,
                                          borrowDate,borrowStatus);
            if (recordRepo.AddRecord(newRecord))
            {
                recordRepo.SetCounter(recordRepo.GetCounter() + 1);
                ViewData["MSG"] = "Add a record!!!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "adding record...";
                return View("Errror");
            }
        }

        [HttpDelete]
        public ActionResult RemoveRecord(int recordId)
        {
            if (recordRepo.RemoveRecord(recordId))
            {
                ViewData["MSG"] = "Remove slected record !!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "Removing record...";
                return View("Error");
            }
        }

        [HttpGet]
        public ActionResult EditRecord(int recordId) //just in case librarian make a mistake while borrowing
        {
            {
                Record currentRecord = recordRepo.GetRecord(recordId);
                if (currentRecord == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    return View("Edit", currentRecord);
                }
            }

        }

        [HttpPut]
        public ActionResult EditRecord(int recordId, int bookId, string bookName, int memberId, string memberName
                      , DateTime borrowDate, DateTime dueDate, DateTime returnDate, string borrowStatus)//id cannot edit
        {
            Record updatedRecord = new Record(recordId,bookId,bookName,memberId,memberName,
                                              borrowDate,dueDate,returnDate,borrowStatus);

            if (recordRepo.EditRecord(updatedRecord))
            {
                ViewData["MSG"] = "Updated record!!!";
                return View("Success");
            }
            else
            {
                ViewData["MSG"] = "Updating record...";
                return View("Errror");
            }

        }

        [HttpGet]
        public ActionResult ShowRecordInfo(int recordId)
        {
            Record currentRecord = recordRepo.GetRecord(recordId);

            if (currentRecord == null)
            {
                return HttpNotFound();
            }
            else
            {
                return View("Info", currentRecord);
            }
        }
    }
}
