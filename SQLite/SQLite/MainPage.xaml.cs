using SQLite.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLite
{
    public partial class MainPage : ContentPage
    {

        private readonly SQLiteAsyncConnection _connection;
        private ObservableCollection<Recipe> _recipes;

        public MainPage()
        {
            InitializeComponent();
            _connection = DependencyService.Get<ISQLiteDb>().GetConnection();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await _connection.CreateTableAsync<Recipe>();
            var recipes = await _connection.Table<Recipe>().ToListAsync();
            _recipes = new ObservableCollection<Recipe>(recipes);
            recipeList.ItemsSource = _recipes;
        }


        async void OnAdd(object sender, EventArgs e)
        {
            var recipe = new Recipe { Name = "Recipe " + DateTime.Now.Ticks };
            await _connection.InsertAsync(recipe);
            _recipes.Add(recipe);
        }

        async void OnDelete(object sender, EventArgs e)
        {
            var recipe = _recipes[0];
            await _connection.DeleteAsync(recipe);
            _recipes.Remove(recipe);
        }

        void OnUpdate(object sender, EventArgs e)
        {
            var recipe = _recipes.FirstOrDefault();

            // problem some times update list sometimes not
            //recipe.Name += " Updated";

            // work arround 
            var name = recipe.Name + " Updated";
            var id = recipe.Id;
            _recipes.Remove(recipe);
            _recipes.Insert(0, new Recipe { Id = id, Name = name });

            _connection.UpdateAsync(recipe);
        }

        private void OnSelected(object sender, SelectedItemChangedEventArgs e)
            => recipeList.SelectedItem = null;
    }
}
