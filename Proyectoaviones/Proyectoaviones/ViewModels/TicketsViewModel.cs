using Proyectoaviones.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyectoaviones.ViewModels
{
    public class TicketsViewModel : BaseViewModel
    {
        private string __id;

        public string _id
        {
            get { return __id; }
            set { __id = value; OnPropertyChanged(); }
        }

        private string _idvuelo;

        public string idvuelo
        {
            get { return _idvuelo; }
            set { _idvuelo = value; OnPropertyChanged(); }
        }

        private string _cliente;

        public string cliente
        {
            get { return _cliente; }
            set { _cliente = value; OnPropertyChanged(); }
        }

        private string _cantidad;

        public string cantidad
        {
            get { return _cantidad; }
            set { _cantidad = value; OnPropertyChanged(); }
        }

        private string _precio;

        public string precio
        {
            get { return _precio; }
            set { _precio = value; OnPropertyChanged(); }
        }


        private string _total;

        public string total
        {
            get { return _total; }
            set { _total = value; OnPropertyChanged(); }
        }

        public TicketsViewModel()
        {

        }

        public TicketsViewModel(Ventas vuelos)
        {
            _id = vuelos._id;
            idvuelo = vuelos.idvuelo;
            cliente = vuelos.cliente;
            cantidad = vuelos.cantidad;
            precio = vuelos.precio;
            total = vuelos.total;
        }

        public Ventas GetVuelo()
        {
            return new Ventas()
            {
                _id = this._id,
                idvuelo = this.idvuelo,
                cliente = this.cliente,
                cantidad = this.cantidad,
                precio = this.precio,
                total = this.total,
            };
        }
    }
}
