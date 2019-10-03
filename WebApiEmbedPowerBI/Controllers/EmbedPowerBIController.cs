using EmbedPowerBI;
using System.Web.Http;
using Commons.DTO;
using System.Net;
using System.Net.Http;
using System;

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
        public HttpResponseMessage GetTokenAccess([FromBody] TokenRequest request)
        {
            HttpResponseMessage response;
            try
            {
                TokenEmbedPowerBI EmbedPowerBIApi = new TokenEmbedPowerBI()
                {
                    GroupId = request.GroupId,
                    ReportId = request.ReportId,
                    DatasetId = request.DatasetId,
                    AccessLevel = request.AccessLevel
                };

                var result = EmbedPowerBIApi.GetTokenAccess();

                response = Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception ex)
            {
                HttpError myCustomError = new HttpError(ex.Message) { { "IsSuccess", false } };
                return Request.CreateErrorResponse(HttpStatusCode.OK, myCustomError);
            }
            return response;
        }
    }
}
