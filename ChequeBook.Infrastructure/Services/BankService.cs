using ChequeBook.Application;
using ChequeBook.Application.Dtos;
using ChequeBook.Application.Interface;
using ChequeBook.Domain.Entity;
using ChequeBook.Infrastructure.DataConnection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ChequeBook.Infrastructure.Services
{
    public class BankService : IBankInfo
    {
        private readonly CQDataConnection _connection;
        private readonly string _imagePath;

        public BankService(CQDataConnection connection, IConfiguration configuration)
        {
            _connection = connection;
            _imagePath = configuration["ImageStorage:ImagePath"] ?? string.Empty;
        }
        public async Task<List<BankDto>> GetBankList()
        {
            try
            {

                return await _connection.Bank
                 .Select(b => new BankDto
                 {
                     BankId = b.BankId,
                     BankName = b.BankName ?? string.Empty,       // handle null
                     BankImage = b.BankImage ?? string.Empty,     // handle null
                     InsertDate = b.InsertDate,                   // DateTime can't be null
                     InsertBy = b.InsertBy,
                     Status = b.Status
                 })
                 .ToListAsync() ?? new List<BankDto>();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<(string Message, bool Status)> SaveBankInfo(BankSaveInfoDto model)
        {
            try
            {
                if (model.BankImage != null && model.FileName != null)
                {
                    var path = Path.Combine(_imagePath, model.FileName);
                    await File.WriteAllBytesAsync(path, model.BankImage);
                }
                var bankEntity = new Bank
                {
                    BankName = model.BankName,
                    BankImage = model.FileName,
                    Status = model.Status,
                    InsertDate = DateTime.Now
                };
                await _connection.Bank.AddAsync(bankEntity);
                await _connection.SaveChangesAsync();
                return ("Bank Name Save Successfully", true);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
