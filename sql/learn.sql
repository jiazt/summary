
SELECT LastName,FirstName FROM Persons

SELECT * FROM Persons

-- 关键词 DISTINCT 用于返回唯一不同的值
SELECT DISTINCT Company FROM Orders 

SELECT * FROM Persons WHERE City='Beijing'
SELECT * FROM Persons WHERE Year>1965

-- AND OR 和 ORDER BY 的应用  DESC 降序 ASC 升序
SELECT * FROM Persons WHERE FirstName='Thomas' AND LastName='Carter'
SELECT * FROM Persons WHERE firstname='Thomas' OR lastname='Carter'
SELECT * FROM Persons WHERE (FirstName='Thomas' OR FirstName='William') AND LastName='Carter'
SELECT Company, OrderNumber FROM Orders ORDER BY Company, OrderNumber
SELECT Company, OrderNumber FROM Orders ORDER BY Company DESC, OrderNumber ASC

-- INSERT INTO 插入语句
INSERT INTO Persons VALUES ('Gates', 'Bill', 'Xuanwumen 10', 'Beijing')
INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')

-- UPDATE 更新语句
UPDATE Person SET FirstName = 'Fred' WHERE LastName = 'Wilson'
UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'

-- DELETE 删除语句
DELETE FROM Person WHERE LastName = 'Wilson' 
DELETE FROM table_name
DELETE * FROM table_name

-- TOP 语句
SELECT TOP 3 * FROM Persons  //去前三个
SELECT TOP 50 PERCENT * FROM Person //选取前 50% 的记录。

-- LIKE 操作符 模糊匹配用
SELECT * FROM Persons WHERE City LIKE '%hai%'
SELECT * FROM Persons WHERE City NOT LIKE '%hai%'
SELECT * FROM Persons WHERE LastName LIKE 'C_r_er'
SELECT * FROM Persons WHERE City LIKE '[ALN]%' // "Persons" 表中选取居住的城市以 "A" 或 "L" 或 "N" 开头的人

-- IN 操作符允许我们在 WHERE 子句中规定多个值
SELECT * FROM Persons WHERE LastName IN ('Adams','Carter')

-- BETWEEN 操作符在 WHERE 子句中使用，作用是选取介于两个值之间的数据范围。
介于 "Adams"（包括）和 "Carter"（不包括）之间的人
SELECT * FROM Persons WHERE LastName BETWEEN 'Adams' AND 'Carter'
SELECT * FROM Persons WHERE LastName NOT BETWEEN 'Adams' AND 'Carter'

-- Alias 实例: 使用表名称别名
SELECT po.OrderID, p.LastName, p.FirstName
FROM Persons AS p, Product_Orders AS po
WHERE p.LastName='Adams' AND p.FirstName='John'
-- 如果不用别名：
SELECT Product_Orders.OrderID, Persons.LastName, Persons.FirstName
FROM Persons, Product_Orders
WHERE Persons.LastName='Adams' AND Persons.FirstName='John'
-- 别名把key重新命名
SELECT LastName AS Family, FirstName AS Name
FROM Persons

-- Join 和 Key
SELECT Persons.LastName, Persons.FirstName, Orders.OrderNo
FROM Persons
INNER JOIN Orders
ON Persons.Id_P = Orders.Id_P
ORDER BY Persons.LastName
-- 如果不用Join
SELECT Persons.LastName, Persons.FirstName, Orders.OrderNo
FROM Persons, Orders
WHERE Persons.Id_P = Orders.Id_P 

-- LEFT JOIN 
-- 关键字会从左表 (table_name1) 那里返回所有的行，
-- !即使在右表 (table_name2) 中没有匹配的行
SELECT Persons.LastName, Persons.FirstName, Orders.OrderNo
FROM Persons
LEFT JOIN Orders
ON Persons.Id_P=Orders.Id_P
ORDER BY Persons.LastName

-- RIGHT JOIN 
-- 关键字会右表 (table_name2) 那里返回所有的行，
-- !!!即使在左表 (table_name1) 中没有匹配的行

-- 只要其中某个表存在匹配，FULL JOIN 关键字就会返回行。
SELECT Persons.LastName, Persons.FirstName, Orders.OrderNo
FROM Persons
FULL JOIN Orders
ON Persons.Id_P=Orders.Id_P
ORDER BY Persons.LastName

-- UNION 操作符用于合并两个或多个 SELECT 语句的结果集
SELECT E_Name FROM Employees_China
UNION
SELECT E_Name FROM Employees_USA
-- UNION 操作符选取不同的值。如果允许重复的值，请使用 UNION ALL
SELECT E_Name FROM Employees_China
UNION ALL
SELECT E_Name FROM Employees_USA

-- SELECT INTO 语句可用于创建表的备份复件
-- 下面的例子会制作 "Persons" 表的备份复件：
SELECT *
INTO Persons_backup
FROM Persons

