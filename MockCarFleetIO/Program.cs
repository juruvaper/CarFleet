// See https://aka.ms/new-console-template for more information
using CarFleetIO.Application.Commands;
using CarFleetIO.Application.Commands.Handlers;
using CarFleetIO.Domain.Entities;
using CarFleetIO.Domain.Factories;
using CarFleetIO.Domain.Repositories;
using CarFleetIO.Domain.ValueObjects;
using CarFleetIO.Infrastructure.Contexts;
using CarFleetIO.Infrastructure.Repositories;
using CarFleetIO.Infrastructure.Services;
using System.Reflection.Metadata.Ecma335;
using CarFleetIO.Domain.Consts;
using CarFleetIO.Application.Services;



//Na początku stworzę "mock" dependency injection - zainicjuję wszystkie obiekty, których
//lifespan powinien być zdefiniowany jako singleton. Dodatkowo, stworzę sobie sztucznie pewne obiekty
// (np. Localization), abym mógł zademonstrować działanie encji: User, Car oraz Reservation




Localization Rzeszow = new Localization(new Guid("950b8f70-9322-498e-8172-996034d2fcaf"), "Rzeszow", "Poland");
Localization Vien = new Localization(new Guid("8742e7b8-232e-4c54-948e-5c718967d305"), "Vien", "Austria");
Localization Roma = new Localization(new Guid("fc533402-8db5-4c51-ba2f-e4e251a5d0eb"), "Roma", "Italy");


Car Volvo = new Car("URJDGSBFKT1JFU849", "TSAFP85", 254, 85000, "mja854", new Guid("950b8f70-9322-498e-8172-996034d2fcaf"), "Volvo", "S60", 5);
Car Toyota = new Car("KDPRYDNXKF1485PFJ", "TSAFP85", 180, 95000, "tyr123", new Guid("8742e7b8-232e-4c54-948e-5c718967d305"), "Toyota", "Camry", 4);
Car Tesla = new Car("TESLASERIAL1SJD85", "TSAFP85", 400, 30000, "rob567", new Guid("fc533402-8db5-4c51-ba2f-e4e251a5d0eb"), "Tesla", "Model 3", 5);


User Jon = new User("mja854", 83947584912, new Guid("950b8f70-9322-498e-8172-996034d2fcaf"), 0, "Jon", "Snow", new DateOnly(1988, 1, 1), new DateOnly(2020, 10, 10));
User Rob = new User("rob567", 65947584914, new Guid("8742e7b8-232e-4c54-948e-5c718967d305"), 0, "Rob", "Stark", new DateOnly(1990, 2, 2), new DateOnly(2015, 10, 10));
User Tyrion = new User("tyr123", 16947584916, new Guid("fc533402-8db5-4c51-ba2f-e4e251a5d0eb"), 0, "Tyrion", "Lannister", new DateOnly(1967, 1, 1), new DateOnly(2012, 10, 10));

AdministrationUser admin1 = new AdministrationUser("ann123", 84758694719, new Guid("fc533402-8db5-4c51-ba2f-e4e251a5d0eb"), Gender.Male, "Anna", "Nowak",
    new DateOnly(1980, 1, 1), new DateOnly(2010, 5, 10));

WriteDbContext InMemoryWritedDbSet = new WriteDbContext(
    new List<Localization> { Rzeszow, Vien, Roma },
    new List<Car> { Volvo, Toyota, Tesla },
    new List<User> { Jon, Rob, Tyrion },
    new List<Reservation> { },
    new List<TripReport> { },
    new List<Leasing> { }
    );

//Na potrzeby synulacji, Read i WriteDB są takie same

WriteDbContext InMemoryReadDbSet = new WriteDbContext(
    new List<Localization> { Rzeszow, Vien, Roma },
    new List<Car> { Volvo, Toyota, Tesla },
    new List<User> { Jon, Rob, Tyrion },
    new List<Reservation> { },
    new List<TripReport> { },
    new List<Leasing> { }
    );


// ------------------------- KONFIGURACJA POTRZEBNYCH SERWISÓW ----------------------------


// ------ CAR ------

CarRepository inMemoryCarRepository = new CarRepository(InMemoryWritedDbSet);
CarReadService inMemoryCarReadService = new CarReadService(InMemoryWritedDbSet);
CarFactory inMemoryCarFactory = new CarFactory();

