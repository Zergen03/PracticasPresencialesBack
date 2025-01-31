
CREATE DATABASE QUESTIFYDB;
USE QUESTIFY;



CREATE TABLE USERS (
    ID INTEGER AUTO_INCREMENT PRIMARY KEY,
    NAME VARCHAR(255) NOT NULL,
    PASSWORD VARCHAR(255) NOT NULL,
    LIFE INTEGER NOT NULL,
    XP INTEGER NOT NULL,
    GOLD INTEGER NOT NULL
);

CREATE TABLE CATEGORIES (
    ID INTEGER AUTO_INCREMENT PRIMARY KEY,
    NAME VARCHAR(255) NOT NULL,
    USER_ID INTEGER NOT NULL,
    FOREIGN KEY (USER_ID) REFERENCES USERS(ID) 
);

CREATE TABLE ITEMS (
    ID INTEGER AUTO_INCREMENT PRIMARY KEY,
    TYPEOBJECT VARCHAR(255) NOT NULL,
    STATSOBJECT INTEGER NOT NULL,
    VALUEOBJECT INTEGER NOT NULL
);

CREATE TABLE TASKS (
    ID INTEGER AUTO_INCREMENT PRIMARY KEY,
    NAME VARCHAR(255) NOT NULL,
    DESCRIPTION TEXT NOT NULL,
    GOLDREWARD INTEGER NOT NULL,
    XPREWARD INTEGER NOT NULL,
    EXPIRATIONDATE DATETIME NOT NULL,
    DIFFICULTY INTEGER NOT NULL,
    CATEGORY_ID INTEGER NOT NULL,
    FOREIGN KEY (CATEGORY_ID) REFERENCES CATEGORIES(ID) 
);

CREATE TABLE USERITEMS (
    ID INTEGER AUTO_INCREMENT PRIMARY KEY,
    USER_ID INTEGER NOT NULL,
    ITEM_ID INTEGER NOT NULL,
    FOREIGN KEY (USER_ID) REFERENCES USERS(ID),
    FOREIGN KEY (ITEM_ID) REFERENCES ITEMS(ID) 
);

INSERT INTO USERS (NAME, PASSWORD, LIFE, XP, GOLD) VALUES
('Alice', 'password123', 100, 50, 200),
('Bob', 'securepass', 80, 120, 500),
('Charlie', 'mypassword', 90, 70, 300);

INSERT INTO CATEGORIES (NAME, USER_ID) VALUES
('Estudio', 1),
('Ejercicio', 1),
('Trabajo', 2),
('Hobbies', 3);

INSERT INTO ITEMS (TYPEOBJECT, STATSOBJECT, VALUEOBJECT) VALUES
('Espada de Madera', 5, 100),
('Poción de Vida', 20, 50),
('Escudo Ligero', 10, 150),
('Libro de Conocimientos', 15, 200);


INSERT INTO TASKS (NAME, DESCRIPTION, GOLDREWARD, XPREWARD, EXPIRATIONDATE, DIFFICULTY, CATEGORY_ID) VALUES
('Estudiar Matemáticas', 'Resolver 5 ejercicios de álgebra', 100, 50, '2025-02-05 23:59:59', 2, 1),
('Correr 5 km', 'Salir a correr por la mañana', 150, 75, '2025-02-07 08:00:00', 3, 2),
('Completar informe', 'Redactar el informe para el trabajo', 200, 100, '2025-02-10 18:00:00', 4, 3),
('Aprender a tocar guitarra', 'Practicar acordes básicos', 50, 30, '2025-02-15 20:00:00', 1, 4);

INSERT INTO USERITEMS (USER_ID, ITEM_ID) VALUES
(1, 1),  -- Alice tiene la Espada de Madera
(1, 2),  -- Alice tiene una Poción de Vida
(2, 3),  -- Bob tiene un Escudo Ligero
(3, 4);  -- Charlie tiene el Libro de Conocimientos


SELECT * FROM USERS;