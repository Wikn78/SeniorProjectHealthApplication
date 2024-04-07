using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using Xamarin.Forms;

namespace SeniorProjectHealthApplication.ViewModels
{
    public class AddFoodPageViewModel : INotifyPropertyChanged
    {

        public ICommand SearchCommand { get; private set; }
        public AddFoodPageViewModel(string categoryId)
        {
            SearchCommand = new Command(ExecuteSearchCommand);
        }
        
        
        private void ExecuteSearchCommand()
        {
            Console.WriteLine(SearchText);
        }
        
        private string _searchText;
        public string SearchText
        {
            get { return _searchText; }
            set
            {
                if (_searchText != value)
                {
                    _searchText = value;
                    OnPropertyChanged(nameof(SearchText)); // Raise a property changed event
                }
            }
        }




        #region PropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        
    }
}