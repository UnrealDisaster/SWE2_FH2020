using System;
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
            string connstring = "Server=127.0.0.1; Port=5432; User ID=postgres; Password=postgres;Database=postgres;";
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
        public void save(Picture p)
        {
            NpgsqlConnection db = DBConnection.Instance.initialize();
            NpgsqlCommand cmd_exif_check = new NpgsqlCommand("Select * from exif WHERE pk_exif_id = @p", db);
            cmd_exif_check.Parameters.AddWithValue("p", p.getExif().getId());
            try
            {
                cmd_exif_check.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader_exif_check = cmd_exif_check.ExecuteReader();
            cmd_exif_check.Dispose();
            if(!reader_exif_check.Read())
            {
                reader_exif_check.Close();
                NpgsqlCommand cmd_exif = new NpgsqlCommand("INSERT INTO exif(iso_speed_ratings, make, date_time, flash, exposuretime) values (@p, @q, @r, @s, @t", db);
                cmd_exif.Parameters.AddWithValue("p", p.getExif().getIsoSpeedRating());
                cmd_exif.Parameters.AddWithValue("q", p.getExif().getMake());
                cmd_exif.Parameters.AddWithValue("r", p.getExif().getDateTime());
                cmd_exif.Parameters.AddWithValue("s", p.getExif().getFlash());
                cmd_exif.Parameters.AddWithValue("t", p.getExif().getExposureTime());
                cmd_exif.ExecuteNonQuery();
                cmd_exif.Dispose();
            }

            NpgsqlCommand cmd_iptc_check = new NpgsqlCommand("Select * from iptc WHERE pk_iptc_id = @p", db);
            cmd_iptc_check.Parameters.AddWithValue("p", p.getIptc().getId());
            try
            {
                cmd_iptc_check.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader_iptc_check = cmd_iptc_check.ExecuteReader();
            cmd_iptc_check.Dispose();
            if (!reader_iptc_check.Read())
            {
                reader_iptc_check.Close();
                NpgsqlCommand cmd_iptc = new NpgsqlCommand("INSERT INTO iptc(date_created, time_created, by_line, copyright) values (@p, @q, @r, @s", db);
                cmd_iptc.Parameters.AddWithValue("p", p.getIptc().getDate());
                cmd_iptc.Parameters.AddWithValue("q", p.getIptc().getTime());
                cmd_iptc.Parameters.AddWithValue("r", p.getIptc().getByLine());
                cmd_iptc.Parameters.AddWithValue("s", p.getIptc().getCopyright());
                cmd_iptc.ExecuteNonQuery();
                cmd_iptc.Dispose();
            }

            NpgsqlCommand cmd_pic_check = new NpgsqlCommand("Select * from picture WHERE picture_id = @p", db);
            cmd_pic_check.Parameters.AddWithValue("p", p.getId());
            try
            {
                cmd_pic_check.Prepare();
            }
            catch
            {
                Console.WriteLine("Invalid query");
            }
            NpgsqlDataReader reader_pic_check = cmd_pic_check.ExecuteReader();
            cmd_pic_check.Dispose();
            if (!reader_pic_check.Read())
            {
                reader_pic_check.Close();
                NpgsqlCommand cmd_pic = new NpgsqlCommand("INSERT INTO picture (fk_pk_exif_id, fk_pk_iptc_id, fk_pk_fotograf_id, directory) values (@p, @q, @r, @s", db);
                cmd_pic.Parameters.AddWithValue("p", p.getExif().getId());
                cmd_pic.Parameters.AddWithValue("q", p.getIptc().getId());
                cmd_pic.Parameters.AddWithValue("r", p.getPhotographer().getId());
                cmd_pic.Parameters.AddWithValue("s", p.getDirectory());
            }
        }
        public void delete(Picture p)
        {

        }


    }
}
