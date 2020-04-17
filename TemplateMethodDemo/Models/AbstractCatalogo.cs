using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TemplateMethodDemo.Models
{
    public abstract class AbstractCatalogo
    {
        protected string cadenaconexion;
        protected DataSet dataset;
        protected MySqlConnection mySqlConnection;

        public AbstractCatalogo(string cadenaconexion)
        {
            this.cadenaconexion = cadenaconexion;
        }

        public virtual bool Conectar()
        {
            mySqlConnection = new MySqlConnection(cadenaconexion);
            mySqlConnection.Open();
            return (mySqlConnection.State == ConnectionState.Open);
        }

        public virtual void Desconectar()
        {
            cadenaconexion = "";
            if (mySqlConnection.State == ConnectionState.Open)
            {
                mySqlConnection.Close();
            }
        }

        public abstract void Seleccionar();

        public abstract List<string> Procesar();

        //Template Method
        public List<string> Ejecutar()
        {
            List<string> catalogo = new List<string>();
            if(Conectar())
            {
                Seleccionar();
                catalogo = Procesar();
                Desconectar();
            }
            return catalogo;
        }

    }
}
