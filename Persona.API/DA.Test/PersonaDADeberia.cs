using Abstracciones.DA;
using Abstracciones.Interfaces.DA;
using Abstracciones.Modelos;
using KellermanSoftware.CompareNetObjects;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Reflection.Metadata;
using Moq;

namespace DA.Test
{
    [TestClass]
    public class PersonaDADeberia
    {
        [TestMethod]
        public async Task ConsultarPersonas()
        {
            //Arrange - Esperado
                IEnumerable<Persona> esperado = Obtener_esperado_Obtener_Personas();


            IRepositorioEF repositoriosEF = ObtenerSubstitutoRepositorioEF();

            IPersonaDA sut = new PersonaDA(repositoriosEF);
            IEnumerable<Persona> obtenido = await sut.Obtener();

            //Assert - Comparación
            CompareLogic compareLogic = new CompareLogic();
            ComparisonResult result = compareLogic.Compare(obtenido, esperado);
            Assert.IsTrue(result.AreEqual);
        }

        private IRepositorioEF ObtenerSubstitutoRepositorioEF()
        {

            var data = new List<Persona>
  {
new Persona { Identificacion="123", Id=Guid.Parse("0980447e-da5c-4dc5-9c2e-9a63f3b63a9f") },
    new Persona { Identificacion="124",Id=Guid.Parse("0980447e-da5c-4dc5-9c2e-9a63f3b63a9a") },
    new Persona { Identificacion="125",Id=Guid.Parse("0980447e-da5c-4dc5-9c2e-9a63f3b63a9e") }
  }.AsAsyncQueryable();

            var mockSet = new Mock<DbSet<Persona>>();
            mockSet.As<IQueryable<Persona>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<Persona>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<Persona>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<Persona>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());




            var mockContext = new Mock<IRepositorioEF>();
            mockContext.Setup(m => m.Personas).Returns(mockSet.Object);

            return mockContext.Object;
        }

        private IEnumerable<Persona> Obtener_esperado_Obtener_Personas()
        {
            return new List<Persona>
{
new Persona { Identificacion="123", Id=Guid.Parse("0980447e-da5c-4dc5-9c2e-9a63f3b63a9f") },
    new Persona { Identificacion="124",Id=Guid.Parse("0980447e-da5c-4dc5-9c2e-9a63f3b63a9a") },
    new Persona { Identificacion="125",Id=Guid.Parse("0980447e-da5c-4dc5-9c2e-9a63f3b63a9e") },
};
        }
    }
}