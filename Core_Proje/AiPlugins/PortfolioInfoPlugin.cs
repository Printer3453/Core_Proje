using Microsoft.SemanticKernel;
using System.ComponentModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using BusinessLayer.Abstract; // Senin namespace'lerin
using EntityLayer.Concrete;

namespace Core_Proje.AiPlugins
{
    public class PortfolioInfoPlugin
    {
        private readonly IPortfolioService _portfolioService;

        public PortfolioInfoPlugin(IPortfolioService portfolioService)
        {
            _portfolioService = portfolioService;
        }

        [KernelFunction, Description("Ömer Faruk'un tamamladığı projeleri listeler.")]
        public string GetProjects()
        {
            var values = _portfolioService.TGetList();
            var summary = "--- PROJE LİSTESİ ---\n";
            foreach (var item in values)
            {
                summary += $"Proje: {item.Name}\nRepo: {item.ProjectUrl}\nDetay: {item.ImageUrl}\n---\n";
            }
            return summary;
        }

        [KernelFunction, Description("Bir GitHub reposundaki belirli bir klasörün içindeki dosyaları listeler.")]
        public async Task<string> GetFolderContents(
     [Description("Repo adı (Örn: FinancialBankV2)")] string repoName,
     [Description("Klasör yolu (Boş bırakılırsa ana dizini getirir. Örn: src/FinancialBankV2.Domain)")] string folderPath = "")
        {
            string username = "Printer3453";
            using HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue("FarukBot", "1.0"));

            try
            {
                // GitHub API'den tüm ağacı çekiyoruz
                string treeUrl = $"https://api.github.com/repos/{username}/{repoName}/git/trees/main?recursive=1";

                var response = await client.GetAsync(treeUrl);
                if (!response.IsSuccessStatusCode)
                {
                    // Main yoksa Master dene
                    treeUrl = treeUrl.Replace("main", "master");
                    response = await client.GetAsync(treeUrl);
                }

                if (!response.IsSuccessStatusCode) return "Repo veya klasör bulunamadı.";

                var content = await response.Content.ReadAsStringAsync();
                using JsonDocument doc = JsonDocument.Parse(content);
                var files = doc.RootElement.GetProperty("tree").EnumerateArray();

                // Sonuçları biriktirelim
                var fileList = new List<string>();

                // Klasör yolu düzeltmeleri (başına sonuna slash koyma vs)
                folderPath = folderPath.Trim('/');

                foreach (var item in files)
                {
                    string path = item.GetProperty("path").GetString() ?? "";
                    string type = item.GetProperty("type").GetString(); // "blob" (dosya) veya "tree" (klasör)

                    // Eğer ana dizin isteniyorsa (folderPath boşsa) en üsttekileri al
                    if (string.IsNullOrEmpty(folderPath))
                    {
                        if (!path.Contains("/")) // Sadece kök dizindekiler
                        {
                            fileList.Add(type == "tree" ? $"📁 {path}" : $"📄 {path}");
                        }
                    }
                    // Eğer spesifik bir klasör isteniyorsa
                    else if (path.StartsWith(folderPath, StringComparison.OrdinalIgnoreCase))
                    {
                        // Sadece o klasörün hemen altındakileri al (derinlere inme)
                        string relativePath = path.Substring(folderPath.Length).Trim('/');
                        if (!string.IsNullOrEmpty(relativePath) && !relativePath.Contains("/"))
                        {
                            fileList.Add(type == "tree" ? $"📁 {relativePath}" : $"📄 {relativePath}");
                        }
                    }
                }

                if (fileList.Count == 0) return "Bu klasör boş veya bulunamadı. Lütfen yolu kontrol et.";

                // Listeyi madde işaretli metne çevir
                return $"📂 '{repoName}' projesi '{folderPath}' konumundaki içerikler:\n" + string.Join("\n", fileList);
            }
            catch (Exception ex)
            {
                return $"Hata: {ex.Message}";
            }
        }
    }
}