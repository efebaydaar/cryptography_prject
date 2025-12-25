using System.Text;

public static class YerdegistirmeSayiAnahtarlı
{
    /// <summary>
    /// Sayı anahtarlı dikey transpozisyon:
    /// metni k sütunlu bir ızgaraya satır satır yazar,
    /// sonra sütun sütun, kalan harfleri (pad yok) okur.
    /// </summary>
    public static string Sifrele(string metin, int k)
    {
        if (k < 1)
            throw new ArgumentException("Anahtar (sütun sayısı) en az 1 olmalı.");

        // 1) Temizle
        metin = metin.Trim()
                     .Replace(" ", "")
                     .ToLower();

        int len = metin.Length;
        int cols = k;
        int rows = (len + cols - 1) / cols;  // yukarı yuvarla

        var sb = new StringBuilder();

        // Her sütun için
        for (int c = 0; c < cols; c++)
        {
            // her satır için
            for (int r = 0; r < rows; r++)
            {
                int idx = r * cols + c;
                if (idx < len)
                {
                    sb.Append(metin[idx]);
                }
            }
        }

        return sb.ToString();
    }
}
