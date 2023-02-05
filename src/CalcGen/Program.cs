using System.Numerics;

void FibonacciAB<T>(int nombre, T a, T b) where T : INumber<T>
{
  for (; nombre-- > 0; a = b - a)
    Console.Write($"{b += a} ");
}

void Fibonacci<T>(int nombre) where T : INumber<T>
    => FibonacciAB(nombre, T.Zero, T.One);

Fibonacci<BigInteger>(1000);
Console.WriteLine();