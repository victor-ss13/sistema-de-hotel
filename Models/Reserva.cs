using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioProjetoHospedagem.Models
{
    public class Reserva
    {

        // Propriedades
        public List<Pessoa> Hospedes { get; private set; }
        public Suite Suite { get; set; }
        public int DiasReservados { get; private set; }

        // Construtor
        public Reserva(int diasReservados)
        {
            DiasReservados = diasReservados;
            Hospedes = new List<Pessoa>(); // Inicializa a lista vazia para evitar erros de referência nula
        }


        // Métodos
        public void CadastrarHospedes(List<Pessoa> hospedes)
        {
            if (hospedes.Count > Suite.Capacidade)
            {
                throw new Exception("A suíte não comporta o número de hóspedes informado.");
            }

            Hospedes = hospedes;
        }

        public void CadastrarSuite(Suite suite)
        {
            Suite = suite;
        }

        public int ObterQuantidadeHospedes()
        {
            return Hospedes.Count;
        }

        public decimal CalcularValorDiaria()
        {
            decimal valor = DiasReservados * Suite.ValorDiaria;

            // Aplicar desconto de 10% para reservas com 10 ou mais dias
            if (DiasReservados >= 10)
            { 
                valor *= 0.9M;
            }

            return valor;
        }
    }
}