using Task7.OrderItems;
using Task7.Deliveries;

namespace Task7.Orders
{    
    class Order<TDelivery, TDeliveryTime> where TDelivery : Delivery<TDeliveryTime>, new()
    {    
        private static int orderCounter;

        private const string homeDeliveryPrefix = "H";
        private const string pickPointDeliveryPrefix = "PP";        

        private Food[] foodCollection;
        private Wine[] wineCollection;

        public string Number { get; private set; }

        public TDelivery Delivery { get; set; }        

        static Order()
        {
            orderCounter = 0;
        }

        public Order()
        {
            ++orderCounter;
            Delivery = new TDelivery();
            Number = ComposeOrderNumber();            
        }

        public void AddItem<TItem>(TItem item) where TItem : Item
        {
            if (item is Food foodItem)
            {
                Food[] collection;
                if (foodCollection == null)
                {
                    collection = new Food[1];
                }
                else
                {
                    collection = new Food[foodCollection.Length + 1];
                    for (int i = 0; i < foodCollection.Length; i++)
                    {
                        collection[i] = foodCollection[i];
                    }
                }
                
                collection[collection.Length - 1] = foodItem;

                foodCollection = collection;
            }
            else if(item is Wine wineItem)
            {
                //Do some specific check
                Wine[] collection;
                if (wineCollection == null)
                {
                    collection = new Wine[1];
                }
                else
                {
                    collection = new Wine[wineCollection.Length + 1];
                    for (int i = 0; i < wineCollection.Length; i++)
                    {
                        collection[i] = wineCollection[i];
                    }
                }

                collection[collection.Length - 1] = wineItem;

                wineCollection = collection;
            }            
        }

        private string ComposeOrderNumber()
        {
            if (Delivery is HomeDelivery)
                return homeDeliveryPrefix + orderCounter.ToString();
            else if (Delivery is PickPointDelivery)
                return pickPointDeliveryPrefix + orderCounter.ToString();
            else
                return string.Empty;
        }
    }     
}
