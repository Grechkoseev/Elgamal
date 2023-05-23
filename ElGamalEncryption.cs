using System.Numerics;

namespace Lab_6;

internal class ElGamalEncryption
{
    private readonly int _p;
    private readonly int _g;
    private readonly int _x;
    private readonly int _y;
    private readonly int _k;

    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="p"></param>
    /// <param name="g"></param>
    /// <param name="x"></param>
    public ElGamalEncryption(int p, int g, int x)
    {
        _p = p;
        _g = g;
        _x = x;
        _y = (int)Math.Pow(_g, _x) % _p;
        _k = GetRandomNumber(_p);
    }

    /// <summary>
    /// генерируем случайное число k, взаимно простое с p-1, такое что 1 < k < p-1
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private static int GetRandomNumber(int p)
    {
        var rnd = new Random();
        int x;

        do
        {
            x = rnd.Next(1, p - 1); 
        } while (GCD(x, p - 1) != 1);

        return x;
    }

    /// <summary>
    /// НОД a и b
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            var temp = b;
            b = a % b;
            a = temp;
        }

        return a;
    }

    /// <summary>
    /// Вычисляем r и s
    /// </summary>
    /// <param name="h"></param>
    /// <param name="r"></param>
    /// <param name="s"></param>
    public void CountRS(int h, out int r, out int s)
    {
        r = (int)(BigInteger.Pow(_g, _k) % _p);
        var u = (h - _x * r) % (_p - 1);

        if (u < 0)
        {
            u += _p - 1;
        }

        var k = FindInverse(_k, _p - 1);
        s = k * u % (_p - 1);
    }

    /// <summary>
    /// Вычисляем k^-1, такое, что k * k^-1 = 1 mod p-1
    /// </summary>
    /// <param name="k"></param>
    /// <param name="p"></param>
    /// <returns></returns>
    private static int FindInverse(int k, int p)
    {
        var t = 0;
        var r = p;
        var newt = 1;
        var newr = k;

        while (newr != 0)
        {
            var quotient = r / newr;
            var temp1 = t - quotient * newt;
            var temp2 = r - quotient * newr;

            t = newt;
            newt = temp1;
            r = newr;
            newr = temp2;
        }

        if (t < 0)
        {
            t += p;
        }

        return t;
    }

    /// <summary>
    /// Вычисляем y^r * r^s mod p
    /// </summary>
    /// <param name="r"></param>
    /// <param name="s"></param>
    /// <returns></returns>
    public int CountLeftSide(int r, int s)
    {
        return (int)(BigInteger.Pow(_y, r) * BigInteger.Pow(r, s) % _p);
    }

    /// <summary>
    /// Вычисляем g^h mod p
    /// </summary>
    /// <param name="hash"></param>
    /// <returns></returns>
    public int CountRightSide(int hash)
    {
        return (int)(BigInteger.Pow(_g, hash) % _p);
    }

    /// <summary>
    /// Сравниваем левую и правую часть, проверяем верность равенства y^r * r^s mod p == g^h mod p
    /// </summary>
    /// <param name="r"></param>
    /// <param name="s"></param>
    /// <param name="h"></param>
    /// <returns></returns>
    public bool IsLeftAndRightEquals(int r, int s, int h)
    {
        return (int)(BigInteger.Pow(_y, r) * BigInteger.Pow(r, s) % _p) == (int)(BigInteger.Pow(_g, h) % _p);
    }
}