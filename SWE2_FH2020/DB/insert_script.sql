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
	fk_pk_fotograf_id int,
	directory VARCHAR NOT NULL,
	CONSTRAINT "ck_pk_exif_id" FOREIGN KEY ("fk_pk_exif_id") REFERENCES "exif" ("pk_exif_id"),
	CONSTRAINT "ck_pk_iptc_id" FOREIGN KEY ("fk_pk_iptc_id") REFERENCES "iptc" ("pk_iptc_id"),
	CONSTRAINT "ck_pk_fotograf_id" FOREIGN KEY ("fk_pk_fotograf_id") REFERENCES "fotograf" ("pk_fotograf_id") ON DELETE SET NULL
);

/*
INSERT INTO fotograf (vorname,nachname,geburtsdatum)
VALUES
('pepe','thefrog','3.2.2012'),
('Daniel','Krottendorfer','2.23.1996'),
('Marius','Hochwald','6.9.420');
*/

select * from picture left join fotograf on picture.fk_pk_fotograf_id=fotograf.pk_fotograf_id left join exif on picture.fk_pk_exif_id=exif.pk_exif_id left join iptc on picture.fk_pk_iptc_id=iptc.pk_iptc_id ;

insert into fotograf (vorname, nachname, geburtsdatum, notiz) values ('Marius', 'Hochwald', '2012-02-02', 'Ich bin ein Tester');
insert into exif(iso_speed_ratings, make, date_time, flash, exposuretime) values (400, 'Canon', '2011-01-01', true, '1/30 sec');
insert into iptc(date_created, time_created, by_line, copyright) values ('2011-01-01', '15:05:20', 'Marius Hochwald', 'Hochwald Copyright GmbH');
insert into picture (fk_pk_exif_id, fk_pk_iptc_id, fk_pk_fotograf_id, directory) values (1,1,1, 'pictures/test.png');

insert into fotograf (vorname, nachname, geburtsdatum, notiz) values ('Daniel', 'Krottendorfer', '2013-12-02', 'Ich bin ein Fotografierer');
insert into exif(iso_speed_ratings, make, date_time, flash, exposuretime) values (600, 'Nikon', '2010-02-03', true, '1/20 sec');
insert into iptc(date_created, time_created, by_line, copyright) values ('2010-02-03', '10:11:46', 'Daniel Krottendorfer', 'Krottendorfer Copyright GmbH');
insert into picture (fk_pk_exif_id, fk_pk_iptc_id, fk_pk_fotograf_id, directory) values (2,2,2, 'pictures/test2.png');