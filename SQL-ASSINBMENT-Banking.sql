--DDL- CREATE ALTER DROP TRUNCATE

CREATE DATABASE HMBANK



CREATE TABLE Customers(
customer_id int not null primary key,
first_name varchar(25),
last_name varchar(25),
DOB date,
email varchar(50),
phone_number int,
address varchar(255)
)



CREATE TABLE Accounts(
account_id int not null primary key,
customer_id int  ,
account_type varchar(20),
balance int,
foreign key (customer_id) references Customers(customer_id)
)

CREATE TABLE Transactions(
transaction_id int primary key,
account_id int,
transaction_type varchar(20),
amount int,
transaction_date date,
foreign key (account_id) references Accounts(account_id)

)

ALTER TABLE Transactions
ALTER COLUMN amount decimal;

ALTER TABLE Accounts
ALTER COLUMN balance decimal;


ALTER TABLE Customers
ALTER COLUMN phone_number varchar(11);

--Task1 ---

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(01,'Ashwin','S','2003-02-16','ashwin94429@gmail.com','7708567362','no 18,dhwqdun uquindq diudhnqud q')
INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(02,'Ann','paul','2002-05-22','annpaul@gmail.com','7708567362','no 3,dhwqdun uquindq diudhnqud djk dwkejfq')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(03,'Ashefa','j','2002-11-03','ashefa@gmail.com','9708567362','no 19,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(04,'Indra','priya','2003-02-28','indrapriya@gmail.com','8708567362','no 25,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(05,'Saran','kumar','2002-08-9','saran@gmail.com','7708576362','no 9,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(06,'Thalapathi','R','2001-05-28','thalapathi@gmail.com','8608567362','no 10,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(07,'Dharsan','S','2003-10-29','dharsan@gmail.com','7708569062','no 28,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(08,'Harish','Kumar','2003-03-18','harish@gmail.com','9808567362','no 37,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(09,'Barath','Raj','2003-06-17','barath@gmail.com','8908567362','no 48,dhwqdun uquindq diudhnqud q')

INSERT INTO Customers(customer_id,first_name,last_name,DOB,email,phone_number,[address]) values(10,'Varun','Kumar','2003-09-18','varun@gmail.com','7008567362','no 28,dhwqdun qdhjkbedu wuehyff uquindq diudhnqud q')

select * from Customers;
select * from Accounts;


select * from Customers
FULL OUTER JOIN Accounts
on Customers.customer_id=
Accounts.customer_id 

TRUNCATE TABLE Customers;

DELETE FROM Customers;


INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1001,1, 'Savings', 5000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1002,2, 'Current', 7000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1003,3, 'Savings', 3000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1004,4, 'Current', 15000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1005,5, 'zero_balance', 10000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1006,6, 'Savings', 8000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1007,7, 'zero_balance', 20000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1008,8, 'Current', 6000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1009,9, 'Savings', 4000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1010,10, 'zero_balance', 9000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1011,10, 'Savings', 10000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1012,10, 'Current', 4000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1013,11, 'Savings', 4000);

INSERT INTO Accounts (account_id, customer_id, account_type, balance) VALUES (1014,3, 'Savings', 1000);




select * from Transactions

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (101, 1001, 'deposit', 1000.00, '2024-02-28');


INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (102, 1002, 'withdrawal', 500.00, '2024-02-28');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (103, 1003, 'deposit', 1500.00, '2024-02-27');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (104, 1004, 'transfer', 200.00, '2024-02-27');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (105, 1005, 'withdrawal', 300.00, '2024-02-26');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (106, 1006, 'deposit', 800.00, '2024-02-26');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (107, 1007, 'transfer', 400.00, '2024-02-25');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (108, 1008, 'withdrawal', 100.00, '2024-02-25');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (109, 1009, 'deposit', 2000.00, '2024-02-24');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (110, 1010, 'withdrawal', 700.00, '2024-02-24');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (110, 1010, 'withdrawal', 700.00, '2024-02-24');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (111, 1005, 'withdrawal', 700.00, '2024-02-24');

INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (113, 1005, 'withdrawal',10000.00, '2024-03-29');


INSERT INTO Transactions (transaction_id, account_id, transaction_type, amount, transaction_date) VALUES (112, 1005, 'deposit', 700.00, '2024-02-24');


--Task 2--

--1Write a SQL query to retrieve the name, account type and email of all customers.

select Customers.first_name,Customers.last_name,Accounts.account_type,Customers.email from Customers join Accounts on Customers.customer_id= Accounts.customer_id;

--2. Write a SQL query to list all transaction corresponding customer.
select *,concat(Customers.first_name,Customers.last_name) from Transactions 
join Accounts on Transactions.account_id= Accounts.account_id 
join Customers on
Customers.customer_id= Accounts.customer_id 
where Customers.customer_id= 5


--3. Write a SQL query to increase the balance of a specific account by a certain amount.update Accounts set balance= balance + 4000 where customer_id=1;select * from Accounts--4. Write a SQL query to Combine first and last names of customers as a full_name.select concat_ws(' ',first_name,last_name) from Customers;--5. Write a SQL query to remove accounts with a balance of zero where the account type is savings.delete  Accounts from Customers join Accounts on Customers.customer_id= Accounts.customer_idwhere Accounts.balance=0 and Accounts.account_type='Savings' delete Accounts where Accounts.balance=0 and Accounts.account_type='Savings'  delete from Accounts where Accounts.account_id=1003 and Accounts.account_type='Savings' delete from Customers
where customer_id NOT IN (
    select  customer_id
    from  Accounts
);

select * from Customers

--6. Write a SQL query to Find customers living in a specific city.select * from Customerswhere address = 'Chennai'-- 7. Write a SQL query to Get the account balance for a specific account.select concat(Customers.first_name,Customers.last_name),balance from Customers join Accountson Customers.customer_id= Accounts.customer_idwhere Customers.customer_id=5;-- 8. Write a SQL query to List all current accounts with a balance greater than $1,000.select concat(Customers.first_name,Customers.last_name),balance from Customers join Accountson Customers.customer_id= Accounts.customer_idwhere Accounts.account_type='Current' and Accounts.balance> 1000--9. Write a SQL query to Retrieve all transactions for a specific account.select * from Transactions where account_id= 1005;--10 Calculate Simple interest selectaccount_id, balance * 0.045 as Interest FromAccountsWhere account_type = 'Savings'-- 11. Write a SQL query to Identify accounts where the balance is less than a specified overdraft limit. select concat(Customers.first_name,Customers.last_name), Accounts.balance from Customers join Accounts on Customers.customer_id = Accounts.customer_id where Accounts.balance >= 9000;--12. Write a SQL query to Find customers not living in a specific city.select * from Customers where address not in (Select address from Customers where address='Chennai')--Task 3--1.1. Write a SQL query to Find the average account balance for all customers. select AVG(balance) as avg_balance from Accounts;--2. Write a SQL query to Retrieve the top 10 highest account balances.select top 10 balance,account_id as ACCOUNT_ID from Accounts Order by balance desc;--3. Write a SQL query to Calculate Total Deposits for All Customers in specific date.select sum(amount) as [Deposit Ammount] from Transactions where transaction_date='2024-02-24' and transaction_type='deposit'--4. Write a SQL query to Find the Oldest and Newest Customers.SELECT concat(first_name,last_name),dob from Customerswhere dob=(select min(dob) from Customers) ORDOB=(select max(DOB) from Customers)--5. Write a SQL query to Retrieve transaction details along with the account type.select T.*,A.account_id,A.account_type from Transactions as T joinAccounts as Aon A.account_id= T.account_id;--6. Write a SQL query to Get a list of customers along with their account details.select concat(C.first_name,C.last_name) as full_name,A.*from Customers as C join Accounts as Aon C.customer_id= A.customer_id;--7. Write a SQL query to Retrieve transaction details along with customer information for a specific account.select T.*,concat(C.first_name,C.last_name) as [FULL NAME] from Transactions as T
join Accounts as A on T.account_id= A.account_id 
join Customers as C on
C.customer_id= A.customer_id 
where A.account_id=1005;

-- 8. Write a SQL query to Identify customers who have more than one account.select customer_id,Count(Account_id) as [Accounts]from AccountsGroup by customer_idHaving count(account_id) >1;
--9. Write a SQL query to Calculate the difference in transaction amounts between deposits and withdrawals.SELECT
    SUM(CASE WHEN transaction_type = 'Deposit' THEN amount ELSE 0 END) -
    SUM(CASE WHEN transaction_type = 'Withdrawal' THEN amount ELSE 0 END) AS difference
FROM
    transactions;
--10. Write a SQL query to Calculate the average daily balance for each account over a specified period.	SELECT A.account_id,AVG(A.balance)	FROM Accounts as A	JOIN Transactions as T	on A.account_id = T.account_id	WHERE T.transaction_date between '01-01-2024' AND '02-04-2025'	GROUP BY A.account_id-- 11. Calculate the total balance for each account type.select concat_ws('-',sum(balance), account_type) as [Total-Balance]from Accountsgroup by account_type--12. Identify accounts with the highest number of transactions order by descending order.select A.account_id,count(T.transaction_id) fromAccounts as A join Transactions as Ton A.account_id = T.account_idGroup by A.account_idorder by count(A.account_id) desc--	13. List customers with high aggregate account balances, along with their account types.select concat(C.first_name, C.last_name),sum(A.balance)from Customers as C joinAccounts as A on C.customer_id = A.customer_idgroup by C.first_name,C.customer_id,C.last_name--14. Identify and list duplicate transactions based on transaction amount, date, and account.SELECT account_id,amount,transaction_date,count(*) As duplicate from TransactionsGroup BY account_id,amount,transaction_dateHaving count(*)>1select * from Transactions-- task 4--1. Retrieve the customer(s) with the highest account balance.select * from Customerswhere customer_id in(select customer_id from Accounts where balance=(select max(balance) from Accounts))--2 2. Calculate the average account balance for customers who have more than one account.select customer_id,avg(avg_bal) as average from (select customer_id ,avg(balance) as avg_balfrom accountsgroup by customer_idhaving count(account_id) >1) as subgroup by customer_id--3. Retrieve accounts with transactions whose amounts exceed the average transaction amount.select Accounts.account_id,Accounts.customer_id,Transactions.* from 
Accounts join Transactions 
on Accounts.account_id = Transactions.account_id
where Transactions.transaction_type='withdrawal' and Transactions.amount>=10000


--4. Identify customers who have no recorded transactions.SELECT C.* from 
Customers as C JOIN
Accounts as A on C.customer_id= A.customer_id
where A.account_id NOT IN (
	SELECT account_id
	FROM Transactions
)

--5. Calculate the total balance of accounts with no recorded transactions.SELECT sum(A.balance) as total from 
Customers as C JOIN
Accounts as A on C.customer_id= A.customer_id
where A.account_id NOT IN (
	SELECT account_id
	FROM Transactions
)

--6. Retrieve transactions for accounts with the lowest balance.
SELECT * 
FROM Transactions 
WHERE account_id = (
	SELECT account_id from Accounts 
	WHERE balance= (SELECT MIN(balance) from Accounts)
)


--7. Identify customers who have accounts of multiple types.
SELECT * FROM 
Customers where 
customer_id IN (
	SELECT customer_id 
	FROM Accounts 
	Group by customer_id
	HAVING count(customer_id)>1
	)


	select * from Accounts

--8. Calculate the percentage of each account type out of the total number of accounts.SELECT
    account_type,
    COUNT(account_type) AS account_count,
    ROUND(COUNT(*) * 100.0 / (SELECT COUNT(*) FROM accounts), 2) AS percentage
FROM accounts
GROUP BY account_type;
--9. Retrieve all transactions for a customer with a given customer_id.SELECT * FROM Transactionswhere account_id in (		SELECT account_id 		FROM Accounts 		WHERE customer_id = 5		)--10. Calculate the total balance for each account type, including a subquery within the SELECT clauseSELECT A.account_type,(SELECT SUM(balance) from Accounts where account_type = A.account_type) as TotalFROM   (SELECT DISTINCT account_type FROM Accounts) AS A;


