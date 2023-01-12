using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS_130
{
    class Node
    {
        public string namaObat, dssObat, hargaObat;
        public int idObat;
        public Node next;
        public Node prev;

    }
    class Program
    {
        Node START;
        public Program()
        {
            START = null;
        }
        public bool Search(string dssObat, ref Node previous, ref Node current)
        {
            for (previous = current = START; current != null &&
                dssObat != current.dssObat; previous = current,
                current = current.next)
            { }
            return (current != null);
        }
        public bool listEmpty()
        {
            if (START == null)
                return true;
            else
                return false;
        }
        public void traverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData kosong!");
            else
            {
                Console.WriteLine("\nData Obat yang tersedia adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode != null; currentNode = currentNode.next)
                    Console.Write(currentNode.idObat + " " + currentNode.namaObat + " " + currentNode.dssObat + " " + currentNode.hargaObat + "\n");
            }
        }
        public void revtraverse()
        {
            if (listEmpty())
                Console.WriteLine("\nData Obat kosong");
            else
            {
                Console.WriteLine("\nData Obat dari urutan terbawah " + "adalah:\n");
                Node currentNode;
                for (currentNode = START; currentNode.next != null; currentNode = currentNode.next)
                { }
                while (currentNode != null)
                {
                    Console.Write(currentNode.idObat + " " + currentNode.namaObat + " " + currentNode.dssObat + " " + currentNode.hargaObat + "\n");
                    currentNode = currentNode.prev;
                }
            }
        }
        public void addobat()
        {
            Console.Write("\nMasukkan id obat: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nMasukkan nama Obat: ");
            string nama = Console.ReadLine();
            Console.Write("\nMasukkan dosis Obat: ");
            string dosis = Console.ReadLine();
            Console.Write("\nMasukkan harga Obat: ");
            string harga = Console.ReadLine();

            Node newnode = new Node();
            newnode.idObat = id;
            newnode.namaObat = nama;
            newnode.hargaObat = harga;
            newnode.dssObat = dosis;


            if (START == null || id == START.idObat)
            {
                if ((START != null) && (id == START.idObat))
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
                newnode.next = START;
                if (START != null)
                    START.prev = newnode;
                newnode.prev = null;
                START = newnode;
                return;
            }
            Node previous, current;
            for (current = previous = START; current != null &&
                id != current.idObat; previous = current, current =
                current.next)
            {
                if (id == current.idObat)
                {
                    Console.WriteLine("\nData duplikat tidak diperbolehkan");
                    return;
                }
            }

            newnode.next = current;
            newnode.prev = previous;

            if (current == null)
            {
                newnode.next = null;
                previous.next = newnode;
                return;
            }
            current.prev = newnode;
            previous.next = newnode;
        }
        public bool delObat(string dssObat)
        {
            Node previous, current;
            previous = current = null;
            if (Search(dssObat, ref previous, ref current) == false)
                return false;
            if (current == START)
            {
                START = START.next;
                if (START != null)
                    START.prev = null;
                return true;

            }
            if (current.next == null)
            {
                previous.next = null;
                return true;
            }
            previous.next = current.next;
            current.next.prev = previous;
            return true;
        }
        static void Main(string[] args)
        {
            Program p = new Program();
            while (true)
            {
                try
                {
                    Console.WriteLine("\n Menu Apotek" +
                        "\n 1. Menampilkan semua data Obat" +
                        "\n 2. Mencari sebuah data Obat" +
                        "\n 3. Menampilkan data dari urutan terbawah" +
                        "\n 4. Menambah data Obat" +
                        "\n 5. Menghapus data Obat" +
                        "\n 6. Keluar" +

                        "\n Masukkan pilihan anda (1 - 6): "
                        );
                    char ch = Convert.ToChar(Console.ReadLine());
                    switch (ch)
                    {
                        case '1':
                            {
                                p.traverse();
                            }
                            break;
                        case '2':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData kosong!");
                                    break;
                                }
                                Node prev, curr;
                                prev = curr = null;
                                Console.Write("Masukkan dosis Obat yang ingin dicari: ");
                                string dssObat = Console.ReadLine();
                                if (p.Search(dssObat, ref prev, ref curr) == false)
                                    Console.WriteLine("\nData tidak ditemukan");
                                else
                                {
                                    Console.WriteLine("\nData ditemukan!");
                                    Console.WriteLine("\nID Obat " + curr.idObat);
                                    Console.WriteLine("\nNama Obat " + curr.namaObat);
                                    Console.WriteLine("\nDosis Obat " + curr.dssObat);
                                    Console.WriteLine("\nHarga Obat " + curr.hargaObat);

                                }
                            }
                            break;
                        case '3':
                            {
                                p.revtraverse();
                            }
                            break;
                        case '4':
                            {

                                p.addobat();
                            }
                            break;
                        case '5':
                            {
                                if (p.listEmpty())
                                {
                                    Console.WriteLine("\nData Obat Kosong!");
                                    break;
                                }
                                Console.Write("Masukkan dosis obat dari data" + " yang datanya ingin dihapus: ");
                                string dssObat = Console.ReadLine();
                                Console.WriteLine();
                                if (p.delObat(dssObat) == false)
                                    Console.WriteLine("Data tidak ditemukan!");
                                else
                                    Console.WriteLine("Data Dosis Obat " + dssObat + " telah terhapus \n");
                            }
                            break;
                        case '6':
                            return;
                        default:
                            {
                                Console.WriteLine("\nPilihan salah!");
                            }
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

/*
 * 
2). Algoritma yang saya gunakan adalah DoubleLinked List, karena sesuai dengan studi kasus di atas bahwa data obat yang dikumpulkan
masih belum terurut,algoritma double linked list bisa memasukkan node di Start list,
diantara dua node atau prev dan next node diakhir list, maka mempermudah karyawan apotek dalam
menampilkan, mengurutkan, dan mencari data obat obatan tersebut.

3). Jika array membutuhkan indeks untuk menyimpan data, dan array ini digunakan ketika kita ingin menyimpan banyak data,
sedangkan linked list menyimpan data terstruktur sesuai dengan referensi dari datanya, dan linkedlist digunakan ketika kita akan menstrukturkan
data sesuai referensi data yang kita masukkan.

4). Front & Rear

5). a.  16 dan 53
        46 dan 55
        63 dan 70
        62 dan 64

    b. Inorder = 16 25 41 42 46 53 55 60 62 63 65 74 64 70
 
 */