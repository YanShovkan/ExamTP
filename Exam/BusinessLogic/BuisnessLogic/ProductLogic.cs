using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;

namespace BusinessLogic.BuisnessLogic
{
    public class ProductLogic
    {
        private IProductStorage productStorage;

        public ProductLogic(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public List<ProductViewModel> Read(ProductBindingModel model)
        {
            if (model == null)
            {
                return productStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ProductViewModel> { productStorage.GetElement(model) };
            }
            return productStorage.GetFiltredList(model);
        }

        public void CreateOrUpdate(ProductBindingModel model)
        {
            
            if (model.Id.HasValue)
            {
                productStorage.Update(model);
            }
            else
            {
                productStorage.Insert(model);
            }
        }

        public void Delete(ProductBindingModel model)
        {
            var element = productStorage.GetElement(model);

            if(element == null)
            {
                throw new Exception("Элемент не найден");
            }

            productStorage.Delete(model);
        }
    }
}
