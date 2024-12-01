Use [AIPizza]

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Customer_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Insert a new Customer
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Customer_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Customer_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Customer_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Customer_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Customer_Insert >>>'

    End

GO

Create PROCEDURE Customer_Insert

    -- Add the parameters for the stored procedure here
    @Address nvarchar(255),
    @City nvarchar(50),
    @Name nvarchar(50),
    @PhoneNumber nvarchar(20),
    @State nvarchar(2),
    @VIPClub bit,
    @ZipCode nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [Customer]
    ([Address],[City],[Name],[PhoneNumber],[State],[VIPClub],[ZipCode])

    -- Begin Values List
    Values(@Address, @City, @Name, @PhoneNumber, @State, @VIPClub, @ZipCode)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Customer_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Update an existing Customer
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Customer_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Customer_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Customer_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Customer_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Customer_Update >>>'

    End

GO

Create PROCEDURE Customer_Update

    -- Add the parameters for the stored procedure here
    @Address nvarchar(255),
    @City nvarchar(50),
    @Id int,
    @Name nvarchar(50),
    @PhoneNumber nvarchar(20),
    @State nvarchar(2),
    @VIPClub bit,
    @ZipCode nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [Customer]

    -- Update Each field
    Set [Address] = @Address,
    [City] = @City,
    [Name] = @Name,
    [PhoneNumber] = @PhoneNumber,
    [State] = @State,
    [VIPClub] = @VIPClub,
    [ZipCode] = @ZipCode

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Customer_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Find an existing Customer
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Customer_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Customer_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Customer_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Customer_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Customer_Find >>>'

    End

GO

Create PROCEDURE Customer_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[City],[Id],[Name],[PhoneNumber],[State],[VIPClub],[ZipCode]

    -- From tableName
    From [Customer]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Customer_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Delete an existing Customer
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Customer_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Customer_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Customer_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Customer_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Customer_Delete >>>'

    End

GO

Create PROCEDURE Customer_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [Customer]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Customer_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Returns all Customer objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Customer_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Customer_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Customer_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Customer_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Customer_FetchAll >>>'

    End

GO

