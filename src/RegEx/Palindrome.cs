using BenchmarkDotNet.Attributes;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;

[MemoryDiagnoser]
public class Palindrome
{
  [StringSyntax(StringSyntaxAttribute.Regex)]
  const string modele = @"^(?'L'\w)+\w?(?:\k'L'(?'-L'))+(?('L')(?!))$";

  [BenchmarkCategory("init"), Benchmark] public void InitSimple() { Simple = new Regex(modele); }
  [BenchmarkCategory("init"), Benchmark] public void InitCompil() { Compilated = new Regex(modele, RegexOptions.Compiled); }
  [BenchmarkCategory("init"), Benchmark] public void InitStatic() { ViderCache(); Regex.IsMatch(modele, Texte.ToLower()); }

  [BenchmarkCategory("exec"), Benchmark] public bool VerifierSimple() => Simple.IsMatch(Texte.ToLower());
  [BenchmarkCategory("exec"), Benchmark] public bool VerifierCompil() => Compilated.IsMatch(Texte.ToLower());
  [BenchmarkCategory("exec"), Benchmark] public bool VerifierStatic() => Regex.IsMatch(modele, Texte.ToLower());

  private Regex Simple = new Regex(modele);
  private Regex Compilated = new Regex(modele, RegexOptions.Compiled);

  public string Texte { get; set; } = "ressasser";
  private void ViderCache()
  {
    Regex.CacheSize = 0;
    Regex.CacheSize = 15;
  }
}
