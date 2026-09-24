<div align="center">

# 🔐 Cifra de César

### Criptografia e descriptografia de arquivos de texto

Projeto desenvolvido para a disciplina de **Segurança Computacional**  
do curso de **Ciência da Computação**.

<br>

![C#](https://img.shields.io/badge/C%23-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![.NET](https://img.shields.io/badge/.NET_10-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Windows Forms](https://img.shields.io/badge/Windows_Forms-0078D4?style=for-the-badge&logo=windows&logoColor=white)
![MSTest](https://img.shields.io/badge/MSTest-Testes-25A162?style=for-the-badge)

</div>

---

## 📖 Sobre o projeto

O **Cifra de César** é uma aplicação desktop para Windows que permite criptografar e descriptografar arquivos de texto utilizando o algoritmo clássico da Cifra de César.

Por meio de uma interface gráfica simples, o usuário pode selecionar um arquivo, informar uma chave numérica e escolher entre realizar a **criptografia** ou a **descriptografia** do conteúdo.

Os arquivos são processados utilizando codificação **UTF-8**, preservando caracteres que não fazem parte do alfabeto utilizado pela cifra.

---

## ✨ Funcionalidades

- 📂 Seleção de arquivos de texto pela interface gráfica
- 🔑 Definição da chave durante a execução
- 🔒 Criptografia utilizando a Cifra de César
- 🔓 Descriptografia utilizando a mesma chave
- 🔤 Preservação de letras maiúsculas e minúsculas
- 🌎 Preservação de caracteres Unicode e acentuados
- 📄 Leitura e gravação de arquivos UTF-8
- 📁 Geração automática dos arquivos de saída
- 🗂️ Abertura da pasta do arquivo gerado
- 🧪 Testes automatizados com MSTest

---

## 🛠️ Tecnologias utilizadas

| Tecnologia | Utilização |
|---|---|
| **C#** | Linguagem principal |
| **.NET 10** | Plataforma de desenvolvimento |
| **Windows Forms** | Interface gráfica |
| **MSTest** | Testes automatizados |
| **Git** | Controle de versão |

---

## 🏗️ Arquitetura

A solução foi organizada separando a interface gráfica das regras da aplicação e dos testes.

```text
Cifra-de-Cesar/
│
├── src/
│   │
│   ├── CifraDeCesar.Core/
│   │   ├── Arquivos/
│   │   │   └── ArquivoService.cs
│   │   │
│   │   └── Criptografia/
│   │       └── CifraCesar.cs
│   │
│   └── CifraDeCesar.WinForms/
│       ├── FormPrincipal.cs
│       ├── FormPrincipal.Designer.cs
│       └── Program.cs
│
├── tests/
│   └── CifraDeCesar.Tests/
│       ├── Arquivos/
│       │   └── ArquivoServiceTests.cs
│       │
│       └── Criptografia/
│           └── CifraCesarTests.cs
│
├── exemplos/
│   ├── exemplo.txt
│   ├── exemplo_cript.txt
│   └── exemplo_cript_descript.txt
│
├── CifraDeCesar.slnx
└── README.md
```

### 🧠 Core

O projeto `CifraDeCesar.Core` concentra as regras da aplicação.

Ele é responsável por:

- executar a Cifra de César;
- criptografar e descriptografar textos;
- ler arquivos;
- gravar arquivos;
- trabalhar com codificação UTF-8;
- gerar os caminhos dos arquivos de saída.

### 🖥️ WinForms

O projeto `CifraDeCesar.WinForms` contém a interface gráfica.

Ele é responsável por:

- selecionar o arquivo de entrada;
- receber a chave;
- iniciar a criptografia ou descriptografia;
- apresentar o resultado da operação;
- informar o caminho do arquivo criado;
- abrir a pasta do resultado;
- apresentar mensagens de erro ao usuário.

A interface não implementa diretamente o algoritmo de criptografia. Ela utiliza as funcionalidades disponíveis no projeto `Core`.

### 🧪 Tests

O projeto `CifraDeCesar.Tests` contém os testes automatizados das regras presentes no `Core`.

Isso permite verificar a criptografia e a manipulação dos arquivos independentemente da interface gráfica.

---

# 🔐 Como funciona a Cifra de César?

A **Cifra de César** é uma cifra de substituição na qual cada letra é deslocada uma determinada quantidade de posições no alfabeto.

Considere uma chave igual a `3`.

```text
Original:       A B C D E F ...
                ↓ ↓ ↓ ↓ ↓ ↓
Criptografado:  D E F G H I ...
```

Portanto:

```text
A → D
B → E
C → F
```

Quando o deslocamento ultrapassa o final do alfabeto, ele retorna ao início:

```text
X → A
Y → B
Z → C
```

### Exemplo

Entrada:

```text
ABCXYZ
```

Chave:

```text
3
```

Resultado:

```text
DEFABC
```

Para realizar a **descriptografia**, o deslocamento é realizado no sentido inverso utilizando a mesma chave.

---

## 🔄 Fluxo da aplicação

```text
┌─────────────────────────┐
│   Selecionar arquivo    │
└────────────┬────────────┘
             │
             ▼
┌─────────────────────────┐
│     Informar chave      │
└────────────┬────────────┘
             │
             ▼
┌─────────────────────────┐
│ Criptografar /          │
│ Descriptografar         │
└────────────┬────────────┘
             │
             ▼
┌─────────────────────────┐
│   Processar conteúdo    │
│     usando o Core       │
└────────────┬────────────┘
             │
             ▼
┌─────────────────────────┐
│ Gerar arquivo de saída  │
└─────────────────────────┘
```

---

## 🔤 Regras da implementação

O deslocamento da Cifra de César é aplicado somente às letras do alfabeto latino básico:

```text
A-Z
a-z
```

As letras mantêm sua capitalização.

Assim:

```text
A → D
```

e:

```text
a → d
```

utilizando chave `3`.

Caracteres que não pertencem a esses intervalos são preservados, incluindo:

- espaços;
- números;
- sinais de pontuação;
- símbolos;
- quebras de linha;
- caracteres acentuados.

### Exemplo

Com chave `3`:

```text
Olá, Mundo! 123
```

torna-se:

```text
Roá, Pxqgr! 123
```

Observe que `á`, a vírgula, o espaço, o ponto de exclamação e os números não são modificados.

---

## 🔑 Funcionamento da chave

A chave é informada pelo usuário diretamente na interface durante a execução.

O programa aceita:

```text
Chaves positivas
Chave zero
Chaves negativas
Chaves maiores que 26
```

Como existem 26 letras no alfabeto utilizado pela cifra, a chave é normalizada automaticamente.

Por exemplo:

```text
29 % 26 = 3
```

Portanto:

```text
Chave 29
```

produz o mesmo deslocamento de:

```text
Chave 3
```

---

## 🌎 Codificação UTF-8

A leitura e a gravação dos arquivos são realizadas explicitamente utilizando:

```text
UTF-8 sem BOM
```

Dessa forma, caracteres como:

```text
á  é  í  ó  ú  ã  õ  ç
```

são preservados corretamente.

Esses caracteres continuam presentes no arquivo, mas não são deslocados pela Cifra de César, pois o algoritmo implementado trabalha somente com `A-Z` e `a-z`.

---

## 📄 Arquivos de saída

### Criptografia

Ao selecionar:

```text
exemplo.txt
```

e realizar a criptografia, é criado:

```text
exemplo_cript.txt
```

### Descriptografia

Ao selecionar:

```text
exemplo_cript.txt
```

e realizar a descriptografia, é criado:

```text
exemplo_cript_descript.txt
```

O diretório e a extensão original são preservados.

Esse comportamento evita a substituição direta do arquivo utilizado como entrada.

---

## 🚀 Como executar

### Pré-requisitos

- Windows
- .NET 10 SDK

### 1. Restaurar as dependências

Na raiz do projeto:

```powershell
dotnet restore CifraDeCesar.slnx
```

### 2. Executar a aplicação

```powershell
dotnet run --project src/CifraDeCesar.WinForms
```

A interface gráfica será aberta.

### 3. Utilizar o programa

Na aplicação:

1. clique em **Selecionar arquivo...**;
2. escolha um arquivo de texto;
3. informe a chave;
4. clique em **Criptografar** ou **Descriptografar**;
5. confira o caminho do arquivo gerado;
6. utilize **Abrir pasta** para localizar o resultado.

---

## 📝 Arquivos de exemplo

A pasta `exemplos/` contém os arquivos utilizados na demonstração completa da aplicação.

| Arquivo | Descrição |
|---|---|
| `exemplo.txt` | Arquivo original utilizado como entrada |
| `exemplo_cript.txt` | Resultado da criptografia utilizando chave `3` |
| `exemplo_cript_descript.txt` | Resultado da descriptografia |

### Arquivo original

```text
Seguranca Computacional
Cifra de Cesar - Teste 123!

ABCDEFGHIJKLMNOPQRSTUVWXYZ
abcdefghijklmnopqrstuvwxyz

Texto com acentos: á é í ó ú ã õ ç.
A chave utilizada neste exemplo sera 3.
```
---

## 🧪 Testes automatizados

O projeto utiliza **MSTest** para verificar automaticamente o funcionamento das principais regras.

Para executar todos os testes:

```powershell
dotnet test CifraDeCesar.slnx
```

### Resultado atual

```text
29 testes executados
29 testes aprovados
0 testes com falha
```

### Cenários verificados

| Categoria | Exemplos de testes |
|---|---|
| 🔐 Criptografia | Maiúsculas, minúsculas e retorno circular |
| 🔓 Descriptografia | Recuperação do texto original |
| 🔑 Chaves | Zero, negativas, maiores que 26 e valores extremos |
| 🔤 Caracteres | Espaços, números, pontuação e Unicode |
| 📄 Arquivos | Criação, leitura e conteúdo |
| 📝 Nomes | `_cript`, `_descript` e múltiplos pontos |
| 🌎 UTF-8 | Preservação de caracteres acentuados |
| 🔄 Round-trip | Criptografar e descriptografar recupera o original |
| ⚠️ Validações | Caminhos inválidos e arquivos inexistentes |

---

## ✅ Validação funcional

Além dos testes automatizados, foi realizado um fluxo completo utilizando a própria aplicação:

```text
exemplo.txt
     │
     │ Criptografar
     │ Chave = 3
     ▼
exemplo_cript.txt
     │
     │ Descriptografar
     │ Chave = 3
     ▼
exemplo_cript_descript.txt
```

Ao final do processo, o conteúdo descriptografado corresponde ao conteúdo original.

---

## 🔒 Consideração de segurança

> [!IMPORTANT]
> A Cifra de César possui finalidade **didática e histórica** e não deve ser utilizada para proteger informações sensíveis em aplicações reais.

Como existem poucas possibilidades de chave e o padrão de substituição é simples, a cifra pode ser quebrada facilmente por técnicas como força bruta e análise de frequência.

Neste projeto, sua utilização tem como objetivo demonstrar conceitos introdutórios de **criptografia, cifragem e decifragem**.

---

<div align="center">

### Segurança Computacional

**Ciência da Computação**

Desenvolvido por Gustavo Tessaro como trabalho acadêmico sobre a **Cifra de César**.

</div>