Create PROCEDURE Customer_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[City],[Id],[Name],[PhoneNumber],[State],[VIPClub],[ZipCode]

    -- From tableName
    From [Customer]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: OrderDetail_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Insert a new OrderDetail
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('OrderDetail_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure OrderDetail_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.OrderDetail_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure OrderDetail_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure OrderDetail_Insert >>>'

    End

GO

Create PROCEDURE OrderDetail_Insert

    -- Add the parameters for the stored procedure here
    @GroundBeef bit,
    @Pepperoni bit,
    @PizzaOrderId int,
    @Price float,
    @Quantity int,
    @Sausage bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [OrderDetail]
    ([GroundBeef],[Pepperoni],[PizzaOrderId],[Price],[Quantity],[Sausage])

    -- Begin Values List
    Values(@GroundBeef, @Pepperoni, @PizzaOrderId, @Price, @Quantity, @Sausage)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: OrderDetail_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Update an existing OrderDetail
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('OrderDetail_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure OrderDetail_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.OrderDetail_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure OrderDetail_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure OrderDetail_Update >>>'

    End

GO

Create PROCEDURE OrderDetail_Update

    -- Add the parameters for the stored procedure here
    @GroundBeef bit,
    @Id int,
    @Pepperoni bit,
    @PizzaOrderId int,
    @Price float,
    @Quantity int,
    @Sausage bit

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [OrderDetail]

    -- Update Each field
    Set [GroundBeef] = @GroundBeef,
    [Pepperoni] = @Pepperoni,
    [PizzaOrderId] = @PizzaOrderId,
    [Price] = @Price,
    [Quantity] = @Quantity,
    [Sausage] = @Sausage

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: OrderDetail_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Find an existing OrderDetail
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('OrderDetail_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure OrderDetail_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.OrderDetail_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure OrderDetail_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure OrderDetail_Find >>>'

    End

GO

Create PROCEDURE OrderDetail_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [GroundBeef],[Id],[Pepperoni],[PizzaOrderId],[Price],[Quantity],[Sausage]

    -- From tableName
    From [OrderDetail]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: OrderDetail_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Delete an existing OrderDetail
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('OrderDetail_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure OrderDetail_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.OrderDetail_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure OrderDetail_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure OrderDetail_Delete >>>'

    End

GO

Create PROCEDURE OrderDetail_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [OrderDetail]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: OrderDetail_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Returns all OrderDetail objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('OrderDetail_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure OrderDetail_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.OrderDetail_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure OrderDetail_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure OrderDetail_FetchAll >>>'

    End

GO

Create PROCEDURE OrderDetail_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [GroundBeef],[Id],[Pepperoni],[PizzaOrderId],[Price],[Quantity],[Sausage]

    -- From tableName
    From [OrderDetail]

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: PizzaOrder_Insert
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Insert a new PizzaOrder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('PizzaOrder_Insert'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure PizzaOrder_Insert

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.PizzaOrder_Insert') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure PizzaOrder_Insert >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure PizzaOrder_Insert >>>'

    End

GO

Create PROCEDURE PizzaOrder_Insert

    -- Add the parameters for the stored procedure here
    @CustomerId int,
    @DriverDepartTime datetime,
    @Filled bit,
    @OrderDate datetime,
    @OrderType int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Insert Statement
    Insert Into [PizzaOrder]
    ([CustomerId],[DriverDepartTime],[Filled],[OrderDate],[OrderType])

    -- Begin Values List
    Values(@CustomerId, @DriverDepartTime, @Filled, @OrderDate, @OrderType)

    -- Return ID of new record
    SELECT SCOPE_IDENTITY()

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: PizzaOrder_Update
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Update an existing PizzaOrder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('PizzaOrder_Update'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure PizzaOrder_Update

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.PizzaOrder_Update') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure PizzaOrder_Update >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure PizzaOrder_Update >>>'

    End

GO

Create PROCEDURE PizzaOrder_Update

    -- Add the parameters for the stored procedure here
    @CustomerId int,
    @DriverDepartTime datetime,
    @Filled bit,
    @Id int,
    @OrderDate datetime,
    @OrderType int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Update Statement
    Update [PizzaOrder]

    -- Update Each field
    Set [CustomerId] = @CustomerId,
    [DriverDepartTime] = @DriverDepartTime,
    [Filled] = @Filled,
    [OrderDate] = @OrderDate,
    [OrderType] = @OrderType

    -- Update Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: PizzaOrder_Find
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Find an existing PizzaOrder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('PizzaOrder_Find'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure PizzaOrder_Find

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.PizzaOrder_Find') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure PizzaOrder_Find >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure PizzaOrder_Find >>>'

    End

GO

Create PROCEDURE PizzaOrder_Find

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CustomerId],[DriverDepartTime],[Filled],[Id],[OrderDate],[OrderType]

    -- From tableName
    From [PizzaOrder]

    -- Find Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: PizzaOrder_Delete
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Delete an existing PizzaOrder
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('PizzaOrder_Delete'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure PizzaOrder_Delete

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.PizzaOrder_Delete') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure PizzaOrder_Delete >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure PizzaOrder_Delete >>>'

    End

GO

Create PROCEDURE PizzaOrder_Delete

    -- Primary Key Paramater
    @Id int

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Delete Statement
    Delete From [PizzaOrder]

    -- Delete Matching Record
    Where [Id] = @Id

END

set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: PizzaOrder_FetchAll
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Returns all PizzaOrder objects
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('PizzaOrder_FetchAll'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure PizzaOrder_FetchAll

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.PizzaOrder_FetchAll') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure PizzaOrder_FetchAll >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure PizzaOrder_FetchAll >>>'

    End

GO

Create PROCEDURE PizzaOrder_FetchAll

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [CustomerId],[DriverDepartTime],[Filled],[Id],[OrderDate],[OrderType]

    -- From tableName
    From [PizzaOrder]

END

-- Begin Custom Methods


set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
Go
-- =========================================================
-- Procure Name: Customer_FindByPhoneNumber
-- Author:           Data Juggler - Data Tier.Net Procedure Generator
-- Create Date:   11/30/2024
-- Description:    Find an existing Customer for the PhoneNumber given.
-- =========================================================

-- Check if the procedure already exists
IF EXISTS (select * from syscomments where id = object_id ('Customer_FindByPhoneNumber'))

    -- Procedure Does Exist, Drop First
    BEGIN

        -- Execute Drop
        Drop Procedure Customer_FindByPhoneNumber

        -- Test if procedure was dropped
        IF OBJECT_ID('dbo.Customer_FindByPhoneNumber') IS NOT NULL

            -- Print Line Drop Failed
            PRINT '<<< Drop Failed On Procedure Customer_FindByPhoneNumber >>>'

        Else

            -- Print Line Procedure Dropped
            PRINT '<<< Drop Suceeded On Procedure Customer_FindByPhoneNumber >>>'

    End

GO

Create PROCEDURE Customer_FindByPhoneNumber

    -- Create @PhoneNumber Paramater
    @PhoneNumber nvarchar(20)

AS
BEGIN

    -- SET NOCOUNT ON added to prevent extra result sets from
    -- interfering with SELECT statements.
    SET NOCOUNT ON

    -- Begin Select Statement
    Select [Address],[City],[Id],[Name],[PhoneNumber],[State],[VIPClub],[ZipCode]

    -- From tableName
    From [Customer]

    -- Find Matching Record
    Where [PhoneNumber] = @PhoneNumber

END


-- End Custom Methods

-- Thank you for using DataTier.Net.

