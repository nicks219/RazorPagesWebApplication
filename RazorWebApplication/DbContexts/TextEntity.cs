using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RandomSongSearchEngine.DbContexts
{
    /// <summary>
    /// Строка таблицы бд с текстами песен
    /// </summary>
    public class TextEntity
    {
        public int TextID { get; set; }

        public string Title { get; set; }

        public string Song { get; set; }

        public ICollection<GenreTextEntity> GenreTextInText { get; set; }
    }
}