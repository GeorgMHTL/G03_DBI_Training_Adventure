# G04_DBI_Training_Adventure

## Datenbank Abfragen

### Tabellen erstellen
```sql
Create Table Trainingstage (ID integer primary key autoincrement, Datum date, Dauer time default 0, Schwierigkei
t integer default 1);
```

```sql
Create Table Uebungen (ID integer primary key autoincrement, Name string, Muskelgruppen string);
```

```sql
Create Table Training (ID integer primary key autoincrement, fkTag int, fkUebung int);
```

### View Tabelle die mit 2 Joins alle 3 Tabellen Infos verbindet
```sql
Create View TrainingDetails as select Trainingstage.Datum, Trainingstage.Dauer, Trainingstage.Schwierigkeit, Uebungen.Name, Uebungen.Muskelgruppen f
rom Trainingstage join Training on Training.fkTag = Trainingstage.ID join Uebungen on Training.fkUebung = Uebungen.ID;
```

## Projekt Tagebuch
### Joudi
| Datum      | Was gemacht?                                          |
| ---------- | ----------------------------------------------------- |
| 21.05.2024 | Tabelle Trainingstage, Uebungen und Training erstellt |
| 31.05.2024 | View Tabelle erstellt mit Joins                       |
| 04.06.2024 | AddDay Klasse und AddWindow hinzugefügt               |
| 10.06.2024 | Hinzufügen von Daten fertig                           |
| 11.06.2024 | Eingaben Format geändert                              |

### Georg
| Datum      | Was gemacht?                |
| ---------- | --------------------------- |
| 04.06.2024 | Crated Repo and Base Layout |
| 10.06.2024 | Added Loading from DB       |
|            |                             |