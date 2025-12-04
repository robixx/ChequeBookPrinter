using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeBook.Application
{
    public class SubMenuDto
    {
        public int MenuId { get; set; }
        public string? MenuName { get; set; }
        public string? Urls { get; set; }
        public string? AreaName { get; set; }
        public string? ControllerName { get; set; }
        public string? ActionName { get; set; }
        public int? ParentId { get; set; }
        public int? OrderView { get; set; }
        public int? Status { get; set; }
    }
}
