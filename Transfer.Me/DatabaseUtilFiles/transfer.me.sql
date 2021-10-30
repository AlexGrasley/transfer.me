/*
SQLyog Community v13.1.5  (64 bit)
MySQL - 10.5.12-MariaDB : Database - transfer.me
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`transfer.me` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `transfer.me`;

/*Table structure for table `device` */

DROP TABLE IF EXISTS `device`;

CREATE TABLE `device` (
  `DeviceID` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserID` bigint(20) NOT NULL,
  `PublicKey` bigint(20) NOT NULL,
  PRIMARY KEY (`DeviceID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `device_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `tmuser` (`UserID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `device` */

/*Table structure for table `encryptedfile` */

DROP TABLE IF EXISTS `encryptedfile`;

CREATE TABLE `encryptedfile` (
  `FileID` bigint(20) NOT NULL AUTO_INCREMENT,
  `FileSize` bigint(20) NOT NULL,
  `Descript` varchar(255) NOT NULL,
  `FileData` blob NOT NULL,
  `UserID` bigint(20) NOT NULL,
  PRIMARY KEY (`FileID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `encryptedfile_ibfk_1` FOREIGN KEY (`UserID`) REFERENCES `tmuser` (`UserID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `encryptedfile` */

/*Table structure for table `filelog` */

DROP TABLE IF EXISTS `filelog`;

CREATE TABLE `filelog` (
  `FileLogID` bigint(20) NOT NULL AUTO_INCREMENT,
  `Uploaded` datetime NOT NULL,
  `Downloaded` datetime NOT NULL,
  `FileSize` bigint(20) NOT NULL,
  `Descript` varchar(255) NOT NULL,
  `FileID` bigint(20) NOT NULL,
  `UserID` bigint(20) NOT NULL,
  PRIMARY KEY (`FileLogID`),
  KEY `FileID` (`FileID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `filelog_ibfk_1` FOREIGN KEY (`FileID`) REFERENCES `encryptedfile` (`FileID`) ON DELETE CASCADE,
  CONSTRAINT `filelog_ibfk_2` FOREIGN KEY (`UserID`) REFERENCES `tmuser` (`UserID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `filelog` */

/*Table structure for table `recipient` */

DROP TABLE IF EXISTS `recipient`;

CREATE TABLE `recipient` (
  `RecipientID` bigint(20) NOT NULL AUTO_INCREMENT,
  `FileID` bigint(20) NOT NULL,
  `UserID` bigint(20) NOT NULL,
  PRIMARY KEY (`RecipientID`),
  KEY `FileID` (`FileID`),
  KEY `UserID` (`UserID`),
  CONSTRAINT `recipient_ibfk_1` FOREIGN KEY (`FileID`) REFERENCES `encryptedfile` (`FileID`) ON DELETE CASCADE,
  CONSTRAINT `recipient_ibfk_2` FOREIGN KEY (`UserID`) REFERENCES `tmuser` (`UserID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `recipient` */

/*Table structure for table `recipientfilekey` */

DROP TABLE IF EXISTS `recipientfilekey`;

CREATE TABLE `recipientfilekey` (
  `DeviceKeyID` bigint(20) NOT NULL AUTO_INCREMENT,
  `EncryptedKey` bigint(20) NOT NULL,
  `RecipientID` bigint(20) NOT NULL,
  `DeviceID` bigint(20) NOT NULL,
  `FileID` bigint(20) NOT NULL,
  PRIMARY KEY (`DeviceKeyID`),
  KEY `RecipientID` (`RecipientID`),
  KEY `DeviceID` (`DeviceID`),
  KEY `FileID` (`FileID`),
  CONSTRAINT `recipientfilekey_ibfk_1` FOREIGN KEY (`RecipientID`) REFERENCES `recipient` (`RecipientID`) ON DELETE CASCADE,
  CONSTRAINT `recipientfilekey_ibfk_2` FOREIGN KEY (`DeviceID`) REFERENCES `device` (`DeviceID`) ON DELETE CASCADE,
  CONSTRAINT `recipientfilekey_ibfk_3` FOREIGN KEY (`FileID`) REFERENCES `encryptedfile` (`FileID`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `recipientfilekey` */

/*Table structure for table `tmuser` */

DROP TABLE IF EXISTS `tmuser`;

CREATE TABLE `tmuser` (
  `UserID` bigint(20) NOT NULL AUTO_INCREMENT,
  `UserName` varchar(255) NOT NULL,
  `Email` varchar(255) NOT NULL,
  `LastLogin` datetime NOT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `tmuser` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
