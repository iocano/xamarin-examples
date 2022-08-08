using AppContactBookMVVMPattern.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppContactBookMVVMPattern
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactDetailPage : ContentPage
    {
        public ContactDetailPage(ContactDetailPageViewModel viewModel = null)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }
}