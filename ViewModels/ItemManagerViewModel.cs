using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RPGCharacterManager.Commands;
using RPGCharacterManager.Models;
using RPGCharacterManager.Services;

namespace RPGCharacterManager.ViewModels
{
    public class ItemManagerViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<InventoryItem> AllItems => ItemDatabaseService.Instance.AllItems;
        private InventoryItem? _selectedItem;

        public InventoryItem? SelectedItem
        {
            get => _selectedItem;
            set { _selectedItem = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand DeleteCommand { get; }

        public ItemManagerViewModel()
        {
            AddCommand = new RelayCommand(o => ItemDatabaseService.Instance.AddItem(new InventoryItem { Name = "New Item", Strength = 1, IconPath = "/Assets/Items/sword.png" }));
            DeleteCommand = new RelayCommand(o => { if (SelectedItem != null) ItemDatabaseService.Instance.RemoveItem(SelectedItem); }, o => SelectedItem != null);
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
