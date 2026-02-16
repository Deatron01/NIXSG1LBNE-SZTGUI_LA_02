using System.Windows;
using RPGCharacterManager.ViewModels;

namespace RPGCharacterManager.Views
{
    public partial class ItemManagerWindow : Window
    {
        public ItemManagerWindow()
        {
            InitializeComponent();
            this.DataContext = new ItemManagerViewModel();
        }

        private void Select_Click(object sender, RoutedEventArgs e)
        {
            var viewModel = (ItemManagerViewModel)this.DataContext;
            if (viewModel.SelectedItem != null)
            {
                this.DialogResult = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select an item first!");
            }
        }
    }
}
