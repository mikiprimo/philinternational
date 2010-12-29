DROP TABLE IF EXISTS lotto;
DROP TABLE IF EXISTS lotto_load;

CREATE TABLE IF NOT EXISTS lotto_tmp (
  idcatalogo int(10) NOT NULL,
  conferente varchar(15) DEFAULT NULL,
  anno varchar(15) NOT NULL,
  tipo_lotto varchar(30) DEFAULT NULL,
  numero_pezzi int(11) NOT NULL,
  descrizione text NOT NULL,
  prezzo_base float DEFAULT NULL,
  euro varchar(15) DEFAULT NULL,
  riferimento_sassone varchar(20) DEFAULT NULL,
  PRIMARY KEY (idcatalogo)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;


CREATE TABLE IF NOT EXISTS lotto (
  idcatalogo int(10) NOT NULL,
  idparagrafo_argomento int(10) NOT NULL,
  idparagrafo_subargomento int(10) DEFAULT NULL,
  conferente varchar(15) DEFAULT NULL,
  anno varchar(15) NOT NULL,
  tipo_lotto varchar(30) DEFAULT NULL,
  numero_pezzi int(11) NOT NULL,
  descrizione text NOT NULL,
  prezzo_base float DEFAULT NULL,
  euro varchar(15) DEFAULT NULL,
  riferimento_sassone varchar(20) DEFAULT NULL,
  stato int(3) 
  PRIMARY KEY (idcatalogo)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;