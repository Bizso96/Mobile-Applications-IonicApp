using RoadRunner.Core.Models.DataTransferModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunner.Core.Models
{
    public class Truck
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public TruckStatusEnum TruckStatus { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        public static Truck FromTruckAPIModel(TruckAPIModel truckModel)
        {
            if (truckModel == null) return null;

            TruckStatusEnum truckStatus;
            if (!Enum.TryParse(truckModel.TruckStatus, out truckStatus)) truckStatus = TruckStatusEnum.Available;

            return new Truck
            {
                Id = truckModel.Id,
                UserId = truckModel.UserId ?? -1,
                Brand = truckModel.Brand,
                Model = truckModel.Model,
                TruckStatus = truckStatus
            };
        }
    }
}
