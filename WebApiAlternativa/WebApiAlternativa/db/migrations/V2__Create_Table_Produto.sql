CREATE TABLE Produto(
 id bigint identity (0,1) primary key, 
 name varchar(20),
 description varchar(20),
 value decimal (10,2),
 brand varchar(20),
 category_id bigint foreign key references Categoria(id)
)