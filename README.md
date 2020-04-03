Configuração Inicial: Para rodar o sistema é necessario ao abrir o projeto pela primeira vez definir o projeto TesteNavita.WebApi como projeto padrao. depois é necessario criar nossa Base no Banco de Dados. Para isso primeiro altere o arquivo appsettings.json que fica na raiz do projeto TesteNavita.WebApi, em ConnectionStrings->DefaultConnection, altere os dados para para as suas configurações. Após isso abra o console gerenciador de pacotes NuGet, defina o projeto padrao para TesteNavita.Repository e coloque o comando "update-database" conforme imagem abaixo e aguarde o base ser gerado automaticamente, depois disso você estará pronto utilizar a API.
 

O projeto foi desenvolvido utilizando o Asp Net Core na versão 2.2.0, tambem foi utilizado o Entity Framework Core na versão 2.2  e o Auto Mapper da Microsoft versão 4.0.1.

O sistema foi dividido em três camadas para dividir as responsabilidades e facilitar o entendimento da arquitetura do projeto. O projeto "TesteNavita.Domain" é responsável pelas nossas entidades e pelas nossas regras de negócios. O projeto "TesteNavita.Repository" é responsável pelas persistências no Banco de Dados. O projeto "TesteNavita.WebApi" é o nosso middleware, todas as nossas requisições começam aqui e terminam inicialmente aqui.

Para autenticação foi utilizado o Identity Framework da Microsoft, para gerar os Tokens foi utilizado o JWT. A configuração pode ser encontrado no arquivo Startup.cs do projeto TesteNavita.WebApi. As entidades utilizadas podem ser encontradas no projeto TesteNavita.Domain na pasta "Entity". Todas as rotas exigem autenticação, menos a "Register" e a "Login".

Rotas:

Rota user/Register do tipo Post, é responsável por registrar um novo usuário no sistema.

Rota user/Login do tipo Post, é responsável por autenticar um usuário no sistema, a sistema irá devolver um token que deve ser utilizado nas requisiçoes protegidas do sistema.

Rota user do tipo Get, é responsável listar todos os usuários do sistema.

Rota user/Delete/{id} do tipo Delete, é responsável por apagar novo usuário no sistema.

Rota marca do tipo Post, é responsável por registrar um nova marca no sistema.

Rota marca do tipo Get, é responsável por listar todas as marcas do sistema.

Rota marca/{id} do tipo Get, é responsável por listar uma marca pelo seu id.

Rota marca/{id} do tipo Put, é responsável por alterar uma marca no sistema.

Rota marca{id} do tipo Delete, é responsável por apagar uma marca no sistema.

Rota marca/{id}/patrimonios do tipo Get, é responsável por listar todos patrimonios de uma marca.

Rota patrimonio do tipo Post, é responsável por registrar um novo patrimonio.

Rota patrimonio do tipo Get, é responsável por listar todos os patrimonios.

Rota patrimonio/{id} do tipo get, é responsável por listar um patrimonio por id.

Rota patrimonio/{id} do tipo Delete, é responsável por apagar um patrimonio.











