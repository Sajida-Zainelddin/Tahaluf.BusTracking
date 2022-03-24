﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpGet]
        [Route("GetAll")]
       // [ProducesResponseType(typeof(List<Student>), StatusCodes.Status200OK)]
        // anyone with token or [Authorize(Role = "Teacher, Student")] [Authorize] 
        public List<StudentDto> GetAllStudent()
        {
            return _studentService.GetAllStudent();
        }
        [HttpGet]
        [Route("GetRoundStatus")]
        public List<Roundstatus> GETROUNDSTATUS()
        {
            return _studentService.GETROUNDSTATUS();
        }


        [HttpGet]
        [Route("GetParentName")]
        public List<User> GETPARENTNAME()
        {
            return _studentService.GETPARENTNAME();

        }
  
        [HttpGet]
        [Route("GetBusNum")]
        public List<Bu> GETBUSNUMBER()
        {
            return _studentService.GETBUSNUMBER();

        }



        [HttpPost]
        [Route("Create")]
        public bool CreateStudent([FromBody] StudentDto studentdto)
        {
            return _studentService.CreateStudent(studentdto);
        }

        [HttpPut]
        [Route("Update")]
        public bool UpdateStudent([FromBody] StudentDto studentdto)
        {
            return _studentService.UpdateStudent(studentdto);
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public bool DeleteStudent(int id)
        {
            return _studentService.DeleteStudent(id);
        }
    }
}
