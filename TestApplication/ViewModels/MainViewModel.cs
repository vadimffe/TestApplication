using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using TestApplication.Commands;
using TestApplication.Models;

namespace TestApplication.ViewModels
{
  public class MainViewModel : BaseViewModel
  {
    public MainViewModel()
    {
      this.items = new ObservableCollection<Item>
      {
        new Item { Id = 1, Name = "Item 1"},
        new Item { Id = 2, Name = "Item 2"},
        new Item { Id = 3, Name = "Item 3"},
        new Item { Id = 4, Name = "Item 4"},
        new Item { Id = 5, Name = "Item 5"},
      };

      this.selectedIndex = 0;
      this.totalItems = this.items.Count();
    }

    public ICommand MoveUpCommand => new RelayCommand(this.MoveDown, this.CanMoveDown);
    public ICommand MoveDownCommand => new RelayCommand(this.MoveUp, this.CanMoveUp);

    private bool CanMoveUp() => this.SelectedIndex != this.Items.Count - 1;
    private bool CanMoveDown() => this.SelectedIndex != 0;

    private void MoveUp()
    {
      this.SelectedIndex += 1;
    }

    private void MoveDown()
    {
      this.SelectedIndex -= 1;
    }

    private int totalItems;
    public int TotalItems
    {
      get => this.totalItems;
      set
      {
        this.totalItems = value;
        this.OnPropertyChanged();
      }
    }

    private Item selectedItem;
    public Item SelectedItem
    {
      get => this.selectedItem;
      set
      {
        this.selectedItem = value;
        this.OnPropertyChanged();
      }
    }

    private int selectedIndex;
    public int SelectedIndex
    {
      get => this.selectedIndex;
      set
      {
        this.selectedIndex = value;
        this.OnPropertyChanged();
      }
    }

    private ObservableCollection<Item> items;
    public ObservableCollection<Item> Items
    {
      get => this.items;
      set
      {
        this.items = value;
        this.OnPropertyChanged();
      }
    }
  }
}
