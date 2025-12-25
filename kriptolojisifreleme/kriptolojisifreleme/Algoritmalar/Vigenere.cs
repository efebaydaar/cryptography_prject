using System;
using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public class Vigenere
    {
        private static readonly string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";

        /// <summary>
        /// Vigenère cipher: metni, anahtar kelimenin harflerince belirlenen kaydırmalarla şifreler.
        /// </summary>
        /// <param name="metin">Şifrelenecek metin</param>
        /// <param name="key">Anahtar kelime (harf dizisi)</param>
        /// <returns>Şifreli metin</returns>
        public static string Sifrele(string metin, string key)
        {
            // Baş/son boşluk at, iç boşlukları kaldır, küçük harfe çevir
            metin = metin.Trim().Replace(" ", "").ToLower();
            key = key.Trim().ToLower();
            if (key.Length == 0)
                throw new ArgumentException("Anahtar kelime boş olamaz.");

            var sb = new StringBuilder();
            int keyLen = key.Length;

            for (int i = 0; i < metin.Length; i++)
            {
                char m = metin[i];
                int mi = alfabe.IndexOf(m);
                if (mi == -1)
                {
                    // Alfabe dışı karakterleri olduğu gibi ekle
                    sb.Append(m);
                }
                else
                {
                    char k = key[i % keyLen];
                    int ki = alfabe.IndexOf(k);
                    if (ki == -1)
                        throw new ArgumentException($"Anahtar içinde geçersiz harf: {k}");

                    int yi = (mi + ki) % alfabe.Length;
                    sb.Append(alfabe[yi]);
                }
            }

            return sb.ToString();
        }
    }
}
