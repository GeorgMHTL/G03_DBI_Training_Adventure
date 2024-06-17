# G04_DBI_Training_Adventure
## Projekt Tagebuch 

### Joudi
| Datum      | Was gemacht?                                                                          |
|------------|---------------------------------------------------------------------------------------|
| 21.05.2024 | Tabelle Trainingstage, Uebungen und Training erstellt                                 |
| 31.05.2024 | View Tabelle erstellt mit Joins                                                       |
| 04.06.2024 | AddDay Klasse und AddWindow hinzugefügt                                               |
| 10.06.2024 | Hinzufügen von Daten fertig                                                           |
| 11.06.2024 | Eingaben Format geändert                                                              |
| 13.06.2024 | Löschen von einem Tag Basis fertig fehlt wie man datum bekommt zum löschen            |
| 14.06.2024 | Löschen fertig fehlt das Aktualisieren von der Home page nach dem löschen             |
| 15.06.2024 | Statistik fertig; Übungen variabel gemacht und man kann jetzt übungen hinzufügen      |
| 16.06.2024 | AddButton in 2 Buttons aufgeteilt für Eintrag und Übung; Buttons mit Icons vertauscht |

### Georg (in English because Joudi doesnt do it)
| Datum      | Was gemacht?                     |
|------------|----------------------------------|
| 04.06.2024 | Crated Repo and Base Layout      |
| 10.06.2024 | Added Loading from DB            |
| 11.06.2024 | Worked on Edit Window            |
| 13.06.2024 | Worked on Edit Window            |
| 15.06.2024 | Worked on UI                     |
| 16.06.2024 | Worked on UI and some SMALL bugs |
| 17.06.2024 | Worked on the NEW UI             |

## Kurzbeschreibung des Projekts
Ein Programm zur Trainingsdokumentation, Einträge von Ihrem Training dem Programm hinzufügen
### Must have's
- Einträge hinzufügen und in Datenbank speichern können
- Einträge anzeigen können
- Einträge bearbeiten können
- Einträge löschen können
### Nice to have's
- Statistik über die gemachten Übungen der Einträge
- Möglichkeit eigene Übungen hinzufügen können
- Einfache UI
- Designe möglichkeiten

## Datenbank Abfragen

### Tabellen erstellen
```sql
CREATE TABLE Trainingstage (ID integer primary key autoincrement, Datum date);
```

```sql
Create Table Uebungen (ID integer primary key autoincrement, Name string, Muskelgruppen string);
```

```sql
CREATE TABLE Training (ID integer primary key autoincrement, fkTag int, fkUebung int, Dauer integer, Schwierigkeit integer);
```

### View Tabelle die mit 2 Joins alle 3 Tabellen Infos verbindet
```sql
CREATE VIEW TrainingDetails AS
SELECT
    Trainingstage.Datum,
    Training.Dauer,
    Training.Schwierigkeit,
    Uebungen.Name,
    Uebungen.Muskelgruppen
FROM
    Trainingstage
JOIN
    Training ON Trainingstage.ID = Training.fkTag
JOIN
    Uebungen ON Training.fkUebung = Uebungen.ID
```

### Daten hinzufügen
Spalten die mit {} eingegrentzt sind, sind Variablen in unserem Programm.
```sql
INSERT INTO Uebungen (Name, Muskelgruppen) VALUES ('{name}', '{description}');
```
```sql
INSERT INTO Trainingstage (Datum) VALUES ('{Date}');
```
```sql
INSERT INTO Training(fkTag, fkUebung, Dauer, Schwierigkeit) VALUES ((SELECT ID From Trainingstage WHERE Datum = '{Date}'), {Exercise+1}, {Duration}, {Difficulty});
```

### Daten auslesen
```sql
SELECT Name FROM Uebungen;
```
```sql
SELECT Datum FROM TrainingDetails GROUP BY Datum;
```
```sql
SELECT * FROM TrainingDetails WHERE Datum = '{Datum}';
```
```sql
SELECT ID FROM Trainingstage WHERE Datum = '{newDate}';
```
```sql
SELECT UebungName, COUNT(*) FROM TrainingDetails GROUP BY UebungName;
```
### Daten ändern
```sql
UPDATE Trainingstage SET Datum = '{newDate}' WHERE Datum = '{oldDate}';
```
```sql
UPDATE Training SET fkUebung = '{ex.ExersiceCombo.SelectedIndex + 1}', Dauer = '{int.Parse(ex.TimeSpan.Text)}', Schwierigkeit = {ex.DifficultyCombo.SelectedIndex + 1} WHERE  ID = {ex.ID};"
```
### Daten löschen
```sql
DELETE FROM Training WHERE fkTag = (SELECT ID FROM Trainingstage WHERE Datum = '{Date}');
```
```sql
DELETE FROM Trainingstage WHERE Datum = '{Date}';
```

## Kurzanleitung
### Installationsanleitung
Sie müssen unsere .exe Datei herunterladen um unser Programm zu benutzen
### Bedienungsanleitung
#### Allgemein
```answer
Hier sehen Sie nun unser Programm. Unten finden Sie Ihre Einträge und oben gibt es noch Knöpfe um weitere Funktionalitäten auszuführen.
```
#### Navigation
```answer
Um einen Eintrag hinzuzufügen müssen Sie auf das Notzizbuch ähnliche Bild mit einem Pfeil nach unten in der Mitte klicken. Später taucht ein kleines Fenster auf, wo Sie Ihre Daten einfügen müssen. Beachten Sie, dass alle Felder richtig befüllt sein müssen, damit ein Eintrag, später beim Klicken auf "Hinzufügen", hinzugefügt wird.
```

```answer
Um eine eigene Übung hinzuzufügen müssen Sie auf das Gewicht ähnliche Bild mit einem Plus klicken. Später taucht ein kleines Fenster auf, wo Sie Ihre Daten einfügen müssen. Beachten Sie, dass alle Felder richtig befüllt sein müssen, damit ein Eintrag, später beim Klicken auf "Hinzufügen", hinzugefügt wird.
```

```answer
Um die Statistik über Ihre gemachten Übungen zu öffnen klicken Sie bitte auf das Bild, das wie ein Säulendiagramm aussieht. Nun können Sie die Statistik sehen.
```

```answer
Um die Hintergrundfarbe, der unteren Seite des Programmes zu ändern müssen Sie auf Bild klicken, das wie eine Farbpalette aussieht. Die Farbe des Bildes repräsentiert die nächste Farbe nach 2 Klicks.
```
#### Eintragsoberfläche
```answer
Um Ihre weiteren Einträge zu sehen müssen Sie auf einen der Pfeile rechts oder links klicken.
```

```answer
Um einen Eintrag zu bearbeiten müssen Sie bei einem Eintrag auf das Stift ähnliche Bild klicken. Später taucht ein kleines Fenster auf, wo Sie die bereits festgelegten Daten umändern können. Klicken Sie dann auf "Ok" um Ihre Änderung zu bestätigen.
```

```answer
Um einen Eintrag zu löschen müssen Sie bei einem Eintrag auf das Bild klicken, welches ein X symbolisiert. Später wird dieser Eintrag gelöscht und ist nicht mehr zu finden.
```

```answer
Wenn Sie wissen möchten, welche Muskelgruppen eine Übung trainiert, dann müssen Sie lediglich nur Ihren Mauszeiger bei einem Eintrag auf den Informationssymbol, das eingekreiste "i", legen.
```