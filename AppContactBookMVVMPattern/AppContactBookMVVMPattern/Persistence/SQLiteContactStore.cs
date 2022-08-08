using AppContactBookMVVMPattern.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppContactBookMVVMPattern.Persistence
{
    public class SQLiteContactStore : IContactStore
    {

        private readonly SQLiteAsyncConnection _connection;
        public SQLiteContactStore(ISQLiteDb db)
        {
            _connection = db.GetConnectionAsync();
            _connection.CreateTableAsync<Contact>();
        } 
        public async Task AddContact(Contact contact)
            => await _connection.InsertAsync(contact);

        public async Task DeleteContact(Contact contact)
            => await _connection.DeleteAsync(contact);

        public async Task<IEnumerable<Contact>> GetConstactsAsync()
            => await _connection.Table<Contact>().ToListAsync();

        public async Task<Contact> GetContactAsync(int id)
            => await _connection.GetAsync<Contact>(c => c.Id == id);

        public async Task UpdateContact(Contact contact)
            => await _connection.UpdateAsync(contact);
    }
}
