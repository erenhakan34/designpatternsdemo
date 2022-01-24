	
Singleton design pattern nedir? - Yaratımsal
-----------------------------------------------

   Nesnenin bir defa oluşturulmasını sağlayan bir kalıptır. Private constroctor ile nesne örneklenmesi kullanıcıya bırakılmaz. Lazy instantiate yaklaşımı da kullanılabilir.
   
   
Factory design pattern nedir? - Yaratımsal
-----------------------------------------------
 
   Benzer nesnelerden sadece birini kullanmak isteyebiliriz ve kod içerisinde buna if-else veya switch ile karar vermek yerine tek bir sınıf üzerinden belirli şarta göre
   oluşan nesneyi alabiliriz. Nesne oluşturmak factory sınıfının görevi olur ve client sadece nesneyi ister.
	
   Strategy ile karıştırılabilir, factory'nin kullanım amacı daha çok client'ı kompleks nesnelerin üretiminden soyutlamak.
	

Dependency Injection(DI) nedir? (Bağımlılıkları soyutlamak)
--------------------------------------------------------------

   Bir nesneye bağımlığı olan sınıf bu nesneyi kendisi üretmek yerine, bu nesnenin kendisine dışarıdan verilmesidir. Ya constructor ya da metod parametresi ile alabilir bu nesneyi.
   
   Gevşek bağlılık (Loosely coupled) bir yaklaşım sağlar.
   
   Dependency Inversion bir solid prensibidir, bağımlılıkları tersine çevrilmesi gerektiğini söyler... DI bunu uygulayan bir pattern'dir...
   
   
Prototype design pattern nedir? - Yaratımsal(Çok kullanılmaz)
-----------------------------------------------------------------

Nesnelerin hızlıca kopyasını elde etmemizi sağlar. Yaratma işlemi kompleks ve maliyetli ise bir nesneyi bu yolla hızlıca farklı bir nesne alabiliriz.

Shallow Copy: Farklı bir nesne oluşur fakat nesne içerisinde bir nesne var ise o nesnenin referansı kopyalanır.
				Yöntem: this.MemberwiseClone()
				
Deep Copy:    Farklı bir nesne oluşur ve içerisindeki nesneler de farklı referansla oluşur.  
			   Yöntem: Yeni bir instance yaratmak...	
	

Strategy design pattern nedir? - Davranışsal kalıp > Nesnenin runtime'daki davranışı ile ilgili
--------------------------------------------------------------------------------------------------

Bir işlem için birden farklı yöntem var ise bu yöntemlerden birisini kullanmak için kullanılır.

    SOLId prensiplerinden Open-closed prensibini sağlamış oluruz.

Strategy base sınıfımız olur ve bu sınıfı uygulayan özel strateji sınıfları olur. Client hangi stratejiyi kullanmak istiyorsa onu geçmek zorundadır.

Örnek senaryolar: Ödeme yöntemleri(Nakit ödeme, Kredi kartı ile ödeme, QR kod ile ödeme, vs)
                   Login olma yöntemleri(Tckn ile login, kullanıcı kodu ile login, kredi kartı no ile login, vs.)
	
	
	

Observer design pattern nedir? - Davranışsal
-----------------------------------------------

   Bir nesnenin durumunda değişiklik olduğunda bu nesnedeki değişiklikleri izleyen diğer nesneleri haberdar etmek için kullanılır.
   
   İzlenecek olan nesne içerisinde observer'larının listesini tutar ve ekleyen bir metod açar. Observer'lar ilgili nesnede abone olarak o nesnede bir güncelleme olduğu zaman
	bildirim alırlar.
	
	
Memento design pattern nedir? - Davranışsal
----------------------------------------------

   Memento = Hatıra
   Nesnenin herhangi bir T anındaki durumunu kayda alır ve o ana dönülebilmesini sağlar.
   
   Asıl nesnemiz: Originator, nesnemizin memento sınıfı var ve bu memento nesnesini saklayan care taker sınıfı var. 
	Asıl nesne içerisinde Save ve Load metodları olabilir.
	
	

Facade design pattern nedir? - Yapısal kalıp
------------------------------------------------

Karmaşık sistemler için client'lara basit bir arayüz sunarak kompleks işleri client'tan soyutlamak için kullanılır.
Facade sınıfı olmadan da alt sistemi oluşturan sınıflara direkt erişim de yapılabilir. Her biri bağımsız çalışırlar.

Fluent Interface pattern nedir? - Diğer
--------------------------------------------

	Akıcı kod yazmamızı sağlayan bir pattern'dir. Nesne üzerinde işlem yapıldığında sürekli nesnenin kendisini dönüp diğer metodları hızlıca çağırabilmek.
	
	Method chaining yöntemi kullanılır. Aynı nesne içerisinde metod çağrıldığında aynı nesnenin dönülmesi...
	
	Dezavantajı: Eğer bir API kullanıyorsak ve method chaining var ise, geriye aynı instance mı yoksa farklı instance mı döndüğünü bilmek zorlaşır...
	
	
