using MicroService.PhoneBook.Data;
using MicroService.PhoneBook.Data.Entities;
using MicroService.PhoneBook.Repository.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MicroService.PhoneBook.Repository
{
    public class PhoneBookRepository : IPhoneBookRepository
    {
        public List<EntryModel> GetList(DataContext context, string byName, string byPhoneNumber)
        {
            if (context.Entry.Count() == 0)
                return new List<EntryModel>();

            var entryEntities = context.Entry.ToList();

            if (!string.IsNullOrEmpty(byName))
                entryEntities = entryEntities.Where(w => w.Name.ToLower().Contains(byName.ToLower())).ToList();

            if (!string.IsNullOrEmpty(byPhoneNumber))
                entryEntities = entryEntities.Where(w => w.PhoneNumber.Contains(byPhoneNumber)).ToList();

            return MapEntitiesToModel(entryEntities);
        }

        public void Insert(DataContext context, List<EntryModel> models)
        {
            foreach(var model in models)
            {
                model.Id = Guid.NewGuid();

                context.Entry.Add(new EntryEntity()
                {
                    Id = model.Id,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                });
            }

            context.SaveChanges();
        }

        public void Update(DataContext context, EntryModel model)
        {
            var entity = context.Entry.Find(model.Id);
            entity.Name = model.Name;
            entity.PhoneNumber = model.PhoneNumber;

            context.SaveChanges();
        }

        public void Delete(DataContext context, Guid id)
        {
            var entity = context.Entry.Find(id);
            context.Remove(entity);

            context.SaveChanges();
        }

        #region Private methods

        private List<EntryModel> MapEntitiesToModel(List<EntryEntity> entities)
        {
            List<EntryModel> entries = new List<EntryModel>();
            foreach (var entity in entities)
            {
                entries.Add(new EntryModel()
                {
                    Id = entity.Id,
                    Name = entity.Name,
                    PhoneNumber = entity.PhoneNumber
                });
            }

            return entries;
        }

        #endregion
    }
}
