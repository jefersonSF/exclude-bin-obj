# BinObj Cleaner

Ferramenta de linha de comando para **excluir automaticamente as pastas `bin` e `obj`** de projetos .NET no Windows.

![.NET](https://img.shields.io/badge/.NET-8.0-purple)
![Platform](https://img.shields.io/badge/platform-Windows-blue)
![License](https://img.shields.io/badge/license-MIT-green)

---

## 📌 Objetivo

Ao ser executada, a ferramenta varre o diretório atual e todos os seus subdiretórios em busca de pastas `bin` e `obj` que estejam **no mesmo nível de um arquivo de projeto `.csproj`**, e as exclui.

Isso é útil para:

- Liberar espaço em disco após builds;
- Limpar artefatos antes de versionar ou compactar um projeto;
- Evitar conflitos ao copiar/mover soluções entre máquinas.

---

## ⚙️ Requisitos

- **Windows** (a ferramenta foi projetada para esse ambiente);
- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0) ou superior para compilar o código-fonte.

> **Nota:** SDKs 9/10 também compilam o target `net8.0`; versões 6/7 não são suportadas.

---

## 🚀 Como usar

### 1. Compile o executável

No diretório do projeto:

```bash
dotnet publish -c Release -r win-x64 --self-contained
```
### 2. Rode o executável

Rode o executável na pasta do projeto onde quer limpar as pastas bin e obj. Ex: 
```bash
PS D:\Projetos-tools\MonitorMobile> binobj.exe
```
Após termino da execução, todas as pastas **bin** e **obj** no diretório atual (D:\Projetos-tools\MonitorMobile) e subdiretórios, terão sido excluídas.

---
## 💡 Dicas de uso

Para facilitar o uso no dia a dia:

### Dica 1
1. **Gere o executável** com 
`dotnet publish`
:
   ```bash
   dotnet publish -c Release -r win-x64 --self-contained


2. **Crie um atalho** para o executável no local de sua preferência (Área de Trabalho, menu Iniciar, etc...).

3. (Opcional) Adicione a pasta do executável ao `PATH` para chamar a ferramenta de qualquer terminal.

   **Windows**: adicione o caminho em Variáveis de Ambiente → Path.

   **Linux/macOS**: adicione export PATH="$PATH:/caminho/para/a/pasta" ao ~/.bashrc ou ~/.zshrc
