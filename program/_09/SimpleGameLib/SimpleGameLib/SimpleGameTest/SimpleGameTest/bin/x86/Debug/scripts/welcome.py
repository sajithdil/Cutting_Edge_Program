from SimpleGameLib import *
from SimpleWindow.Structure import *

LOG.log("Welcome");

#Create a frame to hold the other components, need this destroy the window too
frame=GFrame("MyPythonWindow",200,200,200,100);
frame.Background="door";


img=GImageFrame("MyAvatar",0,0,40,60,"grass_tile");
message=GText("welcome_msg",50,1,20,20,"This window was created in python ");
click=UserEvents("create_interface");
message.OnClick=click;

frame.register(message);
frame.register(img);

#Connect the elements to the game
WINDOWCONTROL.add(frame);
#Need to generate a new map of the windows once changes are made
MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);

LOG.log("$welcome ending script");