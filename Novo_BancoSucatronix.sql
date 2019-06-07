DROP USER IF EXISTS 'sucatronix'@'%';
DROP DATABASE IF EXISTS sucatronix;

CREATE DATABASE IF NOT EXISTS sucatronix;
USE sucatronix;
CREATE USER 'sucatronix'@'%';
ALTER USER 'sucatronix'@'%' IDENTIFIED BY 'sucatronix';
GRANT Delete ON sucatronix.* TO 'sucatronix'@'%';
GRANT Insert ON sucatronix.* TO 'sucatronix'@'%';
GRANT Select ON sucatronix.* TO 'sucatronix'@'%';
GRANT Update ON sucatronix.* TO 'sucatronix'@'%';
GRANT Execute ON sucatronix.* TO 'sucatronix'@'%';
FLUSH PRIVILEGES;

CREATE TABLE Funcionario (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(128) NOT NULL,
	cpf CHAR(14) NOT NULL UNIQUE,
	rg CHAR(12) NOT NULL UNIQUE,
	email VARCHAR(64) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	dataNascimento DATE NOT NULL,
	cep CHAR(9) NOT NULL,
	rua VARCHAR(64) NOT NULL,
	numero VARCHAR(6) NOT NULL,
	complemento VARCHAR(128) NOT NULL,
	bairro VARCHAR(64) NOT NULL,
	senha VARCHAR(128) NOT NULL,
	tipo VARCHAR(16) NOT NULL
);
INSERT INTO Funcionario VALUES
(1, "Administrador", "720.542.070-98", "44.026.079-6", "admin@sucatronix.com", "(19) 1234-5678", "2019-06-06", "13330-000", "Rua Um", "2", "", "Bairro Três", "$argon2id$v=19$m=1024,t=1,p=1$c29tZXNhbHQ$BUVc7fijcn0i4/qxrguoMdRItWvprNMavOS3EQ2Lcms", "ADMINISTRADOR"),
(2, "Gerente", "860.932.800-71", "17.850.589-4", "gerente@sucatronix.com", "(19) 1234-5678", "2019-06-06", "13330-000", "Rua Um", "2", "", "Bairro Três", "$argon2id$v=19$m=1024,t=1,p=1$c29tZXNhbHQ$wFlUcZ1kKrGMTWXO8P+x5S73Xfhf07H0wsHBTuTFvvs", "GESTOR"),
(3, "Vendedor", "869.610.750-02", "15.126.828-9", "vendedor@sucatronix.com", "(19) 1234-5678", "2019-06-06", "13330-000", "Rua Um", "2", "", "Bairro Três", "$argon2id$v=19$m=1024,t=1,p=1$c29tZXNhbHQ$zREdkIBoIUB+GEr0VFUH3ZSk+bHpMvnICGVhWKkUE9k", "VENDEDOR"),
(4, "Técnico", "684.797.770-10", "33.114.113-9", "tecnico@sucatronix.com", "(19) 1234-5678", "2019-06-06", "13330-000", "Rua Um", "2", "", "Bairro Três", "$argon2id$v=19$m=1024,t=1,p=1$c29tZXNhbHQ$cShusbZt047FmuZCo6/A24OxPce2frHy3qf154I8U+E", "TÉCNICO"),
(5, "Almoxarifado", "660.510.190-14", "25.381.208-2", "almoxarifado@sucatronix.com", "(19) 1234-5678", "2019-06-06", "13330-000", "Rua Um", "2", "", "Bairro Três", "$argon2id$v=19$m=1024,t=1,p=1$c29tZXNhbHQ$AXdZKtuJJjFNKA8K1Z2q5UUsSQhz0U+5qrbuHXK1N24", "ALMOXARIFADO"),
(6, "Superuser", "", "", "super@sucatronix.com", "(19) 1234-5678", "2019-06-06", "13330-000", "Rua Um", "2", "", "Bairro Três", "$argon2d$v=19$m=1024,t=1,p=1$c29tZXNhbHQ$pCHSywNQtybhSsAshuRFlkKOQVjNQU3R/0MBWZgxZss", "SUPERUSER");

CREATE TABLE Fornecedor (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(64) NOT NULL,
	email VARCHAR(64) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	cep CHAR(9) NOT NULL,
	rua VARCHAR(64) NOT NULL,
	numero VARCHAR(6) NOT NULL,
	complemento VARCHAR(128) NOT NULL,
	bairro VARCHAR(64) NOT NULL
);

CREATE TABLE Cliente (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(64) NOT NULL,
	email VARCHAR(64) NOT NULL,
	telefone VARCHAR(15) NOT NULL,
	cep CHAR(9) NOT NULL,
	rua VARCHAR(64) NOT NULL,
	numero VARCHAR(6) NOT NULL,
	complemento VARCHAR(128) NOT NULL,
	bairro VARCHAR(64) NOT NULL
);

CREATE TABLE Produto (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	nome VARCHAR(64) NOT NULL,
	estoqueAtual DOUBLE(8, 2) NOT NULL,
	preco DOUBLE(8, 2) NOT NULL
);

CREATE TABLE Pedido (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	funcionario INT NOT NULL,
	fornecedor INT NOT NULL,
	`data` DATE NOT NULL,
	situacao VARCHAR(32) NOT NULL,
	FOREIGN KEY(fornecedor) REFERENCES Fornecedor(id),
	FOREIGN KEY(funcionario) REFERENCES Funcionario(id)
);

CREATE TABLE Produto_Pedido (
	produto INT NOT NULL,
	quantidade DOUBLE(8, 2) NOT NULL,
	pedido INT NOT NULL,
	PRIMARY KEY(produto, pedido),
	FOREIGN KEY(produto) REFERENCES Produto(id),
	FOREIGN KEY(pedido) REFERENCES Pedido(id)
);

CREATE TABLE Venda (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	cliente INT NOT NULL,
	`data` DATE NOT NULL,
	funcionario INT NOT NULL,
	situacao VARCHAR(32) NOT NULL,
	FOREIGN KEY(cliente) REFERENCES Cliente(id),
	FOREIGN KEY(funcionario) REFERENCES Funcionario(id)
);

CREATE TABLE Produto_Venda (
	produto INT NOT NULL,
	quantidade DOUBLE(8, 2) NOT NULL,
	venda INT NOT NULL,
	PRIMARY KEY(produto, venda),
	FOREIGN KEY(produto) REFERENCES Produto(id),
	FOREIGN KEY(venda) REFERENCES Venda(id)
);

CREATE TABLE Solicitacao (
	id INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
	funcionario INT NOT NULL,
	`data` DATE NOT NULL,
	situacao VARCHAR(32) NOT NULL,
	FOREIGN KEY(funcionario) REFERENCES Funcionario(id)
);

CREATE TABLE Produto_Solicitacao (
	produto INT NOT NULL,
	quantidade DOUBLE(8, 2) NOT NULL,
	solicitacao INT NOT NULL,
	PRIMARY KEY(produto, solicitacao),
	FOREIGN KEY(produto) REFERENCES Produto(id),
	FOREIGN KEY(solicitacao) REFERENCES Solicitacao(id)
);