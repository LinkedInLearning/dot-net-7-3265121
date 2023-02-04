public class Document
{
  public string Titre { get; init; }

  public string? Lien { get; set; }

  public string? ContenuJson { get; set; }

  public const string ValidateurIsbn = @"^\d{13}$";
}