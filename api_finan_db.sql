DROP DATABASE IF EXISTS api_finan_db;
CREATE DATABASE api_finan_db;
USE api_finan_db;

CREATE TABLE categorias (
	id int not null auto_increment,
    descricao varchar(300) not null,
    
    primary key(id)
);

CREATE TABLE despesas (
    id INT NOT NULL AUTO_INCREMENT,
    descricao VARCHAR(300) NOT NULL,
    categoria_id INT NOT NULL,
    valor DECIMAL(10,2) NOT NULL,
    data_vencimento DATE NOT NULL,
    data_pagamento DATETIME NULL,
    situacao VARCHAR(50),
    
    PRIMARY KEY (id),
    
    CONSTRAINT fk_despesas_categoria  FOREIGN KEY (categoria_id) REFERENCES categorias(id)
);

INSERT INTO categorias (descricao) VALUES
('Folha de Pagamento'),
('Infraestrutura'),
('Serviços'),
('Fornecedores'),
('Impostos'),
('Tecnologia'),
('Logística'),
('Marketing'),
('Manutenção'),
('Administrativo');

INSERT INTO despesas 
(descricao, categoria_id, valor, data_vencimento, data_pagamento, situacao)
VALUES
('Salários Funcionários - Abril', 1, 25000.00, '2026-04-05', '2026-04-05 08:00:00', 'Pago'),
('Conta de Energia Escritório', 2, 1350.80, '2026-04-10', NULL, 'Pendente'),
('Serviço de Limpeza', 3, 900.00, '2026-04-12', '2026-04-12 15:00:00', 'Pago'),
('Compra de Matéria-Prima', 4, 7800.50, '2026-04-15', NULL, 'Pendente'),
('Pagamento de ICMS', 5, 4200.00, '2026-04-20', NULL, 'Pendente'),
('Licença Software ERP', 6, 1600.00, '2026-04-18', '2026-04-18 09:45:00', 'Pago'),
('Frete de Produtos', 7, 1100.00, '2026-04-14', '2026-04-14 11:30:00', 'Pago'),
('Campanha Facebook Ads', 8, 950.00, '2026-04-22', NULL, 'Pendente'),
('Manutenção de Ar Condicionado', 9, 650.00, '2026-04-16', NULL, 'Pendente'),
('Material de Escritório', 10, 320.75, '2026-04-08', '2026-04-08 10:10:00', 'Pago');

SELECT * FROM despesas;


create table tags(
id int not null auto_increment primary key,
nome varchar(100) not null
);

insert into tags (nome) values ('Locação'), ('Salario'), ('custo operacional'),
('investimento');


create table despesas_tags (
despesa_id int not null,
tag_id int not null,
primary key (despesa_id, tag_id),
foreign key (despesa_id) references despesas(id),
foreign key (tag_id) references tags(id)
);

insert into despesas_tags (despesa_id, tag_id) values (1,2), (2,1),
(3,3), (1,3), (4,4);





