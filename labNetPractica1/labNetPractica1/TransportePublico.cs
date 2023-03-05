using System;
using System.Collections.Generic;

namespace Poo
{
    public abstract class TransportePublico
    {
        private int _pasajeros { get; set; }

        public TransportePublico(int _pasajeros)
        {
            this._pasajeros = _pasajeros;
        }

        public int get_pasajeros()
        {
            return _pasajeros;
        }

        public abstract void Avanzar();

        public abstract void Detenerse();

        public abstract void MostrarPasajeros();
    }
}
