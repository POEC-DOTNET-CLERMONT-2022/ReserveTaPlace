# ReserveTaPlace

# Table des matières
1. [Présentation](#presentation)
    -  [ReserveTaPlace, c'est quoi ?](#ReserveTaPlace,-c'est-quoi-?)
    -  [Le client lourd, il sert à quoi ?](#Le-client-lourd,-il-sert-à-quoi-?)
    -  [Les technoligies utilisés côté client lourd](#Les-technoligies-utilisés-côté-client-lourd)
    -  [La base de données](#La-base-de-données)
    -  [Et le client léger alors, ses technologies ?](#Et-le-client-léger-alors,-ses-technologies-?)
2. [Travail réalisé](#Travail-réalisé)
    -  [Git et GitHub](#Git-et-GitHub)
    -  [Diagramme de cas d'utilisation](#Diagramme-de-cas-d'utilisation)
    -  [Diagramme de classe](#Diagramme-de-classe)
    -  [Diagramme d'architecture](#Diagramme-architecture)
    -  [Extrait de maquettes réalisées](#Maquette)

# Présentation <a name="presentation"></a>

### ReserveTaPlace, c'est quoi ? <a name="ReserveTaPlace,-c'est-quoi-?"></a>

Notre projet ReserveTaPlace consiste à mettre en place un client lourd, permettant aux cinémas (zone de Clermont-Ferrand pour commencer) de pouvoir proposer leur scéances sur une plateforme commune. Le client léger permettra la gestion des utilisateurs et leur droit.

### Le client lourd, il sert à quoi ? <a name="Le-client-lourd,-il-sert-à-quoi-?"></a>

Chaque gérant devra pouvoir choisir le film qu'il désire proposer, soit en le recherchant sur l'API IMBD en ligne, et dans ce cas le film pourra être ajouté sur le serveur en base de données afin que les autres gérants puissent aussi le récupèrer, soit le récupèrer directement sur la base de données.
Chaque gérant pourra ensuite créer ses scéances de film avec ses horaires, dates, etc ...Une fois ajouté, une séance sera visible sur une autre plateforme qui donnera la possibilité de reserver une place (cette partie ne sera pas développer lors de ce projet). 

### Les technoligies utilisés côté client lourd <a name="Les-technoligies-utilisés-côté-client-lourd"></a>

Afin de mener à bien ce projet, la partie client lourd sera réaliser en dotnet core 6, la base de donnée sera mise en place grâce a Entity Framwork Core et sera installé sur Microsoft SQL Server, et on mettra en place une API web ASP.NET Core. La vue du client lourd s'affichera grâce à un client WPF.

### La base de données <a name="La-base-de-données"></a>

La base de données sera commune à tous les cinémas, elle contiendra toutes les informations relatives aux utilisateurs, les cinémas, les séances, les commandes réalisées, etc ...

### Et le client léger alors, ses technologies ? <a name="Et-le-client-léger-alors,-ses-technologies-?"></a>

Le client leger sera réaliser avec Angular, il aura pour but de permettre la gestion des utilisateurs, avec toutes les possibilitées du CRUD.

# Travail réalisé <a name="Travail-réalisé"></a>

### Git et GitHub <a name="Git-et-GitHub"></a>

Afin de réaliser ce projet, nous devions utiliser Git pour gérer les versions de notre application et GitHub pour son service d'hébergement. Il nous a permis de mettre en place des issues, afin  de partager le travail à réaliser, effectuer des pull request pour demander des contôles du code réaliser.

### Diagramme de cas d'utilisation <a name="Diagramme-de-cas-d'utilisation"></a>

![alt text](https://github.com/POEC-DOTNET-CLERMONT-2022/ReserveTaPlace/blob/2a564b79d3022adb4edb252483646e9151c721ed/Documentation/Images/UseCaseDiagramReserveTaPlace.svg)

### Diagramme de classe <a name="Diagramme-de-classe"></a>

### Diagramme d'architecture <a name="Diagramme-architecture"></a>

![alt text](https://github.com/POEC-DOTNET-CLERMONT-2022/ReserveTaPlace/blob/189ceb049cf0e0e27abcadcf997eb6db6ef41222/Documentation/Images/ArchiDiagram.drawio.png)

### Extrait de maquettes réalisées <a name="Maquette"></a>

![alt text](https://github.com/POEC-DOTNET-CLERMONT-2022/ReserveTaPlace/blob/a1281ec31f8d83f990e0752d64a3fcfdacabe254/Documentation/Images/Login.jpg)
![alt text](https://github.com/POEC-DOTNET-CLERMONT-2022/ReserveTaPlace/blob/a1281ec31f8d83f990e0752d64a3fcfdacabe254/Documentation/Images/Gestion%20films%20Mettre%20un%20film%20a%20l'affiche.jpg)
![alt text](https://github.com/POEC-DOTNET-CLERMONT-2022/ReserveTaPlace/blob/a1281ec31f8d83f990e0752d64a3fcfdacabe254/Documentation/Images/Gestion%20cin%C3%A9mas%20accueil.jpg)
![alt text](https://github.com/POEC-DOTNET-CLERMONT-2022/ReserveTaPlace/blob/a1281ec31f8d83f990e0752d64a3fcfdacabe254/Documentation/Images/Gestion%20cin%C3%A9mas%20Ajouter%20un%20cin%C3%A9ma.jpg)

Projet ReserveTaPlace.com 

ReserveTaPlace.com devra permettre aux utilisateurs de réserver des places de cinéma en ligne, en choisissant sa séance et son cinéma. Il permet de trouver rapidement une séance correspondante grâce au nom du film.

L’administrateur général pourra ajouter des gérants de cinéma, en supprimer ou les modifier sur une interface web.

Depuis un client lourd les gérants de cinéma pourront ajouter, modifier et supprimer des films, créer des séances, pour leur cinéma. Ils pourront voir les statistiques de l’occupation de leurs salles.

Les clients auront accès à une interface web leur permettant de :

-Consulter la liste des films disponibles avec toutes les infos sur le film.

-Réserver une ou plusieurs places pour un ou plusieurs films.



