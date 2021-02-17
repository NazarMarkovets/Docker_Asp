create database comments;
use comments;
create table comment(id int not null primary key, slur varchar(50) not null, body text not null);
insert into comments.comment values (1, 'test slur', 'test body text');