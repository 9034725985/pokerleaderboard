-- postgres://xukiiogf:REkQDxhkxXdSd9Yj7gbj75ovitfPxr7k@balarama.db.elephantsql.com:5432/xukiiogf

drop table person;
drop table  lookup_country;

create table lookup_country
(
  id varchar(255) default gen_random_uuid() primary key,
  full_name varchar(255) not null,
  abbreviation varchar(10) not null
);

create table person
(
  id varchar(255) default gen_random_uuid() primary key,
  full_name varchar(255) not null,
  winnings decimal(19,4) not null default 0,
  country varchar(255) not null references lookup_country (id)
);

insert into lookup_country
(
  full_name, abbreviation
)
values
('United States of America', 'USA'),
('Great Britain', 'GBR');

insert into person(full_name,country)
select person_name,id
from 
(
    values 
    ('Antonio Esfandiari'),
    ('Daniel Negreanu'),
    ('Erik Seidel'),
    ('Phil Hellmuth')
) as person (person_name)
cross join (select id from lookup_country where abbreviation = 'USA') c;

select * from person;