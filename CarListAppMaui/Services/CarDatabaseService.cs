using CarListAppMaui.Models;
using SQLite;

namespace CarListAppMaui.Services
{
    public class CarDatabaseService
    {
        SQLiteConnection conn;
        
        string _dbPath;
        public string StatusMessage;
        int result = 0;

        public CarDatabaseService(string dbPath)
        {            
            _dbPath = dbPath;
        }

        private void Init()
        {
            if (conn != null)
                return;
            conn = new SQLiteConnection(_dbPath );
            conn.CreateTable<Car>();

        }
        public List<Car> GetCars()
        {
            
            try
            {
                Init();
                return conn.Table<Car>().ToList();
                
            }
            catch (Exception)
            {
                StatusMessage="Failed to retrieve data.";
            }

            return new List<Car>();
            // static list rimossa 
            //return new List<Car>()
            //{
            
            //    new Car
            //    {
            //        Id = 1,Make="Honda", Model = "Fit",Vin = "123"
            //    },
            //    new Car
            //    {
            //        Id = 2,Make="Toyota", Model = "Prado",Vin = "123"
            //    },
            //    new Car
            //    {
            //        Id = 3,Make="Honda", Model = "Civic",Vin = "123"
            //    },
            //    new Car
            //    {
            //        Id = 4,Make="Audi", Model = "A5",Vin = "123"
            //    },
            //    new Car
            //    {
            //        Id = 5,Make="BMW", Model = "M3",Vin = "123"
            //    }

            //};
        }

        public Car GetCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().FirstOrDefault(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to retrieve data.";
            }
            return null;
        }

        public int DeleteCar(int id)
        {
            try
            {
                Init();
                return conn.Table<Car>().Delete(q => q.Id == id);
            }
            catch (Exception)
            {
                StatusMessage = "Failed to delete data.";
            }
            return 0;
        }
        
        public void AddCar(Car car)
        {
            try
            {
                Init();
                if (car == null)
                    throw new Exception("Invalid car Record");
                result = conn.Insert(car);
                StatusMessage = result == 0 ? "Insert Failed" : "Insert Successful";
                    
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Insert data.";
            }
            }
     
        public void UpdateCar(Car car)
        {
            try
            {
                Init();

                if (car == null)
                    throw new Exception("Invalid Car Record");

                result = conn.Update(car);
                StatusMessage = result == 0 ? "Update Failed" : "Update Successful";
            }
            catch (Exception ex)
            {
                StatusMessage = "Failed to Update data.";
            }
        }
    }
}



