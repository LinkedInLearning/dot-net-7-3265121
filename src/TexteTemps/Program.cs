#region Temps

var a = DateTime.Now;
var b = DateTime.Now;

Console.WriteLine($"{a.Millisecond}");

Console.WriteLine($"{a:hh:mm:ss:fff} {b:hh:mm:ss:fff}");

#endregion

#region Texte

// Multiligne
var xml = @"
<?xml version=""1.0"" encoding=""utf-8""?>
<biblio>
    <livre titre=""Les misérables"">
        <auteur>Victor Hugo</auteur>
    </livre>
    <livre titre=""Le comte de Monte-Cristo"">
        <auteur>Alexandre Dumas</auteur>
    </livre>
</biblio>
";
Console.WriteLine(xml);

// String syntaxe
var doc = new Document() { Titre = "Les misérables" };

doc.ContenuJson = "[ 1.2, True, { 'a':1.5 }]";

#endregion