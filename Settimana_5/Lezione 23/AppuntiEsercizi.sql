--One to one

create table persona (
persona_id int auto_increment primary key,
nome varchar(100)
);


create table carta_identita (
id int auto_increment primary key,
numero_documento int unique,
persona_id int UNIQUE,
FOREIGN KEY (persona_id) REFERENCES persona(persona_id)
);

--Many to one

create table persona (
persona_id int auto_increment primary key,
nome varchar(100)
);


create table ordine (
id int auto_increment primary key,
persona_id int,
data_ordine date,
FOREIGN KEY (persona_id) REFERENCES persona(persona_id)
)

--many to many

create table attore (
attore_id int auto_increment primary key,
nome varchar(100)
);


create table film (
film_id int auto_increment primary key,
titolo varchar(100)
);



create table film_attore (
attore_id int,
film_id int,
primary key (attore_id, film_id),
foreign key (attore_id) references attore(attore_id),
foreign key (film_id) references film(film_id)
);

-- \Esercizio Ristorante\ --
Create DATABASE ristorante;

Create Table utente(
utente_id int Primary Key auto_increment,
nome varchar(100),
cognome varchar(100),
email varchar(100) UNIQUE NOT NULL,
telefono varchar(15) UNIQUE NOT NULL,
address_id int,
Foreign key (address_id) references address(address_id)
);

Create table address(
address_id int primary key auto_increment,
address varchar(100) unique Not null,
city varchar(100) default "Napoli",
postal_code varchar(10) Not null
);

Create table ordine(
ordine_id int primary key auto_increment,
utente_id int,
data_ordine datetime default NOW(),
foreign key (utente_id) references utente(utente_id)
);

Create table ordine_piatto(
ordine_id int,
piatto_id int,
primary key (ordine_id,piatto_id),
foreign key (piatto_id) references piatto(piatto_id),
foreign key (ordine_id) references ordine(ordine_id)
);

Create table piatto(
piatto_id int primary key auto_increment,
piatto_nome varchar(100) unique not null,
piatto_costo decimal not null
);

alter table piatto 
modify column piatto_costo float;

Create table ingrediente(
ingrediente_id int primary key auto_increment,
ingrediente_nome varchar(100) unique not null
);

Create table piatto_ingrediente(
piatto_id int,
ingrediente_id int,
primary key(ingrediente_id,piatto_id),
foreign key (ingrediente_id) references ingrediente(ingrediente_id),
foreign key (piatto_id) references piatto(piatto_id)
);

Create table pagamento(
pagamento_id int primary key auto_increment,
utente_id int, 
ordine_id int unique,
amount float,
foreign key (utente_id) references utente(utente_id),
foreign key (ordine_id) references ordine(ordine_id)
);


-- Esempi di query 
-- Seleziona tutti i piatti che hanno l'ingrediente pomodoro
Select p.piatto_nome, group_concat(i.ingrediente_nome separator "/ ") as ListaIngredienti
from piatto p
join piatto_ingrediente pi on pi.piatto_id=p.piatto_id
join ingrediente i on i.ingrediente_id=pi.ingrediente_id
group by p.piatto_id
having ListaIngredienti like "%pomodoro%";

-- Seleziona gli utenti che hanno una media di spesa per ordine maggiore della media
Select concat(u.nome, " ", u.cognome), sum(pa.amount)/count(distinct o.ordine_id) as spesa_media_per_ordine
from utente u
join pagamento pa on po.utente_id=u-utente_id
join ordine o on o.utente_id=u.utente_id
