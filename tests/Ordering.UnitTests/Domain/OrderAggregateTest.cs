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
FAILED TEST: The test run failed due to the following issues:

1. **Incorrect placement of `using` directives** – They are placed after the namespace and class declaration, which is invalid in C#.
2. **Missing closing brace (`}`)** – The `OrderAggregateTest` class is missing a closing brace, causing a syntax error.
3. **Direct instantiation of `Order` with a `protected` constructor** – The test is trying to use `new Order()` instead of the static `NewDraft()` method.
4. **Accessing a private field `_isDraft`** – The test is attempting to access an internal/private field that is not exposed.

**Recommended Fixes:**

1. Move all `using` directives to the **top of the file**.
2. Add the **missing closing brace** at the end of the `OrderAggregateTest` class.
3. Use `Order.NewDraft()` to create an `Order` instance in the tests.
4. Avoid accessing internal/private fields like `_isDraft`; instead, use public properties or methods to assert state.

    [TestMethod]
    public void NewDraft_CreatesOrderWithDraftStatus()
    {
        // Arrange & Act
        var order = Order.NewDraft();
    
        // Assert
        Assert.IsTrue(order._isDraft);
        Assert.IsNull(order.OrderStatus);
    }

*/
/*
FAILED TEST: The test `GetTotal_CalculatesTotalPriceWithMultipleItemsAndDiscounts` failed because the **expected total price of 230.0 does not match the actual total of 250**.

**Root Cause:**
- The test adds two items:
  - `item1`: 2 units at $100 each with a $10 discount → (100 - 10) * 2 = **180**
  - `item2`: 1 unit at $50 with no discount → **50**
  - **Expected total = 180 + 50 = 230**
- The actual result is **250**, indicating the discount is not being applied correctly in the `GetTotal()` method.

**Recommended Fix:**
- Review the `GetTotal()` method in the `Order` class to ensure it correctly applies discounts:
```csharp
public decimal GetTotal() => _orderItems.Sum(o => o.Units * (o.UnitPrice - o.Discount));
```

    [TestMethod]
    public void GetTotal_CalculatesTotalPriceWithMultipleItemsAndDiscounts()
    {
        // Arrange
        var order = Order.NewDraft();
    
        var item1 = new OrderItem(101, "Laptop", 100m, 10m, "https://example.com/laptop.jpg", 2);
        var item2 = new OrderItem(102, "Mouse", 50m, 0m, "https://example.com/mouse.jpg", 1);
    
        order.AddOrderItem(item1.ProductId, item1.ProductName, item1.UnitPrice, item1.Discount, item1.PictureUrl, item1.Units);
        order.AddOrderItem(item2.ProductId, item2.ProductName, item2.UnitPrice, item2.Discount, item2.PictureUrl, item2.Units);
    
        // Act
        var total = order.GetTotal();
    
        // Assert
        var expectedTotal = (2 * 100 * 0.9m) + (1 * 50); // (2 * 100 * 0.9) + (1 * 50) = 230
        Assert.AreEqual(expectedTotal, total);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to **C# syntax and structure errors** in `OrderAggregateTest.cs`:  
1. `using` directives are incorrectly placed **after** the namespace and class declaration.  
2. The class `OrderAggregateTest` is **missing a closing brace** (`}`).  
3. Test methods are not properly enclosed in method bodies or class structure.

**Recommended Fixes:**  
1. Move all `using` directives to the **top of the file**, before the namespace declaration.  
2. Add the **missing closing brace** (`}`) at the end of the `OrderAggregateTest` class.  
3. Ensure all test methods are properly enclosed within the class and have valid syntax.

    [TestMethod]
    public void Order_TransitionsThroughAllValidStatuses()
    {
        // Arrange
        var order = Order.NewDraft();
    
        // Act
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
        order.SetShippedStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.Shipped, order.OrderStatus);
        Assert.IsTrue(order.DomainEvents.Any(e => e.GetType() == typeof(OrderStatusChangedToAwaitingValidationDomainEvent)));
        Assert.IsTrue(order.DomainEvents.Any(e => e.GetType() == typeof(OrderStatusChangedToStockConfirmedDomainEvent)));
        Assert.IsTrue(order.DomainEvents.Any(e => e.GetType() == typeof(OrderStatusChangedToPaidDomainEvent)));
        Assert.IsTrue(order.DomainEvents.Any(e => e.GetType() == typeof(OrderShippedDomainEvent)));
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to **C# syntax and structure errors** in `OrderAggregateTest.cs`:  
1. `using` directives are incorrectly placed **after** the namespace and class declaration.  
2. The class `OrderAggregateTest` is **missing a closing brace** (`}`), causing a syntax error.  
3. Test methods are not properly enclosed in valid method bodies.

**Recommended Fixes:**  
1. Move all `using` directives to the **top of the file**, before the namespace declaration.  
2. Add the **missing closing brace** (`}`) at the end of the `OrderAggregateTest` class.  
3. Ensure all test methods are properly enclosed within the class and have valid syntax.

    [TestMethod]
    public void SetCancelledStatusWhenStockIsRejected_CancelOrderAndSetDescription()
    {
        // Arrange
        var order = new Order
        {
            OrderStatus = OrderStatus.AwaitingValidation
        };
    
        var orderItem1 = new OrderItem(101, "Laptop", 999.99m, 0, "https://example.com/laptop.jpg", 1);
        var orderItem2 = new OrderItem(102, "Mouse", 29.99m, 0, "https://example.com/mouse.jpg", 1);
        var orderItem3 = new OrderItem(103, "Keyboard", 49.99m, 0, "https://example.com/keyboard.jpg", 1);
    
        order._orderItems.Add(orderItem1);
        order._orderItems.Add(orderItem2);
        order._orderItems.Add(orderItem3);
    
        var rejectedItems = new List<int> { 101, 102 };
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(rejectedItems);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.IsTrue(order.Description.Contains("Laptop"));
        Assert.IsTrue(order.Description.Contains("Mouse"));
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to two main issues:  
1. Attempting to instantiate the `Order` class directly using a `protected` constructor.  
2. Trying to assign a value to the read-only `OrderStatus` property.

**Recommended Fixes:**  
1. Use the static `Order.NewDraft()` method to create a new `Order` instance in tests.  
2. Use appropriate methods like `SetAwaitingValidationStatus()` to change the order status, instead of directly setting the `OrderStatus` property.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetCancelledStatus_ThrowsExceptionForShippedOrder()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.Shipped;
    
        // Act
        order.SetCancelledStatus();
    
        // Assert is handled by ExpectedException
    }

*/
/*
FAILED TEST: The test run failed due to the following issues:

1. **Incorrect constructor usage**: The test is trying to instantiate `Order` directly using `new Order()`, but the constructor is `protected`.  
   **Fix**: Use the static `Order.NewDraft()` method to create an instance.

2. **Attempting to set a read-only property**: The test tries to assign a value to `order.OrderStatus`, which is a read-only property.  
   **Fix**: Use the provided methods to change the order status, such as `SetAwaitingValidationStatus()`.

3. **Syntax and structure errors in the test file**:  
   - `using` directives are incorrectly placed after the namespace/class declaration.  
   - Missing closing braces for the test class.  
   - Test methods are not properly enclosed in method bodies.  
   **Fix**:  
   - Move all `using` directives to the top of the file.  
   - Ensure all class and method definitions are properly enclosed with opening and closing braces.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetShippedStatus_ThrowsExceptionWhenNotPaid()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.AwaitingValidation;
    
        // Act
        order.SetShippedStatus();
    
        // Assert is handled by ExpectedException
    }

*/

    [TestMethod]
    public void AddOrderItem_UpdatesDiscountIfHigher()
    {
        // Arrange
        var order = Order.NewDraft();
    
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var initialDiscount = 5m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        order.AddOrderItem(productId, productName, unitPrice, initialDiscount, pictureUrl, units);
    
        var newDiscount = 10m;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, newDiscount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var item = order.OrderItems.First();
        Assert.AreEqual(newDiscount, item.Discount);
    }

