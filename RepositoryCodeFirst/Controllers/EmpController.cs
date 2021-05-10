using Entity;
using Microsoft.AspNetCore.Mvc;
using RepoService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RepositoryCodeFirst.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        private readonly IRepo _repo;
        public EmpController(IRepo repo)
        {
            _repo = repo;
        }
        [HttpGet("Get")]
        public async Task<IEnumerable<EmployeeDomain>> Get()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                var model = new List<EmployeeDomain>();
                var getData = await _repo.Get();
                foreach (var list in getData)
                {
                    model.Add(new EmployeeDomain
                    {
                        EmpId=list.EmpId,
                        FirstName = list.FirstName,
                        LastName = list.LastName,
                        Address=list.Address,
                        IsActive=list.IsActive,
                        IsDelete=list.IsDelete,
                        CreateOn=list.CreateOn


                    });
                }
                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
        [HttpGet("GetById")]
        public async Task<EmployeeDomain> GetById(int Id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                EmployeeDomain model = new EmployeeDomain();
                var get = await _repo.GetById(Id);
                model = new EmployeeDomain
                {
                    EmpId=model.EmpId,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Address = model.Address,
                    IsActive=model.IsActive,
                    IsDelete=model.IsDelete,
                    CreateOn=model.CreateOn
                };
                return get;
            }
            catch(Exception ex)
            {
                return null;
            }
           
        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(EmployeeDomain employeeDomain)
        {
            if (!ModelState.IsValid)
            {
                BadRequest(ModelState);
            }
            var saveData = new EmployeeDomain
            {
                FirstName = employeeDomain.FirstName,
                LastName = employeeDomain.LastName,
                Address = employeeDomain.Address,
                IsActive=true,
                IsDelete=false,
                CreateOn=DateTime.Now
            };
            if(saveData != null)
            {
                await _repo.Create(saveData);
            }

            return Ok(employeeDomain);
        }
        [HttpPost("Update")]
        public async Task <EmployeeDomain> Update(EmployeeDomain employeeDomain)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }

                var model = await _repo.GetById(employeeDomain.EmpId);
                if(model != null)
                {
                    model.FirstName = employeeDomain.FirstName;
                    model.LastName = employeeDomain.LastName;
                    model.Address = employeeDomain.Address;
                    await _repo.Update(model);
                }
                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        [HttpPost("Delete")]
        public async Task <EmployeeDomain> Delete(EmployeeDomain employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    BadRequest(ModelState);
                }
                var model = await _repo.GetById(employee.EmpId);
                if (model != null)
                {
                    model.IsDelete = true;
                    model.IsActive = false;
                    await _repo.Delete(model);
                }
                return model;
            }
            catch(Exception ex)
            {
                return null;
            }
        }
    }
}
