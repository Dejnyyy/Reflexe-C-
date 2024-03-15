using System.Reflection;

namespace ReflexeTestSlaby
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           
               
                Control clickedControl = sender as Control;

               
                
                
                this.Controls.Add(flowLayoutPanel2);

                
                Type type = clickedControl.GetType();

                MethodInfo[] methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            foreach (MethodInfo method in methods)
                {
                    if (method.GetParameters().Length == 0)
                    {
                        Button methodButton = new Button();
                        methodButton.Text = method.Name;
                        methodButton.Click += (s, args) =>
                        {
                           
                            object result = method.Invoke(clickedControl, null);
                            if (result != null)
                            {
                                MessageBox.Show("returnova hodnota: " + result.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Metoda nevrátila žádnou hodnotu.");
                            }
                        };
                    flowLayoutPanel2.Controls.Add(methodButton);
                }
                }

            }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
