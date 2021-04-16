CREATE TABLE Produtos(
 id bigint identity (0,1) primary key, 
 name varchar(20),
 description varchar(20),
 value decimal (10,2) default 0,
 brand varchar(20),
 category_id bigint foreign key references Categorias(id)
)