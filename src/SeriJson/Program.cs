using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

var paiements = new Paiement[] {
    new Carte  (Guid.NewGuid(), 95m, "1234 5678 9012 3456", new DateOnly(2025, 12, 1)),
    new Liquide(Guid.NewGuid(), MontantRecu: 100m, Monnaie: 10m),
    new Carte  (Guid.NewGuid(), 28m, "9012 3456 1234 5678", new DateOnly(2024, 3, 1))
};
var options = new JsonSerializerOptions() {
  WriteIndented = true,
  TypeInfoResolver = new DefaultJsonTypeInfoResolver() {
    Modifiers = { IgnorerMontantLiquide }
  }
};

Console.WriteLine(
    JsonSerializer.Serialize(paiements, options)
);

static void IgnorerMontantLiquide(JsonTypeInfo info)
{
  if (info.Type == typeof(Liquide))
  {
    foreach (var prop in info.Properties)
    {
      if (prop.Name == nameof(Liquide.Montant))
        prop.ShouldSerialize = (a, b) => false;
    }
  }
}
