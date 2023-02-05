using System.Text.Json;

var paiements = new Paiement[] {
    new Carte  (Guid.NewGuid(), 95m, "1234 5678 9012 3456", new DateOnly(2025, 12, 1)),
    new Liquide(Guid.NewGuid(), MontantRecu: 100m, Monnaie: 10m),
    new Carte  (Guid.NewGuid(), 28m, "9012 3456 1234 5678", new DateOnly(2024, 3, 1))
};
var options = new JsonSerializerOptions() {
  WriteIndented = true
};

Console.WriteLine(
    JsonSerializer.Serialize(paiements, options)
);

