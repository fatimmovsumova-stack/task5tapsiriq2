
using System;
using System.IO;

class Program
{
    static void Main()
    {
        try
        {
           
            Console.Write("Menbe qovlugunun yolunu daxil edin: ");
            string menbe = Console.ReadLine();

            
            if (!Directory.Exists(menbe))
            {
                Console.WriteLine("Xeta: Menbe qovlugu movcud deyil!");
                return;
            }

          
            Console.Write("Teyinat qovlugunun yolunu daxil edin: ");
            string teyinat = Console.ReadLine();

            
            if (!Directory.Exists(teyinat))
            {
                Directory.CreateDirectory(teyinat);
                Console.WriteLine("Teyinat qovlugu yaradildi.");
            }

            
            string tarix = DateTime.Now.ToString("yyyy-MM-dd");

           
            string[] fayllar = Directory.GetFiles(menbe, "*.txt");

            int say = 0;
            long umumiOlcu = 0;

           
            foreach (string fayl in fayllar)
            {
                FileInfo info = new FileInfo(fayl);

                string yeniAd = tarix + "_" + info.Name;

                string yeniYol = Path.Combine(teyinat, yeniAd);

                File.Copy(fayl, yeniYol, true);

                say++;

                umumiOlcu += info.Length;

                Console.WriteLine(info.Name + " -> " + yeniAd);
            }

            
            Console.WriteLine("\n===== BACKUP NETICESI =====");

            Console.WriteLine("Kopyalanan fayllarin sayi: " + say);

            Console.WriteLine("Umumi olcu: " + umumiOlcu + " bayt");

            Console.WriteLine("Backup emeliyyati tamamlandi!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Xeta bas verdi: " + ex.Message);
        }
    }
}
