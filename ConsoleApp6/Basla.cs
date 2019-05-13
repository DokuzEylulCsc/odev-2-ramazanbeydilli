using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Basla
    {

        Universite uni = new Universite("Yeni Universite");
        List<Fakulte> fakultes = new List<Fakulte>(); 
        List<OgretimElemanlari> ogretimElemanlaris = new List<OgretimElemanlari>();
        List<Ogrenci> ogrencis = new List<Ogrenci>();


        public void Baslat()
        {
            while (true)
            {

                int key;
            AnaMenu:
                Console.Clear();
                Console.WriteLine("Ekleme Islemleri - 1");
                Console.WriteLine("Cikis - 2");
                try
                {
                    key = int.Parse(Console.ReadLine());

                    switch (key)
                    {
                        case 1:
                            goto EkleCikar;
                        case 2:
                            goto Kaydet;
                        case 3:
                            goto bitir;
                        default:
                            Console.WriteLine("Yanlış giriş yaptınız. Yeniden deneyin.");
                            Console.ReadKey();
                            goto AnaMenu;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                }

                catch (Exception exception)
                {
                    Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                }
            Kaydet:
                {
                    try
                    {
                        FileStream ds = new FileStream(@"dosya.txt", FileMode.OpenOrCreate, FileAccess.Write);
                        StreamWriter st = new StreamWriter(ds);
                        if (fakultes.Count > 0)
                        {
                            for (int i = 0; i < fakultes.Count; i++)
                            {
                                Console.WriteLine(i + 1 + "." + fakultes[i].isim);
                            }
                            Console.WriteLine("Sectiginiz fakulte numarasini girin");
                            int secim = int.Parse(Console.ReadLine());
                            while (secim <= 0 && secim > fakultes.Count)
                            {
                                Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                secim = int.Parse(Console.ReadLine());
                            }

                            if (fakultes[secim - 1].bolums.Count > 0)
                            {
                                for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                {
                                    Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[i].isim);
                                }
                                Console.WriteLine("Sectiginiz bolum numarasini girin");
                                int secim2 = int.Parse(Console.ReadLine());
                                while (secim2 <= 0 && secim2 > fakultes[secim - 1].bolums.Count)
                                {
                                    Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                    secim2 = int.Parse(Console.ReadLine());
                                }
                                if (fakultes[secim - 1].bolums[secim2 - 1].derses.Count > 0)
                                {
                                    for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].derses.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[secim2 - 1].derses[i].isim);
                                    }
                                    Console.WriteLine("Sectiginiz ders numarasini girin");
                                    int secim3 = int.Parse(Console.ReadLine());
                                    while (secim3 <= 0 && secim3 > fakultes[secim - 1].bolums[secim2 - 1].derses.Count)
                                    {
                                        Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                        secim3 = int.Parse(Console.ReadLine());
                                    }
                                    if (fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].eleman != null)
                                    {
                                        st.WriteLine("Dersin ogretim elemani :" + fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].eleman.ogretimadi);
                                    }
                                    else
                                    {
                                        st.WriteLine("Dersin ogretim elemanı yok");
                                    }
                                    if (fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].subesi.Count > 0)
                                    {
                                        st.Write("Dersin şubeleri : ");
                                        for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].subesi.Count; i++)
                                        {
                                            st.Write(fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].subesi[i].isim + ", ");
                                        }
                                        st.WriteLine();
                                    }
                                    else st.WriteLine("dersin şubesi yok");
                                    if (fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].ogrencis.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].ogrencis.Count; i++)
                                        {
                                            st.WriteLine(fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].ogrencis[i].ogradi);
                                        }
                                    }
                                    else st.WriteLine("Ogrenci yok");
                                    st.Flush();
                                    st.Close();
                                    ds.Close();
                                }
                                else
                                {
                                    Console.WriteLine("Ders eklemeyi unuttunuz ;)");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Bolum eklemeyi unuttunuz ;)");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Fakulte eklemeyi unuttunuz ;)");
                        }
                    }
                    catch (FormatException e)
                    {
                        Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                    }

                    catch (Exception exception)
                    {
                        Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                    }
                    Console.ReadKey();
                    goto AnaMenu;
                }
            EkleCikar:
                Console.WriteLine("Fakulte Ekle - 1");
                Console.WriteLine("Bolum Ekle - 2");
                Console.WriteLine("Ders Ekle - 3");
                Console.WriteLine("Şube Ekle - 4");
                Console.WriteLine("Öğrenci Ekle - 5");
                Console.WriteLine("Derse Ogrenci Ekle - 6");
                Console.WriteLine("Öğretim Elemanı Ekle - 7");
                Console.WriteLine("Öğretim Elemanını Derse Ekle - 8");

                Console.WriteLine("Ana Menü - 0");

                try
                {
                    key = int.Parse(Console.ReadLine());
                    switch (key)
                    {

                        case 1:
                            Console.WriteLine("Eklenecek fakülte adini girin");
                            string fadi = Console.ReadLine();
                            fakultes.Add(new Fakulte(fadi, uni));
                            goto AnaMenu;
                        case 2:
                            try
                            {
                                if (fakultes.Count > 0)
                                {
                                    for (int i = 0; i < fakultes.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + ". " + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Secilecek fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());

                                    while (secim >= fakultes.Count && secim < 0)
                                    {
                                        Console.WriteLine("yanlis giris yaptiniz yeniden deneyin");
                                        secim = int.Parse(Console.ReadLine());
                                    }
                                    Console.WriteLine("Eklenecek bölüm adini girin");
                                    string bolumadi = Console.ReadLine();
                                    fakultes[secim - 1].bolums.Add(new Bolum(bolumadi, fakultes[secim - 1]));
                                }
                                else
                                {
                                    Console.WriteLine("Herhangi bir fakülte yok, lütfen önce fakülte ekleyiniz");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 3:
                            try
                            {
                                if (fakultes.Count > 0)
                                {
                                    for (int i = 0; i < fakultes.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + ". " + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Secilecek fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());
                                    while (secim > fakultes.Count && secim <= 0)
                                    {
                                        Console.WriteLine("yanlis giris yaptiniz yeniden deneyin");
                                        secim = int.Parse(Console.ReadLine());
                                    }
                                    if (fakultes[secim - 1].bolums.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + ". " + fakultes[secim - 1].bolums[i].isim);
                                        }
                                        Console.WriteLine("Secilen bolum numarasini girin");
                                        int secim2 = int.Parse(Console.ReadLine());
                                        while (secim2 <= 0 && secim2 >= fakultes[secim - 1].bolums.Count)
                                        {
                                            Console.WriteLine("yanlis giris yaptiniz yeniden deneyin");
                                            secim2 = int.Parse(Console.ReadLine());
                                        }
                                        Console.WriteLine("Eklenecek ders adini girin");
                                        string dersadi = Console.ReadLine();
                                        Console.WriteLine("Eklenecek dersin donemini giriniz");
                                        int donemno = int.Parse(Console.ReadLine());
                                        fakultes[secim - 1].bolums[secim2 - 1].derses.Add(new Ders(dersadi, fakultes[secim - 1].bolums[secim2 - 1], donemno));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Herhangi bir bölüm yok, lütfen önce bölüm ekleyiniz");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Herhangi bir fakülte yok, lütfen önce fakülte ekleyiniz");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 4:
                            try
                            {
                                if (fakultes.Count > 0)
                                {
                                    for (int i = 0; i < fakultes.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + "." + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Sectiginiz fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());
                                    while (secim >= fakultes.Count && secim < 0)
                                    {
                                        Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                        secim = int.Parse(Console.ReadLine());
                                    }

                                    if (fakultes[secim - 1].bolums.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[i].isim);
                                        }
                                        Console.WriteLine("Sectiginiz bolum numarasini girin");
                                        int secim2 = int.Parse(Console.ReadLine());
                                        while (secim2 <= 0 && secim2 > fakultes[secim - 1].bolums.Count)
                                        {
                                            Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                            secim2 = int.Parse(Console.ReadLine());
                                        }
                                        if (fakultes[secim - 1].bolums[secim2 - 1].derses.Count > 0)
                                        {
                                            for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].derses.Count; i++)
                                            {
                                                Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[secim2 - 1].derses[i].isim);
                                            }
                                            Console.WriteLine("Sectiginiz ders numarasini girin");
                                            int secim3 = int.Parse(Console.ReadLine());
                                            while (secim3 <= 0 && secim3 > fakultes[secim - 1].bolums[secim2 - 1].derses.Count)
                                            {
                                                Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                                secim3 = int.Parse(Console.ReadLine());
                                            }
                                            Console.WriteLine("Sube numarasini giriniz");
                                            string subeno = Console.ReadLine();
                                            fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].subesi.Add(new Sube(subeno, fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1]));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ders eklemeyi unuttunuz ;)");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bolum eklemeyi unuttunuz ;)");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Fakulte eklemeyi unuttunuz ;)");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 5:
                            try
                            {
                                if (fakultes.Count > 0) //ekli fakülte varsa
                                {
                                    for (int i = 0; i < fakultes.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + "." + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Sectiginiz fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());
                                    while (secim >= fakultes.Count && secim < 0)
                                    {
                                        Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                        secim = int.Parse(Console.ReadLine());
                                    }

                                    if (fakultes[secim - 1].bolums.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[i].isim);
                                        }
                                        Console.WriteLine("Sectiginiz bolum numarasini girin");
                                        int secim2 = int.Parse(Console.ReadLine());
                                        while (secim2 <= 0 && secim2 > fakultes[secim - 1].bolums.Count)
                                        {
                                            Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                            secim2 = int.Parse(Console.ReadLine());
                                        }
                                        Console.WriteLine("Lisans (1), Yuksek Lisans(2), Doktora(3)");
                                        int tercih = int.Parse(Console.ReadLine());
                                        while (tercih < 1 && tercih > 3)
                                        {
                                            Console.WriteLine("Hatali islem yaptiniz, tekrar deneyin");
                                            tercih = int.Parse(Console.ReadLine());
                                        }
                                        if (tercih == 1)
                                        {

                                            Console.WriteLine("Ogrenci numarasini girin");
                                            int ogrno = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Ogrenci adini girin");
                                            string ograd = Console.ReadLine();
                                            ogrencis.Add(new Lisans(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                            fakultes[secim - 1].bolums[secim2 - 1].ogrencis.Add(new Lisans(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                            fakultes[secim - 1].ogrencis.Add(new Lisans(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                        }
                                        else if (tercih == 2)
                                        {
                                            Console.WriteLine("Ogrenci numarasini girin");
                                            int ogrno = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Ogrenci adini girin{");
                                            string ograd = Console.ReadLine();
                                            ogrencis.Add(new YuksekLisans(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                            fakultes[secim - 1].bolums[secim2 - 1].ogrencis.Add(new YuksekLisans(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                            fakultes[secim - 1].ogrencis.Add(new YuksekLisans(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                        }
                                        else
                                        {
                                            Console.WriteLine("Ogrenci numarasini girin");
                                            int ogrno = int.Parse(Console.ReadLine());
                                            Console.WriteLine("Ogrenci adini girin{");
                                            string ograd = Console.ReadLine();
                                            ogrencis.Add(new Doktora(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                            fakultes[secim - 1].bolums[secim2 - 1].ogrencis.Add(new Doktora(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                            fakultes[secim - 1].ogrencis.Add(new Doktora(ogrno, ograd, fakultes[secim - 1].bolums[secim2 - 1]));
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bolum eklemeyi unuttunuz ;)");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Fakulte eklemeyi unuttunuz ;)");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 6:
                            try
                            {
                                if (fakultes.Count > 0) //ekli fakülte varsa
                                {
                                    for (int i = 0; i < fakultes.Count; i++) 
                                    {
                                        Console.WriteLine(i + 1 + "." + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Sectiginiz fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());
                                    while (secim >= fakultes.Count && secim < 0)
                                    {
                                        Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                        secim = int.Parse(Console.ReadLine());
                                    }
                                    if (fakultes[secim - 1].bolums.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[i].isim);
                                        }
                                        Console.WriteLine("Sectiginiz bolum numarasini girin");
                                        int secim2 = int.Parse(Console.ReadLine());
                                        while (secim2 <= 0 && secim2 > fakultes[secim - 1].bolums.Count)
                                        {
                                            Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                            secim2 = int.Parse(Console.ReadLine());
                                        }
                                        if (fakultes[secim - 1].bolums[secim2 - 1].ogrencis.Count > 0)
                                        {
                                            for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].ogrencis.Count; i++)
                                            {
                                                Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[secim2 - 1].ogrencis[i].ogradi + "\t Bölümü : " + fakultes[secim - 1].bolums[secim2 - 1].ogrencis[i].bolumadi);
                                            }
                                            Console.WriteLine("Sectiginiz ogrencinin indisi");
                                            int tercih2 = int.Parse(Console.ReadLine());
                                            while (tercih2 <= 0 && tercih2 > fakultes[secim - 1].bolums[secim2 - 1].ogrencis.Count)
                                            {
                                                Console.WriteLine("Hatali islem yaptiniz, tekrar girin");
                                                tercih2 = int.Parse(Console.ReadLine());
                                            }
                                            if (fakultes[secim - 1].bolums[secim2 - 1].derses.Count > 0)
                                            {
                                                for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].derses.Count; i++)
                                                {
                                                    Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[secim2 - 1].derses[i].isim);
                                                }
                                                Console.WriteLine("Sectiginiz ders numarasini girin");
                                                int secim3 = int.Parse(Console.ReadLine());
                                                while (secim3 <= 0 && secim3 > fakultes[secim - 1].bolums[secim2 - 1].derses.Count)
                                                {
                                                    Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                                    secim3 = int.Parse(Console.ReadLine());
                                                }
                                                fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].ogrencis.Add(fakultes[secim - 1].bolums[secim2 - 1].ogrencis[tercih2 - 1]);
                                            }
                                            else
                                            {
                                                Console.WriteLine("Ders eklemeyi unuttunuz ;)");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Bolume kayitli ogrenci yok.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bolum eklemeyi unuttunuz ;)");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Fakulte eklemeyi unuttunuz ;)");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 7:
                            try
                            {
                                if (fakultes.Count > 0)
                                {
                                    for (int i = 0; i < fakultes.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + "." + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Sectiginiz fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());
                                    while (secim >= fakultes.Count && secim < 0)
                                    {
                                        Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                        secim = int.Parse(Console.ReadLine());
                                    }
                                    if (fakultes[secim - 1].bolums.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[i].isim);
                                        }
                                        Console.WriteLine("Sectiginiz bolum numarasini girin");
                                        int secim2 = int.Parse(Console.ReadLine());
                                        while (secim2 <= 0 && secim2 > fakultes[secim - 1].bolums.Count)
                                        {
                                            Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                            secim2 = int.Parse(Console.ReadLine());
                                        }
                                        Console.WriteLine("Ogretim elemani adini girin");
                                        string ogretimadi = Console.ReadLine();
                                        ogretimElemanlaris.Add(new OgretimElemanlari(ogretimadi, fakultes[secim - 1].bolums[secim2 - 1]));
                                        fakultes[secim - 1].bolums[secim2 - 1].ogretimElemanlaris.Add(new OgretimElemanlari(ogretimadi, fakultes[secim - 1].bolums[secim2 - 1]));
                                        fakultes[secim - 1].ogretimElemanlaris.Add(new OgretimElemanlari(ogretimadi, fakultes[secim - 1].bolums[secim2 - 1]));
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bolum eklemeyi unuttunuz ;)");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Fakulte eklemeyi unuttunuz ;)");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 8:
                            try
                            {
                                if (fakultes.Count > 0) //ekli fakülte varsa
                                {
                                    for (int i = 0; i < fakultes.Count; i++)
                                    {
                                        Console.WriteLine(i + 1 + "." + fakultes[i].isim);
                                    }
                                    Console.WriteLine("Sectiginiz fakulte numarasini girin");
                                    int secim = int.Parse(Console.ReadLine());
                                    while (secim >= fakultes.Count && secim < 0)
                                    {
                                        Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                        secim = int.Parse(Console.ReadLine());
                                    }
                                    if (fakultes[secim - 1].bolums.Count > 0)
                                    {
                                        for (int i = 0; i < fakultes[secim - 1].bolums.Count; i++)
                                        {
                                            Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[i].isim);
                                        }
                                        Console.WriteLine("Sectiginiz bolum numarasini girin");
                                        int secim2 = int.Parse(Console.ReadLine());
                                        while (secim2 <= 0 && secim2 > fakultes[secim - 1].bolums.Count) 
                                        {
                                            Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                            secim2 = int.Parse(Console.ReadLine());
                                        }
                                        if (fakultes[secim - 1].bolums[secim2 - 1].ogretimElemanlaris.Count > 0)
                                        {
                                            for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].ogretimElemanlaris.Count; i++)
                                            {
                                                Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[secim2 - 1].ogretimElemanlaris[i].ogretimadi + "\t Bölümü : " + fakultes[secim - 1].bolums[secim2 - 1].ogrencis[i].bolumadi);
                                            }
                                            Console.WriteLine("Sectiginiz ogretim elemanının indisi");
                                            int tercih2 = int.Parse(Console.ReadLine());
                                            while (tercih2 <= 0 && tercih2 > fakultes[secim - 1].bolums[secim2 - 1].ogretimElemanlaris.Count)
                                            {
                                                Console.WriteLine("Hatali islem yaptiniz, tekrar girin");
                                                tercih2 = int.Parse(Console.ReadLine());
                                            }
                                            if (fakultes[secim - 1].bolums[secim2 - 1].derses.Count > 0)
                                            {
                                                for (int i = 0; i < fakultes[secim - 1].bolums[secim2 - 1].derses.Count; i++)
                                                {
                                                    Console.WriteLine(i + 1 + "." + fakultes[secim - 1].bolums[secim2 - 1].derses[i].isim);
                                                }
                                                Console.WriteLine("Sectiginiz ders numarasini girin");
                                                int secim3 = int.Parse(Console.ReadLine());
                                                while (secim3 <= 0 && secim3 > fakultes[secim - 1].bolums[secim2 - 1].derses.Count)
                                                {
                                                    Console.WriteLine("Hatali giris yaptiniz, tekrar girin");
                                                    secim3 = int.Parse(Console.ReadLine());
                                                }
                                                fakultes[secim - 1].bolums[secim2 - 1].derses[secim3 - 1].eleman = fakultes[secim - 1].bolums[secim2 - 1].ogretimElemanlaris[tercih2 - 1];
                                            }
                                            else
                                            {
                                                Console.WriteLine("Ders eklemeyi unuttunuz ;)");
                                            }
                                        }
                                        else
                                        {
                                            Console.WriteLine("Bolume kayitli ogrenci yok.");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Bolum eklemeyi unuttunuz ;)");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Fakulte eklemeyi unuttunuz ;)");
                                }
                            }
                            catch (FormatException e)
                            {
                                Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                            }

                            catch (Exception exception)
                            {
                                Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                            }
                            Console.ReadKey();
                            goto AnaMenu;
                        case 0:
                            goto AnaMenu;
                        default:
                            Console.WriteLine("Yanlış giriş yaptınız!");
                            goto EkleCikar;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("Hata! Sadece sayı girilebilir. Hata Mesajı:{0}", e.Message);
                }

                catch (Exception exception)
                {
                    Console.WriteLine("Beklenmedik bir hata oluştu. Hata Mesajı:{0}", exception.Message);
                }
            }
        bitir:
            Console.WriteLine("Bitti");
        }
    }
}