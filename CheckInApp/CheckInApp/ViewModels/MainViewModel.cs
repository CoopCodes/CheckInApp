using System;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;
using System.Data.SqlClient;
using System.IO;

namespace CheckInApp.ViewModels {
    public class MainViewModel : BaseViewModel {
        Dictionary<string, Models.EventType> eventTypes = Globals.EventTypes;
        
        public bool CheckedIn { get; set; } = false;
        public int DeviceID { get; set; } //Make sure to set value, either from register, log in, or from file

        public MainViewModel() {
            DeviceID = Globals.DeviceID;
        }

        #region Events

        public void CheckInClick(object sender, EventArgs e) {
            //QR Code stuff


            if (!CheckedIn) {
                Query.Insert("spEvents_Add", Query.Event, eventTypes["Check In"]);
                //sender.text = "Check Out";
            }
            else {
                Query.Insert("spEvents_Add", Query.Event, eventTypes["Check Out"]);
                //sender.text = "Check In";
            }
        }

        private async void btnScan_Clicked(object sender, EventArgs e) {
            try {
                var scanner = DependencyService.Get<Services.IQrScanningService>();
                var result = await scanner.ScanAsync();
                if (result != null) {
                    //txtBarcode.Text = result;
                }
            }
            catch (Exception ex) {
                throw;
            }
        }

        #endregion


        #region Old
        //Title = "About";
        //OpenWebCommand = new Command(async () => await Browser.OpenAsync("https://aka.ms/xamain-quickstart"));
        //public ICommand OpenWebCommand { get; }
        #endregion
    }
}