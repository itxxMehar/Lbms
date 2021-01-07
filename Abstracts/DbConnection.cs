using MySqlConnector;
using System.Data;

namespace LBMS.Abstracts
{
    public class DbConnection
    {
        private readonly MySqlConnection _dbContext;
        private readonly string _connectionString = "DataSource=localhost;Database=lbms;port=3306;username=root;password=root";
        private MySqlCommand _dbCommand;

        public DbConnection()
        {
            _dbContext = new MySqlConnection(_connectionString);
        }

        public bool Save(string tableName, string values)
        {
            var template = $"insert into {tableName} values({values})";
            _dbCommand = new MySqlCommand(template, _dbContext);
            if (ValidateDbConnection())
            {
                return _dbCommand.ExecuteNonQuery() > 0;
            }
            return false;
        }

        public bool Update(string tableName, string setValues)
        {
            var template = $"update {tableName} set {setValues}";
            _dbCommand = new MySqlCommand(template, _dbContext);
            if (ValidateDbConnection())
            {
                return _dbCommand.ExecuteNonQuery() > 0;
            }
            return false;
        }

        public bool Delete(string tableName, string condition)
        {
            var template = $"delete from {tableName} where {condition}";
            _dbCommand = new MySqlCommand(template, _dbContext);
            if (ValidateDbConnection())
            {
                return _dbCommand.ExecuteNonQuery() > 0;
            }
            return false;
        }

        public DataTable Find(string tableName, string predicate)
        {
            var template = $"select * from {tableName} where {predicate}";
            _dbCommand = new MySqlCommand(template, _dbContext);
            if (ValidateDbConnection())
            {
                var adapter = new MySqlDataAdapter(_dbCommand);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            return null;
        }

        public DataTable GetAll(string tableName, string columnNames)
        {
            var template = $"select {columnNames} from {tableName}";
            _dbCommand = new MySqlCommand(template, _dbContext);
            if (ValidateDbConnection())
            {
                var adapter = new MySqlDataAdapter(_dbCommand);
                var dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            return null;
        }

        private bool ValidateDbConnection()
        {
            if (_dbContext.State == ConnectionState.Closed)
            {
                _dbContext.Open();
            }
            return _dbContext.State == ConnectionState.Open;
        }
    }
}
