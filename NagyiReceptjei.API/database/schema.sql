SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

DROP DATABASE IF EXISTS `nagyi_receptjei`;
CREATE DATABASE IF NOT EXISTS `nagyi_receptjei` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;
USE `nagyi_receptjei`;

DROP TABLE IF EXISTS `comments`;
CREATE TABLE IF NOT EXISTS `comments` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `recipe_id` int(11) NOT NULL,
  `user_id` int(11) NOT NULL,
  `content` varchar(250) COLLATE utf8_hungarian_ci NOT NULL,
  `created_date_time` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`id`),
  KEY `recipe_id__recipes_id` (`recipe_id`),
  KEY `user_id__users_id` (`user_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

DROP TABLE IF EXISTS `ingredients`;
CREATE TABLE IF NOT EXISTS `ingredients` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  `amount` int(11) NOT NULL,
  `unit` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
  `recipe_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `recipe_id___recipes_id` (`recipe_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

DROP TABLE IF EXISTS `photos`;
CREATE TABLE IF NOT EXISTS `photos` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `file_name` varchar(41) COLLATE utf8_hungarian_ci NOT NULL,
  `recipe_id` int(11) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `recipe___id_recipes___id` (`recipe_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

DROP TABLE IF EXISTS `recipes`;
CREATE TABLE IF NOT EXISTS `recipes` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
  `content` varchar(2000) COLLATE utf8_hungarian_ci NOT NULL,
  `prep_time` int(11) NOT NULL,
  `portion` int(11) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `email` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
  `username` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  `password` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `email` (`email`),
  UNIQUE KEY `username` (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

ALTER TABLE `comments`
  ADD CONSTRAINT `comments_recipe_id_recipes_id` FOREIGN KEY (`recipe_id`) REFERENCES `recipes` (`id`),
  ADD CONSTRAINT `comments_user_id_users_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE `ingredients`
  ADD CONSTRAINT `ingredients_recipe_id_recipes_id` FOREIGN KEY (`recipe_id`) REFERENCES `recipes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;

ALTER TABLE `photos`
  ADD CONSTRAINT `photos_recipe_id_recipes_id` FOREIGN KEY (`recipe_id`) REFERENCES `recipes` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;
