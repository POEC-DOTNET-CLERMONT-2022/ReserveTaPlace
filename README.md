# ReserveTaPlace

**Table of Contents**

[TOCM]

[TOC]

#Presentaion

##ReserveTaPlace, c'est quoi?

Notre projet ReserveTaPlace consiste à mettre en place un client lourd, permettant aux cinémas (zone de Clermont-Ferrand pour commencer) de pouvoir proposer leur scéances sur une plateforme commune. Le client léger permettre la gestion des utilisateurs et leur droit.

##Le client lourd, il sert à quoi ?

Chaque gérant devra pouvoir choisir le film qu'il désire proposer, soit en le recherchant sur l'API IMBD en ligne, et dans ce cas le film pourra être ajouté sur le serveur en base de données afin que les autres gérant puisse aussi le récupèrer, soit le récupèrer directement sur la base de données.
Chaque gérant pourra ensuite créer ses scéances de film avec ses horaires, dates, etc ...Une fois ajouteé, une séance sera visible sur une autre plateforme qui donnera la possibilité de reserver une place (cette partie ne sera pas développer lors de ce projet). 

##Les technoligie utilisés côté client lourd

Afin de mener à bien ce projet, la partie client lourd sera réaliser en dotnet core 6, la base de donnée sera mise en place grâce a Entity Framwork Core et sera installé sur Microsoft SQL Server, et on mettra en place une API web ASP.NET Core. La vue du client lourd s'affichera grâce à un client WPF.

##La base de données

La base de données sera commune à tous les cinémas, elle contiendra toutes les informations relatives aux utilisateurs, les cinémas, les séances, les commandes réalisées, etc ...

##Et le client léger alors, ses technologies ?

Le client leger sera réaliser avec Angular, il aura pour but de permettre la gestion des utilisateurs, avec toutes les possibilitées du CRUD.

#Travail réalisé

##Git et GitHub

Afin de réaliser ce projet, nous devions utiliser Git pour gérer les versions de notre application et GitHub pour son service d'hébergement. Il nous a permis de mettre en place des issues, afin  de partager le travail à réaliser, effectuer des pull request pour demander des contôles du code réaliser.

##Diagramme de classe



Projet ReserveTaPlace.com 

ReserveTaPlace.com devra permettre aux utilisateurs de réserver des places de cinéma en ligne, en choisissant sa séance et son cinéma. Il permet de trouver rapidement une séance correspondante grâce au nom du film.

L’administrateur général pourra ajouter des gérants de cinéma, en supprimer ou les modifier sur une interface web.

Depuis un client lourd les gérants de cinéma pourront ajouter, modifier et supprimer des films, créer des séances, pour leur cinéma. Ils pourront voir les statistiques de l’occupation de leurs salles.

Les clients auront accès à une interface web leur permettant de :

-Consulter la liste des films disponibles avec toutes les infos sur le film.

-Réserver une ou plusieurs places pour un ou plusieurs films.



