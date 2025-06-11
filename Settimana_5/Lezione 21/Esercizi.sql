/* LOCATE(substr, str)
Restituisce la posizione della prima occorrenza della sottostringa substr nella stringa str. Se non trova nulla, restituisce 0. */

SELECT title, LOCATE('DOG', title) AS posizione_dog
FROM film
WHERE LOCATE('DOG', title) > 0;

-- TROVARE DOVE SI TROVA IL CARATTERE "A" NEL NOME DEGLI ATTORI --
SELECT first_name, last_name, LOCATE('A', first_name) AS posizione_a
FROM actor
WHERE LOCATE('A', first_name) > 0;

-- SUBSTRING(string, start, length) // SUBSTRING(string FROM start FOR length) --

-- ESTRARRE I PRIMI 5 CARATTERI DEI TITOLI --
SELECT title, SUBSTRING(title, 1, 5) AS primi_cinque
FROM film;

-- Estrarre l'ultima parte del cognome --
SELECT last_name, SUBSTRING(last_name, LENGTH(last_name) - 2, 3) AS ultimi_tre
FROM actor
WHERE LENGTH(last_name) >= 3;

-- LOCATE + SUBSTRING – estrarre tutto dopo “AT” nel titolo --
SELECT title, SUBSTRING(title, LOCATE('AT ', title) + 3) AS dopo_at
FROM film
WHERE LOCATE('AT ', title) > 0;


-- Cerca l’ultimo spazio (con REVERSE) e ricava da lì la ultima parola. --
SELECT title, SUBSTRING(title, LENGTH(title) - LOCATE(' ', REVERSE(title)) + 2) AS ultima_parola
FROM film
WHERE title LIKE '% %';


--ESERCIZI MATTINA 10/06

-- Conta quanti film ci sono per ciascun rating
Select rating,Count(title) from film
group by rating;

-- Durata media di tutti i film
Select avg(length) from film;

-- Durata min e max dei film
Select min(length),max(length) from film;

-- Somma totale pagamenti
Select Sum(amount) from payment;

-- Durata media film per ciascun rating
Select rating, avg(length) from film
group by rating;

-- Numero totale pagamenti effettuati da ciascun cliente
Select customer_id,Count(payment_id) as PagamentiFatti from payment
group by customer_id;

-- Calcolo importo totale pagati da ciascun cliente
Select customer_id,Sum(amount) as SpesaTotale from payment
group by customer_id;

-- Numero di film per ciascuna lunghezza
Select length,Count(title) as NumeroFilm from film
group by length
order by NumeroFilm DESC;

-- Rating con una durata media dei film superiore a 100
Select rating,Avg(length) as MediaDurata 
from film
group by rating
having avg(length)>113;

-- I clienti che hanno pagato più di 100 euro
Select customer_id, Sum(amount) as TotaleSpeso
from payment
group by customer_id
having sum(amount)>150;

-- Rating in cui sono presenti almeno 50 film
Select rating, count(film_id) as NumeroFilm
from film
group by rating
having count(film_id)>50;

-- Ciascun rating la durata media dei film arrotondata a 1 decimale
Select rating, round(avg(length),1) as Media1Dec
from film
group by rating;

-- clienti con piu di 10 pagamenti
Select customer_id, count(payment_id) as NumeroPagamenti, sum(amount) as Spesa
from payment
group by customer_id
having count(payment_id)>13
order by NumeroPagamenti;


-----ESERCIZI SULLE JOIN AIUT-----

select film.title, language.name as language
FROM film
join language ON film.language_id =language.language_id;

select * from film;

select* from language;

select film.title, language.name as language
FROM film
join language ON film.language_id =language.language_id;

Select* from customer
join store on customer.store_id=store.store_id;

Select film.title, category.name 
from film
join film_category on film.film_id=film_category.film_id
join category on film_category.category_id=category.category_id;

SELECT customer.first_name,city.city, address.address,country.country
FROM customer
JOIN address ON address.address_id = customer.address_id
JOIN city ON city.city_id=address.city_id
JOIN country ON country.country_id=city.country_id;

SELECT rental.rental_id, concat(customer.first_name, " ", customer.last_name) as Cliente, concat(staff.first_name, " ", staff.last_name) as ServitoDa
FROM rental
JOIN customer ON customer.customer_id=rental.customer_id
JOIN staff ON staff.staff_id=rental.staff_id
order by rental_id;

Select category.name, count(film.film_id)
from film
join film_category on film.film_id=film_category.film_id
join category on film_category.category_id=category.category_id
group by category.name;

Select category.name, count(film.film_id)
from category
join film_category on category.category_id=film_category.category_id
join film on film_category.film_id=film.film_id
group by category.name;

Select concat(actor.first_name, " ", actor.last_name) as Attore, count(film.film_id) as NumeroFilm
from actor
JOIN film_actor on actor.actor_id=film_actor.actor_id
JOin film on film.film_id=film_actor.film_id
group by concat(actor.first_name, " ", actor.last_name)
order by NumeroFilm DESC;

