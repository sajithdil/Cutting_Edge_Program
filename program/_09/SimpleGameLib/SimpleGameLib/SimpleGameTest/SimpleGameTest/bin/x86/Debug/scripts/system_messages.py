from SimpleWindow.Structure import *

frame=GFrame("Welcome Winodow",10,10,200,20);
frame.Background="grass_tile";

msg=GText("msg",50,1,20,20,"This window was created in python");
closeOnLeftClick=UserEvents("close_window");
msg.OnClick=closeOnLeftClick;

frame.register(msg);

WINDOWCONTROL.add(frame);
MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);