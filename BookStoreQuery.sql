CREATE TABLE bst_customer
(
cus_id INT IDENTITY(1,1) PRIMARY KEY,
cus_name VARCHAR(50) NOT NULL,
cus_address VARCHAR(100) ,
cus_phone CHAR(10) NOT NULL,
cus_email VARCHAR(50) NOT NULL,
cus_state VARCHAR(50),
cus_zip VARCHAR(50),
cus_city VARCHAR(50),
cus_password VARCHAR(50) NOT NULL,
cus_isdeleted BIT NOT NULL DEFAULT 0
);

CREATE TABLE bst_book
(
bok_id INT IDENTITY(1,1) PRIMARY KEY,
bok_title VARCHAR(50) NOT NULL,
bok_author VARCHAR(50) NOT NULL,
bok_categoryid INT NOT NULL,
bok_price DECIMAL(8,2) NOT NULL,
bok_specialpricestatus BIT DEFAULT 0,
bok_specialprice DECIMAL(8,2),
bok_description VARCHAR(500),
bok_imageurl VARCHAR(200),
bok_isdeleted BIT NOT NULL DEFAULT (0)
);

/*------------CUSTOMER TABLE AND BOOK TABLE CREATED---------------*/

/*-------CUSTOMER ------*/

/*----INSERT------*/
GO
CREATE PROCEDURE procCustomerInsert
@name VARCHAR(50), @address VARCHAR(100), @phone CHAR(10), @email VARCHAR(50),
@state VARCHAR(50), @zip VARCHAR(20), @city VARCHAR(30), @password VARCHAR(50)
AS
INSERT INTO bst_customer 
(
cus_name, cus_address, 
cus_phone, 
cus_email,
cus_state, 
cus_zip, 
cus_city, 
cus_password
)
VALUES (@name, @address, @phone, @email, @state,@zip,@city,@password);
GO

/*-----------LIST------*/

GO
CREATE PROCEDURE procCustomerSelect
AS
SELECT 

cus_id AS [Customer Id], 
cus_name AS [Customer Name], 
cus_address AS [Customer Address], 
cus_phone AS [Customer Phone], 
cus_email AS [Customer Email], 
cus_state as [Customer State], 
cus_zip AS [Customer Zip], 
cus_city as [Customer City], 
cus_password as [Customer Password]

FROM bst_customer
WHERE cus_isdeleted = 0;
GO

/*----------UPDATE-------*/
GO
CREATE PROCEDURE procCustomerUpdate 
@id INT, 
@name VARCHAR(50), 
@address VARCHAR(100), 
@phone CHAR(10), 
@email VARCHAR(50),
@state VARCHAR(50), 
@zip VARCHAR(20), 
@city VARCHAR(30), 
@password VARCHAR(50)
AS
UPDATE bst_customer
SET cus_name = @name, 
cus_address = @address,
cus_phone = @phone,
cus_email = @email,
cus_city = @city,
cus_state = @state,
cus_zip = @zip,
cus_password = @password
WHERE cus_id = @id;
GO

/*-------------DELETE--------*/
GO
CREATE PROCEDURE procCustomerDelete
@id INT
AS
UPDATE bst_customer
SET 
cus_isdeleted = 1
WHERE 
cus_id = @id;
GO

/*--------BOOK TABLE--------*/

/*-------BOOK INSERT-------*/

GO
CREATE PROCEDURE procBookInsert
@title VARCHAR(50),
@author VARCHAR(50),
@categoryid INT,
@price DECIMAL(10,2),
@specialpricestatus BIT,
@specialprice DECIMAL(10,2),
@description VARCHAR(300),
@imageurl VARCHAR(100)
AS
INSERT INTO bst_book
(
bok_title,
bok_author,
bok_categoryid,
bok_price,
bok_specialpricestatus,
bok_specialprice,
bok_description,
bok_imageurl
)
VALUES
(
@title,
@author,
@categoryid,
@price,
@specialpricestatus,
@specialprice,
@description,
@imageurl
);
GO

/*----------LIST--------*/

GO
CREATE PROCEDURE procBookSelect
AS
SELECT
bok_id as [Book Id],
bok_title as [Book Title],
bok_author as [Book Author],
bok_categoryid as [Category Id],
bst_category.cat_name as [Category Name],
bok_price as [Book Price],
bok_specialpricestatus as [Book Special Price Status],
bok_specialprice as [Book Special Price],
bok_description as [Book Description],
bok_imageurl as [Book Image Url]
FROM bst_book
JOIN bst_category
ON bst_category.cat_id = bst_book.bok_categoryid
WHERE bok_isdeleted = 0;
GO

