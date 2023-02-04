#region Temps

var a = DateTime.Now;
var b = DateTime.Now;

Console.WriteLine($"{a.Millisecond} {a.Microsecond} {a.Nanosecond}");

Console.WriteLine($"{a:hh:mm:ss:fffffff} {b:hh:mm:ss:fffffff}");

#endregion

#region Texte

// Multiligne
var xml = """
    <?xml version="1.0" encoding="utf-8"?>
    <biblio>
        <livre titre="Les misérables">
            <auteur>Victor Hugo</auteur>
        </livre>
        <livre titre="Le comte de Monte-Cristo">
            <auteur>Alexandre Dumas</auteur>
        </livre>
    </biblio>
    """;
Console.WriteLine(xml);

// String syntaxe
var doc = new Document() { Titre = "Les misérables" };

doc.ContenuJson = "[ 1.2, true, { 'a':1.5 }]";

#endregion