NotifyApp

NotifyApp console üzərində qurulmuş sadə bir bildiriş və post idarəetmə sistemidir. Layihədə istifadəçilər mövcud postlara baxa, bəyənə bilər və bu əməliyyatlar haqqında adminə bildiriş göndərilir. Bildirişlər həm console-a yazılır, həm də email vasitəsi ilə göndərilir.

Proqramı run edib yoxlamaq istəyənlər aşağıdakı məlumatlardan istifadə edə bilər.

İstifadə üçün hazır test accountlar:
Admin account:
Username: admin
Email: rahimovabanovsha@gmail.com
Password: admin123

User accounts:
Email: rahimovabanovsha@gmail.com
Password: banovsha123

Email: kamalm@gmail.com
Password: kamal123

Bu accountlar FakeDataService.Seed() methodu vasitəsilə avtomatik yaradılır.

Email bildirişləri üçün SMTP protokolu:
Layihədə adminin gmailinə bildiriş göndərmək üçün Gmail SMTP serveri istifadə olunur. Bunun üçün Program.cs faylında aşağıdakı kimi öz gmailiniz və App Password qeyd edilməlidir:

csharp
NotificationService.ConfigureEmailSender(new SmtpEmailSender(
    "your_email@gmail.com",
    "your_app_password"
));

Bəs App Password nədir və necə əldə etmək olar?
Layihədə email bildirişləri göndərmək üçün Gmail SMTP serverindən istifadə olunur. Gmail hesabınızı birbaşa parolla deyil, App Password ilə qorumaq tövsiyə olunur.

Addım-addım App Password əldə etmək:
1. https://myaccount.google.com/security səhifəsinə daxil olun.
2. Google hesabınızda 2-Step Verification aktiv edilməlidir. Əgər aktiv deyilsə, əvvəlcə onu aktiv edin.
3. 2FA aktiv olduqdan sonra "App Passwords" bölməsinə keçin.
4. Açılan səhifədə:
  Select App bölməsində “Mail” seçin.
5. Select Device bölməsində “Other” seçib “NotifyApp” və ya istədiyiniz adı yazın.
6. Google sizin üçün 16 simvoldan ibarət bir App Password yaradacaq.
7. Bu şifrəni kopyalayın və layihədə aşağıdakı yerə daxil edin:

csharp
NotificationService.ConfigureEmailSender(new SmtpEmailSender(
     "your_email@gmail.com",
-->> "your_app_password_here" <<--
));

Diqqət: App Password sadəcə bu tətbiq üçün nəzərdə tutulub. Şəxsi parolunuzu heç yerdə yazmayın, yalnız yoxlama məqsədi ilə istifadə edin və heç yerdə paylaşmayın.

*Əlavə qeydlər:

Əgər proqramın icrası zamanı hər hansı gözlənilməyən vəziyyət ilə qarşılaşsanız — məsələn:
-Unhandled exception,

-Runtime error,

-Məntiqi uyğunsuzluq,

-Gözlənilməyən funksional davranış,

-Email göndərilməsi ilə bağlı bir problem baş verərsə,
zəhmət olmasa problemi detallı şəkildə mənə bildirin.

Müraciətinizə aşağıdakı texniki məlumatları əlavə etməyiniz xahiş olunur:
-Error description – problemin baş verdiyi vəziyyətin qısa və dəqiq izahı
-Console output və ya stack trace (əgər mövcuddursa)
-Screenshot – (vizual problem yaranarsa)
-Reproduction steps – xəta ilə nəticələnən addımların ardıcıllığı (məsələn: User login → View post → Error)

Problemi bildirmək üçün aşağıdakı yollardan istifadə edə bilərsiniz:
1. GitHub Repository-də Issue bölməsində müraciət yarada bilərsiniz.
2. Birbaşa gmail vasitəsilə əlaqə saxlaya bilərsiniz: rahimovabanovsha@gmail.com

Your feedback is highly appreciated.
Wishing you a seamless experience using NotifyApp!
