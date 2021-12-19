using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using Repositorys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASAPAssignmentAPI.Controllers
{
    [EnableCors("AllowOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        IRepository<Person> PersonRepo;
        IUnitOfWork IunitOfWork;
        ResultViewModel Result;
        public PersonController(IUnitOfWork _IunitOfWork)
        {
            IunitOfWork = _IunitOfWork;
            PersonRepo = IunitOfWork.GetPersonRepo();
            Result = new ResultViewModel();
        }

        // return all Person
        [HttpGet]
        public async Task<ResultViewModel> GetAllPerson()
        {
            Result.Data = await PersonRepo.GetAsync();
            Result.IsSucess = true;
            return Result;
        }

        // return Person By ID
        [Route("{PersonID}")]
        [HttpGet ]
        public async Task<ResultViewModel> GetPerson(int PersonID )
        {
            Result.Data = await PersonRepo.GetByIDAsync(PersonID);
            Result.IsSucess = true;
            return Result;
        }

        // Add Person  
        [HttpPost]
        [Route("Add")]
        public async Task<ResultViewModel> AddPerson(Person person)
        {
            Result.Data = await PersonRepo.Add(person);
            await IunitOfWork.Save();
            Result.IsSucess = true;
            Result.Message = "Added Person SuccessFully";
            return Result;
        }

        // Edit Person  
        [HttpPost]
        [Route("Edit")]
        public async Task<ResultViewModel> EditPerson(Person person)
        {
            Result.Data = await PersonRepo.Update(person);
            await IunitOfWork.Save();
            Result.IsSucess = true;
            Result.Message = "Edit Person SuccessFully";
            return Result;
        }

        // Delete Person  
        [HttpDelete]
        [Route("Delete/{PersonID}")]
        public async Task<ResultViewModel> DeletePerson(int PersonID)
        {
            var person = await PersonRepo.GetByIDAsync(PersonID);
            if(person!=null)
            {
                Result.Data = await PersonRepo.Remove(person);
                await IunitOfWork.Save();
                Result.IsSucess = true;
                Result.Message = "Delete Person SuccessFully";
                return Result;
            }
       
            Result.IsSucess = false;
            Result.Message = "Person Not Found";
            return Result;
        }
    }
}
