namespace Warung;

public class Pembeli
{
    private string _name;
    private int _jumlahBarangDibeli = 0;
    private static int _totalPembeli = 0;
    private static int _totalBarangDibeli = 0;

    public string Name { get { return _name; } set { _name = value; } }
    public int BarangDibeli { get { return _jumlahBarangDibeli; } }

    public static int TotalPembeli => _totalPembeli;
    public static int TotalBarangDibeli => _totalBarangDibeli;

    public Pembeli(string name)
    {
        _name = name;

        _totalPembeli++;
    }

    public void MembeliBarang(PilihanBarang namaBarang, int jumlahBeli)
    {
        if (!Enum.IsDefined(typeof(PilihanBarang), namaBarang))
        {
            Console.WriteLine("Barang tidak valid!");
            return;
        }

        if (jumlahBeli <= 0)
        {
            Console.WriteLine("Jumlah beli harus lebih dari 0!");
            return;
        }

        _jumlahBarangDibeli += jumlahBeli;
            
        _totalBarangDibeli += jumlahBeli;

        switch (namaBarang)
        {
            case PilihanBarang.MinyakGoreng:
                MinyakGoreng minyakGoreng = new MinyakGoreng();
                minyakGoreng.Dibeli(jumlahBeli);
                break;
            case PilihanBarang.Beras:
                Beras beras = new Beras();
                beras.Dibeli(jumlahBeli);
                break;
            default:
                break;
        }
    }
}