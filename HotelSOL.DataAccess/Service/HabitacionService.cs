using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelSOL.DataAccess.Services
{
    public class HabitacionService
    {
        private readonly HotelSolContext _context;

        public HabitacionService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // 🔹 Obtener habitaciones disponibles incluyendo el tipo de habitación
        public List<Habitacion> ObtenerHabitacionesDisponibles()
        {
            return _context.Habitaciones
                .Include(h => h.TipoHabitacion) // 🔹 Relación con `TipoHabitacion`
                .Where(h => h.Disponible)
                .ToList();
        }
        public List<Habitacion> ObtenerHabitacionesDisponiblesEnFechas(int cantidadPersonas, DateTime fechaInicio, DateTime fechaFin)
        {
            var habitacionesDisponibles = ObtenerHabitacionesDisponibles()
                .Where(h => h.Capacidad >= cantidadPersonas &&
                            !h.ReservaHabitaciones.Any(rh => rh.Reserva.FechaInicio <= fechaFin && rh.Reserva.FechaFin >= fechaInicio)) // 🔹 Filtra habitaciones sin reservas en esas fechas
                .ToList();

            return habitacionesDisponibles;
        }

        public Habitacion ObtenerHabitacionPorId(int habitacionId)
        {
            return _context.Habitaciones.Include(h => h.TipoHabitacion).FirstOrDefault(h => h.Id == habitacionId);
        }
        public TipoHabitacion ObtenerTipoHabitacionPorNombre(string nombreTipo)
        {
            return _context.TiposHabitaciones.FirstOrDefault(t => t.Nombre == nombreTipo);
        }
        public List<TipoHabitacion> ObtenerTiposHabitacion()
        {
            return _context.TiposHabitaciones.ToList();
        }


        // 🔹 Agregar una nueva habitación asignando el tipo correctamente
        public void AgregarHabitacion(Habitacion nuevaHabitacion)
        {
            if (nuevaHabitacion == null) throw new ArgumentNullException(nameof(nuevaHabitacion));

            var tipoHabitacion = _context.TiposHabitaciones.FirstOrDefault(t => t.Id == nuevaHabitacion.TipoId);
            if (tipoHabitacion == null) throw new InvalidOperationException("❌ Tipo de habitación no encontrado.");

            nuevaHabitacion.TipoHabitacion = tipoHabitacion; // 🔹 Se asigna el tipo de habitación a la nueva habitación
            _context.Habitaciones.Add(nuevaHabitacion);
            _context.SaveChanges();
        }

        // 🔹 Modificar habitación asegurando que el tipo exista
        public bool ModificarHabitacion(int habitacionId, string nuevoTipo, bool nuevaDisponibilidad)
        {
            var habitacion = _context.Habitaciones.Include(h => h.TipoHabitacion).FirstOrDefault(h => h.Id == habitacionId);
            if (habitacion == null) return false;

            var tipoHabitacion = _context.TiposHabitaciones.FirstOrDefault(t => t.Nombre == nuevoTipo);
            if (tipoHabitacion == null) return false; // 🔹 Verifica que el tipo de habitación existe

            habitacion.TipoId = tipoHabitacion.Id; // 🔹 Asigna el nuevo tipo de habitación
            habitacion.Disponible = nuevaDisponibilidad;

            _context.SaveChanges();
            return true;
        }

        // 🔹 Obtener el precio de una habitación desde `TipoHabitacion`
        public decimal ObtenerPrecioHabitacion(int habitacionId)
        {
            var habitacion = _context.Habitaciones.Include(h => h.TipoHabitacion).FirstOrDefault(h => h.Id == habitacionId);
            return habitacion?.TipoHabitacion.PrecioBase ?? 0; // Usa el precio del tipo de habitación
        }

        // 🔹 Eliminar habitación si no tiene reservas activas
        public bool EliminarHabitacion(int habitacionId)
        {
            var habitacion = _context.Habitaciones.FirstOrDefault(h => h.Id == habitacionId);
            if (habitacion == null) return false;

            bool tieneReservasActivas = _context.ReservaHabitaciones.Any(rh => rh.HabitacionId == habitacionId);
            if (tieneReservasActivas)
            {
                return false; // ❌ No permitir eliminación si hay reservas activas
            }

            _context.Habitaciones.Remove(habitacion);
            _context.SaveChanges();
            return true;
        }
        public void ActualizarDisponibilidadHabitacion(int habitacionId, bool disponible)
        {
            var habitacion = _context.Habitaciones.Find(habitacionId);
            if (habitacion != null)
            {
                habitacion.Disponible = disponible;
                _context.SaveChanges();
            }
        }


        public List<Habitacion> ObtenerHabitacionesParaCantidadPersonas(int cantidadPersonas)
        {
            var habitacionesDisponibles = ObtenerHabitacionesDisponibles()
                .Where(h => h.Capacidad >= cantidadPersonas) // 🔹 Filtrar por capacidad adecuada
                .ToList();

            if (!habitacionesDisponibles.Any())
            {
                // 🔹 Si no hay una habitación individual adecuada, buscar combinaciones
                habitacionesDisponibles = ObtenerHabitacionesDisponibles().OrderByDescending(h => h.Capacidad).ToList();
                List<Habitacion> seleccionadas = new List<Habitacion>();
                int capacidadTotal = 0;

                foreach (var habitacion in habitacionesDisponibles)
                {
                    if (capacidadTotal >= cantidadPersonas) break;
                    seleccionadas.Add(habitacion);
                    capacidadTotal += habitacion.Capacidad;
                }

                return capacidadTotal >= cantidadPersonas ? seleccionadas : new List<Habitacion>();
            }

            return habitacionesDisponibles;
        }

    }
}
