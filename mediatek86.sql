-- phpMyAdmin SQL Dump
-- version 5.2.3
-- https://www.phpmyadmin.net/
--
-- Hôte : 127.0.0.1:3306
-- Généré le : dim. 31 mai 2026 à 18:46
-- Version du serveur : 8.4.7
-- Version de PHP : 8.3.28

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de données : `mediatek86`
--
CREATE DATABASE IF NOT EXISTS `mediatek86` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci;
USE `mediatek86`;

-- Création de l'utilisateur de l'application et attribution des droits
CREATE USER 'admin_mediatek'@'localhost' IDENTIFIED BY 'admin';
GRANT ALL PRIVILEGES ON mediatek86.* TO 'admin_mediatek'@'localhost';
FLUSH PRIVILEGES;

-- --------------------------------------------------------

--
-- Structure de la table `absence`
--

DROP TABLE IF EXISTS `absence`;
CREATE TABLE IF NOT EXISTS `absence` (
  `idpersonnel` int NOT NULL,
  `datedebut` datetime NOT NULL,
  `datefin` datetime DEFAULT NULL,
  `idmotif` int NOT NULL,
  PRIMARY KEY (`idpersonnel`,`datedebut`),
  KEY `idmotif` (`idmotif`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `absence`
--

INSERT INTO `absence` (`idpersonnel`, `datedebut`, `datefin`, `idmotif`) VALUES
(1, '2023-01-10 08:00:00', '2023-01-12 18:00:00', 2),
(1, '2023-04-05 08:00:00', '2023-04-05 18:00:00', 3),
(1, '2023-08-01 08:00:00', '2023-08-15 18:00:00', 1),
(1, '2023-11-20 08:00:00', '2023-11-22 18:00:00', 2),
(1, '2024-02-10 08:00:00', '2024-02-15 18:00:00', 1),
(2, '2023-02-14 08:00:00', '2023-02-14 18:00:00', 3),
(2, '2023-05-10 08:00:00', '2023-05-15 18:00:00', 2),
(2, '2023-09-01 08:00:00', '2023-09-10 18:00:00', 1),
(2, '2023-12-24 08:00:00', '2023-12-31 18:00:00', 1),
(2, '2024-03-01 08:00:00', '2024-03-05 18:00:00', 2),
(3, '2023-01-02 08:00:00', '2023-01-05 18:00:00', 2),
(3, '2023-06-20 08:00:00', '2023-06-25 18:00:00', 1),
(3, '2023-10-15 08:00:00', '2023-10-16 18:00:00', 3),
(3, '2024-01-10 08:00:00', '2024-01-15 18:00:00', 2),
(3, '2024-04-05 08:00:00', '2024-04-10 18:00:00', 1),
(4, '2022-11-01 08:00:00', '2023-05-01 18:00:00', 4),
(4, '2023-07-10 08:00:00', '2023-07-25 18:00:00', 1),
(4, '2023-11-05 08:00:00', '2023-11-08 18:00:00', 2),
(4, '2024-02-20 08:00:00', '2024-02-22 18:00:00', 3),
(4, '2024-05-15 08:00:00', '2024-05-20 18:00:00', 1),
(5, '2023-03-10 08:00:00', '2023-03-12 18:00:00', 2),
(5, '2023-08-15 08:00:00', '2023-08-30 18:00:00', 1),
(5, '2023-12-01 08:00:00', '2023-12-05 18:00:00', 2),
(5, '2024-03-15 08:00:00', '2024-03-15 18:00:00', 3),
(5, '2024-06-01 08:00:00', '2024-06-10 18:00:00', 1),
(6, '2023-01-20 08:00:00', '2023-01-25 18:00:00', 2),
(6, '2023-05-05 08:00:00', '2023-05-05 18:00:00', 3),
(6, '2023-09-15 08:00:00', '2023-09-30 18:00:00', 1),
(6, '2024-01-05 08:00:00', '2024-01-10 18:00:00', 2),
(6, '2024-04-20 08:00:00', '2024-04-25 18:00:00', 1),
(7, '2023-02-05 08:00:00', '2023-02-10 18:00:00', 2),
(7, '2023-07-01 08:00:00', '2023-07-15 18:00:00', 1),
(7, '2023-10-05 08:00:00', '2023-10-05 18:00:00', 3),
(7, '2024-02-14 08:00:00', '2024-02-18 18:00:00', 2),
(7, '2024-05-01 08:00:00', '2024-05-10 18:00:00', 1),
(8, '2023-03-20 08:00:00', '2023-03-25 18:00:00', 2),
(8, '2023-08-05 08:00:00', '2023-08-20 18:00:00', 1),
(8, '2023-11-15 08:00:00', '2023-11-15 18:00:00', 3),
(8, '2024-03-10 08:00:00', '2024-03-15 18:00:00', 2),
(8, '2024-06-15 08:00:00', '2024-06-25 18:00:00', 1),
(9, '2023-04-10 08:00:00', '2023-04-15 18:00:00', 2),
(9, '2023-09-05 08:00:00', '2023-09-20 18:00:00', 1),
(9, '2023-12-10 08:00:00', '2023-12-10 18:00:00', 3),
(9, '2024-04-01 08:00:00', '2024-04-05 18:00:00', 2),
(9, '2024-07-01 08:00:00', '2024-07-15 18:00:00', 1),
(10, '2023-05-20 08:00:00', '2023-05-25 18:00:00', 2),
(10, '2023-10-10 08:00:00', '2023-10-25 18:00:00', 1),
(10, '2024-01-20 08:00:00', '2024-01-20 18:00:00', 3),
(10, '2024-05-20 08:00:00', '2024-05-25 18:00:00', 2),
(10, '2024-08-01 08:00:00', '2024-08-15 18:00:00', 1),
(1, '2023-01-10 00:00:00', '2023-01-12 00:00:00', 2),
(1, '2023-11-20 00:00:00', '2023-11-22 00:00:00', 2);

-- --------------------------------------------------------

--
-- Structure de la table `motif`
--

DROP TABLE IF EXISTS `motif`;
CREATE TABLE IF NOT EXISTS `motif` (
  `idmotif` int NOT NULL AUTO_INCREMENT,
  `libelle` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idmotif`)
) ENGINE=MyISAM AUTO_INCREMENT=5 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `motif`
--

INSERT INTO `motif` (`idmotif`, `libelle`) VALUES
(1, 'vacances'),
(2, 'maladie'),
(3, 'motif familial'),
(4, 'congé parental');

-- --------------------------------------------------------

--
-- Structure de la table `personnel`
--

DROP TABLE IF EXISTS `personnel`;
CREATE TABLE IF NOT EXISTS `personnel` (
  `idpersonnel` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `prenom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `tel` varchar(15) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `mail` varchar(128) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `idservice` int NOT NULL,
  PRIMARY KEY (`idpersonnel`),
  KEY `idservice` (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=17 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `personnel`
--

INSERT INTO `personnel` (`idpersonnel`, `nom`, `prenom`, `tel`, `mail`, `idservice`) VALUES
(1, 'Martin', 'Sophie', '0601020304', 'smartin@mediatek86.fr', 1),
(2, 'Bernard', 'Luc', '0611223344', 'lbernard@mediatek86.fr', 2),
(3, 'Thomas', 'Julie', '0622334455', 'jthomas@mediatek86.fr', 3),
(4, 'Petit', 'Marc', '0633445566', 'mpetit@mediatek86.fr', 1),
(5, 'Robert', 'Emma', '0644556677', 'erobert@mediatek86.fr', 2),
(6, 'Richard', 'Paul', '0655667788', 'prichard@mediatek86.fr', 3),
(7, 'Durand', 'Alice', '0666778899', 'adurand@mediatek86.fr', 1),
(8, 'Dubois', 'Hugo', '0677889900', 'hdubois@mediatek86.fr', 2),
(9, 'Moreau', 'Chloe', '0688990011', 'cmoreau@mediatek86.fr', 3),
(10, 'Laurent', 'Nicolas', '0699001122', 'nlaurent@mediatek86.fr', 1),
(15, 'Laurent', 'Nicolas', '0699001122', 'nlaurent@mediatek86.fr', 1),
(16, 'Laurent', 'Nicolas', '0699001122', 'nlaurent@mediatek86.fr', 1);

-- --------------------------------------------------------

--
-- Structure de la table `responsable`
--

DROP TABLE IF EXISTS `responsable`;
CREATE TABLE IF NOT EXISTS `responsable` (
  `login` varchar(64) COLLATE utf8mb4_unicode_ci NOT NULL,
  `pwd` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `responsable`
--

INSERT INTO `responsable` (`login`, `pwd`) VALUES
('admin', 'admin');

-- --------------------------------------------------------

--
-- Structure de la table `service`
--

DROP TABLE IF EXISTS `service`;
CREATE TABLE IF NOT EXISTS `service` (
  `idservice` int NOT NULL AUTO_INCREMENT,
  `nom` varchar(50) COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  PRIMARY KEY (`idservice`)
) ENGINE=MyISAM AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Déchargement des données de la table `service`
--

INSERT INTO `service` (`idservice`, `nom`) VALUES
(1, 'administratif'),
(2, 'médiation culturelle'),
(3, 'prêt');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
