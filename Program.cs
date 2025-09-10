using DesafioProjetoHospedagem.Models;
using System;
using System.Collections.Generic;

Reserva reserva = null;
Suite suite = null;

while (true)
{
    Console.Clear();
    Console.WriteLine("=== Hotel Sampaio ===");
    Console.WriteLine("1 - Cadastrar Suíte");
    Console.WriteLine("2 - Cadastrar Hóspedes");
    Console.WriteLine("3 - Realizar Reserva");
    Console.WriteLine("4 - Exibir Reserva");
    Console.WriteLine("0 - Sair");
    Console.WriteLine("Escolha uma opção: ");

    string opcao = Console.ReadLine();

    switch (opcao)
    {
        case "1":
            Console.Write("Tipo da Suíte: ");
            string tipo = Console.ReadLine();

            Console.Write("Capacidade da Suíte: ");
            int capacidade = int.Parse(Console.ReadLine());

            Console.Write("Valor da Diária: ");
            decimal valorDiaria = decimal.Parse(Console.ReadLine());

            suite = new Suite(tipo, capacidade, valorDiaria);
            Console.WriteLine("\nSuíte cadastrada com sucesso!");
            break;

        case "2":
            if (suite == null)
            {
                Console.WriteLine("\nPor favor, cadastre uma suíte antes de adicionar hóspedes.");
                break;
            }

            List<Pessoa> hospedes = new List<Pessoa>();

            Console.Write("Quantos hóspedes deseja cadastrar? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidade; i++)
            {
                Console.Write($"Nome do hóspede {i + 1}: ");
                string nome = Console.ReadLine();

                Console.Write($"Sobrenome do hóspede {i + 1}: ");
                string sobrenome = Console.ReadLine();

                hospedes.Add(new Pessoa(nome, sobrenome));
            }

            Console.Write("Por quantos dias será a reserva? ");
            int dias = int.Parse(Console.ReadLine());

            reserva = new Reserva(dias);
            reserva.CadastrarSuite(suite);

            try
            {
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("\nHóspedes cadastrados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\nErro ao cadastrar hóspedes: {ex.Message}");
            }
            break;

        case "3":
            if (reserva == null)
            {
                Console.WriteLine("\nCadastre hóspedes primeiro!");
            }
            else
            {
                Console.WriteLine("\nReserva realizada com sucesso!");
            }
            break;

        case "4":
            if (reserva == null)
            {
                Console.WriteLine("\nNenhuma reserva encontrada!");
            }
            else
            {
                Console.WriteLine("\n=== Detalhes da Reserva ===");
                Console.WriteLine($"Suíte: {reserva.Suite.TipoSuite}");
                Console.WriteLine($"Capacidade: {reserva.Suite.Capacidade} hóspedes");
                Console.WriteLine($"Valor da diária: R$ {reserva.Suite.ValorDiaria}");

                Console.WriteLine("\nHóspedes:");
                foreach (var hospede in reserva.Hospedes)
                {
                    Console.WriteLine($"- {hospede.NomeCompleto()}");
                }

                Console.WriteLine($"\nDias reservados: {reserva.DiasReservados}");
                Console.WriteLine($"Valor total: R$ {reserva.CalcularValorDiaria()}");
            }
            break;

        case "0":
            Console.WriteLine("\nEncerrando o programa, obrigado pela preferência!");
            return;

        default:
            Console.WriteLine("\nOpção inválida, tente novamente.");
            break;
    }

    Console.WriteLine("\nPressione uma tecla para continuar...");
    Console.ReadKey();
}
