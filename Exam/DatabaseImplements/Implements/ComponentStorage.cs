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
    public class ComponentStorage : IComponentStorage
    {
        public List<ComponentViewModel> GetFullList()
        {
            using (var context = new DatabaseImplement())
            {
                return context.Components
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public List<ComponentViewModel> GetFiltredList(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                return context.Components
                    .Include(rec => rec.Product)
                    .Where(rec => rec.ProductId == model.ProductId)
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public ComponentViewModel GetElement(ComponentBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            using (var context = new DatabaseImplement())
            {
                var component = context.Components
                    .Include(rec => rec.Product)
                    .FirstOrDefault(rec => rec.Id == model.Id);

                return component != null ?
                    CreateModel(component) : null;
            }
        }

        public void Insert(ComponentBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                context.Components.Add(CreateModel(model, new Component()));
                context.SaveChanges();
            }
        }

        public void Update(ComponentBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var component = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if(component != null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, component);
                context.SaveChanges();
            }
        }

        public void Delete(ComponentBindingModel model)
        {
            using (var context = new DatabaseImplement())
            {
                var component = context.Components.FirstOrDefault(rec => rec.Id == model.Id);
                if (component != null)
                {
                    throw new Exception("Элемент не найден");
                }
                context.Remove(component);
                context.SaveChanges();
            }
        }

        public ComponentViewModel CreateModel(Component component)
        {
            return new ComponentViewModel
            {
                Id = component.Id,
                Name = component.Name,
                Count = component.Count,
                ProductId = component.ProductId
            };
        }

        public Component CreateModel(ComponentBindingModel model, Component component)
        {
            component.ProductId = model.ProductId;
            component.Name = model.Name;
            component.Count = model.Count;
            return component;
        }
    }
}
