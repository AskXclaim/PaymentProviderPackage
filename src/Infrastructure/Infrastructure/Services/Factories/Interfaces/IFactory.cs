
using System.Threading.Tasks;

namespace Infrastructure.Services.Factories.Interfaces
{
    public interface IFactory
    {
        Task<object> GetResult(object request);
    }
}