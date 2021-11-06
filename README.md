# Text Pop
## By DavidD-Fleming

Heya! This is Text Pop, a short game I made using Unity and C# to warm up my programming skills. Text Pop was created over the course of 4 days (~20 hours). The point of the game is to survive for as long as possible controlling a player against incoming hazards. You can control the player using your mouse and can pop the hazard by typing in its associated key (A-Z, 0-9). The game gets progressively harder as time passes with hazards spawning more frequently and being generally faster. The player can also change the difficulty from easy to normal to hard.

The first commit to Github was done to document what I thought looked like a really cool bouncing ball simulator. As is (in that version), the balls only bounce up and down but they can get more unpredictable by changing the max angle in the spawner gameobject.

The hardest part of making the game was unfortunately my own stubbornness! There were many solutions I could have employed or employed much sooner that I avoided using because I was too hard headed and wanted to go with an "easier" route (even though it was significantly easier just going with another option). For example, Unity KeyCode associates its keys with a specific object that is not a string. Essentially unless if I wanted to create 30+ if statements accounting for every possible key, it seemed impossible to associate the hazard char with the KeyCode that would have popped it. I spent longer then I would like to admit thinking through this problem. After doing some basic research I learned to just utilize EventManager and that instantly solved the problem. Lesson learned.

The part of the project I'm most proud of is colors for the hazards. Initially I was just going to have the hazards all be the same color but I realized it made the game look incredibly boring. Eventually, after some good thinking, I made it so each RGB value of a hazard color would be associated with an in game value. For example, hazards grow more red as the game goes on. This change made the game look amazing compared to its original version and makes everything pop.

Text Pop as it is, is a finished product. However, in the future, I would like to implement my own PlayerPrefs so that the game is more secure and is less prone to warnings. Other then that I am very happy with this game and I plan to use the skills and lessons I learned in future projects!

That's all!
