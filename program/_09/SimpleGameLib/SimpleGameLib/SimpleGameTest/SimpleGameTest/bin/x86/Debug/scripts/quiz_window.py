from SimpleWindow.Structure import *

LOG.log("$quiz_window Attempt to start the quiz");
PLAYERS.getPlayerAt(0).setPosition(100,100);
#The frame to hold the quiz
frame=GFrame("QuizWindow",100,200,200,100);
frame.Background="grass_tile";

#The options
option1=GText("Option1 ",0,1,200,100,"Option One");
option2=GText("Option2",0,50,200,100,"Option Two");

#Attach the user events
close=UserEvents("quiz_close");
close2=UserEvents("quiz_close");

option1.OnClick=close;
option2.OnClick=close2;

#Attach the options
frame.register(option1);
frame.register(option2);

#Attach to the window minder and controller
WINDOWCONTROL.add(frame);
MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);

LOG.log("$quiz_close Finished creating the script");