using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory; // EKLENDİ: Hafıza için
using Microsoft.SemanticKernel;
using Microsoft.SemanticKernel.ChatCompletion;
using Microsoft.SemanticKernel.Connectors.OpenAI;
using Core_Proje.AiPlugins;

namespace Core_Proje.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AiChatController : ControllerBase
    {
        private readonly Kernel _kernel;
        private readonly IChatCompletionService _chatService;
        private readonly IMemoryCache _cache; // Hafıza servisi

        public AiChatController(Kernel kernel, IMemoryCache cache)
        {
            _kernel = kernel;
            _chatService = kernel.GetRequiredService<IChatCompletionService>();
            _cache = cache;
        }

        [HttpPost]
        public async Task<IActionResult> Chat([FromBody] UserQuery request)
        {
            if (string.IsNullOrWhiteSpace(request.Message)) 
                return BadRequest("Boş mesaj gönderilemez.");

            // Session ID kontrolü (Frontend'den gelecek)
            // Eğer gelmezse (eski kullanıcılar için) geçici bir ID oluştur.
            string sessionId = request.SessionId ?? "guest_session";
            string cacheKey = $"chat_history_{sessionId}";

            // 1. GEÇMİŞİ HAFIZADAN ÇEK (Yoksa Yeni Oluştur)
            if (!_cache.TryGetValue(cacheKey, out ChatHistory history))
            {
                history = new ChatHistory();
                
                // SİSTEM ROLÜNÜ SADECE İLK SEFERDE EKLE
                history.AddSystemMessage("""
                    Sen Ömer Faruk'un portfolyo asistanısın. Türkçe konuş.
                    Eğer projele
                    Eğer bir dosya okunacaksa 'GetSourceCode' kullan.
                    Eğer klasör içeriği istenirse 'GetFolderContents' kullan.
                    Cevapların kısa ve net olsun.
                    Kullanıcı 'README' derse, bunun 'README.md' olduğunu anla ve okumayı dene.
                    """);
            }

            // 2. Kullanıcı mesajını geçmişe ekle
            history.AddUserMessage(request.Message);

            // 3. AI Ayarları
            OpenAIPromptExecutionSettings settings = new()
            {
                ToolCallBehavior = ToolCallBehavior.AutoInvokeKernelFunctions,
                Temperature = 0.2
            };

            try
            {
                var result = await _chatService.GetChatMessageContentAsync(history, settings, _kernel);
                
                // 4. AI Cevabını da geçmişe ekle
                history.AddAssistantMessage(result.Content);

                // 5. GÜNCEL GEÇMİŞİ TEKRAR HAFIZAYA KAYDET
                // 1 Saat boyunca işlem yapmazsa silinsin (RAM şişmemesi için)
                _cache.Set(cacheKey, history, TimeSpan.FromMinutes(60));

                return Ok(new { reply = result.Content });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = "Hata: " + ex.Message });
            }
        }
    }

    public class UserQuery
    {
        public string Message { get; set; }
        public string? SessionId { get; set; } // EKLENDİ: Kimlik Kartı
    }
}