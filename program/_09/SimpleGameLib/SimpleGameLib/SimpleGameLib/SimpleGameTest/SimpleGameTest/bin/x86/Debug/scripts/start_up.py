from SimpleGameLib import *
from SimpleGameLib.Players import *
from System.Collections.Generic import *
from SimpleGameLib.Animations import *
from System import *


#set the current world
WORLDSKEEPER.setToCurrent("room_one");

#load the map
WORLDSKEEPER.getCurrent().init();

#Create the player
LOG.log("$start_up.py Attempting to add a player");

player=Player("QuizMan",8,200);

#Create the states
idleState=IdleState("idle_animation",player);
walkLeft=WalkLeft("idle_animation",player);
walkRight=WalkRight("idle_animation",player);

player.Idle=idleState;
player.WalkLeft=walkLeft;
player.WalkRight=walkRight;

#Set the player to a state
player.PlayerState=idleState

PLAYERS.add(player);

LOG.log("$start_up.py Finished adding a player");

LOG.log("Finished running the script start_up.py");