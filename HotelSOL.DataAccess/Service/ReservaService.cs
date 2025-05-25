using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using HotelSOL.DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelSOL.DataAccess.Services
{
    public class ReservaService
    {
        private readonly HotelSolContext _context;

        // Constructor que recibe el contexto
        public ReservaService(HotelSolContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        // Obtener todas las reservas
        public List<Reserva> ObtenerReservas()
        {
            return _context.Reservas.ToList();
        }

        // Obtener reservas activas
        public List<Reserva> ObtenerReservasActivas()
        {
            return _context.Reservas.Include(r => r.ReservaHabitaciones).Where(r => r.FechaFin >= DateTime.Today).ToList() ?? new List<Reserva>();
        }



        // Registrar una nueva reserva
        public void RegistrarReserva(Reserva nuevaReserva, List<int> habitacionesIds)
        {
            var strategy = _context.Database.CreateExecutionStrategy();
            strategy.Execute(() =>
            {
                using (var transaction = _context.Database.BeginTransaction())
                {
                    try
                    {
                        _context.Reservas.Add(nuevaReserva);
                        _context.SaveChanges();

                        if (nuevaReserva.Id == 0)
                        {
                            throw new Exception("Error: La reserva no fue creada correctamente en la base de datos.");
                        }

                        foreach (var habitacionId in habitacionesIds)
                        {
                            var reservaHabitacion = new ReservaHabitaciones
                            {
                                ReservaId = nuevaReserva.Id,
                                HabitacionId = habitacionId
                            };
                            _context.ReservaHabitaciones.Add(reservaHabitacion);
                        }

                        _context.SaveChanges();
                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception($"Error al guardar la reserva:\n{ex.InnerException?.Message ?? ex.Message}");
                    }
                 

                }
            });


        }


        // Cancelar reserva por ID
        public bool CancelarReserva(int reservaId)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.Id == reservaId);
            if (reserva == null) return false;


            if (reserva == null || reserva.Estado != EstadoReserva.Cancelada) // En vez de eliminarla, la marcamos como cancelada
                _context.SaveChanges();
            return true;
        }

        public bool RegistrarCheckIn(int reservaId)
        {
            var reserva = _context.Reservas.Include(r => r.ReservaHabitaciones)
                                           .FirstOrDefault(r => r.Id == reservaId);


            if (reserva == null || reserva.Estado != EstadoReserva.Confirmada)
                return false; // Validar que la reserva existe y está confirmada

            reserva.Estado = EstadoReserva.CheckIn; // En lugar de "Check-In"
            _context.SaveChanges();
            return true;
        }

        public bool RegistrarCheckOut(int reservaId)
        {
            var reserva = _context.Reservas.Include(r => r.ReservaHabitaciones)
                                           .FirstOrDefault(r => r.Id == reservaId);

            if (reserva == null || reserva.Estado != EstadoReserva.CheckIn)
                return false; // Asegurar que el cliente hizo check-in antes de hacer check-out
            reserva.Estado = EstadoReserva.CheckOut;
            _context.SaveChanges();
            return true;
        }
        public bool ConfirmarReserva(int reservaId)
        {
            var reserva = _context.Reservas.Find(reservaId);
            if (reserva == null || reserva.Estado != EstadoReserva.Pendiente)
                return false; // Solo se confirma si está pendiente

            reserva.Estado = EstadoReserva.Confirmada;
            _context.SaveChanges();
            return true;
        }

        public bool ValidarDisponibilidadHabitacion(int reservaId)
        {
            var reserva = _context.Reservas.Include(r => r.ReservaHabitaciones)
                                           .FirstOrDefault(r => r.Id == reservaId);

            if (reserva == null) return false;

            bool solapamiento = _context.ReservaHabitaciones
                .Where(rh => rh.ReservaId != reservaId)
                .Any(rh => _context.Reservas.Any(r => rh.ReservaId == r.Id &&
                    ((reserva.FechaInicio >= r.FechaInicio && reserva.FechaInicio < r.FechaFin) ||
                    (reserva.FechaFin > r.FechaInicio && reserva.FechaFin <= r.FechaFin))));

            return !solapamiento;
        }
        public void ActualizarReserva(Reserva reserva)
        {
            var reservaExistente = _context.Reservas.Include(r => r.Factura)
                                                    .Include(r => r.ReservaHabitaciones)
                                                    .FirstOrDefault(r => r.Id == reserva.Id);

            if (reservaExistente != null)
            {
                reservaExistente.Factura = reserva.Factura; // 🔹 Asignar la factura a la reserva
                _context.SaveChanges();
            }
        }


        public bool ModificarReserva(int reservaId, DateTime nuevaFechaInicio, DateTime nuevaFechaFin, EstadoReserva nuevoEstado)
        {
            var reserva = _context.Reservas.FirstOrDefault(r => r.Id == reservaId);
        if (reserva == null) return false;

        // Verificar solapamiento con otra reserva en las mismas fechas
        bool solapamiento = _context.ReservaHabitaciones
            .Where(rh => rh.ReservaId != reservaId)
            .Any(rh => _context.Reservas.Any(r =>
                rh.ReservaId == r.Id &&
                ((nuevaFechaInicio >= r.FechaInicio && nuevaFechaInicio < r.FechaFin) ||
                (nuevaFechaFin > r.FechaInicio && nuevaFechaFin <= r.FechaFin))
            ));

        if (solapamiento) return false; // No permitir modificación si hay conflicto

        reserva.FechaInicio = nuevaFechaInicio;
        reserva.FechaFin = nuevaFechaFin;
        reserva.Estado = nuevoEstado;

        _context.SaveChanges();
        return true;


    }
        public Reserva ObtenerReservaPorId(int reservaId)
        {
            return _context.Reservas.Include(r => r.Cliente).FirstOrDefault(r => r.Id == reservaId);
        }


    }
}
