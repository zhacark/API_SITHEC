using System;
using System.Linq;
using System.Collections.Generic;
using Persistence.Models;

namespace Services.Extensions
{
    public static class Extensions
    {
        public static bool esFlotanteString(this string _cadena)
        {
            return ValidaFlotante(_cadena);
        }
        public static bool esFlotante(this float _cadena)
        {
            return ValidaFlotante(_cadena);
        }
        public static bool esEntero(this int _entero)
        {
            return ValidaEntero(_entero);
        }
        public static bool esOperacion(this string _cadena)
        {
            return ValidaOperacion(_cadena);
        }
        public static bool esCadenaVacia(this string _cadena)
        {
            return ValidaCadena(_cadena);
        }
        public static bool esHumanoValido(this DTOHumano _obj)
        {
            return ValidaHumano(_obj);
        }
        public static bool esListaVacia(this List<DTOHumano> _obj)
        {
            return ValidaLista(_obj);
        }
        #region Metodos Privados
        private static bool ValidaFlotante(string _valor)
        {
            return float.TryParse(_valor, out _);
        }
        private static bool ValidaFlotante(float _valor)
        {
            return float.TryParse(_valor.ToString(), out _);
        }
        private static bool ValidaEntero(int _valor)
        {
            return int.TryParse(_valor.ToString(), out _);
        }
        private static bool ValidaOperacion(string _valor)
        {
            string[] operaciones = { "suma", "resta", "multiplicacion", "division" };
            if (operaciones.Contains(_valor))
                return true;
            return false;
        }
        private static bool ValidaCadena(string _valor)
        {
            if (String.IsNullOrEmpty(_valor.Trim()))
                return true;
            else
                return false;
        }
        private static bool ValidaHumano(DTOHumano _valor)
        {
            if (!_valor.Nombre.esCadenaVacia() && !_valor.Sexo.esCadenaVacia() && _valor.Edad.esEntero() && _valor.Altura.esFlotante())
                return true;
            else
                return false;
        }
        private static bool ValidaLista(List<DTOHumano> _valor)
        {
            if (_valor == null)
                return true;
            if (_valor.Count == 0)
                return true;
            return false;
        }
        #endregion
    }
}