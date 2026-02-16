using System.Windows;
using System.Windows.Input;
using RPGCharacterManager.Models;
using RPGCharacterManager.ViewModels;

namespace RPGCharacterManager.Views
{
    public partial class StatEditorWindow : Window
    {
        public Character EditedCharacter { get; private set; }

        public StatEditorWindow(Character character)
        {
            InitializeComponent();
            EditedCharacter = character;
            this.DataContext = new StatEditorViewModel(EditedCharacter);
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }

        private void Slot_Click(object sender, MouseButtonEventArgs e)
        {
            var border = sender as FrameworkElement;
            var itemInSlot = border?.DataContext as InventoryItem;

            var itemPicker = new ItemManagerWindow();
            if (itemPicker.ShowDialog() == true)
            {
                var selectedItem = ((ItemManagerViewModel)itemPicker.DataContext).SelectedItem;
                if (selectedItem != null)
                {
                    var vm = (StatEditorViewModel)this.DataContext;
                    int index = vm.Character.Equipment.IndexOf(itemInSlot);
                    if (index != -1) vm.Character.Equipment[index] = selectedItem;
                }
            }
        }

    }
}
