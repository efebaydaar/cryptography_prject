using System;
using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public class Zigzag
    {
        public static string Sifrele(string metin, int numRails)
        {
            if (numRails < 2)
                throw new ArgumentException("Rail sayısı en az 2 olmalı.");

            // Baş/son boşlukları at, iç boşlukları sil, küçük harfe çevir
            metin = metin.Trim().Replace(" ", "").ToLower();

            // Her rail için bir StringBuilder
            var rails = new StringBuilder[numRails];
            for (int i = 0; i < numRails; i++)
                rails[i] = new StringBuilder();

            int rail = 0;
            int direction = +1;   // +1: aşağı, –1: yukarı

            foreach (char c in metin)
            {
                rails[rail].Append(c);

                rail += direction;
                if (rail == numRails)
                {
                    rail = numRails - 2;
                    direction = -1;
                }
                else if (rail < 0)
                {
                    rail = 1;
                    direction = +1;
                }
            }

            // Tüm rail’leri birleştir
            var sonuc = new StringBuilder();
            foreach (var sb in rails)
                sonuc.Append(sb);
            return sonuc.ToString();
        }
    }
}
