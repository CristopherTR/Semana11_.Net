using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infraestructure;
using System.Data.Entity.Validation;
using System.Diagnostics;
using Domain;


namespace Service
{
    public class StudentService
    {
        public List<Student> Get()
        {
            List<Student> students = null;
            using(var context = new SchoolContext())
            {
                students = context.Students.ToList();
            }
            return students;
        }
        public Student GetById(int ID)
        {
            Student student = null;
            using(var context = new SchoolContext())
            {
                student = context.Students.Find(ID);
            }
            return student;
        }

        public void Insert(Student student)
        {
            using (var context = new SchoolContext())
            {
                //context.Students.Add(student);
                //context.SaveChanges();
                try
                {
                    context.Students.Add(student);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}",
                                validationError.PropertyName,
                                validationError.ErrorMessage);
                        }
                    }
                }
            }
        }
        public void Update(Student student, int ID)
            {
                using (var context = new SchoolContext())
            {
                var studentNew = context.Students.Find(ID);

                studentNew.studentName = student.studentName;
                studentNew.studentAddress = student.studentAddress;
                studentNew.studentLast = student.studentLast;
                studentNew.studentCode = student.studentCode;

                context.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            using (var context = new SchoolContext())
            {
                var student = context.Students.Find(ID);
                context.Students.Remove(student);
                context.SaveChanges();
            }
        }
    }
}
