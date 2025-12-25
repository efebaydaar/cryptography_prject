using System;
using System.Collections.Generic;
using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public static class Dortkare
    {
        // 1) Türkçe alfabe (29 harf)
        private const string PLAIN = "abcçdefgğhıijklmnoöprsştuüvyz";

        // 2) Notlarınızdaki SABİT "sağ-üst" kare (30 hücre: 29 harf + 1 'x')
        private const string TR_KEY =
            "ğftjpm" +  // 1. satır: g f t j p m
            "raüşöz" +  // 2. satır: c a ü i o e
            "olivzc" +  // 3. satır: p r i v z c
            "dngbhy" +  // 4. satır: d n g b h y
            "uçskxe";   // 5. satır: u q s k x e

        // 3) Notlarınızdaki SABİT "sol-alt" kare
        private const string BL_KEY =
            "cöhtkg" +  // 1. satır: c d h t k g
            "ümjfus" +  // 2. satır: ü m j f ü ş
            "eibydo" +  // 3. satır: e i b g d o
            "rxğzşç" +  // 4. satır: r x g z ş ş
            "laepın";   // 5. satır: l a e p n x

        /// <summary>
        /// 4-Kare şifreleme. Metni 2'şer harflik bloklara ayırır, her blok için
        /// notlarınızdaki dört kare ile digraph şifrelemesi yapar.
        /// cols = k = sütun sayısı.
        /// </summary>
        public static string Sifrele(string metin, int cols)
        {
            if (cols < 1 || cols > PLAIN.Length)
                throw new ArgumentException("k 1–29 arasında olmalı.");

            // Metni temizle
            metin = metin.Trim().Replace(" ", "").ToLower();
            int rows = (PLAIN.Length + cols - 1) / cols;

            // Dört kareyi oluştur
            var TL = BuildSquare(PLAIN, rows, cols);  // Sol-üst: Düz alfabe
            var BR = BuildSquare(PLAIN, rows, cols);  // Sağ-alt: Düz alfabe
            var TR = BuildSquare(TR_KEY, rows, cols); // Sağ-üst: Anahtar kare
            var BL = BuildSquare(BL_KEY, rows, cols); // Sol-alt: Anahtar kare

            // Hızlı erişim için harf → (satır,sütun) sözlükleri
            var posTL = BuildMap(TL);
            var posBR = BuildMap(BR);

            var sb = new StringBuilder();
            for (int i = 0; i < metin.Length; i += 2)
            {
                char a = metin[i];
                char b = (i + 1 < metin.Length) ? metin[i + 1] : 'x';

                // İlk harf için sol-üst karedeki konumu bul
                if (!posTL.ContainsKey(a))
                    throw new ArgumentException($"Geçersiz karakter: {a}");
                var (r1, c1) = posTL[a];

                // İkinci harf için sağ-alt karedeki konumu bul
                if (!posBR.ContainsKey(b))
                    throw new ArgumentException($"Geçersiz karakter: {b}");
                var (r2, c2) = posBR[b];

                // Şifreleme: Sağ-üst ve sol-alt karelerden harfleri al
                sb.Append(TR[r1, c2]);
                sb.Append(BL[r2, c1]);
            }

            return sb.ToString();
        }

        /// <summary>
        /// 4-Kare şifre çözme. Şifreli metni 2'şer harflik bloklara ayırır, her blok için
        /// dört kare ile digraph şifre çözmesi yapar.
        /// cols = k = sütun sayısı.
        /// </summary>
        public static string Coz(string sifreliMetin, int cols)
        {
            if (cols < 1 || cols > PLAIN.Length)
                throw new ArgumentException("k 1–29 arasında olmalı.");

            // Metni temizle
            sifreliMetin = sifreliMetin.Trim().Replace(" ", "").ToLower();
            if (sifreliMetin.Length % 2 != 0)
                throw new ArgumentException("Şifreli metin çift uzunlukta olmalı.");

            int rows = (PLAIN.Length + cols - 1) / cols;

            // Dört kareyi oluştur
            var TL = BuildSquare(PLAIN, rows, cols);  // Sol-üst: Düz alfabe
            var BR = BuildSquare(PLAIN, rows, cols);  // Sağ-alt: Düz alfabe
            var TR = BuildSquare(TR_KEY, rows, cols); // Sağ-üst: Anahtar kare
            var BL = BuildSquare(BL_KEY, rows, cols); // Sol-alt: Anahtar kare

            // Hızlı erişim için harf → (satır,sütun) sözlükleri
            var posTR = BuildMap(TR);
            var posBL = BuildMap(BL);

            var sb = new StringBuilder();
            for (int i = 0; i < sifreliMetin.Length; i += 2)
            {
                char a = sifreliMetin[i];
                char b = sifreliMetin[i + 1];

                // İlk harf için sağ-üst karedeki konumu bul
                if (!posTR.ContainsKey(a))
                    throw new ArgumentException($"Geçersiz şifreli karakter: {a}");
                var (r1, c2) = posTR[a];

                // İkinci harf için sol-alt karedeki konumu bul
                if (!posBL.ContainsKey(b))
                    throw new ArgumentException($"Geçersiz şifreli karakter: {b}");
                var (r2, c1) = posBL[b];

                // Çözme: Sol-üst ve sağ-alt karelerden harfleri al
                sb.Append(TL[r1, c1]);
                sb.Append(BR[r2, c2]);
            }

            // Son harfi düzelt: Eğer son harf 'x' ise ve orijinal metin tek sayı uzunluğundaysa
            string result = sb.ToString();
            if (result.EndsWith("x") && sifreliMetin.Length % 2 != 0)
            {
                result = result.Substring(0, result.Length - 1);
            }

            return result;
        }

        // rows×cols matrisi harfleri satır satır doldur, eksikleri 'x' ile pad et
        private static char[,] BuildSquare(string letters, int rows, int cols)
        {
            var M = new char[rows, cols];
            int idx = 0;
            foreach (char c in letters)
            {
                int r = idx / cols, c0 = idx % cols;
                if (r < rows) M[r, c0] = c;
                idx++;
            }
            for (int r = 0; r < rows; r++)
                for (int c0 = 0; c0 < cols; c0++)
                    if (M[r, c0] == '\0') M[r, c0] = 'x';
            return M;
        }

        // Harf → (row,column) sözlüğü oluştur
        private static Dictionary<char, (int, int)> BuildMap(char[,] M)
        {
            var map = new Dictionary<char, (int, int)>();
            for (int r = 0; r < M.GetLength(0); r++)
                for (int c0 = 0; c0 < M.GetLength(1); c0++)
                    map[M[r, c0]] = (r, c0);
            return map;
        }
    }
}
