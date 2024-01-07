# QuizMingle 

 Team3 QuizMingle: Eğlenceli ve Etkileşimli Öğrenme Platformu 🌟

##  Uygulama Açıklaması ✨

QuizMingle projesi, eğlenceli ve etkileşimli öğrenme deneyimi sunan bir platformdur. Kullanıcılar, çeşitli konularda interaktif quizler oluşturabilir, paylaşabilir ve katılımcılarını bilgi seviyelerini test edebilirler.

## Projeye Eklediğiniz Özellikler Gereksinimler Odağında

- Clean Architecture: Proje, bakım ve ölçeklenebilirlik için katmanlara (Sunum, Uygulama, Domain, Altyapı) ayrılmıştır. Her katman belirgin sorumluluklara sahiptir.

- Identity Mechanism & JWT Token: Kullanıcı yönetimi için ASP.NET Core Identity ve güvenli, token tabanlı kimlik doğrulama için JWT token kullanılmıştır. Bu, kullanıcı kimlik doğrulaması ve token üretimi yapan AuthControllerda ve Token Serviceda görülebilir.

- CQRS Pattern - MediatR: Komut Sorgu Sorumluluk Ayrımı (CQRS) deseni, MediatR kullanılarak uygulanmış ve komut ile sorguların ayrılması QuizController da sağlanmıştır.

- Fluent Validation: Kullanıcı girişlerinin doğrulaması için Fluent Validation kütüphanesi QuizController kullanılmıştır.

- Interception Mechanism: Dependency Injection mekanizması uygulanmıştır.

- Entity Framework Core & Performance Optimization: Veritabanı işlemleri için Entity Framework Core kullanılmış ve performans optimizasyonları tracing mekanizması yapılmıştır.

- Caching: Veritabanı yükünü azaltmak ve yanıt sürelerini iyileştirmek için önbellekleme stratejileri QuizController uygulanmıştır.

- User Secrets: Geliştirme ortamında hassas verilerin yönetimi için User Secrets kullanılmıştır.

- Helper Classes/Services in Infrastructure Layer: Ortak operasyonlar için altyapı katmanında yeniden kullanılabilir yardımcı sınıflar ve servisler geliştirilmiştir.

- Singleton Design Pattern: Singleton deseni user uygulanmıştır.


##  Projeye Eklenen Özellikler 📍

- Kullanıcı Girişi ve Kaydı:
Platforma giriş yapmak ve quizler oluşturmak için kullanıcıların bir hesap oluşturması gerekmektedir. Kullanıcılar, güvenli kullanıcı kimlik doğrulaması ile platforma erişebilir ve kişisel profillerini yönetebilirler.

- Quiz Oluşturma:
Kullanıcılar, platform üzerinden kolayca quiz oluşturabilirler. Quiz oluşturma formunda, seçenekleri ve doğru cevaplar belirlenebilir.

- Quiz Detayları ve Sonuçlar:
Her quizin ayrıntılı bir sayfası bulunmaktadır. Her katılımcının verdiği cevaplar ve quiz sonuçları detaylı bir şekilde incelenebilir.

##  Görev Dağılımı 📌

- #### Kadirhan Sağlam:

- #### [Seyyit Ahmet Kılıç](https://github.com/sahmett)
    Configurations, Database Design, Entities, QuizControllers, Identity Mechanism, JWT Token,

- #### [Nejla Küçük](https://github.com/nkucukk):
    User CRUD
- #### Elif Yıldırım:

- #### Furkan Mert Mısırlı:
  GetBestScoreInQuiz & GenerateRandomQuiz endpoints
  - Random quiz oluşturma özelliği ile sürekli değişen ve çeşitlenen içerikler sunarak kullanıcılara dinamik bir quiz
  - En iyi skoru getirme endpointleri
##  Yaşanılan Problemler 📛
- Kadirhan Sağlam:

- Seyyit Ahmet Kılıç:

- Nejla Küçük:
    Bu süreçte herhangi bir zorluk yaşamadım.
- Elif Yıldırım:

- Furkan Mert Mısırlı:
  İstenilen süreyi geçersiz veya istenmeyen değerlerle talep edilebilmesi sorununa rastlandı. Bu durumu engellemek ve güvenilirlik sağlamak için validasyon sistemine ek kontroller eklenmesi gerekti.

##  Bize Ulaşın 🚨

🌐 Kadirhan Sağlam : [Linkedin](https://tr.linkedin.com/in/kadirhansaglam)

🌐 Seyyit Ahmet Kılıç: [Linkedin](https://tr.linkedin.com/in/seyyit-ahmet-kilic)

🌐 Nejla Küçük: [Linkedin](https://tr.linkedin.com/in/nkucuk)

🌐 Elif Yıldırım: [Linkedin](https://tr.linkedin.com/in/elif-y%C4%B1ld%C4%B1r%C4%B1m-4a1373203)

🌐 Furkan Mert Mısırlı: [Linkedin](https://www.linkedin.com/in/furkan-mert-m%C4%B1s%C4%B1rl%C4%B1/)