/*---------Get all books of a category------*/
GO
CREATE PROCEDURE procBookByCategoryIdSelect
@id INT
AS
SELECT
bok_id as [Book Id],
bok_title as [Book Title],
bok_author as [Book Author],
bok_categoryid as [Category Id],
bst_category.cat_name as [Category Name],
bok_price as [Book Price],
bok_specialpricestatus as [Book Special Price Status],
bok_specialprice as [Book Special Price],
bok_description as [Book Description],
bok_imageurl as [Book Image Url]
FROM bst_book
JOIN bst_category
ON bst_book.bok_categoryid = bst_category.cat_id
WHERE bst_category.cat_id = @id AND bst_book.bok_isdeleted = 0;
GO

-------------------------------------
GO
CREATE PROCEDURE procBookSpecialsSelect
AS
SELECT
bok_id as [Book Id],
bok_title as [Book Title],
bok_author as [Book Author],
bok_categoryid as [Category Id],
bst_category.cat_name as [Category Name],
bok_price as [Book Price],
bok_specialpricestatus as [Book Special Price Status],
bok_specialprice as [Book Special Price],
bok_description as [Book Description]
FROM bst_book
JOIN bst_category
ON bst_category.cat_id = bst_book.bok_categoryid
WHERE bok_isdeleted = 0 AND bok_specialpricestatus = 1;
GO

exec procBookSpecialsSelect


GO
CREATE PROCEDURE procBookByIdDetailsSelect
@id INT
AS
SELECT
bok_id as [Book Id],
bok_title as [Book Title],
bok_author as [Book Author],
bok_price as [Book Price],
bok_categoryid as [Category Id],
bst_category.cat_name as [Category Name],
bok_specialprice as [Book Special Price],
bok_specialpricestatus as [Special Price Status],
bok_description as [Book Description],
bok_imageurl as [Book Image Url]
FROM bst_book
JOIN bst_category
ON bst_category.cat_id = bst_book.bok_categoryid
WHERE bok_isdeleted = 0 AND bok_id = @id;
GO

exec procBookByIdDetailsSelect 3;
/*-------------------UPDATE------------*/

GO
ALTER PROCEDURE procBookUpdate
@id INT,
@title VARCHAR(50),
@author VARCHAR(50),
@categoryid INT,
@price DECIMAL(10,2),
@specialpricestatus BIT,
@specialprice DECIMAL(10,2),
@description VARCHAR(300),
@imageurl VARCHAR(200)

AS
UPDATE bst_book
SET bok_title = @title,
bok_author = @author,
bok_categoryid = @categoryid,
bok_price = @price,
bok_specialpricestatus = @specialpricestatus,
bok_specialprice = @specialprice,
bok_description = @description,
bok_imageurl = @imageurl
WHERE bok_id = @id;
GO

/*-------------DELETE--------*/
GO
CREATE PROCEDURE procBookDelete
@id INT
AS
UPDATE bst_book
SET 
bok_isdeleted = 1
WHERE 
bok_id = @id;
GO

/*---------Admint Table------------------*/
CREATE TABLE bst_admin
(
adm_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
adm_username VARCHAR(50) NOT NULL,
adm_password VARCHAR(50) NOT NULL
);

GO
CREATE PROCEDURE procAdminByUsernamePasswordOutput
@username VARCHAR(50)
AS
SELECT TOP 1 adm_password
FROM bst_admin
WHERE adm_username = @username
GO

GO
CREATE PROCEDURE procCustomerByEmailPasswordOutput
@email VARCHAR(50)
AS
SELECT TOP 1 cus_password
FROM bst_customer
WHERE cus_email = @email
GO

/*--------------CART TABLE----------------*/
CREATE TABLE bst_cart
(
crt_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
crt_orderid INT NOT NULL,
crt_bookid INT NOT NULL,
crt_quantity INT NOT NULL DEFAULT 1,
crt_unitprice DECIMAL(8,2) NOT NULL,
crt_totalamount AS (crt_quantity * crt_unitprice),
crt_billamount DECIMAL(10,2),
crt_isdeleted BIT NOT NULL DEFAULT 0
);


/*----------------INSERT CART TABLE---------*/
GO
CREATE PROCEDURE procCartInsert
@orderid INT, @bookid INT, @quantity INT, @unitprice DECIMAL(8,2)
AS
INSERT INTO bst_cart (crt_orderid, crt_bookid, crt_quantity, crt_unitprice)
VALUES (@orderid, @bookid, @quantity, @unitprice);
GO


/*-------------LIST-------------*/

