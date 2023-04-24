//MENU
Dictionary<string,Cliente> clientes = null;
string resp;
do
{
    resp = Menu();

    string Menu()
    {
        Console.WriteLine("1. Nueva Inscripción");
        Console.WriteLine("2. Obtener Estadísticas del Evento");
        Console.WriteLine("3. Buscar Cliente");
        Console.WriteLine("4. Cambiar entrada de un Cliente");
        Console.WriteLine("5. Salir");

        Console.Write("\nEliga la opcion que desea: ");
        return Console.ReadLine();
    }

    switch (resp)
    {

        case "1":
            NuevaInscripcion();

            break;

        case "2":

            break;


        case "3":

            break;

        case "4":

            break;
    }
} while (resp != "5");


//FUNCIONES EXTRA
string IngresarDNI(string prompt)
{
    
    bool noValido = false;
    string dni;
    int isNum;
    Console.Write(prompt + ": ");
    do
    {

        if (noValido) Console.Write("Ese DNI ya existe o el valor ingresado es incorrecto.\nVuelva a intentarlo: ");
        noValido = false;
        dni = Console.ReadLine();


        if (int.TryParse(dni, out isNum) && (isNum >= 10000000 && isNum <= 99999999))
        {
            foreach (string k in clientes.Keys)
            {

                if (k == dni)
                {
                    noValido = true;

                    break;
                }

            }
        }
        else
        {

            noValido = true;
        }
    } while (noValido);


    return dni;

}
string IngresarCadena(string prompt)
{

    Console.Write(prompt + ": ");
    string cadena = Console.ReadLine();
    while (cadena == null)
    {

        Console.Write("Debe ingresar al menos un caracter.\nVuelva a intentarlo: ");
        cadena = Console.ReadLine();
    }

    return cadena;




}
int IngresarInt(string prompt)
{
Console.Write(prompt + ": ");
    int num=0;
    string cadena = Console.ReadLine();
    while (cadena == null && !int.TryParse(cadena, out num))
    {

        Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
        cadena = Console.ReadLine();
    }

    return num;




}
int valorEntrada;
int IngresarTipoEntrada(string prompt)
{
Console.Write(prompt + ": ");
    int num=0;
    string cadena = Console.ReadLine();
    while (cadena == null || !int.TryParse(cadena, out num) || !(num >0 && num <=4))
    {

        Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
        cadena = Console.ReadLine();
    }
valorEntrada = num;
    return num;




}
double IngresarDinero(string prompt)
{
Console.Write(prompt + ": ");
    double num=0;
    string cadena = Console.ReadLine();
    while (cadena == null || !double.TryParse(cadena, out num) || !(num -valorEntrada >=0))
    {

        Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
        cadena = Console.ReadLine();
    }

    return num;




}

//FUNCIONES DE PROYECTO
void NuevaInscripcion(){
string dni = IngresarDNI("Ingrese el DNI");
clientes.Add(dni,new Cliente(dni,IngresarCadena("Ingrese el apellido"), IngresarCadena("Ingrese el nombre"),IngresarTipoEntrada("Ingrese el tipo de entrada (1,2,3,4)"), IngresarDinero("Ingrese el total abonado")));


}

int ObtenerValorEntrada(int tipo){
    switch(tipo){
case 1:
return 15000;
break;
case 2:
return 30000;
break;
case 3:
return 10000;
break;
case 4:
return 40000;
break;
default: 
return 0;
break;
    }
}



void ObtenerEstadisticasDelEvento(){


if(clientes == null) Console.WriteLine("Aún no se anotó nadie");
else{
int cantTipo1= 0, cantTipo2=0,cantTipo3=0,cantTipo4=0;
foreach(string d in clientes.Keys){

switch(clientes[d].TipoEntrada){
case 1:
cantTipo1++;
break;

case 2:
cantTipo2++;
break;

case 3:
cantTipo3++;
break;

case 4:
cantTipo4++;
break;
}

}

Console.WriteLine($"Hay {clientes.Count} cliente/s, de los cuales ");
}
}

