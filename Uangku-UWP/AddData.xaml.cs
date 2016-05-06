using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Uangku_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class AddData : Page
    {
        

        public AddData()
        {
            this.InitializeComponent();
           
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }


        
        
        private void AddData_Click(object sender, RoutedEventArgs e)
        {
            using(var database = new DBHelper())
            {
                DateTime dt = new DateTime(dpdate.Date.Year, dpdate.Date.Month, dpdate.Date.Day, tpwaktu.Time.Hours, tpwaktu.Time.Minutes, tpwaktu.Time.Seconds);
                var item = new Item {
                    dateTime = string.Format("{0:dd/MM/yyyy hh:mm}", dt), 
                    itemId = Guid.NewGuid(),
                    amount = Double.Parse(txtjumlah.Text), 
                    desc = txtketerangan.Text,
                    itemType = cbjenis.SelectedIndex 
                };
                database.ListItems.Add(item);
                try {
                    database.SaveChanges();
                    this.Frame.Navigate(typeof(MainPage));
                }
                catch(Exception ex){
                    Debug.WriteLine(ex.Message);
                }
            }
           
          
        }
    }
}
