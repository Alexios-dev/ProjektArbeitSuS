-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-01-21 23:13:17.186

-- tables
-- Table: DatenLehrer
CREATE TABLE DatenLehrer (
    ID int  NOT NULL IDENTITY(1, 1),
    DatumVon datetime  NULL,
    Lehrer_Matrikelnummer int  NOT NULL,
    RFIDLeser_ID int  NOT NULL,
    CONSTRAINT DatenLehrer_pk PRIMARY KEY  (ID)
);

-- Table: DatenSchueler
CREATE TABLE DatenSchueler (
    ID int  NOT NULL IDENTITY(1, 1),
    DatumVon datetime  NULL,
    Schueler_Matrikelnummer int  NOT NULL,
    RFIDLeser_ID int  NOT NULL,
    CONSTRAINT DatenSchueler_pk PRIMARY KEY  (ID)
);

-- Table: Fach
CREATE TABLE Fach (
    ID int  NOT NULL IDENTITY(1, 1),
    Name varchar(50)  NOT NULL,
    CONSTRAINT Fach_pk PRIMARY KEY  (ID)
);

-- Table: Fehlzeiten
CREATE TABLE Fehlzeiten (
    ID int  NOT NULL IDENTITY(1, 1),
    DatumVon datetime  NULL,
    DatumBis datetime  NULL,
    Entschuldigt int  NOT NULL,
    Lehrer_Matrikelnummer int  NOT NULL,
    Schueler_Matrikelnummer int  NOT NULL,
    CONSTRAINT Fehlzeiten_pk PRIMARY KEY  (ID)
);

-- Table: Lehrer
CREATE TABLE Lehrer (
    Matrikelnummer int  NOT NULL,
    Vorname varchar(50)  NOT NULL,
    Nachname varchar(50)  NOT NULL,
    Geburtsdatum date  NOT NULL,
    Kuerzel varchar(50)  NOT NULL,
    Password varchar(255)  NOT NULL,
    RFIDChip_UID int  NOT NULL,
    CONSTRAINT Lehrer_pk PRIMARY KEY  (Matrikelnummer)
);

-- Table: Lehrer_StundenplanStunden
CREATE TABLE Lehrer_StundenplanStunden (
    Lehrer_Matrikelnummer int  NOT NULL,
    StundenplanStunden_ID int  NOT NULL,
    CONSTRAINT Lehrer_StundenplanStunden_pk PRIMARY KEY  (StundenplanStunden_ID,Lehrer_Matrikelnummer)
);

-- Table: RFIDChip
CREATE TABLE RFIDChip (
    UID int  NOT NULL,
    Number int  NOT NULL,
    CONSTRAINT RFIDChip_pk PRIMARY KEY  (UID)
);

-- Table: RFIDLeser
CREATE TABLE RFIDLeser (
    ID int  NOT NULL IDENTITY(1, 1),
    Name varchar(50)  NULL,
    CONSTRAINT RFIDLeser_pk PRIMARY KEY  (ID)
);

-- Table: Schueler
CREATE TABLE Schueler (
    Matrikelnummer int  NOT NULL IDENTITY(1, 1),
    Vorname varchar(50)  NULL,
    Nachname varchar(50)  NULL,
    Geburtsdatum date  NULL,
    password varchar(255)  NULL,
    RFIDChip_UID int  NOT NULL,
    SchuhlKlassen_ID int  NOT NULL,
    CONSTRAINT Schueler_pk PRIMARY KEY  (Matrikelnummer)
);

-- Table: SchuhlKlassen
CREATE TABLE SchuhlKlassen (
    ID int  NOT NULL IDENTITY(1, 1),
    Name varchar(50)  NOT NULL,
    Lehrer_Matrikelnummer int  NOT NULL,
    CONSTRAINT SchuhlKlassen_pk PRIMARY KEY  (ID)
);

