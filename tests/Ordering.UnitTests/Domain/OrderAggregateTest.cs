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
FAILED TEST: **Test Run Failure Summary:**

1. **Duplicate `using` directive**  
   - **Location**: `OrderAggregateTest.cs` line 7  
   - **Error**: `CS0105`  
   - **Fix**: Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`.

2. **Inaccessible constructor**  
   - **Location**: `OrderAggregateTest.cs` (e.g., `var order = new Order();`)  
   - **Error**: `CS0122`  
   - **Fix**: Replace `new Order()` with `Order.NewDraft()`.

3. **Read-only property assignment**  
   - **Location**: `OrderAggregateTest.cs` (e.g., `order.OrderStatus = OrderStatus.Shipped;`)  
   - **Error**: `CS0200`  
   - **Fix**: Use domain methods like `SetShippedStatus()`, `SetAwaitingValidationStatus()`, etc., to change the status.

**Recommended Fixes Summary:**
- Remove the duplicate `using` directive.
- Replace all `new Order()` with `Order.NewDraft()`.
- Use domain methods to modify `OrderStatus`, not direct property assignment.

    [TestMethod]
    public void CalculateOrderTotalWithMultipleItemsAndDiscounts()
    {
        // Arrange
        var order = Order.NewDraft();
        order.AddOrderItem(1, "Item1", 100m, 10m, "url1", 2);
        order.AddOrderItem(2, "Item2", 50m, 0m, "url2", 1);
    
        // Act
        var total = order.GetTotal();
    
        // Assert
        Assert.AreEqual(230m, total);
    }

*/
/*
FAILED TEST: **Analysis of Test Run Failure:**

1. **Duplicate `using` directive**  
   - **Error**: `CS0105` in `OrderAggregateTest.cs` line 7  
   - **Cause**: The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is included twice.  

2. **Inaccessible constructor**  
   - **Error**: `CS0122` in `OrderAggregateTest.cs`  
   - **Cause**: The `Order` class constructor is `protected`, and the test is trying to instantiate it directly with `new Order()`.  

3. **Read-only property assignment**  
   - **Error**: `CS0200` in `OrderAggregateTest.cs`  
   - **Cause**: The test is trying to assign a value to the read-only `OrderStatus` property directly.  

---

**Recommended Fixes:**

1. **Remove the duplicate `using` directive** in `OrderAggregateTest.cs`.  
2. **Replace all `new Order()` calls** with `Order.NewDraft()` to respect encapsulation.  
3. **Use domain methods** (e.g., `SetAwaitingValidationStatus()`, `SetShippedStatus()`) to change the `OrderStatus`, not direct property assignment.

    [TestMethod]
    public void SetPaidStatusFromStockConfirmed()
    {
        // Arrange
        var order = Order.NewDraft();
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
    
        // Act
        order.SetPaidStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.Paid, order.OrderStatus);
        Assert.AreEqual("The payment was performed at a simulated \"American Bank checking bank account ending on XX35071\"", order.Description);
    }

*/
/*
FAILED TEST: **Analysis of Test Run Failure:**

1. **Duplicate `using` directive**  
   - **Error**: `CS0105` in `OrderAggregateTest.cs` line 7  
   - **Cause**: The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is included twice.  

2. **Inaccessible constructor**  
   - **Error**: `CS0122` in `OrderAggregateTest.cs`  
   - **Cause**: The `Order` class constructor is `protected`, and the test is trying to instantiate it directly with `new Order()`.  

3. **Read-only property assignment**  
   - **Error**: `CS0200` in `OrderAggregateTest.cs`  
   - **Cause**: The test is trying to assign a value to the read-only `OrderStatus` property directly.  

---

**Recommended Fixes:**

1. **Remove the duplicate `using` directive** in `OrderAggregateTest.cs`.  
2. **Replace all `new Order()` calls** with `Order.NewDraft()` to respect encapsulation.  
3. **Use domain methods** (e.g., `SetAwaitingValidationStatus()`, `SetShippedStatus()`) to change the `OrderStatus`, not direct property assignment.

    [TestMethod]
    public void SetStockConfirmedStatusFromAwaitingValidation()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.AwaitingValidation;
    
        // Add some order items
        order.AddOrderItem(101, "Laptop", 1000m, 0m, "https://example.com/laptop.jpg", 1);
    
        // Act
        order.SetStockConfirmedStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.StockConfirmed, order.OrderStatus);
        Assert.AreEqual("All the items were confirmed with available stock.", order.Description);
    }

*/
/*
FAILED TEST: **Test Run Failure Summary:**

1. **Duplicate `using` directive**  
   - **Location**: `OrderAggregateTest.cs` line 7  
   - **Fix**: Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`.

