using ChequeBook.Application;
using ChequeBook.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChequeBook.Application.Interface
{
    public interface IBankInfo
    {
        Task<List<BankDto>> GetBankList();
        Task<(string Message, bool Status)>SaveBankInfo(BankSaveInfoDto model);
    }
}