-- Table: Stundenplan
CREATE TABLE Stundenplan (
    ID int  NOT NULL IDENTITY(1, 1),
    SchuhlKlassen_ID int  NOT NULL,
    CONSTRAINT Stundenplan_pk PRIMARY KEY  (ID)
);

-- Table: StundenplanStunden
CREATE TABLE StundenplanStunden (
    ID int  NOT NULL IDENTITY(1, 1),
    DateTimeVon datetime  NOT NULL,
    DateTimeBis datetime  NOT NULL,
    Fach_ID int  NOT NULL,
    Stundenplan_ID int  NOT NULL,
    CONSTRAINT StundenplanStunden_pk PRIMARY KEY  (ID)
);
GO
-- foreign keys
-- Reference: DatenLehrer_Lehrer (table: DatenLehrer)
ALTER TABLE DatenLehrer ADD CONSTRAINT DatenLehrer_Lehrer
    FOREIGN KEY (Lehrer_Matrikelnummer)
    REFERENCES Lehrer (Matrikelnummer);

-- Reference: DatenLehrer_RFIDLeser (table: DatenLehrer)
ALTER TABLE DatenLehrer ADD CONSTRAINT DatenLehrer_RFIDLeser
    FOREIGN KEY (RFIDLeser_ID)
    REFERENCES RFIDLeser (ID);

-- Reference: Daten_RFIDLeser (table: DatenSchueler)
ALTER TABLE DatenSchueler ADD CONSTRAINT Daten_RFIDLeser
    FOREIGN KEY (RFIDLeser_ID)
    REFERENCES RFIDLeser (ID);

-- Reference: Daten_Schueler (table: DatenSchueler)
ALTER TABLE DatenSchueler ADD CONSTRAINT Daten_Schueler
    FOREIGN KEY (Schueler_Matrikelnummer)
    REFERENCES Schueler (Matrikelnummer);

-- Reference: Fehlzeiten_Lehrer (table: Fehlzeiten)
ALTER TABLE Fehlzeiten ADD CONSTRAINT Fehlzeiten_Lehrer
    FOREIGN KEY (Lehrer_Matrikelnummer)
    REFERENCES Lehrer (Matrikelnummer);

-- Reference: Fehlzeiten_Schueler (table: Fehlzeiten)
ALTER TABLE Fehlzeiten ADD CONSTRAINT Fehlzeiten_Schueler
    FOREIGN KEY (Schueler_Matrikelnummer)
    REFERENCES Schueler (Matrikelnummer);

-- Reference: Klassen_Lehrer (table: SchuhlKlassen)
ALTER TABLE SchuhlKlassen ADD CONSTRAINT Klassen_Lehrer
    FOREIGN KEY (Lehrer_Matrikelnummer)
    REFERENCES Lehrer (Matrikelnummer);

-- Reference: Lehrer_RFIDChip (table: Lehrer)
ALTER TABLE Lehrer ADD CONSTRAINT Lehrer_RFIDChip
    FOREIGN KEY (RFIDChip_UID)
    REFERENCES RFIDChip (UID);

-- Reference: Lehrer_StundenplanStunden_Lehrer (table: Lehrer_StundenplanStunden)
ALTER TABLE Lehrer_StundenplanStunden ADD CONSTRAINT Lehrer_StundenplanStunden_Lehrer
    FOREIGN KEY (Lehrer_Matrikelnummer)
    REFERENCES Lehrer (Matrikelnummer);

-- Reference: Lehrer_StundenplanStunden_StundenplanStunden (table: Lehrer_StundenplanStunden)
ALTER TABLE Lehrer_StundenplanStunden ADD CONSTRAINT Lehrer_StundenplanStunden_StundenplanStunden
    FOREIGN KEY (StundenplanStunden_ID)
    REFERENCES StundenplanStunden (ID);

-- Reference: Schueler_RFIDChip (table: Schueler)
ALTER TABLE Schueler ADD CONSTRAINT Schueler_RFIDChip
    FOREIGN KEY (RFIDChip_UID)
    REFERENCES RFIDChip (UID);

