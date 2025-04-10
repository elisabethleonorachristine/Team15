using System;
using System.Collections.Generic;
using System.IO;
using CarApp.Vehicles;

namespace CarApp
{
    public class DataHandler
    {
        public string FilePath { get; set; }

        public DataHandler(string filePath)
        {
            FilePath = filePath;
        }

        public void SaveCars(List<Car> cars)
        {
            StreamWriter writer = null;

            try
            {
                writer = new StreamWriter(FilePath);

                foreach (Car car in cars)
                {
                    writer.WriteLine(car.ToString());
                    foreach (Trip trip in car.trips)
                    {
                        writer.WriteLine(trip.ToString());
                    }
                    writer.WriteLine(); // tom linje mellem biler
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Fejl under skrivning: {ex.Message}");
            }
            finally
            {
                if (writer != null)
                {
                    writer.Close();
                }

                // Denne linje er flyttet herned – præcis som opgaven ønsker det:
                Console.WriteLine("Data gemt i filen.");
            }
        }



        public List<Car> LoadCars()
        {
            List<Car> cars = new List<Car>();
            Car currentCar = null;

            try
            {
                if (!File.Exists(FilePath))
                    return cars;

                using (StreamReader reader = new StreamReader(FilePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (string.IsNullOrWhiteSpace(line)) continue;

                        if (line.StartsWith("# Car:"))
                        {
                            currentCar = Car.FromString(line);
                            cars.Add(currentCar);
                        }
                        else if (line.StartsWith("Trip:") && currentCar != null)
                        {
                            currentCar.trips.Add(Trip.FromString(line));
                        }
                    }
                }
            }
            //Faktisk ikke brugt da vi opretter filen hvis den ikke findes via if (!File.Exists(FilePath))
            catch (FileNotFoundException)
            {
                Console.WriteLine($"Filen '{FilePath}' blev ikke fundet (catch-blok). Ingen biler indlæst.");
            }
            

            return cars;
        }



        public void SaveSingleCar(Car newCar)
        {
            var cars = LoadCars();

            // Tjek om bilen allerede findes
            var existingCar = cars.FirstOrDefault(c =>
                c.carBrand == newCar.carBrand &&
                c.carModel == newCar.carModel &&
                c.carYear == newCar.carYear);

            if (existingCar != null)
            {
                // Bevar eksisterende ture
                foreach (var trip in existingCar.trips)
                {
                    newCar.trips.Add(trip);
                }

                cars.Remove(existingCar);
            }

            cars.Add(newCar);
            SaveCars(cars);
        }

    }
}
