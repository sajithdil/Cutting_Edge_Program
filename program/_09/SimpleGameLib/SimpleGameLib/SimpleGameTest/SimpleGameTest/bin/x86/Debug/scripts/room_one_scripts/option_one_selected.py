from SimpleGameLib.Inventorys import *

key=InventoryItem();
key.Type="key";
key.Name="first_key";

PLAYERS.getPlayerAt(0).InventoryData.add(key);