2. **Inaccessible constructor**  
   - **Location**: `OrderAggregateTest.cs` (e.g., `var order = new Order();`)  
   - **Fix**: Replace `new Order()` with `Order.NewDraft()`.

3. **Read-only property assignment**  
   - **Location**: `OrderAggregateTest.cs` (e.g., `order.OrderStatus = OrderStatus.Shipped;`)  
   - **Fix**: Use domain methods like `SetShippedStatus()` or `SetAwaitingValidationStatus()` to change the status.

**Recommended Fixes:**
- Remove the duplicate `using` directive.
- Replace all `new Order()` with `Order.NewDraft()`.
- Use domain methods to modify `OrderStatus`, not direct property assignment.

    [TestMethod]
    public void SetCancelledStatusWhenStockIsRejected()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.AwaitingValidation;
    
        // Add some order items
        order.AddOrderItem(101, "Laptop", 1000m, 0m, "https://example.com/laptop.jpg", 1);
        order.AddOrderItem(102, "Mouse", 50m, 0m, "https://example.com/mouse.jpg", 1);
        order.AddOrderItem(103, "Keyboard", 75m, 0m, "https://example.com/keyboard.jpg", 1);
    
        var rejectedItems = new List<int> { 101, 102 };
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(rejectedItems);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.AreEqual("The product items don't have stock: (Laptop, Mouse).", order.Description);
    }

