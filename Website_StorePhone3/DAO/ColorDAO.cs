using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Website_StorePhone3.Models.Entities;
using Website_StorePhone3.Models.db;
namespace Website_StorePhone3.DAO
{
    public class ColorDAO
    {
        dotnetstorephoneEntities1 db = new dotnetstorephoneEntities1();

        public List<Color> getListColor()
        {
            List<Color> colors = new List<Color>();

            String sql = "SELECT* FROM `color` WHERE color.activeFlag = 1";

            List<color> listcolors = db.colors.SqlQuery(sql).ToList<color>();
            foreach (color c in listcolors)
            {
                colors.Add(new Color(c.id,c.name));
            }
            return colors;

        }

    }
}