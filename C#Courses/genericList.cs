namespace generic_list
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<T> class Genel yazımı bu şekilde.
            // T -> burada object türünü ifade eder.
            //System.Collection.Generic import etmezsek çalışmaz.

            //int collection türüne örnek.
            List<int> sayiListesi = new List<int>();
            sayiListesi.Add(23);
            sayiListesi.Add(13);
            sayiListesi.Add(22);

            //string collection türüne örnek.
            List<string> renkListesi = new List<string>();
            renkListesi.Add("kırmızı");
            renkListesi.Add("sarı");
            renkListesi.Add("yeşil");

            //Count için
            Console.WriteLine(renkListesi.Count);
            Console.WriteLine(sayiListesi.Count);

            //foreach ve List.ForEach ile elemanlara erişim
            foreach (var sayi in sayiListesi)
                Console.WriteLine(sayi);
            foreach (var renk in renkListesi)
                Console.WriteLine(renk);    

            sayilListesi.ForEach(sayi=> Console.WriteLine(sayi));
            renklListesi.ForEach(renk=> Console.WriteLine(renk));

            //Listeden eleman çıkarma
            sayilListesi.Remove(4);
            renkListesi.Remove("yeşil");

            //Listeden index ile eleman çıkarma
            sayilListesi.RemoveAt(0);
            renkListesi.RemoveAt(1);

            //Liste içinde aram
            if(sayiListesi.Contains(10))
            {
                Console.WriteLine("10 Liste içerisinde bulundu");
            }

            //Eleman ile indexe erişme
            renkListesi.BinarySearch("sarı");

            //Array'i List'e çevirme
            string[] hayvanlar = {"Kedi", "Köpek", "Kuş"};
            List<string> hayvanListesi = new List<string>(hayvanlar);

            //Listeyi nasıl temizleriz?
            hayvanListesi.Clear();

            //Liste içerisinde nesne tutmak
            List<Kullanicilar> kullaniciListesi = new List<Kullanicilar>();

            Kullanicilar kullanici1 = new Kullanicilar();
            kullanici1.Isim = "Ahmet";
            kullanici1.Soyisim = "Yavuz";
            kullanici1.Yas = 26;

            Kullanicilar kullanici2 = new Kullanicilar();
            kullanici2.Isim = "Özcan";
            kullanici2.Soyisim = "Çalışkan";
            kullanici2.Yas = 26;

            kullaniciListesi.Add(kullanici1);
            kullaniciListesi.Add(kullanici2);

            //Bu kullanıcı listesine farklı olarak atama yöntemi
            List<Kullanicilar> yeniListe = new List<Kullanicilar>();

            yeniListe.Add(new Kullanicilar(){
                Isim="Deniz",
                Soyisim="Arda",
                Yas=18
            });

            foreach (var kullanici in kullaniciListesi)
            {
                Console.WriteLine("Kullanıcı Adı:" + kullanici.Isim);
                Console.WriteLine("Kullanıcı Soyadı:" + kullanici.Soyisim);
                Console.WriteLine("Kullanıcı Yaşı:" + kullanici.Yas);                
            }
            yeniListe.Clear();
        }
    }

    public class Kullanicilar{
        private string isim;
        private string soyisim;
        private int yas;

        public string Isim { get => isim; set => isim = value; }
        public string Soyisim { get => soyisim; set => soyisim = value; }
        public int Yas { get => yas; set => yas = value; }
    }
}