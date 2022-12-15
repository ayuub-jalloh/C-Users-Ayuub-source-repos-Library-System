create table IRBook(
id int NOT NULL IDENTITY(1,1) primary key,
std_idnumber varchar(250) not null,
std_name varchar(250) not null,
std_dep varchar(250) not null,
std_sem varchar(250) not null,
std_contact bigint not null,
std_email varchar(250) not null,
book_name varchar(1250) not null,
book_issue_date varchar(250) not null,
book_return_date varchar(250),
);
select * from IRBook

select * from IRBook where std_idnumber = '1234' and book_return_date IS NULL