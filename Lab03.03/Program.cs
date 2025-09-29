class Program
{
    static void Main()
    {
        decimal changeU = Convert.ToDecimal(Console.ReadLine());
        decimal changeE = Convert.ToDecimal(Console.ReadLine());

        CurrencyEUR.RateToRub = changeE;
        CurrencyUSD.RateToRub = changeU;

        CurrencyUSD uCur = new CurrencyUSD(100);
        Console.WriteLine(uCur.Value);

        CurrencyRUB rCur = (CurrencyRUB)uCur;
        Console.WriteLine(rCur.Value);

        CurrencyEUR eCur = (CurrencyEUR)rCur;
        Console.WriteLine(eCur.Value);
    }
}


public abstract class Currency
{
    public decimal Value { get; set; }   // сумма в данной валюте

    protected Currency(decimal value)
    {
        Value = value;
    }
}

#region USD 
public class CurrencyUSD : Currency
{
    public static decimal RateToRub { get; set; } // курс доллара к рублю
    public CurrencyUSD(decimal value) : base(value) { }

    // USD -> RUB
    public static explicit operator CurrencyRUB(CurrencyUSD usd) =>
        new CurrencyRUB(usd.Value * RateToRub);

    // USD -> EUR
    public static explicit operator CurrencyEUR(CurrencyUSD usd) =>
        new CurrencyEUR((usd.Value * RateToRub) / CurrencyEUR.RateToRub);
}
#endregion

#region EUR
public class CurrencyEUR : Currency
{
    public static decimal RateToRub { get; set; } // курс евро к рублю
    public CurrencyEUR(decimal value) : base(value) { }

    // EUR -> RUB
    public static explicit operator CurrencyRUB(CurrencyEUR eur) =>
        new CurrencyRUB(eur.Value * RateToRub);

    // EUR -> USD
    public static explicit operator CurrencyUSD(CurrencyEUR eur) =>
        new CurrencyUSD((eur.Value * RateToRub) / CurrencyUSD.RateToRub);
}
#endregion

#region RUB
public class CurrencyRUB : Currency
{
    public static decimal RateToRub { get; set; } = 1; // всегда 1 к 1
    public CurrencyRUB(decimal value) : base(value) { }

    // RUB -> USD
    public static explicit operator CurrencyUSD(CurrencyRUB rub) =>
        new CurrencyUSD(rub.Value / CurrencyUSD.RateToRub);

    // RUB -> EUR
    public static explicit operator CurrencyEUR(CurrencyRUB rub) =>
        new CurrencyEUR(rub.Value / CurrencyEUR.RateToRub);
}
#endregion