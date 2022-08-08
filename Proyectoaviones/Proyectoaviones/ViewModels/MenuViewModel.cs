using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Proyectoaviones.ViewModels
{
    public class MenuViewModel : BaseViewModel
    {
        readonly IList<Menu> source;
        Menu selectedMonkey;
        public ObservableCollection<Menu> Menu { get; private set; }
        public IList<Menu> EmptyMonkeys { get; private set; }
        public Menu SelectedMonkey
        {
            get
            {
                return selectedMonkey;
            }
            set
            {
                if (selectedMonkey != value)
                {
                    selectedMonkey = value;
                }
            }
        }
        ObservableCollection<object> selectedMonkeys;
        public ObservableCollection<object> SelectedMonkeys
        {
            get
            {
                return selectedMonkeys;
            }
            set
            {
                if (selectedMonkeys != value)
                {
                    selectedMonkeys = value;
                }
            }
        }
        public string SelectedMonkeyMessage { get; private set; }
        public ICommand DeleteCommand => new Command<Menu>(RemoveMonkey);
        public ICommand FilterCommand => new Command<string>(FilterItems);
   
        public MenuViewModel()
        {
            source = new List<Menu>();
            CreateMonkeyCollection();
        }
        void CreateMonkeyCollection()
        {
            source.Add(new Menu
            {
                Name = "Ver Vuelos"
               
            });
            source.Add(new Menu
            {
                Name = "Comprar Boletos"

            });
            source.Add(new Menu
            {
                Name = "Ver Ticket"

            });


            Menu = new ObservableCollection<Menu>(source);
        }
        void FilterItems(string filter)
        {
            var filteredItems = source.Where(monkey => monkey.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach (var monkey in source)
            {
                if (!filteredItems.Contains(monkey))
                {
                    Menu.Remove(monkey);
                }
                else
                {
                    if (!Menu.Contains(monkey))
                    {
                        Menu.Add(monkey);
                    }
                }
            }
        }
        void RemoveMonkey(Menu menu)
        {
            if (Menu.Contains(menu))
            {
                Menu.Remove(menu);
            }
        }
       
    }
    public class Menu
    {
        public string Name { get; set; }
      
    }
}
