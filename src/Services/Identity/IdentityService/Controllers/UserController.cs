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
using Microsoft.Extensions.Configuration;

namespace IdentityService.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserBL objIUserBL;
        private readonly IConfiguration _config;
        public UserController(IUserBL objIUserBL, IConfiguration config)
        {
            _config = config;
            this.objIUserBL = objIUserBL;
        }

        [Route("Authenticate")]
        [HttpPost]
        public async Task<ActionResult> Authenticate([FromBody] object objRequest)
        {
            var objRequestParams = JsonConvert.DeserializeObject<Dictionary<string, object>>(objRequest.ToString());
            var objUserBO = objIUserBL.Authenticate(objRequestParams["UserName"].ToString(), objRequestParams["Password"].ToString());
            if (objUserBO != null)
            {
                var client = new HttpClient();
                var disco = await client.GetDiscoveryDocumentAsync(_config["IdentitySettings:IdentityHost"]);
                // request token
                var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
                {
                    Address = disco.TokenEndpoint,
                    ClientId = _config["Identity:client"],
                    ClientSecret = _config["Identity:secret"],
                    Scope = _config["Identity:api1"]
                });
                // objUserBO.Token = tokenResponse.AccessToken;
                objUserBO.Token = "eyJhbGciOiJSUzI1NiIsImtpZCI6IjBFNDkxQjEwMkE3QUE5Rjc5Q0U4NUEzMDAzMkQwRkNFIiwidHlwIjoiYXQrand0In0.eyJuYmYiOjE2NDA3MDM1NTIsImV4cCI6MTY0MDcwNzE1MiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDExIiwiYXVkIjoiaHR0cDovL2xvY2FsaG9zdDo1MDExL3Jlc291cmNlcyIsImNsaWVudF9pZCI6ImNsaWVudCIsImp0aSI6IjJFQjU3Q0FGMUUxNzExQjUzRDU3NUMyMDBEMkZCRDNGIiwiaWF0IjoxNjQwNzAzNTUyLCJzY29wZSI6WyJhcGkxIl19.CK1nnReZIi92ZfMYGJYmubV-gxj45Lat067AIhd9ORwzFWLurFFZB-CN5HIMXkDdqTldfZ6wlkmHqkHD4cD5fJX6HXPPzLQVbGejCe62vF5TFtJnAXlyA-aB2dG3_hcXEWWdf-LaYuBaba607G_FZlC0PnhZt3kiSb53HpHJ0nlQ-skv3tF63KvavTpIg1emo7bgDxC-HG6lu63mPnY9bXvuC_gk9_GZ6BY0V4z3NY5FxidzIM6FgG2R-N8joUfiA5EOl1K-TiLKYBJccxbFOTtLrIpYNMkfbNBBc0Q8vWwvnGrGoBeKxTQLEgjlDTanBfteUQVKexvScHiQaHEnfg";
                return Ok(objUserBO);
            }
            return Ok(new { data = "Username hoặc Password không đúng!" });
        }
    }
}
