﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;

namespace Tahaluf.BusTracking.Infra.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IDbContext DbContext;
        public StudentRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }

        public List<StudentDto> GetAllStudent()
        {
            IEnumerable<StudentDto> result = DbContext.Connection.Query<StudentDto>("STUDENT_PACKAGE.GETSTUDENTDTO", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateStudent(StudentDto studentdto)
        {
            var p = new DynamicParameters();

            p.Add("NAMEe", studentdto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", studentdto.Xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", studentdto.Yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", studentdto.Grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUNDSTATUS", studentdto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PARENTNAME", studentdto.fullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUMBER", studentdto.busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);


            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.CREATESTUDENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateStudent(StudentDto studentdto)
        {
            var p = new DynamicParameters();
            p.Add("STUDENT_ID", studentdto.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("NAMEe", studentdto.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("X_HOME", studentdto.Xhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("Y_HOME", studentdto.Yhome, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("STD_GRADE", studentdto.Grade, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("ROUNDSTATUS", studentdto.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PARENTNAME", studentdto.fullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("BUS_NUMBER", studentdto.busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
     

            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.UPDATESTUDENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteStudent(int id)
        {
            var p = new DynamicParameters();
            p.Add("STUDENT_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("STUDENT_PACKAGE.DELETESTUDENT", p, commandType: CommandType.StoredProcedure);

            return true;
        }
    }
}
