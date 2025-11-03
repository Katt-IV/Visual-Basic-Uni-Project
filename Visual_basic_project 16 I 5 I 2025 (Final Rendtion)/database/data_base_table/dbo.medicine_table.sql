CREATE TABLE [dbo].[medicine_table]
(
	[Id_medicine] INT NOT NULL PRIMARY KEY, 
    [medicine_name] NCHAR(20) NOT NULL, 
    [medicine_bulk_price] DECIMAL(6,2) NOT NULL, 
    [medicine_unit_price] DECIMAL(5,2) NOT NULL, 
    [number_of_units_in_stock] INT NOT NULL,
)
