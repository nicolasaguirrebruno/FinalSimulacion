using FinalSim.Entidades;
using FinalSim.Generadores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;
using static System.Windows.Forms.Design.AxImporter;

namespace FinalSim.Controlador
{
    public class ControladorSimulacion
    {
        private PrincipalForm principalForm;
        private Parametros parametros;
        public FilaSimulacion fila;
        private FilaSimulacion[] resultadosDesde;
        private Random randomGenerator = new Random();
        public int mesaAEntregar = -1;
        public double normalNoUsado = 0;
        public bool desdeActivado = false;
        public bool tomandoPedido = false;
        public int mesaMozo;

        public ControladorSimulacion(PrincipalForm principal, Parametros parametros)
        {
            this.principalForm = principal;
            this.parametros = parametros;

            if (parametros.CantidadIteraciones < parametros.Desde + 499)
            {
                resultadosDesde = new FilaSimulacion[
                    (int)(parametros.CantidadIteraciones - parametros.Desde + 1)
                ];
            }
            else
            {
                resultadosDesde = new FilaSimulacion[500];
            }
        }

        public void GenerateSimulation()
        {
            var indice = 0;
            for (int i = 0; i < parametros.CantidadIteraciones - 1; i++)
            {
                if (i + 1 == this.parametros.CantidadIteraciones)
                {
                    break;
                }
                if (i == 0)
                {
                    // Inicializamos condiciones iniciales

                    //Genero la fila inicializando los parametros
                    fila = new FilaSimulacion(parametros);

                    if (i >= parametros.Desde - 1 && i < (parametros.Desde + 499))
                    {
                        FilaSimulacion filaActual = (FilaSimulacion)fila.Clone(); // Realiza una copia del objeto fila
                        resultadosDesde[indice] = filaActual;
                        indice++;
                    }
                }
                else
                {
                    var next = fila.Next();

                    fila.evento = next.Item1;
                    fila.reloj = next.Item2;

                    if (fila.evento == "llegada_clientes")
                    {
                        LlegadaClientes(fila);
                    }

                    if (fila.evento == "fin_toma_pedido")
                    {
                        FinTomaPedido(fila);
                    }

                    if (fila.evento == "fin_preparacion_pedido")
                    {
                        FinPreparacionPedido(fila);
                    }
                    if (fila.evento == "fin_entrega_pedido")
                    {
                        FinEntregaPedido(fila);
                    }

                    if (fila.evento == "fin_consumicion_pedido")
                    {
                        FinConsumicionPedido(fila);
                    }
                    if (i > parametros.Desde - 1 && i < (parametros.Desde + 499))
                    {
                        FilaSimulacion filaActual = (FilaSimulacion)fila.Clone(); // Realiza una copia del objeto fila
                        //CleanRow(filaActual);
                        resultadosDesde[indice] = filaActual;
                        indice++;
                    }
                }
            }

            principalForm.CargarResultados(resultadosDesde);
        }

        public void LlegadaClientes(FilaSimulacion f)
        {
            f.llegadaClientes.proximaLlegada = f.llegadaClientes.NextComing(f.reloj);
            bool areClientsWaiting = f.clientsWaiting();
            int mesa = f.FreeTable();
            Cliente cliente;

            double rnd = GenerateRandom();
            f.llegadaClientes.RNDCantidadPersonas = rnd;
            int cantidadPersonas = Convert.ToInt32(
                Math.Floor(GeneradoresAleatorios.GenerateUniformAB(rnd, 1, 5))
            );
            f.llegadaClientes.CantidadPersonas = cantidadPersonas;

            if (areClientsWaiting == false && mesa != -1)
            {
                for (int i = 0; i < cantidadPersonas; i++)
                {
                    cliente = new Cliente("En Mesa", mesa + 1);

                    f.clientes.Add(cliente);
                }

                f.mesas[mesa].cantidadPersonas = cantidadPersonas;

                if (f.mozo.estado != "Libre")
                {
                    f.mesas[mesa].estado = "Esperando Ordenar";
                }
                else
                {
                    NuevaMesa(f, mesa);
                }
            }
            else
            {
                if (mesa != -1)
                {
                    for (int i = 0; i < cantidadPersonas; i++)
                    {
                        cliente = new Cliente("Esperando Mesa");

                        f.clientes.Add(cliente);
                    }
                }
                else
                {
                    f.cantidadClientesNoAtendido++;
                }
            }
        }

