﻿using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticulosNegocio
    {
        public List<Articulo> listar()
        {
            // Creo la lista donde se almacenan los artículos
            List<Articulo> lista = new List<Articulo>();

            // Conexiones a la base de datos
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                // Configuro las conexiones
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; Integrated Security=True";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.IdMarca, M.Id, A.IdCategoria,C.Id, A.Precio\r\nFROM Articulos A\r\nINNER JOIN Marcas M ON M.Id = A.IdMarca\r\nINNER JOIN Categorias C ON C.Id = A.IdCategoria\r\nWHERE Activo = 1\r\n";
                comando.Connection = conexion;

                // Abro la base de datos
                conexion.Open();
                lector = comando.ExecuteReader();

                // Recorro los registros de la consulta
                while (lector.Read())
                {
                   
                    // Creo un nuevo objeto Articulo

                    Articulo aux = new Articulo
                    {

                        // Asigno los valores de las propiedades
                        Id = (int)lector["Id"],
                        Codigo = (string)lector["Codigo"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = (string)lector["Descripcion"],
                        IdMarca = (int)lector["IdMarca"],
                        Marca = new Marca { Descripcion = (string)lector["Marca"], Id = (int)lector["Id"] },
                        IdCategoria = (int)lector["IdCategoria"],
                        Categoria = new Categoria { Descripcion = (string)lector["Categoria"], Id = (int)lector["Id"] },
                        ImagenUrl = (string)lector["ImagenUrl"],
                        Precio = Math.Round((decimal)lector["Precio"], 2),

                    };
                        
               
                // Agrego el artículo a lS lista
                lista.Add(aux);
                }

                
                return lista;
            }
                catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }

        public List<Articulo> listarSinStock()
        {
            // Creo la lista donde se almacenan los artículos
            List<Articulo> lista = new List<Articulo>();

            // Conexiones a la base de datos
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;

            try
            {
                // Configuro las conexiones
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CATALOGO_DB; Integrated Security=True";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.IdMarca, M.Id, A.IdCategoria,C.Id, A.Precio\r\nFROM Articulos A\r\nINNER JOIN Marcas M ON M.Id = A.IdMarca\r\nINNER JOIN Categorias C ON C.Id = A.IdCategoria\r\nWHERE Activo = 0\r\n";
                comando.Connection = conexion;

                // Abro la base de datos
                conexion.Open();
                lector = comando.ExecuteReader();

                // Recorro los registros de la consulta
                while (lector.Read())
                {

                    // Creo un nuevo objeto Articulo

                    Articulo aux = new Articulo
                    {

                        // Asigno los valores de las propiedades
                        Id = (int)lector["Id"],
                        Codigo = (string)lector["Codigo"],
                        Nombre = (string)lector["Nombre"],
                        Descripcion = (string)lector["Descripcion"],
                        IdMarca = (int)lector["IdMarca"],
                        Marca = new Marca { Descripcion = (string)lector["Marca"], Id = (int)lector["Id"] },
                        IdCategoria = (int)lector["IdCategoria"],
                        Categoria = new Categoria { Descripcion = (string)lector["Categoria"], Id = (int)lector["Id"] },
                        ImagenUrl = (string)lector["ImagenUrl"],
                        Precio = Math.Round((decimal)lector["Precio"], 2),

                    };


                    // Agrego el artículo a lS lista
                    lista.Add(aux);
                }


                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.Close();
            }
        }


        public void agregar(Articulo nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into Articulos (Codigo, Nombre, Descripcion, ImagenUrl, IdMarca, IdCategoria, Precio) VALUES (@Codigo, @Nombre, @Descripcion,@ImagenUrl, @IdMarca, @IdCategoria, @Precio)");
                datos.setearParametros("@Codigo", nuevo.Codigo);
                datos.setearParametros("@Nombre", nuevo.Nombre);
                datos.setearParametros("@Descripcion", nuevo.Descripcion);
                datos.setearParametros("@ImagenUrl", nuevo.ImagenUrl);
                datos.setearParametros("@IdMarca", nuevo.Marca.Id);
                datos.setearParametros("@IdCategoria", nuevo.Categoria.Id);
                datos.setearParametros("@Precio", nuevo.Precio);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void modificar(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("update Articulos set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, ImagenUrl = @ImagenUrl , IdMarca = @IdMarca, IdCategoria = @IdCategoria, Precio = @Precio where Id = @Id");
                datos.setearParametros("@Codigo", articulo.Codigo);
                datos.setearParametros("@Nombre", articulo.Nombre);
                datos.setearParametros("@Descripcion", articulo.Descripcion);
                datos.setearParametros("@ImagenUrl", articulo.ImagenUrl);
                datos.setearParametros("@Precio", articulo.Precio);
                datos.setearParametros("@IdMarca", articulo.Marca.Id);
                datos.setearParametros("@IdCategoria", articulo.Categoria.Id);
                datos.setearParametros("@Id", articulo.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("Delete Articulos where Id = @Id");
                datos.setearParametros("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarLogico(int Id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta("update Articulos set Activo = 0 where Id = @Id");
                datos.setearParametros("@Id", Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.IdMarca, M.Id, A.IdCategoria,C.Id, A.Precio FROM Articulos A INNER JOIN Marcas M ON M.Id = A.IdMarca INNER JOIN Categorias C ON C.Id = A.IdCategoria WHERE Activo = 1 AND ";

                if (campo != null)
                {
                    if (campo == "Precio")
                    {
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "A.Precio > " + filtro;
                                //Console.WriteLine(consulta);
                                break;

                            case "Menor a":
                                consulta += "A.Precio < $" + filtro;
                                break;

                            case "Igual a":
                                consulta += "A.Precio = $" + filtro;
                                break;
                        }

                    }
                    else if (campo == "Nombre")
                    {
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Nombre like '" + filtro + "%' ";
                                break;

                            case "Termina con":
                                consulta += "A.Nombre like '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consulta += "A.Nombre like '%" + filtro + "%'";
                                break;
                        }

                    }
                    else
                    {
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like '" + filtro + "%' ";
                                break;

                            case "Termina con":
                                consulta += "A.Descripcion like '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                    }
                } 
                else
                {
                    consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.ImagenUrl, M.Descripcion AS Marca, C.Descripcion AS Categoria, A.IdMarca, M.Id, A.IdCategoria,C.Id, A.Precio\r\nFROM Articulos A\r\nINNER JOIN Marcas M ON M.Id = A.IdMarca\r\nINNER JOIN Categorias C ON C.Id = A.IdCategoria\r\nWHERE Activo = 1 and ";
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                

                // Recorro los registros de la consulta
                while (datos.Lector.Read())
                {

                    // Creo un nuevo objeto Articulo

                    Articulo aux = new Articulo
                    {

                        // Asigno los valores de las propiedades
                        Id = (int)datos.Lector["Id"],
                        Codigo = (string)datos.Lector["Codigo"],
                        Nombre = (string)datos.Lector["Nombre"],
                        Descripcion = (string)datos.Lector["Descripcion"],
                        IdMarca = (int)datos.Lector["IdMarca"],
                        Marca = new Marca { Descripcion = (string)datos.Lector["Marca"], Id = (int)datos.Lector["Id"] },
                        IdCategoria = (int)datos.Lector["IdCategoria"],
                        Categoria = new Categoria { Descripcion = (string)datos.Lector["Categoria"], Id = (int)datos.Lector["Id"] },
                        ImagenUrl = (string)datos.Lector["ImagenUrl"],
                        Precio = Math.Round((decimal)datos.Lector["Precio"], 2),

                    };


                    // Agrego el artículo a lS lista
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }

        
}

