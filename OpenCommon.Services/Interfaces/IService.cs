using System.Threading.Tasks;
using OpenCommon.DependencyInjection.Attributes;
using OpenCommon.Services.Models;

namespace OpenCommon.Services.Interfaces
{
    /// <summary>
    /// Use this interface for any Service class.
    /// </summary>
    [Scoped]
    public interface IService
    {
        Task<ServiceReceipt> SendRequest(ServiceRequest request);
    }
}