        public void FinTomaPedido(FilaSimulacion f)
        {
            if (f.mozo.colaPedidosPorEntregar == 0)
            {
                // Condicion para detectar que el mozo debe cambiar de mesa
                // Es decir que la cantidad de personas que atendio sea igual
                // a los que estan en esa mesa
                if (
                    f.mozo.cantidadPersonasAtendidas
                    == f.mesas[(int)(f.mozo.numeroMesa - 1)].cantidadPersonas
                )
                {
                    CambioMesa(f);
                }
                else if (f.mozo.cantidadPersonasAtendidas < f.mesas[mesaMozo].cantidadPersonas)
                {
                    //Genero el siguiente finTomaPedido
                    f.finTomaPedido.finTomaPedido = f.finTomaPedido.nextOrder(f.reloj, parametros);

                    //Metodo para tomar pedido
                    TomaPedido(f, mesaMozo);

                    // Condicion para detectar que el mozo debe cambiar de mesa
                    // Es decir que la cantidad de personas que atendio sea igual
                    // a los que estan en esa mesa
                    if (
                        f.mozo.cantidadPersonasAtendidas
                        == f.mesas[(int)(f.mozo.numeroMesa - 1)].cantidadPersonas
                    )
                    {
                        CambioMesa(f);
                    }
                }
            }
            else
            {
                f.mesas[f.mozo.numeroMesa - 1].estado = "Toma Interrumpida";
                FinPreparacionPedido(f);
            }
        }

        private void NuevaMesa(FilaSimulacion f, int numeroMesa)
        {
            // Cambio el estado del mozo y le reinicio la cantidad de personas atendidas
            f.mozo.setTomandoPedido();

            // Cambia el numero de mesa del mozo para asignarle la nueva mesa
            f.mozo.numeroMesa = numeroMesa + 1;

            // Cambio el estado de la nueva mesa
            f.mesas[numeroMesa].setTableToRequestingOrder();

            // Calculo el siguiente fin de toma Pedido
            f.finTomaPedido.finTomaPedido = f.finTomaPedido.nextOrder(f.reloj, parametros);

            mesaMozo = numeroMesa;

            tomandoPedido = true;

            // No tomo pedido porque recien llega el mozo, lo unico que hizo fue empezar a tomar la orden
        }

        private void CambioMesa(FilaSimulacion f)
        {
            // Seteo el fin de preparacion usando la acumulacion de los distintos tiempos de preparacion de la mesa
            f.finPreparacionPedido.finPreparacionPedido = f.mesas[mesaMozo].tiempoPreparacion;

            // Seteo el fin de preparacion especifico de la mesa ya que es un evento sub i
            f.finPreparacionPedido.finesPreparacion[mesaMozo] =
                f.mesas[mesaMozo].tiempoPreparacion + f.reloj;

            // Creo el nuevo pedido
            Pedido pedido = new Pedido(mesaMozo + 1, "Sin Finalizar");

            f.pedidos.Add(pedido);

            // Cambio el estado de la mesa a esperando comida
            f.mesas[mesaMozo].setTableToWaitingFood(f.reloj);

            // Me fijo la cantidad de mesas que hay esperando ordenar
            int numeroMesasEsperando = f.amountTablesWaitingOrder();

            //// Solo decremento esta cantidad si es distinto de cero
            //numeroMesasEsperando = numeroMesasEsperando == 0 ? 0 : numeroMesasEsperando--;

            // Se fija si hay mas de una mesa esperando
            if (numeroMesasEsperando > 1)
            {
                // Se fija por la que lleva mas tiempo esperando ser atendida
                mesaMozo = f.nextTableToServe();

                // Seteo los datos de la nueva mesa y el mozo
                NuevaMesa(f, mesaMozo);
            }
            else if (numeroMesasEsperando == 1)
            {
                //Obtengo la mesa que esta libre, que es una sola
                mesaMozo = f.waitingWaiter();

                // Seteo los datos de la nueva mesa y el mozo
                NuevaMesa(f, mesaMozo);
            }
            else if (numeroMesasEsperando == 0)
            {
                // Cambiar estado del mozo a libre
                f.mozo.setLibre();
                // Reinicio el fin toma pedido para que no se clave
                f.finTomaPedido.finTomaPedido = 0;
                //Reinicio la bandera de la toma pedido
                tomandoPedido = false;
            }
        }

