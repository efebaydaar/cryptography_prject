using System.Text;

namespace kriptolojisifreleme.Algoritmalar
{
    public class Permütasyon
    {
        public static string Sifrele(string metin, int[] permutasyon)
        {
            int blokBoyutu = permutasyon.Length;
            metin = metin.Trim().Replace(" ", "").ToLower();
            var sonuc = new StringBuilder();

            for (int i = 0; i < metin.Length; i += blokBoyutu)
            {
                // 1) Bloku al ve eksikleri 'x' ile doldur
                char[] blok = new char[blokBoyutu];
                for (int j = 0; j < blokBoyutu; j++)
                    blok[j] = (i + j < metin.Length) ? metin[i + j] : 'x';

                // 2) Yeni blokta doğru pozisyona yerleştir
                char[] yeniBlok = new char[blokBoyutu];
                for (int j = 0; j < blokBoyutu; j++)
                {
                    int hedefPozisyon = permutasyon[j] - 1;
                    yeniBlok[hedefPozisyon] = blok[j];
                }

                // 3) Sonuca ekle
                for (int j = 0; j < blokBoyutu; j++)
                    sonuc.Append(yeniBlok[j]);
            }

            return sonuc.ToString();
        }

    }
}
