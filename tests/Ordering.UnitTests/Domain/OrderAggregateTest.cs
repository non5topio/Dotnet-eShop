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
The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`, including:
- `using` directives placed **after** the namespace declaration.
- Missing **opening `{`** after the class declaration.
- Missing **closing `}`** for the class and method bodies.
- Direct instantiation of the `Order` class using `new Order()`, which has a `protected` constructor.

**Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the the class with appropriate **`}`**.
4. Replace `new Order()` with `Order.NewDraft()` in test methods.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void CancelOrderThatIsAlreadyPaid()
    {
        // Arrange
        var order = Order.NewDraft();
        order.SetPaymentMethodVerified(1, 1);
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
    
        // Act
        order.SetCancelledStatus();
    
        // Assert is handled by ExpectedException
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`, including:
- `using` directives placed **after** the namespace declaration.
- Missing **opening `{`** after the class declaration.
- Missing **closing `}`** for the class and method bodies.
- Direct instantiation of the `Order` class using `new Order()`, which has a `protected` constructor.

**Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the the class with appropriate **`}`**.
4. Replace `new Order()` with `Order.NewDraft()` in test methods.

    [TestMethod]
    public void CalculateTotalPriceWithMultipleItemsAndDiscounts()
    {
        // Arrange
        var order = Order.NewDraft();
        var item1 = new OrderItem(1, "Item1", 100.00m, 10.00m, "url1", 2);
        var item2 = new OrderItem(2, "Item2", 50.00m, 0.00m, "url2", 1);
    
        var field = typeof(Order).GetField("_orderItems", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        var orderItems = (List<OrderItem>)field.GetValue(order);
        orderItems.Clear();
        orderItems.Add(item1);
        orderItems.Add(item2);
    
        // Act
        var total = order.GetTotal();
    
        // Assert
        Assert.AreEqual(230.00m, total);
    }

*/
/*
FAILED TEST: The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`:

### **Root Cause:**
- `using` directives are placed **after** the namespace declaration.
- Missing **opening `{`** after the class declaration.
- Missing **closing `}`** for the class and method bodies.
- Direct instantiation of `Order` class using `new Order()`, which has a `protected` constructor.

### **Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the the class with appropriate **`}`**.
4. Replace `new Order()` with `Order.NewDraft()` in test methods.

    [TestMethod]
    public void SetOrderStatusToCancelledWhenStockIsRejected()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.AwaitingValidation;
        var orderStockRejectedItems = new List<int> { 101, 102 };
        var orderItems = new List<OrderItem>
        {
            new OrderItem(101, "Laptop", 1000.00m, 0, "https://example.com/laptop.jpg", 1),
            new OrderItem(102, "Mouse", 50.00m, 0, "https://example.com/mouse.jpg", 1)
        };
    
        // Bypass the private field and assign the list to the Order
        var field = typeof(Order).GetField("_orderItems", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        field.SetValue(order, orderItems);
    
        // Act
        order.SetCancelledStatusWhenStockIsRejected(orderStockRejectedItems);
    
        // Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.AreEqual("The product items don't have stock: (Laptop, Mouse).", order.Description);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`, including:
- `using` directives placed **after** the namespace declaration.
- Missing **opening `{`** after the class declaration.
- Missing **closing `}`** for the class and method bodies.
- Attempting to instantiate the `Order` class directly, which has a `protected` constructor.

**Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the the class with appropriate **`}`**.
4. Replace `new Order()` with `Order.NewDraft()` in test methods.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void CancelOrderThatIsAlreadyShipped()
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
FAILED TEST: The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`:

### **Root Cause:**
- `using` directives are placed **after** the namespace declaration.
- Missing **opening `{`** after the class declaration.
- Missing **closing `}`** for the class and methods.
- Attempting to instantiate the `Order` class directly, which has a `protected` constructor and should be created using the `NewDraft()` factory method.

### **Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the the class with appropriate **`}`**.
4. Replace `new Order()` with `Order.NewDraft()` in test methods.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void SetOrderStatusFromSubmittedToShipped_InvalidTransition()
    {
        // Arrange
        var order = new Order
        {
            OrderStatus = OrderStatus.Submitted
        };
    
        // Act
        order.SetShippedStatus();
    
        // Assert is handled by ExpectedException
    }

*/
/*
FAILED TEST: The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`:

### **Root Cause:**
- `using` directives are placed **after** the namespace declaration.
- Missing **opening `{`** after the class declaration.
- Missing **closing `}`** for the class and methods.
- Unclosed methods and class body causing **compilation failure**.

### **Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the the class with appropriate **`}`**.
4. Ensure all methods are properly enclosed within the class body.

    [TestMethod]
    public void SetOrderStatusFromStockConfirmedToShipped()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.StockConfirmed;
    
        // Act
        order.SetShippedStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.Shipped, order.OrderStatus);
        Assert.IsNotNull(order.DomainEvents.OfType<OrderShippedDomainEvent>().FirstOrDefault());
        Assert.AreEqual("The order was shipped.", order.Description);
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed due to **C# syntax errors** in `OrderAggregateTest.cs`, including:
- `using` directives placed **after** the namespace declaration.
- Missing **opening `{** after the class declaration.
- Missing **closing `}`** for the class and methods.
- Unclosed methods and class body causing compilation failure.

**Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing **`{`** after `public class OrderAggregateTest`.
3. Close all open methods and the class with appropriate **`}`**.
4. Ensure all methods are properly enclosed within the class body.

    [TestMethod]
    public void SetOrderStatusFromSubmittedToAwaitingValidation()
    {
        // Arrange
        var order = new Order();
        order.OrderStatus = OrderStatus.Submitted;
    
        // Act
        order.SetAwaitingValidationStatus();
    
        // Assert
        Assert.AreEqual(OrderStatus.AwaitingValidation, order.OrderStatus);
        Assert.IsNotNull(order.DomainEvents.OfType<OrderStatusChangedToAwaitingValidationDomainEvent>().FirstOrDefault());
    }

*/
/*
FAILED TEST: **Analysis:**  
The test run failed because the `Order` class constructor is marked as `protected`, making it inaccessible from the test code. The test attempts to instantiate `Order` directly, which is not allowed.

**Recommended Fix:**  
Refactor the test to use the `NewDraft()` static factory method provided by the `Order` class instead of directly invoking the constructor.

    [TestMethod]
    public void AddOrderItemWithSameProductIdAndLowerDiscount()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000.00m;
        var discount = 20m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 2;
    
        // Add initial item with higher discount
        order.AddOrderItem(productId, productName, unitPrice, 50, pictureUrl, 1);
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        // Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        Assert.AreEqual(productId, order.OrderItems.First().ProductId);
        Assert.AreEqual(productName, order.OrderItems.First().ProductName);
        Assert.AreEqual(unitPrice, order.OrderItems.First().UnitPrice);
        Assert.AreEqual(50m, order.OrderItems.First().Discount); // Discount should remain unchanged
        Assert.AreEqual(pictureUrl, order.OrderItems.First().PictureUrl);
        Assert.AreEqual(3, order.OrderItems.First().Units);
    }

*/
/*
FAILED TEST: The test run failed due to **C# syntax errors** in the `OrderAggregateTest.cs` file:

### **Root Cause:**
- **Incorrect placement of `using` directives** after the namespace declaration.
- **Missing opening `{`** after the class declaration.
- **Missing closing `}`** for the class and method definitions.
- **Unclosed methods** and **unclosed class**, leading to compilation failure.

### **Recommended Fixes:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing opening `{` after `public class OrderAggregateTest`.
3. Close all open methods and the class with appropriate `}`.
4. Ensure all methods are properly enclosed within the class body.

    [TestMethod]
    public void AddOrderItemWithSameProductIdAndHigherDiscount()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000.00m;
        var discount = 50m;
        var pictureUrl = "https://example.com/laptop.jpg";
        var units = 2;
    
        // Add initial item
        order.AddOrderItem(productId, productName, unitPrice, 0, pictureUrl, 1);
    
        // Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
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
FAILED TEST: The test run failed due to **C# syntax errors in the `OrderAggregateTest.cs` file**, specifically:

### **Root Cause:**
- **Missing opening `{`** after the class declaration.
- **Incorrect placement of `using` directives** after the namespace declaration.

### **Key Errors:**
- `CS1513: } expected` — Missing opening `{` for the class.
- `CS1529: A using clause must precede all other elements` — `using` directives are placed after the namespace declaration.
- `CS1022: Type or namespace definition, or end-of-file expected` — Structural syntax issue due to missing `{`.

### **Recommended Fix:**
1. Move all `using` directives **before** the namespace declaration.
2. Add the missing opening `{` after the class declaration `public class OrderAggregateTest`.

**Corrected structure:**
```csharp
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;

namespace eShop.Ordering.UnitTests.Domain
{
    [TestClass]
    public class OrderAggregateTest
    {
        // ... rest of the code ...
    }
}
```

    [TestMethod]
    public void AddNewOrderItemToEmptyOrder()
    {
        // Arrange
        var order = new Order();
        var productId = 101;
        var productName = "Laptop";
        var unitPrice = 1000.00m;
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
