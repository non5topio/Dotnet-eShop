namespace eShop.Ordering.UnitTests.Domain;

using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;

[TestClass]
public class OrderAggregateTest
{
    public OrderAggregateTest()
    { }

    [TestMethod]
    public void Create_order_item_success()
    {
        //Arrange    
        var productId = 1;
        var productName = "FakeProductName";
        var unitPrice = 12;
        var discount = 15;
        var pictureUrl = "FakeUrl";
        var units = 5;

        //Act 
        var fakeOrderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);

        //Assert
        Assert.IsNotNull(fakeOrderItem);
    }

    [TestMethod]
    public void Invalid_number_of_units()
    {
        //Arrange    
        var productId = 1;
        var productName = "FakeProductName";
        var unitPrice = 12;
        var discount = 15;
        var pictureUrl = "FakeUrl";
        var units = -1;

        //Act - Assert
        Assert.ThrowsException<OrderingDomainException>(() => new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
    }

    [TestMethod]
    public void Invalid_total_of_order_item_lower_than_discount_applied()
    {
        //Arrange    
        var productId = 1;
        var productName = "FakeProductName";
        var unitPrice = 12;
        var discount = 15;
        var pictureUrl = "FakeUrl";
        var units = 1;
        
        //Act - Assert
        Assert.ThrowsException<OrderingDomainException>(() => new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units));       
    }

    [TestMethod]
    public void Invalid_discount_setting()
    {
        //Arrange    
        var productId = 1;
        var productName = "FakeProductName";
        var unitPrice = 12;
        var discount = 15;
        var pictureUrl = "FakeUrl";
        var units = 5;

        //Act 
        var fakeOrderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);

        //Assert
        Assert.ThrowsException<OrderingDomainException>(() => fakeOrderItem.SetNewDiscount(-1));
    }

    [TestMethod]
    public void Invalid_units_setting()
    {
        //Arrange    
        var productId = 1;
        var productName = "FakeProductName";
        var unitPrice = 12;
        var discount = 15;
        var pictureUrl = "FakeUrl";
        var units = 5;

        //Act 
        var fakeOrderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);

        //Assert
        Assert.ThrowsException<OrderingDomainException>(() => fakeOrderItem.AddUnits(-1));
    }

    [TestMethod]
    public void when_add_two_times_on_the_same_item_then_the_total_of_order_should_be_the_sum_of_the_two_items()
    {
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address)
            .AddOne(1, "cup", 10.0m, 0, string.Empty)
            .AddOne(1, "cup", 10.0m, 0, string.Empty)
            .Build();

        Assert.AreEqual(20.0m, order.GetTotal());
    }

    [TestMethod]
    public void Add_new_Order_raises_new_event()
    {
        //Arrange
        var street = "fakeStreet";
        var city = "FakeCity";
        var state = "fakeState";
        var country = "fakeCountry";
        var zipcode = "FakeZipCode";
        var cardTypeId = 5;
        var cardNumber = "12";
        var cardSecurityNumber = "123";
        var cardHolderName = "FakeName";
        var cardExpiration = DateTime.UtcNow.AddYears(1);
        var expectedResult = 1;

        //Act 
        var fakeOrder = new Order("1", "fakeName", new Address(street, city, state, country, zipcode), cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);

        //Assert
        Assert.AreEqual(fakeOrder.DomainEvents.Count, expectedResult);
    }

    [TestMethod]
    public void Add_event_Order_explicitly_raises_new_event()
    {
        //Arrange   
        var street = "fakeStreet";
        var city = "FakeCity";
        var state = "fakeState";
        var country = "fakeCountry";
        var zipcode = "FakeZipCode";
        var cardTypeId = 5;
        var cardNumber = "12";
        var cardSecurityNumber = "123";
        var cardHolderName = "FakeName";
        var cardExpiration = DateTime.UtcNow.AddYears(1);
        var expectedResult = 2;

        //Act 
        var fakeOrder = new Order("1", "fakeName", new Address(street, city, state, country, zipcode), cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);
        fakeOrder.AddDomainEvent(new OrderStartedDomainEvent(fakeOrder, "fakeName", "1", cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration));
        //Assert
        Assert.AreEqual(fakeOrder.DomainEvents.Count, expectedResult);
    }

    [TestMethod]
    public void Remove_event_Order_explicitly()
    {
        //Arrange    
        var street = "fakeStreet";
        var city = "FakeCity";
        var state = "fakeState";
        var country = "fakeCountry";
        var zipcode = "FakeZipCode";
        var cardTypeId = 5;
        var cardNumber = "12";
        var cardSecurityNumber = "123";
        var cardHolderName = "FakeName";
        var cardExpiration = DateTime.UtcNow.AddYears(1);
        var fakeOrder = new Order("1", "fakeName", new Address(street, city, state, country, zipcode), cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);
        var @fakeEvent = new OrderStartedDomainEvent(fakeOrder, "1", "fakeName", cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);
        var expectedResult = 1;

        //Act         
        fakeOrder.AddDomainEvent(@fakeEvent);
        fakeOrder.RemoveDomainEvent(@fakeEvent);
        //Assert
        Assert.AreEqual(fakeOrder.DomainEvents.Count, expectedResult);
    }
