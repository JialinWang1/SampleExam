using System.Collections.Generic;
using SampleExam.Models;

namespace SampleExam
{
    public interface IPlanetService
    {
        List<Planet> GetPlanetList();
        void Add(SpaceShip ship);
        void Remove();
        SpaceShip GetSpaceShip();
        void SetPlanet(long id);
        void ToShip(long id);
        void ToPlanet(long id);
        TopThree TopThree();
    }
}
