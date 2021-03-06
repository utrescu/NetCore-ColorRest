
using System.Collections.Generic;
using System.Linq;
using colorsRest.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace colorsRest.Tests.UnitTests
{
    public class Helper
    {
        protected Helper()
        {
        }
        public static List<Color> TestColors
        {
            get
            {
                var colors = new List<Color>();
                colors.Add(new Color
                {
                    Nom = "vermell",
                    Id = 1,
                    Rgb = "#FF0000"
                });

                colors.Add(new Color
                {
                    Nom = "verd",
                    Id = 2,
                    Rgb = "#00FF00"
                });

                colors.Add(new Color
                {
                    Nom = "beix",
                    Id = 3,
                    Rgb = "#F2F2DF"
                });

                return colors;
            }
        }

        public static Mock<DbSet<T>> CreateDbSetMock<T>(IEnumerable<T> elements) where T : class
        {
            var elementsAsQueryable = elements.AsQueryable();
            var dbSetMock = new Mock<DbSet<T>>();

            dbSetMock.As<IQueryable<T>>().Setup(m => m.Provider).Returns(elementsAsQueryable.Provider);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.Expression).Returns(elementsAsQueryable.Expression);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.ElementType).Returns(elementsAsQueryable.ElementType);
            dbSetMock.As<IQueryable<T>>().Setup(m => m.GetEnumerator()).Returns(elementsAsQueryable.GetEnumerator());

            return dbSetMock;
        }
    }
}