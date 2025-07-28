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
/*
FAILED TEST: **Analysis:**

1. **Duplicate Using Directive**  
   - **Location:** `OrderAggregateTest.cs` line 7  
   - **Error:** `CS0105: The using directive for 'eShop.Ordering.Domain.AggregatesModel.OrderAggregate' appeared previously in this namespace`  
   - **Fix:** Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive.

2. **Read-Only Property Assignment**  
   - **Location:** Multiple locations in `OrderAggregateTest.cs` (e.g., line 37, 38, etc.)  
   - **Error:** `CS0200: Property or indexer 'Order.OrderStatus' cannot be assigned to -- it is read only`  
   - **Fix:** Replace direct assignments like `order.OrderStatus = ...` with the appropriate state transition methods (e.g., `order.SetAwaitingValidationStatus();`).

3. **Test Failure: `CalculateTotalPriceWithMultipleItemsAndDiscounts`**  
   - **Error:** `Assert.AreEqual failed. Expected:<280>. Actual:<400>.`  
   - **Fix:** Review the logic in the test and ensure the expected total price matches the actual calculation based on item prices and discounts.

**Recommended Fixes:**

- Remove the duplicate `using` directive from the top of `OrderAggregateTest.cs`.
- Replace all direct assignments to `OrderStatus` with the appropriate state transition methods (e.g., `SetAwaitingValidationStatus()`).
- Correct the expected value in the `CalculateTotalPriceWithMultipleItemsAndDiscounts` test to match the actual computed total.

    [TestMethod]
    public void CalculateTotalPriceWithMultipleItemsAndDiscounts()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
    
        order.AddOrderItem(101, "Item1", 100m, 10, "https://example.com/item1.jpg", 2);
        order.AddOrderItem(102, "Item2", 200m, 0, "https://example.com/item2.jpg", 1);
    
        // Act
        var total = order.GetTotal();
    
        // Assert
        Assert.AreEqual(280m, total);
    }

*/
/*
FAILED TEST: The test run failed due to a **duplicate using directive** in the `OrderAggregateTest.cs` file. Specifically, the directive `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` is declared more than once in the same namespace, which is not allowed in C#.

**Recommended Fix:**
- Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive from the top of the `OrderAggregateTest.cs` file, keeping only one instance.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetPaidStatusFromInvalidState()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        order.SetStockConfirmedStatus(); // Transition to StockConfirmed
    
        // Act
        order.SetPaidStatus();
    
        // Assert is handled by ExpectedException
    }

*/
/*
FAILED TEST: **Analysis:**
The test run failed due to two issues in `OrderAggregateTest.cs`:
1. A **duplicate using directive** for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate`.
2. An attempt to **directly assign a read-only property** `OrderStatus`.

**Recommended Fixes:**
1. Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive.
2. Replace `order.OrderStatus = ...` with the appropriate method, such as `order.SetAwaitingValidationStatus();`.

    [TestMethod]
    public void SetStockConfirmedStatusFromAwaitingValidation()
    {
        // Arrange
        var order = Order.NewDraft();
        order.OrderStatus = OrderStatus.AwaitingValidation;
        order.AddOrderItem(101, "Laptop", 999.99m, 0, "https://example.com/laptop.jpg", 1);
    
        // Act
        order.SetStockConfirmedStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.StockConfirmed, order.OrderStatus);
        Assert.AreEqual("All the items were confirmed with available stock.", order.Description);
        Assert.IsNotNull(order.DomainEvents.OfType<OrderStatusChangedToStockConfirmedDomainEvent>().FirstOrDefault());
    }

*/
/*
FAILED TEST: The test run failed due to two issues in `OrderAggregateTest.cs`:

1. **Duplicate Using Directive**  
   - **Location:** Line 7  
   - **Error:** `CS0105`  
   - **Fix:** Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive.

2. **Attempting to Assign to a Read-Only Property**  
   - **Location:** Line 37  
   - **Error:** `CS0200`  
   - **Fix:** Replace `order.OrderStatus = OrderStatus.AwaitingValidation;` with `order.SetAwaitingValidationStatus();`.

**Recommended Fixes:**
- Remove the duplicate `using` directive.
- Use the appropriate method (`SetAwaitingValidationStatus()`) to change the order status instead of direct assignment.

    [TestMethod]
    public void SetCancelledStatusWhenStockIsRejected()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        order.OrderStatus = OrderStatus.AwaitingValidation;
        order.AddOrderItem(101, "Laptop", 999.99m, 0, "https://example.com/laptop.jpg", 1);
        order.AddOrderItem(102, "Mouse", 29.99m, 0, "https://example.com/mouse.jpg", 1);
        var rejectedItems = new List<int> { 101 };
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(rejectedItems);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.AreEqual("The product items don't have stock: (Laptop).", order.Description);
    }

*/
/*
FAILED TEST: The test run failed due to the following issues:

1. **Duplicate Using Directive**  
   - **Location:** `OrderAggregateTest.cs` line 7  
   - **Error:** `CS0105`  
   - **Fix:** Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive.

2. **Attempting to Assign to a Read-Only Property**  
   - **Location:** `OrderAggregateTest.cs` line 38  
   - **Error:** `CS0200`  
   - **Fix:** Replace `order.OrderStatus = ...` with the appropriate method like `order.SetAwaitingValidationStatus();`.

**Recommended Fixes:**
- Remove the duplicate `using` directive.
- Replace direct assignments to `OrderStatus` with the correct state transition methods (e.g., `SetAwaitingValidationStatus()`).

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetCancelledStatusFromPaidState()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        order.OrderStatus = OrderStatus.Paid;
    
        // Act
        order.SetCancelledStatus();
    
        // Assert is handled by ExpectedException
    }

*/
/*
FAILED TEST: The test run failed due to two main issues in the `OrderAggregateTest.cs` file:

1. **Duplicate Using Directive**  
   - **Error:** `CS0105: The using directive for 'eShop.Ordering.Domain.AggregatesModel.OrderAggregate' appeared previously in this namespace`  
   - **Fix:** Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive at the top of the file.

2. **Attempting to Assign to a Read-Only Property**  
   - **Error:** `CS0200: Property or indexer 'Order.OrderStatus' cannot be assigned to -- it is read only`  
   - **Fix:** Replace the direct assignment `order.OrderStatus = OrderStatus.AwaitingValidation;` with the appropriate method to change the status, such as `order.SetAwaitingValidationStatus();`.

**Recommended Actions:**
- Remove the duplicate `using` directive.
- Replace `order.OrderStatus = ...` with the correct state transition method (e.g., `SetAwaitingValidationStatus()`).

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetShippedStatusFromInvalidState()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        order.OrderStatus = OrderStatus.AwaitingValidation;
    
        // Act
        order.SetShippedStatus();
    
        // Assert is handled by ExpectedException
    }

*/
/*
FAILED TEST: The test run failed due to a **duplicate using directive** in the `OrderAggregateTest.cs` file. The directive `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` is declared more than once in the same namespace, which is not allowed in C#.

### **Recommended Fix**
Remove the duplicate `using` directive from the top of the `OrderAggregateTest.cs` file, keeping only one instance.

    [TestMethod]
    public void AddOrderItemWithLowerDiscount()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var discount = 15;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Act
        var newUnits = 2;
        var newDiscount = 10;
        order.AddOrderItem(productId, productName, unitPrice, newDiscount, pictureUrl, newUnits);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(discount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(3, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to a **duplicate using directive** in the `OrderAggregateTest.cs` file. The directive `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` is declared more than once in the same namespace, which is not allowed in C#.

### **Recommended Fix**
Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive from the top of the `OrderAggregateTest.cs` file, keeping only one instance.

    [TestMethod]
    public void AddOrderItemWithHigherDiscount()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var discount = 10;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Act
        var newUnits = 2;
        var newDiscount = 15;
        order.AddOrderItem(productId, productName, unitPrice, newDiscount, pictureUrl, newUnits);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(newDiscount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(3, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to a **duplicate using directive** in the `OrderAggregateTest.cs` file:  
> `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` appears twice.

**Recommended Fix:**  
Remove the duplicate `using` directive from the top of the file, keeping only one instance.

    [TestMethod]
    public void AddOrderItemWithSameProductId()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var discount = 10;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Act
        var newUnits = 2;
        var newDiscount = 15;
        order.AddOrderItem(productId, productName, unitPrice, newDiscount, pictureUrl, newUnits);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(newDiscount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(3, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to a **duplicate using directive** in the `OrderAggregateTest.cs` file:

> `error CS0105: The using directive for 'eShop.Ordering.Domain.AggregatesModel.OrderAggregate' appeared previously in this namespace`

### **Analysis**
The file contains two identical `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directives, which is not allowed in C#.

### **Recommended Fix**
Remove the duplicate `using` directive from the top of the `OrderAggregateTest.cs` file. Keep only one instance of the directive.

    [TestMethod]
    public void AddNewOrderItemToEmptyOrder()
    {
        // Arrange
        var order = new Order("user1", "User One", new Address(), 1, "1234567890123456", "123", "John Doe", DateTime.UtcNow);
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var discount = 0;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(discount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(units, order.OrderItems.First().Units);
    }

*/
}
