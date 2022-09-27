using System;
using Microsoft.AspNetCore.Identity;
using NetKubernetes.Models;

namespace NetKubernetes.Data;

public class LoadDataBase
{
    public static async Task InsertarData(AppDbContext context, UserManager<Usuario> usuarioManager)
    {
        if (!usuarioManager.Users.Any())
        {
            var usuario = new Usuario
            {
                Nombre = "Vaxi",
                Apellido = "Drez",
                Email = "vaxi.drez.social@gmail.com",
                UserName = "vaxy.drez",
                Telefono = "981212121"
            };

            await usuarioManager.CreateAsync(usuario, "PasswordVxidrez123$");
        }
        
        if (!context.Inmuebles!.Any())
        {
            context.Inmuebles!.AddRange(
                new Inmueble{
                    Nombre = "Casa de Playa",
                    Direccion = "Av del sol 32",
                    Precio = 4500M,
                    FechaCreacion = DateTime.Now 
                },
                new Inmueble{
                    Nombre = "Casa de campo",
                    Direccion = "Av Libertador 22",
                    Precio = 100M,
                    FechaCreacion = DateTime.Now 
                }
            );
        }

        context.SaveChanges();
    }

}