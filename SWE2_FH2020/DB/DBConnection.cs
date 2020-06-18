using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace SWE2_FH2020
{
    public sealed class DBConnection : IDAL
    {
        DBConnection()
        {
        }
        private static readonly object padlock = new object();
        private static DBConnection instance = null;
        public static DBConnection Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new DBConnection();
                    }
                    return instance;
                }
            }
        }

        public NpgsqlConnection initialize()
        {
            string connstring = ConfigurationManager.AppSettings.Get("DBUrl");
            NpgsqlConnection db = new NpgsqlConnection(connstring);
            db.Open();
            return db;
        }
        public List<Picture> getPictures()
        {
            List<Picture> pictureList = new List<Picture>();
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_pic = new NpgsqlCommand("select * from picture left join fotograf on picture.fk_pk_fotograf_id=fotograf.pk_fotograf_id left join exif on picture.fk_pk_exif_id=exif.pk_exif_id left join iptc on picture.fk_pk_iptc_id=iptc.pk_iptc_id", db);
            try
            {
                cmd_pic.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader_pic = cmd_pic.ExecuteReader();
            cmd_pic.Dispose();
            while (reader_pic.Read())
            {
                Picture temp_pic = new Picture();
                temp_pic.setId(reader_pic.GetInt32(0));
                temp_pic.setDirectory(reader_pic.GetString(4));

                Exif temp_exif = new Exif();
                temp_exif.setId(reader_pic.GetInt32(1));
                temp_exif.setIsoSpeedRating(reader_pic.GetInt32(11));
                temp_exif.setMake(reader_pic.GetString(12));
                temp_exif.setDateTime(reader_pic.GetDateTime(13));
                temp_exif.setFlash(reader_pic.GetBoolean(14));
                temp_exif.setExposureTime(reader_pic.GetString(15));
                temp_pic.setExif(temp_exif);

                Iptc temp_iptc = new Iptc();
                temp_iptc.setId(reader_pic.GetInt32(2));
                temp_iptc.setDate(reader_pic.GetDateTime(17));
                temp_iptc.setTime(reader_pic.GetTimeSpan(18));
                temp_iptc.setByLine(reader_pic.GetString(19));
                temp_iptc.setCopyright(reader_pic.GetString(20));
                temp_pic.setIptc(temp_iptc);

                Photographer temp_photo = new Photographer();
                temp_photo.setId(reader_pic.GetInt32(3));
                temp_photo.setVorname(reader_pic.GetString(6));
                temp_photo.setNachname(reader_pic.GetString(7));
                temp_photo.setDate(reader_pic.GetDateTime(8));
                temp_photo.setNotiz(reader_pic.GetString(9));
                temp_pic.setPhotographer(temp_photo);
                pictureList.Add(temp_pic);
            }
            reader_pic.Close();
            return pictureList;
        }
        public List<Photographer> getPhotographers()
        {
            List<Photographer> photographerList = new List<Photographer>();
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_photo = new NpgsqlCommand("Select * from fotograf", db);
            try
            {
                cmd_photo.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader_photo = cmd_photo.ExecuteReader();
            cmd_photo.Dispose();
            while (reader_photo.Read())
            {
                Photographer temp_photo = new Photographer();
                temp_photo.setId(reader_photo.GetInt32(0));
                temp_photo.setVorname(reader_photo.GetString(1));
                temp_photo.setNachname(reader_photo.GetString(2));
                temp_photo.setDate(reader_photo.GetDateTime(3));
                if(!reader_photo.IsDBNull(4))
                    temp_photo.setNotiz(reader_photo.GetString(4));
                photographerList.Add(temp_photo);
            }
            reader_photo.Close();
            return photographerList;
        }

        public void deletePhotographer(string name)
        {
            string[] names = name.Split(' ');
            if(names.Length > 2)
            {
                names[0] = names[0] + " " + names[1];
                names[1] = names[2];
            }
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_delphoto = new NpgsqlCommand("DELETE FROM fotograf WHERE vorname = @p AND nachname = @q", db);
            cmd_delphoto.Parameters.AddWithValue("p", names[0]);
            cmd_delphoto.Parameters.AddWithValue("q", names[1]);
            try
            {
                cmd_delphoto.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            cmd_delphoto.ExecuteNonQuery();
            cmd_delphoto.Dispose();
        }

        public void addPhotographer(Photographer newPhotographer)
        {
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_addphoto = new NpgsqlCommand("INSERT INTO fotograf(vorname, nachname, geburtsdatum, notiz) values (@p, @q, @r, @s)", db);
            cmd_addphoto.Parameters.AddWithValue("p", newPhotographer.getVorname());
            cmd_addphoto.Parameters.AddWithValue("q", newPhotographer.getNachname());
            cmd_addphoto.Parameters.AddWithValue("r", newPhotographer.getDate());
            cmd_addphoto.Parameters.AddWithValue("s", newPhotographer.getNotiz());
            try
            {
                cmd_addphoto.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            cmd_addphoto.ExecuteNonQuery();
            cmd_addphoto.Dispose();
        }

        public IEnumerable<string> photographerList()
        {
            List<Photographer> stringList = getPhotographers();
            List<string> list = new List<string>();
            foreach (Photographer i in stringList)
            {
                string text = i.getVorname() + " " + i.getNachname();
                list.Add(text);
            }
            IEnumerable<string> test = list;
            return test;
        }

        public Picture getPicture(int ID)
        {
            Picture picture = new Picture();
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_pic = new NpgsqlCommand("select * from picture left join fotograf on picture.fk_pk_fotograf_id=fotograf.pk_fotograf_id left join exif on picture.fk_pk_exif_id=exif.pk_exif_id left join iptc on picture.fk_pk_iptc_id=iptc.pk_iptc_id WHERE picture_id = @q", db);
            cmd_pic.Parameters.AddWithValue("q", ID);
            try
            {
                cmd_pic.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader_pic = cmd_pic.ExecuteReader();
            cmd_pic.Dispose();
            while (reader_pic.Read())
            {
                picture.setId(reader_pic.GetInt32(0));
                picture.setDirectory(reader_pic.GetString(4));

                Exif temp_exif = new Exif();
                temp_exif.setId(reader_pic.GetInt32(1));
                temp_exif.setIsoSpeedRating(reader_pic.GetInt32(11));
                temp_exif.setMake(reader_pic.GetString(12));
                temp_exif.setDateTime(reader_pic.GetDateTime(13));
                temp_exif.setFlash(reader_pic.GetBoolean(14));
                temp_exif.setExposureTime(reader_pic.GetString(15));
                picture.setExif(temp_exif);

                Iptc temp_iptc = new Iptc();
                temp_iptc.setId(reader_pic.GetInt32(2));
                temp_iptc.setDate(reader_pic.GetDateTime(17));
                temp_iptc.setTime(reader_pic.GetTimeSpan(18));
                temp_iptc.setByLine(reader_pic.GetString(19));
                temp_iptc.setCopyright(reader_pic.GetString(20));
                picture.setIptc(temp_iptc);

                Photographer temp_photo = new Photographer();
                temp_photo.setId(reader_pic.GetInt32(3));
                temp_photo.setVorname(reader_pic.GetString(6));
                temp_photo.setNachname(reader_pic.GetString(7));
                temp_photo.setDate(reader_pic.GetDateTime(8));
                temp_photo.setNotiz(reader_pic.GetString(9));
                picture.setPhotographer(temp_photo);
            }
            reader_pic.Close();
            return picture;
        }
        public void savePicture(Picture p)
        {
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_exif = new NpgsqlCommand("Update exif SET iso_speed_ratings = @p, make = @q, date_time = @r, flash = @s, exposuretime = @t WHERE pk_exif_id = @u", db);
            cmd_exif.Parameters.AddWithValue("p", p.getExif().getIsoSpeedRating());
            cmd_exif.Parameters.AddWithValue("q", p.getExif().getMake());
            cmd_exif.Parameters.AddWithValue("r", p.getExif().getDateTime());
            cmd_exif.Parameters.AddWithValue("s", p.getExif().getFlash());
            cmd_exif.Parameters.AddWithValue("t", p.getExif().getExposureTime());
            cmd_exif.Parameters.AddWithValue("u", p.getExif().getId());
            cmd_exif.ExecuteNonQuery();
            cmd_exif.Dispose();

            NpgsqlCommand cmd_iptc = new NpgsqlCommand("Update iptc SET date_created = @p, time_created = @q, by_line = @r, copyright = @s WHERE pk_iptc_id = @t", db);
            cmd_iptc.Parameters.AddWithValue("p", p.getIptc().getDate());
            cmd_iptc.Parameters.AddWithValue("q", p.getIptc().getTime());
            cmd_iptc.Parameters.AddWithValue("r", p.getIptc().getByLine());
            cmd_iptc.Parameters.AddWithValue("s", p.getIptc().getCopyright());
            cmd_iptc.Parameters.AddWithValue("t", p.getIptc().getId());
            cmd_iptc.ExecuteNonQuery();
            cmd_iptc.Dispose();

            NpgsqlCommand cmd_pic = new NpgsqlCommand("Update picture SET fk_pk_exif_id = @p, fk_pk_iptc_id = @q, fk_pk_fotograf_id = @r, directory = @s WHERE picture_id = @t", db);
            cmd_pic.Parameters.AddWithValue("p", p.getExif().getId());
            cmd_pic.Parameters.AddWithValue("q", p.getIptc().getId());
            cmd_pic.Parameters.AddWithValue("r", p.getPhotographer().getId());
            cmd_pic.Parameters.AddWithValue("s", p.getDirectory());
            cmd_pic.Parameters.AddWithValue("t", p.getId());
            cmd_pic.ExecuteNonQuery();
            cmd_pic.Dispose();
        }
        public void setupPictures(List<Picture> pic)
        {
            NpgsqlConnection db = DBConnection.Instance.initialize();
            foreach (Picture p in pic)
            {
                NpgsqlCommand cmd_exif = new NpgsqlCommand("INSERT INTO exif(iso_speed_ratings, make, date_time, flash, exposuretime) values (@p, @q, @r, @s, @t)", db);
                cmd_exif.Parameters.AddWithValue("p", p.getExif().getIsoSpeedRating());
                cmd_exif.Parameters.AddWithValue("q", p.getExif().getMake());
                cmd_exif.Parameters.AddWithValue("r", p.getExif().getDateTime());
                cmd_exif.Parameters.AddWithValue("s", p.getExif().getFlash());
                cmd_exif.Parameters.AddWithValue("t", p.getExif().getExposureTime());
                cmd_exif.Parameters.AddWithValue("u", p.getExif().getId());
                cmd_exif.ExecuteNonQuery();
                cmd_exif.Dispose();

                NpgsqlCommand cmd_iptc = new NpgsqlCommand("INSERT INTO iptc(date_created, time_created, by_line, copyright) values (@p, @q, @r, @s)", db);
                cmd_iptc.Parameters.AddWithValue("p", p.getIptc().getDate());
                cmd_iptc.Parameters.AddWithValue("q", p.getIptc().getTime());
                cmd_iptc.Parameters.AddWithValue("r", p.getIptc().getByLine());
                cmd_iptc.Parameters.AddWithValue("s", p.getIptc().getCopyright());
                cmd_iptc.Parameters.AddWithValue("t", p.getIptc().getId());
                cmd_iptc.ExecuteNonQuery();
                cmd_iptc.Dispose();

                NpgsqlCommand cmd_pic = new NpgsqlCommand("INSERT INTO picture (fk_pk_exif_id, fk_pk_iptc_id, directory) values (@p, @q, @r)", db);
                cmd_pic.Parameters.AddWithValue("p", p.getExif().getId());
                cmd_pic.Parameters.AddWithValue("q", p.getIptc().getId());
                cmd_pic.Parameters.AddWithValue("r", p.getDirectory());
                cmd_pic.ExecuteNonQuery();
                cmd_pic.Dispose();
            }
        }
        public void editPhotographer(Photographer photogr)
        {
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_editp = new NpgsqlCommand("UPDATE fotograf SET vorname = @p , nachname = @q , geburtsdatum = @r , notiz = @s WHERE pk_fotograf_id = @t", db);
            cmd_editp.Parameters.AddWithValue("p", photogr.getVorname());
            cmd_editp.Parameters.AddWithValue("q", photogr.getNachname());
            cmd_editp.Parameters.AddWithValue("r", photogr.getDate());
            cmd_editp.Parameters.AddWithValue("s", photogr.getNotiz());
            cmd_editp.Parameters.AddWithValue("t", photogr.getId());
            cmd_editp.ExecuteNonQuery();
            cmd_editp.Dispose();
        }
        public void dropRecreateTables()
        {
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_picture_drop = new NpgsqlCommand("DROP TABLE IF EXISTS picture cascade;", db);
            cmd_picture_drop.ExecuteNonQuery();
            cmd_picture_drop.Dispose();

            NpgsqlCommand cmd_exif_drop = new NpgsqlCommand("DROP TABLE IF EXISTS exif cascade;", db);
            cmd_exif_drop.ExecuteNonQuery();
            cmd_exif_drop.Dispose();

            NpgsqlCommand cmd_iptc_drop = new NpgsqlCommand("DROP TABLE IF EXISTS iptc cascade;", db);
            cmd_iptc_drop.ExecuteNonQuery();
            cmd_iptc_drop.Dispose();

            NpgsqlCommand cmd_foto_drop = new NpgsqlCommand("DROP TABLE IF EXISTS fotograf cascade;", db);
            cmd_foto_drop.ExecuteNonQuery();
            cmd_foto_drop.Dispose();

            NpgsqlCommand cmd_foto_create = new NpgsqlCommand("CREATE TABLE fotograf (pk_fotograf_id serial PRIMARY KEY, vorname varchar(100) NOT NULL, nachname varchar(50) NOT NULL, geburtsdatum DATE NOT NULL, notiz varchar); ", db);
            cmd_foto_create.ExecuteNonQuery();
            cmd_foto_create.Dispose();

            NpgsqlCommand cmd_exif_create = new NpgsqlCommand("CREATE TABLE exif (pk_exif_id serial PRIMARY KEY, iso_speed_ratings INT, make VARCHAR, date_time DATE, flash BOOLEAN, exposuretime VARCHAR); ", db);
            cmd_exif_create.ExecuteNonQuery();
            cmd_exif_create.Dispose();

            NpgsqlCommand cmd_iptc_create = new NpgsqlCommand("CREATE TABLE iptc (pk_iptc_id serial PRIMARY KEY, date_created DATE, time_created TIME, by_line VARCHAR, copyright VARCHAR); ", db);
            cmd_iptc_create.ExecuteNonQuery();
            cmd_iptc_create.Dispose();

            NpgsqlCommand cmd_picture_create = new NpgsqlCommand("CREATE TABLE picture (picture_id serial PRIMARY KEY, fk_pk_exif_id int NOT NULL, fk_pk_iptc_id int NOT NULL, fk_pk_fotograf_id int, directory VARCHAR NOT NULL, CONSTRAINT \"ck_pk_exif_id\" FOREIGN KEY(\"fk_pk_exif_id\") REFERENCES \"exif\"(\"pk_exif_id\"), CONSTRAINT \"ck_pk_iptc_id\" FOREIGN KEY(\"fk_pk_iptc_id\") REFERENCES \"iptc\"(\"pk_iptc_id\"), CONSTRAINT \"ck_pk_fotograf_id\" FOREIGN KEY(\"fk_pk_fotograf_id\") REFERENCES \"fotograf\"(\"pk_fotograf_id\") ON DELETE SET NULL); ", db);
            cmd_picture_create.ExecuteNonQuery();
            cmd_picture_create.Dispose();

            NpgsqlCommand cmd_addphoto = new NpgsqlCommand("INSERT INTO fotograf(vorname, nachname, geburtsdatum, notiz) values (@p, @q, @r, @s)", db);
            cmd_addphoto.Parameters.AddWithValue("p", "Marius");
            cmd_addphoto.Parameters.AddWithValue("q", "Hochwald");
            cmd_addphoto.Parameters.AddWithValue("r", new DateTime(2012,2,2));
            cmd_addphoto.Parameters.AddWithValue("s", "Ich bin eine Notiz");
            try
            {
                cmd_addphoto.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            cmd_addphoto.ExecuteNonQuery();
            cmd_addphoto.Dispose();

            NpgsqlCommand cmd_addphotoTwo = new NpgsqlCommand("INSERT INTO fotograf(vorname, nachname, geburtsdatum, notiz) values (@p, @q, @r, @s)", db);
            cmd_addphotoTwo.Parameters.AddWithValue("p", "Daniel");
            cmd_addphotoTwo.Parameters.AddWithValue("q", "Krottendorfer");
            cmd_addphotoTwo.Parameters.AddWithValue("r", new DateTime(2013, 4, 9));
            cmd_addphotoTwo.Parameters.AddWithValue("s", "Ich bin eine neue Notiz");
            try
            {
                cmd_addphotoTwo.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            cmd_addphotoTwo.ExecuteNonQuery();
            cmd_addphotoTwo.Dispose();

            NpgsqlCommand cmd_addphotoThree = new NpgsqlCommand("INSERT INTO fotograf(vorname, nachname, geburtsdatum, notiz) values (@p, @q, @r, @s)", db);
            cmd_addphotoThree.Parameters.AddWithValue("p", "Leo");
            cmd_addphotoThree.Parameters.AddWithValue("q", "Gruber");
            cmd_addphotoThree.Parameters.AddWithValue("r", new DateTime(2001, 4, 9));
            cmd_addphotoThree.Parameters.AddWithValue("s", "Ich bin eine eine komische Notiz.");
            try
            {
                cmd_addphotoThree.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            cmd_addphotoThree.ExecuteNonQuery();
            cmd_addphotoThree.Dispose();
        }
    }
}
