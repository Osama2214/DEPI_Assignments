
Patient patient01 = new(1, "Osama", "01012345678", "None");
Patient patient02 = new(1, "Osama", "01012345678", "None");

// Q2.1: Print the hash codes of both objects.
Console.WriteLine(patient01.GetHashCode());
Console.WriteLine(patient02.GetHashCode());

// Q2.2: Compare the two objects.
Console.WriteLine(patient01.Equals(patient02));

// Q2.3: Assign patient02 to patient01.
patient01 = patient02;

Console.WriteLine(patient01.Equals(patient02));





Console.WriteLine("\n--- Q3: Records ---");

PatientDto dto01 = new(1, "Osama", "01012345678");
PatientDto dto02 = new(1, "Osama", "01012345678");

// Print hash codes.
Console.WriteLine(dto01.GetHashCode());
Console.WriteLine(dto02.GetHashCode());

// Compare the two records.
Console.WriteLine(dto01.Equals(dto02)); // True

// Assign dto02 to dto01.
dto01 = dto02;

Console.WriteLine(dto01.Equals(dto02)); // True




Console.WriteLine("\n--- Q4: Patient Mapper ---");

Patient patient = new(1, "Osama", "01012345678", "None");

PatientDto patientDto = PatientMapper.MapFromModelToDto(patient);

Console.WriteLine(patientDto);




Console.WriteLine("\n--- Q6: Singleton ---");

AppLogger logger1 = AppLogger.GetLogger();
AppLogger logger2 = AppLogger.GetLogger();
AppLogger logger3 = AppLogger.GetLogger();
AppLogger logger4 = AppLogger.GetLogger();

Console.WriteLine(logger1.GetHashCode());
Console.WriteLine(logger2.GetHashCode());
Console.WriteLine(logger3.GetHashCode());
Console.WriteLine(logger4.GetHashCode());




Console.WriteLine("\n--- Q7: var & dynamic ---");

// 1. Target-typed new
Patient p1 = new(1, "Osama", "01012345678", "None");

// 2. Using var
var p2 = new Patient(2, "Ahmed", "01112345678", "Allergy");

// 3. Using dynamic
dynamic p3 = new Patient(3, "Sara", "01212345678", "None");

Console.WriteLine(p1);
Console.WriteLine(p2);
Console.WriteLine(p3);





Console.WriteLine("\n--- Q8: Anonymous Types ---");

var doctor01 = new
{
    Name = "Sara",
    Specialty = "Cardiology",
    ExperienceYears = 8,
    Salary = 25_000
};

var doctor02 = new
{
    Name = "Sara",
    Specialty = "Cardiology",
    ExperienceYears = 8,
    Salary = 25_000
};

// 1. Print Name and Specialty.
Console.WriteLine(doctor01.Name);
Console.WriteLine(doctor01.Specialty);

// 2. Print hash codes.
Console.WriteLine(doctor01.GetHashCode());
Console.WriteLine(doctor02.GetHashCode());

// 3. Print the generated type.
Console.WriteLine(doctor01.GetType());

// 4. Compare the two objects.
Console.WriteLine(doctor01.Equals(doctor02));

// 5. Print the object.
Console.WriteLine(doctor01.ToString());







Console.WriteLine("\n--- Q9 & Q10: Extension Methods ---");

// Q10.1
Console.WriteLine("Stethoscope".IsShorterThan(5));

// Q10.2
Console.WriteLine("Ab".Repeat(4));