-- IN 子句可用于向另一个数据库中拷贝表：
SELECT *
INTO Persons IN 'Backup.mdb'
FROM Persons

-- 创建一个名为 "Persons_Order_Backup" 的新表，
-- 其中包含了从 Persons 和 Orders 两个表中取得的信息
SELECT Persons.LastName,Orders.OrderNo
INTO Persons_Order_Backup
FROM Persons
INNER JOIN Orders
ON Persons.Id_P=Orders.Id_P

-- CREATE DATABASE 创建数据库语句
CREATE DATABASE my_db

-- CREATE TABLE 语句用于创建数据库中的表
CREATE TABLE Persons
(
    Id_P int,
    LastName varchar(255),
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
)

-- NOT NULL 约束强制列不接受 NULL 值
CREATE TABLE Persons
(
    Id_P int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
)

-- UNIQUE 和 PRIMARY KEY 约束均为列或列集合提供了唯一性的保证
CREATE TABLE Persons
(
    Id_P int NOT NULL UNIQUE,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255)
)
-- 当表已被创建时，如需在 "Id_P" 列创建 UNIQUE 约束
ALTER TABLE Persons
ADD UNIQUE (Id_P)

-- 如需撤销 UNIQUE 约束，请使用下面的 SQL
ALTER TABLE Persons
DROP CONSTRAINT uc_PersonID

-- 表创建时在 "Id_P" 列创建 PRIMARY KEY 约束
CREATE TABLE Persons
(
    Id_P int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),
    PRIMARY KEY (Id_P)
)
-- 添加主键
ALTER TABLE Persons
ADD PRIMARY KEY (Id_P)
-- 撤销主键
ALTER TABLE Persons
DROP CONSTRAINT pk_PersonID

-- 一个表中的 FOREIGN KEY 指向另一个表中的 PRIMARY KEY
CREATE TABLE Orders
(
    Id_O int NOT NULL,
    OrderNo int NOT NULL,
    Id_P int,
    PRIMARY KEY (Id_O),
    FOREIGN KEY (Id_P) REFERENCES Persons(Id_P)
)

-- CHECK 约束用于限制列中的值的范围
CREATE TABLE Persons
(
    Id_P int NOT NULL,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),
    CHECK (Id_P>0)
)

-- DEFAULT 约束用于向列中插入默认值。
CREATE TABLE Orders
(
    Id_O int NOT NULL,
    OrderNo int NOT NULL,
    Id_P int,
    OrderDate date DEFAULT GETDATE()
)

-- CREATE INDEX 语句用于在表中创建索引
CREATE INDEX index_name
ON table_name (column_name)

-- 通过使用 DROP 语句，可以轻松地删除索引、表和数据库
DROP INDEX table_name.index_name
DROP TABLE 表名称
DROP DATABASE 数据库名称

-- ALTER TABLE 语句用于在已有的表中添加、修改或删除列
ALTER TABLE Persons
ADD Birthday date
-- 删除 "Person" 表中的 "Birthday" 
ALTER TABLE Person
DROP COLUMN Birthday
-- 改变 "Persons" 表中 "Birthday" 列的数据类型。
ALTER TABLE Persons
ALTER COLUMN Birthday year

-- Auto-increment 会在新记录插入表中时生成一个唯一的数字
CREATE TABLE Persons
(
    P_Id int NOT NULL AUTO_INCREMENT,
    LastName varchar(255) NOT NULL,
    FirstName varchar(255),
    Address varchar(255),
    City varchar(255),
    PRIMARY KEY (P_Id)
)

-- 视图是可视化的表
CREATE VIEW [Current Product List] AS
SELECT ProductID,ProductName
FROM Products
WHERE Discontinued=No

-- NULL 值是遗漏的未知数据
SELECT LastName,FirstName,Address FROM Persons
WHERE Address IS NOT NULL
SELECT LastName,FirstName,Address FROM Persons
WHERE Address IS NULLs

-- SQL 拥有很多可用于计数和计算的内建函数 AVG COUNT FIRST MAX ,,,
SELECT Customer FROM Orders
WHERE OrderPrice>(SELECT AVG(OrderPrice) FROM Orders)

SELECT COUNT(*) AS NumberOfOrders FROM Orders

SELECT MIN(OrderPrice) AS SmallestOrderPrice FROM Orders

-- 合计函数 (比如 SUM) 常常需要添加 GROUP BY 语句
SELECT Customer,SUM(OrderPrice) FROM Orders
GROUP BY Customer

-- 在 SQL 中增加 HAVING 子句原因是，WHERE 关键字无法与合计函数一起使用
SELECT Customer,SUM(OrderPrice) FROM Orders
WHERE Customer='Bush' OR Customer='Adams'
GROUP BY Customer
HAVING SUM(OrderPrice)>1500