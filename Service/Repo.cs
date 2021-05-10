using DbCon;
using Entity;
using Microsoft.EntityFrameworkCore;
using RepoService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public class Repo : IRepo
    {
        private readonly DbConContext _dbConContext;
        public Repo(DbConContext dbConContext)
        {
            _dbConContext = dbConContext;
        }
        
        public async Task<IEnumerable<EmployeeDomain>> Get()
        {
            return await _dbConContext.Employees.ToListAsync();
        }
        public async Task<EmployeeDomain> GetById(int Id)
        {
            return await _dbConContext.Employees.FirstOrDefaultAsync(x => x.EmpId == Id);
        }
        public async Task<EmployeeDomain> Create(EmployeeDomain employee)
        {
            var result = await _dbConContext.Employees.AddAsync(employee);
            await _dbConContext.SaveChangesAsync();
            return result.Entity;

        }
        public async Task<EmployeeDomain> Update(EmployeeDomain employee)
        {
            var result =  _dbConContext.Employees.Update(employee);
                    await _dbConContext.SaveChangesAsync();
            return result.Entity;
        }
        public async Task<EmployeeDomain> Delete(EmployeeDomain employee)
        {
            var result = _dbConContext.Employees.Update(employee);
            await _dbConContext.SaveChangesAsync();
            return result.Entity;
        }
    }
}
