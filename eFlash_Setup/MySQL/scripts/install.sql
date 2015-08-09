-- MySQL dump 10.10
--
-- Host: localhost    Database: eflash
-- ------------------------------------------------------
-- Server version	5.0.18-nt

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Use database `eFlash`
--

CREATE DATABASE IF NOT EXISTS eFlash;
USE eFlash;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
CREATE TABLE `users` (
  `uid` int(11) NOT NULL auto_increment COMMENT 'User ID',
  `name` varchar(20) NOT NULL COMMENT 'User Name',
  `pw` varchar(15) default NULL COMMENT 'User Password',
  `login_setting` enum('no_save', 'save_pw', 'auto_log') NOT NULL default 'no_save' COMMENT 'Login Settings', # auto_login implies save_pw state also checked
  `nuid` int(11) default NULL COMMENT 'Network User ID',
  PRIMARY KEY  (`uid`),
  UNIQUE KEY `name` (`name`),
  KEY `BTREE` (`nuid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `users`
--

--
-- Table structure for table `decks`
--

DROP TABLE IF EXISTS `decks`;
CREATE TABLE `decks` (
  `did` int(11) NOT NULL auto_increment COMMENT 'Deck ID',
  `type` enum('noQuiz','text','image','sound') NOT NULL COMMENT 'Deck Template',
  `cat` tinytext NOT NULL COMMENT 'Category Name',
  `subcat` tinytext COMMENT 'Sub-category Name',
  `title` tinytext NOT NULL COMMENT 'Deck Title',
  `uid` int(11) NOT NULL COMMENT 'References uid in Users Table',
  `nuid` int(11) default NULL COMMENT 'References nuid in Users Table',
  PRIMARY KEY  (`did`),
  KEY `uid` (`uid`),
  CONSTRAINT `decks_ibfk_1` FOREIGN KEY (`uid`) REFERENCES `users` (`uid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `decks`
--


--
-- Table structure for table `unranked`
--

DROP TABLE IF EXISTS `unranked`;
CREATE TABLE `unranked` (
  `ldid` int(11) NOT NULL COMMENT 'Local Deck ID',
  `rdid` int(11) NOT NULL COMMENT 'Remote Deck ID',
  `lnuid` int(11) NOT NULL COMMENT 'Local Owner Network User ID',
  `rnuid` int(11) NOT NULL COMMENT 'Remote Owner Network User ID',
  PRIMARY KEY (`ldid`),
  KEY `BTREE` (`lnuid`),
  CONSTRAINT `unranked_ibfk_1` FOREIGN KEY (`ldid`) REFERENCES `decks` (`did`) ON DELETE CASCADE,
  CONSTRAINT `unranked_ibfk_2` FOREIGN KEY (`lnuid`) REFERENCES `users` (`nuid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
--
-- Table structure for table `cards`
--

DROP TABLE IF EXISTS `cards`;
CREATE TABLE `cards` (
  `cid` int(11) NOT NULL auto_increment COMMENT ' Card ID',
  `tag` tinytext COMMENT 'Topic Tags',
  `uid` int(11) NOT NULL COMMENT 'References uid in Users Table',
  PRIMARY KEY  (`cid`),
  KEY `uid` (`uid`),
  CONSTRAINT `cards_ibfk_1` FOREIGN KEY (`uid`) REFERENCES `users` (`uid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cards`
--


--
-- Table structure for table `cdrelations`
--

DROP TABLE IF EXISTS `cdrelations`;
CREATE TABLE `cdrelations` (
  `did` int(11) NOT NULL COMMENT 'References did in Decks Table',
  `cid` int(11) NOT NULL COMMENT 'References cid in Cards Table',
  PRIMARY KEY  (`did`,`cid`),
  KEY `cid` (`cid`),
  CONSTRAINT `cdrelations_ibfk_1` FOREIGN KEY (`did`) REFERENCES `decks` (`did`) ON DELETE CASCADE,
  CONSTRAINT `cdrelations_ibfk_2` FOREIGN KEY (`cid`) REFERENCES `cards` (`cid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `cdrelations`
--



--
-- Table structure for table `objects`
--

DROP TABLE IF EXISTS `objects`;
CREATE TABLE `objects` (
  `cid` int(11) NOT NULL COMMENT ' References cid in Card Table',
  `side` int(11) NOT NULL COMMENT 'Side Number',
  `type` enum('text','image','sound') NOT NULL COMMENT 'Type of Object',
  `x1` int(11) NOT NULL COMMENT 'x-position of object start',
  `x2` int(11) NOT NULL COMMENT 'x-position of object end',
  `y1` int(11) NOT NULL COMMENT 'y-position of object start',
  `y2` int(11) NOT NULL COMMENT 'y-position of object end',
  `data` text NOT NULL COMMENT 'actual text or location if not text',
  PRIMARY KEY  (`cid`,`side`,`x1`,`x2`,`y1`,`y2`),
  KEY `BTREE` (`cid`),
  CONSTRAINT `objects_ibfk_1` FOREIGN KEY (`cid`) REFERENCES `cards` (`cid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `objects`
--


--
-- Table structure for table `statistics`
--

DROP TABLE IF EXISTS `statistics`;
CREATE TABLE `statistics` (
  `qid` int(11) NOT NULL auto_increment COMMENT 'Quid ID',
  `uid` int(11) NOT NULL COMMENT 'References uid in Users Table',
  `type` enum('matching','fill-in','multiple-choice') NOT NULL COMMENT 'Quiz Type',
  `score` int(11) COMMENT 'A Perentage score for the Quiz',
  PRIMARY KEY  (`qid`),
  KEY `uid` (`uid`),
  CONSTRAINT `statistics_ibfk_1` FOREIGN KEY (`uid`) REFERENCES `users` (`uid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `quizzes`
--

--
-- Table structure for table `qdrelations`
--

DROP TABLE IF EXISTS `qdrelations`;
CREATE TABLE `qdrelations` (
  `qid` int(11) NOT NULL COMMENT 'References qid in Statistics Table',
  `did` int(11) NOT NULL COMMENT 'References cid in Decks Table',
  PRIMARY KEY  (`qid`,`did`),
  CONSTRAINT `qdrelations_ibfk_1` FOREIGN KEY (`qid`) REFERENCES `statistics` (`qid`) ON DELETE CASCADE,
  CONSTRAINT `qdrelations_ibfk_2` FOREIGN KEY (`did`) REFERENCES `decks` (`did`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `qdrelations`
--


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

