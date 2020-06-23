
        /*
         tabla:
                CREATE TABLE PRODUCTOS
                (
                Id number NOT NULL, 
                Descripcion varchar2(100) NOT NULL, 
                Cantidad number NOT NULL, 
                Precio number(18,2) NOT NULL,
                FechaVencimiento date NOT NULL,
                Activo char(1) NOT NULL,
                CONSTRAINT pk_productos PRIMARY KEY (Id)
                );


INSERT INTO PRODUCTOS(Id, Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES(1,'LECHE',7,57.26,SYSDATE, 'Y');
INSERT INTO PRODUCTOS(Id, Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES(2,'YERBA',77,127.67,SYSDATE+26, 'Y');
INSERT INTO PRODUCTOS(Id, Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES(3,'MORTADELA',66,65571516.26,SYSDATE+15, 'N');
INSERT INTO PRODUCTOS(Id, Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES(4,'TURRON',50,15.33,SYSDATE+98, 'N');
INSERT INTO PRODUCTOS(Id, Descripcion, Cantidad,Precio,FechaVencimiento,Activo)
VALUES(5,'CREMA',0,125.99,SYSDATE+21, 'Y');

COMMIT;

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
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS");

            var lista = new List<Productos>();
            using (var connection = new OracleConnection(conexionString))
            {
                lista = connection.Query<Productos>(sqlQuery.ToString()).ToList();
            }

            return lista;
        }

        public IEnumerable<Productos> ObtenerLista(string activo)
        {
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Activo = :activoParametro ");

            var lista = new List<Productos>();
            using (var connection = new OracleConnection(conexionString))
            {
                lista = connection.Query<Productos>(sqlQuery.ToString(), new { activoParametro = activo }).ToList();
            }

            return lista;
        }

        public Productos ObtenerObjeto()
        {
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");


            var obj = new Productos();
            using (var connection = new OracleConnection(conexionString))
            {
                obj = connection.Query<Productos>(sqlQuery.ToString()).FirstOrDefault();
            }

            return obj;
        }

        public Productos ObtenerObjeto(int id, bool activo)
        {


            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Id, Descripcion, Cantidad, Precio, FechaVencimiento, Activo ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = :p_Id  AND Activo = :p_Activo");

            string variableLogica = string.Empty;
            if (activo == true)
            {
                variableLogica = "Y";
            }
            else
            {
                variableLogica = "N";
            }

            var result = new Productos();

            var parameters = new { p_Id = id, p_Activo = variableLogica };

            var sql = sqlQuery.ToString();

            using (var connection = new OracleConnection(conexionString))
            {
                result = connection.Query<Productos>(sql, parameters).FirstOrDefault();
            }

            return result;
        }

        public string ObtenerCadena()
        {
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Descripcion ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            string cadena = string.Empty;
            using (var connection = new OracleConnection(conexionString))
            {
                cadena = connection.ExecuteScalar<string>(sqlQuery.ToString());
            }

            return cadena;
        }

        public int ObtenerEntero()
        {
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Cantidad ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            int entero = 0;
            using (var connection = new OracleConnection(conexionString))
            {
                entero = connection.ExecuteScalar<int>(sqlQuery.ToString());
            }

            return entero;
        }

        public decimal ObtenerDecimal()
        {
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT Precio ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            decimal nroDecimal = 0;
            using (var connection = new OracleConnection(conexionString))
            {
                nroDecimal = connection.ExecuteScalar<decimal>(sqlQuery.ToString());
            }

            return nroDecimal;
        }

        public DateTime ObtenerFecha()
        {
            string conexionString = @"Data Source=(DESCRIPTION=(ADDRESS=(PROTOCOL=TCP)(HOST=127.0.0.1)(PORT=1521))(CONNECT_DATA=(SERVICE_NAME=XE)));User Id=CYRE;Password=123456;";

            StringBuilder sqlQuery = new StringBuilder();
            sqlQuery.Append("SELECT FechaVencimiento ");
            sqlQuery.Append("FROM PRODUCTOS ");
            sqlQuery.Append("WHERE Id = 3 ");

            DateTime fecha = new DateTime(1985, 12, 20);

            using (var connection = new OracleConnection(conexionString))
            {
                fecha = connection.ExecuteScalar<DateTime>(sqlQuery.ToString());
            }

            return fecha;
        }

