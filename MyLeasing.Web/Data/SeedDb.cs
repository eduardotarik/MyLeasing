using MyLeasing.Web.Data.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private Random _random;

        public SeedDb(DataContext context)
        {
            _context = context;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            if (!_context.Owners.Any())
            {
                AddOwners("Ricardo Barros");
                AddOwners("Daiane Farias");
                AddOwners("Diogo Castro");
                AddOwners("Luís Silveira");
                AddOwners("António Pimenta");
                AddOwners("Filipe Fernandes");
                AddOwners("Tânia Perreira");
                AddOwners("Domingos Silva");
                AddOwners("Tiago Fonseca");
                AddOwners("Pedro Alberto");
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwners(string name)
        {
            Random _random = new Random();

            string[] streetNames = { "Av. da Liberdade", "Estrada da Luz", "Travessa das Flores", "Rua da Verdade", "Rua do Ouro" };
            string[] numbers = { "21", "109", "1", "34", "304" };

            string randomStreet = streetNames[_random.Next(streetNames.Length)];
            string randomNumber = numbers[_random.Next(numbers.Length)];

            string randomAddress = $"{randomStreet}, {randomNumber}";

            // Split the name into first name and last name
            string[] names = name.Split(' ');
            string firstName = names[0];
            string lastName = names.Length > 1 ? names[1] : "";

            string document = GenerateRandomDigits(6);
            string fixedPhone = GenerateRandomDigits(7, "21");
            string cellPhone = GenerateRandomDigits(7, "91");

            _context.Owners.Add(new Owner
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = fixedPhone,
                CellPhone = cellPhone,
                Address = randomAddress
            });
        }

        private string GenerateRandomDigits(int length, string prefix = "")
        {
            string digits = prefix;
            for (int i = 0; i < length; i++)
            {
                digits += _random.Next(10).ToString();
            }
            return digits;
        }
    }
}
