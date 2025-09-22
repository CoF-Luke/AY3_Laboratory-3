using System;

class Program
{
    static void Main()
    {
        Vector vec1 = new(3.5, 5.1, 9.3);
        Vector vec2 = new(7.0, 6.9, 13.13);
        Vector vec3 = new(5.1, 9.3, 3.5);

        Vector res1 = vec1 + vec2;
        Console.WriteLine($"operator + : x = {res1.X}, y = {res1.Y}, z = {res1.Z};");

        double x = 5.5;
        Vector res2 = vec1 * x;
        Console.WriteLine($"operator * double : x = {res2.X}, y = {res2.Y}, z = {res2.Z};");

        double res3 = vec1 * vec2;
        Console.WriteLine($"operator * : x = {res3};");

        Console.WriteLine($"operator < : {vec1 < vec2}");

        Console.WriteLine($"operator == : {vec1 == vec2}");

        Console.WriteLine($"operator == : {vec1 == vec3}");

        Console.WriteLine($"operator <= : {vec1 <= vec3}");


    }
}

struct Vector
{
    public double X = 0, Y = 0, Z = 0;

    public Vector(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    public static Vector operator +(Vector vec1, Vector vec2)
    {
        return new Vector(vec1.X + vec2.X, vec1.Y + vec2.Y, vec1.Z + vec2.Z);
    }

    public static double operator *(Vector vec1, Vector vec2)
    {
        return vec1.X * vec2.X + vec1.Y* vec2.Y + vec1.Z * vec2.Z;
    }

    public static Vector operator *(Vector vec1, double i)
    {
        return new Vector(vec1.X * i, vec1.Y * i, vec1.Z * i);
    }

    public static bool operator <(Vector vec1, Vector vec2)
    {
        return ((Math.Pow(vec1.X, 2) + Math.Pow(vec1.Y, 2) + Math.Pow(vec1.Z, 2)) < 
            (Math.Pow(vec2.X, 2) + Math.Pow(vec2.Y, 2) + Math.Pow(vec2.Z, 2)));
    }

    public static bool operator >(Vector vec1, Vector vec2)
    {
        return ((Math.Pow(vec1.X, 2) + Math.Pow(vec1.Y, 2) + Math.Pow(vec1.Z, 2)) >
            (Math.Pow(vec2.X, 2) + Math.Pow(vec2.Y, 2) + Math.Pow(vec2.Z, 2)));
    }

    public static bool operator <=(Vector vec1, Vector vec2)
    {
        return ((Math.Pow(vec1.X, 2) + Math.Pow(vec1.Y, 2) + Math.Pow(vec1.Z, 2)) <=
            (Math.Pow(vec2.X, 2) + Math.Pow(vec2.Y, 2) + Math.Pow(vec2.Z, 2)));
    }

    public static bool operator >=(Vector vec1, Vector vec2)
    {
        return ((Math.Pow(vec1.X, 2) + Math.Pow(vec1.Y, 2) + Math.Pow(vec1.Z, 2)) >=
            (Math.Pow(vec2.X, 2) + Math.Pow(vec2.Y, 2) + Math.Pow(vec2.Z, 2)));
    }

    public static bool operator ==(Vector vec1, Vector vec2)
    {
        return Math.Abs((Math.Pow(vec1.X, 2) + Math.Pow(vec1.Y, 2) + Math.Pow(vec1.Z, 2)) -
            (Math.Pow(vec2.X, 2) + Math.Pow(vec2.Y, 2) + Math.Pow(vec2.Z, 2))) < Math.Pow(10, -1);
    }

    public static bool operator !=(Vector vec1, Vector vec2)
    {
        return ((Math.Pow(vec1.X, 2) + Math.Pow(vec1.Y, 2) + Math.Pow(vec1.Z, 2)) !=
            (Math.Pow(vec2.X, 2) + Math.Pow(vec2.Y, 2) + Math.Pow(vec2.Z, 2)));
    }
}