using System;
using System.Collections.Generic;
using System.Data;
using CapaDatos;

namespace CapaNegocio
{
    public class CNFactura
    {
        public static string FacturaInsertar(int id_empleado, int id_empresa, string metodo_pago, Decimal total, out int id_factura)
        {
            id_factura = 0;

            CDFactura objFactura = new CDFactura();
            objFactura.id_empleado = id_empleado;
            objFactura.id_empresa = id_empresa;
            objFactura.metodo_pago = metodo_pago;
            objFactura.total = total;

            string resultado = objFactura.FacturaInsertar(objFactura);

            if (resultado.StartsWith("OK:"))
            {
                string[] partes = resultado.Split(':');
                if (partes.Length > 1 && int.TryParse(partes[1], out int nuevoId))
                {
                    id_factura = nuevoId;
                    return "Cabecera de factura insertada correctamente!";
                }
            }

            return resultado;
        }

        public static string FacturaDetInsertar(int id_factura, int id_reserva, DateTime fecha_emision, decimal importe_total, int descuento)
        {
            // Validaciones básicas
            if (id_factura <= 0)
            {
                return "Error: ID de factura inválido.";
            }

            // Crear objeto de capa de datos
            CDFactura objDetalle = new CDFactura();
            objDetalle.id_factura = id_factura;
            objDetalle.id_reserva = id_reserva;
            objDetalle.fecha_emision = fecha_emision;
            objDetalle.importe_total = importe_total;
            objDetalle.descuento = descuento;

            // Ejecutar la inserción del detalle
            return objDetalle.FacturaDetInsertar(objDetalle);
        }

        public static string FacturaCompleta(int id_empleado, int id_empresa, string metodo_pago, Decimal total, List<(int id_reserva, DateTime fecha_emision, Decimal importe_total, int descuento)> detalles, out int id_factura)
        {
            id_factura = 0;

            if (detalles == null || detalles.Count == 0)
            {
                return "Error: Debe proporcionar al menos un detalle de factura.";
            }
            string resultadoCabecera = FacturaInsertar(id_empleado, id_empresa, metodo_pago, total, out id_factura);

            // Si hubo error, devolver el mensaje
            if (!resultadoCabecera.Contains("correctamente"))
            {
                return resultadoCabecera;
            }

            // Insertar cada detalle
            List<string> errores = new List<string>();
            foreach (var detalle in detalles)
            {
                string resultadoDetalle = FacturaDetInsertar(
                    id_factura,
                    detalle.id_reserva,
                    detalle.fecha_emision,
                    detalle.importe_total,
                    detalle.descuento
                );

                // Si hubo error, guardar el mensaje
                if (!resultadoDetalle.StartsWith("OK:"))
                {
                    errores.Add(resultadoDetalle);
                }
            }

            // Si hubo errores, devolver mensajes
            if (errores.Count > 0)
            {
                return $"Se insertó la factura #{id_factura} pero con errores en algunos detalles: {string.Join(", ", errores)}";
            }

            return $"Factura #{id_factura} insertada correctamente con {detalles.Count} detalles!";
        }

        public static string FacturaActualizar(int id_factura, int id_empleado, int id_empresa, string metodo_pago, decimal total)
        {
            CDFactura objFactura = new CDFactura();
            objFactura.id_factura = id_factura;
            objFactura.id_empleado = id_empleado;
            objFactura.id_empresa = id_empresa;
            objFactura.metodo_pago = metodo_pago;
            objFactura.total = total;

            return objFactura.FacturaActualizar(objFactura);
        }

        public static string FacturaDetActualizar(int id_facturadet, int id_factura, int id_reserva, DateTime fecha_emision, int descuento)
        {
            CDFactura objFactura = new CDFactura();
            objFactura.id_facturadet = id_facturadet;
            objFactura.id_factura = id_factura;
            objFactura.id_reserva = id_reserva;
            objFactura.fecha_emision = fecha_emision;
            objFactura.descuento = descuento;

            return objFactura.FacturaDetActualizar(objFactura);
        }

        public static string FacturaCompletaActualizar(int id_factura, int id_empleado, int id_empresa, string metodo_pago,
            decimal total, List<(int id_facturadet, int id_reserva, DateTime fecha_emision, decimal importe_total, int descuento)> detalles)
        {
            if (detalles == null || detalles.Count == 0)
            {
                return "Error: Debe proporcionar al menos un detalle de factura.";
            }

            // Usamos el total proporcionado desde la capa de presentación
            // Actualizar cabecera de factura
            string resultadoCabecera = FacturaActualizar(id_factura, id_empleado, id_empresa, metodo_pago, total);

            if (!resultadoCabecera.Contains("correctamente"))
            {
                return resultadoCabecera;
            }

            // Actualizar cada detalle de factura
            List<string> errores = new List<string>();
            foreach (var detalle in detalles)
            {
                string resultadoDetalle = FacturaDetActualizar(
                    detalle.id_facturadet,
                    id_factura,
                    detalle.id_reserva,
                    detalle.fecha_emision,
                    detalle.descuento
                );

                if (!resultadoDetalle.Contains("correctamente"))
                {
                    errores.Add(resultadoDetalle);
                }
            }

            if (errores.Count > 0)
            {
                return $"Se actualizó la factura #{id_factura} pero con errores en algunos detalles: {string.Join(", ", errores)}";
            }

            return $"Factura #{id_factura} actualizada correctamente con {detalles.Count} detalles!";
        }

        // CONSULTA DE FACTURAS
        public DataTable FacturaConsultar(string parametro)
        {
            CDFactura objFactura = new CDFactura();
            return objFactura.FacturaConsultar(parametro);
        }

        public  DataTable FacturaDetConsultar(string parametro)
        {
            CDFactura objFactura = new CDFactura();
            return objFactura.FacturaDetConsultar(parametro);
        }

        public DataTable FacturaTodo()
        {
            CDFactura objFactura = new CDFactura();
            return objFactura.FacturaTodo();
        }

        public DataTable FacturaCompletaConsultar(string parametro)
        {
            CDFactura objFactura = new CDFactura();
            DataTable dtDetalles = objFactura.FacturaDetConsultar(parametro);
            return dtDetalles;
        }

        // ELIMINACIÓN DE FACTURAS
        public static int FacturaEliminar(string parametro)
        {
            CDFactura objFactura = new CDFactura();
            return objFactura.FacturaEliminar(parametro);
        }
        public static int FacturaDetEliminar(string parametro)
        {
            CDFactura objFactura = new CDFactura();
            return objFactura.FacturaDetEliminar(parametro);
        }
    }
}
