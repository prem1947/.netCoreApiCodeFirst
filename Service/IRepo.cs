using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepoService
{
    public interface IRepo
    {
        public Task<IEnumerable<EmployeeDomain>> Get();
        public Task<EmployeeDomain> GetById(int Id);
        public Task<EmployeeDomain> Create(EmployeeDomain employee);
        public Task<EmployeeDomain> Update(EmployeeDomain employee);
        public Task<EmployeeDomain> Delete(EmployeeDomain employee);

    }
}
