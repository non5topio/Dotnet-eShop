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
FAILED TEST: **Analysis:**
The test run failed because the required `.NET workload` `maui-tizen` is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_multiple_order_items_same_product_id_different_discounts_retains_higher_discount()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var pictureUrl = "http://example.com";
        var units = 1;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, 5m, pictureUrl, units);
        order.AddOrderItem(productId, productName, unitPrice, 10m, pictureUrl, units);
    
        // Assert
        var orderItem = order.OrderItems.SingleOrDefault(o => o.ProductId == productId);
        Assert.IsNotNull(orderItem);
        Assert.AreEqual(10m, orderItem.Discount);
        Assert.AreEqual(2, orderItem.Units);
    }

*/
/*
FAILED TEST: The test run failed due to a missing `.NET workload` required to build the project.

**Root Cause:**
- The `maui-tizen` workload is missing, which is required for the project to build and run tests.

**Recommended Fix:**
Run the following command to install the missing workload:

```bash
dotnet workload restore
```

    [TestMethod]
    public void Cancel_order_in_awaiting_validation_status_due_to_stock_rejection()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345"))
            .WithOrderItem(1, "Test Product", 10.0m, 0.0m, "http://example.com/image.jpg")
            .Build();
        order.SetAwaitingValidationStatus();
        var rejectedProductIds = new List<int> { 1 };
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(rejectedProductIds);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.AreEqual("The product items don't have stock: (Test Product).", order.Description);
    }

*/
/*
FAILED TEST: The test run failed because the required `maui-tizen` workload is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Transition_order_from_paid_to_shipped_status()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345")).Build();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
    
        // Act
        order.SetShippedStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.Shipped, order.OrderStatus);
        Assert.AreEqual("The order was shipped.", order.Description);
    }

*/
/*
FAILED TEST: The test run failed because the required `maui-tizen` workload is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Cancel_shipped_order_throws_exception()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345")).Build();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
        order.SetShippedStatus();
    
        // Act & Assert
        Assert.ThrowsException<OrderingDomainException>(() => order.SetCancelledStatus());
    }

*/
/*
FAILED TEST: The test run failed because the required `maui-tizen` workload is missing, which is necessary to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Set_negative_discount_on_existing_order_item_throws_exception()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 0m;
        var pictureUrl = "http://example.com";
        var units = 1;
    
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.AddOrderItem(productId, productName, unitPrice, -1m, pictureUrl, units));
    }

*/
/*
FAILED TEST: The test run failed because the required `maui-tizen` workload is missing, which is needed to build the project.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_order_item_with_discount_greater_than_unit_price_throws_exception()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 15.0m;
        var pictureUrl = "http://example.com";
        var units = 1;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
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
    public void Add_order_item_with_zero_units_throws_exception()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Street", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 0m;
        var pictureUrl = "http://example.com";
        var units = 0;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
    }

*/
}
