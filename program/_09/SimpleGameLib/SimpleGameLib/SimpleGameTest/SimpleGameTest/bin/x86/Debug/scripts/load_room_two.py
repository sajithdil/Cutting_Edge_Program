from SimpleGameLib import *

LOG.log("Trying to load room two");

WORLDSKEEPER.setToCurrent("room_two");

LOG.log("Loading data");

WORLDSKEEPER.getCurrent().init();

PLAYERS.getPlayerAt(0).setPosition(358,250);

LOG.log("Finished loading the room");