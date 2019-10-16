
SELECT LastName,FirstName FROM Persons

SELECT * FROM Persons

//关键词 DISTINCT 用于返回唯一不同的值
SELECT DISTINCT Company FROM Orders 

SELECT * FROM Persons WHERE City='Beijing'
SELECT * FROM Persons WHERE Year>1965

//AND OR 和 ORDER BY 的应用
SELECT * FROM Persons WHERE FirstName='Thomas' AND LastName='Carter'
SELECT * FROM Persons WHERE firstname='Thomas' OR lastname='Carter'
SELECT * FROM Persons WHERE (FirstName='Thomas' OR FirstName='William') AND LastName='Carter'
SELECT Company, OrderNumber FROM Orders ORDER BY Company, OrderNumber