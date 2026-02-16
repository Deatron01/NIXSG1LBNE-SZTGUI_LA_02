using System.Collections.ObjectModel;
using RPGCharacterManager.Models;

namespace RPGCharacterManager.Services
{
    public class ItemDatabaseService
    {
        private static ItemDatabaseService? _instance;
        public static ItemDatabaseService Instance => _instance ??= new ItemDatabaseService();

        public ObservableCollection<InventoryItem> AllItems { get; set; }

        private ItemDatabaseService()
        {
            // Csak az item adatbázis inicializálása
            AllItems = new ObservableCollection<InventoryItem>
            {
                new InventoryItem("Iron Sword", "pack://application:,,,/Assets/Items/sword.png", 5,0),
                new InventoryItem("Wooden Shield", "pack://application:,,,/Assets/Items/shield.png", 0,3)
            };
        }

        public void AddItem(InventoryItem item)
        {
            AllItems.Add(item);
        }

        public void RemoveItem(InventoryItem item)
        {
            AllItems.Remove(item);
        }
    }
}
