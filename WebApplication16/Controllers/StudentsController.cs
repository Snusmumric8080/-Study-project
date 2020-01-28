using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication16.Models;
using WebApplication6.Models;

namespace WebApplication16.Controllers
{
    public class StudentsController : Controller
    {
        private Model1 db = new Model1();
        private object students;

        // GET: Students
        public ActionResult Index()
        {
            try
            {
                Attendance1 attendance = new Attendance1();
                attendance.IdAttendance = DateTime.Today;
                db.Attendance1.Add(attendance);
                db.SaveChanges();
                return View(db.Students.ToList());
            }
            catch (Exception)
            {
                return View(db.Students.ToList());
            }
        }

        public ActionResult Progress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdStudent,FullNameStudent,Town,Street,Home,TeacherFullName,PlaseOfBirt,DateOfBirt,klass,FullNameMother,NumerMother,PlaseWorkMother,FullNameFather,NumberFather,PlaseWorkFather,Mail")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(student);
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdStudent,FullNameStudent,Town,Street,Home,TeacherFullName,PlaseOfBirt,DateOfBirt,klass,FullNameMother,NumerMother,PlaseWorkMother,FullNameFather,NumberFather,PlaseWorkFather,Mail")] Student student)
        {
            if (ModelState.IsValid)
            {
                db.Entry(student).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: DeleteConfirmed
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var delProgress = (from m in db.Progresses
                               where m.IdStudent == id
                               select m);
            foreach (var c in delProgress)
            {
                db.Progresses.Remove(c);
            }

            var delAttendance = (from m in db.AttendanceStudents
                                 where m.IdStudent == id
                                 select m);
            foreach (var c in delAttendance)
            {
                db.AttendanceStudents.Remove(c);
            }

            Student student = db.Students.Find(id);
                db.Students.Remove(student);
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

        //Progress
        // GET: Progresses/Delete/5
        public ActionResult DeleteProgress(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Progress progress = db.Progresses.Find(id);
            if (progress == null)
            {
                return HttpNotFound();
            }
            return View(progress);
        }

        // POST: Progresses/Delete/5
        [HttpPost, ActionName("DeleteProgress")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteProgressConfirmed(int id)
        {
            Progress progress = db.Progresses.Find(id);
            db.Progresses.Remove(progress);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Progresses/Create
        public ActionResult AddProgress()
        {
            ViewBag.IdStudent = new SelectList(db.Students, "IdStudent", "FullNameStudent");
            ViewBag.IdSubject = new SelectList(db.Subjects, "IdSubject", "NameSubject");
            return View();
        }

        // POST: Progresses/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProgress([Bind(Include = "Id_Progress,IdStudent,IdSubject,Rating,date")] Progress progress)
        {
            if (ModelState.IsValid)
            {
                db.Progresses.Add(progress);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdStudent = new SelectList(db.Students, "IdStudent", "FullNameStudent", progress.IdStudent);
            ViewBag.IdSubject = new SelectList(db.Subjects, "IdSubject", "NameSubject", progress.IdSubject);
            return View(progress);
        }



        // Subject
        // GET: Subjects
        public ActionResult Subject()
        {
            return View(db.Subjects.ToList());
        }

        // GET: Subjects/Delete/5
        public ActionResult DeleteSubject(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("DeleteSubject")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteSubjectConfirmed(int id)
        {
            var delSubject = (from m in db.Progresses
                               where m.IdSubject == id
                               select m);
            foreach (var c in delSubject)
            {
                db.Progresses.Remove(c);
            }

            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
            db.SaveChanges();
            return RedirectToAction("Subject");
        }


        // GET: Subjects/Create
        public ActionResult CreateSubject()
        {
            return View();
        }

        // POST: Subjects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateSubject([Bind(Include = "IdSubject,NameSubject")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.Subjects.Add(subject);
                db.SaveChanges();
                return RedirectToAction("Subject");
            }

            return View(subject);
        }

        //посещаемость
        //AttendanceStudent
        public ActionResult AttendanceStudent(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Student student = db.Students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // DeleteAttendance
        // GET: Progresses/Delete/5
        public ActionResult DeleteAttendance(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AttendanceStudent attendanceStudent = db.AttendanceStudents.Find(id);
      
            return View(attendanceStudent);
        }

        // POST: DeleteAttendance
        [HttpPost, ActionName("DeleteAttendance")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteAttendance(int id)
        {
            AttendanceStudent attendanceStudent = db.AttendanceStudents.Find(id);
            db.AttendanceStudents.Remove(attendanceStudent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Attedanse()
        {
            return View(db.Attendance1.ToList());
        }

        public ActionResult CreateAttedance()
        {
            return View();
        }

        // POST: CreateAttedance
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAttedance([Bind(Include = "IdAttendance")] Attendance1 attendance1)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Attendance1.Add(attendance1);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        public ActionResult CreateAttendanceStudent()
        {
            ViewBag.IdAttendance = new SelectList(db.Attendance1, "IdAttendance", "IdAttendance");
            ViewBag.IdStudent = new SelectList(db.Students, "IdStudent", "FullNameStudent");
            return View();
        }

        // POST: CreateAttendanceStudent
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateAttendanceStudent([Bind(Include = "IDAttendanceStudent,Status,IdStudent,IdAttendance")] AttendanceStudent attendanceStudent)
        {
            if (ModelState.IsValid)
            {
                db.AttendanceStudents.Add(attendanceStudent);
                db.SaveChanges();
            }
            // отправляем email
            try
            {
                ViewBag.IdStudent = new SelectList(db.Students, "IdStudent", "FullNameStudent", attendanceStudent.IdStudent);

                // ваборка почты
                var mail = (from m in db.Students
                            where m.IdStudent == attendanceStudent.IdStudent
                            select m.Mail).FirstOrDefault();
                // выборка имени
                var student = (from m in db.Students
                               where m.IdStudent == attendanceStudent.IdStudent
                               select m.FullNameStudent).FirstOrDefault();
                // выборка даты
                var date = (from m in db.AttendanceStudents
                            where m.IdStudent == attendanceStudent.IdStudent
                            select m.IdAttendance).FirstOrDefault();

                var Achievement = attendanceStudent.Status;

                // отправка письма
                FeedBack feedback = new FeedBack();
                feedback.Subkject = "Посещаемость";
                feedback.text = String.Format($@"Ученик: {student} " +
                    $"<br/>Дата: {date}" +
                    $"<br/>Статус: {Achievement}");
                Emailer.Send(mail.ToString(), feedback.Subkject, feedback.text);

                return RedirectToAction("CreateAttendanceStudent");
            }
            catch (Exception)
            {
                return RedirectToAction("CreateAttendanceStudent");
            }
        }
    }
}


