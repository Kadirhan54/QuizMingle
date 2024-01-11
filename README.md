# QuizMingle 

 Team3 QuizMingle: Fun and Interactive Learning Platform 🌟

## Application Description ✨

The QuizMingle project is a platform that offers a fun and interactive learning experience. Users can create and share interactive quizzes on various topics and test the knowledge level of their participants.

## Features you add to the project in line with the requirements 

- Clean Architecture: The project is divided into layers (Presentation, Application, Domain, Infrastructure) for maintenance and scalability. Each layer has clear responsibilities.

- Identity Mechanism & JWT Token: ASP.NET Core Identity is used for user management and JWT token for secure, token-based authentication. This can be seen in the AuthController and Token Service, which perform user authentication and token generation.

- CQRS Pattern - MediatR: The Command Query Responsibility Separation (CQRS) pattern is implemented using MediatR and the separation of commands and queries is provided in the QuizController.

- Fluent Validation: Fluent Validation library was used in QuizController to validate user input.

- Interception Mechanism: Dependency Injection mechanism has been implemented.

- Entity Framework Core & Performance Optimisation: Entity Framework Core was used for database operations and performance optimisations were made by tracing mechanism.

- Caching: QuizController caching strategies have been implemented to reduce database load and improve response times.

- User Secrets: User Secrets are used for the management of sensitive data in the development environment.

- Helper Classes/Services in Infrastructure Layer: Reusable helper classes and services have been developed in infrastructure layer for common operations.

- Singleton Design Pattern: Singleton pattern is implemented in user.


##  Projeye Eklenen Özellikler Detay📍

- Kullanıcı Girişi ve Kaydı:
Platforma giriş yapmak ve quizler oluşturmak için kullanıcıların bir hesap oluşturması gerekmektedir. Kullanıcılar, güvenli kullanıcı kimlik doğrulaması ile platforma erişebilir ve kişisel profillerini yönetebilirler.

- Quiz Oluşturma:
Kullanıcılar, platform üzerinden kolayca quiz oluşturabilirler. Quiz oluşturma formunda, seçenekleri ve doğru cevaplar belirlenebilir.

- Quiz Detayları ve Sonuçlar:
Her quizin ayrıntılı bir sayfası bulunmaktadır. Her katılımcının verdiği cevaplar ve quiz sonuçları detaylı bir şekilde incelenebilir.

##  Görev Dağılımı 📌

- #### [Kadirhan Sağlam](https://github.com/kadirhan54):
    Tracing and Interception Mechanism, Caching, Fluent Validation

- #### [Seyyit Ahmet Kılıç](https://github.com/sahmett)
    Domain, Persistence,  Database Design, Configurations, Entities, AuthController, QuizControllers, Identity Mechanism, JWT Token

- #### [Nejla Küçük](https://github.com/nkucukk):
    User CRUD, MediatR 
- #### [Elif Yıldırım](https://github.com/elif-ux):
    User CRUD, Singleton Design Pattern, Fixing the bugs
- #### Furkan Mert Mısırlı:
  GetBestScoreInQuiz & GenerateRandomQuiz endpoints
  - Random quiz oluşturma özelliği ile sürekli değişen ve çeşitlenen içerikler sunarak kullanıcılara dinamik bir quiz
  - En iyi skoru getirme endpointleri
    
##  Yaşanılan Problemler 📛
- Kadirhan Sağlam:

- Seyyit Ahmet Kılıç:
   JWT token oluşturma , veri tabanı tasarımı aşamalarında zorlandım.

- Nejla Küçük:
    Bu süreçte herhangi bir zorluk yaşamadım.
  
- Elif Yıldırım:
    Bu süreçte okul dönemimdeki yoğunluğun takım çalışması haftasına denk gelmesinin birkaç gün sabahlamama sebep olması dışında bir sorun yaşamadım. 

- Furkan Mert Mısırlı:
  İstenilen süreyi geçersiz veya istenmeyen değerlerle talep edilebilmesi sorununa rastlandı. Bu durumu engellemek ve güvenilirlik sağlamak için validasyon sistemine ek kontroller eklenmesi gerekti.

##  Bize Ulaşın 🚨

🌐 Kadirhan Sağlam : [Linkedin](https://tr.linkedin.com/in/kadirhansaglam)

🌐 Seyyit Ahmet Kılıç: [Linkedin](https://tr.linkedin.com/in/seyyit-ahmet-kilic)

🌐 Nejla Küçük: [Linkedin](https://tr.linkedin.com/in/nkucuk)

🌐 Elif Yıldırım: [Linkedin](https://tr.linkedin.com/in/elif-y%C4%B1ld%C4%B1r%C4%B1m-4a1373203)

🌐 Furkan Mert Mısırlı: [Linkedin](https://www.linkedin.com/in/furkan-mert-m%C4%B1s%C4%B1rl%C4%B1/)

