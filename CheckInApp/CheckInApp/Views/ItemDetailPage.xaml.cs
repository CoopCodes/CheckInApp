using System.ComponentModel;
using Xamarin.Forms;
using CheckInApp.ViewModels;

namespace CheckInApp.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}