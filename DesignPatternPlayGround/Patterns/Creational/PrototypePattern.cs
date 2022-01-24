using System;

namespace DesignPatternPlayGround.Patterns
{
    public static class PrototypePattern
    {
        public static void Run()
        {
            Console.WriteLine("Prototype Pattern\n-------------------");

            //Shallow Copy
            Address address = new Address() { City = "İstanbul", Town = "Kadıköy", Detail = new AddressDetail() { Line = "Address line" } };
            Address address2 = address;

            address2.City = "Ankara";

            Console.WriteLine("Assigning object to another");
            Console.WriteLine(address.City);
            Console.WriteLine(address2.City);
            Console.WriteLine(address.Detail.Line);
            Console.WriteLine(address2.Detail.Line);
            Console.WriteLine($"== result > {address == address2}");
            Console.WriteLine($"Equals result > {address.Equals(address2)}");
            Console.WriteLine($"ReferenceEquals result > {ReferenceEquals(address, address2)}");
            Console.WriteLine($"Address detail ReferenceEquals result > {ReferenceEquals(address.Detail, address2.Detail)}");

            address2 = address.ShallowCopy() as Address;

            address.City = "İzmir";
            address2.City = "Bursa";
            address2.Detail.Line = "Changed address line";

            Console.WriteLine("\nShallow Copy");
            Console.WriteLine(address.City);
            Console.WriteLine(address2.City);
            Console.WriteLine(address.Detail.Line);
            Console.WriteLine(address2.Detail.Line);
            Console.WriteLine($"== result > {address == address2}");
            Console.WriteLine($"Equals result > {address.Equals(address2)}");
            Console.WriteLine($"ReferenceEquals result > {ReferenceEquals(address, address2)}");
            Console.WriteLine($"Address detail ReferenceEquals result > {ReferenceEquals(address.Detail, address2.Detail)}");

            address2 = address.DeepCopy() as Address;

            address.City = "İzmir";
            address2.City = "Bursa";
            address2.Detail.Line = "Deep changed address line";

            Console.WriteLine("\nDeep Copy");
            Console.WriteLine(address.City);
            Console.WriteLine(address2.City);
            Console.WriteLine(address.Detail.Line);
            Console.WriteLine(address2.Detail.Line);
            Console.WriteLine($"== result > {address == address2}");
            Console.WriteLine($"Equals result > {address.Equals(address2)}");
            Console.WriteLine($"ReferenceEquals result > {ReferenceEquals(address, address2)}");
            Console.WriteLine($"Address detail ReferenceEquals result > {ReferenceEquals(address.Detail, address2.Detail)}");
        }
    }

    public class Address
    {
        public string City { get; set; }
        public string Town { get; set; }

        public AddressDetail Detail { get; set; }

        public object ShallowCopy()
        {
            return this.MemberwiseClone();
        }

        public object DeepCopy()
        {
            return new Address() { City = this.City, Town = this.Town, Detail = this.Detail.ShallowCopy() as AddressDetail };
        }
    }

    public class AddressDetail
    {
        public string Line { get; set; }

        public object ShallowCopy() 
        {
            return this.MemberwiseClone();
        }
    }
}
