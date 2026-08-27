using System;
using System.Collections.Generic;

class Program
{
    const decimal DiscountLimit = 500m;
    const decimal DiscountRate = 0.15m;

    static void Main(string[] args)
    {
        List<string> itemNames = new List<string>();
        List<int> quantities = new List<int>();
        List<decimal> unitPrices = new List<decimal>();
        List<decimal> lineTotals = new List<decimal>();

        decimal totalPrice = 0m;
        string answer = "j";

        while (answer.ToLower() == "j")
        {
            Console.Write("Indtast varenavn: ");
            string itemName = Console.ReadLine() ?? "";

            Console.Write("Indtast antal: ");
            int quantity = int.Parse(Console.ReadLine() ?? "0");

            Console.Write("Indtast pris pr. enhed: ");
            decimal unitPrice = decimal.Parse(Console.ReadLine() ?? "0");

            decimal lineTotal = CalculateLineTotal(quantity, unitPrice);

            itemNames.Add(itemName);
            quantities.Add(quantity);
            unitPrices.Add(unitPrice);
            lineTotals.Add(lineTotal);

            totalPrice += lineTotal;

            Console.Write("Vil du registrere endnu en vare? (j/n): ");
            answer = Console.ReadLine() ?? "n";
        }

        Console.WriteLine();

        for (int i = 0; i < itemNames.Count; i++)
        {
            Console.WriteLine(
                $"{itemNames[i]}: {quantities[i]} stk. à {unitPrices[i]:F2} kr. = {lineTotals[i]:F2} kr.");
        }

        Console.WriteLine($"Samlet pris før rabat: {totalPrice:F2} kr.");

        decimal discount = CalculateDiscount(totalPrice);

        if (discount > 0)
        {
            Console.WriteLine($"15% rabat: {discount:F2} kr.");
        }
        else
        {
            Console.WriteLine("Ingen rabat (under 500 kr.)");
        }

        decimal finalPrice = totalPrice - discount;

        Console.WriteLine($"Samlet pris: {finalPrice:F2} kr.");
    }

    static decimal CalculateLineTotal(int quantity, decimal unitPrice)
    {
        return quantity * unitPrice;
    }

    static decimal CalculateDiscount(decimal totalPrice)
    {
        if (totalPrice > DiscountLimit)
        {
            return totalPrice * DiscountRate;
        }

        return 0m;
    }
}