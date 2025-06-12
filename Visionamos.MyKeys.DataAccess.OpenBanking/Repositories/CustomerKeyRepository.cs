using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Visionamos.MyKeys.DataAccess.OpenBanking.Context;
using Visionamos.MyKeys.DataAccess.OpenBanking.Contract.Entities;

namespace Visionamos.MyKeys.DataAccess.OpenBanking.Repositories
{
    public class CustomerKeyRepository : ICustomerKeyRepository
    {
        private readonly ManageKeysDbContext _context;

        public CustomerKeyRepository(ManageKeysDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<KeyCustomer>> GetAllAsync()
        {
            return await _context.KeyCustomers.ToListAsync();
        }

        public async Task<KeyCustomer> GetByIdAsync(Guid id)
        {
            try
            {
                if (id == Guid.Empty)
                    throw new ArgumentException("El ID no puede estar vacío.", nameof(id));

                return await _context.KeyCustomers.FindAsync(id);
            }
            catch
            {
                throw;
            }
        }

        public async Task<KeyCustomer> GetByValueKeyCustomerAsync(string valueKeyCustomer)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(valueKeyCustomer))
                    throw new ArgumentException("El valor de la llave no puede estar vacío.");

                return await _context.KeyCustomers
                    .FirstOrDefaultAsync(k => k.ValueKeyCustomer == valueKeyCustomer);
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<KeyCustomer>> GetBySourceIdentificationAsync(string sourceIdentification)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(sourceIdentification))
                    throw new ArgumentException("La identificación no puede estar vacía.");

                return await _context.KeyCustomers
                    .Where(k => k.SourceIdentification == sourceIdentification)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }

        }

        public async Task<IEnumerable<KeyCustomer>> GetActiveKeysBySourceIdentificationAsync(string sourceIdentification)
        {
            try
            {
                return await _context.KeyCustomers
                .Where(k => k.SourceIdentification == sourceIdentification && k.KeyStateCode == "ACTV")
                .ToListAsync();
            }
            catch
            {
                throw;
            }

        }
        public async Task<KeyCustomer> GetKeyByValueAsync(string valueKeyCustomer) {
            try
            {
                return await _context.KeyCustomers
                .FirstOrDefaultAsync(k => k.ValueKeyCustomer == valueKeyCustomer);
            }
            catch
            {
                throw;
            }

        }

        public async Task<List<KeyCustomer>> GetKeysByCriteriaAsync(string sourceIdentification, string valueKeyCustomer)
        {
            try
            {
                var query = _context.KeyCustomers.Where(k => k.KeyStateCode == "ACTV");
                if (!string.IsNullOrEmpty(sourceIdentification))
                    query = query.Where(k => k.SourceIdentification == sourceIdentification);
                if (!string.IsNullOrEmpty(valueKeyCustomer))
                    query = query.Where(k => k.ValueKeyCustomer == valueKeyCustomer);
                return await query.ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task AddKeyAsync(KeyCustomer keyCustomer)
        {
            try
            {
                await _context.KeyCustomers.AddAsync(keyCustomer);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task UpdateKeyAsync(KeyCustomer keyCustomer)
        {
            try
            {
                _context.KeyCustomers.Update(keyCustomer);
                await _context.SaveChangesAsync();
            }
            catch
            {
                throw;
            }
        }   
        //public async Task<IEnumerable<KeyCustomer>> SearchKeysAsync(string? sourceIdentification = null, string? valueKeyCustomer = null)
        //{
        //    var query = _context.KeyCustomers.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(sourceIdentification))
        //        query = query.Where(k => k.SourceIdentification == sourceIdentification);

        //    if (!string.IsNullOrWhiteSpace(valueKeyCustomer))
        //        query = query.Where(k => k.ValueKeyCustomer == valueKeyCustomer);

        //    return await query.ToListAsync();
        //}

        public async Task<KeyCustomer> CreateAsync(KeyCustomer keyCustomer)
        {
            try
            {
                if (keyCustomer == null)
                    throw new ArgumentNullException(nameof(keyCustomer));

                if (string.IsNullOrWhiteSpace(keyCustomer.ValueKeyCustomer))
                    throw new ArgumentException("El valor de la llave es obligatorio.");

                bool exists = await ValueKeyExistsAsync(keyCustomer.ValueKeyCustomer);
                if (exists)
                    throw new InvalidOperationException("La llave ya existe.");

                await _context.KeyCustomers.AddAsync(keyCustomer);
                await _context.SaveChangesAsync();
                return keyCustomer;
            }
            catch
            {
                throw;
            }
        }

        public async Task<KeyCustomer> UpdateAsync(KeyCustomer keyCustomer)
        {
            try
            {
                var existing = await _context.KeyCustomers.FindAsync(keyCustomer.Id);
                if (existing == null)
                    throw new KeyNotFoundException("No se encontró la llave para actualizar.");

                _context.Entry(existing).CurrentValues.SetValues(keyCustomer);
                await _context.SaveChangesAsync();
                return existing;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeactivateKeyAsync(string valueKeyCustomer)
        {
            try
            {
                var key = await GetByValueKeyCustomerAsync(valueKeyCustomer);
                if (key == null || key.KeyStateCode != "ACTV")
                    return false;

                key.KeyStateCode = "INTV";
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ValueKeyExistsAsync(string valueKeyCustomer)
        {
            try
            {
               return await _context.KeyCustomers.AnyAsync(k => k.ValueKeyCustomer == valueKeyCustomer);

            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> SequenceExistsAsync(string sequence)
        {
            try
            {
                return await _context.KeyCustomers.AnyAsync(k => k.Sequence == sequence);
            }
            catch
            {
                throw;
            }

        }

        public async Task<int> GetActiveKeysCountByCustomerAsync(string sourceIdentification)
        {
            try
            {
                return await _context.KeyCustomers
               .CountAsync(k => k.SourceIdentification == sourceIdentification && k.KeyStateCode == "ACTV");
            }
            catch
            {
                throw;
            }
        }

        public async Task<List<KeyCustomer>> GetByIdentificationAsync(string identification)
        {
            try
            {
                return await _context.KeyCustomers
                .Where(k => k.SourceIdentification == identification)
                .ToListAsync();
            }
            catch
            {
                throw;
            }

        }

        //public async Task<List<KeyCustomer>> SearchAsync(string? identification, string? valueKeyCustomer)
        //{
        //    var query = _context.KeyCustomers.AsQueryable();

        //    if (!string.IsNullOrWhiteSpace(identification))
        //        query = query.Where(k => k.SourceIdentification == identification);

        //    if (!string.IsNullOrWhiteSpace(valueKeyCustomer))
        //        query = query.Where(k => k.ValueKeyCustomer == valueKeyCustomer);

        //    return await query.ToListAsync();
        //}
    }
}