GO
CREATE PROCEDURE procCartSelect
@orderid INT
AS
SELECT 
crt_bookid as [Book Id],
bok_title as [Book Title],
bok_price as [Book Price],
bok_specialprice as [Book Special Price],
bok_specialpricestatus as [Special Price Status],
crt_quantity as [Quantity],
crt_unitprice as [Unit Price],
crt_totalamount as [Total Amount],
crt_billamount as [Bill Amount],
crt_orderid as [Order Id]
FROM bst_cart
JOIN bst_book 
ON bst_book.bok_id = bst_cart.crt_bookid
WHERE bst_cart.crt_isdeleted = 0 AND bst_cart.crt_orderid = @orderid AND bst_book.bok_isdeleted = 0;
GO

/*------get book details from cart using bookid and useremail-------*/
GO
CREATE PROCEDURE procCartByBookIdAndOrderIdSelect
@orderid INT, @bookid INT
AS
SELECT 
crt_bookid as [Book Id],
bok_title as [Book Title],
bok_specialprice as [Book Special Price],
bok_specialpricestatus as [Special Price Status],
crt_quantity as [Quantity],
crt_unitprice as [Unit Price],
crt_totalamount as [Total Amount],
crt_billamount as [Bill Amount],
crt_orderid as [Order Id]
FROM bst_cart
JOIN bst_book 
ON bst_book.bok_id = bst_cart.crt_bookid
WHERE bst_cart.crt_isdeleted = 0 AND bst_cart.crt_orderid = @orderid AND bst_book.bok_isdeleted = 0 AND crt_bookid=@bookid;
GO

/*----------Delete--------------*/
GO
CREATE PROCEDURE procCartDelete
@bookid INT, @orderid INT
AS
UPDATE bst_cart 
SET crt_isdeleted = 1 
WHERE crt_bookid = @bookid AND crt_orderid = @orderid;
GO

GO
CREATE PROCEDURE procCartByOrderIdDelete
@orderid INT
AS
DELETE 
FROM bst_cart
WHERE crt_id = @orderid;
GO

/*---------UPDATE----------------*/
GO
CREATE PROCEDURE procCartUpdate
@bookid INT, @orderid INT, @quantity INT
AS
UPDATE bst_cart
SET crt_quantity = @quantity
WHERE crt_bookid = @bookid AND crt_orderid = @orderid AND crt_isdeleted=0;
GO

/*-------------------Get bill amount----------*/
GO
CREATE PROCEDURE procCartBillAmountSelect
@orderid INT
AS
SELECT SUM(crt_totalamount)
FROM bst_cart
WHERE crt_orderid = @orderid AND crt_isdeleted = 0
GO

/*----------ORDER TABLE------------*/
CREATE TABLE bst_order
(
ord_id INT NOT NULL IDENTITY(1,1),
ord_date DATETIME NOT NULL DEFAULT GETDATE(),
ord_useremail VARCHAR(50) NOT NULL,
ord_billamount DECIMAL(10,2),
ord_isdeleted BIT NOT NULL DEFAULT 0
);

/*----------Insert -------------*/
GO
CREATE PROCEDURE procOrderInsert
@useremail VARCHAR(50)
AS
INSERT INTO bst_order(ord_useremail)
VALUES (@useremail)
GO

/*--------UPDATE-------------------*/
GO
CREATE PROCEDURE procOrderUpdate
@useremail VARCHAR(50), @orderid INT, @datetime DATETIME, @billamount DECIMAL(10,2)
AS
UPDATE bst_order
SET ord_date = @datetime,
ord_billamount = @billamount
WHERE ord_id = @orderid AND ord_useremail = @useremail;
GO

/*---------------LIST-----------*/
GO
CREATE PROCEDURE procOrderByUserEmailSelect
@useremail VARCHAR(50)
AS
SELECT 
ord_id as [Order Id],
ord_date as [Order Date],
ord_billamount as [Bill Amount]
FROM bst_order
WHERE ord_useremail = @useremail AND ord_isdeleted = 0;
GO

/*--------------------delete order--------------*/
GO
CREATE PROCEDURE procOrderDelete
@orderid INT
AS
UPDATE bst_order
SET ord_isdeleted = 1
WHERE ord_id = @orderid;
GO

/*--------------------------ORDER DETAILS TABLE------------------*/
CREATE TABLE bst_orderdetails
(
odd_id INT NOT NULL IDENTITY(1,1),
odd_orderid INT NOT NULL,
odd_bookid INT NOT NULL,
odd_quantity INT NOT NULL,
odd_unitprice DECIMAL(10,2) NOT NULL,
odd_totalamount DECIMAL(10,2) NOT NULL,
odd_billamount DECIMAL(10,2) NOT NULL,
odd_isdeleted BIT NOT NULL DEFAULT 0
);

