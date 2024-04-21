using BE2024.DataAccess.Layers;
using BE2024.DataAccess.Objects;
using CommonLibs;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace BE2024.DataAccess.Implementations
{
    public class StudentRegister : IStudentRegister
    {
        private readonly Course course = new Course();
        private readonly List<Student> students = new List<Student>();
        public ReturnData Register(Student student)
        {
            ReturnData returnData = new ReturnData();

            if (!Validation.IsName(student.FullName))
            {
                returnData.ErrorCode = -1;
                returnData.Message = "Tên không hợp lệ!";
                return returnData;
            }

            if (student.Birthday > DateTime.Now)
            {
                returnData.ErrorCode = -1;
                returnData.Message = "Ngày sinh không hợp lệ!";
                return returnData;
            }

            student.RegisterDate = DateTime.Now;

            if (course.OpeningDate - student.RegisterDate > TimeSpan.FromDays(30))
                student.Discount = 15;
            if (course.OpeningDate - student.RegisterDate > TimeSpan.FromDays(30))
                student.Discount = 10;

            students.Add(student);
            return returnData;
        }
        public ReturnData UpdateCourseInfo(string name, string description, double tuition, DateTime openingDate)
        {
            ReturnData returnData = new ReturnData();

            if (!Validation.IsName(name))
            {
                returnData.ErrorCode = -1;
                returnData.Message = "Tên không hợp lệ!";
                return returnData;
            }

            if (Validation.IsContainHTMLTags(description))
            {
                returnData.ErrorCode = -2;
                returnData.Message = "Mô tả không hợp lệ!";
                return returnData;
            }
            
            if (tuition < 0)
            {
                returnData.ErrorCode = -4;
                returnData.Message = "Học phí không thể âm!";
                return returnData;
            }

            course.Name = name;
            course.Description = description;
            course.Tuition = tuition;
            course.OpeningDate = openingDate;

            return returnData;
        }

        public string ShowAllStudents()
        {
            students.OrderBy(item => item.Discount);
            return FormatListStudents(students);
        }

        public string FormatListStudents(List<Student> students)
        {
            CultureInfo provider = new CultureInfo("vi-VN");
            StringBuilder builder = new StringBuilder();
            string format = "{0, -20}{1,-12}{2,-15}{3,-16:C0}{4,-16:C0}";

            string header = string.Format(provider, format,
                    "Họ tên",
                    "Ngày sinh",
                    "Ngày đăng kí",
                    "Học phí",
                    "Học phí sau chiết khấu");
            builder.AppendLine(header);

            foreach (var item in students)
            {
                string content = string.Format(provider, format, 
                    item.FullName,
                    item.Birthday.ToShortDateString(),
                    item.RegisterDate.ToShortDateString(),
                    course.Tuition,
                    course.Tuition * item.Discount / 100
                );
                builder.AppendLine(content);
            }

            return builder.ToString();
        }
    }
}
