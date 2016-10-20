using System;

namespace PatternsTask02
{
    #region Introduction
    public interface IAutoFactory
    {
        string AutoName { get; }
        ICarcase CreateCarcase();
        IEngine CreateEngine();
        ICarInterior CreateCarInterior();
    }

    public interface ICarcase
    {
        CarcaseTypes Carcase { get; }
        int DoorsCount { get; }
        string Name { get; }
    }

    public interface IEngine
    {
        EngineTypes Engine { get; }
        int Power { get; }
        string Name { get; }
    }

    public interface ICarInterior
    {
        MaterialTypes Material { get; }
        string MaterialName { get; }
        string DesignerSecName { get; }
    }

    public enum CarcaseTypes
    {
        Sedan,
        Hatchback,
        Universal
    }

    public enum EngineTypes
    {
        Injection,
        Diesel
    }

    public enum MaterialTypes
    {
        Leather,
        Textile,
        Styrofoam
    }

    #endregion

    #region Implements Factory

    public class BmwFactory : IAutoFactory
    {
        public string AutoName => "Bmw";
        public ICarcase CreateCarcase()
        {
            return new Sedan();
        }

        public ICarInterior CreateCarInterior()
        {
            return new TextileInterior();
        }

        public IEngine CreateEngine()
        {
            return new Diesel();
        }
    }

    public class AudiFactory : IAutoFactory
    {
        public string AutoName => "Audi";
        public ICarcase CreateCarcase()
        {
            return new Hatchback();
        }

        public ICarInterior CreateCarInterior()
        {
            return new StyrofoamInterior();
        }

        public IEngine CreateEngine()
        {
            return new Injection();
        }
    }

    #endregion

    #region Additional Classes

    public class Sedan : ICarcase
    {
        public CarcaseTypes Carcase => CarcaseTypes.Sedan;
        public int DoorsCount => 4;
        public string Name => "Sedan";
    }

    public class Hatchback : ICarcase
    {
        public CarcaseTypes Carcase => CarcaseTypes.Hatchback;
        public int DoorsCount => 12;
        public string Name => "Hatchback";
    }

    public class Diesel : IEngine
    {
        public EngineTypes Engine => EngineTypes.Diesel;
        public string Name => "Diesel";
        public int Power => 850;
    }

    public class Injection : IEngine
    {
        public EngineTypes Engine => EngineTypes.Injection;
        public string Name => "Injection";
        public int Power => 1550;
    }

    public class TextileInterior : ICarInterior
    {
        public MaterialTypes Material => MaterialTypes.Textile;
        public string DesignerSecName => "Воронцов";
        public string MaterialName => "Тканевый";
    }

    public class StyrofoamInterior : ICarInterior
    {
        public MaterialTypes Material => MaterialTypes.Styrofoam;
        public string DesignerSecName => "Бригадин";
        public string MaterialName => "Пенопластовый (такой тоже бывает :) )";
    }

    #endregion

    public class Program
    {
        public static void Main(string[] args)
        {
            var bmwFactory = new BmwFactory();
            PrintAutoDescr(bmwFactory);

            var audiFactory = new AudiFactory();
            PrintAutoDescr(audiFactory);

            Console.ReadLine();
        }

        public static void PrintAutoDescr(IAutoFactory factory)
        {
            Console.WriteLine($">>> {factory.AutoName} <<<");
            
            var carcase = factory.CreateCarcase();
            Console.WriteLine(" > Descr carcase:");
            Console.WriteLine($"  - Type: {carcase.Name}");
            Console.WriteLine($"  - Doors count: {carcase.DoorsCount}");

            var engine = factory.CreateEngine();
            Console.WriteLine(" > Descr engine");
            Console.WriteLine($"  - Type: {engine.Name}");
            Console.WriteLine($"  - Power: {engine.Power}");

            var interior = factory.CreateCarInterior();
            Console.WriteLine(" > Descr interior");
            Console.WriteLine($"  - MaterialName: {interior.MaterialName}");
            Console.WriteLine($"  - Designer's second name : {interior.DesignerSecName}");
            Console.WriteLine();
        }
    }
}