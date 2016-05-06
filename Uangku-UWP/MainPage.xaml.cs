using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Uangku_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
               
            ObservableCollection<MenuItem> dataList = new ObservableCollection<MenuItem>();
            dataList.Add(new MenuItem() { Name = "Tambah", Icon = "" });
            dataList.Add(new MenuItem() { Name = "Tentang", Icon = "" });
            MyList.ItemsSource = dataList;
            DateTime today = DateTime.Today;
            LoadList();

        }

        private void LoadList()
        {
            using (var database = new DBHelper())
            {
                int count = database.ListItems.Count();
                if (count > 0)
                {
                    ContentList.ItemsSource = database.ListItems.ToList();
                }
                else
                {
                    ContentList.ItemsSource = null;
                }
                Item[] Items = database.ListItems.ToArray();
                double pendapatan = 0, pengeluaran = 0, total = 0;
                int i;
                for (i = 0; i < count; i++)
                {
                    Item item = Items[i];
                    if (item.itemType == 1)
                    {
                        pendapatan += item.amount;
                    }
                    else
                    {
                        pengeluaran += item.amount;
                    }
                }
                total = pendapatan - pengeluaran;
                actionbar.Text = "Uangku Rp " + total;
                txtpendapatan.Text = "Rp " + pendapatan;
                txtpengeluaran.Text = "Rp " + pengeluaran;
            }
        }
        //92a955
        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void MyList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (MyList.SelectedIndex == 0)
            {
                this.Frame.Navigate(typeof(AddData));
            }
            else
            {

            }
        }

        private async void confrimdialog()
        {
           
            

        }

        private void ContentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            using (var database = new DBHelper())
            {

                Item[] Items = database.ListItems.ToArray();
                try
                {
                    database.ListItems.Remove(Items[ContentList.SelectedIndex]);
                    database.SaveChanges();
                }
                catch (Exception ex)
                {

                }
                LoadList();
            }

        }
    }
}