Proxy design pattern nedir? (Vekalet) - Yapısal
---------------------------------------------------

	Nesnelerin kontrolünü ele alan sınıflar oluşturmak için kullanılır. Nesnelere direkt erişmek yerine proxy sınıflar üzerinden erişilir ve belirli kontrol ve işlemler yapılır.
    Asıl nesnemiz içerisinde ekstradan metodlar girmez.
	
	Senaryolar:
		Uzaktaki nesneye local temsilci sağlar. Örneğin, asmx servisi metodlarının tetiklenmesi için wsdl ile client tarafında proxy sınıflar oluşturulur.
		Yetkilendirme işleri için kullanılır. Örneğin, ilgili nesneyi tüketmeden önce yetkilerin kontrol edilmesi için kullanılır.

	

Builder design pattern nedir?  - Yaratımsal
------------------------------------------------

	İnşaatçi görevi üstlenir ve kompleks nesnelerin yaratılmasından sorumlu bir sınıf oluşturmak için kullanılır. Client tarafında kod karmaşıklığı da azalır.
	Factory ile benzer ama factory sadece constructor'ı wrap ediyor, builder hem daha uzun bir inşa süreci için kullanılıyor.
	
	Birden fazla aynı nesneyi farklı şekilde yaratan builder sınıfları olabilir. Örnek: Araba üretmek
	
	

Template design pattern nedir? - Davranışsal
------------------------------------------------

    Şablon demektir. Bir algoritma içerisinde değişiklik gösteren noktalar var ise kullanılır. Genel bir algoritma vardır ve alt sınıflara göre ara ara farklı yöntemler uygulanabilir.
	
	Algoritma tüm alt sınıflar için benzerse ve bazı noktalar değişiyorsa kullanılabilir, aksi takdirde strateji pattern daha uygun olacaktır.
	
	Algoritma abstract bir sınıfta belirlenir ve somut sınıfların algoritmayı değiştirebilmeyi sağlayan metodları uygulaması gerekir.
	
	

Iterator design pattern nedir? - Davranışsal
------------------------------------------------

   Döngü misali iş yapan tekrarlayıcı bir yapı.

   foreach döngüsü iterasyon mantığı ile çalışır. Kaynağı koleksiyon veya dizidir. Bu kaynakların interface'lerinden birisi IEnumerable'dır.
    IEnumerable nesneye itera edilebilme özelliği veriyor...
	
	yield anahtar sözcüğü kullanılır. > Dataları iterasyon içerisinde kullanılması için tek tek döner. En son nerede kalındıysa compiler onu saklıyor ve metot her çağrılışında
	 kaldığı yerden devam ediyor.
	 
	Direk liste dönülemez miydi? Evet dönülürdü ama döngü içerisinde belirli şartlar sağlayıp performansı da iyi kullanmak istiyorsak tercih edilebilir.(Lazy loading yapar)
	  Sadece döngü içerisinde kullanıldığında tetiklenir.
	  
	.NET koleksiyonları mevcutta IEnumerable ve IEnumerator'dan türüyor ve iterasyon özelliği var...
	
	
	
	
Object pooling pattern nedir? - Diğer
------------------------------------------

     Tekrar tekrar kullanılan nesnelerin üretim maliyetlerini azaltmak için nesnenin bir havuzda tutulması ve ihtiyaç anında oradan alınıp kullanılması için kullanılır.
	 
	 
	 Nesne yaratılır, havuza atılır, ihtiyaç anında havuzdan alınır ve iş bitince tekrar havuza bırakılır...
	 
	 ConcurrentBag'de saklanır. Acquire(nesneyi havuzdan al) ve Release(nesneyi havuza bırak) metodları kullanılabilir.
	 
	 Örnek: DBContext nesnesi için sıklıkla kullanılan bir pattern'dir. Pooling tekniği...
	 
	 Microsoft.Extensions.ObjectPool nuget kütüphanesi...
	 
	 
	 
Decorator design pattern nedir? - Yapısal
---------------------------------------------

    Sınıfa yeni bir nitelik kazandırmak için kullanılır. (Süsleme)
	Örneğin bir sınıfın metoduna yeni bir davranış kazandırmak istiyor. Bunun için inheritance da tercih edilebilir decorator pattern de tercih edilebilir.
	
	
	 
	
Mediator design pattern nedir? - Davranışsal
------------------------------------------------

    MediatR kütüphanesi ile popülerliği artan bir pattern.
	Nesneler arası bağımlılıkları azaltmak için kullanılan bir pattern. Nesneler arası bağımlılıkların tek bir yerden yönetilmesini sağlar.
		Nesneler birbirleriyle değil, bir aracı üzerinden iletişim kurarlar. Tıpkı uçak ve kule gibi.
		
	
	
	
State design pattern nedir? - Davranışsal
----------------------------------------------

Nesnenin t anındaki durumuna göre çalışma davranışını değiştirmek için kullanılır.
Örnek: Televizyon kumandası açma ve kapama düğmesi aynı. Eğer tv açıkca tuş kapatır, eğer tv kapalı ise tuş tv'yi açar.

Nesnenin tüm olası durumlarına istinaden yeni sınıflar oluşturulması ve davranışların bu sınıflar içerisinde handle edilmesi.

Intercepting Filter pattern nedir? - Diğer
-----------------------------------------------

Kullanıcıdan gelen isteği işlemeden önce filtreleme yapmak veya cevap dönmeden önce response'ı modifiye etmek için kullanılır.
Her bir filtre kendi görevini yapıp isteği diğer bir filtreye iletir. Bu akışı yöneten FilterManager sınıfıdır.
	
	
