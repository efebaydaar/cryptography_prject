using System;
using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public class Rota
    {
        /// <summary>
        /// Route cipher: metni cols sütunlu bir matrise satır satır yazar,
        /// sonra sol-alt köşeden başlayarak yukarı, sağa, aşağı, sola… spiral okur.
        /// </summary>
        public static string Sifrele(string metin, int cols)
        {
            if (cols < 1) throw new ArgumentException("Sütun sayısı en az 1 olmalı.");

            // Temizle, küçük harf, boşlukları at
            metin = metin.Trim().Replace(" ", "").ToLower();
            int len = metin.Length;

            // Kaç satır gerekir?
            int rows = (len + cols - 1) / cols;      // ceil(len/cols)
            // Matrisi doldur, eksikleri 'x' ile pad et
            char[,] mat = new char[rows, cols];
            int idx = 0;
            for (int r = 0; r < rows; r++)
                for (int c = 0; c < cols; c++)
                    mat[r, c] = (idx < len ? metin[idx++] : 'x');

            // Spiral okumaya sol-alt köşeden başla
            bool[,] used = new bool[rows, cols];
            int r0 = rows - 1, c0 = 0;
            int[,] dirs = { { -1, 0 }, { 0, 1 }, { 1, 0 }, { 0, -1 } };
            int d = 0;
            var sb = new StringBuilder();

            for (int k = 0; k < rows * cols; k++)
            {
                sb.Append(mat[r0, c0]);
                used[r0, c0] = true;

                int nr = r0 + dirs[d, 0], nc = c0 + dirs[d, 1];
                if (nr < 0 || nr >= rows || nc < 0 || nc >= cols || used[nr, nc])
                {
                    d = (d + 1) % 4;
                    nr = r0 + dirs[d, 0];
                    nc = c0 + dirs[d, 1];
                }
                r0 = nr; c0 = nc;
            }

            return sb.ToString();
        }
    }
}