// ------  USER -------

UserReadService inMemoryUserReadService = new UserReadService(InMemoryWritedDbSet);
UserRepository inMemoryUserRepository = new UserRepository(InMemoryWritedDbSet);
UserFactory inMemoryUserFactory = new UserFactory();

// ----- RESERVATION -------

ReservationReadService inMemoryReservationReadService = new ReservationReadService(InMemoryWritedDbSet);
ReservationRepository inMemoryReservationRepository = new ReservationRepository(InMemoryWritedDbSet);
ReservationFactory inMemoryReservationFactory = new ReservationFactory();

// ----- TRIP REPORT ------

TripReportRepository inMemoryTripReportRepository = new TripReportRepository(InMemoryWritedDbSet);
TripReportFactory inMemoryTripReportFactory = new TripReportFactory();


// ----- LEASING ------

LeasingFactory inMemoryLeasingFactory = new LeasingFactory();
LeasingReadService inMemoryLeasingReadService = new LeasingReadService(InMemoryWritedDbSet);
LeasingRepository inMemoryleasingRepository = new LeasingRepository(InMemoryWritedDbSet);


// ---------------------------- KONIEC KONFIGURACJI -------------------------------------------------



// ----- KOMENDY -----

CreateCar createCarCommand = new CreateCar("BMWX5SERIALX2024K", "KRK0012", 320, 60000, "rob567", new Guid("d482bfc4-f843-4a32-abe3-1fc18be263e1"), "BMW", "X5", 5);

MakeReservation makeReservation = new MakeReservation(new Guid("3b2a80f8-c71f-476a-a146-10015f24e667"), 
    new ReservationDatesWriteModel(new DateOnly(2025,5,1), new DateOnly(2025, 5, 20)), "BMWX5SERIALX2024K", "rob567" , "Warsaw", "Vien");

MakeReservation makeReservation1 = new MakeReservation(new Guid("7d6304b8-22a2-4b04-902d-90a8b1d52eb6"),
    new ReservationDatesWriteModel(new DateOnly(2025, 6, 1), new DateOnly(2025, 6, 10)), "BMWX5SERIALX2024K", "rob567", "Drezno", "Lisbon");

MakeReservation makeReservation2 = new MakeReservation(new Guid("f3c52cb4-29c4-4979-a383-f6f3f611d3c7"),
    new ReservationDatesWriteModel(new DateOnly(2025, 4, 20), new DateOnly(2025, 5, 5)), "TESLASERIAL1SJD85", "rob567", "Drezno", "Lisbon");

FinishReservation finishReservation = new FinishReservation(new Guid("f3c52cb4-29c4-4979-a383-f6f3f611d3c7"));



// ------ HANDLERY -------

CreateCarHandler createCarHandler = new CreateCarHandler(inMemoryCarRepository, inMemoryCarFactory, inMemoryUserReadService, inMemoryCarReadService);

MakeReservationHandler makeReservationHandler = new MakeReservationHandler(inMemoryReservationRepository, inMemoryReservationFactory, inMemoryCarReadService, inMemoryReservationReadService, inMemoryUserReadService);

FinishReservationHandler finishReservationHandler = new FinishReservationHandler(inMemoryReservationReadService, inMemoryReservationRepository, inMemoryTripReportFactory,
    inMemoryTripReportRepository);
FillTripDetailsHandler fillTripDetailsHandler = new FillTripDetailsHandler(inMemoryTripReportRepository);

ReportDefectHandler reportDefectHandler = new ReportDefectHandler(inMemoryTripReportRepository);


// ---- IMPORT CARS FROM LEASING SECTION ------- \\

var csvCars = "VF1RFA00463001576,WXE1234,150,50000,admin1,950b8f70-9322-498e-8172-996034d2fcaf,Renault,Clio,5;" +
              "WVWZZZ1KZAW000123,QWE5678,200,75000,admin1,950b8f70-9322-498e-8172-996034d2fcaf,Volkswagen,Golf,5;" +
              "JHMCM56557C404453,RTY8910,180,62000,admin1,950b8f70-9322-498e-8172-996034d2fcaf,Honda,Civic,5;" +
              "1HGFA16526L081234,UIO2345,220,34000,admin1,950b8f70-9322-498e-8172-996034d2fcaf,Toyota,Corolla,5;" +
              "4T1BE46KX7U123456,ASD6789,170,43000,admin1,950b8f70-9322-498e-8172-996034d2fcaf,Mazda,CX30,5";

