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

namespace AdoNetHomeWork07
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Model1 db = new Model1();
        public MainWindow()
        {
            InitializeComponent();
        }
        public void GetAreaData(object sender, RoutedEventArgs e)
        {
            GV.Columns.Clear();
            List<Area> data = db.Area.Where(w => w.WorkingPeople > 2).ToList();
            
            GV.Columns.Add(new GridViewColumn() { Header = "AreaId", DisplayMemberBinding = new Binding() { Path = new PropertyPath("AreaId") } });
            GV.Columns.Add(new GridViewColumn() { Header = "FullName", DisplayMemberBinding = new Binding() { Path = new PropertyPath("FullName") } });
            List.ItemsSource = data;
        }
        public void GetAreaData2()
        {
            var data = db.Area.Where(w => w.AssemblyArea == true);
        }

        public void GetAreaData3()
        {
            var data = db.Area.Take(10);
        }

        public void GetAreaData4()
        {
            var data = db.Area.Skip(5).Take(8);
        }

        public void GetAreaData5()
        {
            var data = db.Area.ToList();
            var data2 = data.TakeWhile(tw => tw.OrderExecution != null);
        }

        public void GetAreaData6()
        {
            var data = db.Area.ToList();
            var data2 = data.TakeWhile(tw => tw.OrderExecution == null);
        }

        public void GetAreaData7()
        {
            var data = db.Area.GroupBy(gb => gb.IP);
        }

        public void GetAreaData8()
        {
            int[] arr = new[] { 22, 23, 24, 25, 26, 27, 28 };
            var data = db.Timer.Where(w => arr.Contains(w.AreaId.Value));
        }

        public void GetAreaData9()
        {
            int[] arr = new[] { 38, 39, 102 };
            var data = db.Timer.Where(w => arr.Contains(w.AreaId.Value)&& w.DateFinish != null).Where(w=> w.DateStart>= DateTime.Parse("01.06.2017 ")&& w.DateFinish<=DateTime.Parse("30.08.2017"));
        }

        public void GetAreaData10()
        {
            var data = db.Timer.Join(db.Area, tm => tm.DocumentId, ar => ar.AreaId, (tm, ar) => new { tm, ar });
        }

        public void GetAreaData11()
        {
            var data = db.Timer.GroupBy(gr => gr.DateStart).OrderByDescending(o => o.Key.Value);
           
        }

        private void Button_Click()
        {

        }
    }
}
