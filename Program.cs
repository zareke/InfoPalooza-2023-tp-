//MENU
Dictionary<string,Cliente> clientes = new Dictionary<string, Cliente>();
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
double IngresarDouble(string prompt)
{
Console.Write(prompt + ": ");
    double num=0;
    string cadena = Console.ReadLine();
    while (cadena == null && !double.TryParse(cadena, out num))
    {

        Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
        cadena = Console.ReadLine();
    }

    return num;




}

//FUNCIONES DE PROYECTO
void NuevaInscripcion(){
string dni = IngresarDNI("Ingrese el DNI");
clientes.Add(dni,new Cliente(dni,IngresarCadena("Ingrese el apellido"), IngresarCadena("Ingrese el nombre"), IngresarInt("Ingrese el tipo de entrada (1,2,3,4)"), IngresarDouble("Ingrese el total abonado")));

}





