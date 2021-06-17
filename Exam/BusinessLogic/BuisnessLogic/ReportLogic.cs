using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace BusinessLogic.BuisnessLogic
{
    class ReportLogic
    {
        private readonly IProductStorage productStorage;

        public ReportLogic(IProductStorage productStorage)
        {
            this.productStorage = productStorage;
        }

        public List<ReportViewModel> GetOrders(ProductBindingModel model)
        {
            var products = productStorage.GetFiltredList(model);
            var list = new List<ReportViewModel>();
            foreach (var product in products)
            {
                var record = new ReportViewModel
                {
                    ProductName = product.Name,
                    DateCreate = product.DateCreate
                };
                foreach (var component in product.ProductComponents)
                {
                    record.ComponentName = component.Value.Item2;
                    record.ComponentCount = component.Value.Item1;
                    list.Add(record);
                }
            }
            return list;
        }
        public void SaveJSONDataContract(ProductBindingModel model)
        {
            DataContractJsonSerializer formatter = new DataContractJsonSerializer(typeof(List<ReportViewModel>));
            using (FileStream fs = new FileStream("otchet.json", FileMode.OpenOrCreate))
            {
                formatter.WriteObject(fs, GetOrders(model));
            }
        }
    }
}
