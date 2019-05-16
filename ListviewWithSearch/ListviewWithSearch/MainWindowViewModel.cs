using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace ListviewWithSearch
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {

        public MainWindowViewModel()
        {
            Items = new ObservableCollection<string> { "Hello", "World" };
            Deselect = new RelayCommand(Deselecting, x => SelectedItem != null);
        }

        private void Deselecting(object obj)
        {
            SelectedItem = null;
        }

        private ICommand _deselect;
        public ICommand Deselect { get => _deselect; set { _deselect = value; OnPropertyChanged(); } }

        private string _selectedItem;
        public string SelectedItem { get => _selectedItem; set { _selectedItem = value; OnPropertyChanged(); } }

        private ObservableCollection<string> _items;
        public ObservableCollection<string> Items { get => _items; set { _items = value; OnPropertyChanged(); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName]string propertyName = null)
        {
            if (propertyName == null) throw new ArgumentException();
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}