        private void TomaPedido(FilaSimulacion f, int numeroMesa)
        {
            //Genero la informacion del menu que escogio la persona
            double rnd = GenerateRandom();
            int menu = f.chosedMenu(rnd);

            f.finTomaPedido.RNDMenu = rnd;

            f.finTomaPedido.menu = menu;

            if (menu == 1)
            {
                f.finTomaPedido.tiempoPreparacion = parametros.TiempoPreparacionMenu1;
            }
            else
            {
                f.finTomaPedido.tiempoPreparacion = parametros.TiempoPreparacionMenu2;
            }
            //Asigno el tiempo de preparacion
            f.mesas[numeroMesa].tiempoPreparacion += f.finTomaPedido.tiempoPreparacion;

            // Sumo uno a la cantidad de personas atendidas
            f.mozo.cantidadPersonasAtendidas++;
        }

        public void FinPreparacionPedido(FilaSimulacion f)
        {
            int numeroMesaAServir = 0;

            // Si el mozo esta libre o entregando (verificando que haya terminado la entrega previa con el ==-1)
            // entonces se puede entregar el siguiente pedido.
            if ((f.mozo.estado == "Libre" || f.mozo.estado == "Entregando") && mesaAEntregar == -1)
            {
                // Calculo el fin entrega pedido
                f.finEntregaPedido.finEntregaPedido = f.reloj + parametros.TiempoEntregaPedido;

                // Si el evento anterior fue un toma pedido y paso a entregando uso esta bandera
                // para reasignar el fin de la toma de pedido de la mesa interrumpida porque sino queda clavada
                // valiendo lo mismo y bugea el programa
                if (tomandoPedido == true)
                {
                    // reasigno la nueva toma como el fin pedido + lo que hubiese llevado la toma normalmente
                    f.finTomaPedido.finTomaPedido =
                        f.finEntregaPedido.finEntregaPedido + parametros.TiempoTomaPedido;
                    //Reinicio la bandera toma pedido
                    tomandoPedido = false;
                }

                // Me fijo si hay mas de una mesa esperando comida, esto es porque pueden haber dos mesas con el mismo fin preparacion
                if (f.amountFinished(f.reloj) > 1)
                {
                    // Si hay entonces me fijo cual mesa estuvo mas tiempo esperando para asignarla
                    numeroMesaAServir = f.nextTableToServeFood();

                    // Asigno el numero de a que mesa se entrega para despues usarlo
                    mesaAEntregar = numeroMesaAServir;

                    // A la/s mesas que tienen el mismo fin preparacion que no fueron seleccionadas les asigno el esperando entrega
                    for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                    {
                        if (
                            f.finPreparacionPedido.finesPreparacion[i] == f.reloj
                            && i != numeroMesaAServir
                        )
                        {
                            //Elimino el fin preparacion de la mesa que ya termino su preparacion del pedido y cambio estado
                            f.finPreparacionPedido.finesPreparacion[i] = 0;
                            f.mesas[i].estado = "Esperando Entrega";
                            f.mozo.colaPedidosPorEntregar++;
                        }
                    }
                }
                // Si no hay mas de una significa que es una sola asi que buscamos cual es esa que tiene de estado esperando comida
                else
                {
                    if (f.mozo.colaPedidosPorEntregar > 1)
                    {
                        for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                        {
                            if (f.finPreparacionPedido.finesPreparacion[i] == f.reloj)
                            {
                                //Asignamos la siguiente mesa a entregar
                                mesaAEntregar = i;
                                //Cambiamos estado a esperando entrega
                                f.mesas[i].estado = "Esperando Entrega";
                                //Elimino el fin preparacion de la mesa que termino su pedido
                                f.finPreparacionPedido.finesPreparacion[i] = 0;
                            }
                        }
                    }
                    else
                    {
                        for (int i = 0; i < f.mesas.Length; i++)
                        {
                            if (i == mesaMozo)
                            {
                                //Asignamos la siguiente mesa a entregar
                                mesaAEntregar = i;
                                //Cambiamos estado a esperando entrega
                                f.mesas[i].estado = "Esperando Entrega";
                                //Elimino el fin preparacion de la mesa que termino su pedido
                                f.finPreparacionPedido.finesPreparacion[i] = 0;
                            }
                        }
                    }
                }
                // Si el mozo estaba libre pasa a estar entregando
                if (f.mozo.estado == "Libre")
                {
                    f.mozo.estado = "Entregando";
                }
            }
            // Si el mozo esta tomando pedido o la mesa a entregar es distinto de cero indicando que el mozo esta entregando
            // ya que mesaAentregar !=-1
            else if (f.mozo.estado == "Tomando pedido" || mesaAEntregar != -1)
            {
                f.mozo.colaPedidosPorEntregar++;
                f.mozo.estado = "Entregando";

                // Asigno a la mesa que esta esperando su pedido
                for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                {
                    if (f.finPreparacionPedido.finesPreparacion[i] == f.reloj)
                    {
                        f.mesas[i].estado = "Esperando Entrega";
                        f.mozo.numeroMesa = i + 1;
                        mesaMozo = i;
                        if (f.mozo.estado == "Entregando")
                        {
                            f.finPreparacionPedido.finesPreparacion[i] = 0;
                        }
                    }
                }
            }
        }

