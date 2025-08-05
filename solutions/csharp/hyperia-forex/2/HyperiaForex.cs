using System.Runtime.CompilerServices;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    public static bool operator ==(CurrencyAmount money1, CurrencyAmount money2)
    {
        if (money1.currency != money2.currency) throw new ArgumentException();
        return money1.amount == money2.amount;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(amount, currency);
    }

    public override bool Equals(object? obj)
    {
        if (obj is CurrencyAmount c)
        {
            if (this.currency == c.currency)
            {
                return this.amount == c.amount;
            }
            return false;
        }
        return false;

    }

    public static bool operator !=(CurrencyAmount money1, CurrencyAmount money2)
    {
        if (money1.currency != money2.currency) throw new ArgumentException();
        return money1.amount != money2.amount;
    }

    public static bool operator <(CurrencyAmount money1, CurrencyAmount money2)
    {
        if (money1.currency != money2.currency) throw new ArgumentException();
        return money1.amount < money2.amount;
    }

    public static bool operator >(CurrencyAmount money1, CurrencyAmount money2)
    {
        if (money1.currency != money2.currency) throw new ArgumentException();
        return money1.amount > money2.amount;
    }

    public static CurrencyAmount operator +(CurrencyAmount money1, CurrencyAmount money2)
    {
        if (money1.currency != money2.currency) throw new ArgumentException();
        return new CurrencyAmount(money1.amount + money2.amount, money1.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount money1, CurrencyAmount money2)
    {
        if (money1.currency != money2.currency) throw new ArgumentException();
        return new CurrencyAmount(money1.amount - money2.amount, money1.currency);
    }

    public static CurrencyAmount operator *(decimal num, CurrencyAmount money1)
    {
        return new CurrencyAmount(num * money1.amount, money1.currency);
    }

    public static CurrencyAmount operator /(decimal num, CurrencyAmount money1)
    {
        return new CurrencyAmount(money1.amount / num, money1.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount money1, decimal num)
    {
        return new CurrencyAmount(money1.amount / num, money1.currency);
    }

    public static CurrencyAmount operator *(CurrencyAmount money1, decimal num)
    {
        return new CurrencyAmount(money1.amount * num, money1.currency);
    }

    public static explicit operator double(CurrencyAmount money)
    {
        return (double)money.amount;
    }

    public static implicit operator decimal(CurrencyAmount money)
    {
        return (decimal)money.amount;
    }

    // TODO: implement type conversion operators
}
