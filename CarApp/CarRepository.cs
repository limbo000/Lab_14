using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using CarApp;

public class CarRepository
{
    private List<Car> cars = new List<Car>();

    public CarRepository(string filePath)
    {
        LoadCars(filePath);
    }

    private void LoadCars(string filePath)
    {
        try
        {
            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines)
            {
                var parts = line.Split(';');
                if (parts.Length == 5)
                {
                    cars.Add(new Car
                    {
                        RegNumber = parts[0].Trim(),
                        Brand = parts[1].Trim(),
                        Color = parts[2].Trim(),
                        Year = int.Parse(parts[3].Trim()),
                        OwnerAddress = parts[4].Trim()
                    });
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ошибка при загрузке данных: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }


    public List<Car> GetCarsByBrandAndColor(string brand, string color)
    {
        return cars.FindAll(car => car.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase) &&
                                    car.Color.Equals(color, StringComparison.OrdinalIgnoreCase));
    }

    public Car GetCarByRegNumber(string regNumber)
    {
        return cars.Find(car => car.RegNumber.Equals(regNumber, StringComparison.OrdinalIgnoreCase));
    }

    public List<Car> GetCarsByRegNumberPart(string regNumberPart)
    {
        return cars.FindAll(car => car.RegNumber.Contains(regNumberPart));
    }
}
