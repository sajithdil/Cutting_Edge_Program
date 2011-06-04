from SimpleWindow.Structure import *
frame=GFrame("Event1",78,100,200,20);
frame.Background="grass_tile";

msg=GText("eventMessage",50,1,20,20,"This is an event triggered by the player walking over me");

frame.register(msg);

WINDOWCONTROL.add(frame);
MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);