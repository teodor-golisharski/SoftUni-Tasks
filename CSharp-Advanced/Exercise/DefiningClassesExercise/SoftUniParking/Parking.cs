using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftUniParking
{
    public class Parking
    {
        public Parking(int capacity)
        {
            this.capacity = capacity;
            this.Cars = new List<Car>();
        }

        private List<Car> cars;
        private int capacity;
        public List<Car> Cars
        {
            get { return this.cars; }
            set { this.cars = value; }
        }
        public int Count
        {
            get { return this.cars.Count; }
        }

        public string AddCar(Car car)
        {
            if (this.ContainsCar(car.RegistrationNumber))
            {
                return "Car with that registration number, already exists!";
            }
            else if (this.Count >= this.capacity)
            {
               return "Parking is full!";
            }
            else
            {
                cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";
            }
        }
        public string RemoveCar(string registrationNumber)
        {
            if (!this.ContainsCar(registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car car = cars.Find(x => x.RegistrationNumber == registrationNumber);
                cars.Remove(car);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            return cars.Find(x => x.RegistrationNumber == registrationNumber);
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (var item in registrationNumbers)
            {
                if(cars.Any(x => x.RegistrationNumber == item))
                {
                    cars.Remove(cars.Find(x => x.RegistrationNumber == item));
                }
            }
        }


        private bool ContainsCar(string plate)
        {
            foreach (var item in this.cars)
            {
                if (item.RegistrationNumber == plate)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
