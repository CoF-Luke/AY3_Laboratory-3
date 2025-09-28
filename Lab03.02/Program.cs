class Program
{
    static void Main()
    {
        Car c1 = new Car("Porsh Caen", "Disel", 270);
        Car c2 = new Car("Tesla Model S", "Electric", 230);
        Car c3 = new Car("Matis", "Gas", 120);

        CarsCatalog cars = new CarsCatalog();
        cars.Add(c1);
        cars.Add(c2);
        cars.Add(c3);

        for (int i = 0; i < 4; i++)
        {
            Console.WriteLine(cars[i]);
        }
    }
}


class Car : IEquatable<Car>
{
    public string Name { get; set; }
    public string Engine { get; set; }
    public int MaxSpeed { get; set; }

    public Car(string name, string engine, int maxSpeed)
    {
        Name = name;
        Engine = engine;
        MaxSpeed = maxSpeed;
    }

    public override string ToString()
    {
        return Name;
    }

    public bool Equals(Car other)
    {
        if (other == null) return false;
        return Name == other.Name &&
               Engine == other.Engine &&
               MaxSpeed == other.MaxSpeed;
    }

    public override bool Equals(object obj)
    {
        return Equals(obj as Car);
    }
}


class CarsCatalog
{
    private List<Car> cars = new List<Car>();

    public void Add(Car car)
    {
        cars.Add(car);
    }

    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= cars.Count)
                return "No such car...";
            return $"{cars[index].Name} with engine: {cars[index].Engine}";
        }
    }
}