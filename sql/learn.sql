
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

//