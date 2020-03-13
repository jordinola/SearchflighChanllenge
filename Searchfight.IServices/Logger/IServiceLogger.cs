using RestSharp;
using System;

namespace Searchfight.IServices.Logger
{
    public interface IServiceLogger
    {
        void LogRequestError(IRestRequest request, IRestResponse response);
    }
}
