using System;

namespace OgrenciLinkedList
{
    class Node
    {
        public string Ad;
        public string Soyad;
        public int Numara;
        public Node Next;

        public Node(string ad, string soyad, int numara)
        {
            Ad = ad;
            Soyad = soyad;
            Numara = numara;
            Next = null;
        }
    }

    class LinkedList
    {
        Node head;

        // Baştan ekleme
        public void BasaEkle(string ad, string soyad, int numara)
        {
            Node yeni = new Node(ad, soyad, numara);
            yeni.Next = head;
            head = yeni;
        }

        // Sona ekleme
        public void SonaEkle(string ad, string soyad, int numara)
        {
            Node yeni = new Node(ad, soyad, numara);

            if (head == null)
            {
                head = yeni;
                return;
            }

            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = yeni;
        }

        // Belirtilen numaradan sonra ekleme
        public void SonrasinaEkle(int numara, string ad, string soyad, int yeniNo)
        {
            Node temp = head;
            while (temp != null && temp.Numara != numara)
            {
                temp = temp.Next;
            }

            if (temp == null)
            {
                Console.WriteLine("Numara bulunamadı.");
                return;
            }

            Node yeni = new Node(ad, soyad, yeniNo);
            yeni.Next = temp.Next;
            temp.Next = yeni;
        }

        // Belirtilen numaradan önce ekleme
        public void OncesineEkle(int numara, string ad, string soyad, int yeniNo)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            if (head.Numara == numara)
            {
                BasaEkle(ad, soyad, yeniNo);
                return;
            }

            Node temp = head;
            while (temp.Next != null && temp.Next.Numara != numara)
            {
                temp = temp.Next;
            }

            if (temp.Next == null)
            {
                Console.WriteLine("Numara bulunamadı.");
                return;
            }

            Node yeni = new Node(ad, soyad, yeniNo);
            yeni.Next = temp.Next;
            temp.Next = yeni;
        }

        // Baştan silme
        public void BastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }
            head = head.Next;
        }

        // Sondan silme
        public void SondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            if (head.Next == null)
            {
                head = null;
                return;
            }

            Node temp = head;
            while (temp.Next.Next != null)
            {
                temp = temp.Next;
            }
            temp.Next = null;
        }

        // Belirli numarayı silme
        public void Sil(int numara)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            if (head.Numara == numara)
            {
                head = head.Next;
                return;
            }

            Node temp = head;
            while (temp.Next != null && temp.Next.Numara != numara)
            {
                temp = temp.Next;
            }

            if (temp.Next == null)
            {
                Console.WriteLine("Numara bulunamadı.");
                return;
            }

            temp.Next = temp.Next.Next;
        }

        // Arama
        public void Ara(int numara)
        {
            Node temp = head;
            while (temp != null)
            {
                if (temp.Numara == numara)
                {
                    Console.WriteLine($"Bulundu: {temp.Ad} {temp.Soyad} ({temp.Numara})");
                    return;
                }
                temp = temp.Next;
            }
            Console.WriteLine("Öğrenci bulunamadı.");
        }

        // Listeleme
        public void Listele()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.Numara} - {temp.Ad} {temp.Soyad}");
                temp = temp.Next;
            }
        }

        // Kullanıcıdan veri alıp ekleme
        public void KullaniciEkle()
        {
            Console.Write("Ad: ");
            string ad = Console.ReadLine();
            Console.Write("Soyad: ");
            string soyad = Console.ReadLine();
            Console.Write("Numara: ");
            int numara = int.Parse(Console.ReadLine());

            SonaEkle(ad, soyad, numara);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            LinkedList liste = new LinkedList();

            liste.SonaEkle("Ahmet", "Yılmaz", 101);
            liste.SonaEkle("Elif", "Demir", 102);
            liste.BasaEkle("Mert", "Kaya", 100);

            Console.WriteLine("\n--- Öğrenciler ---");
            liste.Listele();

            Console.WriteLine("\n102 numaradan sonra Ayşe ekleniyor...");
            liste.SonrasinaEkle(102, "Ayşe", "Kara", 103);
            liste.Listele();

            Console.WriteLine("\n102 numarası siliniyor...");
            liste.Sil(102);
            liste.Listele();

            Console.WriteLine("\nKullanıcıdan öğrenci ekleme:");
            liste.KullaniciEkle();
            liste.Listele();

            Console.WriteLine("\nAramak istediğiniz numarayı girin:");
            int n = int.Parse(Console.ReadLine());
            liste.Ara(n);
        }
    }
}