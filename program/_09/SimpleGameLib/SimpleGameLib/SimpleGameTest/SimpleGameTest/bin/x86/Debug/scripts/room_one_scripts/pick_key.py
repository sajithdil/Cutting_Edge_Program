from SimpleGameLib import *
from SimpleWindow.Structure import *

LOG.log("$pick_key Pick key entered");

frame=GFrame("key_pick",250,230,200,150);
frame.Background="grass_tile";

width=100;
height=30;
op1="Pick up key two";
op2="Pick up key one";
op3="You snuff it";

option1=GText("Option1",0,1,width,height,op1);
option2=GText("Option2",0,20,width,height,op2);
option3=GText("Option3",0,40,width,height,op3);

select1=UserEvents("key_option_one_selected");
select2=UserEvents("key_option_two_selected");
select3=UserEvents("key_option_three_selected");

option1.OnClick=select1;
option2.OnClick=select2;
option3.OnClick=select3;
        
frame.register(option1);
frame.register(option2);
frame.register(option3);
        
WINDOWCONTROL.add(frame);
MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);
LOG.log("$pick_key Left pick key");