-- Reference: Schueler_SchuhlKlassen (table: Schueler)
ALTER TABLE Schueler ADD CONSTRAINT Schueler_SchuhlKlassen
    FOREIGN KEY (SchuhlKlassen_ID)
    REFERENCES SchuhlKlassen (ID);

-- Reference: StundenplanStunden_Fach (table: StundenplanStunden)
ALTER TABLE StundenplanStunden ADD CONSTRAINT StundenplanStunden_Fach
    FOREIGN KEY (Fach_ID)
    REFERENCES Fach (ID);

-- Reference: StundenplanStunden_Stundenplan (table: StundenplanStunden)
ALTER TABLE StundenplanStunden ADD CONSTRAINT StundenplanStunden_Stundenplan
    FOREIGN KEY (Stundenplan_ID)
    REFERENCES Stundenplan (ID);

-- Reference: Stundenplan_SchuhlKlassen (table: Stundenplan)
ALTER TABLE Stundenplan ADD CONSTRAINT Stundenplan_SchuhlKlassen
    FOREIGN KEY (SchuhlKlassen_ID)
    REFERENCES SchuhlKlassen (ID);

-- End of file.


--Fach
INSERT INTO Fach(Name)
Values('Deutsch');--0
INSERT INTO Fach(Name)
Values('Mathe');--1
INSERT INTO Fach(Name)
Values('Englisch');--2
INSERT INTO Fach(Name)
Values('Software');--3
INSERT INTO Fach(Name)
Values('Rechnersystemtechnik');--4
INSERT INTO Fach(Name)
Values('Datenbank');--5
INSERT INTO Fach(Name)
Values('Wirtschaft');--6
INSERT INTO Fach(Name)
Values('Betriebssystemnezwerk');--7
INSERT INTO Fach(Name)
Values('Elektroprozesstechnik');--8
INSERT INTO Fach(Name)
Values('Politik');--9
GO
--RFID Chip
--Lehrer UID
INSERT INTO RFIDChip(UID,Number)
Values (00000001,987654321);
INSERT INTO RFIDChip(UID,Number)
Values (00000002,198765432);
INSERT INTO RFIDChip(UID,Number)
Values (00000003,129876543);
INSERT INTO RFIDChip(UID,Number)
Values (00000004,321987654);
INSERT INTO RFIDChip(UID,Number)
Values (00000005,431298765);
INSERT INTO RFIDChip(UID,Number)
Values (00000006,543219876);
INSERT INTO RFIDChip(UID,Number)
Values (00000007,321987657);
INSERT INTO RFIDChip(UID,Number)
Values (00000008,431298768);
INSERT INTO RFIDChip(UID,Number)
Values (00000009,543219879);
INSERT INTO RFIDChip(UID,Number)
Values (00000010,543219880);
GO
--Schüler UID
INSERT INTO RFIDChip(UID,Number)
Values (00000011,000000001);

GO
--RFID Leser
INSERT INTO RFIDLeser(Name)
VALUES ('C112');
INSERT INTO RFIDLeser(Name)
VALUES ('C107');
INSERT INTO RFIDLeser(Name)
VALUES ('C206');
INSERT INTO RFIDLeser(Name)
VALUES ('A103');
INSERT INTO RFIDLeser(Name)
VALUES ('A104');
INSERT INTO RFIDLeser(Name)
VALUES ('A105');
INSERT INTO RFIDLeser(Name)
VALUES ('A106');

GO
--Lehrer
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889977,'Steffan','Erlei','1990/01/01','ER',00000001);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889978,'Mara','Jansen','1990/01/02','JA',00000002);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889979,'Frank','Wächter','1990/01/01','WÄ',00000003);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889981,'Boris','Hegermann','1990/01/01','HA',00000004);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889982,'Ali','Bostanci','1990/01/02','BC',00000005);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889983,'Andreas','Burdenski','1990/01/05','BD',00000006);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889984,'Holger','Hüller','1990/01/01','HÜ',00000007);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889985,'Detlef','Gotthardt','1990/01/02','GH',00000008);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889986,'Stefan','Opalla','199/001/03','OP',00000009);
INSERT INTO Lehrer(Matrikelnummer,Vorname,Nachname,Geburtsdatum,Kuerzel,RFIDChip_UID)
VALUES (5016889987,'Dennis','Netterdon','1990/01/05','NT',00000010);
GO

