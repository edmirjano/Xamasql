using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamaSqlLite.DbContext;
using XamaSqlLite.Models;
using XamaSqlLite.Views;
using XamaSqlLite.Services;
using SQLite;
using System.Collections.ObjectModel;
using System.IO;

//using XamaSqlLite.ViewModels;

namespace XamaSqlLite.Views
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class ItemsPage : ContentPage
    {
        private SQLiteAsyncConnection _connection;
        private ObservableCollection<Item> _items;
        public ItemsPage()
        {
            InitializeComponent();

            var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, "TestDB.db3");

            _connection = new SQLiteAsyncConnection(path);
        }

         void OnItemSelected(object sender, EventArgs args)
        {
            var layout = (BindableObject)sender;
            var item = (Item)layout.BindingContext;
            //await Navigation.PushAsync(new ItemDetailPage(new ItemDetailViewModel(item)));
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            var item = new Item { Text = "filani", Description = "fisteqi" };
            await _connection.InsertAsync(item);
            _items.Add(item);

            //await Navigation.PushModalAsync(new NavigationPage(new NewItemPage()));
        }

        protected override async void OnAppearing()
        {
            await _connection.CreateTableAsync<Item>();

            var list = await _connection.Table<Item>().ToListAsync();
            _items = new ObservableCollection<Item>(list);
            ItemsCollectionView.ItemsSource = _items;

            base.OnAppearing();
        }
    }
}