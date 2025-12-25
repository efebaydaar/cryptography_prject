namespace kriptolojisifreleme.Algoritmalar
{
    public class Kaydirmali
    {
        private static readonly string alfabe = "abcçdefgğhıijklmnoöprsştuüvyz";

        public static string Sifrele(string metin, int k)
        {
            // Baş ve sondaki boşlukları kaldır, iç boşlukları sil, sonra küçült
            metin = metin.Trim().Replace(" ", "").ToLower();
            string sonuc = "";

            foreach (char harf in metin)
            {
                int index = alfabe.IndexOf(harf);
                if (index != -1)
                {
                    int yeniIndex = (index + k) % 29;
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
