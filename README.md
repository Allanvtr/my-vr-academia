# My VR Academia

Aplicação de realidade virtual para treinar apresentações acadêmicas. O usuário envia os slides em PDF pelo app mobile, e o backend usa um LLM para gerar perguntas sobre o conteúdo, convertidas depois em áudio. Na cena em RV (Google Cardboard), uma plateia virtual faz essas perguntas durante a apresentação.

Projeto de Iniciação Científica desenvolvido no ICMC-USP com apoio da FAPESP.

## Arquitetura

| Pasta | Tecnologia | Função |
|---|---|---|
| `backend/` | ASP.NET Core (.NET 10) | Recebe o PDF, extrai o texto, gera as perguntas (Groq) e os áudios (Azure Speech). Notifica os clientes via SignalR em `/sceneHub`. |
| `mobile/` | React Native 0.84 | Tela de configuração da sessão. Envia o PDF para `POST /Scene/start` e abre o app da Unity por um Intent do Android. |
| `unity/` | Unity 2022.3 + Cardboard XR | Cena de RV. Lê os parâmetros do Intent, conecta ao SignalR e reproduz as perguntas em áudio. |

O fluxo completo funciona **apenas em Android**: o app mobile abre o app da Unity pelo pacote `com.DefaultCompany.my_vr_academia`, então os dois precisam estar instalados no mesmo celular.

## Pré-requisitos

- [Git LFS](https://git-lfs.com/) — modelos 3D, imagens e áudios do repositório são armazenados com LFS.
- [.NET SDK 10](https://dotnet.microsoft.com/download)
- Node.js 22.11 ou superior, JDK 17 e Android SDK 36 com NDK 27.1.12297006. O guia [Set Up Your Environment](https://reactnative.dev/docs/set-up-your-environment) do React Native cobre essa instalação.
- Unity **2022.3.62f2**, instalada pelo Unity Hub com o módulo **Android Build Support** (inclua OpenJDK e Android SDK & NDK Tools).
- [ngrok](https://ngrok.com/) ou outro túnel HTTPS, para que o celular alcance o backend.
- Credenciais de serviços externos: uma chave da [API da Groq](https://console.groq.com/keys) e um recurso [Azure AI Speech](https://portal.azure.com/) (chave e região).
- Um celular Android com depuração USB ativada e, para a experiência imersiva, um visor Cardboard.

## 1. Clonar o repositório

Instale o Git LFS **antes** de clonar. Sem ele, os arquivos grandes chegam como ponteiros de texto e a cena da Unity abre sem os modelos.

```sh
git lfs install
git clone https://github.com/Allanvtr/my-vr-academia.git
cd my-vr-academia
```

Se você já clonou sem o LFS, rode `git lfs pull` dentro do repositório.

## 2. Backend

Crie o arquivo de variáveis de ambiente a partir do modelo e preencha suas credenciais:

```sh
cd backend/src/VrAudioCena.WebApi
cp .env.example .env
```

| Variável | Descrição |
|---|---|
| `GROQ_API_KEY` | Chave da API da Groq |
| `MODEL` | Modelo da Groq usado para gerar as perguntas (padrão: `llama-3.3-70b-versatile`) |
| `AZURE_SPEECH_KEY` | Chave do recurso Azure AI Speech |
| `AZURE_SPEECH_REGION` | Região do recurso (ex.: `brazilsouth`) |

Execute o backend **de dentro da pasta do projeto**. O `.env` e a pasta de áudios (`wwwroot/audio`) são resolvidos a partir do diretório atual, então rodar com `dotnet run --project` a partir de outra pasta não funciona.

```sh
dotnet run --launch-profile http
```

O backend sobe em `http://localhost:5116`.

## 3. Expor o backend para o celular

Em outro terminal:

```sh
ngrok http 5116
```

O ngrok mostra uma URL pública HTTPS (por exemplo `https://seu-subdominio.ngrok-free.app`). Se você tiver um domínio estático gratuito do ngrok, use `ngrok http --url=SEU_DOMINIO 5116` para que a URL não mude entre execuções.

Atualmente a URL do backend está fixa no código. Substitua a URL existente pela sua nos três arquivos abaixo **antes** de gerar os apps:

- `mobile/src/services/api.tsx` (`baseURL`)
- `unity/Assets/Scripts/Network/ApiClient.cs` (`BaseUrl`)
- `unity/Assets/Scripts/Network/SignalRService.cs` (URL do `/sceneHub`)

Se a URL mudar depois, os dois apps precisam ser gerados de novo.

## 4. App de RV (Unity)

1. No Unity Hub, adicione a pasta `unity/` e abra com a versão 2022.3.62f2. A primeira abertura demora, porque a Unity recria a pasta `Library`.
2. Em **File > Build Settings**, selecione **Android** e clique em **Switch Platform**. A cena `Assets/Scenes/SampleScene.unity` já está marcada para o build.
3. Conecte o celular por USB e clique em **Build And Run** (ou gere o APK com **Build** e instale manualmente).

O plugin Cardboard XR está incluído em `unity/Dependencies/` e os pacotes NuGet do cliente SignalR já estão em `unity/Assets/Packages/`, então não é preciso baixar dependências adicionais.

## 5. App mobile (React Native)

Com o celular conectado e o app da Unity já instalado:

```sh
cd mobile
npm install
npm start
```

Em outro terminal, na mesma pasta:

```sh
npm run android
```

## 6. Uso

1. Deixe o backend e o túnel do ngrok rodando.
2. No app mobile, escolha o cenário e configure a sessão, como o tamanho do público e a duração.
3. Envie o PDF da apresentação. O app envia o arquivo ao backend e abre a cena em RV.
4. Coloque o celular no visor Cardboard. As perguntas em áudio são reproduzidas pela plateia virtual quando ficam prontas.
