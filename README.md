# SpieleGluecksrad
Glücksrad um Spiele zb Für einen Challenge stream auszulosen

## Features

Mit dem Aktivieren der Automatisch Streichen Checkbox Wird nach dem Stop des Rades das Item aus der Liste "Gestrichen" (Abgehackt)
Jedes Stück vom Rad ist einem Item der Liste zugeortnet

## Benutzen

![grafik](https://github.com/Bisam97/SpieleGluecksrad/assets/15315141/ebc82540-274a-4b7d-b1b0-87f425e2f58a) 

### Ohne Untergruppe

"Öffnen des Glücksrades" öffnet das Glücksrad Nachdem die Settings Geladen wurden dabei bennent sich der Knopf in "Spinn" um.

"Spinn" Aktualisiert das Rad mit den nicht Abgehackten Items der Liste und lässt es Drehen. Es hält nach kurzer zeit an und gibt den gewinner bekannt.

"Streiche den Gewinner" Macht das selbe wie das Automatische Streichen nur Manuell
![grafik](https://github.com/Bisam97/SpieleGluecksrad/assets/15315141/55fd4c7e-e9ec-4e34-a80a-7e9466f17627)


### Laden
Im Bereich Laden kann man Settings laden die man zuvor eingestellt hat und CVS Dateien in das Programm einlesen welche die Items des Rades enthalten (Liste Rechts).
In den Settings wird gespeichert welche Farben man für das Rad Eingestellt hat, mit welcher geschwindichkeit das Rad sich dreht und wie lange sich das Rad dreht.
Zusätzlich kann noch eine CVS Datei mit den Settings verknüpft werden welche beim aufruf der Settings automatisch geladen wird.


### Speichern
Im Bereich Laden kann man kann man Die Settings Speichern und die Liste von Items als CSV Datei Exportieren.

### Einfügen in Liste

Hier Lassen sich Die Items in die Liste eintragen und auch alle schon vom Rad gestrichen Items zurücksetzten.

### Aus Lste Löschen

Man hat die Möglichkeit das aktuell ausgewählte Element aus der Liste zu Löschen oder die Ganze Liste zu löschen.

### Bestechen

Mit einem Klick auf "Besteche das Rad" wird das Element zu 100% gewinnen welches Aktuell in der Liste ausgewählt oder in der Nummern Box eingetragen ist.
Das bestechen wird automatisch wenn das Rad steht wieder Aufgehoben.

### Geschwindichkeit und Timer

Hier Lässt sich die Zeit einstellen welche das Rad Minimal/Maximal mit voller geschwichkeit Dreht.
Zusätzlich lässt sich hier auch die Maximal Geschwindichkeit des Rades Einstellen.

### Farben und Co

ein Klick auf Farben ändern öffnet:

![grafik](https://github.com/Bisam97/SpieleGluecksrad/assets/15315141/05328a41-952c-4458-9f14-2b4e9a0dc420)

Mit dem Fenster kann man die Farbreihenfolge des Rades einstellen.
Beim Klick auf Wähle Farbe Öffnet sich eine Farbpalette wo man sich eine Farbe aussucht und mit OK sie in die Liste hinzufügt.

Löschen löscht die aktuell ausgewählte Zeile der Liste.

Regenbogen Läd eine vorgefertigte Liste an Farben.


## TODOs

- Item aus der Liste kann einer Farbe zugeortnet werden.
- Name vom Item der Liste wird dem Zugeortneten Stück im Rad angezeigt.




