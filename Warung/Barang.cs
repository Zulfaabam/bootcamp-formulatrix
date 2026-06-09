namespace Warung;

public enum PilihanBarang
{
    MinyakGoreng,
    Beras
}

public interface IBarang
{
    string Name { get; }
    int Harga { get; }
    int JumlahStok { get; }
    void Dibeli(int jumlah);
}

public class MinyakGoreng : IBarang
{
    public string Name => "Minyak Goreng";
    public int Harga => 15000;

    private static int _jumlahStok = 10;

    public int JumlahStok => _jumlahStok;

    public void Dibeli(int jumlah)
    {
        if (_jumlahStok >= jumlah)
        {
            _jumlahStok -= jumlah;
        } else
        {
            Console.WriteLine("Stok kurang!");
        }
    }
}

public class Beras : IBarang
{
    public string Name => "Beras";
    public int Harga => 25000;

    private static int _jumlahStok = 20;

    public int JumlahStok => _jumlahStok;

    public void Dibeli(int jumlah)
    {
        if (_jumlahStok >= jumlah)
        {
            _jumlahStok -= jumlah;
        } else
        {
            Console.WriteLine("Stok kurang!");
        }
    }
}

public static class BarangFactory
{
    public static IBarang Create(PilihanBarang pilihan) => pilihan switch
    {
        PilihanBarang.MinyakGoreng => new MinyakGoreng(),
        PilihanBarang.Beras => new Beras(),
        _ => throw new ArgumentException("Invalid barang type", nameof(pilihan))
    };
}