from SimpleGameLib import *
from SimpleGameLib.Players import *
from System.Collections.Generic import *
from SimpleGameLib.Animations import *
from SimpleGameLib.MouseRenderers import *
from System import *



#set the current world
WORLDSKEEPER.setToCurrent("room_three");

#load the map
WORLDSKEEPER.getCurrent().init();

#Create the cursor
LOG.log("$start_up.py Attempting to create the cursor");
MOUSECURSOR.Alias="cursor";
LOG.log("$start_up.py Finished creating cursor");

#Create the player
LOG.log("$start_up.py Attempting to add a player");

player=Player("QuizMan",400,200);

#Create the states
idleState=IdleState("idle",player);
walkLeft=WalkLeftState("player_left",player);
walkRight=WalkRightState("player_right",player);
walkUp=WalkUpState("player_up",player);
walkDown=WalkDownState("player_down",player);
collision=CollisionState("idle",player);

player.Idle=idleState;
player.WalkLeft=walkLeft;
player.WalkRight=walkRight;
player.WalkUp=walkUp;
player.WalkDown=walkDown;
player.Collision=collision;

#Set the player to a state
player.PlayerState=idleState

#Attach the player to the players

PLAYERS.add(player);

LOG.log("$start_up.py Finished adding a player");

LOG.log("Finished running the script start_up.py");