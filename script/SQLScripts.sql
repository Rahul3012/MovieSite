//query to create database name Movie_Dev
create database Movie_Dev

//query to use Movie_Dev database
use Movie_Dev

//query to create PersonDetail Table
create Table CrewDetail(
Id int not null identity(1,1),
Type int not null,
Name varchar(50) not null,
DOB date,
Bio varchar(MAX),
Gender int not null,
Company varchar(50) null,
primary key (Id)
)

//query to create MovieDetail table
create table MovieDetail(
Id int not null identity(1,1),
Name varchar(50) not null,
ReleasedDate date,
Plot varchar(max),
Actors varchar(4000),
Producers varchar(500),
Poster varbinary(max)
)