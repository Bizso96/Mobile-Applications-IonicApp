using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunner.Core.Models.DataTransferModels
{
    public class TruckAPIModel
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string TruckStatus { get; set; }

        public static TruckAPIModel FromTruck(Truck truck)
        {
            if (truck == null) return null;

            return new TruckAPIModel
            {
                Id = (int) truck.Id,
                UserId = truck.UserId,
                Brand = truck.Brand,
                Model = truck.Model,
                TruckStatus = truck.TruckStatus.ToString()
            };
        }
    }
}
