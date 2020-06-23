/*
Para Conectarse con una base de datos Oracle 11G 32bits (x86)
En el proyecto de datos:
Instalar los siguientes packetes NuGet:
-Dapper
-System.Data.SqlClient
*/

using System;
using System.Collections.Generic;
using System.Text;
using Entidades;

using System.Linq;
using Dapper;
using System.Data.SqlClient;



        /*
        tabla:
CREATE TABLE PRODUCTOS
(
Id INT PRIMARY KEY IDENTITY(1,1) NOT NULL, 
Descripcion VARCHAR(100) NOT NULL, 
Cantidad INT NOT NULL, 
Precio DECIMAL(18,2) NOT NULL,
FechaVencimiento DATETIME NOT NULL,
Activo BIT NOT NULL
);




INSERT INTO PRODUCTOS(Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES('LECHE',7,57.26,'1985-20-12', 1);

INSERT INTO PRODUCTOS(Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES('YERBA',77,127.67,'2011-03-12', 1);

INSERT INTO PRODUCTOS(Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES('MORTADELA',66,65571516.26,'2019-22-10', 0);

INSERT INTO PRODUCTOS(Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES('TURRON',50,15.33,'2015-01-11', 0);

INSERT INTO PRODUCTOS(Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES('CREMA',0,125.99,'2012-27-07', 1);



SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo FROM PRODUCTOS

SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo 
FROM PRODUCTOS
WHERE Id = 3

SELECT Descripcion
FROM PRODUCTOS
WHERE Id = 3

SELECT Cantidad
FROM PRODUCTOS
WHERE Id = 3

SELECT Precio
FROM PRODUCTOS
WHERE Id = 3

SELECT FechaVencimiento
FROM PRODUCTOS
WHERE Id = 3

SELECT Activo
FROM PRODUCTOS
WHERE Id = 3

            */


        public IEnumerable<Productos> ObtenerLista()
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS");

            var lista = new List<Productos>();
            using (var connection = new SqlConnection(conexionString))
            {
                lista = connection.Query<Productos>(sqlQuery.ToString()).ToList();
            }

            return lista;
        }

        public IEnumerable<Productos> ObtenerLista(bool activo)
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Activo = @activoParametro ");

            var lista = new List<Productos>();
            using (var connection = new SqlConnection(conexionString))
            {
                lista = connection.Query<Productos>(sqlQuery.ToString(), new { activoParametro = activo }).ToList();
            }

            return lista;
        }

        public Productos ObtenerObjeto()
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");


            var obj = new Productos();
            using (var connection = new SqlConnection(conexionString))
            {
                obj = connection.Query<Productos>(sqlQuery.ToString()).FirstOrDefault();
            }

            return obj;
        }

        public Productos ObtenerObjeto(int id, bool activo)
        {

            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = @p_Id  AND Activo = @p_Activo");

           
            var result = new Productos();

            var parameters = new { p_Id = id, p_Activo = activo };

            var sql = sqlQuery.ToString();

            using (var connection = new SqlConnection(conexionString))
            {
                result = connection.Query<Productos>(sql, parameters).FirstOrDefault();
            }

            return result;
        }

        public string ObtenerCadena()
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Descripcion ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            string cadena = string.Empty;
            using (var connection = new SqlConnection(conexionString))
            {
                cadena = connection.ExecuteScalar<string>(sqlQuery.ToString());
            }

            return cadena;
        }

        public int ObtenerEntero()
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Cantidad ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            int entero = 0;
            using (var connection = new SqlConnection(conexionString))
            {
                entero = connection.ExecuteScalar<int>(sqlQuery.ToString());
            }

            return entero;
        }

        public decimal ObtenerDecimal()
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Precio ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            decimal nroDecimal = 0;
            using (var connection = new SqlConnection(conexionString))
            {
                nroDecimal = connection.ExecuteScalar<decimal>(sqlQuery.ToString());
            }

            return nroDecimal;
        }

        public DateTime ObtenerFecha()
        {
            string conexionString = @"Data Source=NOTEBENJA;Initial Catalog=dbTest;Integrated Security=True;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT FechaVencimiento ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            DateTime fecha = new DateTime(1985, 12, 20);

            using (var connection = new SqlConnection(conexionString))
            {
                fecha = connection.ExecuteScalar<DateTime>(sqlQuery.ToString());
            }

            return fecha;
        }
