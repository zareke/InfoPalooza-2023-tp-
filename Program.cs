#region Menu
    Dictionary<int, Cliente> clientes = new Dictionary<int, Cliente>();
    List<DateTime> fechas = new List<DateTime>();
    List<double> pagos = new List<double>();
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
                ObtenerEstadisticasDelEvento();
                break;
    
            case "3":
                BuscarCliente("Ingrese el DNI del cliente que desea buscar");
    
                break;
    
            case "4":
    
                break;
        }
    } while (resp != "5");
#endregion
#region Funciones extra
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
                foreach (int k in clientes.Keys)
                {
    
                    if (clientes[k].DNI == dni)
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
        int num = 0;
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
        int num = 0;
        string cadena = Console.ReadLine();
        while (cadena == null || !int.TryParse(cadena, out num) || !(num > 0 && num <= 4))
        {
    
            Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
            cadena = Console.ReadLine();
        }
        valorEntrada = ObtenerValorEntrada(num);
        return num;
    
    
    
    
    }
    double IngresarDinero(string prompt)
    {
        Console.Write(prompt + ": ");
        double num = 0;
        string cadena = Console.ReadLine();
        while (cadena == null || !double.TryParse(cadena, out num) || !(num - valorEntrada >= 0))
        {
    
            Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
            cadena = Console.ReadLine();
        }
    
        return num;
    
    
    
    
    }
    DateTime IngresarFecha(string prompt)
    {
        Console.Write(prompt + ": ");
        DateTime date = new DateTime();
        string cadena = Console.ReadLine();
        while (cadena == null || !DateTime.TryParse(cadena, out date) || !(date.Month < DateTime.Today.Month || date.Year < DateTime.Today.Year))
        {
    
            Console.Write("Valor ingresado incorrecto.\nVuelva a intentarlo: ");
            cadena = Console.ReadLine();
        }
    
        if (!fechas.Contains(date)) fechas.Add(date);
        return date;
    
    
    }
#endregion
#region Funciones de proyecto
    void NuevaInscripcion()
    {
        int id = Tiquetera.DevolverUltimoId();
        clientes.Add(id, new Cliente(IngresarDNI("Ingrese el DNI"), IngresarCadena("Ingrese el apellido"), IngresarCadena("Ingrese el nombre"), IngresarTipoEntrada("Ingrese el tipo de entrada (1,2,3,4)"), IngresarDinero("Ingrese el total abonado"), IngresarFecha("Ingrese el dia que abonó")));
    
    
    }
    
    int ObtenerValorEntrada(int tipo)
    {
        switch (tipo)
        {
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
    
    
    
    void ObtenerEstadisticasDelEvento()
    {
    
        double totalRecaudacion = 0;
        if (clientes.Count == 0) Console.WriteLine("Aún no se anotó nadie");
        else
        {
            double cantTipo1 = 0, cantTipo2 = 0, cantTipo3 = 0, cantTipo4 = 0;
            foreach (int k in clientes.Keys)
            {
    
                switch (clientes[k].TipoEntrada)
                {
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
                totalRecaudacion += ObtenerValorEntrada(clientes[k].TipoEntrada);
    
    
                for (int i = 0; i < fechas.Count; i++)
                {
                    pagos.Add(0);
                    if (fechas[i] == clientes[k].DiaDePago)
                    {
                        pagos[i] += (ObtenerValorEntrada(clientes[k].TipoEntrada));
                    }
    
                }
            }
            cantTipo1 = (cantTipo1 / clientes.Count) * 100;
            cantTipo2 = (cantTipo2 / clientes.Count) * 100;
            cantTipo3 = (cantTipo3 / clientes.Count) * 100;
            cantTipo4 = (cantTipo4 / clientes.Count) * 100;
    
    
            Console.WriteLine($"-Hay {clientes.Count} cliente/s");
            Console.WriteLine($"-El {cantTipo1}% eligio el tipo de entrada 1, el {cantTipo2}% eligio el 2, el {cantTipo3}% eligio el 3, y el {cantTipo4}% eligio el 4");
            for (int i = 0; i < fechas.Count; i++)
            {
    
                Console.WriteLine("-El dia " + fechas[i].ToShortDateString() + " se pagó $" + pagos[i]);
            }
            Console.WriteLine("-En total se abonó $" + totalRecaudacion);
    
        }
    
    }
    
    
    //cambiar
    void BuscarCliente(string prompt)
    {
        if (clientes.Count == 0) Console.WriteLine("Aún no se anotó nadie");
        else
        {
            bool encontrado = false;
            
            Console.Write(prompt + ": ");
    
            int resp = int.Parse(Console.ReadLine());
    
            
            if (!clientes.ContainsKey(resp))
            {
    
                Console.WriteLine("El ID que ingresó no existe");
    
            }
            else
            {
    
    Cliente c = clientes[resp];
                Console.WriteLine($"-DNI: {c.DNI}\n-Nombre: {c.Nombre}\n-Apellido: {c.Apellido}\n-Tipo de entrada: {c.TipoEntrada}\n-Total abonado: {c.TotalAbonado}\n-Fecha de pago: {c.DiaDePago.ToShortDateString()}");
    
    
            }
        }
    
    
    }
#endregion

