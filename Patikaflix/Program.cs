using Patikaflix;
using System.Linq.Expressions;

Console.WriteLine("Patikaflix'e hoşgeldiniz");

var data = new List<Data>();// En genel listeyi oluşturmak
abc:
Console.WriteLine("Dizi eklemek için 1 e basınız\n Devam etmek için 2 ye basınız ");
int control = Convert.ToInt32(Console.ReadLine());

if (control == 1)//Dizi girip girmeyeceğini kontrol ediyorum
{
   
   
        Console.WriteLine("Lütfen dizinin adını giriniz ");
        string name1=Console.ReadLine();// Girilecek verileri değişkende topluyorum 

    int year1 = 0;// Değişkeni dışarıda tanımlayarak hata almayı enegelliyorum
    bool control2 = false;

    while (!control2)// Hata girerilene kadar döngüden çıkmaması için 
    {
        try
        {

            Console.WriteLine("Lütfen dizinin yayın yılınız yazınız");
            year1 = Convert.ToInt32(Console.ReadLine());
            control2 = true;
        }
        catch (FormatException ex)// Sayı girilmemesi durumunda format hatası vermesi 
        {
            Console.WriteLine("HATA! Yanlış formatta sayı girişi");
          
        }

    }

    Console.WriteLine("Lütfen dizinin türünü yazınız");
        string type1=Console.ReadLine();
        Console.WriteLine("lütfen dizinin yayınlanıdğı kanalı yazınız");
        string channel1=Console.ReadLine();
        Console.WriteLine("Lütfen yönetmenin adını giriniz ");
        string director1 = Console.ReadLine();

    data.Add(new Data { Name=name1, Year=year1,Type=type1,Channel=channel1,Director=director1 });// Değişkene girilen değerleri grup elemanlarına atıyorum

    goto abc;//Tekrardan dizi girmek istediğini sormak için başa dönüyorum
    
    
}
else if (control == 2)
{
    Console.WriteLine("Listenizin elemanları:");
    foreach (var item in data)// Dizi girme işlemi bittiğinde listeyi yazdırıyorum
    {
        Console.WriteLine("Dizi adı:"+item.Name +"Yayın yılı:"+item.Year+ "Yönetmen " +item.Director + "Dizi türü:"+ item.Type+ "Yayınlana kanal:"+item.Channel);
    }
}
 else // Kontrol sırasında hatalı giriş olur ise başa dönüyorum
    Console.WriteLine("Geçersiz giriş");
goto abc;

 List<Question1>dataList = data.Select(x => new Question1 //Yeni bir liste oluşturuyorum
 { 

     NewName=x.Name,
     NewDirector=x.Director,
     NewType=x.Type,
 }
).ToList();


foreach(var item in dataList)//Yeni listeyi yazdırıyorum
{
    Console.WriteLine("Yeni liste : " +item.NewName+" " +item.NewType+" "+item.NewDirector);
}

var orderData=dataList.OrderBy(x => x.NewName).ThenBy(x => x.NewDirector);// Yeni oluşturduğum listeyi sıralıyorum

foreach (var item in orderData)//Sıralanmış listeyi yazdırıyorum
{
    Console.WriteLine(item.NewName+ "--" +item.NewDirector);
}

