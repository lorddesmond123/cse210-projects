using System;

class Program
{
    static void Main(string[] args)
    {
        // ==============================
        // ORDER 1 - CUSTOMER IN THE USA
        // ==============================

        Address address1 = new Address(
            "123 Main Street",
            "Seattle",
            "Washington",
            "USA"
        );

        Customer customer1 = new Customer(
            "John Smith",
            address1
        );

        Order order1 = new Order(customer1);

        Product product1 = new Product(
            "Laptop",
            "L001",
            750.00m,
            1
        );

        Product product2 = new Product(
            "Wireless Mouse",
            "M002",
            25.00m,
            2
        );

        Product product3 = new Product(
            "Keyboard",
            "K003",
            45.00m,
            1
        );

        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);


        // ==================================
        // ORDER 2 - CUSTOMER OUTSIDE THE USA
        // ==================================

        Address address2 = new Address(
            "25 Oxford Road",
            "London",
            "England",
            "UK"
        );

        Customer customer2 = new Customer(
            "Mary Johnson",
            address2
        );

        Order order2 = new Order(customer2);

        Product product4 = new Product(
            "Headphones",
            "H004",
            80.00m,
            1
        );

        Product product5 = new Product(
            "USB Cable",
            "U005",
            12.00m,
            3
        );

        order2.AddProduct(product4);
        order2.AddProduct(product5);


        // ==============================
        // DISPLAY ORDER 1
        // ==============================

        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 1");
        Console.WriteLine("====================================");

        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order1.GetTotalCost():0.00}");

        Console.WriteLine();


        // ==============================
        // DISPLAY ORDER 2
        // ==============================

        Console.WriteLine("====================================");
        Console.WriteLine("ORDER 2");
        Console.WriteLine("====================================");

        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine($"TOTAL COST: ${order2.GetTotalCost():0.00}");
    }
}