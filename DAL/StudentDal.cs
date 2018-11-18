using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class StudentDal
    {
        public List<StudentModel> GetAllStudent()
        {
            List<StudentModel> lststudents = new List<StudentModel>();
            try
            {
                using (MVCDemoEntities objEntities = new MVCDemoEntities())
                {
                    var allstudents = objEntities.Students.ToList();
                    foreach (var std in allstudents)
                    {
                        StudentModel studentModel = new StudentModel();

                        studentModel.Id = std.Id;
                        studentModel.Name = std.Name;
                        studentModel.FatherName = std.FatherName;
                        studentModel.Gender = std.Gender;
                        studentModel.RollNo = std.RollNo;

                        lststudents.Add(studentModel);
                    }
                }
                return lststudents;
            }
            catch (Exception ex)
            {
                return lststudents;
            }
        }

        public int CreateStutent(StudentModel studentModel)
        {
            try
            {
                using (MVCDemoEntities objEntities = new MVCDemoEntities())
                {
                    Student std = new Student();
                    std.Id = studentModel.Id;
                    std.Name = studentModel.Name;
                    std.FatherName = studentModel.FatherName;
                    std.Gender = studentModel.Gender;
                    std.RollNo = studentModel.RollNo;

                    objEntities.Students.Add(std);

                    objEntities.SaveChanges();

                    return std.Id;

                }
            }
            catch (Exception ex)
            {
                return 0;
            }

        }
        public StudentModel GetStudent(int Id)
        {
            try
            {
                using (MVCDemoEntities mvcdemoEntity = new MVCDemoEntities())
                {
                    var student = mvcdemoEntity.Students.Where(a => a.Id == Id).FirstOrDefault();
                    StudentModel studentModel = new StudentModel();
                    studentModel.Id = student.Id;
                    studentModel.Name = student.Name;
                    studentModel.FatherName = student.FatherName;
                    studentModel.RollNo = student.RollNo;
                    studentModel.Gender = student.Gender;

                    return studentModel;
                }
            }
            catch(Exception ex)
            {
                return new StudentModel();
            }
        }

        public int UpdateStutent(StudentModel studentModel)
        {
            try
            {
                using (MVCDemoEntities mvcdemoEntity = new MVCDemoEntities())
                {
                    var student = mvcdemoEntity.Students.Where(a => a.Id == studentModel.Id).FirstOrDefault();
                    student.Name = studentModel.Name;
                    student.RollNo = studentModel.RollNo;
                    student.Gender = studentModel.Gender;
                    student.FatherName = studentModel.FatherName;

                    mvcdemoEntity.SaveChanges();
                    return student.Id;
                }
            }
            catch(Exception ex)
            {
                return 0;
            }
            
        }
        public int DeleteStutent(int stdId)
        {
            return 0;

        }
        
        
        public List<StudentModel> AllStudent()
        {
            List<StudentModel> lststudentModels = new List<StudentModel>()
            {
                new StudentModel()
                {
                    Id=1,
                    FatherName="father1",
                    Gender="male",
                    Name="Student 1",
                    RollNo=1
                },
                new StudentModel()
                {
                    Id=2,
                    FatherName="father2",
                    Gender="male",
                    Name="Student 2",
                    RollNo=2
                },
                new StudentModel()
                {
                    Id=3,
                    FatherName="father3",
                    Gender="male",
                    Name="Student 3",
                    RollNo=3
                },
                new StudentModel()
                {
                    Id=4,
                    FatherName="father4",
                    Gender="male",
                    Name="Student 4",
                    RollNo=4
                },
                new StudentModel()
                {
                    Id=5,
                    FatherName="father5",
                    Gender="male",
                    Name="Student 5",
                    RollNo=5
                },
            };
            return lststudentModels;
        }

    }
}
