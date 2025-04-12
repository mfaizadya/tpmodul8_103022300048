using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config;
        try
        {
            string jsonString = File.ReadAllText("covid_config.json");
            config = JsonSerializer.Deserialize<CovidConfig>(jsonString);
        }
        catch
        {
            config = new CovidConfig
            {
                satuan_suhu = "celcius",
                batas_hari_demam = 14,
                pesan_ditolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini",
                pesan_diterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini"
            };
        }

        Console.Write($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}: ");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool isSuhuNormal = false;

        if (config.satuan_suhu.ToLower() == "celcius")
            isSuhuNormal = suhu >= 36.5 && suhu <= 37.5;
        else
            isSuhuNormal = suhu >= 97.7 && suhu <= 99.5;

        if (isSuhuNormal && hariDemam < config.batas_hari_demam)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }

        config.UbahSuhu();
        Console.WriteLine($"Satuan suhu setelah diubah: {config.satuan_suhu}");
    }
}





