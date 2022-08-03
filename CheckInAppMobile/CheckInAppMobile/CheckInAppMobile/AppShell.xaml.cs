using System;
using System.Collections.Generic;
using CheckInAppMobile.ViewModels;
using CheckInAppMobile.Views;
using Xamarin.Forms;

namespace CheckInAppMobile {
    public partial class AppShell : Xamarin.Forms.Shell {
        public AppShell() {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
        }

    }
}
