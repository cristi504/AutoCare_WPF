using System;
using System.IO;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using Autocare_WPF.domain.cars;
using Autocare_WPF.domain.documents;
using Autocare_WPF.domain.Services;
using Autocare_WPF.domain.user_validation;
using static Autocare_WPF.domain.documents.StoreDocument;

namespace Autocare_WPF.data_access
{
    internal class DataAccess
    {
        private static DataAccess _instance;
        public static DataAccess Instance => _instance ??= new DataAccess();


        private readonly static string connectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\limbaje (c#)\Autocare WPF\AutoCareDatabase.accdb";
        public string CurrentUsername { get; private set; }
        public int CurrentUserID { get; private set; }


        private int GetUserIDFromUsername(string username)
        {
            int userID =0;

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT UserId FROM tUsers WHERE Username = ?";
                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.Parameters.AddWithValue("?", username);
                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        userID = Convert.ToInt32(result);
                        
                    }
                    else
                    {
                        MessageBox.Show("User not found!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error fetching UserID: {ex.Message}");
                }
            }
            return userID;
            
        }
        public void SetCurrentUser(string username)
        {
            CurrentUsername = username;
            CurrentUserID = GetUserIDFromUsername(username);
        }

        public bool LogIn(Login user)
        {
            try
            {
                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT COUNT(*) FROM tUsers WHERE Username = ? AND PasswordHash = ?";

                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", user.username);
                        command.Parameters.AddWithValue("?", user.hashedPassword);

                        int count = (int)command.ExecuteScalar();

                        if (count > 0)
                        {
                            SetCurrentUser(user.username); 
                            return true; 
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public bool SignUp(Signup user)
        {
            try
            {
                if (!user.email.Contains("@"))
                {
                    MessageBox.Show("Please enter a valid email address.", "Invalid Email", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return false;
                }

                using (OleDbConnection connection = new OleDbConnection(connectionString))
                {
                    connection.Open();

                    string checkUserQuery = "SELECT COUNT(*) FROM tUsers WHERE Username = ?";
                    using (OleDbCommand command1 = new OleDbCommand(checkUserQuery, connection))
                    {
                        command1.Parameters.AddWithValue("?", user.username);
                        int userCount = (int)command1.ExecuteScalar();

                        if (userCount > 0)
                        {
                            MessageBox.Show("User already exists!", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                            return false;
                        }
                    }

                    string query = "INSERT INTO tUsers (Username, PasswordHash, Email, FirstName, LastName, CreateAt) VALUES (?, ?, ?, ?, ?, ?)";
                    using (OleDbCommand command = new OleDbCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("?", user.username);
                        command.Parameters.AddWithValue("?", user.hashedPassword);
                        command.Parameters.AddWithValue("?", user.email);
                        command.Parameters.AddWithValue("?", user.FirstName);
                        command.Parameters.AddWithValue("?", user.LastName);
                        command.Parameters.AddWithValue("?", DateTime.Now);

                        int result = command.ExecuteNonQuery();
                        return result > 0; 
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                return false;
            }
        }
        public List<mycars> GetCarDetails(int userID)
        {
            List<mycars> carList = new List<mycars>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = @"SELECT tCars.CarID, Brand, tCars.Model, tCars.Year, tCars.LicensePlate, tCars.VIN,
                                    tCarSpecs.Color, tCarSpecs.EngineCapacity, tCarSpecs.FuelType, 
                                    tCarSpecs.Power, tCarSpecs.Transmision, tCarSpecs.Mileage
                                    FROM tCars
                                    INNER JOIN tCarSpecs ON tCars.CarID = tCarSpecs.CarID
                                    WHERE tCars.UserID = ?";

                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.Parameters.AddWithValue("?", userID);

                    OleDbDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        carList.Add(new mycars
                        {
                            CarID = Convert.ToInt32(reader["CarID"]),
                            Brand = reader["Brand"].ToString(),
                            Model = reader["Model"].ToString(),
                            Year = reader["Year"].ToString(),
                            LicensePlate = reader["LicensePlate"].ToString(),
                            VIN = reader["VIN"].ToString(),
                            Color = reader["Color"].ToString(),
                            EngineCapacity = (int)reader["EngineCapacity"],
                            FuelType = reader["FuelType"].ToString(),
                            HorsePower = reader["Power"].ToString(),
                            Mileage = (int)reader["Mileage"],
                            Transmision = reader["Transmision"].ToString(),
                           
                        });
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            return carList;
        }
        public bool DeleteCar(int carId)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                OleDbTransaction transaction = connection.BeginTransaction();

                try
                {
                    // Step 1: Delete related data from tCarSpecs
                    string deleteSpecsQuery = "DELETE FROM [tCarSpecs] WHERE [CarID] = ?";
                    using (OleDbCommand deleteSpecsCommand = new OleDbCommand(deleteSpecsQuery, connection, transaction))
                    {
                        deleteSpecsCommand.Parameters.AddWithValue("?", carId);
                        deleteSpecsCommand.ExecuteNonQuery();
                    }

                    // Step 2: Delete car from tCars
                    string deleteCarQuery = "DELETE FROM [tCars] WHERE [CarID] = ?";
                    using (OleDbCommand deleteCarCommand = new OleDbCommand(deleteCarQuery, connection, transaction))
                    {
                        deleteCarCommand.Parameters.AddWithValue("?", carId);
                        deleteCarCommand.ExecuteNonQuery();
                    }

                    // Commit transaction
                    transaction.Commit();
                    return true;
                }
                catch (Exception ex)
                {
                    // Rollback transaction on error
                    transaction.Rollback();
                    MessageBox.Show($"Error deleting car: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }
        public bool AddCar(AddCarClass car)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Check for duplicate VIN
                    if (RecordExists(connection, "tCars", "VIN", car.VIN))
                    {
                        MessageBox.Show("This VIN already exists in the database.", "Duplicate VIN", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }

                    // Check for duplicate License Plate
                    if (RecordExists(connection, "tCars", "LicensePlate", car.LicensePlate))
                    {
                        MessageBox.Show("This License Plate already exists in the database.", "Duplicate License Plate", MessageBoxButton.OK, MessageBoxImage.Warning);
                        return false;
                    }

                    // Begin transaction
                    using (OleDbTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            int carId;

                            // Insert into tCars table
                            string carInsertQuery = "INSERT INTO [tCars] ([UserID],[Brand], [Model], [Year], [VIN], [LicensePlate]) VALUES (?, ?, ?, ?, ?, ?)";
                            using (OleDbCommand carCommand = new OleDbCommand(carInsertQuery, connection, transaction))
                            {

                               
                                carCommand.Parameters.AddWithValue("?", car.UserID);
                                carCommand.Parameters.AddWithValue("?", car.Brand);
                                carCommand.Parameters.AddWithValue("?", car.Model);
                                carCommand.Parameters.AddWithValue("?", car.Year);
                                carCommand.Parameters.AddWithValue("?", car.VIN);
                                carCommand.Parameters.AddWithValue("?", car.LicensePlate);
                                carCommand.ExecuteNonQuery();
                            }

                            // Get the newly inserted CarID (safer than MAX(CarID))
                            string getCarIdQuery = "SELECT @@IDENTITY";
                            using (OleDbCommand getCarIdCommand = new OleDbCommand(getCarIdQuery, connection, transaction))
                            {
                                carId = Convert.ToInt32(getCarIdCommand.ExecuteScalar());
                            }

                            // Insert into tCarSpecs table
                            string specsInsertQuery = "INSERT INTO [tCarSpecs] ([CarID], [EngineCapacity], [FuelType], [Power], [Transmision], [Color], [Mileage]) VALUES (?, ?, ?, ?, ?, ?, ?)";
                            using (OleDbCommand specsCommand = new OleDbCommand(specsInsertQuery, connection, transaction))
                            {
                                specsCommand.Parameters.AddWithValue("?", carId);
                                specsCommand.Parameters.AddWithValue("?",car.EngineCapacity) ;
                                specsCommand.Parameters.AddWithValue("?", string.IsNullOrEmpty(car.FuelType) ? (object)DBNull.Value : car.FuelType);
                                specsCommand.Parameters.AddWithValue("?", string.IsNullOrEmpty(car.HorsePower) ? (object)DBNull.Value : car.HorsePower);
                                specsCommand.Parameters.AddWithValue("?", string.IsNullOrEmpty(car.Transmision) ? (object)DBNull.Value : car.Transmision);
                                specsCommand.Parameters.AddWithValue("?", string.IsNullOrEmpty(car.Color) ? (object)DBNull.Value : car.Color);
                                specsCommand.Parameters.AddWithValue("?", car.Mileage); 
                                specsCommand.ExecuteNonQuery();
                            }

                            // Commit transaction
                            transaction.Commit();
                            return true;
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            MessageBox.Show($"Error adding car: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                            return false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Database connection error: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }


        private bool RecordExists(OleDbConnection connection, string tableName, string columnName, string value)
        {
            string query = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = ?";
            using (OleDbCommand cmd = new OleDbCommand(query, connection))
            {
                cmd.Parameters.AddWithValue("?", value);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count > 0;
            }
        }
        public bool UserExists(int userId)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) FROM [tUsers] WHERE [UserId] = ?";
                using (OleDbCommand command = new OleDbCommand(query, connection))
                {
                    command.Parameters.AddWithValue("?", userId);
                    return Convert.ToInt32(command.ExecuteScalar()) > 0;
                }
            }
        }
        public List<ServiceCar> GetCarsForUser(int userID)
        {
            List<ServiceCar> cars = new List<ServiceCar>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT CarID, Brand FROM tCars WHERE UserID = ? ORDER BY Brand ASC";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", userID);
                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cars.Add(new ServiceCar(reader.GetInt32(0), reader.GetString(1)));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading cars: {ex.Message}");
                }
            }
            return cars;
        }
        public List<ServiceInterval> GetServiceIntervalsForCar(int carID)
        {
            List<ServiceInterval> services = new List<ServiceInterval>();

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT Oil, AirFilter, FuelFilter, OilFilter, OtherInterventions, Mileage, Price FROM tServices WHERE CarID = ?";

                    using (OleDbCommand cmd = new OleDbCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("?", carID);

                        using (OleDbDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string oil = reader.IsDBNull(0) ? "" : reader.GetString(0);
                                string airFilter = reader.IsDBNull(1) ? "" : reader.GetString(1);
                                string fuelFilter = reader.IsDBNull(2) ? "" : reader.GetString(2);
                                string oilFilter = reader.IsDBNull(3) ? "" : reader.GetString(3);
                                string otherInterventions = reader.IsDBNull(4) ? "" : reader.GetString(4);
                                int mileage = reader.IsDBNull(5) ? 0 : Convert.ToInt32(reader[5]);
                                decimal price = reader.IsDBNull(6) ? 0 : Convert.ToDecimal(reader[6]);

                                services.Add(new ServiceInterval(oil, airFilter, fuelFilter, oilFilter, otherInterventions, mileage, price));
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading service intervals: {ex.Message}");
                }
            }
            return services;
        }
        public bool AddServiceEntry(ServiceEntry service)
        {
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    string query = @"INSERT INTO tServices (CarID, Oil, AirFilter, FuelFilter, OilFilter, OtherInterventions, Mileage, Price)
                                     VALUES (?, ?, ?, ?, ?, ?, ?, ?)";

                    OleDbCommand command = new OleDbCommand(query, connection);
                    command.Parameters.AddWithValue("?", service.CarID);
                    command.Parameters.AddWithValue("?", service.Oil);
                    command.Parameters.AddWithValue("?", service.AirFilter);
                    command.Parameters.AddWithValue("?", service.FuelFilter);
                    command.Parameters.AddWithValue("?", service.OilFilter);
                    command.Parameters.AddWithValue("?", service.OtherInterventions);
                    command.Parameters.AddWithValue("?", service.Mileage);
                    command.Parameters.AddWithValue("?", service.Price);

                    command.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding service entry: {ex.Message}", "Database Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return false;
                }
            }
        }


        public static int storeDocument(StoreDocument doc)
        {
            int newDocumentID = -1;
            string sqlQuery = "INSERT INTO tDocument (UserID, Type, Series, IssueDate, ExpiryDate) VALUES (?, ?, ?, ?, ?)";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", doc.userId);
                    cmd.Parameters.AddWithValue("?", doc.documentType);
                    cmd.Parameters.AddWithValue("?", doc.series);
                    cmd.Parameters.AddWithValue("?", doc.issueDate);
                    cmd.Parameters.AddWithValue("?", doc.expiryDate);
                    cmd.ExecuteNonQuery();
                }

                // Get the last inserted DocumentID
                sqlQuery = "SELECT @@IDENTITY";  // Gets the last auto-incremented ID
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        newDocumentID = Convert.ToInt32(result);
                    }
                }
            }

            return newDocumentID;
        }

