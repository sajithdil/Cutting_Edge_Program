from SimpleWindow.Structure import *

def  buildWindow(op1,op2,op3,message,locx,locy,width,height):
        frame=GFrame("window",locx,locy,width,height);
        frame.Background="grass_tile";
        
        option1=GText("Option1",0,1,width,height,op1);
        option2=GText("Option2",0,20,width,height,op2);
        option3=GText("Option3",0,40,width,height,op3);
        
        frame.register(option1);
        frame.register(option2);
        frame.register(option3);
        
        WINDOWCONTROL.add(frame);
        MINDER.generate(WINDOWCONTROL,WINDOWSKINNER,WINDOWSTYLE);
        return
    