using Task7.Orders;
using Task7.OrderItems;
using Task7.Deliveries;

// Создаём первый заказ с типом доставки HomeDelivery
Order<HomeDelivery, string> o1 = new Order<HomeDelivery, string>();
o1.Delivery.Address = "Калуга";
o1.Delivery.DeliveryCompany = "Частная компания";
o1.Delivery.DeliveryTime = "120 минут";

// Создаём второй заказ с типом доставки PickPointDelivery
Order<PickPointDelivery, DeliveryPeriod> o2 = new Order<PickPointDelivery, DeliveryPeriod>();
o2.Delivery.Address = "Москва";
o2.Delivery.DeliveryTime = DeliveryPeriod.Day;

// Создаём третий заказ с типом доставки PickPointDelivery, чтобы проверить как работает счётчик номера заказа
Order<PickPointDelivery, DeliveryPeriod> o3 = new Order<PickPointDelivery, DeliveryPeriod>();
o3.Delivery.Address = "Тула";

// Добляем к первому заказу несколько позиций
o1.AddItem(new Food("картофель", 50, 2) * 3); // 3 пакета картошки ценой 50 и весом пакета 2кг
o1.AddItem(new Food("сыр", 1000, 0.2));
o1.AddItem(new Wine("Мерло", 1500, 1));
o1.AddItem(new Wine("Пино блан", 1200, 1));

//Создаём коллекцию вина
WineCollection shopWineCollection = new WineCollection( new Wine[] {
new Wine("Бордо Бержерак 2015", 2500, 1),
new Wine("Долина Курико Мальбек 2018", 1800, 1) ,
new Wine("Риоха 2014", 2200, 1)
});

// Добляем к первому заказу вино из коллекции по индексу 1
o1.AddItem(shopWineCollection[1]);

// Печатаем список вин в коллекции
shopWineCollection.PrintItems();
Console.ReadLine();


static class WineCollectionExtensions
{
    public static void PrintItems(this WineCollection source)
    {        
        if(source != null)
        {
            foreach(var item in source.collection)
            {
                Console.WriteLine($"{item.Name}, Цена {item.Price}, Количество {item.Quantity}");
            }
        }        
    }
}
