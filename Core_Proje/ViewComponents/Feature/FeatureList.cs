using Microsoft.AspNetCore.Mvc;




namespace Core_Proje.ViewComponents.Feature
{



    public class FeatureList: ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
        /* Bu ViewComponent, özelliklerin (features) listelenmesi için kullanılır.
         * Invoke metodu, ViewComponent'in ana işlevini yerine getirir ve bir görünüm döndürür.
         * Controller'daki action metotlarına benzer şekilde çalışır.
         * Amaç, belirli bir işlevselliği kapsülleyip, tekrar kullanılabilir hale getirmektir.
         * avantajı, kodun daha modüler ve yönetilebilir olmasını sağlamaktır.
         * Controller'dan farklı olarak, ViewComponent'ler doğrudan bir görünüm içinde çağrılabilir.
         * Doğrudan bir URL'ye yanıt vermezler, bunun yerine bir sayfanın parçası olarak kullanılırlar.
         * Controller'lar genellikle tam sayfa yanıtları döndürürken, ViewComponent'ler sayfanın 
         * belirli bölümlerini oluşturmak için kullanılır.
         */





    }
}
