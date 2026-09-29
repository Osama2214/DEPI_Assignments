using System;

namespace CompanyOOP
{


    public enum SecurityLevel
    {
        Guest,
        Developer,
        Secretary,
        DBA,
        SecurityOfficer
    }



    public class HiringDate
    {
        private int day;
        private int month;
        private int year;

        public int Day
        {
            get { return day; }
            set
            {
                if (value >= 1 && value <= 31)
                    day = value;
                else
                    day = 1;
            }
        }

        public int Month
        {
            get { return month; }
            set
            {
                if (value >= 1 && value <= 12)
                    month = value;
                else
                    month = 1;
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                if (value >= 1)
                    year = value;
                else
                    year = 2000;
            }
        }



        public HiringDate()
        {
            Day = 1;
            Month = 1;
            Year = 2000;
        }



        public HiringDate(int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);

                Day = day;
                Month = month;
                Year = year;
            }
            catch (ArgumentOutOfRangeException)
            {
                Day = 1;
                Month = 1;
                Year = 2000;
            }
        }

        public override string ToString()
        {
            return string.Format("{0:D2}/{1:D2}/{2}", Day, Month, Year);
        }
    }



    public class Employee
    {
        private int id;
        private string name;
        private SecurityLevel security;
        private decimal salary;
        private HiringDate hireDate;
        private char gender;

        public int ID
        {
            get { return id; }
            set
            {
                if (value > 0)
                    id = value;
                else
                    id = 1;
            }
        }

        public string Name
        {
            get { return name; }
            set
            {
                if (!string.IsNullOrWhiteSpace(value))
                    name = value;
                else
                    name = "Unknown";
            }
        }

        public SecurityLevel Security
        {
            get { return security; }
            set
            {
                if (Enum.IsDefined(typeof(SecurityLevel), value))
                    security = value;
                else
                    security = SecurityLevel.Guest;
            }
        }

        public decimal Salary
        {
            get { return salary; }
            set
            {
                if (value >= 0)
                    salary = value;
                else
                    salary = 0;
            }
        }

        public HiringDate HireDate
        {
            get { return hireDate; }
            set
            {
                if (value != null)
                    hireDate = value;
                else
                    hireDate = new HiringDate();
            }
        }

        public char Gender
        {
            get { return gender; }
            set
            {
                char input = char.ToUpper(value);

                if (input == 'M' || input == 'F')
                    gender = input;
                else
                    gender = 'M';
            }
        }



        public Employee()
        {
            ID = 1;
            Name = "Unknown";
            Security = SecurityLevel.Guest;
            Salary = 0;
            HireDate = new HiringDate();
            Gender = 'M';
        }



        public Employee(int id, string name,
                        SecurityLevel security, decimal salary,
                        HiringDate hireDate, char gender)
        {
            ID = id;
            Name = name;
            Security = security;
            Salary = salary;
            HireDate = hireDate;
            Gender = gender;
        }



        public override string ToString()
        {
            return string.Format(
                "ID: {0}\n" +
                "Name: {1}\n" +
                "Security Level: {2}\n" +
                "Salary: {3:C}\n" +
                "Hire Date: {4}\n" +
                "Gender: {5}",
                ID,
                Name,
                Security,
                Salary,
                HireDate,
                Gender
            );
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {

            Employee[] EmpArr = new Employee[3];


            EmpArr[0] = new Employee(
                1,
                "Ahmed",
                SecurityLevel.DBA,
                15000,
                new HiringDate(10, 5, 2022),
                'M'
            );


            EmpArr[1] = new Employee(
                2,
                "Mona",
                SecurityLevel.Guest,
                8000,
                new HiringDate(15, 3, 2023),
                'F'
            );


            EmpArr[2] = new Employee(
                3,
                "Omar",
                SecurityLevel.SecurityOfficer,
                20000,
                new HiringDate(1, 1, 2021),
                'M'
            );


            foreach (Employee emp in EmpArr)
            {
                Console.WriteLine(emp);
                Console.WriteLine("-");
            }

            Console.ReadKey();
        }
    }
}