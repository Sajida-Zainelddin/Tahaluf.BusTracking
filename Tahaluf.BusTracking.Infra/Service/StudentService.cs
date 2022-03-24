﻿using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;
using Tahaluf.BusTracking.Core.Service;

namespace Tahaluf.BusTracking.Infra.Service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository studentRepository;
        public StudentService(IStudentRepository _studentRepository)
        {
            studentRepository = _studentRepository;
        }
        public List<StudentDto> GetAllStudent() 
        {
            return studentRepository.GetAllStudent();
        }
        public bool CreateStudent(StudentDto studentdto)
        {
            return studentRepository.CreateStudent(studentdto);
        }
        public bool UpdateStudent(StudentDto studentdto)
        {
            return studentRepository.UpdateStudent(studentdto);
        }
        public bool DeleteStudent(int id)
        {
            return studentRepository.DeleteStudent(id);
        }

        public List<Roundstatus> GETROUNDSTATUS()
        {
            return studentRepository.GETROUNDSTATUS();
        }

        public List<User> GETPARENTNAME()
        {
            return studentRepository.GETPARENTNAME();
        }

        public List<Bu> GETBUSNUMBER()
        {
            return studentRepository.GETBUSNUMBER();
        }
    }
}
