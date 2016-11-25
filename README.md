# MyMeds-DotNet
## Gerenciamento de Medicamentos Pessoais (CRUD) - Utilizando .Net

###Aplicação web divida em:

#### 4 layers:
* Camada de apresentação
* Camada de serviços
* Camada de processamento de regras
* Camada de acesso a dados
 
#### 3 tiers:
* Servidor web
* Servidor da camada de serviços e core da aplicação
* Servidor de banco de dados

## Negócio:

### **Medicamento**:
* número do registro
* número do processo
* classe terapêutica *(Ex: PRODUTO P.TERAPIA SINTOMATICA DA GRIPE)*
* nome comercial *(Ex: ACIDO ASCORBICO + PARACETAMOL + CLORIDRATO DE FENILEFRINA)*
* apresentação *(Ex: 100 MG + 400 MG + 10 MG COM CT 5 STRIP X 4)*
* forma farmacêutica *(Ex: COMPRIMIDO SIMPLES)*

### **Empresa (Medicamento)**:
* cnpj
* nome

### **Tratamento**:
* código
* data da prescrição
* diagnóstico

### **Item do Tratamento**: 
* código
* dosagem *(Ex: 8 mL)*
* descrição
* intervalo de tempo *(Ex: 8 em 8h)*
* período de tempo *(Ex: 15 dias)*

### Informações do **usuário**:
* cpf ou cnpj
* nome ou razão social
* telefone
* e-mail

## Tecnologias

### Bibliotecas
* Entity Framework
* ASP.NET MVC
* WCF
* SignalR

### Front-end
* Single Page Application utilizando apenas HTML5 e CSS3
* Javascript puro / JQuery (e plugins)
* AngularJS 1.x e Angular Material Design

### Mobile ( iOS e Android )
* À definir