/*
FAILED TEST: The test run failed because the required `.NET workload` `maui-tizen` is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_order_item_with_high_number_of_units()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .Build();
    
        // Act
        order.AddOrderItem(1, "Product A", 100.0m, 0, "http://example.com/image.jpg", 1000);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(1000, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to a missing `.NET workload` required to build the project. Specifically, the `maui-tizen` workload is missing.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Set_cancelled_status_when_stock_is_rejected()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .AddOne(1, "Product A", 100.0m, 0, "http://example.com/image.jpg")
            .AddOne(2, "Product B", 50.0m, 0, "http://example.com/image.jpg")
            .Build();
    
        order.SetAwaitingValidationStatus();
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(new List<int> { 1, 2 });
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.IsTrue(order.Description.Contains("The product items don't have stock: (Product A, Product B)."));
    }

*/
/*
FAILED TEST: The test run failed because the required `.NET workload` `maui-tizen` is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Invalid_discount_setting_on_existing_order_item()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .AddOne(1, "Product A", 100.0m, 10, "http://example.com/image.jpg")
            .Build();
    
        // Act & Assert
        Assert.ThrowsException<OrderingDomainException>(() => order.OrderItems.First().SetNewDiscount(-1));
    }

*/
/*
FAILED TEST: The test run failed because the required `.NET workload` `maui-tizen` is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:

```bash
dotnet workload restore
```

    [TestMethod]
    public void Set_paid_status_raises_domain_event()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .Build();
    
        // Set up the order to be in StockConfirmed status
        order.SetStockConfirmedStatus();
    
        // Act
        order.SetPaidStatus();
    
        // Assert
        Assert.AreEqual(1, order.DomainEvents.Count);
        Assert.IsInstanceOfType(order.DomainEvents[0], typeof(OrderStatusChangedToPaidDomainEvent));
        Assert.AreEqual(OrderStatus.Paid, order.OrderStatus);
    }

*/
/*
FAILED TEST: The test run failed due to a missing `.NET workload` required to build the project. Specifically, the `maui-tizen` workload is missing.

**Recommended Fix:**
Run the following command to install the missing workload:

```bash
dotnet workload restore
```

    [TestMethod]
    public void Set_shipped_status_when_not_paid_throws_exception()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .Build();
    
        // Act & Assert
        Assert.ThrowsException<OrderingDomainException>(() => order.SetShippedStatus());
    }

*/
/*
FAILED TEST: The test run failed because the required `maui-tizen` workload is missing, which is needed to build the project. This is indicated in the `stdout` error message.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_order_item_with_same_discount_as_existing_item()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .AddOne(1, "Product A", 100.0m, 10, "http://example.com/image.jpg")
            .Build();
    
        // Act
        order.AddOrderItem(1, "Product A", 100.0m, 10, "http://example.com/image.jpg", 2);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(3, order.OrderItems.First().Units);
        Assert.AreEqual(10, order.OrderItems.First().Discount);
    }

*/
/*
FAILED TEST: The test run failed due to a missing workload required to build the project. The error indicates that the `maui-tizen` workload is missing.

**Recommended Fix:**
Run the following command to install the required workload:

```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_order_item_with_zero_discount()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new OrderBuilder(address)
            .AddOne(1, "Product A", 100.0m, 0, "http://example.com/image.jpg")
            .Build();
    
        // Act
        order.AddOrderItem(1, "Product A", 100.0m, 0, "http://example.com/image.jpg", 2);
    
        // Assert
        Assert.AreEqual(2, order.OrderItems.Count);
        Assert.AreEqual(2, order.OrderItems.First().Units);
    }

*/
}
