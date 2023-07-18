using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalSim.Entidades
{
    public class FilaSimulacion
    {
        private Parametros parametros;
        public string evento { get; set; }
        public double reloj { get; set; }

        public LlegadaClientes llegadaClientes { get; set; }
        public FinTomaPedido finTomaPedido { get; set; }
        public FinPreparacionPedido finPreparacionPedido { get; set; }

        public FinEntregaPedido finEntregaPedido { get; set; }

        public FinConsumicion finConsumicion { get; set; }

        public Mozo mozo { get; set; }

        public Mesa[] mesas { get; set; }

        public int cantidadClientesNoAtendido { get; set; }

        public List<Cliente> clientes { get; set; }

        public List<Pedido> pedidos { get; set; }

        public FilaSimulacion() { }

        public FilaSimulacion(Parametros param)
        {
            this.parametros = param;
            // Con este metodo genero lo que seria la primera fila, incluyendo una instanciamiento de todos los objetos que forman parte de la fila
            // Genero la primera llegada para que inicie toda la simulacion

            evento = "inicializacion";
            reloj = 0;

            // Llegada Clientes

            this.llegadaClientes = new LlegadaClientes();

            llegadaClientes.tiempoEntreLlegadas = param.TiempoLlegadaClientes;

            llegadaClientes.proximaLlegada = llegadaClientes.NextComing(reloj);

            // Fin Toma Pedido

            this.finTomaPedido = new FinTomaPedido();

            // Fin Preparacion Pedido


            this.finPreparacionPedido = new FinPreparacionPedido();

            // Fin Entrega Pedido

            this.finEntregaPedido = new FinEntregaPedido();

            // Fin Consumicion

            this.finConsumicion = new FinConsumicion();

            // Mozo

            this.mozo = new Mozo();

            mozo.setLibre();
            mozo.colaPedidosPorEntregar = 0;
            mozo.mesaPendiente = 0;

            // Mesas

            this.mesas = new Mesa[6];
            for (int i = 0; i < 6; i++)
            {
                mesas[i] = new Mesa();
                mesas[i].setTableToFree();
            }

            // Estadistica

            this.cantidadClientesNoAtendido = 0;

            // Clientes

            this.clientes = new List<Cliente>();

            // Pedidos

            this.pedidos = new List<Pedido>();
        }

        public Pedido BuscarPedido(int numeroMesa)
        {
            for (int i = 0; i < this.pedidos.Count; i++)
            {
                if (pedidos[i].idMesa == numeroMesa + 1 && pedidos[i].estado != "morido")
                {
                    return pedidos[i];
                }
            }

            return new Pedido();
        }

        public FilaSimulacion Clone()
        {
            FilaSimulacion nuevaFila = new FilaSimulacion();

            nuevaFila.parametros = this.parametros.Clone(); // Realiza una copia de Parametros si también implementa Clone()
            nuevaFila.evento = this.evento;
            nuevaFila.reloj = this.reloj;
            nuevaFila.llegadaClientes = this.llegadaClientes.Clone(); // Realiza una copia de LlegadaClientes si también implementa Clone()
            nuevaFila.finTomaPedido = this.finTomaPedido.Clone(); // Realiza una copia de FinTomaPedido si también implementa Clone()
            nuevaFila.finPreparacionPedido = this.finPreparacionPedido.Clone(); // Realiza una copia de FinPreparacionPedido si también implementa Clone()
            nuevaFila.finEntregaPedido = this.finEntregaPedido.Clone(); // Realiza una copia de FinEntregaPedido si también implementa Clone()
            nuevaFila.finConsumicion = this.finConsumicion.Clone(); // Realiza una copia de FinConsumicion si también implementa Clone()
            nuevaFila.mozo = this.mozo.Clone(); // Realiza una copia de Mozo si también implementa Clone()

            // Copia de mesas (si Mesa también implementa Clone())
            if (this.mesas != null)
            {
                nuevaFila.mesas = new Mesa[this.mesas.Length];
                for (int i = 0; i < this.mesas.Length; i++)
                {
                    nuevaFila.mesas[i] = this.mesas[i].Clone();
                }
            }

            nuevaFila.cantidadClientesNoAtendido = this.cantidadClientesNoAtendido;

            // Copia de clientes (si Cliente también implementa Clone())
            if (this.clientes != null)
            {
                nuevaFila.clientes = new List<Cliente>();
                foreach (var cliente in this.clientes)
                {
                    nuevaFila.clientes.Add(cliente.Clone());
                }
            }

            // Copia de pedidos (si Pedido también implementa Clone())
            if (this.pedidos != null)
            {
                nuevaFila.pedidos = new List<Pedido>();
                foreach (var pedido in this.pedidos)
                {
                    nuevaFila.pedidos.Add(pedido.Clone());
                }
            }

            return nuevaFila;
        }

        public (string, double) Next()
        {
            List<(string, double)> Events = new List<(string, double)>();
            Events.Add(("llegada_clientes", llegadaClientes.proximaLlegada));
            Events.Add(("fin_toma_pedido", finTomaPedido.finTomaPedido));
            Events.Add(("fin_preparacion_pedido", finPreparacionPedido.nextFin()));
            Events.Add(("fin_entrega_pedido", finEntregaPedido.finEntregaPedido));
            Events.Add(("fin_consumicion_pedido", finConsumicion.nextFin()));

            double smaller = -1;
            string nextEvent = "";

            for (int i = 0; i < Events.Count; i++)
            {
                if (i == 0)
                {
                    smaller = Events[i].Item2;
                    nextEvent = Events[i].Item1;
                }
                else if ((smaller == 0) || (Events[i].Item2 < smaller && Events[i].Item2 != 0))
                {
                    smaller = Events[i].Item2;
                    nextEvent = Events[i].Item1;
                }
            }

            return (nextEvent, smaller);
        }

        public int FreeTable()
        {
            for (int i = 0; i < mesas.Length; i++)
            {
                if (mesas[i].estado == "Libre")
                {
                    return i;
                }
            }

            return -1;
        }

        public bool clientsWaiting()
        {
            foreach (var cliente in clientes)
            {
                if (cliente.estado == "Esperando Mesa")
                {
                    return true;
                }
            }

            return false;
        }

        public int amountTablesWaitingOrder()
        {
            int cantidadEsperando = 0;

            foreach (var mesa in this.mesas)
            {
                if (mesa.estado == "Esperando Ordenar")
                {
                    cantidadEsperando++;
                }
            }

            return cantidadEsperando;
        }

        public int InterrumpedTable()
        {
            int cantidadEsperando = 0;

            for (int i = 0; i < this.mesas.Length; i++)
            {
                if (mesas[i].estado == "Toma Interrumpida")
                {
                    return i;
                }
            }

            return cantidadEsperando;
        }

        public int amountTablesInterrumped()
        {
            int cantidadEsperando = 0;

            foreach (var mesa in this.mesas)
            {
                if (mesa.estado == "Toma Interrumpida")
                {
                    cantidadEsperando++;
                }
            }

            return cantidadEsperando;
        }

        public int amountTablesWaitingDelivery()
        {
            int cantidadEsperando = 0;

            foreach (var mesa in this.mesas)
            {
                if (mesa.estado == "Esperando Entrega")
                {
                    cantidadEsperando++;
                }
            }

            return cantidadEsperando;
        }

        public int amountFinished(double reloj)
        {
            int cantidadEsperando = 0;

            for (int i = 0; i < this.finPreparacionPedido.finesPreparacion.Length; i++)
            {
                if (this.finPreparacionPedido.finesPreparacion[i] == reloj)
                {
                    cantidadEsperando += 1;
                }
            }

            return cantidadEsperando;
        }

        public int nextTableToServeFood()
        {
            Mesa smaller = new Mesa();
            int numero = 0;
            List<Mesa> mesasList = new List<Mesa>();
            for (int i = 0; i < this.mesas.Length; i++)
            {
                if (this.mesas[i].estado == "Esperando Preparacion")
                {
                    mesasList.Add(this.mesas[i]);
                }
            }
            for (int i = 0; i < mesasList.Count; i++)
            {
                if (i == 0)
                {
                    smaller = mesasList[0];
                    numero = 0;
                }
                else
                {
                    if (mesasList[i].horaInicioEsperaComida < smaller.horaInicioEsperaComida)
                    {
                        smaller = mesasList[i];
                        numero = i;
                    }
                }
            }
            return numero;
        }

        public int nextTableToServe()
        {
            Mesa smaller = null;

            List<Mesa> mesasList = new List<Mesa>();

            for (int i = 0; i < this.mesas.Length; i++)
            {
                if (this.mesas[i].estado == "Esperando Ordenar")
                {
                    mesasList.Add(this.mesas[i]);
                }
            }

            for (int i = 0; i < mesasList.Count; i++)
            {
                if (
                    smaller == null
                    || mesasList[i].horaInicioEsperaMozo < smaller.horaInicioEsperaMozo
                )
                {
                    smaller = mesasList[i];
                }
            }

            int posicion = -1;
            if (smaller != null)
            {
                posicion = Array.IndexOf(this.mesas, smaller);
            }

            return posicion;
        }

        public int waitingWaiter()
        {
            int numeroMesa = 0;
            for (int i = 0; i < this.mesas.Length; i++)
            {
                if (mesas[i].estado == "Esperando Mozo")
                {
                    return numeroMesa = i;
                }
            }
            return numeroMesa;
        }

        public int chosedMenu(double rnd)
        {
            if (parametros.ProbabilidadMenu1 > parametros.ProbabilidadMenu2)
            {
                if (rnd < parametros.ProbabilidadMenu1)
                {
                    return 2;
                }
                else
                {
                    return 1;
                }
            }
            else
            {
                if (rnd < parametros.ProbabilidadMenu2)
                {
                    return 1;
                }
                else
                {
                    return 2;
                }
            }
        }

        public string[] ListaString(int clientesTotales, int condicionCorte)
        {
            //programar para devolver un vector de string con los datos de la fila
            var str = new string[]
            {
                this.evento,
                this.reloj.ToString(),
                this.llegadaClientes.tiempoEntreLlegadas == 0
                    ? ""
                    : this.llegadaClientes.tiempoEntreLlegadas.ToString(),
                this.llegadaClientes.proximaLlegada == 0
                    ? ""
                    : this.llegadaClientes.proximaLlegada.ToString(),
                this.llegadaClientes.RNDCantidadPersonas == 0
                    ? ""
                    : this.llegadaClientes.RNDCantidadPersonas.ToString(),
                this.llegadaClientes.CantidadPersonas == 0
                    ? ""
                    : this.llegadaClientes.CantidadPersonas.ToString(),
                this.finTomaPedido.RNDMenu == 0 ? "" : this.finTomaPedido.RNDMenu.ToString(),
                this.finTomaPedido.menu == 0 ? "" : this.finTomaPedido.menu.ToString(),
                this.finTomaPedido.tiempoPreparacion == 0
                    ? ""
                    : this.finTomaPedido.tiempoPreparacion.ToString(),
                this.finTomaPedido.finTomaPedido == 0
                    ? ""
                    : this.finTomaPedido.finTomaPedido.ToString(),
                this.finPreparacionPedido.finPreparacionPedido == 0
                    ? ""
                    : this.finPreparacionPedido.finPreparacionPedido.ToString(),
            };
            foreach (double fines in this.finPreparacionPedido.finesPreparacion)
            {
                str = str.Concat(new string[] { fines == 0 ? "" : fines.ToString() }).ToArray();
            }
            str = str.Concat(
                    new string[]
                    {
                        this.finEntregaPedido.finEntregaPedido == 0
                            ? ""
                            : this.finEntregaPedido.finEntregaPedido.ToString(),
                        this.finConsumicion.RND1 == 0 ? "" : this.finConsumicion.RND1.ToString(),
                        this.finConsumicion.RND2 == 0 ? "" : this.finConsumicion.RND2.ToString(),
                        this.finConsumicion.N1 == 0 ? "" : this.finConsumicion.N1.ToString(),
                        this.finConsumicion.N2 == 0 ? "" : this.finConsumicion.N2.ToString(),
                    }
                )
                .ToArray();

            foreach (double fines in this.finConsumicion.finesConsumicion)
            {
                str = str.Concat(new string[] { fines == 0 ? "" : fines.ToString() }).ToArray();
            }
            str = str.Concat(
                    new string[]
                    {
                        this.mozo.estado.ToString(),
                        this.mozo.mesaActual.ToString(),
                        this.mozo.cantidadPersonasAtendidas.ToString(),
                        this.mozo.colaPedidosPorEntregar.ToString(),
                        this.mozo.mesaPendiente.ToString(),
                    }
                )
                .ToArray();

            foreach (Mesa m in this.mesas)
            {
                str = str.Concat(
                        new string[]
                        {
                            m.estado.ToString(),
                            m.cantidadPersonas == 0 ? "" : m.cantidadPersonas.ToString(),
                            m.tiempoPreparacion == 0 ? "" : m.tiempoPreparacion.ToString(),
                            m.horaInicioEsperaComida == 0
                                ? ""
                                : m.horaInicioEsperaComida.ToString(),
                            m.horaInicioEsperaMozo == 0 ? "" : m.horaInicioEsperaMozo.ToString(),
                            m.tiempoRemanenteToma.ToString(),
                        }
                    )
                    .ToArray();
            }

            str = str.Concat(new string[] { this.cantidadClientesNoAtendido.ToString(), })
                .ToArray();

            var j = -1;
            foreach (Cliente c in this.clientes)
            {
                j++;
                if (j == condicionCorte)
                    break;
                str = str.Concat(
                        new string[]
                        {
                            c.estado == "morido" ? "" : c.estado,
                            c.estado == "morido" ? "" : c.numeroMesa.ToString()
                        }
                    )
                    .ToArray();
            }
            for (int i = 0; i < clientesTotales - this.clientes.Count; i++)
            {
                j++;
                if (j == condicionCorte)
                    break;
                str = str.Concat(new string[] { " ", " " }).ToArray();
            }
            foreach (Pedido p in this.pedidos)
            {
                j++;
                if (j == condicionCorte)
                    break;
                str = str.Concat(
                        new string[]
                        {
                            p.estado == "morido" ? "" : p.estado,
                            p.estado == "morido" ? "" : p.idMesa.ToString(),
                            (p.estado == "morido" || p.horaFinalizacion == 0)
                                ? ""
                                : p.horaFinalizacion.ToString(),
                        }
                    )
                    .ToArray();
            }
            return str;
        }
    }
}
