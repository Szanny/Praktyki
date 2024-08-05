public class Program1
{
    public static void Main()
    {
        Console.WriteLine("Podaj ciąg 13 zaków");
        string ean = Console.ReadLine();

        string result = SprawdzenieEAN(ean);
        Console.WriteLine(result);
    }
    public static string SprawdzenieEAN(string ean)
    {
        if (ean.Length != 13 || !SprawdzenieCzyTylkoCyfry(ean))
        {
            return "podany EAN nie składa się z 13 cyfr";
        }
        int[] eanL = new int[13];
        for (int i = 0; i < 13; i++)
        {
            eanL[i] = int.Parse(ean[i].ToString());
        }
        int ostatniaLiczba = eanL[12];

        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            if (i % 2 != 0)
            {
                sum += eanL[i] * 3;
            }
            else
            {
                sum += eanL[i];
            }
        }
        int reszta = sum % 10;
        int ostatniaLiczbaSprawdzenie = 10 - reszta;
        if (ostatniaLiczbaSprawdzenie == ostatniaLiczba)
        {
            return "EAN prawidłowy";
        }
        else
        {
            return "błędny EAN";
        }

    }
    public static bool SprawdzenieCzyTylkoCyfry(string ean)
    {
        foreach (char cyfra in ean)
        {
            if (cyfra < '0' || cyfra > '9')
            {
                return false;
            }
        }
        return true;
    }
}
