-- Created by Vertabelo (http://vertabelo.com)
-- Last modification date: 2022-01-20 19:43:03.423

-- tables
-- Table: Daten
CREATE TABLE Daten (
    ID int  NOT NULL,
    DatumVon datetime  NOT NULL,
    DatumBis datetime  NOT NULL,
    Schueler_Matrikelnummer int  NOT NULL,
    RFIDLeser_Name varchar(50)  NOT NULL,
    CONSTRAINT Daten_pk PRIMARY KEY  (ID)
);

-- Table: Fehlzeiten
CREATE TABLE Fehlzeiten (
    ID int  NOT NULL,
    DatumVon datetime  NOT NULL,
    DatumBis datetime  NOT NULL,
    Lehrer_Matrikelnummer int  NOT NULL,
    Schueler_Matrikelnummer int  NOT NULL,
    CONSTRAINT Fehlzeiten_pk PRIMARY KEY  (ID)
);

-- Table: Klassen
CREATE TABLE Klassen (
    Name varchar(50)  NOT NULL,
    Stundenplan_ID int  NOT NULL,
    CONSTRAINT Klassen_pk PRIMARY KEY  (Name)
);

-- Table: Lehrer
CREATE TABLE Lehrer (
    Matrikelnummer int  NOT NULL,
    Vorname varchar(50)  NOT NULL,
    Nachname varchar(50)  NOT NULL,
    Geburtsdatum date  NOT NULL,
    Kuerzel varchar(50)  NOT NULL,
    RFIDChip_UID int  NOT NULL,
    Klassen_Name varchar(50)  NOT NULL,
    CONSTRAINT Lehrer_pk PRIMARY KEY  (Matrikelnummer)
);

-- Table: Lehrer_Klassen
CREATE TABLE Lehrer_Klassen (
    Lehrer_Matrikelnummer int  NOT NULL,
    Klassen_Name varchar(50)  NOT NULL,
    CONSTRAINT Lehrer_Klassen_pk PRIMARY KEY  (Lehrer_Matrikelnummer,Klassen_Name)
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
    Name varchar(50)  NOT NULL,
    Number int  NOT NULL,
    CONSTRAINT RFIDLeser_pk PRIMARY KEY  (Name)
);

-- Table: RFIDleser_Klassen
CREATE TABLE RFIDleser_Klassen (
    RFIDLeser_Name varchar(50)  NOT NULL,
    Klassen_Name varchar(50)  NOT NULL,
    CONSTRAINT RFIDleser_Klassen_pk PRIMARY KEY  (Klassen_Name,RFIDLeser_Name)
);

-- Table: Schueler
CREATE TABLE Schueler (
    Matrikelnummer int  NOT NULL,
    Vorname varchar(50)  NULL,
    Nachname varchar(50)  NULL,
    Geburtsdatum date  NULL,
    RFIDChip_UID int  NOT NULL,
    Klassen_Name varchar(50)  NOT NULL,
    CONSTRAINT Schueler_pk PRIMARY KEY  (Matrikelnummer)
);

-- Table: Stundenplan
CREATE TABLE Stundenplan (
    ID int  NOT NULL,
    StundenplanStunden_ID int  NOT NULL,
    CONSTRAINT Stundenplan_pk PRIMARY KEY  (ID)
);

-- Table: StundenplanStunden
CREATE TABLE StundenplanStunden (
    ID int  NOT NULL,
    Name varchar(50)  NOT NULL,
    DateTimeVon datetime  NOT NULL,
    DateTimeBis datetime  NOT NULL,
    CONSTRAINT StundenplanStunden_pk PRIMARY KEY  (ID)
);

-- foreign keys
-- Reference: Daten_RFIDLeser (table: Daten)
ALTER TABLE Daten ADD CONSTRAINT Daten_RFIDLeser
    FOREIGN KEY (RFIDLeser_Name)
    REFERENCES RFIDLeser (Name);

-- Reference: Fehlzeiten_Lehrer (table: Fehlzeiten)
ALTER TABLE Fehlzeiten ADD CONSTRAINT Fehlzeiten_Lehrer
    FOREIGN KEY (Lehrer_Matrikelnummer)
    REFERENCES Lehrer (Matrikelnummer);

-- Reference: Fehlzeiten_Schueler (table: Fehlzeiten)
ALTER TABLE Fehlzeiten ADD CONSTRAINT Fehlzeiten_Schueler
    FOREIGN KEY (Schueler_Matrikelnummer)
    REFERENCES Schueler (Matrikelnummer);

-- Reference: Klassen_Stundenplan (table: Klassen)
ALTER TABLE Klassen ADD CONSTRAINT Klassen_Stundenplan
    FOREIGN KEY (Stundenplan_ID)
    REFERENCES Stundenplan (ID);

-- Reference: Lehrer_Klassen (table: Lehrer)
ALTER TABLE Lehrer ADD CONSTRAINT Lehrer_Klassen
    FOREIGN KEY (Klassen_Name)
    REFERENCES Klassen (Name);

-- Reference: Lehrer_Klassen_Klassen (table: Lehrer_Klassen)
ALTER TABLE Lehrer_Klassen ADD CONSTRAINT Lehrer_Klassen_Klassen
    FOREIGN KEY (Klassen_Name)
    REFERENCES Klassen (Name);

-- Reference: Lehrer_Klassen_Lehrer (table: Lehrer_Klassen)
ALTER TABLE Lehrer_Klassen ADD CONSTRAINT Lehrer_Klassen_Lehrer
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

-- Reference: RFIDleser_Klassen_Klassen (table: RFIDleser_Klassen)
ALTER TABLE RFIDleser_Klassen ADD CONSTRAINT RFIDleser_Klassen_Klassen
    FOREIGN KEY (Klassen_Name)
    REFERENCES Klassen (Name);

-- Reference: RFIDleser_Klassen_RFIDLeser (table: RFIDleser_Klassen)
ALTER TABLE RFIDleser_Klassen ADD CONSTRAINT RFIDleser_Klassen_RFIDLeser
    FOREIGN KEY (RFIDLeser_Name)
    REFERENCES RFIDLeser (Name);

-- Reference: Schueler_Klassen (table: Schueler)
ALTER TABLE Schueler ADD CONSTRAINT Schueler_Klassen
    FOREIGN KEY (Klassen_Name)
    REFERENCES Klassen (Name);

-- Reference: Schueler_RFIDChip (table: Schueler)
ALTER TABLE Schueler ADD CONSTRAINT Schueler_RFIDChip
    FOREIGN KEY (RFIDChip_UID)
    REFERENCES RFIDChip (UID);

-- Reference: Stundenplan_StundenplanStunden (table: Stundenplan)
ALTER TABLE Stundenplan ADD CONSTRAINT Stundenplan_StundenplanStunden
    FOREIGN KEY (StundenplanStunden_ID)
    REFERENCES StundenplanStunden (ID);

-- Reference: Table_15_Schueler (table: Daten)
ALTER TABLE Daten ADD CONSTRAINT Table_15_Schueler
    FOREIGN KEY (Schueler_Matrikelnummer)
    REFERENCES Schueler (Matrikelnummer);

-- End of file.

