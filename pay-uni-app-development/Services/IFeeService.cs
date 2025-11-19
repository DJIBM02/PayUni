using PayUni.Models;

namespace PayUni.Services;

public interface IFeeService
{
    Task<List<Fee>> GetFeesAsync();
    Task<Fee?> GetFeeByIdAsync(string feeId);
}
