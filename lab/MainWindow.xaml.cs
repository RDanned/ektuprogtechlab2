using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Reflection;
using lab.src;

namespace lab
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// N 2.3.13
    public partial class MainWindow : Window
    {
        List<Route> routes = new List<Route>();
        public static Random rnd = new Random();
        int routesCount = 3;

        public MainWindow()
        {
            InitializeComponent();

            int angle = 0;
            for (int i = 0; i != this.routesCount; i++)
            {
                angle = rnd.Next(-90, 90);
                Console.WriteLine(i);
                Route route = new Route(Canvas);
                route.color = this.pickRandomBrush();
                route.setId(i);
                route.setAngle(angle);

                route.generateRoute();

                route.draw(Canvas);

                this.addRoute(route);


            }

            foreach(Route route in routes)
            {
                foreach(Graph graph in route.graphs)
                {
                    if(graph.name != null)
                    {
                        RoutesList.Items.Add(new { routeId = Convert.ToString(route.id), station = graph.name });
                    }
                    Console.WriteLine(graph.name);
                }
            }
        }

        private void addRoute(Route route)
        {
            this.routes.Add(route);
        }

        private SolidColorBrush pickRandomBrush()
        {
            SolidColorBrush result = Brushes.Transparent;

            int Seed = (int)DateTime.Now.Ticks;
            Random rnd = new Random(Seed);

            Type brushesType = typeof(Brushes);

            PropertyInfo[] properties = brushesType.GetProperties();

            int random = rnd.Next(properties.Length);
            result = (SolidColorBrush)properties[random].GetValue(null, null);

            return result;
        }
    }
}
