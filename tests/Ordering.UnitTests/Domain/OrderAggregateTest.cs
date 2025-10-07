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
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: The test file `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` contains a duplicate `using` directive on line 6. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice (lines 3 and 6), preventing the test project from building.

### Recommended Fix
**Delete line 6** from `OrderAggregateTest.cs`:

```csharp
// Remove this duplicate line:
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

The corrected using block should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
// Line 6 deleted
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Cancel_order_when_stock_rejected_with_empty_list_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.AddOrderItem(1, "Product1", 50.00m, 5.00m, "http://example.com/image1.jpg", 2);
        order.SetAwaitingValidationStatus();
        var rejectedItems = new List<int>();
    
        //Act
        order.SetCancelledStatusWhenStockIsRejected(rejectedItems);
    
        //Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.IsTrue(order.Description.Contains("The product items don't have stock: ()."));
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice (lines 3 and 6), preventing the test project from building.

### Recommended Fix
**Delete line 6** from `OrderAggregateTest.cs`:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;  // Line 3 - Keep this
using eShop.Ordering.UnitTests.Domain;                        // Line 4
using Microsoft.VisualStudio.TestTools.UnitTesting;          // Line 5
// DELETE LINE 6: using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Create_order_with_null_buyer_and_payment_ids_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var cardTypeId = 1;
        var cardNumber = "4111111111111111";
        var cardSecurityNumber = "123";
        var cardHolderName = "John Doe";
        var cardExpiration = DateTime.UtcNow.AddYears(2);
    
        //Act
        var order = new Order(userId, userName, address, cardTypeId, cardNumber, 
                             cardSecurityNumber, cardHolderName, cardExpiration, null, null);
    
        //Assert
        Assert.IsNotNull(order);
        Assert.IsNull(order.BuyerId);
        Assert.IsNull(order.PaymentId);
        Assert.AreEqual(OrderStatus.Submitted, order.OrderStatus);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation failed due to **CS0105: duplicate `using` directive** on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice (lines 3 and 6), preventing the test project from building.

### Recommended Fix
**Delete line 6** from `OrderAggregateTest.cs`:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;  // Line 3 - Keep this
using eShop.Ordering.UnitTests.Domain;                        // Line 4
using Microsoft.VisualStudio.TestTools.UnitTesting;          // Line 5
// DELETE LINE 6: using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Add_order_item_with_default_units_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        var productId = 1;
        var productName = "Product A";
        var unitPrice = 100.00m;
        var discount = 5.00m;
        var pictureUrl = "http://example.com/image.jpg";
    
        //Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl);
    
        //Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var addedItem = order.OrderItems.First();
        Assert.AreEqual(1, addedItem.Units);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation failed due to **two compilation errors**:

1. **CS0105** (Line 6): Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate`
2. **CS1061** (Line 56): `OrderItem` class does not contain a `GetCurrentDiscount()` method

### Recommended Fixes

1. **Remove duplicate using statement** - Delete line 6 in `OrderAggregateTest.cs`:
   ```csharp
   using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;  // REMOVE THIS LINE
   ```

2. **Fix method call on line 56** - Replace `GetCurrentDiscount()` with the correct property `Discount`:
   ```csharp
   // Change from:
   orderItem.GetCurrentDiscount()
   
   // To:
   orderItem.Discount
   ```

The `OrderItem` class exposes discount as a property, not a method. Review the test assertion on line 56 and update it to access the `Discount` property directly.

    [TestMethod]
    public void Add_order_item_with_zero_discount_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        var productId = 1;
        var productName = "Product A";
        var unitPrice = 100.00m;
        var discount = 0.00m;
        var pictureUrl = "http://example.com/image.jpg";
        var units = 1;
    
        //Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        //Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var addedItem = order.OrderItems.First();
        Assert.AreEqual(discount, addedItem.GetCurrentDiscount());
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Recommended Fix
**Remove the duplicate `using` statement on line 6**. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is already imported on line 3.

The corrected file header should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eShop.Ordering.Domain.Exceptions;
```

Delete line 6 to resolve the compilation error and allow the test suite to build successfully.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void Cancel_order_when_shipped_throws_exception()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
        order.SetShippedStatus();
    
        //Act
        order.SetCancelledStatus();
    
        //Assert - Exception expected
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Recommended Fix
**Remove the duplicate `using` statement on line 6**. The namespace is already imported on line 3.

The corrected file header should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using eShop.Ordering.Domain.Exceptions;
// Line 6 with duplicate using statement should be deleted
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void Cancel_order_when_paid_throws_exception()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
    
        //Act
        order.SetCancelledStatus();
    
        //Assert - Exception expected
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Recommended Fix
**Action**: Delete line 6 from `OrderAggregateTest.cs`:

```csharp
// Remove this duplicate line:
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

