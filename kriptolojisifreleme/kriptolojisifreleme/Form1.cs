using System;
using System.Windows.Forms;
using kriptolojisifreleme.Algoritmalar;
using System.Linq;

namespace kriptolojisifreleme
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            string metin = txtInput.Text.Trim();
            if (cmbAlgorithm.SelectedItem == null)
            {
                MessageBox.Show("Lütfen bir algoritma seçin.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string secim = cmbAlgorithm.SelectedItem.ToString() ?? "";
            string sonuc = "";

            try
            {
                switch (secim)
                {
                    case "Kaydırmalı":
                        if (!int.TryParse(txtKey.Text, out int k2))
                            throw new ArgumentException("Lütfen geçerli bir sayı girin!");
                        sonuc = Kaydirmali.Sifrele(metin, k2);
                        break;

                    case "Doğrusal":
                        // Anahtarı "a,b" formatında alıyoruz:
                        var parts = txtKey.Text
                                       .Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                        if (parts.Length != 2)
                        {
                            throw new ArgumentException("Lütfen anahtarı \"a,b\" şeklinde girin (örnek: 2,3).");
                        }

                        if (!int.TryParse(parts[0].Trim(), out int a) || !int.TryParse(parts[1].Trim(), out int b))
                        {
                            throw new ArgumentException("Lütfen geçerli sayılar girin.");
                        }

                        // Şifreleme
                        sonuc = Dogrusal.Sifrele(metin, a, b);
                        break;

                    case "Permütasyon":
                        sonuc = Permütasyon.Sifrele(metin, new int[] { 3, 1, 4, 2 });
                        break;

                    case "Yer Değiştirme":
                        string plain = "abcçdefgğhıijklmnoöprsştuüvyz";
                        string cipher = "eürığpankscuymzgdjbtfviölçşho";
                        sonuc = Yerdegistirme.Sifrele(metin, plain, cipher);
                        break;

                    case "Zigzag":
                        if (!int.TryParse(txtKey.Text, out int rails))
                            throw new ArgumentException("Rail sayısı en az 2 olmalı.");
                        sonuc = Zigzag.Sifrele(metin, rails);
                        break;

                    case "Rota":
                        if (!int.TryParse(txtKey.Text, out int cols) || cols < 1)
                            throw new ArgumentException("Lütfen geçerli bir sütun sayısı girin!");
                        sonuc = Rota.Sifrele(metin, cols);
                        break;

                    case "4-Kare":
                        if (!int.TryParse(txtKey.Text, out int k) || k < 1)
                            throw new ArgumentException("Lütfen geçerli bir sütun sayısı girin!");
                        sonuc = Dortkare.Sifrele(metin, k);
                        break;

                    case "Vigenere":
                        string vigKey = txtKey.Text.Trim();
                        if (string.IsNullOrEmpty(vigKey))
                            throw new ArgumentException("Lütfen bir anahtar kelime girin!");
                        sonuc = Vigenere.Sifrele(metin, vigKey);
                        break;

                    case "Hill":
                        // 1) Anahtar metnini oku
                        var toks = txtKey.Text
                                      .Split(new[] { ',', ';', ' ', '\n', '\r' },
                                             StringSplitOptions.RemoveEmptyEntries);
                        if (toks.Length != 9)
                            throw new ArgumentException("Lütfen 9 adet sayı girin, örn: 3,2,5,1,6,10,2,13,3");

                        // 2) 3×3 matrise dönüştür
                        int[,] hillKey = new int[3, 3];
                        for (int i = 0; i < 9; i++)
                            hillKey[i / 3, i % 3] = int.Parse(toks[i]);

                        // 3) Şifrele
                        sonuc = Hill.Sifrele(txtInput.Text, hillKey);
                        break;

                    case "Yer Değiştirme (Sayı Anahtarlı)":
                        if (!int.TryParse(txtKey.Text, out int k3) || k3 < 1)
                            throw new ArgumentException("Lütfen geçerli bir sütun sayısı girin!");
                        sonuc = YerdegistirmeSayiAnahtarlı.Sifrele(txtInput.Text, k3);
                        break;

                    default:
                        throw new ArgumentException("Lütfen bir algoritma seçin.");
                }

                txtOutput.Text = sonuc;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lblInput_Click(object sender, EventArgs e)
        {
        }
    }
}