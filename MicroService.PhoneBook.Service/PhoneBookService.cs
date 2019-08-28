using MicroService.PhoneBook.Data;
using MicroService.PhoneBook.Repository.Model;
using MicroService.PhoneBook.Service.Domain;
using System;
using System.Collections.Generic;

namespace MicroService.PhoneBook.Service
{
    public class PhoneBookService : IPhoneBookService
    {

        private readonly DataContext _context;
        private readonly IPhoneBookRepository _phoneBookRepository;
        public PhoneBookService(DataContext context, IPhoneBookRepository phoneBookRepository)
        {
            _context = context;
            _phoneBookRepository = phoneBookRepository;
        }

        public List<Entry> GetPhoneBookEntries(string byName, string byPhoneNumber)
        {
            return MapModelsToEntry(_phoneBookRepository.GetList(_context, byName, byPhoneNumber));
        }

        public List<Entry> SaveEntries(List<EditEntry> entries)
        {
            var models = MapCreateEntryToModel(entries);
            _phoneBookRepository.Insert(_context, models);

            //return the inserted models
            return MapModelsToEntry(models);
        }

        public void Update(Guid id, EditEntry entry)
        {
            _phoneBookRepository.Update(_context, new EntryModel() {  Id = id, Name = entry.Name, PhoneNumber = entry.PhoneNumber});
        }

        public void Delete(Guid id)
        {
            _phoneBookRepository.Delete(_context, id);
        }

        private List<Entry> MapModelsToEntry(List<EntryModel> models)
        {
            List<Entry> entries = new List<Entry>();
            foreach(var model in models)
            {
                entries.Add(new Entry()
                {
                    Id = model.Id,
                    Name = model.Name,
                    PhoneNumber = model.PhoneNumber
                });
            }

            return entries;
        }

        private List<EntryModel> MapCreateEntryToModel(List<EditEntry> entries)
        {
            List<EntryModel> models = new List<EntryModel>();
            foreach (var entry in entries)
            {
                models.Add(new EntryModel()
                {
                    Name = entry.Name,
                    PhoneNumber = entry.PhoneNumber
                });
            }

            return models;
        }

       
    }
}
