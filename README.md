```markdown
# Projeto .NET 9 com Arquitetura Limpa e Padrão MVC

Este documento descreve um projeto desenvolvido em **.NET 9**, utilizando a **Arquitetura Limpa (Clean Architecture)** e o **padrão MVC (Model-View-Controller)**,
seguindo diversas boas práticas de desenvolvimento de software.

---

## **Objetivo do Projeto**
O objetivo do projeto foi criar uma aplicação escalável, de fácil manutenção e extensível, empregando as melhores práticas para garantir alta qualidade no código e
boa experiência para o usuário final.

---

## **Estrutura do Projeto**

### **1. Camadas da Arquitetura Limpa**
A aplicação foi dividida em camadas claramente separadas, promovendo independência e isolamento das responsabilidades:

- **Domain**:  
  Contém o núcleo da aplicação, como regras de negócio, entidades e interfaces. Essa camada é completamente independente de frameworks e bibliotecas externas.

- **Application**:  
  Contém os casos de uso, serviços e regras específicas de aplicação. Faz uso das interfaces definidas na camada **Domain**.

- **Infrastructure**:  
  Responsável pela implementação dos detalhes técnicos, como acesso a bancos de dados, APIs externas e injeção de dependência.

- **Presentation (WebUI)**:  
  Camada de interface com o usuário, implementada com o padrão **MVC**, conectando os dados da aplicação com as visualizações.

---

### **2. Boas Práticas Adotadas**

#### **2.1. Uso do Padrão MVC**
- Organização clara de **Modelos**, **Views** e **Controllers**, garantindo separação de responsabilidades.
- Controllers foram mantidos "magros" (thin controllers), delegando a maior parte da lógica para serviços na camada **Application**.

#### **2.2. Injeção de Dependência**
- Utilização do **Dependency Injection (DI)** nativo do .NET para gerenciar dependências entre as camadas.
- Todas as dependências foram injetadas, seguindo o princípio de inversão de dependência.

#### **2.3. Princípios SOLID**
- Código desenvolvido seguindo os princípios **SOLID**, promovendo alta coesão e baixo acoplamento.
- Interfaces foram criadas para abstrair implementações, garantindo flexibilidade e facilidade de substituição.

#### **2.4. Repositórios e Unit of Work**
- Padrão **Repository** para abstração do acesso ao banco de dados.
- Implementação do padrão **Unit of Work** para gerenciar transações.

#### **2.5. Testes Automatizados**
- Criação de testes unitários e de integração para garantir a qualidade do código e prevenir regressões.
- Uso de frameworks como **xUnit** e **Moq** para mockar dependências.

#### **2.6. Validações e Segurança**
- Validações centralizadas com uso de bibliotecas como **FluentValidation**.
- Implementação de **autenticação** e **autorização** utilizando o Identity do .NET.
- Proteção contra vulnerabilidades comuns como **SQL Injection** e **Cross-Site Scripting (XSS)**.

#### **2.7. Logging e Monitoramento**
- Uso da biblioteca **Serilog** para captura e armazenamento de logs.
- Integração com ferramentas de monitoramento como **Application Insights** para rastreamento de métricas e desempenho.

---

## **Benefícios da Arquitetura**

- **Escalabilidade**: O projeto pode crescer sem comprometer a estrutura ou desempenho.
- **Testabilidade**: A separação clara entre as camadas facilita a criação de testes automatizados.
- **Manutenibilidade**: A aplicação é fácil de entender e manter, graças à separação de responsabilidades.
- **Extensibilidade**: Novos recursos podem ser adicionados sem alterar significativamente as camadas existentes.

---

## **Tecnologias Utilizadas**
- **.NET 9**
- **Entity Framework Core** para acesso a dados
- **FluentValidation** para validação de regras de entrada
- **Serilog** para logging
- **xUnit** e **Moq** para testes automatizados
- **Bootstrap** para interface do usuário
- **SQL Server** como banco de dados principal

---

## **Considerações Finais**
Este projeto representa uma aplicação moderna e bem estruturada, aplicando a Arquitetura Limpa e o padrão MVC em conjunto com boas práticas de
desenvolvimento. O uso dessas técnicas garante uma aplicação robusta, eficiente e preparada para evoluir conforme as necessidades do negócio.

```
