using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RPGCharacterManager.Models
{
    public class Character : INotifyPropertyChanged
    {
        private string _name = string.Empty;
        private string _class = string.Empty;
        private string _spritePath = string.Empty;
        private int _level;
        private int _strength;
        private int _intelligence;

        public ObservableCollection<InventoryItem?> Equipment { get; set; } = new ObservableCollection<InventoryItem?>();

        public string Name
        {
            get => _name;
            set { _name = value; OnPropertyChanged(); }
        }

        public string Class
        {
            get => _class;
            set { _class = value; OnPropertyChanged(); }
        }

        public string SpritePath
        {
            get => _spritePath;
            set { _spritePath = value; OnPropertyChanged(); }
        }

        public int Level
        {
            get => _level;
            set { _level = value; OnPropertyChanged(); }
        }

        public int Strength
        {
            get => _strength;
            set { _strength = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalStrength)); }
        }

        public int Intelligence
        {
            get => _intelligence;
            set { _intelligence = value; OnPropertyChanged(); OnPropertyChanged(nameof(TotalIntelligence)); }
        }

        // --- Calculated Stats ---

        public int TotalStrength => Strength + Equipment.Where(i => i != null).Sum(i => i!.Strength);

        public int TotalIntelligence => Intelligence + Equipment.Where(i => i != null).Sum(i => i!.Intelligence);

        public Character()
        {
            for (int i = 0; i < 6; i++) Equipment.Add(null);

            // Listen for changes in the equipment list to update total stats
            Equipment.CollectionChanged += (s, e) => {
                OnPropertyChanged(nameof(TotalStrength));
                OnPropertyChanged(nameof(TotalIntelligence));
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        public Character Clone()
        {
            var clone = (Character)this.MemberwiseClone();
            clone.Equipment = new ObservableCollection<InventoryItem?>(this.Equipment);
            return clone;
        }
    }
}
