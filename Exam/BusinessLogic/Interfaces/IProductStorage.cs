using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System.Collections.Generic;

namespace BusinessLogic.Interfaces
{
    public interface IProductStorage
    {
        List<ProductViewModel> GetFullList();
        List<ProductViewModel> GetFiltredList(ProductBindingModel model);
        ProductViewModel GetElement(ProductBindingModel model);
        void Insert (ProductBindingModel model);
        void Update(ProductBindingModel model);
        void Delete(ProductBindingModel model);
    }
}
