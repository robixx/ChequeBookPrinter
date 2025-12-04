

using ChequeBook.Application;
using ChequeBook.Infrastructure.DataConnection;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;

namespace ChequeBook.Infrastructure.Services
{
    public class MenuServices : IMenu
    {

        private readonly CQDataConnection _connection;

        public  MenuServices(CQDataConnection connection)
        {
            _connection = connection;
        }

        public async Task<(string Mesaage, List<MenuDto> menu_list)> GetMenuList()
        {
            try
            {

                var menu = await _connection.Menu.ToListAsync();
                List<MenuDto> Menulist = new List<MenuDto>();              

               
                if (menu != null)
                {
                    var menlist = menu.Where(i => i.ParentId == 0).OrderBy(i => i.OrderView).ToList();
                    foreach (var item in menlist)
                    {
                        var sub = menu.Where(i => i.ParentId == item.MenuId).OrderBy(i => i.OrderView).ToList();
                        List<SubMenuDto> submenu = new List<SubMenuDto>();
                        foreach (var item2 in sub)
                        {
                            submenu.Add(new SubMenuDto
                            {
                                MenuId = item2.MenuId,
                                MenuName = item2.MenuName,
                                Urls = item2.Urls,
                                AreaName = item2.AreaName,
                                ControllerName = item2.ControllerName,
                                ActionName = item2.ActionName,                               
                                ParentId = item2.ParentId,
                                Status = item2.Status,
                                OrderView = item2.OrderView,
                            });
                        }


                        Menulist.Add(new MenuDto
                        {
                            MenuId = item.MenuId,
                            MenuName = item.MenuName,
                            ParentId = item.ParentId??0,
                            ViewOrder = item.OrderView??0,
                            subMenu = submenu

                        });
                    }

                }               
                return ("Success", Menulist);


            }
            catch(Exception ex)
            {
                return ($"Error: {ex.Message}", new List<MenuDto>());
            }
        }
    }
}
