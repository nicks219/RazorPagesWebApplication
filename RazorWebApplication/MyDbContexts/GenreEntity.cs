using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApplication.MyDbContexts
{
    /// <summary>
    /// Строка таблицы бд с жанрами песен
    /// </summary>
    public class GenreEntity
    {
        public int GenreID { get; set; }

        public string Genre { get; set; }

        public ICollection<GenreTextEntity> GenreTextInGenre { get; set; }
    }
}
