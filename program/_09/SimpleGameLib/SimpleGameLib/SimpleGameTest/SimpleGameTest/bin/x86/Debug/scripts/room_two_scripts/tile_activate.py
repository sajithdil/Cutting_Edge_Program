from SimpleGameLib import *
from SimpleWindow.Structure import *

frame=GFrame("tile_activate",250,130,600,450);
frame.Background="puzzle_parchment";

closeButton=GButton("close",0,1,50,30);

close=UserEvents("tile_activate_close");

closeButton.OnClick=close;

frame.register(closeButton);

WINDOWCONTROL.add(frame);
MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);