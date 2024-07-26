using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        string encryptedMessage = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";
        
        string[] arrayBinarioDecodificado = ChaveDeDecodificacao(encryptedMessage);
        string texto = BinarioParaTexto(arrayBinarioDecodificado);

        Console.WriteLine($"Mensagem Criptografada: {encryptedMessage}");
        Console.WriteLine($"Mensagem Descriptografada: {string.Join(" ", arrayBinarioDecodificado)}");
        Console.WriteLine($"Mensagem: {texto}");
    }

    static string[] ChaveDeDecodificacao(string mensagem)
    {
        string[] arrayLetrasBinarias = mensagem.Split(' ');
        List<string> arrayLetrasBinariasDecodificado = new List<string>();

        foreach (string itemDoArray in arrayLetrasBinarias)
        {
            string parte1 = itemDoArray.Substring(0, itemDoArray.Length / 2);
            string parte2 = itemDoArray.Substring(itemDoArray.Length / 2, itemDoArray.Length / 2);
            char[] arrayParte2 = parte2.ToCharArray();

            arrayParte2[parte2.Length - 2] = arrayParte2[parte2.Length - 2] == '1' ? '0' : '1';
            arrayParte2[parte2.Length - 1] = arrayParte2[parte2.Length - 1] == '1' ? '0' : '1';

            string BinarioParte2ComOsUltimosInvertidos = new string(arrayParte2);
            string novoItemTrocandoPartesDeLugar = BinarioParte2ComOsUltimosInvertidos + parte1;

            arrayLetrasBinariasDecodificado.Add(novoItemTrocandoPartesDeLugar);
        }
        
        return arrayLetrasBinariasDecodificado.ToArray();
    }

    static string BinarioParaTexto(string[] listaBinarios)
    {
        string texto = "";
        foreach (string bloco in listaBinarios)
        {
            int ascii = Convert.ToInt32(bloco, 2);
            texto += (char)ascii;
        }
        return texto;
    }
}