        public void FinEntregaPedido(FilaSimulacion f)
        {
            // Cambio el estado de la mesa a la cual le sirvieron
            f.mesas[mesaAEntregar].estado = "Comiendo";
            // Calculo cantidad de mesas esperando ordenar
            int mesasEsperando = f.amountTablesWaitingOrder();
            // Asigno que el mozo se encuentra atendiendo esta mesa
            f.mozo.numeroMesa = mesaAEntregar + 1;

            // Cambio el estado del pedido involucrado
            foreach (var pedido in f.pedidos)
            {
                if (pedido.idMesa - 1 == mesaAEntregar)
                {
                    pedido.estado = "Entregado";
                }
            }

            // Si ya use el otro normal o es la primera vez genero el metodo box muller
            if (normalNoUsado == 0)
            {
                double rnd1 = GenerateRandom();
                double rnd2 = GenerateRandom();

                // Genero los dos numeros normales
                List<double> normales = GeneradoresAleatorios.GenerateBoxMuller(
                    (float)parametros.MediaConsumicionPedido,
                    (float)parametros.DesviacionConsumicionPedido,
                    1,
                    rnd1,
                    rnd2
                );

                // Asigno los normales de consumicion
                f.finConsumicion.N1 = normales[0];
                f.finConsumicion.N2 = normales[1];

                // Genero el siguiente fin consuimicion usando siempre el primer normal cuando se genere el metodo box muller
                f.finConsumicion.finesConsumicion[mesaAEntregar] = normales[1] + f.reloj;

                // Asigno al normal no usado como el segundo normal
                normalNoUsado = normales[0];
            }
            //Si el normal no usado tiene valor distinto a cero quiere decir que no lo emplee
            else
            {
                // Genero el siguiente fin consumicion usando el normal no usado
                f.finConsumicion.finesConsumicion[mesaAEntregar] = normalNoUsado + f.reloj;
                // Reinicio la variable del normalNoUsado
                normalNoUsado = 0;
            }

            // Verifico que la cola de pedido del mozo sea mayor a cero
            if (f.mozo.colaPedidosPorEntregar > 0)
            {
                // Decremento la cantidad de pedidos que tiene pendiente el mozo
                f.mozo.colaPedidosPorEntregar--;

                SiguienteEntrega(f, mesasEsperando);
            }
            else
            {
                SiguienteEntrega(f, mesasEsperando);
            }
        }

