# Application de gestion MediaTek86

## 1. Contexte de la mission
Développement d'une application de bureau en C# (Windows Forms) pour le compte d'InfoTech Services 86. Ce projet permet au responsable de MediaTek86 de gérer son personnel et de suivre les absences via une interface sécurisée, reliée à une base de données MySQL.

## 2. Architecture et Modélisation
### Modèle Conceptuel de Données (MCD)
<img width="477" height="470" alt="MCD" src="https://github.com/user-attachments/assets/327f40b5-32b9-4cb3-b717-4d688b706af8" />

### Diagramme de paquetages
<img width="633" height="507" alt="Diagramme de paquetages" src="https://github.com/user-attachments/assets/43df1d7a-16b4-459a-b6b2-a34ca8f3936f" />

## 3. Interfaces de l'application
### Écran de connexion (Sécurisé)
<img width="802" height="484" alt="Login" src="https://github.com/user-attachments/assets/27231554-11b5-45c0-8cb2-49762675d923" />


### Interface de gestion du personnel
<img width="802" height="482" alt="Gestion du personnel" src="https://github.com/user-attachments/assets/8273df5e-bb86-48ac-9c1a-c44e909fb4af" />


### Interface de gestion des absences
<img width="804" height="482" alt="gestion absence" src="https://github.com/user-attachments/assets/edb53ac3-1a46-4254-9008-739cd186f8ab" />


## 4. Détail des Commits (Déroulé du projet)
* **Initialisation :** Mise en place du dépôt et création de la base de données MySQL (Jeu d'essai).
* **Architecture :** Implémentation du pattern MVC et de la couche DAL pour la connexion BDD.
* **Module Personnel :** Développement des fonctionnalités CRUD (Créer, Lire, Mettre à jour, Supprimer) pour les employés.
* **Module Absences :** Ajout de la gestion des motifs et des dates d'absence liées au personnel.
* **Sécurité :** Mise en place de l'authentification avec hachage des mots de passe en SHA-256.
* **Déploiement :** Génération de l'installateur (setup) et du script SQL final.
