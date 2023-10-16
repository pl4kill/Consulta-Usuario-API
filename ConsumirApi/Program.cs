using ConsumirApi.Entities.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumirApi
{
    internal class Program
    {
        public static async Task Main(string[] args)
        {
            string opcao;

            do
            {
                Console.WriteLine("Informe o ID do usuario: ");
                int id = int.Parse(Console.ReadLine());

                UsuarioServices UsuariosServices = new UsuarioServices();
                Usuarios UsuarioEncontrado = await UsuariosServices.Integracao(id);

                if (id >= 1 && id <= 100)
                {
                    if (!UsuarioEncontrado.verificador)
                    {
                        Console.WriteLine($"\nConsulta feita sucesso!!\n\n" +
                        $"\nId Usuario: {UsuarioEncontrado.Id}\n" +
                        $"Nome: {UsuarioEncontrado.FirstName}\n" +
                        $"Sobrenome: {UsuarioEncontrado.LastName}\n" +
                        $"Idade: {UsuarioEncontrado.Age}\n" +
                        $"Email: {UsuarioEncontrado.Email}\n" +
                        $"Telefone: {UsuarioEncontrado.Phone}\n\n");
                    }
                    Console.WriteLine("Gostaria de fazer outra consulta? Sim / Nao");
                    opcao = Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("ID informado não existe na nossa base de dados.\n\n");
                    opcao = "Sim";
                }
            } while (opcao == "Sim" || opcao == "sim" || opcao == "s" || opcao == "S");

            Console.WriteLine("Espero te ver outra vez, até logo");

            Thread.Sleep(1500);
        }
    }
}
