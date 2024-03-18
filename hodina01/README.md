# 1. hodina

Příklady  vyřešte  v libovolném  procedurálním  programovacím  jazyce. Veškeré  vzájemné 
výměny  prvků  je  nutno  dělat  pomocí  přesměrování  odkazů,  nikoliv  výměnou  datových 
hodnot. Správnost programu otestujte zadáním různých vstupních hodnot. Hodina se považuje 
za splněnou po zisku alespoň 8 bodů z možných 38 bodů. 
 
## Příklad 1.1
Funkce pro práci s jednosměrným spojovým seznamem celých čísel.

Následující funkce napište s optimálním počtem průchodů spojovým seznamem:

a) Napište funkci, která uloží spojový seznam do textového souboru. [2 bod]

b) Napište funkci, která načte z textového souboru spojový seznam, který byl uložen pomocí 
funkce z příkladu 1.1a. [2 bod]

c) Napište funkci, která vrátí počet výskytů zadaného prvku ve spojovém seznamu. [2 body]

d) Napište funkci, která ze spojového seznamu odstraní poslední z prvků, jejichž hodnota je shodná se zadanou hodnotou. [2 body]

e) Napište funkci, která ze spojového seznamu odstraní prvek s nejvyšší hodnotou. Pokud má více prvků stejnou hodnotu, odstraní první z nich. [2 body]

f)  Napište  funkci,  která  obrátí  pořadí  prvků  ve  spojovém  seznamu  (za  použití  jednoho průchodu spojovým seznamem). [3 body]

g) Napište funkci, prvky spojového seznamu uspořádá sestupně. [3 body]

h) Napište funkci, která ve spojovém seznamu prohodí  (pomocí odkazů, nikoliv výměnou 
hodnot) první prvek a poslední prvek. [2 body]

i)  Napište funkci, která ve spojovém seznamu prohodí  druhý prvek a  předposlední prvek. Poznámka: V případě spojového seznamu o dvou prvcích je předposledním prvkem první prvek a druhým prvkem poslední prvek, dojde tedy k jejich výměně. Při testování vyzkoušejte funkci pro seznam se 4 prvky. [4 body] 
 
```
Ukázka: 
int[] pole = { 1055, 2, 29, 8, 7, 15, 29, 8, 22, 6, 29 }; 
Seznam s1 = ConvertArray(pole);  
// 1055->2->29->8->7->15->29->8->22->6->29 
Save("spojak.txt", s1);  
// 1055 2 29 8 7 15 29 8 22 6 29 
Seznam s2 = Load("spojak.txt");  
// 1055->2->29->8->7->15->29->8->22->6->29 
int pocet = Count(s1, 29); // 3 
s1 = DeleteLast(s1, 8);  
// 1055->2->29->8->7->15->29->22->6->29 
s1 = DeleteMax(s1);  
// 2->29->8->7->15->29->22->6->29 
s1 = Reverse(s1);  
// 29->6->22->29->15->7->8->29->2 
s1 = Sort(s1);  
// 29->29->29->22->15->8->7->6->2 
s1 = SwapFirstLast(s1);  
// 2->29->29->22->15->8->7->6->29 
s1 = SwapSecondPenultimate(s1);  
// 2->6->29->22->15->8->7->29->29
```
