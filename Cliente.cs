class Cliente{
#region constructor
        public Cliente(string dNI, string apellido, string nombre, int tipoEntrada, double totalAbonado)
        {
            DNI = dNI;
            Apellido = apellido;
            Nombre = nombre;
            TipoEntrada = tipoEntrada;
            TotalAbonado = totalAbonado;
        }
#endregion

 #region variables
 public string DNI{get;private set;}


public string Apellido{get;private set;}


public string Nombre{get;private set;}

public DateTime FechaInscripcion{get;private set;}


public int TipoEntrada{get;private set;}


public double TotalAbonado{get;private set;}

#endregion

#region funciones
    
    bool CambiarEntrada(int tipoEntrada, double totalAbonado){
    
    
    
        return false;
    }
#endregion
}