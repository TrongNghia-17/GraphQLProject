using GraphQLProject.Interfaces;
using GraphQLProject.Models;

namespace GraphQLProject.Services;

public class MenuRepository : IMenuRepository
{
    private static List<Menu> MenuList = new List<Menu>()
    {
        new Menu(){Id = 1, Name = "One", Description="1", Price=100},
        new Menu(){Id = 2, Name = "Two", Description="2", Price=200},
        new Menu(){Id = 3, Name = "Three", Description="3", Price=300},
        new Menu(){Id = 4, Name = "Four", Description="4", Price=400},
        new Menu(){Id = 5, Name = "Five", Description="5", Price=500},
    };

    public Menu AddMenu(Menu menu)
    {
        MenuList.Add(menu);
        return menu;
    }

    public void DeleteMenu(int id)
    {
        MenuList.RemoveAt(id);
    }

    public List<Menu> GetAllMenu()
    {
        return MenuList;
    }

    public Menu GetMenuById(int id)
    {
        return MenuList.Find(m => m.Id == id);
    }

    public Menu UpdateMenu(int id, Menu menu)
    {
        MenuList[id] = menu;
        return menu;
    }
}
