using System.Threading.Tasks;
using AspnetRunBasics.Models;

namespace AspnetRunBasics.Services
{
    public interface IAggregatorService
    {
        Task<string> InsertSaleOrder(SOModel objSO);
    }
}