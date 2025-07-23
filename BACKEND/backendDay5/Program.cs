namespace backendDay5
{
    internal class Program
    {
        abstract class Vehicle
        {
            public string Manufacturer { get; set; }
            public string Model { get; set; }
            public int ProductionYear { get; set; }
            public int MaxSeatingCapacity { get; set; }

            public abstract void DescribePerformance();

            public Vehicle(string manufacturer, string model, int productionYear, int maxSeatingCapacity)
            {
                if (productionYear < 1886 || productionYear > DateTime.Now.Year)
                {
                    throw new ArgumentException("Invalid production year. Cars didn't exist before 1886.");
                }

                if (maxSeatingCapacity <= 0)
                {
                    throw new ArgumentException("Seating capacity must be greater than zero.");
                }

                Manufacturer = manufacturer;
                Model = model;
                ProductionYear = productionYear;
                MaxSeatingCapacity = maxSeatingCapacity;
            }

            public virtual void displayInfo()
            {
                Console.WriteLine($"Manufacturer: {Manufacturer}");
                Console.WriteLine($"Model: {Model}");
                Console.WriteLine($"Production Year: {ProductionYear}");
                Console.WriteLine($"Max Seating Capacity: {MaxSeatingCapacity}");
            }
        }

        class Car : Vehicle
        {
            public int NumberOfDoors { get; set; }
            public bool HasAutomaticTransmission { get; set; }
            public int HorsePower { get; set; }

            public Car(string manufacturer, string model, int productionYear, int maxSeatingCapacity,
                       int numberOfDoors, bool hasAutomaticTransmission, int horsePower)
                : base(manufacturer, model, productionYear, maxSeatingCapacity)
            {
                if (numberOfDoors <= 0)
                {
                    throw new ArgumentException("Number of doors must be greater than 0.");
                }

                if (horsePower <= 0)
                {
                    throw new ArgumentException("Horsepower must be a positive number.");
                }

                NumberOfDoors = numberOfDoors;
                HasAutomaticTransmission = hasAutomaticTransmission;
                HorsePower = horsePower;
            }

            public override void DescribePerformance()
            {
                Console.WriteLine($"Performance: {HorsePower} HP, " +
                                  (HasAutomaticTransmission ? "Automatic" : "Manual") + " Transmission");
            }

            public override void displayInfo()
            {
                base.displayInfo();
                Console.WriteLine($"Number of Doors: {NumberOfDoors}");
                Console.WriteLine($"Transmission: {(HasAutomaticTransmission ? "Automatic" : "Manual")}");
                Console.WriteLine($"Horsepower: {HorsePower}");
                DescribePerformance();
        }

        class Motorcycle : Vehicle
        {
            public int EngineCapacity { get; set; }
            public bool HasSidecar { get; set; }

            public Motorcycle(string manufacturer, string model, int productionYear, int maxSeatingCapacity,
                              int engineCapacity, bool hasSidecar)
                : base(manufacturer, model, productionYear, maxSeatingCapacity)
            {
                if (engineCapacity < 50 || engineCapacity > 2000)
                {
                    throw new ArgumentException("Engine capacity must be between 50cc and 2000cc.");
                }

                if (maxSeatingCapacity > 3)
                {
                    throw new ArgumentException("Motorcycles typically can't seat more than 3 people.");
                }

                EngineCapacity = engineCapacity;
                HasSidecar = hasSidecar;
            }

            public override void DescribePerformance()
            {
                Console.WriteLine($"Performance: {EngineCapacity}cc engine" +
                                  (HasSidecar ? " with sidecar" : ""));
            }

            public override void displayInfo()
            {
                base.displayInfo();
                Console.WriteLine($"Engine Capacity: {EngineCapacity}cc");
                Console.WriteLine($"Has Sidecar: {(HasSidecar ? "Yes" : "No")}");
                DescribePerformance();
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("=== VEHICLE ENTRY PROGRAM ===\n");

            // car
            Console.WriteLine("Enter Car Information:");
            string carManufacturer = ReadNonEmpty("Manufacturer");
            string carModel = ReadNonEmpty("Model");
            int carYear = ReadIntInRange("Production Year", 1886, DateTime.Now.Year);
            int carSeats = ReadIntGreaterThan("Max Seating Capacity", 0);
            int carDoors = ReadIntGreaterThan("Number of Doors", 0);
            bool carAuto = CheckBool("Has automatic transmission (true/false)");
            int carHP = ReadIntGreaterThan("Horsepower", 0);

            Car car = new Car(carManufacturer, carModel, carYear, carSeats, carDoors, carAuto, carHP);

            //rotoms
            Console.WriteLine("\nEnter Motorcycle Information:");
            string motoManufacturer = ReadNonEmpty("Manufacturer");
            string motoModel = ReadNonEmpty("Model");
            int motoYear = ReadIntInRange("Production Year", 1886, DateTime.Now.Year);
            int motoSeats = ReadIntInRange("Max Seating Capacity", 1, 3);
            int engineCC = ReadIntInRange("Engine Capacity (cc)", 50, 2000);
            bool hasSidecar = CheckBool("Has sidecar (true/false)");

            Motorcycle motorcycle = new Motorcycle(motoManufacturer, motoModel, motoYear, motoSeats, engineCC, hasSidecar);

            Console.WriteLine("\n=== CAR DETAILS ===");
            car.displayInfo();

            Console.WriteLine("\n=== MOTORCYCLE DETAILS ===");
            motorcycle.displayInfo();
        }

        static string ReadNonEmpty(string prompt)
        {
            string input;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                    Console.WriteLine("Input must not be empty.");
            } while (string.IsNullOrWhiteSpace(input));
            return input;
        }

        static int ReadIntGreaterThan(string prompt, int min)
        {
            int value;
            bool valid;
            do
            {
                Console.Write($"{prompt}: ");
                valid = int.TryParse(Console.ReadLine(), out value) && value > min;
                if (!valid)
                    Console.WriteLine($"Value must be greater than {min}.");
            } while (!valid);
            return value;
        }

        static int ReadIntInRange(string prompt, int min, int max)
        {
            int value;
            bool valid;
            do
            {
                Console.Write($"{prompt} ({min}-{max}): ");
                valid = int.TryParse(Console.ReadLine(), out value) && value >= min && value <= max;
                if (!valid)
                    Console.WriteLine($"Value must be between {min} and {max}.");
            } while (!valid);
            return value;
        }

        static bool CheckBool(string prompt)
        {
            string input;
            do
            {
                Console.Write($"{prompt}: ");
                input = Console.ReadLine().ToLower();
                if (input == "true" || input == "yes") return true;
                if (input == "false" || input == "no") return false;
                Console.WriteLine("Enter 'true' or 'false'.");
            } while (true);
        }
    }
}
