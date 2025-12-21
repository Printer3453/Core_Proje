📘 Asp.Net Core 5.0 & AI Destekli Blog Projesi
Bu proje, Murat Yücedağ'ın "Asp.Net Core 5.0" eğitimi temel alınarak geliştirilmiş, ancak üzerine Semantic Kernel ve Generative AI yetenekleri eklenerek modern bir "Akıllı Asistan" modülü ile zenginleştirilmiştir. 
Katmanlı mimari (N-Tier) yapısına sadık kalınarak geliştirilen proje, hem geleneksel web geliştirme hem de modern AI entegrasyonu yeteneklerini sergilemektedir.

Proje Hakkında
Uygulama; Kullanıcı, Yazar ve Admin panellerine ek olarak, ziyaretçilerle etkileşime giren akıllı bir Chatbot içerir. 
Bu asistan, ziyaretçilerin portfolyodaki diğer projeler hakkında soru sormasına, 
veritabanından proje listelemesine ve GitHub üzerindeki kodları analiz etmesine olanak tanır.

 Yapay Zeka ve Chat Özellikleri (Yeni)
Projeye entegre edilen Semantic Kernel tabanlı Chat modülü şu yeteneklere sahiptir:

MSSQL Entegrasyonu: Ziyaretçinin isteği üzerine veritabanına bağlanarak mevcut projeleri listeler ve özet bilgiler sunar.

GitHub Repository Analizi: Ziyaretçi spesifik bir projeyi sorduğunda, bot ilgili projenin GitHub deposunu bulur, README.md dosyasını okur ve proje detaylarını ziyaretçiye aktarır.

Kod ve Dosya Okuma: Ziyaretçi projedeki belirli bir dosyayı (örneğin bir Controller veya Entity sınıfını) merak ettiğinde, asistan o dosyanın içeriğini okur, geliştiricinin (benim) kurduğu yapıyı analiz eder, açıklar ve kod içeriğini kullanıcıya sunar.

Maliyet ve Model Yönetimi:

Geliştirme Ortamı (Dev): Maliyet optimizasyonu için yerel olarak Llama 3.2 modeli kullanılmaktadır.

Canlı Ortam (Prod): Performans ve doğruluk için GPT-4o-mini modeline geçiş yapılması planlanmıştır.

 Kullanılan Teknolojiler
Backend & AI
.NET 8.0 / Core

Microsoft Semantic Kernel (AI Orchestration)

LLM: Llama 3.2 (Local), GPT-4o-mini (Cloud Plan)

Entity Framework Core & MSSQL

ASP.NET Core Identity

Frontend
HTML5, CSS3, Bootstrap 4

JavaScript, jQuery

Razor View Engine

Diğer Özellikler
N-Tier Architecture & SOLID: Sürdürülebilir ve temiz kod yapısı.

Rol Bazlı Yetkilendirme: Admin, Yazar ve Ziyaretçi rolleri.

Dinamik Admin Paneli: Google Charts entegrasyonlu istatistikler ve widget'lar.

Trigger ve Prosedürler: Veritabanı seviyesinde otomatik işlemler.

Blog & Yorum Sistemi: AJAX tabanlı asenkron yorumlaşma.

Proje hala geliştiriliyor

(Chat botun GitHub'dan kod okuyup cevap verdiği bir anın ekran görüntüsünü buraya eklemen çok etkileyici olur.)

Geliştirici: Ömer Faruk Temel Eğitim: Murat Yücedağ
