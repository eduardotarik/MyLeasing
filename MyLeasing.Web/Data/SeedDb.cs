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

            _context.Owners.Add(new Owner
            {
                Document = _random.Next(1000000).ToString(),
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = _random.Next(1000000000).ToString(),
                CellPhone = _random.Next(1000000000).ToString(),
                Address = randomAddress
            });
        }
    }
}
