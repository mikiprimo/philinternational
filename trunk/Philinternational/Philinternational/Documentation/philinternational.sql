-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generato il: 20 nov, 2010 at 01:18 PM
-- Versione MySQL: 5.1.36
-- Versione PHP: 5.3.0

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: 'philinternational'
--

-- --------------------------------------------------------

--
-- Struttura della tabella 'anagrafica'
--

CREATE TABLE IF NOT EXISTS anagrafica (
  idanagrafica int(10) NOT NULL,
  nome varchar(45) NOT NULL,
  cognome varchar(75) NOT NULL,
  codice_fiscale varchar(16) DEFAULT NULL,
  via varchar(30) NOT NULL,
  indirizzo varchar(100) NOT NULL,
  num_civico varchar(15) NOT NULL,
  cap varchar(5) NOT NULL,
  comune varchar(100) NOT NULL,
  provincia varchar(2) NOT NULL,
  email varchar(100) NOT NULL,
  `password` varchar(15) NOT NULL,
  stato int(3) NOT NULL,
  idprofilo int(3) NOT NULL COMMENT '2',
  data_inserimento datetime NOT NULL,
  PRIMARY KEY (idanagrafica)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'anagrafica'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'anagrafica_dettaglio'
--

CREATE TABLE IF NOT EXISTS anagrafica_dettaglio (
  idanagrafica int(10) NOT NULL,
  newsletter int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (idanagrafica)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'anagrafica_dettaglio'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'anagrafica_movimenti'
--

CREATE TABLE IF NOT EXISTS anagrafica_movimenti (
  idanagrafica int(10) NOT NULL,
  numero_asta varchar(3) NOT NULL,
  PRIMARY KEY (idanagrafica,numero_asta)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'anagrafica_movimenti'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'asta_elenco'
--

CREATE TABLE IF NOT EXISTS asta_elenco (
  idasta varchar(3) NOT NULL,
  data_fine datetime DEFAULT NULL,
  PRIMARY KEY (idasta)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'asta_elenco'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'legenda_lotto'
--

CREATE TABLE IF NOT EXISTS legenda_lotto (
  idlegenda int(10) NOT NULL,
  descrizione varchar(45) DEFAULT NULL,
  stato int(3) DEFAULT NULL,
  PRIMARY KEY (idlegenda)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'legenda_lotto'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'legenda_stato'
--

CREATE TABLE IF NOT EXISTS legenda_stato (
  id_stato int(10) NOT NULL,
  descrizione varchar(45) NOT NULL,
  PRIMARY KEY (id_stato)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'legenda_stato'
--

INSERT INTO legenda_stato (id_stato, descrizione) VALUES
(0, 'sospeso'),
(1, 'attivo'),
(2, 'bloccato'),
(99, 'da attivare');

-- --------------------------------------------------------

--
-- Struttura della tabella 'lotto'
--

CREATE TABLE IF NOT EXISTS lotto (
  id_lotto int(10) NOT NULL DEFAULT '0',
  id_paragrafo int(10) NOT NULL DEFAULT '0',
  anno varchar(12) NOT NULL DEFAULT '',
  condizione varchar(25) NOT NULL DEFAULT '',
  colore varchar(10) NOT NULL DEFAULT '',
  descrizione text NOT NULL,
  prezzo varchar(12) NOT NULL DEFAULT '',
  stato int(3) NOT NULL DEFAULT '1',
  PRIMARY KEY (id_lotto)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'lotto'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'lotto_load'
--

CREATE TABLE IF NOT EXISTS lotto_load (
  id_lotto float NOT NULL DEFAULT '0',
  id_paragrafo float DEFAULT NULL,
  anno varchar(12) NOT NULL DEFAULT '',
  condizione varchar(25) NOT NULL DEFAULT '',
  colore varchar(10) NOT NULL DEFAULT '',
  descrizione text NOT NULL,
  prezzo varchar(12) NOT NULL DEFAULT '',
  stato char(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (id_lotto)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'lotto_load'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'lotto_scartato'
--

CREATE TABLE IF NOT EXISTS lotto_scartato (
  idlotto_scartato int(11) NOT NULL,
  testo text,
  PRIMARY KEY (idlotto_scartato)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'lotto_scartato'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'news'
--

CREATE TABLE IF NOT EXISTS news (
  idnews int(11) NOT NULL,
  data_pubblicazione datetime DEFAULT NULL,
  titolo varchar(100) DEFAULT NULL,
  testo text,
  stato char(1) DEFAULT NULL,
  PRIMARY KEY (idnews)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'news'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'newsletter'
--

CREATE TABLE IF NOT EXISTS newsletter (
  idnewsletter int(11) NOT NULL,
  data_creazione datetime DEFAULT NULL,
  titolo varchar(100) DEFAULT NULL,
  testo text,
  PRIMARY KEY (idnewsletter)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'newsletter'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'offerta_per_corrispondenza'
--

CREATE TABLE IF NOT EXISTS offerta_per_corrispondenza (
  idofferta int(11) NOT NULL,
  idlotto int(11) DEFAULT NULL,
  idanagrafica int(11) DEFAULT NULL,
  prezzo_offerto varchar(15) DEFAULT NULL,
  data_inserimento datetime DEFAULT NULL,
  PRIMARY KEY (idofferta)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Elenco delle offerte effettuate';

--
-- Dump dei dati per la tabella 'offerta_per_corrispondenza'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'paragrafo'
--

CREATE TABLE IF NOT EXISTS paragrafo (
  idparagrafo int(5) NOT NULL,
  descrizione varchar(45) NOT NULL,
  stato int(3) DEFAULT '1',
  PRIMARY KEY (idparagrafo)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Antichi stati';

--
-- Dump dei dati per la tabella 'paragrafo'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'paragrafo_argomento'
--

CREATE TABLE IF NOT EXISTS paragrafo_argomento (
  idargomento int(11) NOT NULL,
  idparagrafo int(11) NOT NULL,
  descrizione varchar(45) NOT NULL,
  stato int(3) DEFAULT '1',
  PRIMARY KEY (idargomento)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Lombardo Veneto';

--
-- Dump dei dati per la tabella 'paragrafo_argomento'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'paragrafo_subargomento'
--

CREATE TABLE IF NOT EXISTS paragrafo_subargomento (
  idsub_argomento int(11) NOT NULL,
  idargomento int(11) NOT NULL,
  descrizione varchar(45) NOT NULL,
  stato int(3) DEFAULT '1',
  PRIMARY KEY (idsub_argomento)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Francobolli per giornali';

--
-- Dump dei dati per la tabella 'paragrafo_subargomento'
--


-- --------------------------------------------------------

--
-- Struttura della tabella 'profilo'
--

CREATE TABLE IF NOT EXISTS profilo (
  idprofilo int(3) NOT NULL,
  descrizione varchar(45) DEFAULT NULL,
  amministrazione int(1) DEFAULT '0',
  PRIMARY KEY (idprofilo),
  UNIQUE KEY descrizione_UNIQUE (descrizione)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'profilo'
--

INSERT INTO profilo (idprofilo, descrizione, amministrazione) VALUES
(1, 'Amministratore', 1),
(2, 'utente', 0),
(3, 'webmaster', 1);
