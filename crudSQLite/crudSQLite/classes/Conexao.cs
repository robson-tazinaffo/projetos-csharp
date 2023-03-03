using System.Data.SQLite;

namespace crudSQLite.classes
{
    class Conexao
    {
        public SQLiteConnection conn = new SQLiteConnection("Data Source=crud.db;Version=3;New=True;Compress=True;");

        public void conectar()
        {
            conn.Open();
        }

        public void desconectar()
        {
            conn.Close();
        }

    }
}
