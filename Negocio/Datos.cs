using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio.Modelo;

namespace Negocio
{
    public class Datos
    {

        static public List<Product> listaProductos = new List<Product>() { };
        static public void Agregar(Product producto)
        {
            listaProductos.Add(producto);
        }


    }
}
