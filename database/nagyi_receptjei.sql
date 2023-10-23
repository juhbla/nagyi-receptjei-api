SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";

CREATE DATABASE IF NOT EXISTS `nagyi_receptjei` DEFAULT CHARACTER SET utf8 COLLATE utf8_hungarian_ci;

USE `nagyi_receptjei`;

DROP TABLE IF EXISTS `comments`;
CREATE TABLE IF NOT EXISTS `comments` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `recipe_id` int(11) NOT NULL,
    `user_id` int(11) NOT NULL,
    `content` varchar(250) COLLATE utf8_hungarian_ci NOT NULL,
    PRIMARY KEY (`id`),
    KEY `recipe_id__recipes_id` (`recipe_id`),
    KEY `user_id__users_id` (`user_id`)
    ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

INSERT INTO `comments` (`id`, `recipe_id`, `user_id`, `content`) VALUES
    (1, 1, 1, 'Nagyon finom!!!');


DROP TABLE IF EXISTS `recipes`;
CREATE TABLE IF NOT EXISTS `recipes` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `title` varchar(100) COLLATE utf8_hungarian_ci NOT NULL,
    `category` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
    `ingredients` varchar(500) COLLATE utf8_hungarian_ci NOT NULL,
    `content` varchar(2000) COLLATE utf8_hungarian_ci NOT NULL,
    `prep_time` int(11) NOT NULL,
    `portion` int(11) NOT NULL,
    `image` varchar(25) COLLATE utf8_hungarian_ci NOT NULL,
    PRIMARY KEY (`id`)
    ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

INSERT INTO `recipes` (`id`, `title`, `category`, `ingredients`, `content`, `prep_time`, `portion`, `image`) VALUES
    (1, 'Mákos guba', 'Desszert', 'Mák, tojás, tej, vaj', 'Gyúrd össze a tésztát', 30, 2, '');

DROP TABLE IF EXISTS `users`;
CREATE TABLE IF NOT EXISTS `users` (
    `id` int(11) NOT NULL AUTO_INCREMENT,
    `email` varchar(50) COLLATE utf8_hungarian_ci NOT NULL,
    `username` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
    `password` varchar(10) COLLATE utf8_hungarian_ci NOT NULL,
    PRIMARY KEY (`id`),
    UNIQUE KEY `email` (`email`)
    ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_hungarian_ci;

INSERT INTO `users` (`id`, `email`, `username`, `password`) VALUES
    (1, 'juhasz.adel2@gmail.com', 'juhaszadel', '12345');

ALTER TABLE `comments`
    ADD CONSTRAINT `recipe_id__recipes_id` FOREIGN KEY (`recipe_id`) REFERENCES `recipes` (`id`),
  ADD CONSTRAINT `user_id__users_id` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;
