using BusinessLogic.BindingModels;
using BusinessLogic.Interfaces;
using BusinessLogic.ViewModels;
using DatabaseImplements.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DatabaseImplements.Implements
{
    public class ProductStorage : IProductStorage
    {
        public List<ProductViewModel> GetFullList()
        {
            using (var context = new DatabaseImplement())
            {
                return context.Products
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public List<ProductViewModel> GetFiltredList(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                return context.Products
                    .Where(rec =>(model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public ProductViewModel GetElement(ProductBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                var product = context.Products
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return product != null ?
                    CreateModel(product) : null;
            }
        }

        public void Insert(ProductBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                context.Products.Add(CreateModel(model, new Product()));
                context.SaveChanges();
            }
        }

        public void Update(ProductBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (product != null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, product);
                context.SaveChanges();
            }
        }

        public void Delete(ProductBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var product = context.Products.FirstOrDefault(rec => rec.Id == model.Id);
                if (product != null)
                {
                    throw new Exception("Элемент не найден");
                }
                context.Remove(product);
                context.SaveChanges();
            }
        }

        public ProductViewModel CreateModel(Product product)
        {
            return new ProductViewModel
            {
                Id = product.Id,
                Name = product.Name,
                DateCreate = product.DateCreate
            };
        }

        public Product CreateModel(ProductBindingModel model, Product product)
        {
            product.Name = model.Name;
            product.DateCreate = model.DateCreate;
            return product;
        }
    }
}
