using GuildCars.Data.Interfaces;
using GuildCars.Models.Tables;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.TestRepos
{
    public class ColorRepositoryTEST : IColorRepository
    {
        private static List<Color> _colors;

        public ColorRepositoryTEST()
        {
            _colors = new List<Color>
            {
                new Color {ColorId = 1, ColorName = "White"},
                new Color {ColorId = 2, ColorName = "Black"},
                new Color {ColorId = 3, ColorName = "Red"},
                new Color {ColorId = 4, ColorName = "Green"},
                new Color {ColorId = 5, ColorName = "Blue"},
                new Color {ColorId = 6, ColorName = "Purple"},
                new Color {ColorId = 7, ColorName = "Orange"},
                new Color {ColorId = 8, ColorName = "Yellow"},
                new Color {ColorId = 9, ColorName = "Pink"},
                new Color {ColorId = 10, ColorName = "Lime"}
            };
        }

        public Color Get(int id)
        {
            return _colors.SingleOrDefault(c => c.ColorId == id);
        }

        public List<Color> GetAll()
        {
            return _colors;
        }
    }
}
