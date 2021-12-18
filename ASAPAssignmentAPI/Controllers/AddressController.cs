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
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        IRepository<Address> AddressRepo;
        IUnitOfWork IunitOfWork;
        ResultViewModel Result;
        public AddressController(IUnitOfWork _IunitOfWork)
        {
            IunitOfWork = _IunitOfWork;
            AddressRepo = IunitOfWork.GetAddressRepo();
            Result = new ResultViewModel();
        }

        // return List of Address by User ID
        [HttpGet]
        [Route("{PersonId}")]
        public async Task<ResultViewModel> GetAddress(int PersonId)
        {
            Result.Data = await AddressRepo.FindByCondition(i => i.PersonID == PersonId);
            Result.IsSucess = true;
            return Result;
        }

        // Add Address  
        [HttpPost]
        [Route("Add")]
        public async Task<ResultViewModel> AddAddress(Address address)
        {
            Result.Data = await AddressRepo.Add(address);
            await IunitOfWork.Save();
            Result.IsSucess = true;
            Result.Message = "Added Address SuccessFully";
            return Result;
        }

        // Edit Address  
        [HttpPost]
        [Route("Edit")]
        public async Task<ResultViewModel> EditAddress(Address address)
        {
            Result.Data = await AddressRepo.Update(address);
            await IunitOfWork.Save();
            Result.IsSucess = true;
            Result.Message = "Edit Address SuccessFully";
            return Result;
        }

        // Delete Address  
        [HttpDelete]
        [Route("Delete/{addressID}")]
        public async Task<ResultViewModel> DeleteAddress(int addressID)
        {
            var Address = await AddressRepo.GetByIDAsync(addressID);
            if(Address!=null)
            {
                Result.Data = await AddressRepo.Remove(Address);
                await IunitOfWork.Save();
                Result.IsSucess = true;
                Result.Message = "Delete Address SuccessFully";
                return Result;
            }

            Result.IsSucess = false;
            Result.Message = "Address Not Found ";
            return Result;


        }
    }
}
