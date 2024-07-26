using System;
using System.Collections.Generic;

public class Oferta
{
    public int Posicao { get; set; }
    public double Valor { get; set; }
    public int Quantidade { get; set; }
}

public class LivroDeOfertas
{
    private List<Oferta> ofertas;

    public LivroDeOfertas()
    {
        ofertas = new List<Oferta>();
    }

    public void ProcessarNotificacao(int posicao, int acao, double valor, int quantidade)
    {
        switch (acao)
        {
            case 0: // Inserir
                InserirOferta(posicao, valor, quantidade);
                break;
            case 1: // Modificar
                ModificarOferta(posicao, valor, quantidade);
                break;
            case 2: // Deletar
                DeletarOferta(posicao);
                break;
        }
    }

    private void InserirOferta(int posicao, double valor, int quantidade)
    {
        // Cria uma nova oferta
        Oferta novaOferta = new Oferta { Posicao = posicao, Valor = valor, Quantidade = quantidade };

        // Insere a oferta na posição correta (incrementa a posição das ofertas subsequentes)
        for (int i = 0; i < ofertas.Count; i++)
        {
            if (ofertas[i].Posicao >= posicao)
            {
                ofertas[i].Posicao++;
            }
        }

        ofertas.Insert(posicao - 1, novaOferta);
    }

    private void ModificarOferta(int posicao, double valor, int quantidade)
    {
        foreach (var oferta in ofertas)
        {
            if (oferta.Posicao == posicao)
            {
                if (valor != 0)
                {
                    oferta.Valor = valor;
                }
                if (quantidade != 0)
                {
                    oferta.Quantidade = quantidade;
                }
                break;
            }
        }
    }

    private void DeletarOferta(int posicao)
    {
        for (int i = 0; i < ofertas.Count; i++)
        {
            if (ofertas[i].Posicao == posicao)
            {
                ofertas.RemoveAt(i);
                break;
            }
        }

        // Decrementa a posição das ofertas subsequentes
        for (int i = 0; i < ofertas.Count; i++)
        {
            if (ofertas[i].Posicao > posicao)
            {
                ofertas[i].Posicao--;
            }
        }
    }

    public void ImprimirLivro()
    {
        foreach (var oferta in ofertas)
        {
            Console.WriteLine($"{oferta.Posicao},{oferta.Valor},{oferta.Quantidade}");
        }
    }
}

public class Program
{
    public static void Main()
    {
        if (!int.TryParse(Console.ReadLine(), out int numeroDeNotificacoes))
        {
            Console.WriteLine("Número de notificações inválido.");
            return;
        }

        LivroDeOfertas livroDeOfertas = new LivroDeOfertas();

        for (int i = 0; i < numeroDeNotificacoes; i++)
        {
            string? input = Console.ReadLine();
            if (input != null)
            {
                string[] notificacao = input.Split(',');

                if (notificacao.Length == 4 &&
                    int.TryParse(notificacao[0], out int posicao) &&
                    int.TryParse(notificacao[1], out int acao) &&
                    double.TryParse(notificacao[2], out double valor) &&
                    int.TryParse(notificacao[3], out int quantidade))
                {
                    livroDeOfertas.ProcessarNotificacao(posicao, acao, valor, quantidade);
                }
                else
                {
                    Console.WriteLine("Notificação inválida.");
                }
            }
        }

        livroDeOfertas.ImprimirLivro();
    }
}