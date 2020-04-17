using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TemplateMethodDemo.Models
{
    public class Categorias : AbstractCatalogo
    {
        public Categorias(string cadenaconexion) : base(cadenaconexion)
        {
        }

        public override List<string> Procesar()
        {
            var catalogo = new List<string>();

            foreach(DataRow row in dataset.Tables["Categorias"].Rows)
            {
                catalogo.Add(row["Nombre"].ToString());
            }
            return catalogo;
        }

        public override void Seleccionar()
        {
            string sql = "select * from Categorias order by nombre";
            var adaptador = new MySqlDataAdapter(sql, mySqlConnection);
            dataset = new System.Data.DataSet();
            adaptador.Fill(dataset, "Categorias");
        }
    }
}
