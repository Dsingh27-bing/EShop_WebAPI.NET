using ProductApplicationCore.Model;

namespace ProductApplicationCore.Contracts.Service;

public interface IVariationValueServiceAsync
{
    public Task<VariationResponseModel> GetByIdAsync(int id);
    public Task<int> InsertAsync(VariationRequestModel reqModel);
}