The namespace is already imported on line 3, making the second import on line 6 redundant and causing the compilation failure.

    [TestMethod]
    [ExpectedException(typeof(OrderingDomainException))]
    public void Set_shipped_status_when_not_paid_throws_exception()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
    
        //Act
        order.SetShippedStatus();
    
        //Assert - Exception expected
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Recommended Fix
Remove the duplicate `using` statement on **line 6**. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is already imported on line 3, making the second import redundant and causing a compiler error.

**Action**: Delete line 6 from `OrderAggregateTest.cs`:
```csharp
// Remove this line:
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

    [TestMethod]
    public void Set_paid_status_when_not_stock_confirmed_no_change()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
    
        //Act
        order.SetPaidStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.AwaitingValidation, order.OrderStatus);
        Assert.IsNull(order.Description);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

The namespace is imported twice:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

### Recommended Fix
Remove the duplicate `using` statement on **line 6**. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;

public class OrderAggregateTest
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Set_stock_confirmed_status_when_not_awaiting_validation_no_change()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
    
        //Act
        order.SetStockConfirmedStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.Submitted, order.OrderStatus);
        Assert.IsTrue(string.IsNullOrEmpty(order.Description));
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation fails due to **CS0105: duplicate `using` directive** on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice, preventing the test project from building.

### Recommended Fix
Remove the duplicate `using` statement on **line 6**:

```csharp
// DELETE THIS LINE:
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

The corrected using block should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
```

    [TestMethod]
    public void Set_awaiting_validation_status_when_not_submitted_no_change()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
    
        //Act
        order.SetAwaitingValidationStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.Paid, order.OrderStatus);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation failed due to a **duplicate `using` directive** on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice, causing compiler error **CS0105** that prevents the test suite from building.

### Recommended Fix
Remove the duplicate `using` statement on **line 6** in `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`:

```csharp
// DELETE THIS LINE:
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

The corrected using block should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Calculate_total_for_empty_order_returns_zero()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
    
        //Act
        var total = order.GetTotal();
    
        //Assert
        Assert.AreEqual(0.00m, total);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation failed due to a **duplicate `using` directive** on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice, causing compiler error **CS0105** that prevents the test suite from building.

### Recommended Fix
Remove the duplicate `using` statement on **line 6** in `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`:

```csharp
// DELETE THIS LINE:
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

The corrected using block should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Calculate_total_for_order_with_multiple_items_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.AddOrderItem(1, "Product1", 50.00m, 5.00m, "http://example.com/image1.jpg", 2);
        order.AddOrderItem(2, "Product2", 30.00m, 3.00m, "http://example.com/image2.jpg", 3);
        order.AddOrderItem(3, "Product3", 20.00m, 2.00m, "http://example.com/image3.jpg", 1);
    
        //Act
        var total = order.GetTotal();
    
        //Assert
        Assert.AreEqual(210.00m, total);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation failed due to a **duplicate `using` directive** on line 6 of `OrderAggregateTest.cs`. The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice (lines 3 and 6), causing compiler error **CS0105** that prevents the test suite from building.

### Recommended Fix
Remove the duplicate `using` statement on **line 6** in `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
// DELETE LINE 6: using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Cancel_order_when_stock_rejected_with_matching_products_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.AddOrderItem(1, "Product1", 50.00m, 5.00m, "http://example.com/image1.jpg", 2);
        order.AddOrderItem(2, "Product2", 30.00m, 3.00m, "http://example.com/image2.jpg", 3);
        order.AddOrderItem(3, "Product3", 20.00m, 2.00m, "http://example.com/image3.jpg", 1);
        order.SetAwaitingValidationStatus();
        var rejectedItems = new List<int> { 1, 3 };
    
        //Act
        order.SetCancelledStatusWhenStockIsRejected(rejectedItems);
    
        //Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.IsTrue(order.Description.Contains("Product1"));
        Assert.IsTrue(order.Description.Contains("Product3"));
        Assert.IsFalse(order.Description.Contains("Product2"));
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test compilation failed due to a **duplicate `using` directive** on line 6 of `OrderAggregateTest.cs`.

**Error**: `CS0105: The using directive for 'eShop.Ordering.Domain.AggregatesModel.OrderAggregate' appeared previously in this namespace`

The namespace `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` is imported twice (lines 3 and 6), causing a compilation error that prevents the test suite from building.

