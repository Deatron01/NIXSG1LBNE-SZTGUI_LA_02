using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace RPGCharacterManager.Models
{
    public class InventoryItem : INotifyPropertyChanged
    {
        private string _name = "New Item";
        private string _iconPath = "pack://application:,,,/Assets/Items/sword.png";
        private int _strength = 1;
        private int _intelligence = 1;

        // Parameterless constructor - szükséges WPF binding-hoz
        public InventoryItem() { }

        // Paraméteres constructor - opcionális
        public InventoryItem(string name, string iconPath, int strength, int intelligence)
        {
            _name = name;
            _iconPath = iconPath;
            _strength = strength;
            _intelligence = intelligence;
        }

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string IconPath
        {
            get => _iconPath;
            set { _iconPath = value; OnPropertyChanged(); }
        }

        public int Strength
        {
            get => _strength;
            set { _strength = value; OnPropertyChanged(); }
        }
        public int Intelligence
        {
            get => _intelligence;
            set { _intelligence = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