--Schuhl Klassen
INSERT INTO SchuhlKlassen(Name,Lehrer_Matrikelnummer)
Values ('AIT32',5016889977);
INSERT INTO SchuhlKlassen(Name,Lehrer_Matrikelnummer)
Values ('AIT31',5016889978);
INSERT INTO SchuhlKlassen(Name,Lehrer_Matrikelnummer)
Values ('AIT01',5016889979);
GO
--Stundenplan
INSERT INTO Stundenplan(SchuhlKlassen_ID)
Values (1);
INSERT INTO Stundenplan(SchuhlKlassen_ID)
Values (2);
INSERT INTO Stundenplan(SchuhlKlassen_ID)
Values (3);
GO
--StundenplanStunde
--Montag
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/17 8:30:00','2022/01/17 9:15:00',5,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/17 9:40:00','2022/01/17 11:10:00',6,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/17 11:30:00','2022/01/17 12:15:00',7,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/17 12:15:00','2022/01/17 13:00:00',7,1);
GO
--Dienstag
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/18 9:40:00','2022/01/17 11:10:00',8,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/18 11:30:00','2022/01/17 13:00:00',2,1);
GO
--Mittwoch
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/19 7:45:00','2022/01/17 9:15:00',4,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/19 9:40:00','2022/01/17 11:10:00',3,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/19 11:30:00','2022/01/17 13:00:00',1,1);
GO
--Donnerstag
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/20 7:45:00','2022/01/17 9:15:00',4,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/20 9:40:00','2022/01/17 11:10:00',7,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/20 11:30:00','2022/01/17 13:00:00',0,1);
GO
--Freitag
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/21 7:45:00','2022/01/17 9:15:00',3,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/21 9:40:00','2022/01/17 11:10:00',5,1);
INSERT INTO StundenplanStunden(DateTimeVon,DateTimeBis,Fach_ID,Stundenplan_ID)
Values ('2022/01/21 11:30:00','2022/01/17 13:00:00',9,1);
GO
--Lehrer_StundenplanStunden
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (0,5016889981);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (1,5016889982);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (2,5016889986);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (3,5016889983);

INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (4,5016889983);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (5,5016889977);

INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (6,5016889984);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (7,5016889979);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (8,5016889985);

INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (9,5016889984);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (10,5016889986);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (11,5016889978);

INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (12,5016889979);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (13,5016889986);
INSERT INTO Lehrer_StundenplanStunden(StundenplanStunden_ID,Lehrer_Matrikelnummer)
Values (14,5016889987);

GO
--Schueler
INSERT INTO Schueler(Matrikelnummer,Vorname,Nachname,Geburtsdatum,RFIDChip_UID,SchuhlKlassen_ID)
Values (2219135532,'Alexander','Genenger','´2003/03/03',00000011,1);

GO
--DatenSchueler
-- 2 Stunde
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 08:30:00',2219135532,'1');
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 08:46:00',2219135532,'1');
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 08:50:50',2219135532,'1');
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 09:15:00',2219135532,'1');

-- 3-4 Stunde
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 09:40:00',2219135532,'2');
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 11:10:00',2219135532,'2');

-- 5-6 Stunde
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 11:30:00',2219135532,'2');
INSERT INTO DatenSchueler(DatumVon,Schueler_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 13:00:00',2219135532,'2');

GO
--DatenLehrer
INSERT INTO DatenLehrer(DatumVon,Lehrer_Matrikelnummer,RFIDLeser_ID)
Values ('2022/01/17 08:30:00',5016889981,1);
GO