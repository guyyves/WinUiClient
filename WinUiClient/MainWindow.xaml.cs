using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using Microsoft.WindowsAppSDK.Runtime;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Contacts;
using Windows.Foundation;
using Windows.Foundation.Collections;
using WinUiClient.Data;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace WinUiClient
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        private AppDbContext db;
        private List<Bewoner> BewonerList;
        private bool isClosed;

        public MainWindow()
        {
            this.InitializeComponent();
            
            isClosed = new bool();

            BewonerList = new List<Bewoner>();


            db = new AppDbContext();
            db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                //sort list view on alfabetical order
                BewonerList = db.Bewoners.OrderBy(b => b.Name).ToList();
              
                

                bewonerListView.ItemsSource = BewonerList;


        }
        //reloads the listview
        private void LoadData()
        {
            BewonerList = db.Bewoners.OrderBy(b => b.Name).ToList();
            bewonerListView.ItemsSource = BewonerList;
        }
        //filter on specific item job
        private void SortButton_Click(object sender, RoutedEventArgs e)
        {

            BewonerList = db.Bewoners.Where(item=>item.Job == "Software Developer").ToList();

            bewonerListView.ItemsSource = BewonerList;
        }

        private void UnSortButton_Click(object sender, RoutedEventArgs e) 
        {
           LoadData();
        }
        //filter on text    
        private void OnFilterChanged(object sender, TextChangedEventArgs args) 
        { 
            string filteredText = FilterByName.Text.ToLower();
            BewonerList = db.Bewoners.Where(item => item.Name.ToLower().Contains(filteredText)).ToList();
            bewonerListView.ItemsSource = BewonerList;
        }
        //send to other page
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var softwareDeveloperWindow = new SoftwareDeveloperWindow("Guy van Wonderen");
            
            softwareDeveloperWindow.Closed += softwareDeveloperWindow_Closed;
            softwareDeveloperWindow.Activate();

            
        }
        //listview click filter on job from clicked item
        private void bewonerList_ItemClick(object sender, ItemClickEventArgs e)
        {
            var selectedItem = (Bewoner)e.ClickedItem;
            string clickfilter = selectedItem.Job.ToString();
            BewonerList = db.Bewoners.Where(item => item.Job == clickfilter).ToList();

            bewonerListView.ItemsSource = BewonerList;

        }

        private async void softwareDeveloperWindow_Closed(object sender, WindowEventArgs e)
        {
            var softwareDeveloperWindow = (SoftwareDeveloperWindow) sender;
            var age = softwareDeveloperWindow.DeveloperAge;

            //checks if the main page is closed to prevent a error
            if (isClosed == false) 
            {
                var dialog = new ContentDialog()
                {
                    Title = "Jouw leeftijd",
                    Content = "de door jou opgegeven leeftijd is " + age,
                    CloseButtonText = "OK",
                    XamlRoot = this.Content.XamlRoot,
                };
                await dialog.ShowAsync();
            }
            
        }

        private void Window_Closed(object sender, WindowEventArgs args)
        {
            isClosed = true;
        }
    }
}
