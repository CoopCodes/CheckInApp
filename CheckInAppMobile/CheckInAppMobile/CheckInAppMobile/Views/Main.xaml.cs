using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CheckInAppMobile.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CheckInAppMobile.Views {
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class Main : ContentPage {
        string scanResult = "";
        public Main() {
            //InitializeComponents();
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(Main));
            this.BindingContext = new MainViewModel();
        }

        void Scanned(ZXing.Result result) {
            Device.BeginInvokeOnMainThread(() => {
                scanResult = result.Text + " (type: " + result.BarcodeFormat.ToString() + ")";
                });
        } 
    }
}