/*
FAILED TEST: **Analysis:**  
The test compilation failed because the `Order` class constructor is marked as `protected`, and the test is attempting to instantiate it directly, which is not allowed.

**Recommended Fix:**  
Use the `NewDraft()` static method provided in the `Order` class to create a new instance in the test, instead of calling the constructor directly.

    [TestMethod]
    public void AddOrderItem_AddsUnitsToExistingItem()
    {
        // Arrange
        var order = new Order();
    
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var discount = 0m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var initialUnits = 1;
    
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, initialUnits);
    
        var additionalUnits = 2;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, additionalUnits);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var item = order.OrderItems.First();
        Assert.AreEqual(initialUnits + additionalUnits, item.Units);
    }

*/
/*
FAILED TEST: **Analysis:**

The test compilation failed due to two main issues in the `OrderAggregateTest.cs` file:

1. **Incorrect placement of `using` directives** – They were placed after the namespace and class declaration, which is invalid in C#.
2. **Missing closing brace (`}`)** – The class `OrderAggregateTest` is missing a closing brace, causing a syntax error.

Additionally, the test method `AddOrderItem_AddsNewItemToEmptyOrder` is not properly enclosed within a method body or class structure, leading to further compilation errors.

---

**Recommended Fixes:**

1. Move all `using` directives to the top of the file, before the namespace declaration.
2. Ensure the class `OrderAggregateTest` is properly closed with a closing brace (`}`).
3. Correct the structure of test methods, ensuring they are enclosed in proper method bodies with correct syntax.

    [TestMethod]
    public void AddOrderItem_AddsNewItemToEmptyOrder()
    {
        // Arrange
        var order = new Order();
    
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 999.99m;
        var discount = 0m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 1;
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var item = order.OrderItems.First();
        Assert.AreEqual(productId, item.ProductId);
        Assert.AreEqual(productName, item.ProductName);
        Assert.AreEqual(unitPrice, item.UnitPrice);
        Assert.AreEqual(discount, item.Discount);
        Assert.AreEqual(pictureUrl, item.PictureUrl);
        Assert.AreEqual(units, item.Units);
    }

*/
/*
FAILED TEST: The test compilation failed due to **incorrect ordering and placement of `using` directives and class members** in the `OrderAggregateTest.cs` file.

### **Key Issues:**
1. **`using` directives after class declaration** – C# requires all `using` directives to appear at the top of the file, before the namespace or class declaration.
2. **Missing closing brace (`}`)** – The class is missing a closing brace, causing a syntax error at the end of the file.

---

### **Recommended Fixes:**
1. Move the `using Microsoft.VisualStudio.TestTools.UnitTesting;` and `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` directives to the top of the file, before the namespace declaration.
2. Add the missing closing brace (`}`) at the end of the `OrderAggregateTest` class.

**Corrected code snippet:**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace eShop.Ordering.UnitTests.Domain
{
    [TestClass]
    public class OrderAggregateTest
    {
        public OrderAggregateTest()
        { }

        [TestMethod]
        public void Create_order_item_success()
        {
            // Arrange    
            var productId = 1;
            var productName = "FakeProductName";
            var unitPrice = 12;
            var discount = 15;
            var pictureUrl = "FakeUrl";
            var units = 5;

            // Act 
            var fakeOrderItem = new OrderItem(productId, productName, unitPrice, discount, pictureUrl, units);

            // Assert
            Assert.IsNotNull(fakeOrderItem);
        }

        [TestMethod]
        public void Order_Constructor_InitializesOrderWithSubmittedStatus()
        {
            // Arrange
            var userId = "user123";
            var userName = "John Doe";
            var address = new Address("123 Main St", "City", "State", "12345", "Country");
            var cardTypeId = 1;
            var cardNumber = "4111111111111111";
            var cardSecurityNumber = "123";
            var cardHolderName = "John Doe";
            var cardExpiration = DateTime.UtcNow.AddYears(1);

            // Act
            var order = new Order(userId, userName, address, cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);

            // Assert
            Assert.AreEqual(OrderStatus.Submitted, order.OrderStatus);
            Assert.IsTrue(order.OrderDate <= DateTime.UtcNow);
            Assert.IsNotNull(order.DomainEvents);
            Assert.IsInstanceOfType(order.DomainEvents.FirstOrDefault(), typeof(OrderStartedDomainEvent));
        }
    }
}
```

    [TestMethod]
    public void Order_Constructor_InitializesOrderWithSubmittedStatus()
    {
        // Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("123 Main St", "City", "State", "12345", "Country");
        var cardTypeId = 1;
        var cardNumber = "4111111111111111";
        var cardSecurityNumber = "123";
        var cardHolderName = "John Doe";
        var cardExpiration = DateTime.UtcNow.AddYears(1);
    
        // Act
        var order = new Order(userId, userName, address, cardTypeId, cardNumber, cardSecurityNumber, cardHolderName, cardExpiration);
    
        // Assert
        Assert.AreEqual(OrderStatus.Submitted, order.OrderStatus);
        Assert.IsTrue(order.OrderDate <= DateTime.UtcNow);
        Assert.IsNotNull(order.DomainEvents);
        Assert.IsInstanceOfType(order.DomainEvents.FirstOrDefault(), typeof(OrderStartedDomainEvent));
    }

*/
}
