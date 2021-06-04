using System.Collections.Generic;

namespace RandomSongSearchEngine.DatabaseEntities
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
