-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.0.89-community-nt


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema epme
--

CREATE DATABASE IF NOT EXISTS epme;
USE epme;

--
-- Definition of table `article`
--

DROP TABLE IF EXISTS `article`;
CREATE TABLE `article` (
  `ID` int(15) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `code` varchar(15) NOT NULL,
  `codeb` varchar(15) default NULL,
  `libelle` varchar(50) default NULL,
  `codeo` varchar(15) default NULL,
  `marque` varchar(20) default NULL,
  `codef` varchar(3) default NULL,
  `ls` varchar(10) default NULL,
  `um` varchar(3) default NULL,
  `tva` double(7,2) default NULL,
  `fodec` double(7,2) default '0.00',
  `taxe` double(7,2) default '0.00',
  `paht` decimal(19,3) default NULL,
  `marge` double(7,2) default NULL,
  `puht` decimal(19,3) default NULL,
  `pvpht` decimal(19,3) default NULL,
  `pattc` decimal(19,3) default NULL,
  `puttc` decimal(19,3) default NULL,
  `pvpttc` decimal(19,3) default NULL,
  `qteseuil` double(15,3) default NULL,
  `qtedep` double(15,3) default NULL,
  `qteent` double(15,3) default NULL,
  `qteavrc` double(15,3) default NULL,
  `qtesor` double(15,3) default NULL,
  `qteavrf` double(15,3) default NULL,
  `qtestk` double(15,3) default NULL,
  `dext` double(7,2) default NULL,
  `dint` double(7,2) default NULL,
  `haut` double(7,2) default NULL,
  `vpa` tinyint(1) NOT NULL,
  `benef` tinyint(1) NOT NULL,
  `vstk` tinyint(1) NOT NULL,
  `majore` tinyint(1) NOT NULL,
  `vente` tinyint(1) NOT NULL,
  `achat` tinyint(1) NOT NULL,
  `cara` varchar(512) default NULL,
  `image` longblob,
  `tvavente` tinyint(1) NOT NULL,
  `tvaachat` tinyint(1) NOT NULL,
  `emb` double(4,0) default NULL,
  PRIMARY KEY  (`codes`,`codee`,`code`),
  KEY `codef` (`codef`),
  KEY `codeo` (`codeo`),
  KEY `Index_4` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `article`
--

/*!40000 ALTER TABLE `article` DISABLE KEYS */;
/*!40000 ALTER TABLE `article` ENABLE KEYS */;


--
-- Definition of table `client`
--

DROP TABLE IF EXISTS `client`;
CREATE TABLE `client` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `code` varchar(10) NOT NULL,
  `libelle` varchar(50) default NULL,
  `adrl` varchar(50) default NULL,
  `adrf` varchar(50) default NULL,
  `adrm` varchar(50) default NULL,
  `mf` varchar(20) default NULL,
  `telfixe` varchar(20) default NULL,
  `telfixe1` varchar(20) default NULL,
  `telgsm` varchar(20) default NULL,
  `telgsm1` varchar(20) default NULL,
  `fax` varchar(20) default NULL,
  `fax1` varchar(20) default NULL,
  `regime` tinyint(1) NOT NULL,
  `timbre` tinyint(1) NOT NULL,
  `exenoration` tinyint(1) NOT NULL,
  `solde1` decimal(19,3) default NULL,
  `debit` decimal(19,3) default NULL,
  `credit` decimal(19,3) default NULL,
  `avoir` decimal(19,3) default NULL,
  `retenue` decimal(19,3) default NULL,
  `rem` decimal(19,3) default NULL,
  `plafond` decimal(19,3) default NULL,
  `solde` decimal(19,3) default NULL,
  `remise` double(7,2) default NULL,
  `cumulrem` tinyint(1) NOT NULL,
  `acompte` decimal(19,3) default '0.000',
  `regsoldn1` decimal(19,3) default '0.000',
  PRIMARY KEY  (`codes`,`codee`,`code`),
  KEY `Index_2` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `client`
--

/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` (`ID`,`codes`,`codee`,`code`,`libelle`,`adrl`,`adrf`,`adrm`,`mf`,`telfixe`,`telfixe1`,`telgsm`,`telgsm1`,`fax`,`fax1`,`regime`,`timbre`,`exenoration`,`solde1`,`debit`,`credit`,`avoir`,`retenue`,`rem`,`plafond`,`solde`,`remise`,`cumulrem`,`acompte`,`regsoldn1`) VALUES 
 (1,'999','2012','4100008','STEG','','','','','','','','','','',1,0,1,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,0,'0.000','0.000');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;


--
-- Definition of table `contrat`
--

DROP TABLE IF EXISTS `contrat`;
CREATE TABLE `contrat` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `CODEC` varchar(45) default NULL,
  `NOMC` varchar(250) default NULL,
  `ADRC` varchar(500) default NULL,
  `THT` decimal(23,8) default '0.00000000',
  `REM` decimal(23,8) default '0.00000000',
  `TVA` decimal(23,8) default '0.00000000',
  `TTC` decimal(23,8) default '0.00000000',
  `AVANCE` decimal(23,8) default '0.00000000',
  `DATEDEBUT` date default NULL,
  `DATEFIN` date default NULL,
  `CODES` varchar(5) default NULL,
  `SOLDE` decimal(23,8) default '0.00000000',
  `reste` decimal(23,8) default '0.00000000',
  `CODE` varchar(45) default NULL,
  `VGAR` decimal(5,2) default NULL,
  `VAVANC` decimal(5,2) default NULL,
  `Fermer` tinyint(1) default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `contrat`
--

/*!40000 ALTER TABLE `contrat` DISABLE KEYS */;
INSERT INTO `contrat` (`ID`,`CODEC`,`NOMC`,`ADRC`,`THT`,`REM`,`TVA`,`TTC`,`AVANCE`,`DATEDEBUT`,`DATEFIN`,`CODES`,`SOLDE`,`reste`,`CODE`,`VGAR`,`VAVANC`,`Fermer`) VALUES 
 (1,'4100008','STEG','','162592.00000000','0.00000000','298698.00000000','191859.00000000','19186.00000000','2011-07-04',NULL,'999','0.00000000','0.00000000','C20 D5040','20.00','20.00',0),
 (2,'4100008','STEG','','0.00000000','0.00000000','0.00000000','0.00000000','0.00000000','2012-09-05',NULL,'999','0.00000000','0.00000000','C20 D5040','10.00','10.00',0);
/*!40000 ALTER TABLE `contrat` ENABLE KEYS */;


--
-- Definition of table `eregc`
--

DROP TABLE IF EXISTS `eregc`;
CREATE TABLE `eregc` (
  `ID` int(10) NOT NULL auto_increment,
  `codeu` varchar(2) NOT NULL,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `codem` varchar(3) NOT NULL,
  `NUM` varchar(10) NOT NULL,
  `DATE` datetime default NULL,
  `CODEC` varchar(10) default NULL,
  `MONT` decimal(19,3) default NULL,
  `mntret` decimal(19,3) default NULL,
  `mntrem` decimal(19,3) default NULL,
  `mntsld1` decimal(19,3) default '0.000',
  `mp` varchar(1) default NULL,
  `ncheq` varchar(10) default NULL,
  `datee` datetime default NULL,
  `libelle` varchar(100) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `eregc`
--

/*!40000 ALTER TABLE `eregc` DISABLE KEYS */;
/*!40000 ALTER TABLE `eregc` ENABLE KEYS */;


--
-- Definition of table `exercice`
--

DROP TABLE IF EXISTS `exercice`;
CREATE TABLE `exercice` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `libelle` varchar(50) default NULL,
  PRIMARY KEY  (`codes`,`codee`),
  KEY `codee` (`codee`),
  KEY `codes` (`codes`),
  KEY `Index_4` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `exercice`
--

/*!40000 ALTER TABLE `exercice` DISABLE KEYS */;
INSERT INTO `exercice` (`ID`,`codes`,`codee`,`libelle`) VALUES 
 (2,'999','2012','Exercice 2012');
/*!40000 ALTER TABLE `exercice` ENABLE KEYS */;


--
-- Definition of table `facture`
--

DROP TABLE IF EXISTS `facture`;
CREATE TABLE `facture` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `NUMF` varchar(45) NOT NULL default '',
  `CODEC` varchar(45) default NULL,
  `NOMC` varchar(250) default NULL,
  `ADRC` varchar(250) default NULL,
  `NREF` varchar(250) default NULL,
  `VREF` varchar(500) default NULL,
  `DATEF` date default NULL,
  `MODEP` varchar(50) default NULL,
  `THT` decimal(23,8) default NULL,
  `RAVANCE` decimal(23,8) default NULL,
  `RGARANTIE` decimal(23,8) default NULL,
  `NETHT` decimal(23,8) default NULL,
  `TVA` decimal(23,8) default NULL,
  `TIMBRE` decimal(23,8) default NULL,
  `TTC` decimal(23,8) default NULL,
  `TYPE` varchar(45) default NULL,
  `OBSERVATION` varchar(500) default NULL,
  `CODES` varchar(5) NOT NULL default '',
  `CODEE` varchar(4) NOT NULL default '',
  `REF` varchar(250) default NULL,
  `VAVANCE` decimal(23,8) default NULL,
  `VGARANTIE` decimal(23,8) default NULL,
  `Prorata` decimal(10,3) default NULL,
  `Contrat` int(10) unsigned default '0',
  `rs50` decimal(23,8) default NULL,
  `rs15` decimal(23,8) default NULL,
  `net` decimal(23,8) default NULL,
  PRIMARY KEY  (`ID`,`NUMF`,`CODES`,`CODEE`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `facture`
--

/*!40000 ALTER TABLE `facture` DISABLE KEYS */;
INSERT INTO `facture` (`ID`,`NUMF`,`CODEC`,`NOMC`,`ADRC`,`NREF`,`VREF`,`DATEF`,`MODEP`,`THT`,`RAVANCE`,`RGARANTIE`,`NETHT`,`TVA`,`TIMBRE`,`TTC`,`TYPE`,`OBSERVATION`,`CODES`,`CODEE`,`REF`,`VAVANCE`,`VGARANTIE`,`Prorata`,`Contrat`,`rs50`,`rs15`,`net`) VALUES 
 (1,'FC000037','4100008','STEG','','','','2013-10-11','CHQ30','600.00000000','60.00000000','60.00000000','480.00000000','86.40000000','0.40000000','566.40000000','F',NULL,'999','2012','','10.00000000','10.00000000','100.000',0,'43.20000000','8.49600000','515.10400000'),
 (2,'FC000038','4100008','STEG','','','','2013-10-11','CHQ30','1040.00000000','104.00000000','104.00000000','832.00000000','187.20000000','0.40000000','1019.20000000','T',NULL,'999','2012','','10.00000000','10.00000000','100.000',0,'93.60000000','15.28800000','910.71200000');
/*!40000 ALTER TABLE `facture` ENABLE KEYS */;


--
-- Definition of table `famillearticle`
--

DROP TABLE IF EXISTS `famillearticle`;
CREATE TABLE `famillearticle` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `Code` varchar(3) NOT NULL,
  `libelle` varchar(50) default NULL,
  `type` varchar(1) default '',
  PRIMARY KEY  (`codes`,`codee`,`Code`),
  KEY `Index_2` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=29 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `famillearticle`
--

/*!40000 ALTER TABLE `famillearticle` DISABLE KEYS */;
INSERT INTO `famillearticle` (`ID`,`codes`,`codee`,`Code`,`libelle`,`type`) VALUES 
 (23,'999','2012','001','Informatique',''),
 (24,'999','2012','002','Bureautique',''),
 (25,'999','2012','003','Article Jeux',''),
 (26,'999','2012','004','Article Cadeaux',''),
 (27,'999','2012','005','Batiment',''),
 (28,'999','2012','006','Alimentaire','');
/*!40000 ALTER TABLE `famillearticle` ENABLE KEYS */;


--
-- Definition of table `familleclient`
--

DROP TABLE IF EXISTS `familleclient`;
CREATE TABLE `familleclient` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `Code` varchar(3) NOT NULL,
  `libelle` varchar(50) default NULL,
  `type` varchar(1) default '',
  PRIMARY KEY  (`codes`,`codee`,`Code`),
  KEY `Index_2` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `familleclient`
--

/*!40000 ALTER TABLE `familleclient` DISABLE KEYS */;
INSERT INTO `familleclient` (`ID`,`codes`,`codee`,`Code`,`libelle`,`type`) VALUES 
 (2,'999','2012','001','Revendeur',''),
 (3,'999','2012','002','Privé','');
/*!40000 ALTER TABLE `familleclient` ENABLE KEYS */;


--
-- Definition of table `famillefour`
--

DROP TABLE IF EXISTS `famillefour`;
CREATE TABLE `famillefour` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `Code` varchar(3) NOT NULL,
  `libelle` varchar(50) default NULL,
  `type` varchar(1) default '',
  PRIMARY KEY  (`codes`,`codee`,`Code`),
  KEY `Index_2` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `famillefour`
--

/*!40000 ALTER TABLE `famillefour` DISABLE KEYS */;
INSERT INTO `famillefour` (`ID`,`codes`,`codee`,`Code`,`libelle`,`type`) VALUES 
 (1,'999','2012','001','Local',''),
 (2,'999','2012','002','Etranger','');
/*!40000 ALTER TABLE `famillefour` ENABLE KEYS */;


--
-- Definition of table `four`
--

DROP TABLE IF EXISTS `four`;
CREATE TABLE `four` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `code` varchar(10) NOT NULL,
  `codef` varchar(3) default NULL,
  `libelle` varchar(50) default NULL,
  `adrl` varchar(50) default NULL,
  `adrf` varchar(50) default NULL,
  `adrm` varchar(50) default NULL,
  `mf` varchar(20) default NULL,
  `telfixe` varchar(20) default NULL,
  `telfixe1` varchar(20) default NULL,
  `telgsm` varchar(20) default NULL,
  `telgsm1` varchar(20) default NULL,
  `fax` varchar(20) default NULL,
  `fax1` varchar(20) default NULL,
  `timbre` tinyint(1) NOT NULL,
  `fodecfact` tinyint(1) NOT NULL,
  `solde1` decimal(19,3) default NULL,
  `debit` decimal(19,3) default NULL,
  `credit` decimal(19,3) default NULL,
  `avoir` decimal(19,3) default NULL,
  `retenue` decimal(19,3) default NULL,
  `rem` decimal(19,3) default NULL,
  `solde` decimal(19,3) default NULL,
  `obs` varchar(512) default NULL,
  `image` longblob,
  `acompte` decimal(19,3) default '0.000',
  `regsoldn1` decimal(19,3) default '0.000',
  PRIMARY KEY  (`codes`,`codee`,`code`),
  KEY `codef` (`codef`),
  KEY `Index_3` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `four`
--

/*!40000 ALTER TABLE `four` DISABLE KEYS */;
/*!40000 ALTER TABLE `four` ENABLE KEYS */;


--
-- Definition of table `lcontrat`
--

DROP TABLE IF EXISTS `lcontrat`;
CREATE TABLE `lcontrat` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `CODES` varchar(5) default NULL,
  `NPYLON` varchar(45) default NULL,
  `TYPEPYLON` varchar(45) default NULL,
  `POIDS` decimal(23,8) default NULL,
  `PUPoids` decimal(23,8) default NULL,
  `VBETON` decimal(23,8) default NULL,
  `PUBETON` decimal(23,8) default NULL,
  `TYPEMASSIF` varchar(45) default NULL,
  `DESIGNATION` varchar(250) default NULL,
  `U` varchar(5) default NULL,
  `TYPE` varchar(45) default NULL,
  `IDCONTRAT` int(10) unsigned default NULL,
  `QTE` decimal(23,0) default NULL,
  `PRORATAM` decimal(10,2) default '0.00',
  `PRORATAF` decimal(10,2) default NULL,
  `PRORATAD` decimal(10,2) default NULL,
  `DISTANCE` decimal(23,8) default NULL,
  `PUDISTANCE` decimal(23,8) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=24 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lcontrat`
--

/*!40000 ALTER TABLE `lcontrat` DISABLE KEYS */;
INSERT INTO `lcontrat` (`ID`,`CODES`,`NPYLON`,`TYPEPYLON`,`POIDS`,`PUPoids`,`VBETON`,`PUBETON`,`TYPEMASSIF`,`DESIGNATION`,`U`,`TYPE`,`IDCONTRAT`,`QTE`,`PRORATAM`,`PRORATAF`,`PRORATAD`,`DISTANCE`,`PUDISTANCE`) VALUES 
 (1,'999','0/0','SD-6','6.35400000','800.00000000','20.11000000','700.00000000','I',NULL,'U',NULL,1,NULL,'60.00','20.00','0.00','0.40000000','14000.00000000'),
 (2,'999','0/1','SA+3','6.35400000','800.00000000','7.72000000','700.00000000','I',NULL,'U',NULL,1,NULL,'100.00','0.00','0.00','0.40000000','14000.00000000'),
 (3,'999','0/2','SA+0','6.35400000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'20.00','20.00','0.00','0.40000000','14000.00000000'),
 (4,'999','2/5','SA-1,5','6.35400000','800.00000000','6.93000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','60.00','0.00','0.40000000','15000.00000000'),
 (5,'999','3/4','SA-1,5','6.35400000','800.00000000','6.93000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','100.00','0.00','0.40000000','15500.00000000'),
 (6,'999','3/5','SA+7,5','6.35400000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'0.00','100.00','0.00','0.40000000','15500.00000000'),
 (7,'999','5/2','SA+7,5','6.35400000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'20.00','0.00','0.00','0.40000000','16000.00000000'),
 (8,'999','3/9','SA+4,5','6.35400000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'20.00','0.00','0.00','0.40000000','15500.00000000'),
 (9,'999','9/0','SB+0','6.35400000','800.00000000','22.88000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (10,'999','3/1','SA+6','6.35400000','800.00000000','8.80000000','700.00000000','i',NULL,'U',NULL,1,NULL,'0.00','0.00','0.00','0.40000000','16000.00000000'),
 (11,'999','9/1','SA+6','6.35400000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (12,'999','9/2','SA+4.5','6.08700000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (13,'999','9/3','SA+7.5','6.75700000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (14,'999','9/4','SA+1.5','5.29100000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (15,'999','9/5','SA+6','6.35400000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (16,'999','9/0','DD+E0+0','15.10800000','800.00000000','8.83000000','700.00000000','I',NULL,'U',NULL,1,NULL,'40.00','80.00','0.00','0.40000000','18020.00000000'),
 (17,'999','2/0','DB+E0+0','14.96500000','800.00000000','8.38000000','700.00000000','I',NULL,'U',NULL,1,NULL,'0.00','0.00','0.00','0.40000000','15000.00000000'),
 (21,'999','9/0','SB+0','15.10800000','800.00000000','6.93000000','800.00000000','I',NULL,NULL,NULL,2,NULL,'170.00','170.00','0.00','0.40000000','14500.00000000'),
 (22,'999','2/0','DB+E0+0','14.96500000','800.00000000','6.93000000','800.00000000','I',NULL,NULL,NULL,2,NULL,'170.00','170.00','0.00','0.40000000','16200.00000000'),
 (23,'999','0/1','222','50.00000000','700.00000000','5.05000000','800.00000000','l',NULL,NULL,NULL,2,NULL,NULL,NULL,NULL,'0.40000000','11200.00000000');
/*!40000 ALTER TABLE `lcontrat` ENABLE KEYS */;


--
-- Definition of table `lderoulage`
--

DROP TABLE IF EXISTS `lderoulage`;
CREATE TABLE `lderoulage` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `NUMF` varchar(45) default NULL,
  `DESIGNATION` varchar(500) default NULL,
  `SECTION` varchar(45) default NULL,
  `U` varchar(45) default NULL,
  `QTE` decimal(23,8) default NULL,
  `PUHT` varchar(45) default NULL,
  `REM` decimal(23,8) default NULL,
  `TVA` decimal(23,8) default NULL,
  `PTHT` decimal(23,8) default NULL,
  `TTC` decimal(23,8) default NULL,
  `CODES` varchar(4) default NULL,
  `CODEE` varchar(4) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lderoulage`
--

/*!40000 ALTER TABLE `lderoulage` DISABLE KEYS */;
INSERT INTO `lderoulage` (`ID`,`NUMF`,`DESIGNATION`,`SECTION`,`U`,`QTE`,`PUHT`,`REM`,`TVA`,`PTHT`,`TTC`,`CODES`,`CODEE`) VALUES 
 (7,'FC000022','Transport','4/0-5/0','KM','2.12274000','1400.000',NULL,'18.00000000','2971.83600000',NULL,'999','2012'),
 (8,'FC000022','Pose des cables conducteur (6)','4/0-5/0','KM','2.12274000','11700.000',NULL,'18.00000000','24836.05800000',NULL,'999','2012'),
 (9,'FC000022','Câble de garde','4/0-5/0','KM','2.12274000','2250.000',NULL,'18.00000000','4776.16500000',NULL,'999','2012');
/*!40000 ALTER TABLE `lderoulage` ENABLE KEYS */;


--
-- Definition of table `lfondation`
--

DROP TABLE IF EXISTS `lfondation`;
CREATE TABLE `lfondation` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `NUMF` varchar(45) default NULL,
  `NPYLONE` varchar(50) default NULL,
  `TYPEPYLONE` varchar(45) default NULL,
  `VBETPROPRETE` decimal(23,8) default NULL,
  `U` varchar(45) default NULL,
  `QTE` decimal(23,8) default NULL,
  `PUHT` decimal(23,8) default NULL,
  `TVA` decimal(23,8) default NULL,
  `PTHT` decimal(23,8) default NULL,
  `CODES` varchar(5) default NULL,
  `Tmassif` varchar(45) NOT NULL,
  `VB350` decimal(23,8) NOT NULL,
  `VTOTAL` decimal(23,8) NOT NULL,
  `CODEE` varchar(4) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=79 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lfondation`
--

/*!40000 ALTER TABLE `lfondation` DISABLE KEYS */;
INSERT INTO `lfondation` (`ID`,`NUMF`,`NPYLONE`,`TYPEPYLONE`,`VBETPROPRETE`,`U`,`QTE`,`PUHT`,`TVA`,`PTHT`,`CODES`,`Tmassif`,`VB350`,`VTOTAL`,`CODEE`) VALUES 
 (40,'FC000018','2/5','SA-1.5','6.93000000','U',NULL,'800.00000000','18.00000000','5544.00000000','999','I','0.00000000','0.00000000','2012'),
 (41,'FC000018','3/4','SA-1.5','6.93000000','U',NULL,'800.00000000','18.00000000','5544.00000000','999','I','0.00000000','0.00000000','2012'),
 (42,'FC000018','3/5','SA+4.5','8.83000000','U',NULL,'800.00000000','18.00000000','7064.00000000','999','I','0.00000000','0.00000000','2012'),
 (43,'FC000018','5/2','SA+7.5','8.83000000','U',NULL,'800.00000000','18.00000000','7064.00000000','999','I','0.00000000','0.00000000','2012'),
 (44,'FC000018','3/9','SA+4.5','8.83000000','U',NULL,'800.00000000','18.00000000','7064.00000000','999','I','0.00000000','0.00000000','2012'),
 (45,'FC000018','9/0','SB+0','22.88000000','U',NULL,'800.00000000','18.00000000','18304.00000000','999','I','0.00000000','0.00000000','2012'),
 (47,'FC000020','2/5','SA-1.5','1.52000000','U',NULL,'800.00000000','18.00000000','5544.00000000','999','I','5.41000000','6.93000000','2012'),
 (48,'FC000020','3/4','SA-1.5','1.52000000','U',NULL,'800.00000000','18.00000000','5544.00000000','999','I','5.41000000','6.93000000','2012'),
 (49,'FC000020','3/5','SA+4.5','2.04000000','U',NULL,'800.00000000','18.00000000','7064.00000000','999','I','6.79000000','8.83000000','2012'),
 (50,'FC000020','5/2','SA+7.5','2.04000000','U',NULL,'800.00000000','18.00000000','7064.00000000','999','I','6.79000000','8.83000000','2012'),
 (51,'FC000020','3/9','SA+4.5','2.04000000','U',NULL,'800.00000000','18.00000000','7064.00000000','999','I','6.79000000','8.83000000','2012'),
 (52,'FC000020','9/0','SB+0','3.92000000','U',NULL,'800.00000000','18.00000000','18304.00000000','999','I','18.96000000','22.88000000','2012'),
 (60,'FC000027','9/0','SB+0','22.88000000','m3',NULL,'700.00000000','18.00000000','16016.00000000','999','I','0.00000000','22.88000000','2012'),
 (61,'FC000027','9/1','SA+6','8.83000000','m3',NULL,'700.00000000','18.00000000','6181.00000000','999','I','0.00000000','8.83000000','2012'),
 (62,'FC000027','9/2','SA+4.5','8.83000000','m3',NULL,'700.00000000','18.00000000','6181.00000000','999','I','0.00000000','8.83000000','2012'),
 (63,'FC000027','9/3','SA+7.5','8.83000000','m3',NULL,'700.00000000','18.00000000','6181.00000000','999','I','0.00000000','8.83000000','2012'),
 (64,'FC000027','9/4','SA+1.5','8.83000000','m3',NULL,'700.00000000','18.00000000','6181.00000000','999','I','0.00000000','8.83000000','2012'),
 (65,'FC000027','9/5','SA+6','8.83000000','m3',NULL,'700.00000000','18.00000000','6181.00000000','999','I','0.00000000','8.83000000','2012'),
 (66,'FC000027','9/0','DD+E0+0','8.83000000','m3',NULL,'700.00000000','18.00000000','6181.00000000','999','I','0.00000000','8.83000000','2012'),
 (67,'FC000029','0/1','111','111.00000000','m3',NULL,'22.00000000','18.00000000','2442.00000000','999','1','0.00000000','111.00000000','2012'),
 (70,'FC000030','0/1','11111','50.00000000','1',NULL,'20.00000000','18.00000000','1600.00000000','999','i','30.00000000','80.00000000','2012'),
 (71,'FC000030','0/2','22222','40.00000000','1',NULL,'10.00000000','18.00000000','600.00000000','999','i','20.00000000','60.00000000','2012'),
 (72,'FC000033','9/0','SB+0','6.93000000','m3',NULL,'800.00000000','18.00000000','5544.00000000','999','I','0.00000000','6.93000000','2012'),
 (73,'FC000033','2/0','DB+E0+0','6.93000000','m3',NULL,'800.00000000','18.00000000','5544.00000000','999','I','0.00000000','6.93000000','2012'),
 (74,'FC000033','0/1','222','5.05000000','m3',NULL,'800.00000000','18.00000000','4040.00000000','999','l','0.00000000','5.05000000','2012'),
 (75,'FC000036','9/0','SB+0','6.93000000','m3',NULL,'800.00000000','18.00000000','5544.00000000','999','I','0.00000000','6.93000000','2012'),
 (76,'FC000036','2/0','DB+E0+0','6.93000000','m3',NULL,'800.00000000','18.00000000','5544.00000000','999','I','0.00000000','6.93000000','2012'),
 (77,'FC000036','0/1','222','5.05000000','m3',NULL,'800.00000000','18.00000000','4040.00000000','999','l','0.00000000','5.05000000','2012'),
 (78,'FC000037','0/1','11111','100.00000000','5',NULL,'6.00000000','18.00000000','600.00000000','999','1','0.00000000','100.00000000','2012');
/*!40000 ALTER TABLE `lfondation` ENABLE KEYS */;


--
-- Definition of table `lmontage`
--

DROP TABLE IF EXISTS `lmontage`;
CREATE TABLE `lmontage` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `NUMF` varchar(45) default NULL,
  `CODES` varchar(5) default NULL,
  `CODEE` varchar(4) default NULL,
  `NPYLONE` varchar(45) default NULL,
  `TYPEPYLONE` varchar(45) default NULL,
  `POIDS` decimal(23,8) default NULL,
  `U` varchar(5) default NULL,
  `PUHT` decimal(23,8) default NULL,
  `REM` decimal(23,8) default NULL,
  `TVA` decimal(23,8) default NULL,
  `PTHT` decimal(23,8) default NULL,
  `TTC` decimal(23,8) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=86 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `lmontage`
--

/*!40000 ALTER TABLE `lmontage` DISABLE KEYS */;
INSERT INTO `lmontage` (`ID`,`NUMF`,`CODES`,`CODEE`,`NPYLONE`,`TYPEPYLONE`,`POIDS`,`U`,`PUHT`,`REM`,`TVA`,`PTHT`,`TTC`) VALUES 
 (35,'FC000021','999','2012','5A/0','SB+0','9.21500000','U','700.00000000',NULL,'18.00000000','6450.50000000',NULL),
 (36,'FC000021','999','2012','5A/1','SA-3','4.43400000','U','700.00000000',NULL,'18.00000000','3103.80000000',NULL),
 (37,'FC000021','999','2012','5A/2','SA-3','4.43400000','U','700.00000000',NULL,'18.00000000','3103.80000000',NULL),
 (38,'FC000021','999','2012','5/A3','SA+7.5','6.75700000','U','700.00000000',NULL,'18.00000000','4729.90000000',NULL),
 (39,'FC000021','999','2012','5/A4','SA-7.5','6.75700000','U','700.00000000',NULL,'18.00000000','4729.90000000',NULL),
 (40,'FC000021','999','2012','5/A5','SA+6','6.35400000','U','700.00000000',NULL,'18.00000000','4447.80000000',NULL),
 (41,'FC000021','999','2012','6/0','SB+3','11.00700000','U','700.00000000',NULL,'18.00000000','7704.90000000',NULL),
 (42,'FC000021','999','2012','6/1','SA+6','6.35400000','U','700.00000000',NULL,'18.00000000','4447.80000000',NULL),
 (43,'FC000021','999','2012','6/2','SA-3','4.43400000','U','700.00000000',NULL,'18.00000000','3103.80000000',NULL),
 (44,'FC000021','999','2012','6/3','SA+3','5.77900000','U','700.00000000',NULL,'18.00000000','4045.30000000',NULL),
 (45,'FC000021','999','2012','6/4','SA+6','6.35400000','U','700.00000000',NULL,'18.00000000','4447.80000000',NULL),
 (46,'FC000021','999','2012','6/5','SA+3','5.77900000','U','700.00000000',NULL,'18.00000000','4045.30000000',NULL),
 (47,'FC000021','999','2012','7/0','SB+0','9.21500000','U','700.00000000',NULL,'18.00000000','6450.50000000',NULL),
 (48,'FC000021','999','2012','7/1','SA+4.5','6.08700000','U','700.00000000',NULL,'18.00000000','4260.90000000',NULL),
 (49,'FC000021','999','2012','7/2','SA-3','4.43400000','U','700.00000000',NULL,'18.00000000','3103.80000000',NULL),
 (50,'FC000021','999','2012','7/3','SA+0','4.91500000','U','700.00000000',NULL,'18.00000000','3440.50000000',NULL),
 (51,'FC000021','999','2012','7/4','SA+0','4.91500000','U','700.00000000',NULL,'18.00000000','3440.50000000',NULL),
 (52,'FC000025','999','2012','0/0','SD-6','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (53,'FC000025','999','2012','0/1','SA+3','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (54,'FC000025','999','2012','0/2','SA+0','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (55,'FC000025','999','2012','2/5','SA-1,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (56,'FC000025','999','2012','3/4','SA-1,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (57,'FC000025','999','2012','3/5','SA+7,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (58,'FC000025','999','2012','5/2','SA+7,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (59,'FC000025','999','2012','3/9','SA+4,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (60,'FC000025','999','2012','9/0','SB+0','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (61,'FC000025','999','2012','3/1','SA+6','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (62,'FC000025','999','2012','9/1','SA+6','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (63,'FC000025','999','2012','9/2','SA+4.5','6.08700000','TN','800.00000000',NULL,'18.00000000','4869.60000000',NULL),
 (64,'FC000025','999','2012','9/3','SA+7.5','6.75700000','TN','800.00000000',NULL,'18.00000000','5405.60000000',NULL),
 (65,'FC000025','999','2012','9/4','SA+1.5','5.29100000','TN','800.00000000',NULL,'18.00000000','4232.80000000',NULL),
 (66,'FC000025','999','2012','9/5','SA+6','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (67,'FC000025','999','2012','9/0','DD+E0+0','15.10800000','TN','800.00000000',NULL,'18.00000000','12086.40000000',NULL),
 (68,'FC000025','999','2012','2/0','DB+E0+0','14.96500000','TN','800.00000000',NULL,'18.00000000','11972.00000000',NULL),
 (69,'FC000026','999','2012','9/0','SB+0','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (70,'FC000026','999','2012','9/1','SA+6','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (71,'FC000026','999','2012','9/2','SA+4.5','6.08700000','TN','800.00000000',NULL,'18.00000000','4869.60000000',NULL),
 (72,'FC000026','999','2012','9/3','SA+7.5','6.75700000','TN','800.00000000',NULL,'18.00000000','5405.60000000',NULL),
 (73,'FC000026','999','2012','9/4','SA+1.5','5.29100000','TN','800.00000000',NULL,'18.00000000','4232.80000000',NULL),
 (74,'FC000026','999','2012','9/5','SA+6','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (75,'FC000026','999','2012','9/0','DD+E0+0','15.10800000','TN','800.00000000',NULL,'18.00000000','12086.40000000',NULL),
 (76,'FC000028','999','2012','5/2','SA+7,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (77,'FC000028','999','2012','3/9','SA+4,5','6.35400000','TN','800.00000000',NULL,'18.00000000','5083.20000000',NULL),
 (78,'FC000031','999','2012','0/1','1112222','20.00000000','1','5.00000000',NULL,'18.00000000','100.00000000',NULL),
 (79,'FC000031','999','2012','0/2','2221111','30.00000000','1','10.00000000',NULL,'18.00000000','300.00000000',NULL),
 (80,'FC000034','999','2012','9/0','SB+0','15.10800000','TN','800.00000000',NULL,'18.00000000','12086.40000000',NULL),
 (81,'FC000034','999','2012','2/0','DB+E0+0','14.96500000','TN','800.00000000',NULL,'18.00000000','11972.00000000',NULL),
 (82,'FC000034','999','2012','0/1','222','50.00000000','TN','700.00000000',NULL,'18.00000000','35000.00000000',NULL),
 (83,'FC000035','999','2012','9/0','SB+0','15.10800000','TN','800.00000000',NULL,'18.00000000','12086.40000000',NULL),
 (84,'FC000035','999','2012','2/0','DB+E0+0','14.96500000','TN','800.00000000',NULL,'18.00000000','11972.00000000',NULL),
 (85,'FC000035','999','2012','0/1','222','50.00000000','TN','700.00000000',NULL,'18.00000000','35000.00000000',NULL);
/*!40000 ALTER TABLE `lmontage` ENABLE KEYS */;


--
-- Definition of table `lregc`
--

DROP TABLE IF EXISTS `lregc`;
CREATE TABLE `lregc` (
  `ID` int(15) NOT NULL auto_increment,
  `codeu` varchar(2) default NULL,
  `codes` varchar(3) default NULL,
  `codee` varchar(4) default NULL,
  `codem` varchar(3) default NULL,
  `codec` varchar(10) default NULL,
  `NUM` varchar(10) default NULL,
  `nfact` varchar(10) default NULL,
  `MONT` decimal(19,3) default NULL,
  `date` datetime default NULL,
  `mntret` decimal(19,3) default NULL,
  `mntrem` decimal(19,3) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `lregc`
--

/*!40000 ALTER TABLE `lregc` DISABLE KEYS */;
INSERT INTO `lregc` (`ID`,`codeu`,`codes`,`codee`,`codem`,`codec`,`NUM`,`nfact`,`MONT`,`date`,`mntret`,`mntrem`) VALUES 
 (24,'03','999','2012','001','4100005','RC000023','FC000012','3375.550','2012-12-12 00:00:00',NULL,NULL),
 (25,'03','999','2012','001','4100005','RC000024','FC000004','265.000','2012-12-15 00:00:00',NULL,NULL),
 (26,'03','999','2012','001','4100005','RC000024','FC000006','3091.200','2012-12-15 00:00:00',NULL,NULL),
 (27,'03','999','2012','001','4100001','RC000025','FC000001','448.400','2012-12-18 00:00:00',NULL,NULL),
 (28,'03','999','2012','001','4100001','RC000025','FC000005','211.043','2012-12-18 00:00:00',NULL,NULL),
 (29,'03','999','2012','001','4100001','RC000025','FC000009','758.627','2012-12-18 00:00:00',NULL,NULL);
/*!40000 ALTER TABLE `lregc` ENABLE KEYS */;


--
-- Definition of table `ltravaux`
--

DROP TABLE IF EXISTS `ltravaux`;
CREATE TABLE `ltravaux` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `CODES` varchar(5) default NULL,
  `CODEE` varchar(4) default NULL,
  `DESIGNATION` varchar(500) default NULL,
  `U` varchar(45) default NULL,
  `PUHT` decimal(23,8) default NULL,
  `REM` decimal(23,8) default NULL,
  `TVA` decimal(23,8) default NULL,
  `PTHT` decimal(23,8) default NULL,
  `TTC` decimal(23,8) default NULL,
  `QTE` decimal(23,8) default NULL,
  `NUMF` varchar(45) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=latin1;

--
-- Dumping data for table `ltravaux`
--

/*!40000 ALTER TABLE `ltravaux` DISABLE KEYS */;
INSERT INTO `ltravaux` (`ID`,`CODES`,`CODEE`,`DESIGNATION`,`U`,`PUHT`,`REM`,`TVA`,`PTHT`,`TTC`,`QTE`,`NUMF`) VALUES 
 (1,'999','2012','Execution dun massif classe 1 pour un Pylone de Type C classe 1 avec utilisation du Ciment HRS dosé a 400KG/M3','UN','18500.00000000',NULL,'18.00000000','18500.00000000',NULL,'1.00000000','FC000023'),
 (2,'999','2012','Assemblage et Levage dun Pylone de Type C','UN','10000.00000000',NULL,'18.00000000','10000.00000000',NULL,'1.00000000','FC000023'),
 (3,'999','2012','Assemblage et mise en place des chaines dancrage pou cables conducteur et cables de garde deroulage des cables conducteurs et cables de garde entre le support a implanteur (environ 150m) y compris essai et mise en service','FORFAIT','10000.00000000',NULL,'18.00000000','10000.00000000',NULL,'1.00000000','FC000023'),
 (10,'999','2012','Assemblage et Montage dun Pylone ZBR','UN','15106.66900000',NULL,'18.00000000','15106.66900000',NULL,'1.00000000','FC000024'),
 (11,'999','2012','Assemblage et Montage dun Pylone ZBX','UN','23241.02900000',NULL,'18.00000000','23241.02900000',NULL,'1.00000000','FC000024'),
 (12,'999','2012','Déroulage, Réglage et accrochage des cables conducteur 297 mm2','KM','23241.02900000',NULL,'18.00000000','58102.57300000',NULL,'2.50000000','FC000024'),
 (13,'999','2012','Dépose dun troncon de ligne','KM','21130.43500000',NULL,'18.00000000','48600.00100000',NULL,'2.30000000','FC000024'),
 (14,'999','2012','Démolition de lancien massif à 1m de profondeur','UN','2095.00000000',NULL,'18.00000000','10475.00000000',NULL,'5.00000000','FC000024'),
 (15,'999','2012','Transport du Materiel depose au magasin de la Steg à Tunis','KM','5256.52200000',NULL,'18.00000000','12090.00100000',NULL,'2.30000000','FC000024'),
 (16,'999','2012','ppp oooo','1','100.00000000',NULL,'18.00000000','1000.00000000',NULL,'10.00000000','FC000032'),
 (17,'999','2012','55555555555555555','5','20.00000000',NULL,'18.00000000','1040.00000000',NULL,'52.00000000','FC000038');
/*!40000 ALTER TABLE `ltravaux` ENABLE KEYS */;


--
-- Definition of table `modalite`
--

DROP TABLE IF EXISTS `modalite`;
CREATE TABLE `modalite` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `Code` varchar(5) NOT NULL,
  `libelle` varchar(500) default NULL,
  `REF` varchar(50) default NULL,
  `Observation` varchar(500) default NULL,
  PRIMARY KEY  USING BTREE (`codes`,`Code`),
  KEY `Index_2` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `modalite`
--

/*!40000 ALTER TABLE `modalite` DISABLE KEYS */;
INSERT INTO `modalite` (`ID`,`codes`,`Code`,`libelle`,`REF`,`Observation`) VALUES 
 (9,'999','CHQ30','Cheque 30 Jrs',NULL,'Par chèque ou virement bancaire à notre compte bancaire ATB n° 01001020110706642551 à trent (30) jours de la réception de la présente facture.'),
 (10,'999','CHQ60','Cheque 60 Jrs',NULL,'Par chèque ou virement bancaire à notre compte bancaire ATB n° 01001020110706642551 à soixante (60) jours de la réception de la présente facture.'),
 (11,'999','CHQ90','Cheque 90 Jrs',NULL,'Par chèque ou virement bancaire à notre compte bancaire ATB n° 01001020110706642551 à quatre vignt dix (90) jours de la réception de la présente facture.');
/*!40000 ALTER TABLE `modalite` ENABLE KEYS */;


--
-- Definition of table `nomtable`
--

DROP TABLE IF EXISTS `nomtable`;
CREATE TABLE `nomtable` (
  `ID` int(10) NOT NULL auto_increment,
  `libelle` varchar(30) default NULL,
  `nom` varchar(20) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=45 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `nomtable`
--

/*!40000 ALTER TABLE `nomtable` DISABLE KEYS */;
INSERT INTO `nomtable` (`ID`,`libelle`,`nom`) VALUES 
 (1,'Famille Client','FamilleClient'),
 (2,'Famille Fournisseur','FamilleFour'),
 (3,'Famille Article','FamilleArticle'),
 (4,'Article','Article'),
 (5,'Client','Client'),
 (6,'Fournisseur','Four'),
 (7,'Lieu du Stock','Lstk'),
 (8,'Representant','Rep'),
 (9,'Tva','tva'),
 (11,'Region','Region'),
 (13,'Entete Facture Client','EENTC'),
 (14,'Ligne Facture Client','LENTC'),
 (15,'Entete Facture Fournisseur','EENTF'),
 (16,'Ligne Facture Fournisseur','LENTF'),
 (17,'Entete Livraison Client','EENTL'),
 (19,'Ligne Livraison Client','LENTL'),
 (20,'Entete Entre Fournisseur','EENTE'),
 (21,'Ligne Entre Fournisseur','LENTE'),
 (22,'Entete Devis Client','EENTD'),
 (23,'Ligne Devis Client','LENTD'),
 (31,'Entete Avoir Client','EENTVC'),
 (34,'Entete Avoir Fournisseur','EENTVF'),
 (35,'Ligne  Avoir Client','LENTVC'),
 (36,'Ligne  Avoir Fournisseur','LENTVF'),
 (37,'Entete Commande Client','EENTCC'),
 (38,'Ligne Commande Client','LENTCC'),
 (39,'Entete Commande Fournisseur','EENTCF'),
 (40,'Ligne Commande Fournisseur','LENTCF'),
 (41,'Entete Reglement Client','eregc'),
 (42,'Ligne Reglement Client','lregc'),
 (43,'Entete Paiement Fournisseur','eregf'),
 (44,'Ligne Paiement Fournisseur','lregf');
/*!40000 ALTER TABLE `nomtable` ENABLE KEYS */;


--
-- Definition of table `parametre`
--

DROP TABLE IF EXISTS `parametre`;
CREATE TABLE `parametre` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `param` varchar(255) default NULL,
  `value` varchar(255) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `parametre`
--

/*!40000 ALTER TABLE `parametre` DISABLE KEYS */;
INSERT INTO `parametre` (`ID`,`codes`,`param`,`value`) VALUES 
 (1,'999','TauxMajoration','25'),
 (2,'999','Timbre','0.400'),
 (3,'999','Cumulqteclient','Non'),
 (4,'999','Cumulqtefour','Non'),
 (5,'999','CumulRemiseClient','Non'),
 (6,'999','RCB','Oui'),
 (7,'999','RCL','Oui'),
 (8,'999','RCF','Oui'),
 (9,'999','RCA','Oui'),
 (10,'999','RCR','Oui'),
 (11,'999','RFL','Oui'),
 (12,'999','RFF','Oui'),
 (13,'999','RFA','Oui'),
 (14,'999','RFR','Oui'),
 (15,'999','BonTicket','Oui');
/*!40000 ALTER TABLE `parametre` ENABLE KEYS */;


--
-- Definition of table `pnum`
--

DROP TABLE IF EXISTS `pnum`;
CREATE TABLE `pnum` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `codem` varchar(3) NOT NULL,
  `dbon` varchar(2) default NULL,
  `bon` varchar(8) default NULL,
  `dlivraison` varchar(2) default NULL,
  `livraison` varchar(8) default NULL,
  `dcomande` varchar(2) default NULL,
  `comande` varchar(8) default NULL,
  `ddevis` varchar(2) default NULL,
  `devis` varchar(8) default NULL,
  `dcomandef` varchar(2) default NULL,
  `comandef` varchar(8) default NULL,
  `dentre` varchar(2) default NULL,
  `entre` varchar(8) default NULL,
  `dregcli` varchar(2) default NULL,
  `regcli` varchar(8) default NULL,
  `dregfour` varchar(2) default NULL,
  `regfour` varchar(8) default NULL,
  `gamme` varchar(10) default NULL,
  `secteur` varchar(10) default NULL,
  `rayon` varchar(10) default NULL,
  `etagere` varchar(10) default NULL,
  `casier` varchar(10) default NULL,
  `apaiement` varchar(10) default NULL,
  `areglement` varchar(10) default NULL,
  `aversement` varchar(10) default NULL,
  PRIMARY KEY  USING BTREE (`codes`,`codee`,`codem`),
  KEY `codee` (`codee`),
  KEY `codes` (`codes`),
  KEY `Index_4` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pnum`
--

/*!40000 ALTER TABLE `pnum` DISABLE KEYS */;
INSERT INTO `pnum` (`ID`,`codes`,`codee`,`codem`,`dbon`,`bon`,`dlivraison`,`livraison`,`dcomande`,`comande`,`ddevis`,`devis`,`dcomandef`,`comandef`,`dentre`,`entre`,`dregcli`,`regcli`,`dregfour`,`regfour`,`gamme`,`secteur`,`rayon`,`etagere`,`casier`,`apaiement`,`areglement`,`aversement`) VALUES 
 (1,'999','2012','001','BC','000016','LC','000021','CC','000001','DC','000002','CF','000000  ','LF','000017','RC','000025','PF','000004  ','0000000000','0000000002','0000000004','0000000004','0000000004','0000000002','0000000002','0000000003'),
 (2,'999','2012','002','BC','000000','LC','000000  ','CC','000000 ','DC','000000  ','CF','00000   ','LF','000000  ','RC','000000  ','PF','000000 ','0000000000','0000000000','0000000000','0000000000','0000000000','0000000000','0000000000','0000000000');
/*!40000 ALTER TABLE `pnum` ENABLE KEYS */;


--
-- Definition of table `pnumste`
--

DROP TABLE IF EXISTS `pnumste`;
CREATE TABLE `pnumste` (
  `ID` int(10) NOT NULL auto_increment,
  `codes` varchar(3) NOT NULL,
  `codee` varchar(4) NOT NULL,
  `dfacture` varchar(2) default NULL,
  `facture` varchar(8) default NULL,
  `dfactures` varchar(2) default NULL,
  `factures` varchar(8) default NULL,
  `dfacturef` varchar(2) default NULL,
  `facturef` varchar(8) default NULL,
  `davoirc` varchar(2) default NULL,
  `avoirc` varchar(8) default NULL,
  `davoirf` varchar(2) default NULL,
  `avoirf` varchar(8) default NULL,
  `codeclient` varchar(10) default NULL,
  `codecomptant` varchar(10) default NULL,
  `codefour` varchar(10) default NULL,
  `famillearticle` varchar(3) default NULL,
  `region` varchar(3) default NULL,
  `secteur` varchar(3) default NULL,
  `familleclient` varchar(3) default NULL,
  `famillefour` varchar(3) default NULL,
  PRIMARY KEY  (`codes`,`codee`),
  KEY `Index_2` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `pnumste`
--

/*!40000 ALTER TABLE `pnumste` DISABLE KEYS */;
INSERT INTO `pnumste` (`ID`,`codes`,`codee`,`dfacture`,`facture`,`dfactures`,`factures`,`dfacturef`,`facturef`,`davoirc`,`avoirc`,`davoirf`,`avoirf`,`codeclient`,`codecomptant`,`codefour`,`famillearticle`,`region`,`secteur`,`familleclient`,`famillefour`) VALUES 
 (1,'999','2012','FC','000038','FS','000001','FF','000005','AC','000000','AF','000000','4100010','4100000','4000013','006','003','000','003','002');
/*!40000 ALTER TABLE `pnumste` ENABLE KEYS */;


--
-- Definition of table `propos`
--

DROP TABLE IF EXISTS `propos`;
CREATE TABLE `propos` (
  `ID` int(11) NOT NULL auto_increment,
  `image` longblob,
  `images` int(3) NOT NULL,
  `imagep` int(4) NOT NULL,
  `imaged` datetime NOT NULL,
  `imagef` int(5) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `propos`
--

/*!40000 ALTER TABLE `propos` DISABLE KEYS */;
/*!40000 ALTER TABLE `propos` ENABLE KEYS */;


--
-- Definition of table `ste`
--

DROP TABLE IF EXISTS `ste`;
CREATE TABLE `ste` (
  `ID` int(10) NOT NULL auto_increment,
  `code` varchar(3) default NULL,
  `libelle` varchar(50) default NULL,
  `adr` varchar(50) default NULL,
  `mf` varchar(20) default NULL,
  `ncnss` varchar(10) default NULL,
  `telfixe` varchar(12) default NULL,
  `telgsm` varchar(12) default NULL,
  `var` varchar(1) default NULL,
  `fodec` tinyint(1) default NULL,
  `Ville` varchar(45) default NULL,
  `responsable` varchar(250) default NULL,
  `fonction` varchar(250) default NULL,
  PRIMARY KEY  (`ID`),
  KEY `code` (`code`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ste`
--

/*!40000 ALTER TABLE `ste` DISABLE KEYS */;
INSERT INTO `ste` (`ID`,`code`,`libelle`,`adr`,`mf`,`ncnss`,`telfixe`,`telgsm`,`var`,`fodec`,`Ville`,`responsable`,`fonction`) VALUES 
 (1,'999','Exemple','37 Avenue 20 Mars - Bardo 2000','123456/C/A/M/000','526854','71 00 00 00','98 57 62 25','N',0,'Tunis','DELLAGI HASSEN','DIRECTEUR GENERAL-GERANT');
/*!40000 ALTER TABLE `ste` ENABLE KEYS */;


--
-- Definition of table `tva`
--

DROP TABLE IF EXISTS `tva`;
CREATE TABLE `tva` (
  `ID` int(10) NOT NULL auto_increment,
  `libelle` varchar(50) default NULL,
  `taux` double(7,2) default NULL,
  `actif` tinyint(1) NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `tva`
--

/*!40000 ALTER TABLE `tva` DISABLE KEYS */;
INSERT INTO `tva` (`ID`,`libelle`,`taux`,`actif`) VALUES 
 (13,'Tva 0%',0.00,1),
 (14,'Tva 6%',6.00,1),
 (15,'Tva 12%',12.00,1),
 (17,'Tva 18%',18.00,1);
/*!40000 ALTER TABLE `tva` ENABLE KEYS */;


--
-- Definition of table `utilisateur`
--

DROP TABLE IF EXISTS `utilisateur`;
CREATE TABLE `utilisateur` (
  `ID` int(10) NOT NULL auto_increment,
  `code` varchar(2) NOT NULL,
  `libelle` varchar(50) default NULL,
  `mp` varchar(10) default NULL,
  `type` varchar(1) default NULL,
  PRIMARY KEY  (`code`),
  KEY `code` (`code`),
  KEY `Index_3` (`ID`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `utilisateur`
--

/*!40000 ALTER TABLE `utilisateur` DISABLE KEYS */;
INSERT INTO `utilisateur` (`ID`,`code`,`libelle`,`mp`,`type`) VALUES 
 (1,'00','Mohsen','21011966','S'),
 (2,'01','SA','valid','S'),
 (3,'02','A','valid','A'),
 (4,'03','1','1','S'),
 (5,'04','2','1','U'),
 (6,'05','3','1','U'),
 (7,'06','4','1','U'),
 (8,'07','5','1','U');
/*!40000 ALTER TABLE `utilisateur` ENABLE KEYS */;




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
