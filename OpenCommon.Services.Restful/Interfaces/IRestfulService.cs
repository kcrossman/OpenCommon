using System.Threading.Tasks;
using OpenCommon.Services.Interfaces;
using OpenCommon.Services.Restful.Models;

namespace OpenCommon.Services.Restful.Interfaces
{
    /// <summary>
    /// Use this interface for any Restful service.
    /// </summary>
    public interface IRestfulService : IService
    {
        Task<RestfulResponse> SendRequest(RestfulRequest request);
    }
}
