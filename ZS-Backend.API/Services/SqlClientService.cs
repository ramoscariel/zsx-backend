using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZS_Backend.API.Models.Domain;
using ZS_Backend.API.Repositories;

namespace ZS_Backend.API.Services
{
    public class SqlClientService : IClientService
    {
        private readonly IClientRepository clientRepository;

        public SqlClientService(IClientRepository clientRepository)
        {
            this.clientRepository = clientRepository;
        }

        public async Task<List<Client>> GetAllAsync()
        {
            return await clientRepository.GetAllAsync();
        }

        public async Task<Client?> GetByIdAsync(Guid id)
        {
            return await clientRepository.GetByIdAsync(id);
        }

        public async Task<Client> AddAsync(Client client)
        {
            switch (client.DocumentType)
            {
                case DocumentType.Cedula:
                    if (!IsValidCedula(client.DocumentNumber))
                        throw new ArgumentException("Cédula inválida.", nameof(client.DocumentNumber));
                    break;
                case DocumentType.Ruc:
                    if (!IsValidRuc(client.DocumentNumber))
                        throw new ArgumentException("RUC inválido.", nameof(client.DocumentNumber));
                    break;
            }

            return await clientRepository.AddAsync(client);
        }

        public async Task<Client?> UpdateAsync(Guid id, Client client)
        {
            switch (client.DocumentType)
            {
                case DocumentType.Cedula:
                    if (!IsValidCedula(client.DocumentNumber))
                        throw new ArgumentException("Cédula inválida.", nameof(client.DocumentNumber));
                    break;
                case DocumentType.Ruc:
                    if (!IsValidRuc(client.DocumentNumber))
                        throw new ArgumentException("RUC inválido.", nameof(client.DocumentNumber));
                    break;
            }

            return await clientRepository.UpdateAsync(id, client);
        }

        public async Task<Client?> DeleteAsync(Guid id)
        {
            return await clientRepository.DeleteAsync(id);
        }

        private static bool IsValidCedula(string cedula)
        {
            if (string.IsNullOrWhiteSpace(cedula)) return false;
            var digits = new string(cedula.Where(char.IsDigit).ToArray());
            if (digits.Length != 10) return false;

            // Province code: first two digits between 1 and 24
            if (!int.TryParse(digits.Substring(0, 2), out var province) || province < 1 || province > 24)
                return false;

            // Third digit must be less than 6 for natural persons
            if ((digits[2] - '0') >= 6) return false;

            int[] coefficients = { 2, 1, 2, 1, 2, 1, 2, 1, 2 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                int value = (digits[i] - '0') * coefficients[i];
                if (value >= 10) value -= 9;
                sum += value;
            }

            int computedVerifier = (10 - (sum % 10)) % 10;
            int actualVerifier = digits[9] - '0';

            return computedVerifier == actualVerifier;
        }

        private static bool IsValidRuc(string ruc)
        {
            if (string.IsNullOrWhiteSpace(ruc)) return false;
            var digits = new string(ruc.Where(char.IsDigit).ToArray());
            if (digits.Length != 13) return false;

            // Last three digits (establishment) must not be all zeros
            if (digits.Substring(10, 3) == "000") return false;

            int thirdDigit = digits[2] - '0';

            // Natural person: third digit 0-5 -> first 10 digits is a valid cédula
            if (thirdDigit >= 0 && thirdDigit <= 5)
            {
                return IsValidCedula(digits.Substring(0, 10));
            }

            // Public institutions: third digit == 6, use 9-digit algorithm with coefficients for 8 digits
            if (thirdDigit == 6)
            {
                int[] coefficients = { 3, 2, 7, 6, 5, 4, 3, 2 };
                int sum = 0;
                for (int i = 0; i < 8; i++)
                {
                    sum += (digits[i] - '0') * coefficients[i];
                }

                int verifier = 11 - (sum % 11);
                if (verifier == 11) verifier = 0;
                if (verifier == 10) return false;

                if (verifier != (digits[8] - '0')) return false;

                // For public entities last 4 digits (positions 9-12) must not be all zeros
                if (digits.Substring(9, 4) == "0000") return false;

                return true;
            }

            // Private companies: third digit == 9, use coefficients for first 9 digits
            if (thirdDigit == 9)
            {
                int[] coefficients = { 4, 3, 2, 7, 6, 5, 4, 3, 2 };
                int sum = 0;
                for (int i = 0; i < 9; i++)
                {
                    sum += (digits[i] - '0') * coefficients[i];
                }

                int verifier = 11 - (sum % 11);
                if (verifier == 11) verifier = 0;
                if (verifier == 10) return false;

                if (verifier != (digits[9] - '0')) return false;

                // For private companies last 3 digits (positions 10-12) must not be all zeros
                if (digits.Substring(10, 3) == "000") return false;

                return true;
            }

            return false;
        }
    }
}
