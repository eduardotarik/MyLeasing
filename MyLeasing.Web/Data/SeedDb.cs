using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis;
using MyLeasing.Web.Data.Entities;
using MyLeasing.Web.Helpers;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyLeasing.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _context;
        private readonly IUserHelper _userHelper;
        private Random _random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            _context = context;
            _userHelper = userHelper;
            _random = new Random();
        }

        public async Task SeedAsync()
        {
            await _context.Database.EnsureCreatedAsync();

            var user = await _userHelper.GetUserByEmailAsync("eduardo@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Eduardo",
                    LastName = "Fernandes",
                    Email = "eduardo@gmail.com",
                    UserName = "eduardo@gmail.com",
                    PhoneNumber = "913636654",
                };

                var result = await _userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!_context.Owners.Any())
            {
                AddOwners("Ricardo Barros", user);
                AddOwners("Daiane Farias", user);
                AddOwners("Diogo Castro", user);
                AddOwners("Luís Silveira", user);
                AddOwners("António Pimenta", user);
                AddOwners("Filipe Fernandes", user);
                AddOwners("Tânia Perreira", user);
                AddOwners("Domingos Silva", user);
                AddOwners("Tiago Fonseca", user);
                AddOwners("Pedro Alberto", user);
                await _context.SaveChangesAsync();
            }

            if (!_context.Lessees.Any())
            {
                AddLessee("John Doe", user);
                AddLessee("Eduardo Batista", user);
                AddLessee("Pablo Alexandre", user);
                AddLessee("Fátima Laurin", user);
                AddLessee("Maria Andrade", user);
                await _context.SaveChangesAsync();
            }
        }

        private void AddOwners(string name, User user)
        {
            Random _random = new Random();

            string randomAddress = GenerateRandomAddress();

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
                Address = randomAddress,
                User = user
            });
        }

        private void AddLessee(string name, User user)
        {
            Random _random = new Random();

            string randomAddress = GenerateRandomAddress();

            string[] names = name.Split(' ');
            string firstName = names[0];
            string lastName = names.Length > 1 ? names[1] : "";

            string document = GenerateRandomDigits(6);
            string fixedPhone = GenerateRandomDigits(7, "21");
            string cellPhone = GenerateRandomDigits(7, "91");

            _context.Lessees.Add(new Lessee
            {
                Document = document,
                FirstName = firstName,
                LastName = lastName,
                FixedPhone = fixedPhone,
                CellPhone = cellPhone,
                Address = randomAddress,
                User = user
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

        private string GenerateRandomAddress()
        {
            string[] streetNames = { "Av. da Liberdade", "Estrada da Luz", "Travessa das Flores", "Rua da Verdade", "Rua do Ouro" };
            string[] numbers = { "21", "109", "1", "34", "304" };

            string randomStreet = streetNames[_random.Next(streetNames.Length)];
            string randomNumber = numbers[_random.Next(numbers.Length)];

            return $"{randomStreet}, {randomNumber}";
        }
    }
}