string[] carRecords = csvCars.Split(';');

List<CreateCar> createCarList = new List<CreateCar>();

foreach (var car in carRecords)
{
    var carFormatted = car.Split(',');
    var tempCar = new CreateCar(
                carFormatted[0], // CarId
                carFormatted[1], // LicensePlate
                int.Parse(carFormatted[2]), // Power (int)
                int.Parse(carFormatted[3]), // Price (int)
                carFormatted[4], // Admin
                Guid.Parse(carFormatted[5]), // UUID
                carFormatted[6], // Make
                carFormatted[7], // Model
                int.Parse(carFormatted[8]));  // Year (int)

    createCarList.Add(tempCar);
}

CreateLeasing createLeasing = new CreateLeasing(new Guid("f3c52cb4-29c4-4979-a383-f6f3f611d3c7"),
    admin1, createCarList, new DateOnly(2025, 1, 1), new DateOnly(2028, 1, 1));

CreateLeasingHandler createLeasingHandler = new CreateLeasingHandler(inMemoryCarRepository, inMemoryCarReadService, inMemoryLeasingFactory, inMemoryLeasingReadService, inMemoryleasingRepository);

// -------- KONIEC SEKCJI IMPORTU CSV -------- \\



//SYMULACJA DZIAŁANIA APLIKACJI: MOCK INFRASTRUKTURY IN MEMORY + MOCK API Z UŻYCIEM KONSOLI


Console.WriteLine("Lista samochodów w początkowym stanie - przed użyciem CreateCarHandler\n");

foreach(var car in InMemoryWritedDbSet.Cars)
{
    Console.WriteLine(car.ToString());
}

Console.WriteLine("\n");


Console.WriteLine("Lista samochodów po dodaniu samochodu za pomocą CreateCarHandler\n");

await createCarHandler.HandleAsync(createCarCommand);


foreach (var car in InMemoryWritedDbSet.Cars)
{
    Console.WriteLine(car.ToString());
}


Console.WriteLine("Dodawanie nowej rezerwacji\n");

await makeReservationHandler.HandleAsync(makeReservation);
await makeReservationHandler.HandleAsync(makeReservation1);
await makeReservationHandler.HandleAsync(makeReservation2);

Console.WriteLine("Ustawianie statusu rezerwacji jako skończonej - tworzenie obiektu trip report\n");

await finishReservationHandler.HandleAsync(finishReservation);
foreach(var res in InMemoryWritedDbSet.Reservations.Where(c => c.ReservationID == finishReservation.reservationId))
{
    Console.WriteLine(res.ToString());
}

Guid tempTripId = InMemoryWritedDbSet.TripReports.First().TripID;
List<ReportDefect> reportDefects = new List<ReportDefect>();
reportDefects.Add(new ReportDefect("Oil leak", Severity.High, false));
reportDefects.Add(new ReportDefect("Turbo whistle", Severity.High, false));
reportDefects.Add(new ReportDefect("Trunk hinge broken", Severity.Medium, false));




FillTripDetails fillTripDetails = new FillTripDetails(tempTripId, 1200, 140);

await fillTripDetailsHandler.HandleAsync(fillTripDetails);

Failures failures = new Failures(tempTripId, reportDefects);

await reportDefectHandler.HandleAsync(failures);


foreach (var res in InMemoryWritedDbSet.Reservations)
{
    Console.WriteLine(res.ToString());
}
foreach(var trip in InMemoryWritedDbSet.TripReports)
{
    Console.WriteLine(trip.ToString());
    Console.WriteLine(trip.ShowFailures());
}

Console.WriteLine("Samochody poniżej tworzone są z użyciem funkcji obsługi leasingu\n");

await createLeasingHandler.HandleAsync(createLeasing);

foreach (var car in InMemoryWritedDbSet.Cars)
{
    Console.WriteLine(car.ToString());
}

foreach(var lease in InMemoryWritedDbSet.Leasings)
{
    Console.WriteLine(lease.ToString());
}

Console.ReadKey();

// KONIEC DZIAŁANIA SYMULACJI