        public void SiguienteEntrega(FilaSimulacion f, int mesasEsperando)
        {
            int cantInterrumpidas = f.amountTablesInterrumped();
            int cantEsperandoEntrega = f.amountTablesWaitingDelivery();
            // Si luego de decrementar la cantidad de pedidos queda en cero y no hay mesas esperando ser tomadas el pedido
            if (f.mozo.colaPedidosPorEntregar == 0 && mesasEsperando == 0)
            {
                // Me fijo si quedo alguna mesa con toma interrumpida o esperando entrega
                if (cantInterrumpidas == 0 && cantEsperandoEntrega == 0)
                {
                    // El mozo queda libre
                    f.mozo.setLibre();

                    // Reinicio cantidad la variable mesa a entregar
                    mesaAEntregar = -1;

                    f.finEntregaPedido.finEntregaPedido = 0;
                }
                else
                {
                    if (cantInterrumpidas > 0 && cantEsperandoEntrega == 0)
                    {
                        // Cambio estado del mozo a tomando pedido
                        f.mozo.setTomandoPedido();
                        // Actualizo el estado de la mesa interrumpida a tomando pedido
                        int interrumpedTable = f.InterrumpedTable();

                        f.mesas[interrumpedTable].estado = "Tomando Pedido";

                        //Asigno el numero de mesa del mozo
                        f.mozo.numeroMesa = interrumpedTable + 1;

                        f.finTomaPedido.finTomaPedido = f.reloj + parametros.TiempoTomaPedido;
                    }
                    else if (cantInterrumpidas == 0 && cantEsperandoEntrega > 0)
                    {
                        // Me fijo si hay mas de una mesa esperando comida
                        if (cantEsperandoEntrega > 0)
                        {
                            // Si hay entonces me fijo cual mesa estuvo mas tiempo esperando para asignarla
                            int numeroMesaAServir = f.nextTableToServeFood();

                            // Asigno el numero de a que mesa se entrega para despues usarlo
                            mesaAEntregar = numeroMesaAServir;

                            f.finEntregaPedido.finEntregaPedido =
                                f.reloj + parametros.TiempoEntregaPedido;
                        }
                        // Si no hay mas de una significa que es una sola asi que buscamos cual es esa que tiene de estado esperando comida
                        else
                        {
                            for (int i = 0; i < f.mesas.Length; i++)
                            {
                                if (f.mesas[i].estado == "Esperando Entrega")
                                {
                                    // Asignamos el siguiente mesa a entregar
                                    mesaAEntregar = i;
                                    f.finEntregaPedido.finEntregaPedido =
                                        f.reloj + parametros.TiempoEntregaPedido;
                                }
                            }
                        }
                    }
                }
            }
            // Ahora si hay mas de 1 mesas esperando ser tomadas el pedido pero el mozo no tiene pedidos pendiente ni tampoco hay mesas interrumpidas
            else if (
                mesasEsperando > 0
                && f.mozo.colaPedidosPorEntregar == 0
                && f.amountTablesInterrumped() == 0
            )
            {
                // El mozo pasa a tomar pedido nuevamente
                f.mozo.setTomandoPedido();
                // Reinicio cantidad la variable mesa a entregar
                mesaAEntregar = -1;

                f.finEntregaPedido.finEntregaPedido = 0;
            }
            else if (
                mesasEsperando == 0
                && f.mozo.colaPedidosPorEntregar == 0
                && f.amountTablesInterrumped() > 0
            )
            {
                // El mozo pasa a tomar pedido nuevamente
                f.mozo.setTomandoPedido();

                // Actualizo el estado de la mesa interrumpida a tomando pedido
                int interrumpedTable = f.InterrumpedTable();

                f.mesas[interrumpedTable].estado = "Tomando Pedido";

                //Asigno el numero de mesa del mozo
                f.mozo.numeroMesa = interrumpedTable + 1;
            }
            // Si el mozo tiene pedidos por entregar si o si se va a entregar pedidos
            else if (f.mozo.colaPedidosPorEntregar > 0)
            {
                f.mozo.estado = "Entregando";

                // Calculo el fin entrega pedido
                f.finEntregaPedido.finEntregaPedido = f.reloj + parametros.TiempoEntregaPedido;

                if (f.finTomaPedido.finTomaPedido != 0)
                {
                    f.finTomaPedido.finTomaPedido =
                        f.finEntregaPedido.finEntregaPedido + parametros.TiempoTomaPedido;
                }

                // Me fijo si hay mas de una mesa esperando comida
                if (f.amountTablesWaitingDelivery() > 0)
                {
                    // Si hay entonces me fijo cual mesa estuvo mas tiempo esperando para asignarla
                    int numeroMesaAServir = f.nextTableToServeFood();

                    // Asigno el numero de a que mesa se entrega para despues usarlo
                    mesaAEntregar = numeroMesaAServir;
                }
                // Si no hay mas de una significa que es una sola asi que buscamos cual es esa que tiene de estado esperando comida
                else
                {
                    for (int i = 0; i < f.mesas.Length; i++)
                    {
                        if (f.mesas[i].estado == "Esperando Entrega")
                        {
                            // Asignamos el siguiente mesa a entregar
                            mesaAEntregar = i;
                        }
                    }
                }
            }
        }

