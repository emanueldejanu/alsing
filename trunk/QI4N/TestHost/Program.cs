namespace ConsoleApplication23
{
    using System;

    using QI4N.Framework;
    using QI4N.Framework.Runtime;

    internal class Program
    {
        private static void Main()
        {
            var moduleInstance = new ModuleInstance();
            var factory = new CompositeBuilderFactoryInstance(moduleInstance);
            TransientBuilder<Person> personFactory = factory.NewTransientBuilder<Person>();

            personFactory.Use("Roger@Alsing.com");
            var protoPerson = personFactory.PrototypeFor<PersonState>();
            protoPerson.FirstName.Value = "Roger";
            protoPerson.LastName.Value = "Alsing";
            protoPerson.Weight.Value = 85;

            Person person = personFactory.NewInstance();

      //      Console.WriteLine(person.Weight.Value);

            Person otherPerson = personFactory.NewInstance();

     //       otherPerson.Weight.Value = 99;

     //       Console.WriteLine(person.Weight.Value);
     //       Console.WriteLine(otherPerson.Weight.Value);
            
            person.SayHi();

            Console.ReadLine();

            //// Lacking support for QI4J structural definitions
            //// just kickstart my default impl
            //var moduleInstance = new ModuleInstance();
            //var factory = new CompositeBuilderFactoryInstance(moduleInstance);

            //// Create composite builder
            //var carBuilder = factory.NewCompositeBuilder<Car>();
            //var manufacturerBuilder = factory.NewCompositeBuilder<Manufacturer>();
            //var accidentBuilder = factory.NewCompositeBuilder<Accident>();

            //// prototype support is in place and works
            //var protoManufacturer = manufacturerBuilder.Prototype();

            //// Properties support .Value and Get/Set
            //// Set the properties of the prototype
            //protoManufacturer.Country.Value = "Sweden";
            //protoManufacturer.Name.Value = "Volvo";
            //protoManufacturer.CarsProduced.Value = 1234;    

            //// Create an instance based on the prototype
            //var manufacturer = manufacturerBuilder.NewInstance();

            //// Create a prototype for a car composite
            //var protoCar = carBuilder.Prototype();
            //protoCar.Model.Value = "Amazon";

            //// create a car composite based on the prototype
            //var car = carBuilder.NewInstance();
            //car.Manufacturer.Set(manufacturer);

            //var idCar = (Identity)car;
            //Console.WriteLine(idCar.Identity.Value);

            //// create a prototype value object
            //var protoAccident = accidentBuilder.Prototype();
            //protoAccident.Description.Value = "Wheel fell off";
            //protoAccident.Occured.Value = new DateTime(2009, 06, 01);
            //protoAccident.Repaired.Value = new DateTime(2010, 01, 01);           
            //// instance the value object
            //var accident = accidentBuilder.NewInstance();

            //// Add a value to an "ManyAssociation"
            //car.Accidents.Add(accident);

            //Console.WriteLine(manufacturer.CarsProduced.Value);
            //foreach (var a in car.Accidents)
            //{
            //    Console.WriteLine(a.Description.Value);
            //}

            //////       car.Model.Value = model.Value;

            ////var icar = car as Identity;
            ////icar.Identity.Value = "tjorven";

            ////Console.WriteLine(icar.Identity.Value);

            ////ObjectBuilderFactory factory = new DefaultObjectBuilderFactory();

            ////var manufacturerBuilder = factory.NewObjectBuilder<Manufacturer>();
            ////var carBuilder = factory.NewObjectBuilder<CarEntity>();

            ////Manufacturer manufacturer = manufacturerBuilder.NewInstance();
            ////Car car = carBuilder.NewInstance();   //carEntityFactory.Create(manufacturer,"v70");

            ////manufacturer.Country.Value = "hej";  
            ////car.Manufacturer.Value = manufacturer;
        }
    }
}