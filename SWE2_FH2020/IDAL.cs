﻿using System;
using System.Collections.Generic;
using System.Text;
using Npgsql;

namespace test_db_singleton
{
    public interface IDAL
    {
        public NpgsqlConnection initialize();
        List<Picture> getPictures();
        List<Photographer> getPhotographers();
        Picture getPicture(int ID);
        void save(Picture p);
        void delete(Picture p);

    }
}
