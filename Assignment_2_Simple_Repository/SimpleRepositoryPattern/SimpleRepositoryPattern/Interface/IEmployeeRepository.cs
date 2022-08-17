using SimpleRepositoryPattern.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleRepositoryPattern.Interface
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> Get();
        Task<Employee> GetById(int id);
        Task<Employee> Create(Employee employee);
        Task Update(Employee employee);
        //Task Patch(Employee employee);
        Task Delete(int id);
    }
}
