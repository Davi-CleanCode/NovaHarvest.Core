# Nova Harvest — Core C#

Core independente do Unity para o protótipo. Sem `UnityEngine`, para permitir desenvolvimento/testes da lógica antes da integração visual.

## Já incluído
- Player e movimento sem energia/stamina
- Vida do jogador
- Mundo, objetos e coleta
- Inventário
- Crafting inicial
- Construção de canteiro
- Agricultura: plantar, regar, passar dia e colher
- Dia/noite: 04:30–19:29 dia; 19:30–04:29 noite
- Eventos noturnos
- NPCs, relacionamento e colônia
- Lyra, diálogo e quest inicial
- Progressão/desbloqueios
- `GameSession` para composição central e futura ponte com Unity

## Importante
Não há energia, fome ou sede nesta versão.

## Teste
Com .NET SDK instalado: `dotnet build` e `dotnet run --project Demo`.

## Unity
No Unity, a camada visual deve cuidar de sprites, Tilemap, input, câmera, UI, áudio, prefabs e cenas. O Core continua cuidando das regras do jogo.
# NovaHarvest.Core
