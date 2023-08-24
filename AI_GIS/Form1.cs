using System;
using System.Collections.Generic;
using Npgsql;
using System.Drawing;
using System.Windows.Forms;

using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;

namespace AI_GIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class Substance
        {
            double density;
            /*
            byte speed;
            byte atmoState;
            sbyte temperature;
            double time;
            double volume;
            double spillArea;
            */
            double K1;
            double K2;
            double K3;
            double K4;
            double K5;
            double K6;
            double K7;
            public double q_1;
            public double q_2;
            public Substance(double speed, byte atmoState, sbyte temperature, bool type, double time, double volume, double spillArea)
            {
                K1 = 0.18;
                switch(speed)
                {
                    case 1: K4 = 1; break;
                    case 2: K4 = 1.33; break;
                    case 3: K4 = 1.67; break;
                    case 4: K4 = 2; break;
                    case 5: K4 = 2.34; break;
                    case 6: K4 = 2.67; break;
                    case 7: K4 = 3; break;
                    case 8: K4 = 3.34; break;
                    case 9: K4 = 3.67; break;
                    case 10: K4 = 4; break;
                    case 11: K4 = (5.68 - 4) / 5 + 4; break;
                    case 12: K4 = (5.68 - 4) / 5 * 2 + 4; break;
                    case 13: K4 = (5.68 - 4) / 5 * 3 + 4; break;
                    case 14: K4 = (5.68 - 4) / 5 * 4 + 4; break;
                    case 15: K4 = 5.68; break;
                }
                switch(atmoState)
                {
                    case 0: K5 = 0.08; break;
                    case 1: K5 = 0.23; break;
                    case 2: K5 = 1; break;
                }
                if (type)
                {
                    density = 0.0008;
                    K2 = 0.025;
                    K3 = 0.4;
                }
                else
                {
                    density = 0.0032;
                    K2 = 0.052;
                    K3 = 1;
                }

                if (temperature < -40) K7 = 0;
                else if (-40 <= temperature || temperature < -20) K7 = 0.3;
                else if (-20 <= temperature || temperature < 0) K7 = 0.6;
                else if (0 <= temperature || temperature < 20) K7 = 1;
                else K7 = 1.4;

                double q_0 = density * volume;
                double h = q_0 / spillArea;
                double T = (h * density) / (K2 * K4 * K7);

                if (T < 1) K6 = 1;
                else if (time < T) K6 = Math.Pow(time, 0.8);
                else if (T >= time) K6 = Math.Pow(T, 0.8);
                
                q_1 = K1 * K3 * K5 * K7 * q_0;
                q_2 = ((1 - K1) * K2 * K3 * K4 * K5 * K6 * K7 * q_0) / (h * density);
            }
        }

        // Список точек для зданий
        List<PointLatLng> coordsBuilding = new List<PointLatLng>();
        // Список точек для озёр
        List<PointLatLng> coordsLakes = new List<PointLatLng>();
        // Список точек для рек
        List<PointLatLng> coordsRivers = new List<PointLatLng>();
        // Список точек для лесов
        List<PointLatLng> coordsForests = new List<PointLatLng>();
        // Список точек для зоны заражения
        List<PointLatLng> coordsZone = new List<PointLatLng>();
        // Список точек юзера
        List<PointLatLng> coordsUser = new List<PointLatLng>();

        // Слой для зданий
        GMapOverlay overlayBuildings = new GMapOverlay("Здания");
        // Слой для озёр
        GMapOverlay overlayLakes = new GMapOverlay("Озёра");
        // Слой для рек
        GMapOverlay overlayRivers = new GMapOverlay("Реки");
        // Слой для лесов
        GMapOverlay overlayForests = new GMapOverlay("Леса");
        // Слой для лесов
        GMapOverlay overlayZone = new GMapOverlay("Зона заражения");
        // Слой для точек юзера
        GMapOverlay overlayUser = new GMapOverlay("Слой пользователя");

        bool isCorrect = false;

        // Установление соединения
        private NpgsqlConnection connection;
        string connect = String.Format("Server={0};Port={1};" + "User ID = {2};Password={3};Database={4};",
            "localhost", "5432", "postgres", "1123581321", "gis");
        private string SQL = null;
        string str;

        Point p;
        private string[] splittedCoords;
        private string[] coord;
        static internal bool isModified = false;
        static internal bool isClicked = false;
        static internal bool subType;
        static internal string direction;
        static internal double speed;
        static internal double spill;
        static internal double storageVolume;
        static internal double time;
        static internal sbyte temperature;
        static internal byte atmoState;

        private byte GetColumn (double num)
        {
            if (num > 2000 || (num > 1000) && (2000 - num <= num - 1000)) return 18;
            else if (num > 700 && (1000 - num <= num - 700)) return 17;
            else if (num > 500 && (700 - num <= num - 500)) return 16;
            else if (num > 300 && (500 - num <= num - 300)) return 15;
            else if (num > 100 && (300 - num <= num - 100)) return 14;
            else if (num > 50 && (100 - num <= num - 50)) return 13;
            else if (num > 30 && (100 - num <= num - 50)) return 12;
            else if (num > 20 && (30 - num <= num - 20)) return 11;
            else if (num > 10 && (20 - num <= num - 10)) return 10;
            else if (num > 5 && (10 - num <= num - 5)) return 9;
            else if (num > 3 && (5 - num <= num - 3)) return 8;
            else if (num > 1 && (3 - num <= num - 1)) return 7;
            else if (num > 0.5 && (1 - num <= num - 0.5)) return 6;
            else if (num > 0.1 && (0.5 - num <= num - 0.1)) return 5;
            else if (num > 0.05 && (0.1 - num <= num - 0.05)) return 4;
            else if (num > 0.01 && (0.05 - num <= num - 0.01)) return 3;
            else if (num > 0.01) return 2;
            else return 1;
        }
        #region Функции для win form
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - p.X;
                this.Top += e.Y - p.Y;
            }
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            p = new Point(e.X, e.Y);
        }

        private void CloseForm(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        // Загрузка карты
        private void button2_Click(object sender, EventArgs e)
        {
            GMaps.Instance.Mode = AccessMode.ServerAndCache; //выбор подгрузки карты – онлайн или из ресурсов
            gMap.MapProvider = GoogleMapProvider.Instance;
            gMap.ShowCenter = false; //показывать или скрывать красный крестик в центре
            gMap.MinZoom = 2; //минимальный зум
            gMap.MaxZoom = 18; //максимальный зум
            gMap.Zoom = 14; // какой используется зум при открытии
            gMap.Position = new PointLatLng(55.792060, 49.118498); // точка в центре карты при открытии (центр Казани)
            gMap.MouseWheelZoomType =
                MouseWheelZoomType
                    .MousePositionAndCenter; // как приближает (просто в центр карты или по положению мыши)
            gMap.CanDragMap = true; // перетаскивание карты мышью
            gMap.DragButton = MouseButtons.Left; // какой кнопкой осуществляется перетаскивание
            gMap.ShowTileGridLines = false; //показывать или скрывать тайлы
            gMap.PolygonsEnabled = true; // Разрешение полигонов
            gMap.RoutesEnabled = true; // Разрешение маршрутов
            gMap.ShowTileGridLines = false; // Скрытие внешней сетки карты
            gMap.MarkersEnabled = true; // Разрешение маркеров

            // Добавление оверлеев на карту
            gMap.Overlays.Add(overlayBuildings);
            overlayBuildings.IsVisibile = false;
            gMap.Overlays.Add(overlayLakes);
            overlayLakes.IsVisibile = false;
            gMap.Overlays.Add(overlayRivers);
            overlayRivers.IsVisibile = false;
            gMap.Overlays.Add(overlayForests);
            overlayForests.IsVisibile = false;
            gMap.Overlays.Add(overlayZone);
            overlayZone.IsVisibile = false;
            gMap.Overlays.Add(overlayUser);
            overlayUser.IsVisibile = false;
        }

        // Добавление маркера по двойному клику ЛКМ по карте
        private void gmap_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                // Широта - latitude - lat - с севера на юг
                double x = gMap.FromLocalToLatLng(e.X, e.Y).Lng;
                // Долгота - longitude - lng - с запада на восток
                double y = gMap.FromLocalToLatLng(e.X, e.Y).Lat;

                if (overlayZone.IsVisibile && !overlayUser.IsVisibile)
                {
                    // Добавляем метку на слой
                    GMapMarker MarkerWithMyPosition =
                    new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.arrow);
                    MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                    MarkerWithMyPosition.ToolTipText = "Поражаемый объект";
                    overlayZone.Markers.Add(MarkerWithMyPosition);
                }
                else if (!overlayZone.IsVisibile && overlayUser.IsVisibile)
                {
                    // Добавляем метку на слой
                    GMapMarker MarkerWithMyPosition =
                    new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.blue_pushpin);
                    MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                    MarkerWithMyPosition.ToolTipText = "Метка пользователя";
                    overlayUser.Markers.Add(MarkerWithMyPosition);
                }
                else
                    MessageBox.Show("Please choose between User's and Poisoning overlays", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Получение типа маркера 
        private byte GetFeature(GMarkerGoogleType type)
        {
            if (type == GMarkerGoogleType.blue_dot)
                return 1;
            else if (type == GMarkerGoogleType.red_dot)
                return 2;
            else if (type == GMarkerGoogleType.green_dot)
                return 3;
            else if (type == GMarkerGoogleType.yellow_dot)
                return 4;
            else if (type == GMarkerGoogleType.arrow)
                return 5;
            else
                return 6;
        }

        #region Чекбоксы
        // Чекбокс для слоя зданий
        private void checkBoxBuildings_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxBuildings.Checked)
            {
                ShowBuildings();
            }
            else
            {
                HideBuildings();
            }
        }

        // Чекбокс для слоя озёр
        private void checkBoxLakes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxLakes.Checked)
            {
                ShowLakes();
            }
            else
            {
                HideLakes();
            }
        }

        // Чекбокс для слоя рек
        private void checkBoxRivers_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRivers.Checked)
            {
                ShowRivers();
            }
            else
            {
                HideRivers();
            }
        }

        private void checkBoxForests_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxForests.Checked)
            {
                ShowForests();
            }
            else
            {
                HideForests();
            }
        }

        private void checkBoxZone_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxZone.Checked)
            {
                ShowZones();
            }
            else
            {
                HideZones();
            }
        }

        private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUser.Checked)
            {
                ShowUsersMarks();
            }
            else
            {
                HideUsersMarks();
            }
        }
        #endregion

        #region Отображения и скрытия маркеров
        // Отображение маркеров зданий
        private void ShowBuildings()
        {
            Dictionary<string, string> buildings = new Dictionary<string, string>();
            overlayBuildings.IsVisibile = true;
            connection = new NpgsqlConnection(connect);
            try
            {
                connection.Open();
                str = "SELECT" + "\"" + "center" + "\""+ "," + "\"" + "name" + "\"" + "FROM " + "\"" + "buildings" + "\"";
                SQL = @str;
                var cmd = new NpgsqlCommand(SQL, connection);
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    buildings.Add(rdr.GetString(1), rdr.GetString(0));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вот такой еррор: " + ex.Message, "еррор", MessageBoxButtons.OK);
            }
            DrawMarkers(buildings, 1, overlayBuildings);
        }

        // Скрытие маркеров зданий
        private void HideBuildings()
        {
            overlayBuildings.Clear();
            overlayBuildings.IsVisibile = false;
        }

        // Отображение маркеров озёр
        private void ShowLakes()
        {
            Dictionary<string, string> lakes = new Dictionary<string, string>();
            overlayLakes.IsVisibile = true;
            connection = new NpgsqlConnection(connect);
            try
            {
                connection.Open();
                str = "SELECT" + "\"" + "center" + "\"" + "," + "\"" + "name" + "\"" + "FROM " + "\"" + "lakes" + "\"";
                SQL = @str;
                var cmd = new NpgsqlCommand(SQL, connection);
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    lakes.Add(rdr.GetString(1), rdr.GetString(0));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вот такой еррор: " + ex.Message, "еррор", MessageBoxButtons.OK);
            }
            DrawMarkers(lakes, 2, overlayLakes);
        }

        // Скрытие маркеров озёр
        private void HideLakes()
        {
            overlayLakes.Clear();
            overlayLakes.IsVisibile = false;
        }

        // Отображение маркеров рек 
        private void ShowRivers()
        {
            Dictionary<string, string> rivers = new Dictionary<string, string>();
            overlayRivers.IsVisibile = true;
            connection = new NpgsqlConnection(connect);
            try
            {
                connection.Open();
                str = "SELECT" + "\"" + "center" + "\"" + "," + "\"" + "name" + "\"" + "FROM " + "\"" + "rivers" + "\"";
                SQL = @str;
                var cmd = new NpgsqlCommand(SQL, connection);
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    rivers.Add(rdr.GetString(1), rdr.GetString(0));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вот такой еррор: " + ex.Message, "еррор", MessageBoxButtons.OK);
            }
            DrawMarkers(rivers, 3, overlayRivers);
        }

        // Скрытие маркеров рек
        private void HideRivers()
        {
            overlayRivers.Clear();
            overlayRivers.IsVisibile = false;
        }

        // Отображение маркеров лесов 
        private void ShowForests()
        {
            Dictionary<string, string> forests = new Dictionary<string, string>();
            overlayForests.IsVisibile = true;
            connection = new NpgsqlConnection(connect);
            try
            {
                connection.Open();
                str = "SELECT" + "\"" + "center" + "\"" + "," + "\"" + "name" + "\"" + "FROM " + "\"" + "forests" + "\"";
                SQL = @str;
                var cmd = new NpgsqlCommand(SQL, connection);
                NpgsqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    forests.Add(rdr.GetString(1), rdr.GetString(0));
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Вот такой еррор: " + ex.Message, "еррор", MessageBoxButtons.OK);
            }
            DrawMarkers(forests, 4, overlayForests);
        }

        // Скрытие маркеров лесов
        private void HideForests()
        {
            overlayForests.Clear();
            overlayForests.IsVisibile = false;
        }

        // Отображение маркеров зон поражения
        private void ShowZones()
        {
            overlayZone.IsVisibile = true;
        }

        // Скрытие маркеров зон поражения
        private void HideZones()
        {
            overlayZone.IsVisibile = false;
        }

        // Отображение маркеров зон поражения
        private void ShowUsersMarks()
        {
            overlayUser.IsVisibile = true;
        }

        // Скрытие маркеров зон поражения
        private void HideUsersMarks()
        {
            overlayUser.IsVisibile = false;
        }
        #endregion

        #region Перегрузки функции отображения данных по каждому виду объектов
        private void ShowInfo(string name, string description, int date)
        {
            richTextBox1.Text = description.Equals(null) ? "Наименование: " + name +  "Год основания: " + date : "Наименование: " + name + "\n\nОписание: " + description + "\n\n" + "Год основания: " + date;
        }

        private void ShowInfo(string name, string description, double depth, double volume)
        {
            richTextBox1.Text = description.Equals(null) ? "Наименование: " + name + "\n\n" + "Глубина (м.): " + depth + "\n\n" + "Объём (миллион. куб. м.): " + volume:"Наименование: " + name + "\n\nОписание: " + description + "\n\n" + "Глубина (м.): " + depth + "\n\n" + "Объём (миллион. куб. м.): " + volume;
        }

        private void ShowInfo(string name, string description, double length, string isSandy)
        {
            richTextBox1.Text = description.Equals(null) ? "Наименование: " + name + "\n\n" + "Протяжённость (км.): " + length + "\n\n" + "Песчаное дно: " + isSandy: "Наименование: " + name + "\n\nОписание: " + description + "\n\n" + "Протяжённость (км.): " + length + "\n\n" + "Песчаное дно: " + isSandy;
        }

        private void ShowInfo(string name, string description, string type, double area)
        {
            richTextBox1.Text = description.Equals(null) ? "Наименование: " + name + "\n\n" + "Тип леса: " + type + "\n\n" + "Площадь (га): " + area: "Наименование: " + name + "\n\nОписание: " + description + "\n\n" + "Тип леса: " + type + "\n\n" + "Площадь (га): " + area;
        }
        #endregion

        // Отрисовка всех маркеров по их типу
        private void DrawMarkers(Dictionary<string, string> dict, byte feature, GMapOverlay overlay)
        {
            foreach (string key in dict.Keys)
            {
                splittedCoords = dict[key].Split(';');
                // Широта - latitude - lat - с севера на юг
                double y = Convert.ToDouble(splittedCoords[0]);
                // Долгота - longitude - lng - с запада на восток
                double x = Convert.ToDouble(splittedCoords[1]);
                GMapMarker MarkerWithMyPosition;
                // Добавляем метку на слой
                switch (feature)
                { 
                    case 1:
                        MarkerWithMyPosition =
                    new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.blue_dot);
                        MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                        MarkerWithMyPosition.ToolTipText = key;
                        overlay.Markers.Add(MarkerWithMyPosition);
                        break;
                    case 2:
                        MarkerWithMyPosition =
                    new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.red_dot);
                        MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                        MarkerWithMyPosition.ToolTipText = key;
                        overlay.Markers.Add(MarkerWithMyPosition);
                        break;
                    case 3:
                        MarkerWithMyPosition =
                    new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.green_dot);
                        MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                        MarkerWithMyPosition.ToolTipText = key;
                        overlay.Markers.Add(MarkerWithMyPosition);
                        break;
                    case 4:
                        MarkerWithMyPosition =
                    new GMarkerGoogle(new PointLatLng(y, x), GMarkerGoogleType.yellow_dot);
                        MarkerWithMyPosition.ToolTip = new GMapRoundedToolTip(MarkerWithMyPosition);
                        MarkerWithMyPosition.ToolTipText = key;
                        overlay.Markers.Add(MarkerWithMyPosition);
                        break;
                    default:
                        break;
                }              
            } 
        }

        // Получение инфы при нажатии на маркер
        private void gMap_OnMarkerClick(GMapMarker item, MouseEventArgs e)
        {
            GMarkerGoogle marker = item as GMarkerGoogle;
            byte feature = GetFeature(marker.Type);
            // Если нажали ЛКМ по метке - выдать подробную ифну о маркере
            if (e.Button == MouseButtons.Left)
            {
                string name = "", description = "", coords = "", center = "";
                try
                {
                    connection = new NpgsqlConnection(connect);
                    connection.Open();
                    NpgsqlCommand cmd;
                    NpgsqlDataReader rdr;
                    switch (feature)
                    {
                        case 1:
                            int date = 0;
                            str = "SELECT * FROM " + "\"" + "buildings" + "\"";
                            SQL = @str;
                            cmd = new NpgsqlCommand(SQL, connection);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                name = rdr.GetString(1);
                                description = rdr.IsDBNull(2) ? null : rdr.GetString(2);
                                coords = rdr.GetString(3);
                                date = rdr.GetInt32(4);
                                center = rdr.GetString(5);

                                if (item.Position.Lat == Convert.ToDouble(center.Substring(0, center.IndexOf(';'))) && item.Position.Lng == Convert.ToDouble(center.Substring(center.IndexOf(' '))))
                                {
                                    isCorrect = !isRemarked(overlayBuildings, name);
                                    if (isCorrect)
                                    {
                                        DrawPolygon(coords, coordsBuilding, name, overlayBuildings);
                                        ShowInfo(name, description, date);
                                    }
                                    else
                                        richTextBox1.Text = "";
                                    break;
                                }
                            }
                            break;
                        case 2:
                            double depth = 0, volume = 0;
                            str = "SELECT * FROM " + "\"" + "lakes" + "\"";
                            SQL = @str;
                            cmd = new NpgsqlCommand(SQL, connection);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                name = rdr.GetString(1);
                                description = rdr.IsDBNull(2) ? null : rdr.GetString(2);
                                coords = rdr.GetString(3);
                                depth = rdr.GetDouble(4);
                                center = rdr.GetString(5);
                                volume = rdr.GetDouble(6);

                                if (item.Position.Lat == Convert.ToDouble(center.Substring(0, center.IndexOf(';'))) && item.Position.Lng == Convert.ToDouble(center.Substring(center.IndexOf(' '))))
                                {
                                    isCorrect = !isRemarked(overlayLakes, name);
                                    if (isCorrect)
                                    {
                                        DrawPolygon(coords, coordsLakes, name, overlayLakes);
                                        ShowInfo(name, description, depth, volume);
                                    }
                                    else
                                        richTextBox1.Text = "";
                                    break;
                                }
                            }
                            break;
                        case 3:
                            double length = 0;
                            string isSandy = "";
                            str = "SELECT * FROM " + "\"" + "rivers" + "\"";
                            SQL = @str;
                            cmd = new NpgsqlCommand(SQL, connection);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                name = rdr.GetString(1);
                                description = rdr.IsDBNull(2) ? null : rdr.GetString(2);
                                coords = rdr.GetString(3);
                                length = rdr.GetDouble(4);
                                center = rdr.GetString(5);
                                isSandy = rdr.GetBoolean(6) ? "да": "нет";

                                if (item.Position.Lat == Convert.ToDouble(center.Substring(0, center.IndexOf(';'))) && item.Position.Lng == Convert.ToDouble(center.Substring(center.IndexOf(' '))))
                                {
                                    isCorrect = !isRemarked(overlayRivers, name);
                                    if (isCorrect)
                                    {
                                        DrawPolygon(coords, coordsRivers, name, overlayRivers);
                                        ShowInfo(name, description, length, isSandy);
                                    }
                                    else
                                        richTextBox1.Text = "";
                                    break;
                                }
                            }
                            break;
                        case 4:
                            double area = 0;
                            string type = "";
                            str = "SELECT * FROM " + "\"" + "forests" + "\"";
                            SQL = @str;
                            cmd = new NpgsqlCommand(SQL, connection);
                            rdr = cmd.ExecuteReader();
                            while (rdr.Read())
                            {
                                name = rdr.GetString(1);
                                description = rdr.IsDBNull(2) ? null: rdr.GetString(2);
                                coords = rdr.GetString(3);
                                type = rdr.GetString(4);
                                center = rdr.GetString(5);
                                area = rdr.GetDouble(6);

                                if (item.Position.Lat == Convert.ToDouble(center.Substring(0, center.IndexOf(';'))) && item.Position.Lng == Convert.ToDouble(center.Substring(center.IndexOf(' '))))
                                {
                                    isCorrect = !isRemarked(overlayForests, name);
                                    if (isCorrect)
                                    {
                                        DrawPolygon(coords, coordsForests, name, overlayForests);
                                        ShowInfo(name, description, type, area);
                                    }
                                    else
                                        richTextBox1.Text = "";
                                    break;
                                }
                            }
                            break;
                        case 5:
                            isModified = false;
                            Form2 optionsForm = new Form2();
                            optionsForm.ShowDialog();
                            while (!isClicked) ;
                            if (isModified)
                            {
                                Substance substance = new Substance(speed, atmoState, temperature, subType, time, storageVolume, spill);
                                str = "SELECT * FROM " + "\"" + "table_one" + "\"";
                                SQL = @str;
                                cmd = new NpgsqlCommand(SQL, connection);
                                rdr = cmd.ExecuteReader();
                                double gamma_1 = 0, gamma_2 = 0, gamma = 0;
                                while (rdr.Read())
                                {
                                    if (rdr.GetDouble(0) == speed || rdr.GetDouble(0) == 1 && speed < 1.5 || rdr.GetDouble(0) == 2 && speed >= 1.5 && speed < 2.5 || rdr.GetDouble(0) == 15 && speed > 15)
                                    {
                                        gamma_1 = rdr.GetDouble(GetColumn(substance.q_1));
                                        gamma_2 = rdr.GetDouble(GetColumn(substance.q_2));
                                        break;
                                    }
                                }
                                if (gamma_1 > gamma_2)
                                    gamma = gamma_1 + (gamma_2 * 0.5);
                                else
                                    gamma = gamma_2 + (gamma_1 * 0.5);
                                if (speed < 0.5)
                                    CreateCircle(gamma, item);
                                else if (speed >= 0.5 && speed < 1)
                                    CreateSector(gamma, item, direction);
                                else if (speed >= 1 && speed < 2)
                                    CreateSegment(gamma, item, direction, 90);
                                else
                                    CreateSegment(gamma, item, direction, 45);
                                isModified = false;
                            }
                            isClicked = false;
                            break;
                        case 6:
                            break;
                        default:
                            MessageBox.Show("Что - то пошло не так...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                    }
                    connection.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Вот такой еррор: " + ex.Message, "еррор", MessageBoxButtons.OK);
                }
            }
        }

        private void CreateSegment(double gamma, GMapMarker item, string direction, int phi)
        {
            PointLatLng point = new PointLatLng(item.Position.Lat, item.Position.Lng);
            int segments = phi;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            if (direction.ToLower() == "s")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 90) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "n")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i + 90) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "e")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 180) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "w")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, i * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "nw")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i + 45) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "se")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 135) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "sw")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 45) * (Math.PI / 180), gamma));
            }
            else
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i + 135) * (Math.PI / 180), gamma));
            }

            gpollist.Add(point);

            GMapPolygon polygon = new GMapPolygon(gpollist, "Сектор");

            polygon.Stroke = new Pen(Color.Red, 1);
            polygon.Fill = new SolidBrush(Color.FromArgb(60, Color.Red));
            overlayZone.Polygons.Add(polygon);
        }

        private void CreateSector(double gamma, GMapMarker item, string direction)
        {
            PointLatLng point = new PointLatLng(item.Position.Lat, item.Position.Lng);
            int segments = 180;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            if (direction.ToLower() == "s")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 90) * (Math.PI / 180), gamma));
            }  
            else if (direction.ToLower() == "n")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i + 90) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "e" )
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 180) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "w")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, i * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "nw")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i + 45) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "se")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 135) * (Math.PI / 180), gamma));
            }
            else if (direction.ToLower() == "sw")
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i - 45) * (Math.PI / 180), gamma));
            }
            else
            {
                for (int i = 0; i < segments; i++)
                    gpollist.Add(FindPointAtDistanceFrom(point, (i + 135) * (Math.PI / 180), gamma));
            }

            GMapPolygon polygon = new GMapPolygon(gpollist, "Полукругаль");

            polygon.Stroke = new Pen(Color.Red, 1);
            polygon.Fill = new SolidBrush(Color.FromArgb(60, Color.Red));
            overlayZone.Polygons.Add(polygon);
        }

        private void CreateCircle(double gamma, GMapMarker item)
        {
            PointLatLng point = new PointLatLng(item.Position.Lat, item.Position.Lng);
            int segments = 360;

            List<PointLatLng> gpollist = new List<PointLatLng>();

            for (int i = 0; i < segments; i++)
                gpollist.Add(FindPointAtDistanceFrom(point, i * (Math.PI / 180), gamma));

            GMapPolygon polygon = new GMapPolygon(gpollist, "Кругаль");

            polygon.Stroke = new Pen(Color.Red, 1);
            polygon.Fill = new SolidBrush(Color.FromArgb(60, Color.Red));
            overlayZone.Polygons.Add(polygon);
        }

        public static PointLatLng FindPointAtDistanceFrom(PointLatLng startPoint, double initialBearingRadians, double distanceKilometres)
        {
            const double radiusEarthKilometres = 6371.01;
            var distRatio = distanceKilometres / radiusEarthKilometres;
            var distRatioSine = Math.Sin(distRatio);
            var distRatioCosine = Math.Cos(distRatio);

            var startLatRad = DegreesToRadians(startPoint.Lat);
            var startLonRad = DegreesToRadians(startPoint.Lng);

            var startLatCos = Math.Cos(startLatRad);
            var startLatSin = Math.Sin(startLatRad);

            var endLatRads = Math.Asin((startLatSin * distRatioCosine) + (startLatCos * distRatioSine * Math.Cos(initialBearingRadians)));
            var endLonRads = startLonRad + Math.Atan2(Math.Sin(initialBearingRadians) * distRatioSine * startLatCos, distRatioCosine - startLatSin * Math.Sin(endLatRads));

            return new PointLatLng(RadiansToDegrees(endLatRads), RadiansToDegrees(endLonRads));
        }
        public static double DegreesToRadians(double degrees)
        {
            const double degToRadFactor = Math.PI / 180;
            return degrees * degToRadFactor;
        }
        public static double RadiansToDegrees(double radians)
        {
            const double radToDegFactor = 180 / Math.PI;
            return radians * radToDegFactor;
        }

        // Отрисовка полигона по координатам в текущем слое 
        private void DrawPolygon(string coords, List<PointLatLng> list, string name, GMapOverlay overlay)
        {
            list.Clear();
            splittedCoords = coords.Split(new char[1] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string s in splittedCoords)
            {
                coord = s.Split(';');
                list.Add(new PointLatLng(Convert.ToDouble(coord[0]), Convert.ToDouble(coord[1])));
            }

            var polygon = new GMapPolygon(list, name);
            polygon.Fill = new SolidBrush(Color.FromArgb(50, Color.Red));
            polygon.Stroke = new Pen(Color.Red);
            overlay.Polygons.Add(polygon);
        }

        // Проверка на то, был ли полигон уже отрисован
        private bool isRemarked(GMapOverlay overlay, string name)
        {
            foreach (var poly in overlay.Polygons)
            {
                if (poly.Name == name)
                {
                    overlay.Polygons.Remove(poly);
                    return true;
                }
            }
            return false;
        }
    }
}
