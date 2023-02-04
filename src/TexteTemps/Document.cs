using System.Diagnostics.CodeAnalysis;

public class Document
{
  public required string Titre { get; init; }

  [StringSyntax(StringSyntaxAttribute.Uri)]
  public string? Lien { get; set; }

  [StringSyntax(StringSyntaxAttribute.Json)]
  public string? ContenuJson { get; set; }

  [StringSyntax(StringSyntaxAttribute.Regex)]
  public const string ValidateurIsbn = @"^\d{13}$";
}