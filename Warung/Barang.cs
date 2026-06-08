namespace Warung;

public enum PilihanBarang
{
    MinyakGoreng,
    Beras
}

public interface IBarang
{
    int Harga { get; }
    int JumlahStok { get; }
    void Dibeli(int jumlah);
}

public class MinyakGoreng : IBarang
{
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