### Recommended Fix
Remove the duplicate `using` statement on **line 6** in `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs`.

The corrected using block should be:
```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Cancel_order_with_awaiting_validation_status_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
    
        //Act
        order.SetCancelledStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.Cancelled, order.OrderStatus);
        Assert.AreEqual("The order was cancelled.", order.Description);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test execution failed due to **two compilation errors** preventing the test project from building:

1. **CS0105** (Line 6): Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate`
2. **CS1061** (Line 53): `OrderItem` class does not contain a `GetCurrentDiscount()` method

### Recommended Fixes

1. **Remove duplicate using statement** - Delete line 6 in `OrderAggregateTest.cs`:
   ```csharp
   using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;  // REMOVE THIS LINE
   ```

2. **Fix method call** - Replace `GetCurrentDiscount()` with the correct property `Discount` on line 53:
   ```csharp
   // Change from:
   orderItem.GetCurrentDiscount()
   
   // To:
   orderItem.Discount
   ```

These fixes will resolve the compilation errors and allow the test suite to build and execute.

    [TestMethod]
    public void Add_existing_item_with_higher_discount_updates_discount_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        var productId = 1;
        
        //Act
        order.AddOrderItem(productId, "Product A", 100.00m, 5.00m, "http://example.com/image.jpg", 2);
        order.AddOrderItem(productId, "Product A", 100.00m, 10.00m, "http://example.com/image.jpg", 1);
    
        //Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var item = order.OrderItems.First();
        Assert.AreEqual(3, item.Units);
        Assert.AreEqual(10.00m, item.GetCurrentDiscount());
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
The test execution failed due to **two compilation errors**:

1. **CS0105**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6
2. **CS1061**: `OrderItem` class does not contain a `GetCurrentDiscount()` method (referenced on line 53)

### Recommended Fixes

1. **Remove duplicate using statement** - Delete line 6 in `OrderAggregateTest.cs`:
   ```csharp
   // Remove this line:
   using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
   ```

2. **Fix GetCurrentDiscount() call** - On line 53, replace `GetCurrentDiscount()` with the correct property accessor. Based on the `Order.cs` source, `OrderItem` likely has a `Discount` property, not a `GetCurrentDiscount()` method. Change:
   ```csharp
   // From:
   orderItem.GetCurrentDiscount()
   
   // To:
   orderItem.Discount
   ```

These fixes will resolve the compilation errors and allow the test suite to build and execute.

    [TestMethod]
    public void Add_units_to_existing_order_item_with_lower_discount_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        var productId = 1;
        
        //Act
        order.AddOrderItem(productId, "Product A", 100.00m, 5.00m, "http://example.com/image.jpg", 2);
        order.AddOrderItem(productId, "Product A", 100.00m, 3.00m, "http://example.com/image.jpg", 3);
    
        //Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var item = order.OrderItems.First();
        Assert.AreEqual(5, item.Units);
        Assert.AreEqual(5.00m, item.GetCurrentDiscount());
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Issue Details
The test file contains the same using statement twice:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error CS0105, blocking test execution entirely.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Set_shipped_status_from_paid_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
        order.SetPaidStatus();
    
        //Act
        order.SetShippedStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.Shipped, order.OrderStatus);
        Assert.AreEqual("The order was shipped.", order.Description);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Issue Details
The test file contains the same using statement twice:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error CS0105, blocking test execution entirely.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Set_paid_status_from_stock_confirmed_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
        order.SetStockConfirmedStatus();
    
        //Act
        order.SetPaidStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.Paid, order.OrderStatus);
        Assert.AreEqual("The payment was performed at a simulated \"American Bank checking bank account ending on XX35071\"", order.Description);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Issue Details
The test file contains the same using statement twice:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error CS0105, blocking test execution entirely.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Set_stock_confirmed_status_from_awaiting_validation_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        order.SetAwaitingValidationStatus();
    
        //Act
        order.SetStockConfirmedStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.StockConfirmed, order.OrderStatus);
        Assert.AreEqual("All the items were confirmed with available stock.", order.Description);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` prevents the test project from building.

### Issue Details
The test file contains the same using statement twice:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error CS0105, blocking test execution entirely.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Set_awaiting_validation_status_from_submitted_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        
        //Act
        order.SetAwaitingValidationStatus();
    
        //Assert
        Assert.AreEqual(OrderStatus.AwaitingValidation, order.OrderStatus);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive for `eShop.Ordering.Domain.AggregatesModel.OrderAggregate` on line 6 of `OrderAggregateTest.cs` prevents the test project from building.

### Issue Details
The test file contains the same using statement twice:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error CS0105, blocking test execution entirely.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Set_payment_method_verified_with_valid_ids_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        var buyerId = 5;
        var paymentId = 10;
    
        //Act
        order.SetPaymentMethodVerified(buyerId, paymentId);
    
        //Assert
        Assert.AreEqual(buyerId, order.BuyerId);
        Assert.AreEqual(paymentId, order.PaymentId);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error (CS0105)**: Duplicate `using` directive on line 6 of `OrderAggregateTest.cs` prevents the test project from building.

### Issue Details
The file contains two identical import statements:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error CS0105, blocking test execution entirely.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
```

