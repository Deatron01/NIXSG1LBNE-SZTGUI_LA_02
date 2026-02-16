using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using RPGCharacterManager.Commands;
using RPGCharacterManager.Models;
using RPGCharacterManager.Services;
using RPGCharacterManager.Views;

namespace RPGCharacterManager.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private readonly CharacterService _service;
        private Character? _selectedCharacter;

        public ObservableCollection<Character> Characters { get; set; }

        public Character? SelectedCharacter
        {
            get => _selectedCharacter;
            set { _selectedCharacter = value; OnPropertyChanged(); }
        }

        public ICommand AddCommand { get; }
        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public MainWindowViewModel()
        {
            _service = new CharacterService();
            Characters = _service.GetCharacters();

            AddCommand = new RelayCommand(o => AddCharacter());
            EditCommand = new RelayCommand(o => EditCharacter(), o => SelectedCharacter != null);
            DeleteCommand = new RelayCommand(o => { if (SelectedCharacter != null) _service.DeleteCharacter(SelectedCharacter); }, o => SelectedCharacter != null);
        }

        private void AddCharacter()
        {
            var newCharacter = new Character
            {
                Name = "New Hero",
                Class = "Warrior",
                Level = 1,
                Strength = 10,
                Intelligence = 10,
                Equipment = new ObservableCollection<InventoryItem>
        {
            new InventoryItem(), new InventoryItem(),
            new InventoryItem(), new InventoryItem(),
            new InventoryItem(), new InventoryItem()
        }
            };

            var editor = new StatEditorWindow(newCharacter);
            if (editor.ShowDialog() == true)
            {
                _service.AddCharacter(editor.EditedCharacter);
            }
        }


        private void EditCharacter()
        {
            if (SelectedCharacter == null) return;

            var editor = new StatEditorWindow(SelectedCharacter.Clone());
            if (editor.ShowDialog() == true)
            {
                _service.UpdateCharacter(SelectedCharacter, editor.EditedCharacter);
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

    }
}
