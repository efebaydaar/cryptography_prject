using System;

namespace kriptolojisifreleme.Algoritmalar
{
    public class Dogrusal
    {
        private static readonly string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";

        public static string Sifrele(string metin, int a, int b)
        {
            if (GCD(a, 29) != 1)
                throw new ArgumentException("a ile 29 aralarında asal olmalıdır.");

            // Baş ve sondaki boşlukları kaldır, iç boşlukları sil, sonra küçült
            metin = metin.Trim().Replace(" ", "").ToLower();
            string sonuc = "";

            foreach (char harf in metin)
            {
                int index = alfabe.IndexOf(harf);
                if (index != -1)
                {
                    int yeniIndex = (a * index + b) % 29;
                    sonuc += alfabe[yeniIndex];
                }
                else
                {
                    sonuc += harf;
                }
            }

            return sonuc;
        }

        private static int GCD(int a, int b)
        {
            while (b != 0)
            {
                int temp = b;
                b = a % b;
                a = temp;
            }
            return a;
        }
    }
}
