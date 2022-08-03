using System.ComponentModel;
using Xamarin.Forms;
using CheckInAppMobile.ViewModels;

namespace CheckInAppMobile.Views {
    public partial class ItemDetailPage : ContentPage {
        public ItemDetailPage() {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}