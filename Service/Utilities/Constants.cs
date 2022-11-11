namespace Services.Utilities
{
    public class Constants
    {
        //ABC Registros
        public const string CREATEOK = "Registro guardado correctamente.";
        public const string UPDATEOK = "Registro actualizado correctamente.";
        public const string DELETEOK = "Registro eliminado correctamente.";

        public const string EXIST = "El registro ya existe.";
        public const string DEPENDENT = "Existen registros que dependen. \n No se puede eliminar.";
        public const string NOTEXIST = "El registro no existe.";
        public const string LISTEMPTY = "No hay registros para visualizar";

        //REQUEST
        public const string REQ_OK = "Petición correcta";
        public const string REQ_ERR = "Petición incorrecta";
        public const string PARAM_ERR = "Favor de revisar los parámetros ingresados.";
        public const string OPERATION_NOT_FOUND = "No se encuentra la operación a realizar";
        public const string ZERO = "No se puede dividir entre cero";
    }
}