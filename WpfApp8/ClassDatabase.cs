using System;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace ProjektPlant
{
    public class ClassDatabase
    {
        public static int id_plant;
        public static int id_action;
        private SqlConnection cnn;
        public ObservableCollection<ClassPlant> collectionofplants = new ObservableCollection<ClassPlant>();
        public ObservableCollection<ClassAction> collectionofaction = new ObservableCollection<ClassAction>();
        public ObservableCollection<ClassView> collectionofview= new ObservableCollection<ClassView>();


        public void OpenConection()
        {
            string connetionString;
            connetionString = @"Data Source=DESKTOP-T7AJRB1\MSSQLSERVER01;Initial Catalog=Plants;Integrated Security=True";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            //MessageBox.Show("Connection Open  !");
        }

        public void CloseConection()
        {
            cnn.Close();
            //MessageBox.Show("Connection Close  !");
        }

        public void GetDatePlant()
        {
            SqlCommand command = new SqlCommand("getPlants", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                ClassPlant plant1 = new ClassPlant();
                plant1.ID = Convert.ToInt32(row["id_plant"]);
                id_plant = plant1.ID;
                plant1.nameOfPlant = (string)row["nameOfPlant"];
                plant1.nameOfPlantLatin = (string)row["nameOfPlantLatin"];
                plant1.origin = (string)row["origin"];
                plant1.light = (string)row["light"];
                plant1.water = Convert.ToInt32(row["water"]);
                plant1.fertilizationSpringSummer = Convert.ToInt32(row["fertilizationSpringSummer"]);
                plant1.fertilizationAutumnWinter = Convert.ToInt32(row["fertilizationAutumnWinter"]);
                plant1.subsoil = (string)row["subsoil"];
                try
                {
                    plant1.ImageBuffer = (string)row["picture"];
                }
                catch
                {

                }
                collectionofplants.Add(plant1);
            }
        }
        public void AddDatePlant(ClassPlant plant)
        {
            try
            {
                id_plant++;
                SqlCommand command = new SqlCommand("AddPlant", cnn);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id_plant;
                command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = plant.nameOfPlant;
                command.Parameters.AddWithValue("@NameLatin", SqlDbType.NVarChar).Value = plant.nameOfPlantLatin;
                command.Parameters.AddWithValue("@Origin", SqlDbType.NVarChar).Value = plant.origin;
                command.Parameters.AddWithValue("@light", SqlDbType.NVarChar).Value = plant.light;
                command.Parameters.AddWithValue("@water", SqlDbType.NVarChar).Value = plant.water;
                command.Parameters.AddWithValue("@fertilizationSS", SqlDbType.NVarChar).Value = plant.fertilizationSpringSummer;
                command.Parameters.AddWithValue("@fertilizationAW", SqlDbType.NVarChar).Value = plant.fertilizationAutumnWinter;
                command.Parameters.AddWithValue("@subsoil", SqlDbType.NVarChar).Value = plant.subsoil;
                command.Parameters.AddWithValue("@Image", SqlDbType.VarChar).Value = plant.ImageBuffer;
                SqlDataAdapter da = new SqlDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
            }
            catch
            {
                
            }
        }
        public void DeletleDatePlant(int id_deletle)
        {
            SqlCommand cmd = new SqlCommand("deletePlants", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id_deletle;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        public void EditDatePlant(ClassPlant plant)
        {
            SqlCommand command = new SqlCommand("updatePlant", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = plant.ID;
            command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = plant.nameOfPlant;
            command.Parameters.AddWithValue("@NameLatin", SqlDbType.NVarChar).Value = plant.nameOfPlantLatin;
            command.Parameters.AddWithValue("@Origin", SqlDbType.NVarChar).Value = plant.origin;
            command.Parameters.AddWithValue("@light", SqlDbType.NVarChar).Value = plant.light;
            command.Parameters.AddWithValue("@water", SqlDbType.NVarChar).Value = plant.water;
            command.Parameters.AddWithValue("@fertilizationSS", SqlDbType.NVarChar).Value = plant.fertilizationSpringSummer;
            command.Parameters.AddWithValue("@fertilizationAW", SqlDbType.NVarChar).Value = plant.fertilizationAutumnWinter;
            command.Parameters.AddWithValue("@subsoil", SqlDbType.NVarChar).Value = plant.subsoil;
            command.Parameters.AddWithValue("@Image", SqlDbType.VarChar).Value = plant.ImageBuffer;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

        public void GetDateAction()
        {
            SqlCommand command = new SqlCommand("getActions", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                ClassAction action = new ClassAction();
                action.ID = Convert.ToInt32(row["id_action"]);
                id_action = action.ID;
                action.nameOfPlant = (string)row["nameOfPlant"];
                action.action = (string)row["action"];
                action.description = (string)row["description"];

                collectionofaction.Add(action);
            }
        }
        public void AddDateAction(ClassAction care)
        {
            id_action++;
            SqlCommand command = new SqlCommand("AddAction", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id_action;
            command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = care.nameOfPlant;
            command.Parameters.AddWithValue("@Action", SqlDbType.NVarChar).Value = care.action;
            command.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = care.description;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        public void DeleteDateAction(int id_delete)
        {
            SqlCommand cmd = new SqlCommand("deleteAction", cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = id_delete;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }
        public void EditDateAction(ClassAction care)
        {
            SqlCommand command = new SqlCommand("updateAction", cnn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = care.ID;
            command.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = care.nameOfPlant;
            command.Parameters.AddWithValue("@Action", SqlDbType.NVarChar).Value = care.action;
            command.Parameters.AddWithValue("@Description", SqlDbType.NVarChar).Value = care.description;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
        }

        public void GetDateView()
        {
            SqlCommand command = new SqlCommand("getPlantView", cnn);
            command.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                ClassView view = new ClassView();
                id_action = view.ID;
                view.nameOfPlant = (string)row["nameOfPlant"];
                view.light = (string)row["light"];
                view.water = Convert.ToInt32(row["water"]);
                view.subsoil = (string)row["subsoil"];
                view.action = (string)row["action"];
                view.description = (string)row["description"];
                collectionofview.Add(view);
            }
        }
    }
}