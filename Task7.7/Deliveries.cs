namespace Task7.Deliveries
{
    abstract class Delivery<T>
    {
        public string Address;

        public T DeliveryTime;
        public Delivery()
        {
            Address = string.Empty;
        }
    }

    class HomeDelivery : Delivery<string>
    {
        public string DeliveryCompany;
    }

    class PickPointDelivery : Delivery<DeliveryPeriod>
    {
        public static int DefaultStorageDays = 5;
        public int StorageDays; 

        public PickPointDelivery() : base()
        {
            StorageDays = DefaultStorageDays;
        }
    }

    public enum DeliveryPeriod
    {
        Week,
        Day,
        Hour
    }    
}
