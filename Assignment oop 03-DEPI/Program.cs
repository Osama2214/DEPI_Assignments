using System;

namespace OOPAssignment03
{


    // Part 1: Static Binding

    public class Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }


        public Shape(double width, double height)
        {
            Width = width;
            Height = height;
        }


        public double Area()
        {
            return Width * Height;
        }


        public override string ToString()
        {
            return string.Format(
                "(Width = {0}, Height = {1})",
                Width,
                Height
            );
        }
    }



    public class Cube : Shape
    {
        public double Depth { get; set; }


        public Cube(double width, double height, double depth)
            : base(width, height)
        {
            Depth = depth;
        }


        public new double Area()
        {
            return base.Area() * Depth;
        }


        public void Print()
        {
            Console.WriteLine("Width: " + Width);
            Console.WriteLine("Height: " + Height);
            Console.WriteLine("Depth: " + Depth);
        }
    }



    // Part 2: Dynamic Binding

    public class Person
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }


        public Person()
        {
            Name = "Unknown";
        }


        public void Greet()
        {
            Console.WriteLine("I am a Person.");
        }


        public virtual void Display()
        {
            Console.WriteLine("ID: " + ID);
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Age: " + Age);
        }
    }



    public class Doctor : Person
    {
        public string Specialty { get; set; }


        public Doctor()
        {
            Specialty = "Unknown";
        }


        public new void Greet()
        {
            Console.WriteLine("I am a Doctor.");
        }


        public override void Display()
        {
            base.Display();
            Console.WriteLine("Specialty: " + Specialty);
        }
    }



    public class Engineer : Person
    {
        public string Field { get; set; }
        public int YearsOfExperience { get; set; }


        public Engineer()
        {
            Field = "Unknown";
        }


        public new void Greet()
        {
            Console.WriteLine("I am an Engineer.");
        }


        public override void Display()
        {
            base.Display();
            Console.WriteLine("Field: " + Field);
            Console.WriteLine(
                "Years Of Experience: " + YearsOfExperience
            );
        }
    }



    // Part 3: Interfaces

    public interface IMoveable
    {
        void MoveForward();
        void MoveBackward();
    }



    public interface IFlyable
    {
        void MoveUp();
        void MoveDown();
    }



    public class Car : IMoveable
    {
        public void MoveForward()
        {
            Console.WriteLine("Car moves forward on the ground.");
        }


        public void MoveBackward()
        {
            Console.WriteLine("Car moves backward on the ground.");
        }
    }



    public class Ship : IMoveable
    {
        public void MoveForward()
        {
            Console.WriteLine("Ship moves forward on the sea.");
        }


        public void MoveBackward()
        {
            Console.WriteLine("Ship moves backward on the sea.");
        }
    }



    public class Airplane : IMoveable, IFlyable
    {
        public void MoveForward()
        {
            Console.WriteLine("Airplane moves forward in the air.");
        }


        public void MoveBackward()
        {
            Console.WriteLine("Airplane moves backward in the air.");
        }


        public void MoveUp()
        {
            Console.WriteLine("Airplane moves up.");
        }


        public void MoveDown()
        {
            Console.WriteLine("Airplane moves down.");
        }
    }



    // Q13: Interface Inheritance

    public interface IVehicle : IMoveable, IFlyable
    {

    }



    public class Vehicle : IVehicle
    {
        public virtual void MoveForward()
        {
            Console.WriteLine("Vehicle moves forward.");
        }


        public virtual void MoveBackward()
        {
            Console.WriteLine("Vehicle moves backward.");
        }


        public virtual void MoveUp()
        {
            Console.WriteLine("Vehicle moves up.");
        }


        public virtual void MoveDown()
        {
            Console.WriteLine("Vehicle moves down.");
        }
    }



    // Q14: Explicit Interface

    public class ShipExplicit : IMoveable
    {
        void IMoveable.MoveForward()
        {
            Console.WriteLine("Ship moves forward on the sea.");
        }


        public void MoveBackward()
        {
            Console.WriteLine("Ship moves backward on the sea.");
        }
    }



    internal class Program
    {


        static void ProcessPerson(Person person)
        {
            person.Greet();
            person.Display();
        }



        static void Main(string[] args)
        {


            // Part 1

            Console.WriteLine("Part 1: Static Binding");
            Console.WriteLine();


            Shape shape = new Shape(2, 3);
            Console.WriteLine("Shape Area: " + shape.Area());


            Cube cube = new Cube(2, 3, 4);
            Console.WriteLine("Cube Area: " + cube.Area());

            cube.Print();


            Shape shapeRef = new Cube(2, 3, 4);
            Console.WriteLine("Shape Reference Area: " + shapeRef.Area());


            Console.WriteLine();


            object obj = new Cube(1, 2, 3);
            Console.WriteLine(obj.ToString());


            Console.WriteLine();


            // Part 2

            Console.WriteLine("Part 2: Dynamic Binding");
            Console.WriteLine();


            Person doctor = new Doctor
            {
                ID = 1,
                Name = "Ahmed",
                Age = 35,
                Specialty = "Cardiology"
            };


            Person engineer = new Engineer
            {
                ID = 2,
                Name = "Omar",
                Age = 28,
                Field = "Software Engineering",
                YearsOfExperience = 5
            };


            Console.WriteLine("Doctor Information:");
            ProcessPerson(doctor);


            Console.WriteLine();


            Console.WriteLine("Engineer Information:");
            ProcessPerson(engineer);


            Console.WriteLine();


            // Part 3

            Console.WriteLine("Part 3: Interfaces");
            Console.WriteLine();


            Car car = new Car();
            car.MoveForward();
            car.MoveBackward();


            Ship ship = new Ship();
            ship.MoveForward();
            ship.MoveBackward();


            Airplane airplane = new Airplane();
            airplane.MoveForward();
            airplane.MoveBackward();
            airplane.MoveUp();
            airplane.MoveDown();


            Console.WriteLine();


            IMoveable carRef = new Car();
            carRef.MoveForward();
            carRef.MoveBackward();


            IMoveable planeRef = new Airplane();
            planeRef.MoveForward();
            planeRef.MoveBackward();


            IFlyable flyRef = new Airplane();
            flyRef.MoveUp();
            flyRef.MoveDown();


            Console.WriteLine();


            // Q13

            IVehicle vehicle = new Vehicle();

            vehicle.MoveForward();
            vehicle.MoveBackward();
            vehicle.MoveUp();
            vehicle.MoveDown();


            Console.WriteLine();


            // Q14

            ShipExplicit explicitShip = new ShipExplicit();

            // explicitShip.MoveForward();

            IMoveable explicitShipRef = explicitShip;

            explicitShipRef.MoveForward();
            explicitShipRef.MoveBackward();


            Console.ReadKey();
        }
    }
}