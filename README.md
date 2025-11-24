# 🚀 Space War 2025: Galactic Defense

Trabalho prático final para a disciplina de **Computação Gráfica e Realidade Virtual (CG & RV)**, ministrada pelo Prof. Dr. Rafael Rieder.

## 🎮 Sobre o Jogo

**Space War 2025** é um *top-down shooter* espacial desenvolvido na engine Unity. O jogador pilota uma nave em uma missão perigosa através de um campo de asteroides e naves inimigas, onde a progressão e dificuldade se adaptam às suas escolhas.

O movimento da nave é **omnidirecional (360º)**, sendo a rotação controlada pelo mouse e a propulsão/aceleração controlada pelo teclado, cumprindo o requisito de manipulação de câmera análoga.

![Banner do Jogo](https://private-user-images.githubusercontent.com/229839896/517923981-2219ac63-f373-4738-9887-c05bed20f586.png?jwt=eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJpc3MiOiJnaXRodWIuY29tIiwiYXVkIjoicmF3LmdpdGh1YnVzZXJjb250ZW50LmNvbSIsImtleSI6ImtleTUiLCJleHAiOjE3NjM5NTIxODAsIm5iZiI6MTc2Mzk1MTg4MCwicGF0aCI6Ii8yMjk4Mzk4OTYvNTE3OTIzOTgxLTIyMTlhYzYzLWYzNzMtNDczOC05ODg3LWMwNWJlZDIwZjU4Ni5wbmc_WC1BbXotQWxnb3JpdGhtPUFXUzQtSE1BQy1TSEEyNTYmWC1BbXotQ3JlZGVudGlhbD1BS0lBVkNPRFlMU0E1M1BRSzRaQSUyRjIwMjUxMTI0JTJGdXMtZWFzdC0xJTJGczMlMkZhd3M0X3JlcXVlc3QmWC1BbXotRGF0ZT0yMDI1MTEyNFQwMjM4MDBaJlgtQW16LUV4cGlyZXM9MzAwJlgtQW16LVNpZ25hdHVyZT05NTg0MGNkOTMxNTY2NjJkOTk0MWM4NTJhZjA4NWEwNzg0OTY5ZTNhODg0ODQzN2NiMmQ0YjE0NmZkOWZjZTVkJlgtQW16LVNpZ25lZEhlYWRlcnM9aG9zdCJ9.eGZnBlUs0pJXc5pz5o4M3773eCAo05CKei3m0_zurdw)

---

## 🌟 Características Principais

* **🎯 Movimentação 360º e Aceleração:** Controle preciso da nave com aceleração e mira independente do mouse.
* **⚙️ Sistema de Dificuldade Dinâmico:** HP, dano e velocidade dos inimigos são escalados pela Dificuldade (Fácil/Médio/Difícil) e pela Fase (1, 2 ou 3).
* **👾 Disparo Adaptativo:** Inimigos disparam em dificuldades mais altas (Médio: Grandes atiram; Difícil: Todos atiram).
* **👹 Batalha de Chefe (Boss):** O Boss surge após o abate de 7+ inimigos e sua derrota garante a vitória.
* **⏱️ Time Limit (5 Minutos):** A missão deve ser completada antes de 300 segundos.
* **🏆 Ranking Local:** Highscore que salva nome, pontuação e melhor tempo (com regra de desempate).

---

## 🕹️ Mecânicas e Pontuação

### Tempo Máximo
O tempo de jogo é fixado em **5 minutos (300 segundos)**.

### Controles (PC)

| Tecla / Ação | Função |
| :--- | :--- |
| **W / A / S / D** | Movimentar a nave (física com inércia) |
| **Mouse** | Mirar (Gira a nave na direção do cursor) |
| **Botão Esq. Mouse** ou **Ctrl** | Disparar Lasers |
| **Interface** | Botões clicáveis para Menus e Restart |

---

### Pontuação
A pontuação final é calculada com base nos abates e recebe um **Bônus de Tempo** conforme o requisito (999, 667 ou 333 pontos).

| Alvo Destruído | Pontuação Base |
| :--- | :--- |
| 🪨 **Asteroide** | **+10** Pontos |
| 🛸 **Inimigo Pequeno** | **+70** Pontos |
| 🚀 **Inimigo Grande** | **+100** Pontos |
| 👹 **Boss Final** | **+450** Pontos |

### Condições de Derrota
* A vida da nave chegar a zero.
* O Cronômetro de 5 minutos zerar.

---

## 📦 Assets e Créditos

* **Sprites (Nave, Inimigos, UI):** [Kenney Space Shooter Redux](https://kenney.nl/assets/space-shooter-redux)
* **Efeitos Visuais (Explosões):** [2D Pixel Spaceships (Unity Asset Store)](https://assetstore.unity.com/packages/2d/characters/2d-pixel-spaceships-2-small-ships-explosions-133395)
* **Áudio (Ambiente):** [Spaceship Ambience (Pixabay)](https://pixabay.com/pt/sound-effects/spaceship-ambience-with-effects-21420/)
* **Skybox (Fundo):** [Milky Way Skybox](https://assetstore.unity.com/packages/2d/textures-materials/milky-way-skybox-94001)

---

## 📦 Assets e Créditos

* **Executável do Projeto:** [Kenney Space Shooter Redux](https://drive.google.com/file/d/1ADqgyMC8vlYc4QndCAkpsuWyTKKzeU76/view?usp=sharing)
* **Vídeo Demonstrativo:** [Clique aqui](link.com.br)

---

## 👥 Integrantes do Grupo

* **Gustavo Fernandes R. de Lima (Matrícula: 172957)**
* **Murilo Pelisser Burato (Matrícula: 178331)**
* **Grégori Roberto do Nascimento de Mattos (Matrícula: 172954)**

---
*Universidade de Passo Fundo - 2025*