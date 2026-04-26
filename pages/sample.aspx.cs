using logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TurboFlow.pages
{
    public partial class sample : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static Dictionary<string, object> LoadInit(Dictionary<string, string> datos)
        {
            BasePage basePage = new BasePage();
            logic_acces logicAcces = new logic_acces(BasePage.ConexionDB);
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            DataSet ds = logicAcces.ExecuteQuery("StockCategory_Sel", datos);
            dictionary["Categories"] = (object)basePage.DataTableToMap(ds.Tables[0]);

            return dictionary;
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static Dictionary<string, object> CargarDatosPersonales(Dictionary<string, string> datos)
        {
            BasePage basePage = new BasePage();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                // querysssssssssss
                string queryDatosPersonales = "SELECT NombreCompleto, DATE_FORMAT(FechaNacimiento, '%d/%m/%Y') AS FechaNacimiento, Direccion, EstadoCivil, Telefono, Correo FROM Nombre WHERE MatriculaID = @MatriculaID";
                string queryConocimientos = "SELECT Conocimiento FROM Conocimientos WHERE MatriculaID = @MatriculaID";
                string queryEducacion = "SELECT Escuela, Titulo, FechaIniFin FROM Educacion WHERE MatriculaID = @MatriculaID";
                string queryHabilidades = "SELECT Habilidad FROM Habilidades WHERE MatriculaID = @MatriculaID";
                string queryHobbies = "SELECT Hobbie FROM Hobbies WHERE MatriculaID = @MatriculaID";
                string queryIdiomas = "SELECT Idioma, Porcentaje FROM Idiomas WHERE MatriculaID = @MatriculaID";
                string queryTrabajos = "SELECT Empresa, Puesto, Funciones, Logros, FechaIniFin FROM Trabajos WHERE MatriculaID = @MatriculaID";

                DataTable ExecuteQuery(string query)
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);
                            return dt;
                        }
                    }
                }

                DataTable dtDatosPersonales = ExecuteQuery(queryDatosPersonales);
                dictionary["DatosPersonales"] = dtDatosPersonales.Rows.Count > 0 ? basePage.DataTableToMap(dtDatosPersonales) : null;

                DataTable dtConocimientos = ExecuteQuery(queryConocimientos);
                dictionary["Conocimientos"] = dtConocimientos.Rows.Count > 0 ? basePage.DataTableToMap(dtConocimientos) : null;

                DataTable dtEducacion = ExecuteQuery(queryEducacion);
                dictionary["Educacion"] = dtEducacion.Rows.Count > 0 ? basePage.DataTableToMap(dtEducacion) : null;

                DataTable dtHabilidades = ExecuteQuery(queryHabilidades);
                dictionary["Habilidades"] = dtHabilidades.Rows.Count > 0 ? basePage.DataTableToMap(dtHabilidades) : null;

                DataTable dtHobbies = ExecuteQuery(queryHobbies);
                dictionary["Hobbies"] = dtHobbies.Rows.Count > 0 ? basePage.DataTableToMap(dtHobbies) : null;

                DataTable dtIdiomas = ExecuteQuery(queryIdiomas);
                dictionary["Idiomas"] = dtIdiomas.Rows.Count > 0 ? basePage.DataTableToMap(dtIdiomas) : null;

                DataTable dtTrabajos = ExecuteQuery(queryTrabajos);
                dictionary["Trabajos"] = dtTrabajos.Rows.Count > 0 ? basePage.DataTableToMap(dtTrabajos) : null;
            }

            return dictionary;
        }



        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarDatosPersonales(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Nombre 
            SET NombreCompleto = @NombreCompleto, 
                FechaNacimiento = STR_TO_DATE(@FechaNacimiento, '%d/%m/%Y'), 
                Direccion = @Direccion, 
                EstadoCivil = @EstadoCivil, 
                Telefono = @Telefono, 
                Correo = @Correo 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@NombreCompleto", datos["NombreCompleto"]);
                    cmd.Parameters.AddWithValue("@FechaNacimiento", datos["FechaNacimiento"]);
                    cmd.Parameters.AddWithValue("@Direccion", datos["Direccion"]);
                    cmd.Parameters.AddWithValue("@EstadoCivil", datos["EstadoCivil"]);
                    cmd.Parameters.AddWithValue("@Telefono", datos["Telefono"]);
                    cmd.Parameters.AddWithValue("@Correo", datos["Correo"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarTrabajos(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Trabajos 
            SET Empresa = @Empresa, 
                Puesto = @Puesto, 
                Funciones = @Funciones, 
                Logros = @Logros, 
                FechaIniFin = @FechaIniFin 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Empresa", datos["Empresa"]);
                    cmd.Parameters.AddWithValue("@Puesto", datos["Puesto"]);
                    cmd.Parameters.AddWithValue("@Funciones", datos["Funciones"]);
                    cmd.Parameters.AddWithValue("@Logros", datos["Logros"]);
                    cmd.Parameters.AddWithValue("@FechaIniFin", datos["FechaIniFin"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }


        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarEducacion(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Educacion 
            SET Escuela = @Escuela, 
                Titulo = @Titulo, 
                FechaIniFin = @FechaIniFin 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Escuela", datos["Escuela"]);
                    cmd.Parameters.AddWithValue("@Titulo", datos["Titulo"]);
                    cmd.Parameters.AddWithValue("@FechaIniFin", datos["FechaIniFin"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarHobbies(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Hobbies 
            SET Hobbie = @Hobbie 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Hobbie", datos["Hobbie"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarIdiomas(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Idiomas 
            SET Idioma = @Idioma, 
                Porcentaje = @Porcentaje 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Idioma", datos["Idioma"]);
                    cmd.Parameters.AddWithValue("@Porcentaje", datos["Porcentaje"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarHabilidades(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Habilidades 
            SET Habilidad = @Habilidad 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Habilidad", datos["Habilidad"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool ActualizarConocimientos(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            UPDATE Conocimientos 
            SET Conocimiento = @Conocimiento 
            WHERE MatriculaID = @MatriculaID";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Conocimiento", datos["Conocimiento"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }




        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool AgregarConocimientos(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = "INSERT INTO Conocimientos (Conocimiento, MatriculaID) VALUES (@Conocimiento, @MatriculaID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Conocimiento", datos["Conocimiento"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool AgregarTrabajos(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Trabajos (Empresa, Puesto, Funciones, Logros, FechaIniFin, MatriculaID)
            VALUES (@Empresa, @Puesto, @Funciones, @Logros, @FechaIniFin, @MatriculaID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Empresa", datos["Empresa"]);
                    cmd.Parameters.AddWithValue("@Puesto", datos["Puesto"]);
                    cmd.Parameters.AddWithValue("@Funciones", datos["Funciones"]);
                    cmd.Parameters.AddWithValue("@Logros", datos["Logros"]);
                    cmd.Parameters.AddWithValue("@FechaIniFin", datos["FechaIniFin"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool AgregarEducacion(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Educacion (Escuela, Titulo, FechaIniFin, MatriculaID)
            VALUES (@Escuela, @Titulo, @FechaIniFin, @MatriculaID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Escuela", datos["Escuela"]);
                    cmd.Parameters.AddWithValue("@Titulo", datos["Titulo"]);
                    cmd.Parameters.AddWithValue("@FechaIniFin", datos["FechaIniFin"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool AgregarHabilidades(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Habilidades (Habilidad, MatriculaID)
            VALUES (@Habilidad, @MatriculaID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Habilidad", datos["Habilidad"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool AgregarHobbies(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Hobbies (Hobbie, MatriculaID)
            VALUES (@Hobbie, @MatriculaID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Hobbie", datos["Hobbie"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        [WebMethod(EnableSession = true)]
        [ScriptMethod]
        public static bool AgregarIdiomas(Dictionary<string, string> datos)
        {
            string connString = "Database=Proyecto;Server=localhost;User ID=root; Password=Nak0Mugi002#;";

            using (MySqlConnection connection = new MySqlConnection(connString))
            {
                connection.Open();

                string query = @"
            INSERT INTO Idiomas (Idioma, Porcentaje, MatriculaID)
            VALUES (@Idioma, @Porcentaje, @MatriculaID)";

                using (MySqlCommand cmd = new MySqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@Idioma", datos["Idioma"]);
                    cmd.Parameters.AddWithValue("@Porcentaje", datos["Porcentaje"]);
                    cmd.Parameters.AddWithValue("@MatriculaID", datos["MatriculaID"]);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }
    }

}