from SimpleGameLib.Inventorys import *

potion=InventoryItem();
potion.Name="healthPotion";
potion.Type="potion";
potion.ImageAlias="dungeon_tile_one";

#Add it to the players inventory
PLAYERS.getPlayerAt(0).InventoryData.add(potion);

LOG.log("$notification added a potion");