        public static List<RetrievedDocument> DocumentsRetreive(int currentUserID)
        {
            var result = new List<RetrievedDocument>();
            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT documentID, Type, Series, IssueDate, ExpiryDate FROM tDocument WHERE UserID = ?";
                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.Parameters.AddWithValue("?", currentUserID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new RetrievedDocument()
                            {
                                documentID = reader.GetInt32(0),
                                Type = reader.GetString(1),
                                Series = reader.GetString(2),
                                IssueDate = reader.GetDateTime(3),
                                ExpiryDate = reader.GetDateTime(4)
                            });
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading documents: {ex.Message}");
                }
            }
            return result;
        }
        public static void UpdateDocument(UpdateDocument doc)
        {
            string query = "UPDATE tDocument SET Type = ?, Series = ?, IssueDate = ?, ExpiryDate = ? WHERE documentID = ?";

            using (OleDbConnection connection = new OleDbConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    OleDbCommand cmd = new OleDbCommand(query, connection);
                    cmd.Parameters.AddWithValue("?", doc.documentType);
                    cmd.Parameters.AddWithValue("?", doc.series);
                    cmd.Parameters.AddWithValue("?", doc.issueDate);
                    cmd.Parameters.AddWithValue("?", doc.expiryDate);
                    cmd.Parameters.AddWithValue("?", doc.documentId);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Document updated successfully.");

                    }
                    else
                    {
                        MessageBox.Show("Update failed. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating document: {ex.Message}");

                }
            }
        }

        public static bool DeleteDocument(int documentID)
        {
            try
            {
              
                using (OleDbConnection conn = new OleDbConnection(connectionString))
                {
                    // Open the database connection
                    conn.Open();

                    // SQL query to delete the document
                    string query = "DELETE FROM tDocument WHERE documentID = @documentID";

                    using (OleDbCommand cmd = new OleDbCommand(query, conn))
                    {
                        // Use parameters to avoid SQL injection
                        cmd.Parameters.AddWithValue("@documentID", documentID);

                        // Execute the query
                        int rowsAffected = cmd.ExecuteNonQuery();

                        // If at least one row was affected, deletion was successful
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error or show a message
                MessageBox.Show("An error occurred: " + ex.Message);
                return false;
            }
        }
        

        public static byte[] GetDocumentPhoto(int documentID)
        {
            byte[] photoData = null;
            string sqlQuery = "SELECT Photo FROM tDocument WHERE DocumentID = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", documentID);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read() && reader["Photo"] != DBNull.Value)
                        {
                            photoData = (byte[])reader["Photo"]; // Get raw bytes
                        }
                    }
                }
            }

            return photoData;
        }
        public static void SaveDocumentPhoto(int documentID, string imagePath)
        {
            byte[] imageBytes = File.ReadAllBytes(imagePath); // Read image as byte array

            string sqlQuery = "UPDATE tDocument SET Photo = ? WHERE DocumentID = ?";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", imageBytes); // Store as raw bytes
                    cmd.Parameters.AddWithValue("?", documentID);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public static int GetLatestDocumentID(int userId)
        {
            int documentID = -1;
            string sqlQuery = "SELECT TOP 1 documentID FROM tDocument WHERE UserID = ? ORDER BY documentID DESC";

            using (OleDbConnection conn = new OleDbConnection(connectionString))
            {
                conn.Open();
                using (OleDbCommand cmd = new OleDbCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("?", userId);

                    using (OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            documentID = reader.GetInt32(0);
                        }
                    }
                }
            }

            return documentID;
        }








    }

}
