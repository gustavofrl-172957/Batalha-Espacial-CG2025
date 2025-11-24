# 🚀 Space War 2025: Galactic Defense

Trabalho prático final para a disciplina de **Computação Gráfica e Realidade Virtual (CG & RV)**, ministrada pelo Prof. Dr. Rafael Rieder.

## 🎮 Sobre o Jogo

**Space War 2025** é um *top-down shooter* espacial desenvolvido na engine Unity.  
O jogador pilota uma nave em uma missão perigosa através de um campo de asteroides e naves inimigas, onde a **dificuldade e a progressão escalam por Fase e Dificuldade escolhidas**.

O movimento da nave é **omnidirecional (360º)**, sendo a rotação controlada pelo mouse e a propulsão/aceleração controlada pelo teclado, cumprindo o requisito de manipulação de câmera análoga.

![Banner do Jogo](https://github.com/user-attachments/assets/84a9d7b7-9aeb-40f8-a441-1531d0e005c5)

---

## 🌟 Características Principais

* **🎯 Movimentação 360º com Física:** Controle da nave com aceleração, inércia e mira independente do mouse.
* **⚙️ Sistema de Dificuldade Dinâmico (Fácil / Médio / Difícil):**
  - HP, dano e quantidade de inimigos são escalados pela dificuldade.
  - O jogo também escala pela **Fase (1, 2 ou 3)**.
* **👾 Disparo dos Inimigos baseado na Dificuldade:**
  - **Fácil:** Inimigos não atiram.
  - **Médio:** Apenas inimigos grandes disparam.
  - **Difícil:** Todos os inimigos (pequenos e grandes) atiram, com cadência maior.
* **💥 Dano do Player por Dificuldade:**
  - Fácil/Médio: dano base do tiro.
  - Difícil: dano do tiro é levemente aumentado para compensar a pressão extra.
* **👹 Batalha de Chefe (Boss):**
  - O Boss surge após um certo número de inimigos abatidos, que varia por fase.
  - A derrota do Boss garante a vitória da missão.
* **📈 Progressão por Fase:**
  - A cada fase, inimigos ficam mais resistentes e surgem em maior quantidade.
* **⏱️ Time Limit (5 Minutos):**
  - A missão deve ser completada antes de **300 segundos**.
* **🏆 Ranking Local por Fase e Dificuldade:**
  - Salva **nome, pontuação, tempo, fase e dificuldade**.
  - Empates são desempattados pelo **menor tempo**.

---

## 🕹️ Mecânicas em Detalhe

### Tempo Máximo
O tempo de jogo é fixado em **5 minutos (300 segundos)** para todas as fases e dificuldades.

### Controles (PC)

| Tecla / Ação                     | Função                                           |
| :------------------------------- | :----------------------------------------------- |
| **W / A / S / D**                | Movimentar a nave (movimento com inércia)       |
| **Mouse**                        | Mirar (gira a nave na direção do cursor)        |
| **Botão Esquerdo do Mouse / Ctrl** | Disparar lasers                               |
| **Interface (UI)**              | Botões clicáveis para Navegar Menus e Restart   |

---

## ⚙️ Escalonamento de Dificuldade e Fase

### Dificuldades

- **Fácil**
  - Inimigos com **menos HP**.
  - Jogador toma **menos dano**.
  - **Menos inimigos em tela** (spawn mais lento).
  - Tiros inimigos **desativados**.
- **Médio**
  - HP e dano balanceados.
  - Apenas **inimigos grandes** disparam.
  - Taxa de spawn padrão.
- **Difícil**
  - Inimigos com **mais HP**.
  - Jogador toma **mais dano**.
  - **Mais inimigos em tela** (spawn mais rápido).
  - **Todos os inimigos** (pequenos e grandes) disparam.
  - Dano do player é levemente aumentado para manter o jogo desafiador, porém justo.

### Fases (1, 2 e 3)

A Fase selecionada afeta:

- **HP dos Inimigos:** aumenta progressivamente a cada fase.
- **Quantidade de inimigos necessários para chamar o Boss:**

| Fase | Inimigos até o Boss | Observação                 |
| :--- | :------------------ | :------------------------- |
| **1** | 7 inimigos         | Valor base configurado     |
| **2** | 9 inimigos         | Base + 2                   |
| **3** | 11 inimigos        | Base + 4                   |

O tempo permanece **300s** em todas as fases; o que muda é a quantidade e resistência dos inimigos.

---

## 🧮 Pontuação

A pontuação final considera **abates + bônus de tempo** (seguindo as regras de 999, 667 ou 333 pontos de bônus, conforme o tempo restante).

### Pontos por Inimigo

| Alvo Destruído           | Pontuação Base |
| :----------------------- | :------------- |
| 🪨 **Asteroide**         | **+10**        |
| 🛸 **Inimigo Pequeno**   | **+70**        |
| 🚀 **Inimigo Grande**    | **+100**       |
| 👹 **Boss Final**        | **+450**       |

### Condições de Vitória

- Derrotar o **Boss** antes do tempo acabar.

### Condições de Derrota

- A vida da nave chegar a **zero**.
- O cronômetro de **5 minutos** zerar.

---

## 🏆 Sistema de Ranking

O jogo mantém um **Ranking Local (Top 5)**:

Para cada entrada são salvos:

- **Nome do jogador**
- **Pontuação**
- **Tempo da run**
- **Fase (L1, L2, L3)**
- **Dificuldade (F, M, D)**

Critérios de ordenação:

1. Maior **pontuação**.
2. Em caso de empate, **menor tempo**.

O ranking aparece no menu principal como:

`1. NOME - 12.345 Pts | 123.45s (L2-D)`

---

## 📦 Assets e Créditos

* **Sprites (Nave, Inimigos, UI):** [Kenney Space Shooter Redux](https://kenney.nl/assets/space-shooter-redux)
* **Efeitos Visuais (Explosões):** [2D Pixel Spaceships (Unity Asset Store)](https://assetstore.unity.com/packages/2d/characters/2d-pixel-spaceships-2-small-ships-explosions-133395)
* **Áudio (Ambiente):** [Spaceship Ambience (Pixabay)](https://pixabay.com/pt/sound-effects/spaceship-ambience-with-effects-21420/)
* **Skybox (Fundo):** [Milky Way Skybox](https://assetstore.unity.com/packages/2d/textures-materials/milky-way-skybox-94001)

---

## 📦 Links do Projeto

* **Executável do Projeto:** [Clique aqui](https://drive.google.com/file/d/1hkmH5FFG7hI73Q-k3vKFK9vH0-sBgvCm/view?usp=sharing)
* **Vídeo Demonstrativo:** [Clique aqui](link.com.br)

---

## 👥 Integrantes do Grupo

* **Gustavo Fernandes R. de Lima (Matrícula: 172957)**
* **Murilo Pelisser Burato (Matrícula: 178331)**
* **Grégori Roberto do Nascimento de Mattos (Matrícula: 172954)**

---

*Universidade de Passo Fundo - 2025*
