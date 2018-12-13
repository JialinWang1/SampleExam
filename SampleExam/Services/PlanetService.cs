using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SampleExam.Models;

namespace SampleExam
{
    internal class PlanetService : IPlanetService
    {
        private readonly ApplicationContext _applicationContext;

        public PlanetService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public List<Planet> GetPlanetList()
        {
            return _applicationContext.Planets.ToList();
        }

        public SpaceShip GetSpaceShip()
        {
            return _applicationContext.SpaceShip.Include(x => x.Planet).ToList()[0];
        }

        public void SetPlanet(long id)
        {
            _applicationContext.SpaceShip.ToList()[0].Planet = _applicationContext.Planets.Find(id);
            _applicationContext.SaveChanges();
        }

        public void ToShip(long id)
        {
            var planet = _applicationContext.Planets.Find(id);
            var ship = _applicationContext.SpaceShip.ToList()[0];
            var gap = ship.MaxCapacity - ship.Utilization;

            if (planet.Population <= gap)
            {
                ship.Utilization += (int)planet.Population;

                planet.Population = 0;
            }
            else
            {
                planet.Population -= gap;
                ship.Utilization += gap;
            }
            _applicationContext.SaveChanges();
        }

        public void ToPlanet(long id)
        {
            var planet = _applicationContext.Planets.Find(id);
            var ship = _applicationContext.SpaceShip.ToList()[0];
            planet.Population += ship.Utilization;
            ship.Utilization = 0;
            _applicationContext.SaveChanges();
        }

        public TopThree TopThree()
        {
            var list = _applicationContext.Planets.OrderByDescending(x => x.Population).Take(3).ToList();
            return new TopThree
            {
                Planets = list
            };
        }

        public void Remove()
        {
            _applicationContext.SpaceShip.Remove(_applicationContext.SpaceShip.First());
            _applicationContext.SaveChanges();
        }
        public void Add(SpaceShip ship)
        {
            _applicationContext.SpaceShip.Add(new SpaceShip
            {
                MaxCapacity = 60,
                Planet = _applicationContext.Planets.First(),
                Utilization = 0

            });
            _applicationContext.SaveChanges();
        }
    }
}