-- \ESERCIZI SU SUBQUERY\ --
INSERT INTO actor (first_name, last_name, last_update)
VALUES ('Mario', 'Rossi', NOW());

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
JOIN film_actor fa ON a.actor_id = fa.actor_id
JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
LEFT JOIN film_actor fa ON a.actor_id = fa.actor_id
LEFT JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';

Select title, length 
from film
where length >(
	Select Avg(length)
    from film
);

Select f.title, actor_count
FROM(
	SELECT fa.film_id,Count(*) as actor_count
    From film_actor fa
    GROUP BY fa.film_id
) AS film_actor_count
JOIN film f ON film_actor_count.film_id=f.film_id
order by actor_count DESC;

Select f.title,f.rental_rate
from film f
where f.rental_rate>(
Select avg(film.rental_rate)
from film
)
order by f.rental_rate DESC;

Select concat(actor.first_name, " ", actor.last_name) as AttoriFilmAction
from actor
where actor_id IN (
	SELECT distinct a.actor_id
    from actor a
    join film_actor fa on fa.actor_id=a.actor_id
    join film f on f.film_id=fa.film_id
    join film_category fc on f.film_id=fc.film_id
    join category c on fc.category_id=c.category_id
    where c.name like "Action"
)

INSERT INTO actor (first_name, last_name, last_update)
VALUES ('Mario', 'Rossi', NOW());

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
JOIN film_actor fa ON a.actor_id = fa.actor_id
JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';

SELECT a.actor_id, a.first_name, a.last_name, f.title
FROM actor a
LEFT JOIN film_actor fa ON a.actor_id = fa.actor_id
LEFT JOIN film f ON fa.film_id = f.film_id
WHERE a.first_name = 'Mario';

Select title, length 
from film
where length >(
	Select Avg(length)
    from film
);

Select f.title, fac.actor_count
FROM(
	SELECT fa.film_id,Count(*) as actor_count
    From film_actor fa
    GROUP BY fa.film_id
) AS fac
JOIN film f ON fac.film_id=f.film_id
order by fac.actor_count DESC;

Select f.title,f.rental_rate
from film f
where f.rental_rate>(
Select avg(film.rental_rate)
from film
)
order by f.rental_rate DESC;

Select concat(actor.first_name, " ", actor.last_name) as AttoriFilmAction
from actor
where actor_id IN (
	SELECT distinct a.actor_id
    from actor a
    join film_actor fa on fa.actor_id=a.actor_id
    join film f on f.film_id=fa.film_id
    join film_category fc on f.film_id=fc.film_id
    join category c on fc.category_id=c.category_id
    where c.name like "Action"
);

-- \Trova i titoli dei film con lo stesso numero di attori di academy dinosaur\ --
Select f.title, fac.actor_count
FROM(
	SELECT fa.film_id,Count(*) as actor_count
    From film_actor fa
    GROUP BY fa.film_id
) AS fac
JOIN film f ON fac.film_id=f.film_id
where fac.actor_count = (
Select Count(*) 
from film_actor fa
Join film f2 on fa.film_id=f2.film_id
where f2.title="ACADEMY DINOSAUR"
group by fa.film_id -- non necessario potrebbe anche non esserci
)
order by f.title;

-- \Traccia: categprie con film maggiori della media dei film per categoria
SELECT c.name, COUNT(fc.film_id) AS num_film
FROM category c
JOIN film_category fc ON c.category_id = fc.category_id
GROUP BY c.category_id
HAVING COUNT(fc.film_id) > (
SELECT AVG(film_count)
FROM (
SELECT COUNT(*) AS film_count
FROM film_category
GROUP BY category_id
) AS sub
);

-- \clienti che hanno speso più della media delle spese totali\ --
Select concat(c.first_name, " ", c.last_name) as Cliente, sum(p.amount) as SpesaTotale
from customer c
join payment p on p.customer_id=c.customer_id
group by Cliente
having SpesaTotale > (
Select sum(p.amount)/count(distinct c.customer_id)
from payment p
join customer c on c.customer_id=p.customer_id
)
order by SpesaTotale DESC;

-- \Titoli mai noleggiati\ --
Select f.title
from film f
join inventory i on f.film_id=i.film_id
join rental r on r.inventory_id=i.inventory_id
where r.rental_date is null;

-- Con subquery
Select f.title
from film f
where f.film_id NOT IN(
	Select Distinct i.film_id
    from inventory i
    Join rental r on i.inventory_id=r.inventory_id
);

-- Film con la durata più lunga per ogni categoria
Select c.name as Categoria, f.title as Titolo, f.length as Durata
from film f
join film_category fc on f.film_id=fc.film_id
join category c on fc.category_id=c.category_id
where f.length = (
	Select max(f2.length)
    from film f2 
    Join film_category fc2 on fc2.film_id=f2.film_id
    where fc2.category_id= fc.category_id 
) 
order by Categoria;

-- attori i cui film sono stati noleggiati meno rispetto alla media di tutti gli attori
Select concat(actor.first_name, " ", actor.last_name) as AttoriFilm, count(r.rental_id) as Noleggi
from actor 
join film_actor fa on fa.actor_id=actor.actor_id  
join film f on f.film_id=fa.film_id
join inventory i on i.film_id=f.film_id
join rental r on r.inventory_id=i.inventory_id
group by AttoriFilm
having Noleggi<(
	Select count(r.rental_id)/count(distinct actor.actor_id) 
	from actor 
    join film_actor fa on fa.actor_id=actor.actor_id  
	join film f on f.film_id=fa.film_id
	join inventory i on i.film_id=f.film_id
	join rental r on r.inventory_id=i.inventory_id
	)
order by Noleggi;

--  Paesi i cui clienti noleggiano più rispetto alla media in aggiunta il numero totale di clienti per ciascun paese
Select co.country as Paese, count(distinct c.customer_id) as NumeroClienti, count(r.rental_id) as Noleggi
from customer c
join rental r on r.customer_id=c.customer_id
join address a on a.address_id=c.address_id
join city ci on ci.city_id=a.city_id
join country co on co.country_id=ci.country_id
group by Paese
having Noleggi>(
	Select count(r2.rental_id)/count(distinct co2.country_id)
    from rental r2
    join customer c2 on c2.customer_id=r2.customer_id
    join address a2 on a2.address_id=c2.address_id
	join city ci2 on ci2.city_id=a2.city_id
	join country co2 on co2.country_id=ci2.country_id
);

-- rental_rate che hanno un costo di noleggio superiore al rentalt rate medio 
SELECT f.title,f.rental_rate,f.rating
FROM
    film AS f
WHERE f.rental_rate > (
	SELECT AVG(f2.rental_rate)
	FROM film AS f2
	WHERE f2.rating = f.rating
    )
ORDER BY
    f.rating, f.title;