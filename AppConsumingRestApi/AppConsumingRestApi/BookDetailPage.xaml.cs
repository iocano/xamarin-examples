using AppConsumingRestApi.Models;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppConsumingRestApi
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookDetailPage : ContentPage
    {
        public BookDetailPage(Item item)
        {
            InitializeComponent();
            if (item == null)
            {
                throw new ArgumentNullException(nameof(item));
            }
            BindingContext = item;
        }
    }
}