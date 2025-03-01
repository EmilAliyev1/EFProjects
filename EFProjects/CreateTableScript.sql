CREATE TABLE Cars (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Brand NVARCHAR(50),
    Model NVARCHAR(50),
    Year INT,
    Price DECIMAL(18,2)
);

INSERT INTO Cars (Brand, Model, Year, Price)
VALUES ('BMW', 'M5', '2023', '10')