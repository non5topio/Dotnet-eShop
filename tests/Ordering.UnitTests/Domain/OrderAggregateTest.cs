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
The test run failed due to a missing **maui-tizen** workload required to build the project.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Cancel_order_in_awaiting_validation_status_due_to_stock_rejection()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new Order("1", "fakeName", address, 1, "1234", "123", "John Doe", DateTime.UtcNow);
        order.OrderStatus = OrderStatus.AwaitingValidation;
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 0;
        var pictureUrl = "http://example.com";
        var units = 1;
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
        var orderStockRejectedItems = new List<int> { productId };
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(orderStockRejectedItems);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.AreEqual($"The product items don't have stock: ({productName}).", order.Description);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed because the required **maui-tizen** workload is missing, preventing the project from building.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_multiple_order_items_same_product_id_same_discount_increases_units()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Main St", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 5.0m;
        var pictureUrl = "http://example.com";
        var units = 1;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        var orderItem = order.OrderItems.SingleOrDefault(i => i.ProductId == productId);
        Assert.IsNotNull(orderItem);
        Assert.AreEqual(unitPrice, orderItem.UnitPrice);
        Assert.AreEqual(discount, orderItem.Discount);
        Assert.AreEqual(2, orderItem.Units);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to a missing **maui-tizen** workload required to build the project.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_multiple_order_items_same_product_id_varying_discounts_updates_with_higher_discount()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Main St", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var pictureUrl = "http://example.com";
        var initialDiscount = 5.0m;
        var higherDiscount = 10.0m;
        var units = 1;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, initialDiscount, pictureUrl, units);
        order.AddOrderItem(productId, productName, unitPrice, higherDiscount, pictureUrl, units);
    
        // Assert
        var orderItem = order.OrderItems.SingleOrDefault(i => i.ProductId == productId);
        Assert.IsNotNull(orderItem);
        Assert.AreEqual(unitPrice, orderItem.UnitPrice);
        Assert.AreEqual(higherDiscount, orderItem.Discount);
        Assert.AreEqual(units, orderItem.Units);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to a missing **maui-tizen** workload required to build the project.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Set_order_status_to_cancelled_when_paid_throws_exception()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new Order("1", "fakeName", address, 1, "1234", "123", "John Doe", DateTime.UtcNow);
        order.OrderStatus = OrderStatus.Paid;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.SetCancelledStatus());
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to a missing **maui-tizen** workload required to build the project.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Set_order_status_to_shipped_when_not_paid_throws_exception()
    {
        // Arrange
        var address = new Address("123 Main St", "City", "State", "Country", "12345");
        var order = new Order("1", "fakeName", address, 1, "1234", "123", "John Doe", DateTime.UtcNow);
        order.OrderStatus = OrderStatus.Submitted;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.SetShippedStatus());
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to a missing **maui-tizen** workload required to build the project.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_order_item_with_discount_equal_to_unit_price_succeeds()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Main St", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 10.0m;
        var pictureUrl = "http://example.com";
        var units = 1;
    
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
FAILED TEST: **Analysis:**  
The test run failed because the required **maui-tizen** workload is missing, preventing the project from building.

**Recommended Fix:**  
Install the missing workload by running:
```bash
dotnet workload restore
```

    [TestMethod]
    public void Add_order_item_with_discount_greater_than_unit_price_throws_exception()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Main St", "City", "State", "Country", "12345")).Build();
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
FAILED TEST: The test run failed due to a missing workload required to build the project. The error indicates that the **maui-tizen** workload is missing.

### **Analysis**
- **Error**: `NETSDK1147: To build this project, the following workloads must be installed: maui-tizen`
- **Cause**: The .NET SDK requires specific workloads to build certain types of projects. The `maui-tizen` workload is needed for this project but is not installed.

### **Recommended Fix**
Run the following command to install the required workload:

```bash
dotnet workload restore
```

This will install the necessary workloads to build the project and allow the tests to run.

    [TestMethod]
    public void Add_order_item_with_zero_units_throws_exception()
    {
        // Arrange
        var order = new OrderBuilder(new Address("123 Main St", "City", "State", "Country", "12345")).Build();
        var productId = 1;
        var productName = "Test Product";
        var unitPrice = 10.0m;
        var discount = 0;
        var pictureUrl = "http://example.com";
        var units = 0;
    
        // Act & Assert
        Assert.Throws<OrderingDomainException>(() => order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units));
    }

*/
}
