using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XamaSqlLite.DbContext;
using XamaSqlLite.Models;

namespace XamaSqlLite.Services
{
    public class ItemsService
    {
        public SQLiteAsyncConnection _connection;
        public void InitConnection()
        {
            _connection = DependencyService.Get<IDBContext>().GetConnection();

            _connection.CreateTableAsync<Item>();
        }

        public async Task<bool> AddItemAsync(Item item)
        {
            await _connection.InsertAsync(item);

            return await Task.FromResult(true);
        }

        public async Task<IEnumerable<Item>> GetItemsAsync(bool forceRefresh = false)
        {
            var items = await _connection.Table<Item>().ToListAsync();
            var i = items.ToList<Item>();
            return await Task.FromResult(i);
        }

    }
}
