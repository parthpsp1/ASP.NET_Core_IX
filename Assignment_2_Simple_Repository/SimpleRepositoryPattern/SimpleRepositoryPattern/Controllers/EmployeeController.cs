using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SimpleRepositoryPattern.Interface;
using SimpleRepositoryPattern.Model;
using SimpleRepositoryPattern.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;

        private readonly EmployeeService employeeService;
        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository; // DI through
            employeeService = new EmployeeService(); // Object through
        }
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            //return await _employeeRepository.Get();
            return await employeeService.Get();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployees(int id)
        {
            return await _employeeRepository.GetById(id);
        }
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees(Employee employee)
        {
            var AddEmployee = await _employeeRepository.Create(employee);
            return AddEmployee;
        }
    }
}
