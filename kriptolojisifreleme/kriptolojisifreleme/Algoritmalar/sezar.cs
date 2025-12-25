namespace kriptolojisifreleme.Algoritmalar
{
    public class Sezar
    {
        private static readonly string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";

        public static string Sifrele(string metin, int anahtar)
        {
            // Baş ve sondaki boşlukları kaldır, sonra küçült
            metin = metin.Trim().ToLower();
            string sonuc = "";

            foreach (char harf in metin)
            {
                int index = alfabe.IndexOf(harf);
                if (index != -1)
                {
                    int yeniIndex = (index + anahtar) % 29;
                    sonuc += alfabe[yeniIndex];
                }
                else
                {
                    sonuc += harf;
                }
            }

            return sonuc;
        }
    }
}
