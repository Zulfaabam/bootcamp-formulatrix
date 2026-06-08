// See https://aka.ms/new-console-template for more information
namespace Warung;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=============Warung============\n");

        Console.WriteLine($"Stok Minyak Goreng: {new MinyakGoreng().JumlahStok}");
        Console.WriteLine($"Stok Beras: {new Beras().JumlahStok}\n");

        Pembeli pembeli = new Pembeli("Abam");
        Pembeli pembeli2 = new("maba");

        pembeli.MembeliBarang(PilihanBarang.MinyakGoreng, 5);
        pembeli.MembeliBarang(PilihanBarang.Beras, 3);
        pembeli2.MembeliBarang(PilihanBarang.Beras, 2);

        Console.WriteLine("Ada yang beli....");
        Console.WriteLine($"Pembeli 1: {pembeli.Name}, Jumlah Membeli: {pembeli.BarangDibeli}");
        Console.WriteLine($"Pembeli 2: {pembeli2.Name}, Jumlah Membeli: {pembeli2.BarangDibeli}");
        Console.WriteLine($"\nTotal Pembeli: {Pembeli.TotalPembeli}");
        Console.WriteLine($"Total Barang Dibeli: {Pembeli.TotalBarangDibeli}");
        
        Console.WriteLine($"\nSisa Minyak Goreng: {new MinyakGoreng().JumlahStok}");
        Console.WriteLine($"Sisa Beras: {new Beras().JumlahStok}");

        Console.WriteLine("\n=============Warung============");
    }
}

