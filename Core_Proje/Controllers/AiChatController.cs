using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Core_Proje.AiPlugins; // Plugin klasörünü eklemeyi unutma

namespace Core_Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiChatController : ControllerBase
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chatService;

        // Program.cs'de yapılandıracağımız Kernel buraya otomatik gelecek
        public AiChatController(Kernel kernel)
        {
            _kernel = kernel;
            _chatService = kernel.GetRequiredService<IChatCompletionService>();
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] UserQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.Message))
                return BadRequest("Boş mesaj gönderilemez.");

            // 1. Sohbet Geçmişini ve Sistem Rolünü Ayarla
            var history = new ChatHistory();
            history.AddSystemMessage("""
                Sen Ömer Faruk Yazıcı'nın yapay zeka asistanısın.
                Görevin: Ziyaretçilerin projeler, yetenekler ve deneyimler hakkındaki sorularını yanıtlamak.
                Kurallar:
                - PortfolioInfoPlugin yeteneğini kullanarak gerçek verileri veritabanından çek.
                - Sadece Türkçe konuş.
                - Nazik ve profesyonel ol.
                - Bilmediğin bir proje sorulursa uydurma, 'Listemde göremedim' de.
                """);

            // Kullanıcı mesajını ekle
            history.AddUserMessage(request.Message);

            // 2. Ayarlar (Fonksiyonları otomatik çağırması için)
            OpenAIPromptExecutionSettings settings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                Temperature = 0.2 // Tutarlı cevaplar için düşük sıcaklık
            };

            // 3. AI Cevabını Al
            try
            {
                var result = await _chatService.GetChatMessageContentAsync(history, settings, _kernel);
                return Ok(new { reply = result.Content });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "AI yanıt veremedi: " + ex.Message });
            }
        }
    }

    // Basit bir model sınıfı
    public class UserQuery
    {
        public string Message { get; set; }
    }
}