using Agenda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Agenda.Models
{
    public static class EnviarDados
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {

            using (var context = new ApplicationDbContext(
                        serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {

                if (context.Contato.Any())
                {
                    return;
                }

                context.Contato.AddRange(
                    new Contato
                    {
                        Nome = "Renan Coelho",
                        DataNascimento = DateTime.Parse("1990-01-02"),
                        Email = "rt2012cc@outlook.com",
                        Telefone = "9237-5611",
                        Cpf = "000.000.000-0"
                    },
                    new Contato
                    {
                        Nome = "Teixeira",
                        DataNascimento = DateTime.Parse("1995-05-13"),
                        Email = "rt2012cc@yahoo.com.br",
                        Telefone = "9204-0122",
                        Cpf = "111.111.111-1"
                    }
                    );

                context.SaveChanges();
            }
        }
    }
}
