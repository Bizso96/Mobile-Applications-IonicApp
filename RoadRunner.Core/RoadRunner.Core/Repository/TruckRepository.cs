using RoadRunner.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunner.Core.Repository
{
    public class TruckRepository
    {
        private RoadRunnerContext _dbContext;

        public TruckRepository(RoadRunnerContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public Truck GetById(int id)
        {
            return _dbContext.Trucks.FirstOrDefault(truck => truck.Id == id);
        }

        public List<Truck> GetAll()
        {
            return _dbContext.Trucks.ToList();
        }

        public Truck Add(Truck truck)
        {
            if (truck == null) return null;
            _dbContext.Trucks.Add(truck);
            int numberOfChanges = _dbContext.SaveChanges();
            return numberOfChanges > 0 ? truck : null;
        }

        public Truck Delete(Truck truck)
        {
            if (truck == null) return null;

            Truck matchById = GetById((int)truck.Id);
            if (matchById == null) return null;

            _dbContext.Trucks.Remove(matchById);
            int numberOfChanges = _dbContext.SaveChanges();
            return numberOfChanges > 0 ? matchById : null;
        }

        public Truck Delete(int id)
        {
            Truck matchById = GetById(id);

            if (matchById == null) return null;

            _dbContext.Trucks.Remove(matchById);
            int numberOfChanges = _dbContext.SaveChanges();
            return numberOfChanges > 0 ? matchById : null;
        }

        public Truck Update(Truck truck)
        {
            if (truck == null) return null;

            Truck matchById = GetById((int) truck.Id);

            if (matchById == null) return null;

            matchById.Brand = truck.Brand;
            matchById.Model = truck.Model;
            _dbContext.Update<Truck>(matchById);
            _dbContext.SaveChanges();

            return matchById;
        }

        public void Seed()
        {
            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 4,
                Brand = "Tatra",
                Model = "Phoenix",
                TruckStatus = TruckStatusEnum.Available
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 4,
                Brand = "International",
                Model = "Lonestar",
                TruckStatus = TruckStatusEnum.Available
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 4,
                Brand = "International",
                Model = "HX 520",
                TruckStatus = TruckStatusEnum.Available
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 4,
                Brand = "International",
                Model = "Transtar",
                TruckStatus = TruckStatusEnum.Available
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 4,
                Brand = "MAN",
                Model = "TGS",
                TruckStatus = TruckStatusEnum.LowFuel
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 5,
                Brand = "MAN",
                Model = "TGS",
                TruckStatus = TruckStatusEnum.Unavailable
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 5,
                Brand = "Mercedes-Benz",
                Model = "Actros",
                TruckStatus = TruckStatusEnum.Available
            });

            _dbContext.Trucks.Add(new Truck
            {
                Id = 0,
                UserId = 4,
                Brand = "Volvo",
                Model = "FH-16",
                TruckStatus = TruckStatusEnum.UnderRepair
            });

            _dbContext.SaveChanges();
        }
    }
}
