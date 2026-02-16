using System.Windows.Input;
using RPGCharacterManager.Commands;
using RPGCharacterManager.Models;

namespace RPGCharacterManager.ViewModels
{
    public class StatEditorViewModel
    {
        public Character Character { get; set; }
        public ICommand RemoveItemCommand { get; }

        public StatEditorViewModel(Character character)
        {
            Character = character;

            // Command to remove an item from a slot (sets it to null)
            RemoveItemCommand = new RelayCommand(item => {
                if (item is InventoryItem inventoryItem)
                {
                    int index = Character.Equipment.IndexOf(inventoryItem);
                    if (index != -1)
                    {
                        Character.Equipment[index] = null;
                    }
                }
            });
        }
    }
}
