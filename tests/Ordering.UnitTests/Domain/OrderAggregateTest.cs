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
The test run failed because the required `maui-tizen` workload is missing, which is necessary to build the project.

**Recommended Fix:**  
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void GetTotal_WithMultipleItemsAndVaryingDiscounts_ShouldCalculateCorrectly()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
    
        // Add first item
        order.AddOrderItem(1, "Product 1", 100.0m, 10, "http://example.com/image1.jpg", 2);
    
        // Add second item
        order.AddOrderItem(2, "Product 2", 50.0m, 5, "http://example.com/image2.jpg", 3);
    
        // Expected total calculation:
        // (100 * 2 * 0.9) + (50 * 3 * 0.95) = 180 + 142.5 = 322.5
        var expectedTotal = 322.5m;
    
        // Act
        var actualTotal = order.GetTotal();
    
        // Assert
        Assert.AreEqual(expectedTotal, actualTotal);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed because the required `maui-tizen` workload is missing, which is necessary to build the project. This is a .NET workload required by the test project.

**Recommended Fix:**  
Run the following command to install the missing workload:

```bash
dotnet workload restore
```

    [TestMethod]
    public void AddOrderItem_WithSameProductIdAndHigherDiscount_ShouldUpdateItem()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
    
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 100.0m;
        var initialDiscount = 10;
        var newDiscount = 15;
        var pictureUrl = "http://example.com/image.jpg";
        var initialUnits = 2;
        var additionalUnits = 3;
    
        // Add initial order item
        order.AddOrderItem(productId, productName, unitPrice, initialDiscount, pictureUrl, initialUnits);
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, newDiscount, pictureUrl, additionalUnits);
    
        // Assert
        var orderItem = order.OrderItems.SingleOrDefault(i => i.ProductId == productId);
        Assert.IsNotNull(orderItem);
        Assert.AreEqual(unitPrice, orderItem.UnitPrice);
        Assert.AreEqual(newDiscount, orderItem.Discount);
        Assert.AreEqual(initialUnits + additionalUnits, orderItem.Units);
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
    public void SetCancelledStatus_WhenOrderIsShipped_ShouldThrowException()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        order.OrderStatus = OrderStatus.Shipped;
    
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
    public void SetShippedStatus_WhenNotInPaidStatus_ShouldThrowException()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        order.OrderStatus = OrderStatus.StockConfirmed;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.SetShippedStatus());
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
    public void SetPaidStatus_WithStockConfirmedStatus_ShouldSetPaid()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        order.OrderStatus = OrderStatus.StockConfirmed;
    
        // Act
        order.SetPaidStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.Paid, order.OrderStatus);
        Assert.IsTrue(order.Description.Contains("The payment was performed at a simulated"));
        Assert.IsTrue(order.DomainEvents.Any(e => e is OrderStatusChangedToPaidDomainEvent));
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
    public void SetCancelledStatusWhenStockIsRejected_WithAwaitingValidationStatus_ShouldSetCancelled()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        order.OrderStatus = OrderStatus.AwaitingValidation;
        
        // Add test order items
        order.AddOrderItem(1, "Product 1", 100.0m, 0, "http://example.com/image1.jpg", 1);
        order.AddOrderItem(2, "Product 2", 100.0m, 0, "http://example.com/image2.jpg", 1);
        order.AddOrderItem(3, "Product 3", 100.0m, 0, "http://example.com/image3.jpg", 1);
        
        var orderStockRejectedItems = new List<int> { 1, 2 };
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(orderStockRejectedItems);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.IsTrue(order.Description.Contains("The product items don't have stock: (Product 1, Product 2)."));
        Assert.IsTrue(order.DomainEvents.Any(e => e is OrderCancelledDomainEvent));
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
    public void AddOrderItem_WithDiscountGreaterThanUnitPrice_ShouldThrowException()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 15.0m; // Changed to decimal to match parameter type
        var pictureUrl = "http://example.com/image.jpg";
        var units = 1;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => 
            order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
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
    public void AddOrderItem_WithNegativeUnits_ShouldThrowException()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 100.0m;
        var discount = 10;
        var pictureUrl = "http://example.com/image.jpg";
        var units = -5;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => 
            order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
    }

*/
/*
FAILED TEST: The test run failed because the required `maui-tizen` workload is missing, preventing the project from building.

**Recommended Fix:**
Run the following command to install the missing workload:
```bash
dotnet workload restore
```

    [TestMethod]
    public void AddOrderItem_WithMaxUnits_ShouldSucceed()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 100.0m;
        var discount = 10;
        var pictureUrl = "http://example.com/image.jpg";
        var units = 9999;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        var orderItem = order.OrderItems.SingleOrDefault(i => i.ProductId == productId);
        Assert.IsNotNull(orderItem);
        Assert.AreEqual(unitPrice, orderItem.UnitPrice);
        Assert.AreEqual(discount, orderItem.Discount);
        Assert.AreEqual(units, orderItem.Units);
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
    public void AddOrderItem_WithZeroDiscount_ShouldSucceed()
    {
        // Arrange
        var address = new AddressBuilder().Build();
        var order = new OrderBuilder(address).Build();
        
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 100.0m;
        var discount = 0m;
        var pictureUrl = "http://example.com/image.jpg";
        var units = 2;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        var orderItem = order.OrderItems.SingleOrDefault(i => i.ProductId == productId);
        Assert.IsNotNull(orderItem);
        Assert.AreEqual(unitPrice, orderItem.UnitPrice);
        Assert.AreEqual(discount, orderItem.Discount);
        Assert.AreEqual(units, orderItem.Units);
    }

*/
}
