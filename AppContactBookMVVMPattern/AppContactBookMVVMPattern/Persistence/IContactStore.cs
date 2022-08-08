using AppContactBookMVVMPattern.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppContactBookMVVMPattern.Persistence
{
    public interface IContactStore
    {
        Task<IEnumerable<Contact>> GetConstactsAsync();

        Task<Contact> GetContactAsync(int id);

        Task AddContact(Contact contact);

        Task UpdateContact(Contact contact);

        Task DeleteContact(Contact contact);

    }
}
