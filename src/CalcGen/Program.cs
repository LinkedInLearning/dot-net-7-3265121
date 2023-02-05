void FibonacciAB(int nombre, int a, int b)
{
  for (; nombre-- > 0; a = b - a)
    Console.Write($"{b += a} ");
}

void Fibonacci(int nombre)
    => FibonacciAB(nombre, 0, 1);

Fibonacci(10);
Console.WriteLine();