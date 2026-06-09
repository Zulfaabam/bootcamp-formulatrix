// See https://aka.ms/new-console-template for more information
namespace Warung;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();

        ShowHeader();

        ShowMenu();

        BuyingProcess();

        Console.WriteLine("\n============= Terimakasih ============\n");

        // Console.WriteLine($"Sisa stok {barangTerpilih}: {barang.JumlahStok}");
    }
    public static void ShowHeader()
    {
        Console.WriteLine("╔══════════════════════════════════════════════════════════════╗");
        Console.WriteLine("║               SELAMAT DATANG DI WARUNG ABAM                  ║");
        Console.WriteLine("║                THE BEST WARUNG IN THE WORLD                  ║");
        Console.WriteLine("╚══════════════════════════════════════════════════════════════╝\n");
    }
    public static void ShowMenu()
    {
        Console.WriteLine("Mau beli apa?");

        foreach (PilihanBarang pb in Enum.GetValues<PilihanBarang>())
        {
            IBarang objBarang = BarangFactory.Create(pb);

            Console.WriteLine($"{(int)pb + 1}. {pb}, Harga: Rp {objBarang.Harga}, Stok: {objBarang.JumlahStok}");
        }
    }
    public static IBarang? BarangPilihan()
    {
        Console.Write("\nKetik nomornya: ");

        if (!int.TryParse(Console.ReadLine(), out int terpilih))
        {
            Console.WriteLine("Input tidak valid!");
            return null;
        }

        if (terpilih < 1 || terpilih > Enum.GetValues<PilihanBarang>().Length)
        {
            Console.WriteLine("Pilihan tidak ada...");
            return null;
        }

        PilihanBarang barangTerpilih = (PilihanBarang)(terpilih - 1);

        IBarang barang = BarangFactory.Create(barangTerpilih);
        
        Console.WriteLine($"Terpilih: {barangTerpilih}");

        return barang;
    }
    public static int JumlahBarang()
    {
        Console.Write("Jumlahnya: ");

        if (!int.TryParse(Console.ReadLine(), out int jumlah))
        {
            Console.WriteLine("Input tidak valid!");
            return 0;
        }

        Console.WriteLine($"Jumlah: {jumlah}");

        return jumlah;
    }
    public static decimal CalculateTotalHarga(IBarang barang, int jumlah)
    {
        decimal harga = barang.Harga;
        decimal totalHarga = harga * jumlah;

        Console.WriteLine($"Harga satuan: {harga}");
        Console.WriteLine($"Total Harga: {totalHarga}");

        return totalHarga;
    }
    public static void BuyingProcess()
    {
        IBarang? barang = BarangPilihan();

        if (barang == null)
        {
            Console.WriteLine("Barang tidak valid!");
            return;
        }

        int jumlah = JumlahBarang();

        if (jumlah > barang.JumlahStok)
        {
            Console.WriteLine("Stok tidak mencukupi!");
            return;
        }

        decimal totalHarga = CalculateTotalHarga(barang, jumlah);

        Console.Write("\nMasukkan nama pembeli: ");
        string namaPembeli = Console.ReadLine() ?? "Pembeli";

        Console.Write("Jumlah uang pembeli: ");

        if (!decimal.TryParse(Console.ReadLine(), out decimal uangPembeli))
        {
            Console.WriteLine("Input tidak valid!");
            return;
        }

        if (uangPembeli < totalHarga)
        {
            Console.WriteLine("Uang tidak cukup!");
            return;
        }

        Pembeli pembeli = new(namaPembeli);
        pembeli.MembeliBarang(barang, jumlah);

        Console.WriteLine($"\n{pembeli.Name} berhasil membeli {jumlah} {barang.Name} \ndengan total harga Rp {totalHarga} \nkembalian Rp {uangPembeli - totalHarga}");
    }
}

