using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BusinessLayer.Abstract;
using EntityLayer.Concrete;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core_Proje.AiPlugins
{
    public class PortfolioInfoPlugin
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioInfoPlugin(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        // 1. YETENEK: Veritabanından Projeleri Listele
        [KernelFunction, Description("Ömer Faruk'un tamamladığı projeleri listeler.")]
        public string GetProjects()
        {
            // Senin kodundaki metod ismi 'TGetList' imiş, onu korudum.
            var values = _portfolioService.TGetList();
            var summary = "--- PROJE LİSTESİ ---\n";
            foreach (var item in values)
            {
                summary += $"Proje: {item.Name}\nRepo: {item.ProjectUrl}\nDetay: {item.ImageUrl}\n---\n";
            }
            return summary;
        }

        // 2. YETENEK: Klasör İçeriğini Listele (Gözcü)
        [KernelFunction, Description("Bir GitHub reposundaki belirli bir klasörün içindeki dosyaları listeler.")]
        public async Task<string> GetFolderContents(
            [Description("Repo adı (Örn: FinancialBankV2)")] string repoName,
            [Description("Klasör yolu (Boş bırakılırsa ana dizini getirir)")] string folderPath = "")
        {
            string username = "Printer3453";
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("FarukBot", "1.0"));

            try
            {
                string treeUrl = $"https://api.github.com/repos/{username}/{repoName}/git/trees/main?recursive=1";

                var response = await client.GetAsync(treeUrl);
                if (!response.IsSuccessStatusCode)
                {
                    treeUrl = treeUrl.Replace("main", "master");
                    response = await client.GetAsync(treeUrl);
                }

                if (!response.IsSuccessStatusCode) return "Repo veya klasör bulunamadı.";

                var content = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(content);
                var files = doc.RootElement.GetProperty("tree").EnumerateArray();

                var fileList = new List<string>();
                folderPath = folderPath.Trim('/');

                foreach (var item in files)
                {
                    string path = item.GetProperty("path").GetString() ?? "";
                    string type = item.GetProperty("type").GetString();

                    if (string.IsNullOrEmpty(folderPath))
                    {
                        if (!path.Contains("/"))
                            fileList.Add(type == "tree" ? $"📁 {path}" : $"📄 {path}");
                    }
                    else if (path.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase))
                    {
                        string relativePath = path.Substring(folderPath.Length).Trim('/');
                        if (!string.IsNullOrEmpty(relativePath) && !relativePath.Contains("/"))
                        {
                            fileList.Add(type == "tree" ? $"📁 {relativePath}" : $"📄 {relativePath}");
                        }
                    }
                }

                if (fileList.Count == 0) return "Bu klasör boş veya bulunamadı.";
                return $"📂 '{repoName}/{folderPath}' İçerikleri:\n" + string.Join("\n", fileList);
            }
            catch (Exception ex) { return $"Hata: {ex.Message}"; }
        }

        // 3. YETENEK: Dosya İçeriğini Oku (Okuyucu) 
        [KernelFunction, Description("GitHub'daki bir dosyanın içeriğini okur.")]
        public async Task<string> GetSourceCode(
            [Description("Repo adı (Örn: FinancialBankV2)")] string repoName,
            [Description("Dosya yolu (Örn: README.md)")] string filePath)
        {
            // Akıllı düzeltme: "README" -> "README.md"
            if (filePath.Equals("README", StringComparison.OrdinalIgnoreCase)) filePath = "README.md";

            filePath = filePath.TrimStart('/');
            string username = "Printer3453";

            // Raw URL formatı
            string urlMain = $"https://raw.githubusercontent.com/{username}/{repoName}/main/{filePath}";
            string urlMaster = $"https://raw.githubusercontent.com/{username}/{repoName}/master/{filePath}";

            using HttpClient client = new HttpClient();
            // User-Agent ŞART
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (compatible; FarukBot/1.0)");

            try
            {
                // Önce Main'e bak
                var response = await client.GetAsync(urlMain);

                // Bulamazsa Master'a bak
                if (!response.IsSuccessStatusCode) response = await client.GetAsync(urlMaster);

                if (response.IsSuccessStatusCode)
                {
                    string code = await response.Content.ReadAsStringAsync();
                    // Çok uzun dosyaları kırp
                    if (code.Length > 20000) return code.Substring(0, 20000) + "\n...(Devamı kesildi)...";
                    return code;
                }
                else
                {
                    return $"Dosya bulunamadı. (Denenen yollar: main/master)";
                }
            }
            catch (Exception ex) { return $"Bağlantı Hatası: {ex.Message}"; }
        }
    }
}