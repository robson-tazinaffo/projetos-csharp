create database db_agenda;

use db_agenda;

CREATE TABLE IF NOT EXISTS contato (
  id INT NOT NULL AUTO_INCREMENT,
  nome varchar(150),
  email VARCHAR(150),
  telefone varchar(20),
  PRIMARY KEY (id))
ENGINE = InnoDB;