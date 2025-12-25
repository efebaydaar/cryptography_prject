using System;
using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public static class Hill
    {
        // 0–28 arası indeks için Türkçe alfabe
        private const string Alfa =
            "abcçdefgğhıijklmnoöprsştuüvyz";

        /// <summary>
        /// Hill Şifreleme: metni 3×3 bloklara bölüp her bloğu
        /// key matrisle çarpar, mod 29 alır ve harfe çevirir.
        /// </summary>
        /// <param name="metin">Düz metin</param>
        /// <param name="key">3×3 tam sayı anahtar matrisi</param>
        /// <returns>Şifreli metin</returns>
        public static string Sifrele(string metin, int[,] key)
        {
            if (key.GetLength(0) != 3 || key.GetLength(1) != 3)
                throw new ArgumentException("Anahtar matrisi must be 3×3.");

            // 1) Temizle: trim, boşlukları at, küçült
            metin = metin.Trim()
                         .Replace(" ", "")
                         .ToLower();

            // 2) Blok boyutu ve alfabe uzunluğu
            const int n = 3;
            int m = Alfa.Length;  // 29

            // 3) Düz metni 3’erli bloklara ayır, eksikleri 'a' ile pad et
            int total = metin.Length;
            int padded = ((total + n - 1) / n) * n;
            var sb = new StringBuilder();

            for (int i = 0; i < padded; i += n)
            {
                // 3.1) Bloğu sayılara dönüştür
                int[] v = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (i + j < total)
                    {
                        int idx = Alfa.IndexOf(metin[i + j]);
                        if (idx < 0) throw new ArgumentException($"Bilinmeyen karakter: {metin[i + j]}");
                        v[j] = idx;
                    }
                    else
                    {
                        v[j] = 0;  // pad='a'
                    }
                }

                // 3.2) key × v çarpımı, mod m
                for (int row = 0; row < n; row++)
                {
                    long sum = 0;
                    for (int col = 0; col < n; col++)
                        sum += (long)key[row, col] * v[col];
                    int mod = (int)((sum % m + m) % m);
                    sb.Append(Alfa[mod]);
                }
            }

            return sb.ToString();
        }
    }
}
