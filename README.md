# G04_DBI_Training_Adventure

## Datenbank Abfragen

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