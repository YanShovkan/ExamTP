using System.Collections.Generic;
using BusinessLogic.Interfaces;
using BusinessLogic.BindingModels;
using BusinessLogic.ViewModels;
using System;

namespace BusinessLogic.BuisnessLogic
{
    public class ComponentLogic
    {
        private IComponentStorage componentStorage;

        public ComponentLogic(IComponentStorage componentStorage)
        {
            this.componentStorage = componentStorage;
        }

        public List<ComponentViewModel> Read(ComponentBindingModel model)
        {
            if (model == null)
            {
                return componentStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<ComponentViewModel> { componentStorage.GetElement(model) };
            }
            return componentStorage.GetFiltredList(model);
        }

        public void CreateOrUpdate(ComponentBindingModel model)
        {

            if (model.Id.HasValue)
            {
                componentStorage.Update(model);
            }
            else
            {
                componentStorage.Insert(model);
            }
        }

        public void Delete(ComponentBindingModel model)
        {
            var element = componentStorage.GetElement(model);

            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }

            componentStorage.Delete(model);
        }
    }
}
