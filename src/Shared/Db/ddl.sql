DROP DATABASE IF EXISTS campuslove;
CREATE DATABASE campuslove;
USE campuslove;


CREATE TABLE usuario (
  id INT AUTO_INCREMENT PRIMARY KEY,
  nombre VARCHAR (100),
  usuarioEmail VARCHAR(100) UNIQUE,
  contrasena  VARCHAR (100),
  edad SMALLINT,
  genero VARCHAR (20),
  intereses TEXT,
  carrera VARCHAR (100),
  frase TEXT,
  meGusta INT,
  noMeGusta INT
);

CREATE TABLE historialInteraccion (
  id INT AUTO_INCREMENT PRIMARY KEY,
  tipoInteraccion ENUM("Like", "Dislike"),
  usuarioReceptorId INT,
  FOREIGN KEY (usuarioReceptorId) REFERENCES usuario(id)
);

CREATE TABLE matching(
  usuario1 INT,
  usuario2 INT,
  fechaDelMatch DATETIME,
  PRIMARY KEY (usuario1, usuario2),
  FOREIGN KEY (usuario1) REFERENCES usuario(id),
  FOREIGN KEY (usuario2) REFERENCES usuario(id)
);