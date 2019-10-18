
SELECT LastName,FirstName FROM Persons

SELECT * FROM Persons

//关键词 DISTINCT 用于返回唯一不同的值
SELECT DISTINCT Company FROM Orders 

SELECT * FROM Persons WHERE City='Beijing'
SELECT * FROM Persons WHERE Year>1965

//AND OR 和 ORDER BY 的应用  DESC 降序 ASC 升序
SELECT * FROM Persons WHERE FirstName='Thomas' AND LastName='Carter'
SELECT * FROM Persons WHERE firstname='Thomas' OR lastname='Carter'
SELECT * FROM Persons WHERE (FirstName='Thomas' OR FirstName='William') AND LastName='Carter'
SELECT Company, OrderNumber FROM Orders ORDER BY Company, OrderNumber
SELECT Company, OrderNumber FROM Orders ORDER BY Company DESC, OrderNumber ASC

//INSERT INTO 插入语句
INSERT INTO Persons VALUES ('Gates', 'Bill', 'Xuanwumen 10', 'Beijing')
INSERT INTO Persons (LastName, Address) VALUES ('Wilson', 'Champs-Elysees')

//UPDATE 更新语句
UPDATE Person SET FirstName = 'Fred' WHERE LastName = 'Wilson'
UPDATE Person SET Address = 'Zhongshan 23', City = 'Nanjing' WHERE LastName = 'Wilson'

//DELETE 删除语句
DELETE FROM Person WHERE LastName = 'Wilson' 
DELETE FROM table_name
DELETE * FROM table_name

//TOP 语句
SELECT TOP 3 * FROM Persons  //去前三个
SELECT TOP 50 PERCENT * FROM Person //选取前 50% 的记录。

//LIKE 操作符 模糊匹配用
SELECT * FROM Persons WHERE City LIKE '%hai%'
SELECT * FROM Persons WHERE City NOT LIKE '%hai%'
SELECT * FROM Persons WHERE LastName LIKE 'C_r_er'
SELECT * FROM Persons WHERE City LIKE '[ALN]%' // "Persons" 表中选取居住的城市以 "A" 或 "L" 或 "N" 开头的人

//IN 操作符允许我们在 WHERE 子句中规定多个值
SELECT * FROM Persons WHERE LastName IN ('Adams','Carter')

//BETWEEN 操作符在 WHERE 子句中使用，作用是选取介于两个值之间的数据范围。
介于 "Adams"（包括）和 "Carter"（不包括）之间的人
SELECT * FROM Persons WHERE LastName BETWEEN 'Adams' AND 'Carter'
SELECT * FROM Persons WHERE LastName NOT BETWEEN 'Adams' AND 'Carter'

Alias 实例: 使用表名称别名
SELECT po.OrderID, p.LastName, p.FirstName
FROM Persons AS p, Product_Orders AS po
WHERE p.LastName='Adams' AND p.FirstName='John'
如果不用别名：
SELECT Product_Orders.OrderID, Persons.LastName, Persons.FirstName
FROM Persons, Product_Orders
WHERE Persons.LastName='Adams' AND Persons.FirstName='John'
别名把key重新命名
SELECT LastName AS Family, FirstName AS Name
FROM Persons

//Join 和 Key