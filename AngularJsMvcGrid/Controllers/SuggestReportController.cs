using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularJsMvcGrid.Models;

namespace AngularJsMvcGrid.Controllers
{
    public class SuggestReportController : Controller
    {
        private IDBOLiveEntities db = new IDBOLiveEntities();

        // GET: /SuggestReport/
        public ActionResult Index()
        {
            return View(db.GenSuggestReports.ToList());
        }

        public ActionResult getAllIssues()
        {
            var issueReportDetails = db.GenSuggestReports.Where(i => i.RecordType == 1 && i.IsActive == 0).OrderBy(i => i.Created).ToList();
            return new JsonNetResult() { Data = issueReportDetails };
            //return Json(issueReportDetails, JsonRequestBehavior.AllowGet);
        }
        public ActionResult getComments(Guid? id)
        {
            //Guid ID = Guid.Parse(id);
            var comments = db.GenSuggestReportComments.Where(i => i.SuggestReportID == id).ToList();
            return Json(comments, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult updateIssue(GenSuggestReport changedIssue)
        {

            if(ModelState.IsValid){
                db.Entry(changedIssue).State = EntityState.Modified;
                db.SaveChanges();
               // return RedirectToAction("Index");
            }
            
            var issueReportDetails = db.GenSuggestReports.Where(i => i.RecordType == 1 && i.IsActive == 0).OrderBy(i => i.Created).ToList();
            return new JsonNetResult() { Data = issueReportDetails };
        }
        // GET: /SuggestReport/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenSuggestReport gensuggestreport = db.GenSuggestReports.Find(id);
            if (gensuggestreport == null)
            {
                return HttpNotFound();
            }
            return View(gensuggestreport);
        }

        // GET: /SuggestReport/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /SuggestReport/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,ParentID,CreatedBy,SlNo,Notes,Description,RecordType,RecordStatus,ReviewedBy,SectionName,WIPDate,PausedDate,ClosedDate,NotAnIssueDate,DataRowVersion,Created,LastUpdated,UserID,ChangeSetNumber,IsActive,Priority,SectionGroupID,SectionID,CID,ClosedByID")] GenSuggestReport gensuggestreport)
        {
            if (ModelState.IsValid)
            {
                gensuggestreport.ID = Guid.NewGuid();
                
                db.GenSuggestReports.Add(gensuggestreport);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gensuggestreport);
        }

        // GET: /SuggestReport/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenSuggestReport gensuggestreport = db.GenSuggestReports.Find(id);
            if (gensuggestreport == null)
            {
                return HttpNotFound();
            }
            return View(gensuggestreport);
        }

        // POST: /SuggestReport/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,ParentID,CreatedBy,SlNo,Notes,Description,RecordType,RecordStatus,ReviewedBy,SectionName,WIPDate,PausedDate,ClosedDate,NotAnIssueDate,DataRowVersion,Created,LastUpdated,UserID,ChangeSetNumber,IsActive,Priority,SectionGroupID,SectionID,CID,ClosedByID")] GenSuggestReport gensuggestreport)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gensuggestreport).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gensuggestreport);
        }

        // GET: /SuggestReport/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GenSuggestReport gensuggestreport = db.GenSuggestReports.Find(id);
            if (gensuggestreport == null)
            {
                return HttpNotFound();
            }
            return View(gensuggestreport);
        }

        // POST: /SuggestReport/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            GenSuggestReport gensuggestreport = db.GenSuggestReports.Find(id);
            db.GenSuggestReports.Remove(gensuggestreport);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
