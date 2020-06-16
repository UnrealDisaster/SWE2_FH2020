CREATE TABLE fotograf (
    pk_fotograf_id serial PRIMARY KEY,
	vorname varchar(100) NOT NULL,
	nachname varchar(50) NOT NULL,
    geburtsdatum DATE NOT NULL,
    notiz varchar,
	CONSTRAINT "ch_geburtsdatum" CHECK (geburtsdatum <= CURRENT_DATE)
);

CREATE TABLE exif (
    pk_exif_id serial PRIMARY KEY,
	iso_speed_ratings INT,
	make VARCHAR,
    date_time DATE,
    flash BOOLEAN,
	exposuretime VARCHAR
);

CREATE TABLE iptc (
    pk_iptc_id serial PRIMARY KEY,
	date_created DATE,
	time_created TIME,
    by_line VARCHAR,
    copyright VARCHAR
);

CREATE TABLE picture (
    picture_id serial PRIMARY KEY,
	fk_pk_exif_id int NOT NULL,
	fk_pk_iptc_id int NOT NULL,
	fk_pk_fotograf_id int NOT NULL,
	directory VARCHAR NOT NULL,
	CONSTRAINT "ck_pk_exif_id" FOREIGN KEY ("fk_pk_exif_id") REFERENCES "exif" ("pk_exif_id"),
	CONSTRAINT "ck_pk_iptc_id" FOREIGN KEY ("fk_pk_iptc_id") REFERENCES "iptc" ("pk_iptc_id"),
	CONSTRAINT "ck_pk_fotograf_id" FOREIGN KEY ("fk_pk_fotograf_id") REFERENCES "fotograf" ("pk_fotograf_id")
);

INSERT INTO fotograf (vorname,nachname,geburtsdatum)
VALUES
('pepe','thefrog','3.2.2012'),
('Daniel','Krottendorfer','2.23.1996'),
('Marius','Hochwald','6.9.420');