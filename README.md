# Overview

**I decide to make  a RTS Game because if well is a type of game whit limitations, is simple put goals and measurable objectives improving my ability to plan projects and execute this projects, also for make this type of game you must use a lot of different tools of unity, even if is not 3d, I have the opportunity of understand and use a lot of multiple characteristics of the program for create this game, also help me for have a point of start in the programing games whit 2 players and by last I like the RTS games and I know how work and because of that I decide start whit agender of videogames that I know**

**The game is a RTS per turns were you play like one of two factions, called gray and red respectfully, each faction have one base and one worker at the beginning and can create soldiers and barracks, that are in board of 100 boxes, each one of this elements is called fiches and each one of them have 2 values, move and health, if the health drops to 0 the fiche is destroyed and the move determinates what number of actions can make that fiche that turn, for a example, if a worker have 1 move and walks to other box, the worker will now have 0 move and will cannot do nothing more, this move element receive a + 1 for each fiche in each player turn, the player can decide if used or not use the fiche inactive for that turn and the next use more than 1 movement, each fiche is different and fulfills a role, first the base store the resources, this resources work to generate new fiches, in the bae you can also create new workers expending 1 resource element, if your base is destroyed you lose the game, the worker can recollect more resources if is close to a resources fiche(+2 in resources) of create a barrack(-4 in resources), the barrack can create soldiers(-2 in resources), the soldiers can attack the enemies and deal 1 of damage, the game needs two player playing in the same computer, the objective of each player if destroy the enemy base, each player will take a turn for make his moves, this is in terms of playthrough, in terms of code each fiche have programed a standard health, the movement at the start of the gray player is one because go first and the red player have 2 of movements for compensate at the start, during each turn the controls of the contrary player are deactivated and each fiche of the current player receives 1+ move, this is made in the PlayersTurns.cs, this scrip also check if any of the bases has been destroyed to see the winer, the way that works the fiches ius that teres a code that see what is in the box in his front, back, top and down the fiche, depending of what is in the box is the possible actions, the worker can move in empty box or build new barracks there and if in box is a resource fiche the worker can recollect resources, the solder can move similar and if in the box ius a enemy fiche he can attack, the two buildings can create new fiches in the box if are empty, the code do this  by the use of menus that ,let the player select multiple options all of this code is inside the respective cs files for each fiche, at lasts there’s DisplayResurces.cs file that display part of the IU and the BackgroundMusic.cs that manages the music in the game, this is how work the game in a point of view of script.**

**I made this code for improve my ability in c# for the programing of games and starting my path programing games, during this project I develop my c# skills to fulfill the goals by making new and original code to fulfill this goals, also understand how use UNITY and his tools for fulfill the project, all of this improve my ability of programming whit c# and how combined whit UNITY, this project has help me for be more capable in this areas and coding in general.**

[Software Game Demo Video](https://youtu.be/0bBeBmQN_f0)

# Development Environment

**I use the UNITY engine for develop the 2D game whit the help of VS Code for the creation of scrips and GitHub for sharing and storing of the game.**

**The game is programed whit c#, a common language designed for scripting and whit a great capabilities and in UNITY, a common game motor that is easy of understand and have a lot of potential, I use the UNITY built-in APIs, including UnityEngine, UnityEngine.Tilemaps, and UnityEngine.EventSystems, to handle game objects, grid positions, mouse input, and UI interactions.**

# Useful Websites

* [Unity Official Website](https://unity.com/es)
* [Unity Manual](https://docs.unity3d.com/Manual/index.html)
* [Unity Scripting API](https://docs.unity3d.com/ScriptReference/)

# Future Work

* **Theres a weird bug that happens when you select a fiche and do a movement, another fiche will move to a random box, I don’t know why and like future project I will fix this.**
* **Add a new characteristic top the name called technologies, have the ability of research a technology at the exchange of some resources and number of turns, this technology will bring some advantages, like the solder making 2 points of damage or the worker recollecting 4 resources, some tings like that.**
* **Add death and actions sound to all the fiches for give them more personality.**