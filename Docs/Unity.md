[Home](../README.md)

---
### ♦ O Unity é importante?

Essa biblioteca é utilizada para realização da Injeção de Dependência no projeto e seus benefícios são: ([acesse o link para ver na integra](https://enlabsoftware.com/development/domain-driven-design-in-asp-net-core-applications.html)):

1. **Acoplamento fraco:** As partes do sistema irão interagir umas com as outras através das definições e princípios estabelecidos na camada Core (interfaces, classes abstratas, classes base, etc.). As implementações serão concluídas nas camadas restantes. A configuração da implementação será por meio de bibliotecas DI (Unity). Portanto, as equipes podem se desenvolver de forma independente ao mesmo tempo.

1. **Flexibilidade:** Os links soltos e as definições de alto nível permitem que a equipe aprimore e se adapte a novos requisitos funcionais de forma mais flexível, sem impacto considerável no sistema geral.

1. **Testabilidade:** Conforme mencionado acima, separando a implementação das interfaces definidas na camada Core, é permitido testar com dados simulados em um ambiente separado.

1. **Manutenção:** DDD divide claramente as funções entre camadas/camadas. Especificamente, o Domínio implementa a lógica de negócios, a Infraestrutura é responsável pela persistência dos dados e o Aplicativo lida com a API e a lógica de integração. Seguindo essa abordagem, você terá a chance de escrever códigos mais limpos e confiáveis. Além disso, sua equipe pode encontrar facilmente o código, limitar sua duplicação e reduzir o tempo de manutenção.
