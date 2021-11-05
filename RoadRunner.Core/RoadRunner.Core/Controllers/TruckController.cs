using Microsoft.AspNetCore.Mvc;
using RoadRunner.Core.Models;
using RoadRunner.Core.Models.DataTransferModels;
using RoadRunner.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Cors;

namespace RoadRunner.Core.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class TruckController : ControllerBase
    {
        private TruckRepository _truckRepository;

        public TruckController(TruckRepository truckRepository)
        {
            _truckRepository = truckRepository;
        }

        [HttpGet("{id}")]
        public async Task<string> Test(int id)
        {
            return JsonSerializer.Serialize(id);
        }

        [HttpPost]
        public async Task<string> PostTest(TruckAPIModel truckModel)
        {
            return JsonSerializer.Serialize(truckModel.Brand + " " + truckModel.Model);
        }

        [HttpPost]
        public async void PopulateRepository()
        {
            _truckRepository.Seed();
        }

        [HttpGet]
        public async Task<List<TruckAPIModel>> Get()
        {
            return _truckRepository.GetAll().Select(truck => TruckAPIModel.FromTruck(truck)).ToList();
        }

        [HttpGet("{id}")]
        public async Task<TruckAPIModel> Get(int id)
        {
            return TruckAPIModel.FromTruck(_truckRepository.GetById(id));
        }

        [HttpPost]
        public async Task<string> Add(TruckAPIModel truckModel)
        {
            if (truckModel.UserId == null) truckModel.UserId = 4;
            return _truckRepository.Add(Truck.FromTruckAPIModel(truckModel)) != null ? "Truck added" : "Could not add truck";
        }

        [HttpPost]
        public async Task<string> Update(TruckAPIModel truckModel)
        {
            return _truckRepository.Update(Truck.FromTruckAPIModel(truckModel)) != null ? "Truck updated" : "Could not update truck";
        }

        [HttpPost]
        public async Task<string> Delete(int id)
        {
            return _truckRepository.Delete(id) != null ? "Truck deleted" : "Truck could not be deleted";
        }
    }
}
