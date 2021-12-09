using IdentityModel.Client;
using IdentityService.BL;
using IdentityService.BO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL objIUserBL;
        public UserController(IUserBL objIUserBL)
        {
            this.objIUserBL = objIUserBL;
        }

        [Route("Authenticate")]
        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] object objRequest)
        {
            var objRequestParams = JsonConvert.DeserializeObject<Dictionary<string, object>>(objRequest.ToString());
            var objUserBO = objIUserBL.Authenticate(objRequestParams["Username"].ToString(), objRequestParams["Password"].ToString());
            if (objUserBO != null)
            {
                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5011");
                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = "client",
                    ClientSecret = "secret",
                    Scope = "api1"
                });
                objUserBO.Token = tokenResponse.AccessToken;
                return Ok(objUserBO);
            }
            return Ok(new { data = "Username hoặc Password không đúng!" });
        }
    }
}
