using AdminWebApp.Extensions;
using AdminWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace AdminWebApp.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly HttpClient _client;
        public IdentityService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<UserModel> Authenticate(UserModel objUser)
        {
            var response = await _client.PostAsJson<UserModel>("/User/Authenticate", objUser);
            var dataAsString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<UserModel>(dataAsString);
        }
    }
}