This will resolve the compilation error and allow the test suite to build and execute successfully.

    [TestMethod]
    public void Add_new_order_item_to_empty_order_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var order = new Order(userId, userName, address, 1, "4111111111111111", 
                             "123", "John Doe", DateTime.UtcNow.AddYears(2));
        var productId = 1;
        var productName = "Product A";
        var unitPrice = 100.00m;
        var discount = 10.00m;
        var pictureUrl = "http://example.com/image.jpg";
        var units = 2;
    
        //Act
        order.AddOrderItem(productId, productName, unitPrice, discount, pictureUrl, units);
    
        //Assert
        Assert.AreEqual(1, order.OrderItems.Count);
        var addedItem = order.OrderItems.First();
        Assert.AreEqual(productId, addedItem.ProductId);
        Assert.AreEqual(productName, addedItem.ProductName);
        Assert.AreEqual(units, addedItem.Units);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error**: Duplicate `using` directive preventing test compilation.

### Issue Details
The file `tests/Ordering.UnitTests/Domain/OrderAggregateTest.cs` contains a duplicate import statement:
- Line 3: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;`
- Line 6: `using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;` **(DUPLICATE)**

This causes compiler error **CS0105**, preventing the test project from building and executing.

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected file header should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using eShop.Ordering.UnitTests.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class OrderAggregateTest
{
    // ... rest of the code
}
```

This will resolve the compilation error and allow the tests to build and run successfully.

    [TestMethod]
    public void Create_draft_order_using_NewDraft_success()
    {
        //Act
        var draftOrder = Order.NewDraft();
    
        //Assert
        Assert.IsNotNull(draftOrder);
        Assert.IsNotNull(draftOrder.OrderItems);
        Assert.AreEqual(0, draftOrder.OrderItems.Count);
    }

*/
/*
FAILED TEST: ## Test Failure Analysis

### Root Cause
**Compilation Error**: Duplicate `using` directive in the test file.

### Issue Details
Line 6 in `OrderAggregateTest.cs` contains a duplicate import:
```csharp
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;  // Line 3
using eShop.Ordering.UnitTests.Domain;                        // Line 4
using Microsoft.VisualStudio.TestTools.UnitTesting;          // Line 5
using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;  // Line 6 - DUPLICATE
```

Error: `CS0105: The using directive for 'eShop.Ordering.Domain.AggregatesModel.OrderAggregate' appeared previously in this namespace`

### Recommended Fix
Remove the duplicate `using` statement on line 6. The corrected using block should be:

```csharp
namespace eShop.Ordering.UnitTests.Domain;

using eShop.Ordering.Domain.AggregatesModel.OrderAggregate;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
```

This will resolve the compilation error and allow the tests to run.

    [TestMethod]
    public void Create_order_with_valid_parameters_success()
    {
        //Arrange
        var userId = "user123";
        var userName = "John Doe";
        var address = new Address("street", "city", "state", "country", "zipcode");
        var cardTypeId = 1;
        var cardNumber = "4111111111111111";
        var cardSecurityNumber = "123";
        var cardHolderName = "John Doe";
        var cardExpiration = DateTime.UtcNow.AddYears(2);
        var buyerId = 1;
        var paymentMethodId = 1;
    
        //Act
        var order = new Order(userId, userName, address, cardTypeId, cardNumber, 
                             cardSecurityNumber, cardHolderName, cardExpiration, 
                             buyerId, paymentMethodId);
    
        //Assert
        Assert.IsNotNull(order);
        Assert.AreEqual(OrderStatus.Submitted, order.OrderStatus);
        Assert.AreEqual(address, order.Address);
        Assert.AreEqual(buyerId, order.BuyerId);
        Assert.AreEqual(paymentMethodId, order.PaymentId);
        Assert.IsTrue((DateTime.UtcNow - order.OrderDate).TotalSeconds < 5);
    }

*/
}
