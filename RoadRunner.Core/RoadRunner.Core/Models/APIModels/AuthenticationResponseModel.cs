using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoadRunner.Core.Models.APIModels
{
    public class AuthenticationResponseModel
    {
        public int id { get; set; }
        public string userName { get; set; }
        public string token { get; set; }


        public AuthenticationResponseModel(User user, string token)
        {
            id = user.Id;
            userName = user.UserName;
            this.token = token;
        }
    }
}
