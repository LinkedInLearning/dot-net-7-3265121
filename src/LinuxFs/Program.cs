using System.Formats.Tar;
using System.IO.Compression;

var racine = Path.Combine(
    Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) ?? "./",
    "../../.."
);
var archive = Path.Combine(racine, "archive.tar.gz");
var repertoire = Path.Combine(racine, "obj");
var contenu = Path.Combine(racine, "obj/contenu");

try
{
  Console.WriteLine("Décompression : ");
  using (var gz = new GZipStream(File.OpenRead(archive), CompressionMode.Decompress))
  {
    using var tar = new TarReader(gz);
    TarEntry? entree;

    while ((entree = tar.GetNextEntry()) is not null)
    {
      Console.WriteLine($"- {entree.Name} ({entree.Length}b) : {entree.Mode}");
    }
  }

  using (var gz = new GZipStream(File.OpenRead(archive), CompressionMode.Decompress))
  {
    TarFile.ExtractToDirectory(gz, repertoire, true);
  }

  Console.WriteLine("Parcours :");
  foreach (var chemin in Directory.EnumerateFileSystemEntries(contenu))
  {
    var info = OperatingSystem.IsLinux()
            ? File.GetUnixFileMode(chemin)
            : UnixFileMode.None;
    Console.WriteLine($"- {Path.GetFileName(chemin)} : {info}");
  }
}
catch (IOException e)
{
  Console.Error.WriteLine(e.Message);
}