/*---------------------------create ------------------*/
GO
CREATE PROCEDURE procOrderDetailsInsert
@orderid INT, @bookid INT, @quantity INT, @unitprice DECIMAL(10,2), @totalamount DECIMAL(10,2), @billamount DECIMAL(10,2)
AS
INSERT INTO bst_orderdetails
(odd_orderid, odd_bookid, odd_quantity, odd_unitprice, odd_totalamount, odd_billamount)
VALUES (@orderid, @bookid, @quantity, @unitprice, @totalamount, @billamount)
GO

/*-------------LIST-------------*/
GO
CREATE PROCEDURE procOrderDetailsSelect
@orderid INT
AS
SELECT 
odd_bookid as [Book Id],
bok_title as [Book Title],
odd_orderid as [Order Id],
odd_quantity as [Quantity],
odd_totalamount as [Total Amount],
odd_unitprice as [Unit Price],
odd_billamount as [Bill Amount]
FROM bst_orderdetails
JOIN bst_book ON odd_bookid = bok_id
WHERE odd_orderid = @orderid AND odd_isdeleted = 0 AND bok_isdeleted = 0;
GO
 

/*-------------CREDIT CARD DATABASE----------*/
CREATE TABLE bst_creditcarddata
(
ccd_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
ccd_cardnumber CHAR(16) NOT NULL,
ccd_cardtype VARCHAR(20) NOT NULL,
ccd_month CHAR(2) NOT NULL,
ccd_year CHAR(2) NOT NULL,
ccd_cvv CHAR(3) NOT NULL,
ccd_isdeleted BIT NOT NULL DEFAULT 0
);

INSERT INTO bst_creditcarddata (ccd_cardtype, ccd_cardnumber, ccd_month, ccd_year, ccd_cvv)
VALUES ('Master', '1111111111111111', '01', '21', '111')


INSERT INTO bst_creditcarddata (ccd_cardtype, ccd_cardnumber, ccd_month, ccd_year, ccd_cvv)
VALUES ('Visa', '2222222222222222', '02', '22', '222')


INSERT INTO bst_creditcarddata (ccd_cardtype, ccd_cardnumber, ccd_month, ccd_year, ccd_cvv)
VALUES ('RuPay', '3333333333333333', '03', '23', '333')

GO
alter PROCEDURE procCreditCardValidation
@cardtype VARCHAR(20), @cardnumber CHAR(16), @month CHAR(2), @year CHAR(2), @cvv CHAR(3)
AS
SELECT
ccd_id AS [Card Id]
FROM bst_creditcarddata
WHERE ccd_cardtype = @cardtype AND ccd_cardnumber = @cardnumber AND ccd_month = @month AND ccd_year = @year AND ccd_cvv = @cvv AND ccd_isdeleted =0;
GO

/*---------update bill amount-------*/
GO
alter PROCEDURE procCartBillUpdate
@orderid INT, @bill DECIMAL(10,2)
AS
BEGIN
UPDATE bst_cart
SET crt_billamount = @bill
WHERE crt_orderid = @orderid AND crt_isdeleted = 0;
END
GO

/*---------TRUNCATE !!!!!!!!!!!!!--------*/
truncate table bst_cart
truncate table bst_order
truncate table bst_orderdetails
/*---------TRUNCATE !!!!!!!!!!!!!--------*/


select * from bst_order

select * from bst_orderdetails

select * from bst_cart

SELECT * FROM bst_customer

SELECT * FROM bst_admin

INSERT INTO bst_order(ord_useremail)
VALUES('jacob@yahoo.com');


INSERT INTO bst_order(ord_useremail)
VALUES('thomas@yahoo.com');


INSERT INTO bst_order(ord_useremail)
VALUES('annie@yahoo.com');


INSERT INTO bst_order(ord_useremail)
VALUES('jacob@gmail.com');

CREATE TABLE bst_payment
(
pay_id INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
pay_useremail VARCHAR(50) NOT NULL,
pay_cardnumber CHAR(16) NOT NULL,
pay_cardtype VARCHAR(20) NOT NULL,
pay_month CHAR(2) NOT NULL,
pay_year CHAR(2) NOT NULL,
pay_isdeleted BIT NOT NULL DEFAULT 0
);

GO
CREATE PROCEDURE procPaymentInsert
@useremail VARCHAR(50), @cardnumber CHAR(16), @cardtype VARCHAR(20), @month CHAR(2), @year CHAR(2)
AS
INSERT INTO bst_payment(pay_useremail, pay_cardnumber, pay_cardtype, pay_month, pay_year)
VALUES (@useremail, @cardnumber, @cardtype, @month, @year)
GO

CREATE PROCEDURE procPaymentGetCardNumberGivenUserEmail
@useremail VARCHAR(50)
AS
SELECT pay_cardnumber as [Card Number]
FROM bst_payment
WHERE pay_isdeleted = 0 AND pay_useremail = @useremail;
GO

select * from bst_payment