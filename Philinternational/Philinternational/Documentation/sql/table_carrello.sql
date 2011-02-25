CREATE TABLE IF NOT EXISTS carrello (
  idcarrello int(10) NOT NULL,
  idanagrafica varchar(32) NOT NULL,
  idlotto int(10) NOT NULL,
  data_inserimento datetime NOT NULL,
  PRIMARY KEY (idcarrello)
) ENGINE=MyISAM DEFAULT CHARSET=latin1 COMMENT='carrello utente';

