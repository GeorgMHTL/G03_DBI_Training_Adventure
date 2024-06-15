# G04_DBI_Training_Adventure

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
/* TrainingDetails(Datum,Dauer,Schwierigkeit,Name,Muskelgruppen) */;
```

## Projekt Tagebuch 

### Joudi
| Datum      | Was gemacht?                                                                     |
| ---------- | -------------------------------------------------------------------------------- |
| 21.05.2024 | Tabelle Trainingstage, Uebungen und Training erstellt                            |
| 31.05.2024 | View Tabelle erstellt mit Joins                                                  |
| 04.06.2024 | AddDay Klasse und AddWindow hinzugefügt                                          |
| 10.06.2024 | Hinzufügen von Daten fertig                                                      |
| 11.06.2024 | Eingaben Format geändert                                                         |
| 13.06.2024 | Löschen von einem Tag Basis fertig fehlt wie man datum bekommt zum löschen       |
| 14.06.2024 | Löschen fertig fehlt das Aktualisieren von der Home page nach dem löschen        |
| 15.06.2024 | Statistik fertig; Übungen variabel gemacht und man kann jetzt übungen hinzufügen |

### Georg (in English because Joudi doesnt do it)
| Datum      | Was gemacht?                |
| ---------- | --------------------------- |
| 04.06.2024 | Crated Repo and Base Layout |
| 10.06.2024 | Added Loading from DB       |
| 11.06.2024 | Worked on Edit Window       |
| 13.06.2024 | Worked on Edit Window       |
| 15.06.2024 | Worked on UI                |