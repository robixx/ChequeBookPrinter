using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeBook.Application
{
    public class BankDto
    {
        public int BankId { get; set; }              // Maps to BankId in SQL
        public string? BankName { get; set; }         // Maps to BankName
        public string? BankImage { get; set; }        // Maps to BankImage (path or URL)
        public DateTime InsertDate { get; set; }     // Maps to InsertDate
        public int InsertBy { get; set; }            // Maps to InsertBy
        public int Status { get; set; }
    }
}
