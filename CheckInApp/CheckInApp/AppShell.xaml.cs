using System;
using System.Collections.Generic;
using CheckInApp.ViewModels;
using CheckInApp.Views;
using Xamarin.Forms;

namespace CheckInApp {
    public partial class AppShell : Xamarin.Forms.Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
