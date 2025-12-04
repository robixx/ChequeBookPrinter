using ChequeBook.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeBook.Application
{
    public interface IMenu
    {
        Task<(string Mesaage, List<MenuDto> menu_list)> GetMenuList();
    }
}
