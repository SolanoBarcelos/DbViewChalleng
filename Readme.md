1 - Crie uma tabela que permita cadastrar chapa de aço carbono com espessura.
```sql
CREATE TABLE IF NOT EXISTS chapa (
    pk_chapa_type serial PRIMARY KEY,
    chapa_type_name VARCHAR(100) NOT NULL,
	espessura decimal(10,2)
);

INSERT INTO chapa (chapa_type_name, espessura) VALUES 
('chapa de aço carbono 1', 1.00),
('chapa de aço carbono 2', 2.00),
('chapa de aço carbono 3', 3.00),
('chapa de aço carbono 4', 1.00),
('chapa de aço carbono 5', 1.00);
```

2 - Crie uma tabela que permita cadastrar estoque da chapa acima com largura e comprimento.
```sql
create table estoque(
  pk_chapa_espessura serial primary key,
  fk_pk_chapa_type int not null,
  largura decimal not null,
  comprimento DECIMAL not null
 );

ALTER TABLE estoque
ADD CONSTRAINT fk_chapa_tipo_ref
FOREIGN KEY (fk_pk_chapa_type) REFERENCES chapa (pk_chapa_type);

INSERT INTO estoque (fk_pk_chapa_type, largura, comprimento) VALUES 
(1, 100.00, 100.00), 
(2, 300.00, 300.00), 
(3, 400.00, 400.00),
(4, 500.00, 500.00), 
(5, 500.00, 500.00);
```

3 - Monte uma view que permita ler a descrição e o peso para cada espessura cadastrada, sabendo que o peso específico do aço carbono é 7.85 x 10-6 Kg/mm3.
```sql
create view v_descricao_peso as
select 
c.chapa_type_name,
(c.espessura * e.largura * e.comprimento * 0.00000785) as peso_espessura
from chapa c
join estoque e on c.pk_chapa_type = e.fk_pk_chapa_type
````

4 - API: Crie uma rota que leia a view acima.

API criada em C#, .Net, ASP.NET Core Web API, utilizando Dapper para acessar o banco de dados. 
Foram utilizados conceitos de Clean Architecture e DDD, também DIP e SRP do SOLID (na vida real, utilizaria os padrões da empresa).
Optei por utilizar padrão singleton como tempo de vida do Container de DI para DBcontext, pois a classe fornece apenas o método para criar conexão e não armazena dados vindos dos clients. Uma única instância global economiza memória. IDbConnection permanece ativo enquanto o tempo de vida do método Repository não acabar pelo uso de “using” que fecha a conexão.


5 - Crie uma tela que leia a rota acima.

Tela criada utilizando Blazor.
Backend faz um select na View do Banco > Transforma o resultado em Json > Expõe uma rota com Json > Frontend consome a rota com os dados Json.


Obs: 
- Utilize um banco de dados relacional da sua escolha (preferência para PostgreSQL). 

- Utilize a arquitetura que você se sentir mais confortável. 

- É obrigatório utilizar C# no back-end. 

- Utilize um front-end que você se sentir mais confortável (preferência para Blazor). 

- Os valores de espessura, largura e comprimento devem estar em mm 