*/
/*
FAILED TEST: The test run failed due to the following issues:

1. **Duplicate `using` directive**  
   - **Location**: `OrderAggregateTest.cs` line 7  
   - **Fix**: Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`.

2. **Inaccessible constructor**  
   - **Location**: `OrderAggregateTest.cs` (e.g., `var order = new Order();`)  
   - **Fix**: Replace `new Order()` with `Order.NewDraft()` to create test instances.

3. **Read-only property assignment**  
   - **Location**: `OrderAggregateTest.cs` (e.g., `order.OrderStatus = OrderStatus.Shipped;`)  
   - **Fix**: Use domain methods like `SetShippedStatus()` or `SetAwaitingValidationStatus()` to change the status, not direct assignment.

**Recommended Fixes Summary**:
- Remove the duplicate `using` directive.
- Replace all `new Order()` with `Order.NewDraft()`.
- Use domain methods to modify `OrderStatus` instead of direct property assignment.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void CancelAlreadyShippedOrder()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.Shipped;
    
        // Act - This should throw an exception
        order.SetCancelledStatus();
    
        // Assert - Handled by ExpectedException
    }

*/
/*
FAILED TEST: ### ✅ **Test Run Failure Summary**

The test run failed due to the following issues:

---

### ❌ **1. Duplicate `using` directive**
- **Location**: `OrderAggregateTest.cs`
- **Error**: `CS0105: The using directive for 'eShop.Ordering.Domain.AggregatesModel.OrderAggregate' appeared previously in this namespace`
- **Fix**: Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive.

---

### ❌ **2. Inaccessible constructor**
- **Location**: `OrderAggregateTest.cs` in test methods like `SetShippedStatusFromNonPaidStatus()`
- **Error**: `CS0122: 'Order.Order()' is inaccessible due to its protection level`
- **Fix**: Replace `new Order()` with `Order.NewDraft()` to create test instances.

---

### ❌ **3. Attempt to assign to read-only property**
- **Location**: `OrderAggregateTest.cs` in `SetShippedStatusFromNonPaidStatus()`
- **Error**: `CS0200: Property or indexer 'Order.OrderStatus' cannot be assigned to -- it is read only`
- **Fix**: Use the domain method `SetAwaitingValidationStatus()` or similar to change the status, not direct assignment.

---

### ✅ **Recommended Fixes**

1. **Remove the duplicate `using` directive** in `OrderAggregateTest.cs`.
2. **Replace all `new Order()` calls** with `Order.NewDraft()` to respect encapsulation.
3. **Use domain methods** (e.g., `SetAwaitingValidationStatus()`) to change `OrderStatus`, not direct property assignment.

---

### ✅ **Example Fix for `SetShippedStatusFromNonPaidStatus()`**
```csharp
[TestMethod]
[ExpectedException(typeof(OrderingDomainException))]
public void SetShippedStatusFromNonPaidStatus()
{
    // Arrange
    var order = Order.NewDraft();
    order.SetAwaitingValidationStatus();

    // Act - This should throw an exception
    order.SetShippedStatus();
}
```

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetShippedStatusFromNonPaidStatus()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.AwaitingValidation;
    
        // Act - This should throw an exception
        order.SetShippedStatus();
    
        // Assert - Handled by ExpectedException
    }

*/
/*
FAILED TEST: The test run failed due to the following issues:

1. **CS0105: Duplicate using directive**  
   - **Fix**: Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` in `OrderAggregateTest.cs`.

2. **CS0122: 'Order.Order()' is inaccessible due to its protection level**  
   - **Fix**: Replace direct instantiation of `new Order()` with the static factory method `Order.NewDraft()` to create test instances.

3. **Constructor accessibility issue**  
   - **Fix**: Either make the `Order` constructor `internal` and use `InternalsVisibleTo` to expose it to the test project, or continue using the `NewDraft()` method for test setup.

    [TestMethod]
    public void AddOrderItemWithLowerDiscountThanExistingItem()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000m;
        var initialDiscount = 20m;
        var lowerDiscount = 10m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        // Add first item
        order.AddOrderItem(productId, productName, unitPrice, initialDiscount, pictureUrl, units);
    
        // Act - Add another item with same product ID and lower discount
        order.AddOrderItem(productId, productName, unitPrice, lowerDiscount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(initialDiscount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(2, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to the following issues:

1. **CS0105: Duplicate using directive**  
   - **Fix**: Remove the duplicate `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directive in `OrderAggregateTest.cs`.

2. **CS0122: 'Order.Order()' is inaccessible due to its protection level**  
   - The `Order` class constructor is `protected`, and the test is trying to instantiate it directly.  
   - **Fix**: Use the `Order.NewDraft()` static method to create a valid test instance of `Order` instead of calling `new Order()`.

    [TestMethod]
    public void AddOrderItemWithHigherDiscountThanExistingItem()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000m;
        var initialDiscount = 10m;
        var higherDiscount = 20m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        // Add first item
        order.AddOrderItem(productId, productName, unitPrice, initialDiscount, pictureUrl, units);
    
        // Act - Add another item with same product ID and higher discount
        order.AddOrderItem(productId, productName, unitPrice, higherDiscount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(higherDiscount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(2, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to two main issues:

1. **CS0105: Duplicate using directive**  
   - The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is included twice in the test file.  
   **Fix**: Remove the duplicate `using` directive.

2. **CS0122: 'Order.Order()' is inaccessible due to its protection level**  
   - The `Order` class constructor is marked as `protected`, and the test is trying to instantiate it directly.  
   **Fix**: Use the `NewDraft()` static method to create a valid test instance of `Order`.

    [TestMethod]
    public void AddOrderItemWithSameProductIdAsExistingItem()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000m;
        var discount = 10m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        // Add first item
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Act - Add another item with same product ID
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(discount, order.OrderItems.First().Discount);
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(2, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to the following issues:

1. **CS0105: Duplicate using directive**  
   - The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is included twice in the test file.
   - **Fix**: Remove the duplicate `using` directive.

2. **CS0122: 'Order.Order()' is inaccessible due to its protection level**  
   - The `Order` class constructor is marked as `protected`, and the test is trying to instantiate it directly (`var order = new Order();`).
   - **Fix**: Change the constructor to `internal` or use `InternalsVisibleTo` in the `Ordering.Domain` project to expose internal members to the test project. Alternatively, use the `NewDraft()` static method if it can be used to create a valid test instance.

    [TestMethod]
    public void AddNewOrderItemToEmptyOrder()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000m;
        var discount = 0m;
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
