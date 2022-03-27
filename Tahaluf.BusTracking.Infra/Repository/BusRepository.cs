﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tahaluf.BusTracking.Core.Common;
using Tahaluf.BusTracking.Core.Data;
using Tahaluf.BusTracking.Core.DTO;
using Tahaluf.BusTracking.Core.Repository;

namespace Tahaluf.BusTracking.Infra.Repository
{
    public class BusRepository : IBusRepository
    {
        private readonly IDbContext DbContext;
        public BusRepository(IDbContext _DbContext)
        {
            DbContext = _DbContext;
        }
        public List<Bu> GetAllBus()
        {
            IEnumerable<Bu> result = DbContext.Connection.Query<Bu>("BUS_PACKAGE.GETALLBUSES", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateBus(Bu bus)
        {
            var p = new DynamicParameters();
            p.Add("BUS_NO", bus.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_DRIVER", bus.Busdriver, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_TEACHER", bus.Busteacher, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("BUS_PACKAGE.CREATEBUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateBus(Bu bus)
        {
            var p = new DynamicParameters();
            p.Add("BUS_ID", bus.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_NO", bus.Busnumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_DRIVER", bus.Busdriver, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("BUS_TEACHER", bus.Busteacher, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = DbContext.Connection.ExecuteAsync("BUS_PACKAGE.UPDATEBUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteBus(int id)
        {
            var p = new DynamicParameters();
            p.Add("BUS_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = DbContext.Connection.ExecuteAsync("BUS_PACKAGE.DELETEBUS", p, commandType: CommandType.StoredProcedure);

            return true;
        }

        public List<GetBusDriversDTO> GetBusDrivers() {

            IEnumerable<GetBusDriversDTO> result = DbContext.Connection.Query<GetBusDriversDTO>("getBusDrivers", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
        public List<GetBusTeachersDTO> GetBusTeaachers() {
            IEnumerable<GetBusTeachersDTO> result = DbContext.Connection.Query<GetBusTeachersDTO>("getBusTeachers", commandType: CommandType.StoredProcedure);
            return result.ToList();

        }
       public async  Task<List<Bu>> GETSTUDENTLIST()
        {
               var result = await DbContext.Connection.QueryAsync<Bu, Student, Bu>
            ("BUS_PACKAGE.GETSTUDENTLIST", (bus, student) =>
            {
                bus.Students = bus.Students ?? new List<Student>();
                bus.Students.Add(student);
                return bus;
            },
            splitOn: "Id",
            param: null,
            commandType: CommandType.StoredProcedure
            );


            var FinalResult = result.AsList<Bu>().GroupBy(p => p.Id).Select(g =>
            {
                Bu bus = g.First();
                bus.Students = g.Where(g => g.Students.Any() && g.Students.Count() > 0).Select(p => p.Students.Single()).GroupBy(student => student.Id).Select(student => new Student
                {
                Id = student.First().Id,
                Name = student.First().Name
                }).ToList();
                return bus;
            }).ToList();

            return FinalResult;
        }
    }
}
