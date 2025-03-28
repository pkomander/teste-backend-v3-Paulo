# Teste Backend

Foi apresentado como ponto inicial do projeto a refatoração para incluir o gênero de History e aplicar o calculo de creditos para nova categoria.
Como um dos pontos foi solicitado que seja escalavel pois futuramente podera ter novas implementações com outros gêneros necessitando ser de facil implementação.

## Projeto

A refatoração do projeto foi no sentido de ser criado uma API capaz de receber os parametros Play, Performance, Invoice, e ser possivel salvar e buscar as informações no banco implementando os metodos Post e Get para essas funções.
O projeto foi dividido no modelo de camadas (Aiko.Domain, Aiko.Dto, AIKO.Repository, Aiko.API).

### Domain
Responsavel pela representação das classes do banco de dados (Play, Performance, Invoice).

### Dto
Responsavel pela abstracao das classes do banco.


