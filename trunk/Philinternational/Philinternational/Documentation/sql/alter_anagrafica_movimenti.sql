ALTER TABLE `anagrafica_movimenti` ADD `data_inserimento` DATETIME NOT NULL;
update anagrafica_movimenti set `data_inserimento` = now();