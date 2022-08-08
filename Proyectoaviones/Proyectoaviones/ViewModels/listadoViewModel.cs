using Proyectoaviones.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyectoaviones.ViewModels
{
    public class listadoViewModel : BaseViewModel
    {
        private string __id;
        public string _id
        {
            get { return __id; }
            set { __id = value; OnPropertyChanged(); }
        }

        private string _aerolinea;

        public string aerolinea
        {
            get { return _aerolinea; }
            set { _aerolinea = value; OnPropertyChanged(); }
        }

        private string _origen;

        public string origen
        {
            get { return _origen; }
            set { _origen = value; OnPropertyChanged(); }
        }

        private string _destino;

        public string destino
        {
            get { return _destino; }
            set { _destino = value; OnPropertyChanged(); }
        }

        private string _hora;

        public string hora
        {
            get { return _hora; }
            set { _hora = value; OnPropertyChanged(); }
        }


        private string _fecha;

        public string fecha
        {
            get { return _fecha; }
            set { _fecha = value; OnPropertyChanged(); }
        }

        private string _horallegada;

        public string horallegada
        {
            get { return _horallegada; }
            set { _horallegada = value; OnPropertyChanged(); }
        }
        private string _fechallegada;

        public string fechallegada
        {
            get { return _fechallegada; }
            set { _fechallegada = value; OnPropertyChanged(); }
        }

        private string _disponibles;

        public string disponibles
        {
            get { return _disponibles; }
            set { _disponibles = value; OnPropertyChanged(); }
        }



        public listadoViewModel()
        {

        }

        public listadoViewModel(VuelosDisponibles vuelos)
        {
            _id = vuelos._id;
            aerolinea = vuelos.aerolinea;
            origen = vuelos.origen;
            destino = vuelos.destino;
            hora = vuelos.hora;
            fecha = vuelos.fecha;
            horallegada = vuelos.horallegada;
            fechallegada = vuelos.fechallegada;
            disponibles = vuelos.disponibles;
        }

        public VuelosDisponibles GetVuelo()
        {
            return new VuelosDisponibles()
            {
                _id = this._id,
                aerolinea = this.aerolinea,
                origen = this.origen,
                destino = this.destino,
                hora = this.hora,
                fecha = this.fecha,
                horallegada = this.horallegada,
                fechallegada = this.fechallegada,
                disponibles = this.disponibles,
            };
        }
    }
}