-- Mostra il nome del film la sua categoria e gli attori che vi hanno recitato
Select f.title as Titolo, group_concat(actor.first_name, " ", actor.last_name separator ", ") as Attore, category.name as Categoria
From film f
JOIN film_actor ON f.film_id=film_actor.film_id 
JOIN actor ON film_actor.actor_id=actor.actor_id
JOIN film_category ON f.film_id=film_category.film_id
JOIN category ON film_category.category_id=category.category_id
group by f.title, category.name
order by Titolo;

 -- Clienti che hanno effettuato piu di 5 noleggi 
 Select concat(c.first_name, " ", c.last_name) as Cliente ,count(rental.rental_id) as NumeroNoleggi
 from customer c
 JOIN rental on c.customer_id=rental.customer_id
 group by c.customer_id
 having count(rental.rental_id)>20
 order by NumeroNoleggi ASC;
 
 -- Film mai noleggiati
Select f.title
from film f
JOIN inventory ON f.film_id=inventory.film_id
JOIN rental ON inventory.inventory_id
where rental.rental_date is null;


--  \Titolo del film categoria e il totale speso dai clienti\ --
Select f.title as Titolo, category.name as Categoria, sum(payment.amount) as SpeseNoleggio
from film f
-- prendiamo le categorie
JOIN film_category ON f.film_id=film_category.film_id
JOIN category ON film_category.category_id=category.category_id
-- prendiamo i pagamenti da inventory che va rental che va a payment
JOIN inventory ON f.film_id=inventory.film_id
JOIN rental ON inventory.inventory_id=rental.inventory_id
JOIN payment ON rental.rental_id=payment.rental_id
group by Titolo, Categoria
order by Titolo;

-- \Trova gli attori che non hanno mai recitato in una categoria determinata\ --
Select concat(a.first_name, " ", a.last_name) as Attore, group_concat(category.name separator ", ") as Categorie
from actor a
JOIN film_actor ON a.actor_id=film_actor.actor_id
JOIN film ON film_actor.film_id=film.film_id 
JOIN film_category ON film.film_id=film_category.film_id
JOIN category ON film_category.category_id=category.category_id
group by Attore
having Categorie not like "%Action%"
order by Categorie;

-- \Trova le categorie di film con il numero medio di attori più alto\ --
Select category.name as Categoria,
count(actor.actor_id)/count(DISTINCT film.film_id) as MediaAttori
from category
JOIN film_category ON category.category_id=film_category.category_id
JOIN film ON film_category.film_id=film.film_id
JOIN film_actor ON film.film_id=film_actor.film_id 
JOIN actor ON film_actor.actor_id=actor.actor_id
group by Categoria;

-- \Clienti con più di 20 noleggi totali ordineati per spesa totale decrescente\ --
Select c.customer_id as Id,
concat(c.first_name, " ", c.last_name) as Cliente ,
count(rental.rental_id) as NumeroNoleggi,
sum(payment.amount) as SpesaTotale
from customer c
JOIN rental on c.customer_id=rental.customer_id
JOIN payment on rental.rental_id=payment.rental_id
group by c.customer_id
having count(rental.rental_id)>20
order by SpesaTotale DESC;

-- \Numero medio di noleggi per categoria di film\ --
Select category.name as Categoria,
count(rental.rental_id)/count(DISTINCT film.film_id) as MediaNoleggi,
count(rental.rental_id) as NumeroNoleggi,
count(distinct film.film_id) as NumeroFilm
from category
JOIN film_category ON category.category_id=film_category.category_id
JOIN film ON film_category.film_id=film.film_id
JOIN inventory ON film.film_id=inventory.film_id
JOIN rental ON inventory.inventory_id=rental.inventory_id
group by Categoria
having count(rental.rental_id)>50
order by MediaNoleggi DESC;

-- \Attori con + film a catalogo e noleggi totali
Select concat(a.first_name, " ", a.last_name) as Attore, count(rental.rental_id) as FilmNoleggiati
From actor a
JOIN film_actor on a.actor_id=film_actor.actor_id
JOiN film on film_actor.film_id=film.film_id
JOIN inventory ON film.film_id=inventory.film_id
JOIN rental ON inventory.inventory_id=rental.inventory_id
group by Attore
having count(film.film_id)>10
order by FilmNoleggiati DESC;

-- \Categorie più redditizie\ --
Select category.name as Categoria,
sum(payment.amount)/count(distinct film.film_id) as MediaGuadagni
from category
JOIN film_category ON category.category_id=film_category.category_id
JOIN film ON film_category.film_id=film.film_id
JOIN inventory ON film.film_id=inventory.film_id
JOIN rental ON inventory.inventory_id=rental.inventory_id
JOIN payment ON rental.rental_id=payment.rental_id
group by Categoria
order by MediaGuadagni DESC;

azzirato#070