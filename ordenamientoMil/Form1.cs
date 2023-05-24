namespace ordenamientoMil
{
    public partial class Form1 : Form
    {
        bool estado = false;
        int[] Arreglo_numeros;
        Button[] Arreglo;
        Numeros Datos = new Numeros();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnOrdenar_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            btnOrdenar.Enabled = false;
            txtNumero.Enabled = false;
            btnAgregar.Enabled = false;

            BubbleSort(ref Arreglo_numeros, ref Arreglo);
            this.Cursor = Cursors.Default;

            btnOrdenar.Enabled = true;
            txtNumero.Enabled = true;
            btnAgregar.Enabled = true;
        }

        public void BubbleSort(ref int[] arreglo, ref Button[] arreglo_Numeros)
        {
            for (int i = 0; i < arreglo.Length; i++)
            {
                for (int j = 0; j < arreglo.Length - 1; j++)
                {
                    if (arreglo[j] > arreglo[j + 1])
                    {
                        Intercambio(ref arreglo_Numeros, j + 1, j);

                        int aux = arreglo[j];
                        arreglo[j] = arreglo[j + 1];
                        arreglo[j + 1] = aux;
                    }
                }
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                int num = Convert.ToInt32(txtNumero.Text);
                Datos.Insertar_Dato(num);
                Arreglo_numeros = Datos.Obtener_Arreglo();

                Arreglo = Datos.Arreglo_Botones();
            }
            catch
            {
                MessageBox.Show("Solo se admiten números enteros");
            }
            estado = true;
            tabPage1.Refresh();
        }

        private void tabPage1_Paint(object sender, PaintEventArgs e)
        {
            if (estado)
            {
                Point xy = new Point(50, 70);
                try
                {
                    Dibujar_Arreglo(ref Arreglo, xy, ref tabPage1);
                }
                catch
                {
                }
                estado = false;
            }
        }

        public void Dibujar_Arreglo(ref Button[] Arreglo, Point xy, ref TabPage t)
        {
            for (int i = 1; i < Arreglo.Length; i++)
            {
                Arreglo[i].Location = xy;
                t.Controls.Add(Arreglo[i]);
                xy += new Size(70, 0);
            }
        }

        public void Intercambio(ref Button[] boton, int a, int b)
        {
            string temp = boton[a].Text;

            Point pa = boton[a].Location;
            Point pb = boton[b].Location;
            int diferencia = pa.X - pb.X;
            int x = 10;
            int y = 10;
            int t = 70;

            while (y != 70)
            {
                Thread.Sleep(t);
                boton[a].Location += new Size(0, 10);
                boton[b].Location += new Size(0, -10);
                y += 10;
            }
            while (x != diferencia + 10)
            {
                Thread.Sleep(t);
                boton[a].Location += new Size(-10, 0);
                boton[b].Location += new Size(10, 0);
                x += 10;
            }

            y = 0;

            while (y != -60)
            {
                Thread.Sleep(t);
                boton[a].Location += new Size(0, -10);
                boton[b].Location += new Size(0, +10);
                y -= 10;
            }

            boton[a].Text = boton[b].Text;
            boton[b].Text = temp;
            boton[b].Location = pb;
            boton[a].Location = pa;
            estado = true;
            tabPage1.Refresh();

        }

    }


    class Numeros
    {
        private int longitud;
        private int[] arreglo = new int[1];
        private Button[] arreglo_botones = new Button[1];

        public Numeros()
        {
            int a = 0;
            arreglo[0] = a;
            arreglo_botones[0] = new Button();
            arreglo_botones[0].Width = 40;
            arreglo_botones[0].Height = 40;
            arreglo_botones[0].BackColor = Color.GreenYellow;
            arreglo_botones[0].Text = a.ToString();
            Calcular_Longitud();
        }
        public void Calcular_Longitud()
        {
            longitud = arreglo.Length;
        }
        public int Obtener_Longitud()
        {
            return longitud;
        }
        public int[] Obtener_Arreglo()
        {
            return arreglo;
        }
        public void Insertar_Dato(int dato)
        {
            Array.Resize<int>(ref arreglo, longitud + 1);
            arreglo[longitud] = dato;
            Array.Resize<Button>(ref arreglo_botones, longitud + 1);
            arreglo[longitud] = dato;
            arreglo_botones[longitud] = new Button();
            arreglo_botones[longitud].Width = 50;
            arreglo_botones[longitud].Height = 50;
            arreglo_botones[longitud].BackColor = Color.GreenYellow;
            arreglo_botones[longitud].Text = dato.ToString();
            Calcular_Longitud();
        }
        public Button[] Arreglo_Botones()
        {
            return arreglo_botones;
        }
    }
}

