using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ChequeBook.Application.Dtos
{
    public class BankSaveInfoDto
    {
        public string? BankName { get; set; }         
        public byte[]? BankImage { get; set; }
        public string? FileName { get; set; }  // original file name
        public int Status { get; set; }
    }
}
