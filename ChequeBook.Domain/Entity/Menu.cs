using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ChequeBook.Domain
{
    [Table("app_Menu")]
    public class Menu
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
