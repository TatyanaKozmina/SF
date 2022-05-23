namespace Task7.OrderItems
{    
    abstract class Item
    {
        protected  string name;
        protected  double price;

        public string Name { get { return name; } }

        public virtual double Price 
        {
            get { return price; }
            set 
            {
                if (value > 0)
                    price = value;
                else
                    Console.WriteLine("Некорректная цена");
            }              
        }

        public Item(string name, double price)
        {
            this.name = name;
            if (price > 0)
                this.price = price;
        }        

        public abstract void ShowInfo();
    }
    
    class Food : Item
    {
        protected  double weight; 

        public double Weight { get { return weight; } }

        public Food(string name, double price, double weight): base( name,  price)
        {
            if(weight > 0)
                this.weight = weight;
        }

        public static Food operator * (Food foodItem, int multiplier)
        {
            double currentPrice = foodItem.Price;
            if (multiplier > 9)
                currentPrice *= 0.9; 
            return new Food (foodItem.Name, currentPrice, foodItem.Weight * multiplier);
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{name}, Цена {price}, Вес {weight}");
        }
    }
    
    class Wine : Item
    {
        protected int quantity;
        private const double MaxPrice = 500000;
        public int Quantity
        {
            get { return quantity; }
            set
            {
                if (value > 0)
                    quantity = value;
                else
                {
                    Console.WriteLine("Некорректное количество");
                }
            }
        }

        public override double Price
        {
            get { return price; }
            set
            {
                if (value > 0)
                {
                    if (value > MaxPrice)
                        Console.WriteLine("Проверьте, что цена введена правильно");
                    else
                        price = value;
                }                    
                else
                    Console.WriteLine("Некорректная цена");
            }
        }

        public Wine(string name, double price, int quantity) : base(name, price)
        {
            if(quantity > 0)
                this.quantity = quantity;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"{name}, Цена {price}, Количество {quantity}");
        }
    }

    class WineCollection
    {
        protected internal Wine[] collection;

        protected internal WineCollection(Wine[] collection)
        {
            this.collection = collection;
        }

        protected internal Wine this[int index]
        {
            get
            {
                if (index < 0 || index >= collection.Length)
                    return null;
                else
                    return collection[index];
            }
        }
    }
}
