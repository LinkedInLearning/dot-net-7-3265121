public abstract record Paiement(Guid Transaction, decimal Montant);

public record Carte(Guid Transaction, decimal Montant, string Numero, DateOnly Expiration)
    : Paiement(Transaction, Montant);

public record Liquide(Guid Transaction, decimal MontantRecu, decimal Monnaie)
    : Paiement(Transaction, MontantRecu - Monnaie);
