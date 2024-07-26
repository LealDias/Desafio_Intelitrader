using System;
using System.Text;

public class Program
{
    public static void Main()
    {
        string binaryMessage = "10010110 11110111 01010110 00000001 00010111 00100110 01010111 00000001 00010111 01110110 01010111 00110110 11110111 11010111 01010111 00000011";
        string[] binaryBytes = binaryMessage.Split(' ');

        Console.WriteLine("Descriptografando byte a byte:");
        DescriptografarByteAbyte(binaryBytes);

        Console.WriteLine("\nDescriptografando de forma sequencial:");
        DescriptografarSequencial(binaryMessage.Replace(" ", ""));
    }

    private static void DescriptografarByteAbyte(string[] binaryBytes)
    {
        StringBuilder result = new StringBuilder();
        
        foreach (var binaryByte in binaryBytes)
        {
            Console.WriteLine($"Processando byte original: {binaryByte}");

            // Invertendo os dois últimos bits
            char[] bits = binaryByte.ToCharArray();
            char temp = bits[6];
            bits[6] = bits[7];
            bits[7] = temp;
            Console.WriteLine($"Após inverter os dois últimos bits: {new string(bits)}");

            // Trocando os 4 primeiros bits com os 4 últimos
            string swappedBits = new string(bits, 4, 4) + new string(bits, 0, 4);
            Console.WriteLine($"Após trocar os 4 primeiros bits com os 4 últimos: {swappedBits}");

            // Convertendo para caractere ASCII
            int asciiValue = Convert.ToInt32(swappedBits, 2);
            char character = (char)asciiValue;
            result.Append(character);
        }
        
        Console.WriteLine($"Mensagem descriptografada: {result.ToString()}");
    }

    private static void DescriptografarSequencial(string binaryMessage)
    {
        StringBuilder result = new StringBuilder();
        int length = binaryMessage.Length;

        for (int i = 0; i < length; i += 8)
        {
            string binaryByte = binaryMessage.Substring(i, 8);
            Console.WriteLine($"Processando byte original: {binaryByte}");

            // Invertendo os dois últimos bits
            char[] bits = binaryByte.ToCharArray();
            char temp = bits[6];
            bits[6] = bits[7];
            bits[7] = temp;
            Console.WriteLine($"Após inverter os dois últimos bits: {new string(bits)}");

            // Trocando os 4 primeiros bits com os 4 últimos
            string swappedBits = new string(bits, 4, 4) + new string(bits, 0, 4);
            Console.WriteLine($"Após trocar os 4 primeiros bits com os 4 últimos: {swappedBits}");

            // Convertendo para caractere ASCII
            int asciiValue = Convert.ToInt32(swappedBits, 2);
            char character = (char)asciiValue;
            result.Append(character);
        }

        Console.WriteLine($"Mensagem descriptografada: {result.ToString()}");
    }
}