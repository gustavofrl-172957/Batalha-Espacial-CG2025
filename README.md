# 🚀 Batalha Espacial (CG & RV 2025): Galaxy Defense

Trabalho prático final para a disciplina de **Computação Gráfica e Realidade Virtual (CG & RV)**, ministrada pelo Prof. Dr. Rafael Rieder.

## 🎮 Sobre o Jogo

**Space War 2025** é um *top-down shooter* espacial desenvolvido na engine Unity. O jogador assume o controle de uma nave de combate com a missão de defender o setor galáctico de uma invasão alienígena e campos de asteroides perigosos.

Diferente dos jogos de "nave" tradicionais verticais, aqui você possui liberdade total de rotação (360º) para mirar e pilotar, exigindo reflexos rápidos para gerenciar ameaças vindo de todas as direções enquanto corre contra o tempo.

![Banner do Jogo](https://private-user-images.githubusercontent.com/229839896/517923981-2219ac63-f373-4738-9887-c05bed20f586.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjM5NTIxODAsIm5iZiI6MTc2Mzk1MTg4MCwicGF0aCI6Ii8yMjk4Mzk4OTYvNTE3OTIzOTgxLTIyMTlhYzYzLWYzNzMtNDczOC05ODg3LWMwNWJlZDIwZjU4Ni5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMTI0JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTEyNFQwMjM4MDBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT05NTg0MGNkOTMxNTY2NjJkOTk0MWM4NTJhZjA4NWEwNzg0OTY5ZTNhODg0ODQzN2NiMmQ0YjE0NmZkOWZjZTVkJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.eGZnBlUs0pJXc5pz5o4M3773eCAo05CKei3m0_zurdw) 

---

## 🌟 Características Principais

* **🎯 Movimentação Omnidirecional:** Sistema de física onde a nave acelera com propulsores (WASD) e a mira é controlada independentemente pelo Mouse (360º).
* **⚙️ Sistema de Dificuldade Dinâmico:**
    * **Fácil:** Inimigos passivos.
    * **Médio:** Inimigos maiores revidam.
    * **Difícil:** Todos os inimigos atiram.
* **👾 Spawn:** Inimigos e asteroides surgem de pontos aleatórios e calculam rotas de interceptação ou descida.
* **👹 Batalha de Chefe (Boss):** Um desafio final que surge após abater uma quantidade específica de inimigos.
* **⏱️ Time Attack:** O jogador deve completar a missão antes que o tempo acabe.
* **🏆 Ranking Local:** Sistema de Highscore que salva o nome, pontuação e melhor tempo do piloto vencedor.

---

## 🕹️ Como Jogar

### Objetivo
Sobreviva ao campo de asteroides e naves inimigas. Abata os alvos para preencher o contador de alerta. Quando o **Chefe** aparecer, destrua-o antes que o tempo se esgote!

### Controles (PC)

| Tecla / Ação | Função |
| :--- | :--- |
| **W / A / S / D** | Movimentar a nave (física com inércia) |
| **Mouse** | Mirar (Gira a nave na direção do cursor) |
| **Botão Esq. Mouse** ou **Ctrl** | Disparar Lasers |
| **Interface** | Botões clicáveis para Menus e Restart |

---

## 🛠️ Mecânicas e Pontuação

* **Pontuação:**
    * 🪨 **Asteroide:** +10 Pontos (Giram e bloqueiam caminho)
    * 🛸 **Inimigo Pequeno:** +70 Pontos (Rápidos)
    * 🚀 **Inimigo Grande:** +100 Pontos (Resistentes)
    * 👹 **Boss Final:** +450 Pontos
* **Bônus de Tempo:** Concluir a fase rapidamente concede bônus de até **999 pontos**.
* **Game Over:** Acontece se a vida da nave chegar a 0 ou se o Cronômetro zerar.

---

## 📦 Assets e Créditos

Este projeto utilizou recursos visuais e sonoros de terceiros, respeitando suas licenças de uso:

* **Sprites (Nave, Inimigos, UI):** [Kenney Space Shooter Redux](https://kenney.nl/assets/space-shooter-redux)
* **Skybox (Fundo):** [Milky Way Skybox](https://assetstore.unity.com/packages/2d/textures-materials/milky-way-skybox-94001)
* **Efeitos Visuais (Explosões):** [2D Pixel Spaceships (Unity Asset Store)](https://assetstore.unity.com/packages/2d/characters/2d-pixel-spaceships-2-small-ships-explosions-133395)
* **Áudio (Ambiente):** [Spaceship Ambience (Pixabay)](https://pixabay.com/pt/sound-effects/spaceship-ambience-with-effects-21420/)

---

## 👥 Integrantes do Grupo

* **Gustavo Fernandes R. de Lima (Matrícula: 172957)**
* **Murilo Pelisser Burato (Matrícula: 178331)**
* **Grégori Roberto do Nascimento de Mattos (Matrícula: 172954)**

---
*Universidade de Passo Fundo - 2025*