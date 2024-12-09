# DynamicDBCharts

DynamicDBCharts, kullanıcıların kendi veritabanı bilgilerini girerek tablo verilerini dinamik olarak analiz etmelerine ve farklı grafik türlerinde görselleştirmelerine olanak tanıyan bir uygulamadır. Bu proje, hem API hem de frontend bileşenlerini birleştirerek kullanıcı dostu bir deneyim sunar.

## Özellikler:

-Kullanıcı tarafından sağlanan veritabanı bilgileriyle dinamik bağlantı kurma.

-Veritabanından alınan verileri JSON formatında işleme.

-Grafik türleri arasında seçim yapma (sütun, pasta, radar, vb.).

-Hataları ve durum bilgilerini kullanıcıya bildirerek daha iyi bir deneyim sağlama.

-Session Storage kullanarak verileri tarayıcıda geçici olarak saklama.

## Teknolojiler:

-Backend: ASP.NET Core Web API

-Frontend: HTML, CSS (Bootstrap 4), JavaScript (Vanilla JS, Chart.js)

-Depolama: Session Storage

## Kullanım:

### Gerekli ortamı hazırlayın:
-Visual Studio 2022 veya üstü bir IDE indirin.

-ASP.NET Core yüklü olduğundan emin olun.

-Projeyi klonlayın:

git clone https://github.com/kullaniciadi/DynamicDBCharts.git
cd DynamicDBCharts

### Backend kurulumu:
-appsettings.json dosyasındaki ayarları kontrol edin.

-API'yi çalıştırarak yerel sunucuda barındırın (ör. https://localhost:7157).

-Kullanıcıdan alınan verilerle dinamik veritabanı bağlantısı kurulur ve tablo verileri JSON formatında döner.

### Frontend kurulumu:

-index.html dosyasını açarak kullanıcıdan server adı, veritabanı adı ve doğrulama bilgilerini girmesi istenir.

-API'ye yapılan başarılı bir bağlantı sonrası, chartsview.html sayfasına yönlendirilir.

### Grafikleri görüntüleme:

-Kullanıcı, farklı grafik türlerini seçerek verileri görselleştirebilir.

-Veriler, etiketler (labels) ve değerler (data) şeklinde işlenerek Chart.js ile sunulur.

### Örnek Kullanım:

-Kullanıcı aşağıdaki bilgileri girer:

Server Adı: localhost
Veritabanı Adı: SalesDB
Tablo Adı: CarSales
Doğrulama Türü: SQL Authentication
"Bağlan" butonuna tıklandığında API, belirtilen tabloyu okur ve verileri döndürür.

## Lisans:
-Bu proje MIT Lisansı ile lisanslanmıştır.
