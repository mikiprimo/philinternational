ALTER TABLE  `anagrafica` ADD  `partita_iva` INT( 11 ) NULL DEFAULT NULL AFTER  `codice_fiscale`;
ALTER TABLE  `anagrafica` CHANGE  `codice_fiscale`  `codice_fiscale` VARCHAR( 16 ) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;
ALTER TABLE  `anagrafica` CHANGE  `res_via`  `res_via` VARCHAR( 30 ) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL;