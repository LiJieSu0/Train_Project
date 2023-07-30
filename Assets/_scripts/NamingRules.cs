/*
Naming Rules in Scripts or in Scenes

Characters

Every unique character has one ID, and the length is based on how many characters may be designed.
As a character can be controlled by the player, the naming should be "P_CHARACTER:ID."
As an enemy, the naming should be "E_CHARACTER:ID".
If there are multiple same characters on the battlefield, the naming should be P_CHARACTER:ID_index, index starting from 0.

Battle Field

There are 6 field positions on each player field and enemy field. 6 positions are separated by front line and back line.
The front line and back line both includes 3 positions, top middle bottom. The naming rule should be followed

BT (Backline Top)       FT(Frontline Top)
BM (Backline Middle)    FM(Frontline Middle)
BB (Backline Bottom)    FB(Frontline Bottom)

if the position belongs player field, the name should add P_ before the position, like P_BT.
This naming rule could be combined with the characters naming rule mentioned earlier,
for instance, P_BT_P_Character:ID_0, represent where the first character stands on the battle field.


Every local variable should add _ before the variable name.
variables reference from other class don't need to add _
Class name should start with Upper case.
Interface name should start with I.
method name should start with lower case.

GameObject name should start with Upper case.
UI object should followed by UI as name, like HealthBarUI.
 
 */
