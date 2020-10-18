using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazorWebApplication.MyDbContexts
{
    /// <summary>
    /// Строка таблицы бд, связывающая песни и их жанры
    /// </summary>
    public class GenreTextEntity
    {
        public int GenreID { get; set; }

        public GenreEntity GenreInGenreText { get; set; }

        public int TextID { get; set; }

        public TextEntity TextInGenreText { get; set; }
    }
}
