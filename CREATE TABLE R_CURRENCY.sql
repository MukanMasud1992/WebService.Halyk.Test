USE TEST
CREATE TABLE R_CURRENCY
(
   Id INT PRIMARY KEY IDENTITY,
    TITLE nvarchar(60) not null,
	CODE varchar(3)  not null,      
    VALUE Decimal (18,2)  not null,       
	A_DATE DATE  not null
)
DROP TABLE R_CURRENCY
