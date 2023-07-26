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
        public int mesaMozo = -1;
        int lastTable;

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
            for (int i = 0; i <= parametros.CantidadIteraciones - 1; i++)
            {
                //if (i + 1 == this.parametros.CantidadIteraciones)
                //{
                //    break;
                //}
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
                        desdeActivado = true;
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
                    if (i >= parametros.Desde - 1 && i < (parametros.Desde + 499))
                    {
                        FilaSimulacion filaActual = (FilaSimulacion)fila.Clone(); // Realiza una copia del objeto fila
                        CleanRow(filaActual);
                        resultadosDesde[indice] = filaActual;
                        indice++;
                        desdeActivado = true;
                    }
                    else
                    {
                        desdeActivado = false;
                    }
                }
            }

            principalForm.CargarResultados(
                resultadosDesde,
                fila.cantidadClientesNoAtendido,
                Convert.ToInt64(parametros.CantidadIteraciones)
            );
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
                    f.mesas[mesa].horaInicioEsperaMozo = f.reloj;
                }
                else
                {
                    NuevaMesa(f, mesa);
                }
            }
            else
            {
                if (mesa == -1)
                {
                    bool hayEsperando = false;

                    for (int i = 0; i < f.clientes.Count; i++)
                    {
                        if (f.clientes[i].estado == "Esperando Mesa")
                        {
                            hayEsperando = true;
                        }
                    }

                    if (!hayEsperando)
                    {
                        for (int i = 0; i < cantidadPersonas; i++)
                        {
                            cliente = new Cliente("Esperando Mesa");

                            f.clientes.Add(cliente);
                        }
                    }
                    else
                    {
                        f.cantidadClientesNoAtendido += Convert.ToInt32(
                            Math.Floor(f.llegadaClientes.CantidadPersonas)
                        );
                    }
                }
            }
        }

        public void FinTomaPedido(FilaSimulacion f)
        {
            lastTable = f.mozo.mesaActual;
            if (f.mozo.cantidadPersonasAtendidas < f.mesas[mesaMozo].cantidadPersonas)
            {
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

                if (f.mesas[mesaMozo].tiempoPreparacion == 0)
                {
                    f.mesas[mesaMozo].tiempoPreparacion = f.finTomaPedido.tiempoPreparacion;
                }
                else if (f.finTomaPedido.tiempoPreparacion > f.mesas[mesaMozo].tiempoPreparacion)
                {
                    f.mesas[mesaMozo].tiempoPreparacion = f.finTomaPedido.tiempoPreparacion;
                }

                f.mozo.cantidadPersonasAtendidas++;

                if (f.mozo.cantidadPersonasAtendidas == f.mesas[mesaMozo].cantidadPersonas)
                {
                    f.finPreparacionPedido.finesPreparacion[mesaMozo] =
                        f.mesas[mesaMozo].tiempoPreparacion + f.reloj;

                    f.finPreparacionPedido.finPreparacionPedido =
                        f.mesas[mesaMozo].tiempoPreparacion + f.reloj;

                    Pedido pedido = new Pedido(f.mozo.mesaActual, "Sin Finalizar", 0);
                    f.pedidos.Add(pedido);

                    f.mesas[mesaMozo].estado = "Esperando Preparacion";
                    CambioMesa(f);
                }
                else
                {
                    f.finTomaPedido.finTomaPedido = f.reloj + parametros.TiempoTomaPedido;
                    tomandoPedido = true;
                }
            }
            else
            {
                f.finPreparacionPedido.finesPreparacion[mesaMozo] =
                    f.mesas[mesaMozo].tiempoPreparacion + f.reloj;
                f.finPreparacionPedido.finPreparacionPedido =
                    f.mesas[mesaMozo].tiempoPreparacion + f.reloj;

                Pedido pedido = new Pedido(f.mozo.mesaActual, "Sin Finalizar", 0);
                f.pedidos.Add(pedido);
                f.mesas[mesaMozo].estado = "Esperando Preparacion";

                CambioMesa(f);
            }
        }

        private void CambioMesa(FilaSimulacion f)
        {
            if (f.mozo.colaPedidosPorEntregar > 0)
            {
                int smaller = -1;
                for (int i = 0; i < f.pedidos.Count; i++)
                {
                    if (
                        f.pedidos[i].estado == "Esperando Entrega"
                        && f.pedidos[i].horaFinalizacion > 0
                    )
                    {
                        if (
                            smaller == -1
                            || f.pedidos[i].horaFinalizacion < f.pedidos[smaller].horaFinalizacion
                        )
                        {
                            smaller = i;
                        }
                    }
                }
                Pedido pedido = f.pedidos[smaller];

                f.finEntregaPedido.finEntregaPedido = f.reloj + parametros.TiempoEntregaPedido;
                mesaMozo = pedido.idMesa - 1;
                f.mozo.mesaActual = mesaMozo + 1;
                f.mozo.cantidadPersonasAtendidas = 0;
                f.finTomaPedido.finTomaPedido = 0;
                f.mozo.estado = "Entregando";
            }
            else
            {
                if (f.amountTablesWaitingOrder() == 0)
                {
                    f.mozo.setLibre();
                    f.mesas[mesaMozo].estado = "Esperando Preparacion";
                    mesaMozo = -1;
                    f.finTomaPedido.finTomaPedido = 0;
                    tomandoPedido = false;
                }
                else
                {
                    mesaMozo = f.nextTableToServe();
                    f.mozo.mesaActual = mesaMozo + 1;
                    f.mozo.estado = "Tomando Pedido";
                    f.mozo.cantidadPersonasAtendidas = 0;
                    f.finTomaPedido.finTomaPedido = f.reloj + parametros.TiempoTomaPedido;
                    f.mesas[mesaMozo].setTableToRequestingOrder();
                    tomandoPedido = true;
                }
            }
        }

        private void NuevaMesa(FilaSimulacion f, int numeroMesa)
        {
            // Cambio el estado del mozo y le reinicio la cantidad de personas atendidas
            f.mozo.setTomandoPedido();

            // Cambia el numero de mesa del mozo para asignarle la nueva mesa
            f.mozo.mesaActual = numeroMesa + 1;

            // Cambio el estado de la nueva mesa
            f.mesas[numeroMesa].setTableToRequestingOrder();

            // Calculo el siguiente fin de toma Pedido
            f.finTomaPedido.finTomaPedido = f.finTomaPedido.nextOrder(f.reloj, parametros);

            mesaMozo = numeroMesa;

            tomandoPedido = true;

            // No tomo pedido porque recien llega el mozo, lo unico que hizo fue empezar a tomar la orden
        }

        public void FinPreparacionPedido(FilaSimulacion f)
        {
            f.mozo.colaPedidosPorEntregar++;
            if (f.mozo.estado == "Tomando Pedido")
            {
                for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                {
                    if (f.finPreparacionPedido.finesPreparacion[i] == f.reloj)
                    {
                        f.finPreparacionPedido.finesPreparacion[i] = 0;
                        f.mesas[i].estado = "Esperando Entrega";
                        lastTable = i + 1;
                        Pedido pedido = f.BuscarPedido(i);

                        pedido.horaFinalizacion = f.reloj;
                        pedido.estado = "Esperando Entrega";
                    }
                }

                //f.mozo.estado = "Entregando";
                //f.mozo.mesaPendiente = mesaMozo + 1;
                //double fin = Math.Abs(f.reloj - f.finTomaPedido.finTomaPedido);
                //f.mesas[mesaMozo].tiempoRemanenteToma =
                //    fin == 0 ? parametros.TiempoTomaPedido : fin;
                //f.mesas[mesaMozo].estado = "Toma Interrumpida";

                //f.finEntregaPedido.finEntregaPedido = f.reloj + parametros.TiempoEntregaPedido;
                //if (f.amountFinished(f.reloj) == 1)
                //{
                //    for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                //    {
                //        if (f.finPreparacionPedido.finesPreparacion[i] == f.reloj)
                //        {
                //            f.finPreparacionPedido.finesPreparacion[i] = 0;
                //            f.mesas[i].estado = "Esperando Entrega";

                //            Pedido pedido = f.BuscarPedido(i);

                //            pedido.horaFinalizacion = f.reloj;
                //            pedido.estado = "Esperando Entrega";
                //            f.mozo.mesaActual = i + 1;
                //        }
                //    }
                //}
                //else
                //{
                //    int mesaAservir = f.nextTableToServeFood();

                //    f.finPreparacionPedido.finesPreparacion[mesaAservir] = 0;
                //    f.mesas[mesaAservir].estado = "Esperando Entrega";
                //    Pedido pedido = f.BuscarPedido(mesaAservir);
                //    pedido.horaFinalizacion = f.reloj;
                //    pedido.estado = "Esperando Entrega";
                //    f.mozo.mesaActual = mesaAservir + 1;
                //}
                //f.finTomaPedido.finTomaPedido = 0;
            }
            else
            {
                if (f.mozo.estado == "Libre")
                {
                    f.finEntregaPedido.finEntregaPedido = f.reloj + parametros.TiempoEntregaPedido;
                    f.mozo.estado = "Entregando";

                    for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                    {
                        if (f.finPreparacionPedido.finesPreparacion[i] == f.reloj)
                        {
                            f.finPreparacionPedido.finesPreparacion[i] = 0;
                            f.mesas[i].estado = "Esperando Entrega";
                            Pedido pedido = f.BuscarPedido(i);
                            lastTable = i + 1;
                            pedido.horaFinalizacion = f.reloj;
                            pedido.estado = "Esperando Entrega";

                            f.mozo.mesaActual = i + 1;
                        }
                    }
                }
                if (f.mozo.estado == "Entregando")
                {
                    for (int i = 0; i < f.finPreparacionPedido.finesPreparacion.Length; i++)
                    {
                        if (f.finPreparacionPedido.finesPreparacion[i] == f.reloj)
                        {
                            f.finPreparacionPedido.finesPreparacion[i] = 0;
                            Pedido pedido = f.BuscarPedido(i);
                            f.mesas[i].estado = "Esperando Entrega";
                            pedido.horaFinalizacion = f.reloj;
                            lastTable = i + 1;
                            pedido.estado = "Esperando Entrega";
                        }
                    }
                }
            }
        }

        public void FinEntregaPedido(FilaSimulacion f)
        {
            CalcularFinConsumicion(f);
            lastTable = f.mozo.mesaActual;
            if (f.mozo.colaPedidosPorEntregar > 0)
            {
                f.mozo.colaPedidosPorEntregar--;
                f.mesas[f.mozo.mesaActual - 1].estado = "Comiendo";

                if (f.mozo.colaPedidosPorEntregar > 0)
                {
                    int smaller = -1;
                    for (int i = 0; i < f.pedidos.Count; i++)
                    {
                        if (
                            f.pedidos[i].estado == "Esperando Entrega"
                            && f.pedidos[i].horaFinalizacion > 0
                        )
                        {
                            if (
                                smaller == -1
                                || f.pedidos[i].horaFinalizacion
                                    < f.pedidos[smaller].horaFinalizacion
                            )
                            {
                                smaller = i;
                            }
                        }
                    }

                    Pedido pedido = f.pedidos[smaller];

                    f.finEntregaPedido.finEntregaPedido = f.reloj + parametros.TiempoEntregaPedido;
                    mesaMozo = pedido.idMesa - 1;
                    f.mozo.mesaActual = mesaMozo + 1;

                    return;
                }
                else if (f.mozo.colaPedidosPorEntregar == 0)
                {
                    f.finEntregaPedido.finEntregaPedido = 0;

                    if (f.amountTablesWaitingOrder() == 0)
                    {
                        f.mozo.setLibre();
                    }
                    else
                    {
                        mesaMozo = f.nextTableToServe();
                        f.mozo.estado = "Tomando Pedido";
                        f.mozo.mesaActual = mesaMozo + 1;
                        f.mesas[mesaMozo].estado = "Tomando Pedido";
                        f.finTomaPedido.finTomaPedido = f.reloj + parametros.TiempoTomaPedido;
                    }
                }
            }
            else if (f.mozo.colaPedidosPorEntregar == 0)
            {
                f.finEntregaPedido.finEntregaPedido = 0;

                if (f.amountTablesWaitingOrder() == 0)
                {
                    f.mozo.setLibre();
                }
                else
                {
                    mesaMozo = f.nextTableToServe();
                    f.mozo.estado = "Tomando Pedido";
                    f.mozo.mesaActual = mesaMozo + 1;
                    f.mesas[mesaMozo].estado = "Tomando Pedido";
                    f.finTomaPedido.finTomaPedido = f.reloj + parametros.TiempoTomaPedido;
                }
            }
        }

        private void CalcularFinConsumicion(FilaSimulacion f)
        {
            if (normalNoUsado == 0)
            {
                double rnd1 = 1 - GenerateRandom();
                double rnd2 = 1 - GenerateRandom();

                f.finConsumicion.RND1 = rnd1;
                f.finConsumicion.RND2 = rnd2;

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
                f.finConsumicion.finesConsumicion[f.mozo.mesaActual - 1] = normales[0] + f.reloj;
                Pedido pedido = f.BuscarPedido(f.mozo.mesaActual - 1);
                pedido.estado = "Entregado";
                // Asigno al normal no usado como el segundo normal
                normalNoUsado = normales[1];
            }
            //Si el normal no usado tiene valor distinto a cero quiere decir que no lo emplee
            else
            {
                // Genero el siguiente fin consumicion usando el normal no usado
                f.finConsumicion.finesConsumicion[f.mozo.mesaActual - 1] = normalNoUsado + f.reloj;
                Pedido pedido = f.BuscarPedido(f.mozo.mesaActual - 1);
                pedido.estado = "Entregado";
                // Reinicio la variable del normalNoUsado
                normalNoUsado = 0;
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
                    lastTable = i + 1;
                }
            }
            if (!desdeActivado)
            {
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
            }
            else
            {
                foreach (var cliente in f.clientes)
                {
                    if (cliente.numeroMesa - 1 == numeroMesa)
                    {
                        cliente.estado = "morido";
                    }
                }

                foreach (var pedido in f.pedidos)
                {
                    if (pedido.idMesa - 1 == numeroMesa)
                    {
                        pedido.estado = "morido";
                    }
                }
            }
            // Pongo la mesa como libre
            f.mesas[numeroMesa].setTableToFree();
            int mesaLibre = f.FreeTable();
            int counter = 0;

            for (int i = 0; i < f.clientes.Count; i++)
            {
                if (f.clientes[i].estado == "Esperando Mesa")
                {
                    counter++;
                }
            }
            if (counter > 0)
            {
                for (int i = 0; i < f.clientes.Count; i++)
                {
                    if (f.clientes[i].estado == "Esperando Mesa")
                    {
                        f.clientes[i].estado = "En mesa";
                        f.clientes[i].numeroMesa = mesaLibre + 1;
                    }
                }
                if (f.mozo.estado != "Libre")
                {
                    f.mesas[mesaLibre].cantidadPersonas = counter;
                    f.mesas[mesaLibre].estado = "Esperando Ordenar";
                    f.mesas[mesaLibre].horaInicioEsperaMozo = f.reloj;
                }
                else
                {
                    f.mesas[mesaLibre].cantidadPersonas = counter;
                    NuevaMesa(f, mesaLibre);
                }
            }
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
                    if (f.mozo.estado != "Entregando")
                    {
                        f.finEntregaPedido.finEntregaPedido = 0;
                    }
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 = normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : 0;

                    break;
                case "fin_toma_pedido":

                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    if (f.finTomaPedido.finTomaPedido != 0)
                    {
                        f.finPreparacionPedido.finPreparacionPedido = 0;
                    }
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 = normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : 0;
                    f.finEntregaPedido.finEntregaPedido =
                        f.finEntregaPedido.finEntregaPedido == 0
                            ? 0
                            : f.finEntregaPedido.finEntregaPedido;
                    ;

                    f.evento = "fin_toma_pedido " + "(" + lastTable + ")";
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
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.evento = "fin_preparacion_pedido " + "(" + lastTable + ")";
                    break;
                case "fin_entrega_pedido":

                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    f.finTomaPedido.RNDMenu = 0;
                    f.finTomaPedido.menu = 0;
                    f.finTomaPedido.tiempoPreparacion = 0;
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.finConsumicion.RND1 = normalNoUsado == 0 ? 0 : f.finConsumicion.RND1;
                    f.finConsumicion.RND2 = normalNoUsado == 0 ? 0 : f.finConsumicion.RND2;
                    f.finConsumicion.N1 = normalNoUsado == 0 ? 0 : f.finConsumicion.N1;
                    f.finConsumicion.N2 =
                        normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : f.finConsumicion.N2;
                    f.evento = "fin_entrega_pedido " + "(" + lastTable + ")";
                    break;

                case "fin_consumicion_pedido":
                    f.llegadaClientes.tiempoEntreLlegadas = 0;
                    f.llegadaClientes.RNDCantidadPersonas = 0;
                    f.llegadaClientes.CantidadPersonas = 0;
                    f.finTomaPedido.RNDMenu = 0;
                    f.finTomaPedido.menu = 0;
                    f.finTomaPedido.tiempoPreparacion = 0;
                    f.finPreparacionPedido.finPreparacionPedido = 0;
                    f.finEntregaPedido.finEntregaPedido = 0;
                    f.finConsumicion.N1 = 0;
                    f.finConsumicion.N2 =
                        normalNoUsado == f.finConsumicion.N2 ? normalNoUsado : f.finConsumicion.N2;
                    f.finConsumicion.RND1 = 0;
                    f.finConsumicion.RND2 = 0;
                    f.evento = "fin_consumicion_pedido " + "(" + lastTable + ")";
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
