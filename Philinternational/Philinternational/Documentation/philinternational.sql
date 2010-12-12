-- phpMyAdmin SQL Dump
-- version 3.2.0.1
-- http://www.phpmyadmin.net
--
-- Host: localhost
-- Generato il: 12 dic, 2010 at 11:14 PM
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

DROP TABLE IF EXISTS anagrafica;
CREATE TABLE IF NOT EXISTS anagrafica (
  idanagrafica int(10) NOT NULL,
  nome varchar(45) NOT NULL,
  cognome varchar(75) NOT NULL,
  codice_fiscale varchar(16) DEFAULT NULL,
  res_via varchar(30) NOT NULL,
  res_indirizzo varchar(100) NOT NULL,
  res_num_civico varchar(15) NOT NULL,
  res_cap varchar(5) NOT NULL,
  res_comune varchar(100) NOT NULL,
  res_provincia varchar(2) NOT NULL,
  res_nazione varchar(50) NOT NULL,
  dom_via varchar(30) NOT NULL,
  dom_indirizzo varchar(100) NOT NULL,
  dom_num_civico varchar(15) NOT NULL,
  dom_cap varchar(5) NOT NULL,
  dom_comune varchar(100) NOT NULL,
  dom_provincia varchar(2) NOT NULL,
  dom_nazione varchar(50) NOT NULL,
  email varchar(100) NOT NULL,
  `password` varchar(15) NOT NULL,
  stato int(3) NOT NULL,
  idprofilo int(3) NOT NULL COMMENT '2 - per utente',
  data_inserimento datetime NOT NULL,
  PRIMARY KEY (idanagrafica)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'anagrafica'
--

INSERT INTO anagrafica (idanagrafica, nome, cognome, codice_fiscale, res_via, res_indirizzo, res_num_civico, res_cap, res_comune, res_provincia, res_nazione, dom_via, dom_indirizzo, dom_num_civico, dom_cap, dom_comune, dom_provincia, dom_nazione, email, password, stato, idprofilo, data_inserimento) VALUES(1, 'ciro', 'o amministratore', NULL, 'via', 'le mani dal naso', '2', '20121', 'milani', 'mi', 'italia', 'via', 'le mani dal naso', '2', '20121', 'milano', 'mi', 'italia', 'admin@admin.it', 'password', 1, 1, '2010-12-07 17:50:39');
INSERT INTO anagrafica (idanagrafica, nome, cognome, codice_fiscale, res_via, res_indirizzo, res_num_civico, res_cap, res_comune, res_provincia, res_nazione, dom_via, dom_indirizzo, dom_num_civico, dom_cap, dom_comune, dom_provincia, dom_nazione, email, password, stato, idprofilo, data_inserimento) VALUES(2, 'Utente', 'che paga', NULL, 'piazzale', 'busta paga', '1', '20121', 'milano', 'mi', 'italia', 'piazzale', 'busta paga', '1', '20121', 'milano', 'mi', 'italia', 'user@admin.it', 'password', 1, 2, '2010-12-07 17:51:52');
INSERT INTO anagrafica (idanagrafica, nome, cognome, codice_fiscale, res_via, res_indirizzo, res_num_civico, res_cap, res_comune, res_provincia, res_nazione, dom_via, dom_indirizzo, dom_num_civico, dom_cap, dom_comune, dom_provincia, dom_nazione, email, password, stato, idprofilo, data_inserimento) VALUES(3, 'webmaster', 'sicuro', 'AAABBB12C34A456P', 'piazza', 'la bomba e scappa', '40', '20099', 'sesto san giovanni', 'mi', 'italia', 'piazza', 'la bomba e scappa', '40', '20099', 'sesto san giovanni', 'mi', 'italia', 'webmaster@admin.it', 'password', 1, 3, '2010-12-07 17:53:54');

-- --------------------------------------------------------

--
-- Struttura della tabella 'anagrafica_dettaglio'
--

DROP TABLE IF EXISTS anagrafica_dettaglio;
CREATE TABLE IF NOT EXISTS anagrafica_dettaglio (
  idanagrafica int(10) NOT NULL,
  newsletter int(1) NOT NULL DEFAULT '1',
  PRIMARY KEY (idanagrafica)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'anagrafica_dettaglio'
--

INSERT INTO anagrafica_dettaglio (idanagrafica, newsletter) VALUES(1, 1);
INSERT INTO anagrafica_dettaglio (idanagrafica, newsletter) VALUES(2, 1);
INSERT INTO anagrafica_dettaglio (idanagrafica, newsletter) VALUES(3, 1);

-- --------------------------------------------------------

--
-- Struttura della tabella 'anagrafica_movimenti'
--

DROP TABLE IF EXISTS anagrafica_movimenti;
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

DROP TABLE IF EXISTS asta_elenco;
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

DROP TABLE IF EXISTS legenda_lotto;
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

DROP TABLE IF EXISTS legenda_stato;
CREATE TABLE IF NOT EXISTS legenda_stato (
  id_stato int(10) NOT NULL,
  descrizione varchar(45) NOT NULL,
  PRIMARY KEY (id_stato)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'legenda_stato'
--

INSERT INTO legenda_stato (id_stato, descrizione) VALUES(0, 'sospeso');
INSERT INTO legenda_stato (id_stato, descrizione) VALUES(1, 'attivo');
INSERT INTO legenda_stato (id_stato, descrizione) VALUES(2, 'bloccato');
INSERT INTO legenda_stato (id_stato, descrizione) VALUES(99, 'da attivare');

-- --------------------------------------------------------

--
-- Struttura della tabella 'lotto'
--

DROP TABLE IF EXISTS lotto;
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

DROP TABLE IF EXISTS lotto_load;
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

DROP TABLE IF EXISTS lotto_scartato;
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

DROP TABLE IF EXISTS news;
CREATE TABLE IF NOT EXISTS news (
  idnews int(11) NOT NULL,
  data_pubblicazione datetime DEFAULT NULL,
  titolo varchar(100) DEFAULT NULL,
  testo text,
  stato int(3) DEFAULT NULL,
  PRIMARY KEY (idnews)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

--
-- Dump dei dati per la tabella 'news'
--

INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(1, '2010-12-07 17:43:03', 'Prova', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(11, '2010-10-07 17:43:03', ' vProva', 'tedasst', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(12, '2010-11-05 17:43:03', 'b Prova', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(13, '2010-12-01 17:43:03', '0Prova', 'tesdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(9, '2010-12-06 17:43:03', 'Prova', '5465', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(10, '2010-12-05 17:43:03', 'dProva', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(8, '2010-11-07 17:43:03', 'Prova', ' gfdsgdgdswert45646', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(7, '2010-11-07 17:43:03', 'Prova', ' dfgdgdfsgdfs  dfgds df', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(14, '2010-12-01 17:43:03', '1Prova', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(6, '2010-12-09 17:43:03', 'Prova', 'fgdsgdsfgsd', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(5, '2010-11-01 17:43:03', 'Prova', 'tesadfdsafdsast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(4, '2010-11-07 17:43:03', 'Prova', 'tdsf  iudsagif dsa iadsifadsest', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(3, '2010-10-03 17:43:03', 'Prova fdsf', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(2, '2010-12-07 17:43:03', 'Prova', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(15, '2010-12-02 17:43:03', '2Prova', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(16, '2010-12-03 17:43:03', '3Prova', 'test', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(17, '2010-12-04 17:43:03', '4Prova', 'tdaest', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(18, '2010-12-05 17:43:03', '65Prova', 'tdasdaest', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(19, '2010-12-06 17:43:03', 'Prova', 'tedasst', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(20, '2010-12-12 00:00:00', 'miiiiiiiiiiiichel', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(21, '2010-12-08 10:00:21', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(22, '2010-12-08 10:00:22', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(23, '2010-12-08 10:00:23', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(24, '2010-12-08 10:00:24', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(25, '2010-12-08 10:00:25', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(26, '2010-12-08 10:00:26', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(27, '2010-12-08 10:00:27', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(28, '2010-12-08 10:00:28', '7Prova', 'tedasdast', 1);
INSERT INTO news (idnews, data_pubblicazione, titolo, testo, stato) VALUES(29, '2010-12-08 10:00:21', '29Prova', 'tedasdast', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella 'newsletter'
--

DROP TABLE IF EXISTS newsletter;
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

DROP TABLE IF EXISTS offerta_per_corrispondenza;
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

DROP TABLE IF EXISTS paragrafo;
CREATE TABLE IF NOT EXISTS paragrafo (
  idparagrafo int(5) NOT NULL,
  descrizione varchar(45) NOT NULL,
  stato int(3) DEFAULT '1',
  PRIMARY KEY (idparagrafo)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='Antichi stati';

--
-- Dump dei dati per la tabella 'paragrafo'
--

INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(1, 'PREFILATELICHE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(2, 'ANTICHI STATI', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(3, 'ITALIA REGNO', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(4, 'REPUBBLICA SOCIALE ITALIANA', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(5, 'LUOGOTENENZA', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(6, 'EMISSIONI LOCALI', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(7, 'COLONIE ITALIANE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(8, 'OCCUPAZIONI STRANIERE - I GUERRA MONDIALE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(9, 'TERRE REDENTE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(10, 'OCCUPAZIONI ITALIANE - II GUERRA MONDIALE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(11, 'LEVANTE ITALIANO', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(12, 'OCCUPAZIONI STRANIERE - II GUERRA MONDIALE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(13, 'REPUBBLICA', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(14, 'TRIESTE A', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(15, 'SAN MARINO', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(16, 'VATICANO', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(17, 'EUROPA', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(18, 'OLTREMARE', 1);
INSERT INTO paragrafo (idparagrafo, descrizione, stato) VALUES(19, 'LOTTI E COLLEZIONI', 1);

-- --------------------------------------------------------

--
-- Struttura della tabella 'paragrafo_argomento'
--

DROP TABLE IF EXISTS paragrafo_argomento;
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

DROP TABLE IF EXISTS paragrafo_subargomento;
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

DROP TABLE IF EXISTS profilo;
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

INSERT INTO profilo (idprofilo, descrizione, amministrazione) VALUES(1, 'Amministratore', 1);
INSERT INTO profilo (idprofilo, descrizione, amministrazione) VALUES(2, 'utente', 0);
INSERT INTO profilo (idprofilo, descrizione, amministrazione) VALUES(3, 'webmaster', 1);
