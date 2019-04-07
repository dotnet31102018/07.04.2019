  CREATE TABLE COUNTRY(
            ID INT PRIMARY KEY NOT NULL,
            NAME TEXT NOT NULL,
            SIZE_KM INT,
            BIRTH_YEAR INT,
            CAPITALCITY_ID INT UNIQUE,
            FOREIGN KEY(CAPITALCITY_ID) REFERENCES CAPITALCITY(ID));

            CREATE TABLE CAPITALCITY(
            ID INT PRIMARY KEY NOT NULL,
            NAME TEXT NOT NULL,
            NUMCITIZENS INT,
            COUNTRY_ID INT UNIQUE,
            FOREIGN KEY(COUNTRY_ID) REFERENCES COUNTRY(ID));
