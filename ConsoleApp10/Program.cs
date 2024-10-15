namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Manav manav = new Manav();
            manav.HalAlis();
            manav.MusteriSatis();
        }
    }

    class Manav
    {
        private Dictionary<string, double> halUrunleri = new Dictionary<string, double>();
        private Dictionary<string, double> satisUrunleri = new Dictionary<string, double>();

        public void HalAlis()
        {
            string secim;
            do
            {
                Console.WriteLine("Meyve mi, sebze mi? (m/s): ");
                secim = Console.ReadLine().ToLower();

                if (secim == "m")
                {
                    MeyveEkle();
                }
                else if (secim == "s")
                {
                    SebzeEkle();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim! Lütfen 'm' veya 's' girin.");
                    continue;
                }

                Console.WriteLine("Başka bir arzunuz var mı? (E/H): ");
            } while (Console.ReadLine().ToUpper() == "E");
        }

        private void MeyveEkle()
        {
            string[] meyveler = { "Elma", "Muz", "Portakal", "Armut", "Çilek" };
            ListeleUrunler(meyveler);

            Console.Write("Hangi meyveyi seçiyorsunuz? ");
            string secim = Console.ReadLine();

            Console.Write("Kaç kilo almak istiyorsunuz? ");
            double kilo = Convert.ToDouble(Console.ReadLine());

            if (halUrunleri.ContainsKey(secim))
            {
                halUrunleri[secim] += kilo; 
            }
            else
            {
                halUrunleri[secim] = kilo; 
            }

            Console.WriteLine($"{kilo} kg {secim} halden alındı.");
        }

        private void SebzeEkle()
        {
            string[] sebzeler = { "Domates", "Salatalık", "Biber", "Havuç", "Patates" };
            ListeleUrunler(sebzeler);

            Console.Write("Hangi sebzeyi seçiyorsunuz? ");
            string secim = Console.ReadLine();

            Console.Write("Kaç kilo almak istiyorsunuz? ");
            double kilo = Convert.ToDouble(Console.ReadLine());

            if (halUrunleri.ContainsKey(secim))
            {
                halUrunleri[secim] += kilo; 
            }
            else
            {
                halUrunleri[secim] = kilo; 
            }

            Console.WriteLine($"{kilo} kg {secim} halden alındı.");
        }

        private void ListeleUrunler(string[] urunler)
        {
            Console.WriteLine("Seçebileceğiniz ürünler:");
            foreach (var urun in urunler)
            {
                Console.WriteLine($"- {urun}");
            }
        }

        public void MusteriSatis()
        {
            string secim;
            do
            {
                Console.WriteLine("Meyve mi, sebze mi? (m/s): ");
                secim = Console.ReadLine().ToLower();

                if (secim == "m")
                {
                    SatisMeyve();
                }
                else if (secim == "s")
                {
                    SatisSebze();
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim! Lütfen 'm' veya 's' girin.");
                    continue;
                }

                Console.WriteLine("Başka bir arzunuz var mı? (E/H): ");
            } while (Console.ReadLine().ToUpper() == "E");
        }

        private void SatisMeyve()
        {
            Console.WriteLine("Halden alınan meyveler:");
            foreach (var item in halUrunleri)
            {
                if (item.Key == "Elma" || item.Key == "Muz" || item.Key == "Portakal" || item.Key == "Armut" || item.Key == "Çilek")
                {
                    Console.WriteLine($"- {item.Key}: {item.Value} kg");
                }
            }

            Console.Write("Hangi meyveyi satmak istiyorsunuz? ");
            string secim = Console.ReadLine();

            Console.Write("Kaç kilo satmak istiyorsunuz? ");
            double kilo = Convert.ToDouble(Console.ReadLine());

            if (halUrunleri.ContainsKey(secim) && halUrunleri[secim] >= kilo)
            {
                halUrunleri[secim] -= kilo;
                if (satisUrunleri.ContainsKey(secim))
                {
                    satisUrunleri[secim] += kilo; 
                }
                else
                {
                    satisUrunleri[secim] = kilo; 
                }
                Console.WriteLine($"{kilo} kg {secim} satıldı.");
            }
            else
            {
                Console.WriteLine("Yeterli stok yok veya geçersiz seçim.");
            }
        }

        private void SatisSebze()
        {
            Console.WriteLine("Halden alınan sebzeler:");
            foreach (var item in halUrunleri)
            {
                if (item.Key == "Domates" || item.Key == "Salatalık" || item.Key == "Biber" || item.Key == "Havuç" || item.Key == "Patates")
                {
                    Console.WriteLine($"- {item.Key}: {item.Value} kg");
                }
            }

            Console.Write("Hangi sebzeyi satmak istiyorsunuz? ");
            string secim = Console.ReadLine();

            Console.Write("Kaç kilo satmak istiyorsunuz? ");
            double kilo = Convert.ToDouble(Console.ReadLine());

            if (halUrunleri.ContainsKey(secim) && halUrunleri[secim] >= kilo)
            {
                halUrunleri[secim] -= kilo;
                if (satisUrunleri.ContainsKey(secim))
                {
                    satisUrunleri[secim] += kilo; 
                }
                else
                {
                    satisUrunleri[secim] = kilo; 
                }
                Console.WriteLine($"{kilo} kg {secim} satıldı.");
            }
            else
            {
                Console.WriteLine("Yeterli stok yok veya geçersiz seçim.");
            }
        }
    }
}
