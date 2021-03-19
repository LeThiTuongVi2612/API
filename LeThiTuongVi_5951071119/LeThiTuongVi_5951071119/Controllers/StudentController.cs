using LeThiTuongVi_5951071119.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeThiTuongVi_5951071119.Controllers
{
    public class StudentController : ApiController
    {
        // GET: api/Student
        public IEnumerable<StudentInfo> Get()
        {
            var studentInfList = new List<StudentInfo>();
            {
                var studentInfo = new StudentInfo
                {
                    HoTen = "Lê Thị Tường Vi",
                    MaSo = "5951071119"
                };
                studentInfList.Add(studentInfo);
                return studentInfList;
            }
            
        }

        
    }
}
