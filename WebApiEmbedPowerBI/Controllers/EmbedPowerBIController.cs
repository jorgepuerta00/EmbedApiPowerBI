using EmbedPowerBI;
using System.Web.Http;
using Commons.DTO;

namespace WebApiEmbedPowerBI.Controllers
{
    [RoutePrefix("api/PowerBI")]
    public class EmbedPowerBIController : ApiController
    {
        /// <summary>
        /// A JSON with result operation.
        /// </summary>
        /// <returns>A JSON with result operation.</returns>
        [Route("GetTokenAccess")]
        [HttpPost] //Always explicitly state the accepted HTTP method
        public IHttpActionResult GetTokenAccess([FromBody] TokenRequest Request)
        {
            ClsEmbedPowerBI EmbedPowerBIApi = new ClsEmbedPowerBI()
            {
                AccessLevel = Request.AccessLevel,
                GroupId = Request.GroupId,
                ReportId = Request.ReportId,
                DatasetId = Request.DatasetId
            };

            var TokenAccess = EmbedPowerBIApi.GetTokenAccess();

            return Ok(TokenAccess);
        }
    }
}
