using Microsoft.EntityFrameworkCore;
using SimpleRepositoryPattern.Data;
using SimpleRepositoryPattern.Interface;
using SimpleRepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryPattern.Service
{
    public class EmployeeService : IEmployeeRepository
    {
        private readonly ApplicationDbContext _employee_db;
        public EmployeeService()
        {
            _employee_db = new();
        }
        public async Task<IEnumerable<Employee>> Get()
        {
            var employee_list = await  _employee_db.Employee.ToListAsync();
            return employee_list;
        }

        public async Task<Employee> GetById(int id)
        {
            var employee_list = await _employee_db.Employee.FirstOrDefaultAsync(o => o.Id == id);
            return employee_list;
        }

        public async Task<Employee> Create(Employee employee)
        {
            var create_employee = await _employee_db.Employee.AddAsync(employee);
            _employee_db.SaveChanges(); //Save Changes automatically modifies the table
            return create_employee.Entity;
        }

        public Task Update(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Patch(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
