from SimpleWindow.Structure import *
from SimpleGameLib.Events import *

#Get the frame
LOG.log("Requested to close the Quiz Window");

result=MINDER.getModel("QuizWindow");


#Turn on the event
eventObject=WORLDSKEEPER.getCurrent().EventMapData.getEventByName("test_event");

if eventObject=="null" :
        LOG.log("$Not Found the world");
else:
        LOG.log("$Found the world");
        eventObject.Alive="true";
result.kill();