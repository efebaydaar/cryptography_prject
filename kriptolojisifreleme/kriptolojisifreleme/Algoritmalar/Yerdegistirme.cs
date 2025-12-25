using System;
using System.Collections.Generic;
using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public class Yerdegistirme
    {
        /// <summary>
        /// Substitution cipher: her char'ı plainAlphabet içindeki konumuna bakıp,
        /// aynı indeksteki cipherAlphabet char'ı ile değiştirir.
        /// </summary>
        /// <param name="metin">Şifrelenecek metin</param>
        /// <param name="plainAlphabet">Orijinal alfabe (her karakter bir kez olmalı)</param>
        /// <param name="cipherAlphabet">Şifreli alfabe (aynı uzunlukta, permütasyon)</param>
        /// <returns>Şifrelenmiş metin</returns>
        public static string Sifrele(string metin, string plainAlphabet, string cipherAlphabet)
        {
            // Baş/son boşlukları at, iç boşlukları sil, küçük harfe çevir
            metin = metin.Trim().Replace(" ", "").ToLower();

            if (plainAlphabet.Length != cipherAlphabet.Length)
                throw new ArgumentException("plainAlphabet ile cipherAlphabet aynı uzunlukta olmalı.");

            // Hızlı bakmak için sözlük oluştur
            var map = new Dictionary<char, char>();
            for (int i = 0; i < plainAlphabet.Length; i++)
                map[plainAlphabet[i]] = cipherAlphabet[i];

            var sb = new StringBuilder();
            foreach (char c in metin)
            {
                if (map.ContainsKey(c))
                    sb.Append(map[c]);
                else
                    sb.Append(c);    // harf değilse (noktalama, rakam, vs.) olduğu gibi kalsın
            }

            return sb.ToString();
        }
    }
}