        public void FinConsumicionPedido(FilaSimulacion f)
        {
            int numeroMesa = 0;

            // Me fijo que fin consumicion es para saber a que mesa le tengo que cambiar los parametros
            for (int i = 0; i < f.finConsumicion.finesConsumicion.Length; i++)
            {
                if (f.finConsumicion.finesConsumicion[i] == f.reloj)
                {
                    // Seteo el numero mesa
                    numeroMesa = i;
                    // Reinicio ese fin consumicion
                    f.finConsumicion.finesConsumicion[i] = 0;
                }
            }
            // Por cada pedido que coincida con el numero de mesa lo elimino

            List<Cliente> nuevosClientes = new List<Cliente>();
            foreach (var cliente in f.clientes)
            {
                if (cliente.numeroMesa - 1 != numeroMesa)
                {
                    nuevosClientes.Add(cliente);
                }
            }
            f.clientes = nuevosClientes;
            // Por cada pedido que coincida con el numero de mesa lo elimino
            List<Pedido> nuevosPedidos = new List<Pedido>();
            foreach (var pedido in f.pedidos)
            {
                if (pedido.idMesa - 1 != numeroMesa)
                {
                    nuevosPedidos.Add(pedido);
                }
            }
            f.pedidos = nuevosPedidos;

            // Pongo la mesa como libre
            f.mesas[numeroMesa].setTableToFree();
        }

        public double GenerateRandom()
        {
            return Math.Truncate(randomGenerator.NextDouble() * 100) / 100;
        }

        public void CleanRow(FilaSimulacion f)
        {
            switch (f.evento)
            {
                case "llegada_clientes":
                    f.finTomaPedido.RNDMenu = 0;
                    f.finTomaPedido.menu = 0;
                    f.finTomaPedido.tiempoPreparacion = 0;
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.finEntregaPedido.finEntregaPedido = 0;
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 = normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : 0;

                    break;
                case "fin_toma_pedido":
                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 = normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : 0;
                    f.finEntregaPedido.finEntregaPedido = 0;
                    ;
                    break;
                case "fin_preparacion_pedido":
                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    f.finTomaPedido.RNDMenu = 0;
                    f.finTomaPedido.menu = 0;
                    f.finTomaPedido.tiempoPreparacion = 0;
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 = normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : 0;
                    break;
                case "fin_entrega_pedido":
                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    f.finTomaPedido.RNDMenu = 0;
                    f.finTomaPedido.menu = 0;
                    f.finTomaPedido.tiempoPreparacion = 0;
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 = normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : 0;
                    break;

                case "fin_consumicion":
                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    f.finTomaPedido.RNDMenu = 0;
                    f.finTomaPedido.menu = 0;
                    f.finTomaPedido.tiempoPreparacion = 0;
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.finEntregaPedido.finEntregaPedido = 0;
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
