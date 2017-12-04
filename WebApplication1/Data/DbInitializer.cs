using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Data
{
    public class DbInitializer
    {
        public static void Initialize(kindergartenContext context)
        {
            context.Database.EnsureCreated();

            // Проверка занесены ли данные 
            if (context.TypesOfGroups.Any())
            {
                return; // База данных инициализирована 
            }

            context.AddRange(
                new TypesOfGroups()
                {
                    Name = "Name1",
                    Description = "Description1"

                },
                new TypesOfGroups()
                {
                    Name = "Name2",
                    Description = "Description2"
                },
                new TypesOfGroups()
                {
                    Name = "Name3",
                    Description = "Description3"
                }
            );
            context.SaveChanges();
        }
    }
}
