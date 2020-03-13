using Microsoft.Extensions.Logging;
using RestSharp;
using Searchfight.IServices.Logger;
using System;
using System.Linq;

namespace Searchfight.Services.Logger
{
    public class ServiceLogger : IServiceLogger
    {

        private readonly ILogger<ServiceLogger> _logger;

        public ServiceLogger(ILoggerFactory logger)
        {
            _logger = logger.CreateLogger<ServiceLogger>();
        }

        public void LogRequestError(IRestRequest request, IRestResponse response)
        {
            //Get the values of the parameters passed to the API
            string parameters = string.Join(", ", request.Parameters.Select(x => x.Name.ToString() + "=" + ((x.Value == null) ? "NULL" : x.Value)).ToArray());

            //Set up the information message with the URL, the status code, and the parameters.
            string info = "Request to " + request.Resource + " failed with status code " + response.StatusCode + ", parameters: "
                + parameters + ", and content: " + response.Content;

            //Acquire the actual exception
            Exception ex;
            if (response != null && response.ErrorException != null)
            {
                ex = response.ErrorException;
            }
            else
            {
                ex = new Exception(info);
                info = string.Empty;
            }

            //Log the exception and info message
            _logger.LogError(ex, info);
        }
    }
}
